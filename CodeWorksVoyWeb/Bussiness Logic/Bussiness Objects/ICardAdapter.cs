using System.Collections.Generic;
using CodeWorkVoyWebService.Models.WebData;

namespace CodeWorkVoyWebService.Bussiness_Logic.Bussiness_Objects
{
    public interface ICardAdapter
    {
        Card GetCardData(int templateTypeId, int detailLevel);
        List<Card> GetStyleCards(int templateTypeId);
        List<PRSelection> updateSelectionWithCards(List<PRSelection> pRSelections);
    }
}