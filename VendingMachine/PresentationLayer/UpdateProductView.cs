using DataAccess.Models;
using System;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class UpdateProductView : IUpdateProductView
    {
        public int GetProductId()
        {
            Console.WriteLine("Insert the id of the product that you want to update");
            int productId = Convert.ToInt32(Console.ReadLine());

            return productId;
        }

        public void ShowUpdatedProduct(Product product)
        {
            Console.WriteLine("{0} was updated", product.Name);
        }
        public Product UpdateProduct()
        {
            var newProduct = new Product
            {
                Name = GetProductName(),
                Price = GetProductPrice(),
                Quantity = GetProductQuantity()
            };

            return newProduct;
        }
        private string GetProductName()
        {
            Console.WriteLine("Insert the product name");

            string name = Console.ReadLine();

            return name;
        }
        private double GetProductPrice()
        {
            bool isConvertible;

            double price;

            do
            {
                Console.WriteLine("Insert the product price");

                isConvertible = double.TryParse(Console.ReadLine(), out price);
            } while (!isConvertible);

            return price;
        }
        private int GetProductQuantity()
        {
            bool isConvertible;

            int quantity;

            do
            {
                Console.WriteLine("Insert the product quantity");

                isConvertible = Int32.TryParse(Console.ReadLine(), out quantity);

                if (!isConvertible)
                {
                    Console.WriteLine("Insert a valid quantity");
                    continue;
                }
            } while (!isConvertible);

            return quantity;
        }
    }
}
