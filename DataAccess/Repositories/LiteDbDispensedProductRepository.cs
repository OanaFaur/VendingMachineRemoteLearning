using DataAccess.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("VendingMachine.Tests")]
[assembly: InternalsVisibleTo("iQuest.VendingMachine")]
namespace DataAccess.Repositories
{
    internal class LiteDbDispensedProductRepo : IDispensedProductRepository
    {

        private LiteDatabase db;

        public LiteDbDispensedProductRepo()
        {
            db = new LiteDatabase(@"Filename=C:\Users\OANA\source\repos\oanafaur_rl1\Vending Machine\VendingMachine\myVendingProducts.db;connection=shared");
        }

        public void AddDispensedProduct(DispensedProduct dispensedProduct)
        {

            var collection = db.GetCollection<DispensedProduct>();

            var newSoldProduct = new DispensedProduct
            {
                Date = dispensedProduct.Date,
                Name = dispensedProduct.Name,
                Price = dispensedProduct.Price,
                PaymentMethod = dispensedProduct.PaymentMethod
            };
            collection.Insert(newSoldProduct);
        }

        public IList<DispensedProduct> GetAll()
        {
            var collection = db.GetCollection<DispensedProduct>();
            var results = collection.FindAll().ToList();

            return results;
        }

        public IEnumerable<DispensedProduct> GetProductsByDates(DateTime startDate, DateTime endDate)
        {
            return GetAll()
                .Where(x => x.Date >= startDate && x.Date <= endDate);
        }
    }
}
