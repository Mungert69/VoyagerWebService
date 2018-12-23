using System.Collections.Generic;
using CodeWorksVoyWebService.Bussiness_Logic.DataObjects;

namespace CodeWorksVoyWebService.Services
{
    public interface ICacheServices
    {
        void initCards();
        List<TripCardObj> waitCardsReady();
    }
}