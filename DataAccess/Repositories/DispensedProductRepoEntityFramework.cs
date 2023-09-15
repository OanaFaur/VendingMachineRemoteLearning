using DataAccess.Context;
using DataAccess.Exceptions;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class DispensedProductRepoEntityFramework: IDispensedProductRepository
    {
        private readonly ProductContext context = new ProductContext();

        public DispensedProductRepoEntityFramework(ProductContext context)
        {
            this.context = context;
        }
        public void AddDispensedProduct(DispensedProduct dispensedProduct)
        {
            if (dispensedProduct == null)
            {
                throw new NullProductException();
            }
            else
            {
                var newSoldProduct = new DispensedProduct
                {
                    Date = dispensedProduct.Date,
                    Name = dispensedProduct.Name,
                    Price = dispensedProduct.Price,
                    PaymentMethod = dispensedProduct.PaymentMethod
                };

                context.Add(newSoldProduct);
                context.SaveChanges();
            }
        }
        public IList<DispensedProduct> GetAll()
        {
            return context.DispensedProduct.ToList();
        }

        public IEnumerable<DispensedProduct> GetProductsByDates(DateTime startDate, DateTime endDate)
        {
            return GetAll()
                .Where(x => x.Date >= startDate && x.Date <= endDate);
        }
    }
}
