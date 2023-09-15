using DataAccess.Models;
using System.Collections.Generic;

namespace iQuest.VendingMachine.PurchaseLogic
{
    public interface IProductService
    {
        Product GetProductById(int id);
        IEnumerable<Product> GetProductList();
        void GetTotalValidation(int id);
        void StockDecrementation(int id);
    }
}