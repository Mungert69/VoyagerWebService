using System;
using System.Collections.Generic;

namespace CodeWorkVoyWebService.Models.CubaData
{
    public partial class CurrencyExchange
    {
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public float? CurrencyExchangeRate { get; set; }
    }
}
