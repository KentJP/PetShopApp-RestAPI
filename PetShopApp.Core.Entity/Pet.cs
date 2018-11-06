using System;
using System.Collections.Generic;

namespace PetShopApp.Core.Entity
{
    public class Pet
    {

        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public DateTime birthdate { get; set; }
        public DateTime soldDate { get; set; }
        public string color { get; set; }
        public Owner previousOwner { get; set; }
        public double price { get; set; }


    }
}
