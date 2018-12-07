using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeWorksVoyWebService.Bussiness_Logic.DataObjects
{
    public class DatePriceObj
    {

        private DateTime date;
        private Decimal exactPrice;
        private String dateStr;

        public DatePriceObj()
        {
        }

        public DatePriceObj(decimal price, string dateStr)
        {
            this.exactPrice = price;
            this.dateStr = dateStr;
        }

        public DatePriceObj(String dateStr, decimal price, DateTime date)
        {
            this.dateStr = dateStr;
            this.exactPrice = price;
            this.date = date;
        }

        public DateTime Date { get => date; set => date = value; }
        public decimal ExactPrice { get => exactPrice; set => exactPrice = value; }
        public string DateStr { get => dateStr; set => dateStr = value; }
        public int Price { get => (int)exactPrice; }
    }
}
