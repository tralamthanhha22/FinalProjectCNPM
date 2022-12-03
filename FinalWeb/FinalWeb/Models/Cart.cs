using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalWeb.Models
{
    public class Cart
    {
        //private int price;
        //private string name;
        //private int quantity;
        //private int bill;
        public string ProID { get; set; }
        public string Proname { get; set; }
        public int Proprice { get; set; }
        public int qty { get; set; }
        public int bill { get; set; }
        public string ProImg { get; set; }
    }
}