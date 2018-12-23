using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeWorksVoyWebService.Services
{
    internal interface IScopedProcessingService
    {
        void DoWork();
    }

    internal class ScopedProcessingService : IScopedProcessingService
    {
        private readonly ILogger _logger;
        private readonly ICacheServices _cacheServices;

        public ScopedProcessingService(ILogger<ScopedProcessingService> logger, ICacheServices cacheServices)
        {
            _logger = logger;
            _cacheServices = cacheServices;
        }

        public void DoWork()
        {
            _logger.LogInformation("Scoped Processing Service is working...");
            _cacheServices.initCards();
            _logger.LogInformation("Scoped Processing Service is done.");
        }
    }
}
