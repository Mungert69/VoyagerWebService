using CodeWorksVoyWebService.Bussiness_Logic.Bussiness_Objects;
using CodeWorksVoyWebService.Models.CubaData;
using CodeWorksVoyWebService.Models.UserData;
using CodeWorksVoyWebService.Models.VoyagerReserve;
using CodeWorksVoyWebService.Models.WebData;
using CodeWorksVoyWebService.Services;
using CodeWorksVoyWebServiceTest.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWorksVoyWebServiceTest
{
    class ServiceFactory
    {
        IServiceCollection services;
        public ServiceFactory()
        {
           

            IConfiguration config = TestContainerConfig.InitConfiguration();

            Services = new ServiceCollection();
            Services.AddMemoryCache();
           
            var conCubaData = @"Server=DEVELOP\CODEWORKS;Database=CubaData;Trusted_Connection=True;ConnectRetryCount=0";
            Services.AddDbContext<CubaDataContext>(options => options.UseSqlServer(conCubaData));
            var conWebData = @"Server=DEVELOP\CODEWORKS;Database=WebData;Trusted_Connection=True;ConnectRetryCount=0";
            Services.AddDbContext<WebDataContext>(options => options.UseSqlServer(conWebData));
            var conVoyagerReserve = @"Server=DEVELOP\CODEWORKS;Database=VoyagerReserve;Trusted_Connection=True;ConnectRetryCount=0";
            Services.AddDbContext<VoyagerReserveContext>(options => options.UseSqlServer(conVoyagerReserve));
            var conUserData = @"Server=DEVELOP\CODEWORKS;Database=UserData;Trusted_Connection=True;ConnectRetryCount=0";
            Services.AddDbContext<UserDataContext>(options => options.UseSqlServer(conUserData));


            Services.AddTransient<ITransferAdapter, TransferAdapter>();
            Services.AddTransient<IPlaceAdapter, PlaceAdapter>();
            Services.AddTransient<IVoyResAdapter, VoyResAdapter>();
            Services.AddTransient<IPicturesAdapter, PicturesAdapter>();
            Services.AddTransient<IHotelAdapter, HotelAdapter>();
            Services.AddTransient<IFlightAdapter, FlightAdapter>();
            Services.AddTransient<ICardAdapter, CardAdapter>();
            Services.AddTransient<IItineraryService, ItineraryService>();
            Services.AddTransient<IPriceService, PriceService>();
            Services.AddTransient<IUserItinAdapter, UserItinAdapter>();
            Services.AddTransient<IMapService, MapService>();
            // services.AddSingleton<ISessionObject, SessionObject>();
            Services.AddSingleton<ISessionObjectsService, SessionObjectsService>();
            Services.AddSingleton<IConfiguration>(config);


        }

        public IServiceCollection Services { get => services; set => services = value; }
    }
}
