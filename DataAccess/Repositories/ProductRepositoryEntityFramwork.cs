using DataAccess.Context;
using DataAccess.Exceptions;
using DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class ProductRepositoryEntityFramwork : IProductRepository
    {
        private readonly ProductContext context;

        public ProductRepositoryEntityFramwork(ProductContext context)
        {
            this.context = context;
        }

        public void DecrementStock(int id)
        {
            Product p = FindById(id);

            p.Quantity--;

            context.Update(p);
            context.SaveChanges();
        }

        public Product FindById(int id)
        {
            return context.Product.Where(p => p.ProductId == id).FirstOrDefault();
        }

        IList<Product> IProductRepository.GetAll()
        {
            return context.Product.ToList();
        }

        public void Create(Product p)
        {
            Product newProduct;

            if (p == null)
            {
                new NullProductException();
            }
            else
            {
                newProduct = new Product
                {
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity
                };

                context.Add(newProduct);
                context.SaveChanges();
            }
        }

        public void Delete(Product p)
        {
            if(p == null)
            {
                throw new InvalidProductIdException();
            }

            context.Product.Remove(p);
            context.SaveChanges();
        }

        public void Update(int id, Product updatedProduct)
        {
            Product originalProduct = FindById(id);

            if (originalProduct == null)
            {
                throw new InvalidProductIdException();
            }

            originalProduct.Name = updatedProduct.Name;
            originalProduct.Price = updatedProduct.Price;
            originalProduct.Quantity = updatedProduct.Quantity;

            context.Update(originalProduct);
            context.SaveChanges();
        }
    }
}
