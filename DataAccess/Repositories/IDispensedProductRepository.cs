using DataAccess.Models;
using System;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public interface IDispensedProductRepository
    {
        void AddDispensedProduct(DispensedProduct dispensedProduct);
        IList<DispensedProduct> GetAll();
        IEnumerable<DispensedProduct> GetProductsByDates(DateTime startDate, DateTime endDate);
    }
}