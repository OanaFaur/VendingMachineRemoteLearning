using DataAccess;
using DataAccess.Models;
using iQuest.VendingMachine.PresentationLayer;

namespace iQuest.VendingMachine.UseCases
{
    internal class DeleteProductUseCase : IUseCase
    {
        private readonly IDeleteProductView productView;

        private readonly IProductRepository productRepo;

        public DeleteProductUseCase(IProductRepository productRepo, IDeleteProductView productView)
        {
            this.productRepo = productRepo;
            this.productView = productView;
        }
        public void Execute()
        {
            int userChoice = productView.GetProductId();

            Product product = productRepo.FindById(userChoice);

            productRepo.Delete(product);

            productView.ShowDeletedProduct(product);
        }
    }
}
