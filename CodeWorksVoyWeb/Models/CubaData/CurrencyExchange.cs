using System;
using System.Collections.Generic;

namespace CodeWorksVoyWebService.Models.CubaData
{
    public partial class CurrencyExchange
    {
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public float? CurrencyExchangeRate { get; set; }
    }
}
