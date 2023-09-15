using DataAccess;
using DataAccess.Models;
using iQuest.VendingMachine.PurchaseLogic.ProductValidationExceptions;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("VendingMachine.Tests")]
namespace iQuest.VendingMachine.PurchaseLogic
{
    internal class ProductService : IProductService
    {
        private readonly IProductRepository productRepo;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ProductService(IProductRepository productRepo)
        {
            this.productRepo = productRepo;
        }

        public Product GetProductById(int id)
        {
            return productRepo.FindById(id);
        }

        public IEnumerable<Product> GetProductList()
        {
            return productRepo.GetAll();
        }

        public void GetTotalValidation(int id)
        {
            IsProductValid(id);
            CheckProductQuantity(id);
        }

        public void StockDecrementation(int id)
        {
            productRepo.DecrementStock(id);
        }

        private void CheckProductQuantity(int id)
        {
            Product product = productRepo.FindById(id);

            if (product.Quantity == 0)
            {
                log.Info("The product with the id of "+id +" is put of stock");
                throw new InsufficientStockException();
            }
        }

        private void IsProductValid(int id)
        {

            Product product = productRepo.FindById(id);
            if (product == null)
            {
                log.Info("The product with the id of " + id + " does not exist");
                throw new InvalidProductIdException();
            }

        }
    }
}
