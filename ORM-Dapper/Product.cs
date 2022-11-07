using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//--------------------------------------
// David Zientara
// 11-7-2022
//
// Product.cs
// Contains the variables for the
// Product class
// ProductID, Name, Price, CategoryID,
// OnSale + StockLevel
//
//--------------------------------------

namespace ORM_Dapper
{
    internal class Product
    {
        // For example:
        public int ProductID { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
        public bool OnSale { get; set; }
        public int StockLevel { get; set; }
    }
}
