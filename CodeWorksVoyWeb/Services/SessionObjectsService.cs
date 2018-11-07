using CodeWorkVoyWebService.Bussiness_Logic.Bussiness_Objects;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeWorksVoyWebService.Services
{

   
    public class SessionObjectsService : ISessionObjectsService
    {

        private IMemoryCache cache;
        private IConfiguration configuration;
        private int accessCounter=0;

        public SessionObjectsService(IMemoryCache cache, IConfiguration configuration)
        {
            this.cache = cache;
            this.configuration = configuration;
        }

        public ISessionObject getSessionObject(string userHashId) {
            SessionObject sessionObject = null;
            accessCounter++;
            sessionObject= FactoryUtils.CheckCache<SessionObject>(ref cache, sessionObject, "SessionObject" + userHashId);
            sessionObject.Configuration=configuration;
            return sessionObject;

        }

        public void setSessionObject(string userHashId, ISessionObject sessionObject) {
            FactoryUtils.WriteCache<ISessionObject>(ref cache, sessionObject, "SessionObject" + userHashId);
        }
    }
}
