using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeWorksVoyWebService.Bussiness_Logic.DataObjects
{
    public class DatePriceObj
    {

        private DateTime date;
        private Decimal price;
        private String dateStr;

        public DatePriceObj(decimal price, string dateStr)
        {
            this.price = price;
            this.dateStr = dateStr;
        }

        public DatePriceObj(String dateStr, decimal price, DateTime date)
        {
            this.dateStr = dateStr;
            this.price = price;
            this.date = date;
        }

        public DateTime Date { get => date; set => date = value; }
        public decimal Price { get => price; set => price = value; }
        public string DateStr { get => dateStr; set => dateStr = value; }
    }
}
