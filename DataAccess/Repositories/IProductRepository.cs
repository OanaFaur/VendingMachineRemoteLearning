using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess
{
    public interface IProductRepository
    {
        void DecrementStock(int id);
        Product FindById(int id);
        IList<Product> GetAll();
        void Create(Product p);

        void Delete(Product p);

        void Update(int id, Product p);
    }
}
