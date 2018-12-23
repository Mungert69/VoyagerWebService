using System.Collections.Generic;
using CodeWorksVoyWebService.Models.WebData;

public interface ICardAdapter
{
    Card GetCardData(int templateTypeId, int detailLevel);
    List<Card> GetStyleCards(int templateTypeId);
    List<PRSelection> updateSelectionWithCards(List<PRSelection> pRSelections);
}