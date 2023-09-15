using DataAccess;
using DataAccess.Models;
using iQuest.VendingMachine.PresentationLayer;

namespace iQuest.VendingMachine.UseCases
{
    internal class CreateNewProductUseCase : IUseCase
    {
        private readonly IProductRepository productRepo;

        private readonly ICreateNewProductView productView;
        public CreateNewProductUseCase(IProductRepository productRepo, ICreateNewProductView productView)
        {
            this.productRepo = productRepo;
            this.productView = productView;
        }
        public void Execute()
        {
            Product product = productView.Add();

            productRepo.Create(product);

            productView.ShowAddedProduct(product);
        }
    }
}
