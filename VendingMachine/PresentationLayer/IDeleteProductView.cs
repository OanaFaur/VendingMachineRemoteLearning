using DataAccess.Models;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal interface IDeleteProductView
    {
        int GetProductId();
        void ShowDeletedProduct(Product product);
    }
}