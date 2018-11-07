using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;

using System.Collections.Generic;
using System.Text;
using CodeWorkVoyWebService.Models.CubaData;
using CodeWorkVoyWebService.Models.VoyagerReserve;
using CodeWorkVoyWebService.Bussiness_Logic.DataObjects;
using CodeWorkVoyWebService.Bussiness_Logic.Bussiness_Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
/// <summary>
/// Summary description for VoyResAdapter
/// </summary>
public class VoyResAdapter : IVoyResAdapter

{

    private readonly List<CodeWorkVoyWebService.Models.VoyagerReserve.Countries> countriesTable;

    

    public VoyResAdapter(IMemoryCache cache, VoyagerReserveContext contextRes)
    {
        countriesTable = FactoryUtils.CheckCache<CodeWorkVoyWebService.Models.VoyagerReserve.Countries>(ref cache, contextRes, countriesTable, "CountriesTable");

       

    }

    public string GetCountryById(int countryId) {
        return  countriesTable.Where(c => c.CountryId == countryId).Select(s => s.CountryName).First();
    }
}
