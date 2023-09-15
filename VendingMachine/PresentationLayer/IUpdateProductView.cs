using DataAccess.Models;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal interface IUpdateProductView
    {
        int GetProductId();
        Product UpdateProduct();
        void ShowUpdatedProduct(Product product);
    }
}