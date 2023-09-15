using DataAccess;
using DataAccess.Models;
using iQuest.VendingMachine.PresentationLayer;

namespace iQuest.VendingMachine.UseCases
{
    internal class UpdateProductUseCase : IUseCase
    {
        private readonly IProductRepository productRepo;

        private readonly IUpdateProductView productView;

        public UpdateProductUseCase(IProductRepository productRepo, IUpdateProductView productView)
        {
            this.productRepo = productRepo;
            this.productView = productView;
        }
        public void Execute()
        {
            int userChoice = productView.GetProductId();

            Product product = productRepo.FindById(userChoice);

            productRepo.Update(userChoice, productView.UpdateProduct());

            productView.ShowUpdatedProduct(product);
        }
    }
}
