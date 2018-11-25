using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;

using System.Collections.Generic;
using System.Text;
using CodeWorksVoyWebService.Models.CubaData;
using CodeWorksVoyWebService.Models.VoyagerReserve;
using CodeWorksVoyWebService.Bussiness_Logic.DataObjects;
using CodeWorksVoyWebService.Bussiness_Logic.Bussiness_Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
/// <summary>
/// Summary description for VoyResAdapter
/// </summary>
public class VoyResAdapter : IVoyResAdapter

{

    private readonly List<CodeWorksVoyWebService.Models.VoyagerReserve.Countries> countriesTable;

    

    public VoyResAdapter(IMemoryCache cache, VoyagerReserveContext contextRes)
    {
        countriesTable = FactoryUtils.CheckCache<CodeWorksVoyWebService.Models.VoyagerReserve.Countries>(ref cache, contextRes, countriesTable, "CountriesTable");

       

    }

    public string GetCountryById(int countryId) {
        return  countriesTable.Where(c => c.CountryId == countryId).Select(s => s.CountryName).First();
    }
}
