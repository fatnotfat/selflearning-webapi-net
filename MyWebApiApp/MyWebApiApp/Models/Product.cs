using System;

namespace MyWebApiApp.Models
{
    public class ProductVM
    {
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
    }

    public class Product : ProductVM
    {
        public Guid ProductID { get; set; }
    }
}
