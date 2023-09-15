using DataAccess.Models;
using System;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class DeleteProductView : IDeleteProductView
    {
        public int GetProductId()
        {
            Console.WriteLine("Insert the id of the product that you want to delete");
            int productId = Convert.ToInt32(Console.ReadLine());

            return productId;
        }

        public void ShowDeletedProduct(Product product)
        {
            Console.WriteLine("{0} was deleted", product.Name);
        }
    }
}
