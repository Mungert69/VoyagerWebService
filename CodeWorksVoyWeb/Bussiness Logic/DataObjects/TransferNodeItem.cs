using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeWorksVoyWebService.Bussiness_Logic.DataObjects
{
    public class TransferNodeItem : TransferNode
    {
        private TransferObj transferItem;

        public TransferObj TransferItem { get => transferItem; set => transferItem = value; }
    }
}
