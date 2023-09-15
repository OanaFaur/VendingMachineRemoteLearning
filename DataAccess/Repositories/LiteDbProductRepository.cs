using DataAccess.Models;
using LiteDB;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("VendingMachine.Tests")]
[assembly: InternalsVisibleTo("iQuest.VendingMachine")]
namespace DataAccess
{
    internal class LiteDbProductRepository : IProductRepository
    {
        private readonly LiteDatabase context = new LiteDatabase(@"Filename=C:\Users\OANA\source\repos\oanafaur_rl1\Vending Machine\VendingMachine\myVendingProducts.db;connection=shared");

        public LiteDbProductRepository()
        {
            
        }

        public void Create(Product p)
        {
            //to be implemented
        }

        public void DecrementStock(int id)
        {
            var issues = context.GetCollection<Product>();

            Product product = FindById(id);

            product.Quantity--;

            issues.Update(id, product);
        }

        public void Delete(Product p)
        {
            //to be impleented
        }

        public Product FindById(int id)
        {
            return GetAll().FirstOrDefault(p => p.ProductId == id);
        }

        public IList<Product> GetAll()
        {
            var issues = context.GetCollection<Product>();
            var results = issues.FindAll().ToList();

            return results;
        }

        public void Update(int id, Product p)
        {
           //to be implemented
        }
    }
}
