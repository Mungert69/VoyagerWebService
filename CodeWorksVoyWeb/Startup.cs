using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using CodeWorksVoyWebService.Models.CubaData;
using CodeWorksVoyWebService.Models.UserData;
using CodeWorksVoyWebService.Models.VoyagerReserve;
using CodeWorksVoyWebService.Models.WebData;
using CodeWorksVoyWebService.Services;
using CodeWorksVoyWebService.Services;
using CodeWorksVoyWebService.Bussiness_Logic.Bussiness_Objects;

namespace CodeWorksVoyWeb
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            //Configuration = configuration;

            var builder = new ConfigurationBuilder()
           .SetBasePath(env.ContentRootPath)
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddSessionStateTempDataProvider();
            services.AddMemoryCache();
            services.AddResponseCompression();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin",
                    builder => builder.AllowAnyOrigin());
            });


            var conCubaData = @"Server=DEVELOP\CODEWORKS;Database=CubaData;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<CubaDataContext>(options => options.UseSqlServer(conCubaData));
            var conWebData = @"Server=DEVELOP\CODEWORKS;Database=WebData;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<WebDataContext>(options => options.UseSqlServer(conWebData));
            var conVoyagerReserve = @"Server=DEVELOP\CODEWORKS;Database=VoyagerReserve;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<VoyagerReserveContext>(options => options.UseSqlServer(conVoyagerReserve));
            var conUserData = @"Server=DEVELOP\CODEWORKS;Database=UserData;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<UserDataContext>(options => options.UseSqlServer(conUserData));


            services.AddTransient<ITransferAdapter, TransferAdapter>();
            services.AddTransient<IPlaceAdapter, PlaceAdapter>();
            services.AddTransient<IVoyResAdapter, VoyResAdapter>();
            services.AddTransient<IPicturesAdapter, PicturesAdapter>();
            services.AddTransient<IHotelAdapter, HotelAdapter>();
            services.AddTransient<IFlightAdapter, FlightAdapter>();
            services.AddTransient<ICardAdapter, CardAdapter>();
            services.AddTransient<IItineraryService, ItineraryService>();
            services.AddTransient<IPriceService, PriceService>();
            services.AddTransient<IUserItinAdapter, UserItinAdapter>();
            services.AddTransient<IMapService, MapService>();
            services.AddScoped<ICacheServices, CacheServices>();
           // services.AddSingleton<ISessionObject, SessionObject>();
            services.AddSingleton<ISessionObjectsService, SessionObjectsService>();
            services.AddSingleton<IConfiguration>(Configuration);

            services.AddHostedService<ConsumeScopedServiceHostedService>();
            services.AddScoped<IScopedProcessingService, ScopedProcessingService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseResponseCompression();
            app.UseCors("AllowAnyOrigin");
            app.UseHttpsRedirection();

           

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}/{id2?}/{id3?}");
            });

        }
    }
}
