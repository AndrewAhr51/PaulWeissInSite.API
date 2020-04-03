using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using PaulWeissInSite.API.Entities;
using PaulWeissInSite.API.Services;

namespace PaulWeissInSite.API
{
    public class Startup
    {
        public static IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            //Allows the calling application to return XML instead of the default JSON by passing the appropriate header
            services.AddMvc()
               .AddMvcOptions(o => o.OutputFormatters.Add(
                   new XmlDataContractSerializerOutputFormatter()));

#if DEBUG
            services.AddTransient<IMailService, IntegrationMailService>();
#else
            services.AddTransient<IMailService, ProductionMailService>();
#endif
            var cachetime =  Convert.ToInt32(Startup.Configuration["cacheSettings:CacheTime"]);

            services.AddHttpCacheHeaders((expirationModelOptions)
                =>
            { expirationModelOptions.MaxAge = cachetime;
            },
            (validationModelOptions)
            =>
            {
                validationModelOptions.AddMustRevalidate = true;
            });

            services.AddResponseCaching();

            var connectionString = Startup.Configuration["connectionStrings:DominoDBConnectionString"];
            var handshakeConnectionString = Startup.Configuration["connectionStrings:handshakeDBConnectionString"];
           
            services.AddDbContext<FirmEventsContext>(o => o.UseSqlServer(connectionString));
            services.AddDbContext<vFirmEventsContext>(o => o.UseSqlServer(connectionString));
            services.AddDbContext<View_PWInsiteNewsItemsContext>(o => o.UseSqlServer(connectionString));
            services.AddDbContext<PW_UrgentRefreshContext>(o => o.UseSqlServer(handshakeConnectionString));
            services.AddDbContext<vCommunityNewsContext>(o => o.UseSqlServer(connectionString));
            services.AddDbContext<vRecentHiresContext>(o => o.UseSqlServer(handshakeConnectionString));
            services.AddDbContext<vSpotlightContext>(o => o.UseSqlServer(handshakeConnectionString));

            services.AddScoped<IFirmEventRepository, FirmEventRepository>();
            services.AddScoped<IvFirmEventRepository, vFirmEventRepository>();
            services.AddScoped<IView_PWInsiteNewsItemsRepository, View_PWInsiteNewsItemsRepository>();
            services.AddScoped<IPW_UrgentRefreshRepository, PW_UrgentRefreshRepository>();
            services.AddScoped<IvCommunityNewsRepository, vCommunityNewsRepository>();
            services.AddScoped<IvRecentHiresRepository, vRecentHiresRepository>();
            services.AddScoped<IvSpotlightRepository, vSpotlightRepository>();
                   }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            loggerFactory.AddNLog();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStatusCodePages();
            }

            app.UseStatusCodePages();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Entities.PW_UrgentRefresh, Models.PW_UrgentRefreshDto>();
                cfg.CreateMap<Entities.vFirmEvents, Models.vFirmEventDto>();
                cfg.CreateMap<Entities.FirmEvents, Models.FirmEventDto>();
                //cfg.CreateMap<Entities.vCommunityNews, Models.vCommunityNewsDto>();
                //cfg.CreateMap<Entities.View_PWInsiteNewsItems, Models.View_PWInsiteNewsItemsDto>();
                cfg.CreateMap<Entities.vRecentHires, Models.vRecentHiresDto>();
                cfg.CreateMap<Entities.vSpotlight, Models.vSpotlightDto>();
            });

            app.UseCors("CorsPolicy");

            app.UseResponseCaching();

            app.UseHttpCacheHeaders();

            app.UseMvc();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
