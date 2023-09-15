using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("VendingMachine.Tests")]
namespace iQuest.VendingMachine.PresentationLayer
{
    internal class ShelfView : IShelfView
    {
        public void DisplayProducts(IEnumerable<Product> products)
        {
            foreach (Product p in products)
            {
                Console.WriteLine("{0} {1} {2} leis [{3} left]", p.ProductId, p.Name, p.Price, p.Quantity);
            }
        }
        public string ListIsNull(string message)
        {
            return message;
        }
    }
}
