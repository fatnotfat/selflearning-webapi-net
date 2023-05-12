using System;

namespace MyWebApiApp.Data
{
    public class OrderDetail
    {
        public Guid ProductID { get; set; }
        public Guid OrderID { get; set; }
        public int Quantity { get; set; }
        public double ProductPrice { get; set; }
        public byte Discount { get; set; }




        //Relationship
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
