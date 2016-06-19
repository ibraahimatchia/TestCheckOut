using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StationeryWebAPI.Models
{
    //creating object model
    public class Stationery
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; }
    }
}