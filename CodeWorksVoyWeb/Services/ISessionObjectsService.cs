using System;

namespace CodeWorksVoyWebService.Services
{
    public interface ISessionObjectsService
    {
        ISessionObject getSessionObject(Guid userHashId);
        void setSessionObject(Guid userHashId, ISessionObject sessionObject);
    }
}