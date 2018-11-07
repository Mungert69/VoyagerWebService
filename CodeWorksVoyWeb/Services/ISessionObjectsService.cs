namespace CodeWorksVoyWebService.Services
{
    public interface ISessionObjectsService
    {
        ISessionObject getSessionObject(string userHashId);
        void setSessionObject(string userHashId, ISessionObject sessionObject);
    }
}