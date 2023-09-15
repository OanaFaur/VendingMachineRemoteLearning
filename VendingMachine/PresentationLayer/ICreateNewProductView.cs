using DataAccess.Models;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal interface ICreateNewProductView
    {
        Product Add();
        void ShowAddedProduct(Product product);
    }
}