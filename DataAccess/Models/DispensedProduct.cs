using System;

namespace DataAccess.Models
{
    public class DispensedProduct
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string PaymentMethod { get; set; }

        public DispensedProduct(DateTime date, string name, double price,  string paymentmethod)
        {
            Date = date;
            Name = name;
            Price = price;
            PaymentMethod = paymentmethod;
        }

        public DispensedProduct()
        {

        }
    }
}
