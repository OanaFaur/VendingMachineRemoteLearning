using DataAccess.Models;
using System.Collections.Generic;

namespace iQuest.VendingMachine.PresentationLayer
{
    public interface IShelfView
    {
        void DisplayProducts(IEnumerable<Product> products);
        string ListIsNull(string message);
    }
}