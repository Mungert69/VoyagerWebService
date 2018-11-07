using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeWorkVoyWebService.Bussiness_Logic.DataObjects
{
    public class ItinObj
    {

        private CardObj card;
        private List<PRSelection> pRSelections;
        private List<TransferNode> transferNodes;
        private List<string> transferItems;

        public CardObj Card { get => card; set => card = value; }
        public List<PRSelection> PRSelections { get => pRSelections; set => pRSelections = value; }
        public List<TransferNode> TransferNodes { get => transferNodes; set => transferNodes = value; }
        public List<string> TransferItems { get => transferItems; set => transferItems = value; }
    }
}
