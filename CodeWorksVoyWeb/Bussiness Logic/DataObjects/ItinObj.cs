﻿using CodeWorksVoyWebService.Bussiness_Logic.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeWorksVoyWebService.Bussiness_Logic.DataObjects
{
    public class ItinObj
    {

        private TripCardObj card;
        private List<PRSelection> pRSelections;
        private List<TransferNodeItem> transferNodeItems;

        public TripCardObj Card { get => card; set => card = value; }
        public List<PRSelection> PRSelections { get => pRSelections; set => pRSelections = value; }
        public List<TransferNodeItem> TransferNodeItems { get => transferNodeItems; set => transferNodeItems = value; }
    }
}
