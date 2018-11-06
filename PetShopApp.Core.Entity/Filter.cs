using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.Entity
{
    public class Filter
    {
        public int CurrentPage { get; set; }
        public int ItemsPrPage { get; set; }
        public string SearchProp { get; set; }
        public string SearchValue { get; set; }
    }
}
    