using DataAccess.Models;
using System;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class CreateNewProductView : ICreateNewProductView
    {
        public Product Add()
        {
            var newProduct = new Product
            {
                Name = GetProductName(),
                Price = GetProductPrice(),
                Quantity = GetProductQuantity()
            };

            return newProduct;
        }

        public void ShowAddedProduct(Product product)
        {
            Console.WriteLine("{0} was added", product.Name);
        }
        private string GetProductName()
        {
            string name;

            do
            {
                Console.WriteLine("Insert the product name");
                name = Console.ReadLine();

            } while (name == null);

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
