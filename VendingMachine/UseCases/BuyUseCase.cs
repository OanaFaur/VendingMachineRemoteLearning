using DataAccess.Models;
using DataAccess.Repositories;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.PurchaseLogic;
using System;
using System.Linq;

namespace iQuest.VendingMachine.UseCases
{
    internal class BuyUseCase : IUseCase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IBuyView buyView;

        private readonly IShelfView shelfView;

        private readonly IProductService productService;

        private readonly IConfirmationView confirmView;

        private readonly IPaymentUseCase paymentUseCase;

        private readonly IDispensedProductRepository dispensedProductRepo;

        public BuyUseCase(IBuyView buyView, IShelfView shelfView, IProductService productService, IConfirmationView confirmView, IPaymentUseCase paymentUseCase, IDispensedProductRepository dispensedProductRepo)
        {
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            this.shelfView = shelfView ?? throw new ArgumentNullException(nameof(shelfView));
            this.productService = productService ?? throw new ArgumentNullException(nameof(productService));
            this.confirmView = confirmView ?? throw new ArgumentNullException(nameof(confirmView));
            this.paymentUseCase = paymentUseCase ?? throw new ArgumentNullException(nameof(paymentUseCase));
            this.dispensedProductRepo = dispensedProductRepo ?? throw new ArgumentException(nameof(dispensedProductRepo));

        }
        public void Execute()
        {

            if (!CheckListIsNull())
            {
                int userChoice = GetProductId();

                Product product = productService.GetProductById(userChoice);
                productService.GetTotalValidation(userChoice);
                confirmView.IsSelectionConfirmed();
                paymentUseCase.Execute(product.Price);
                AddToHistory( product);
                productService.StockDecrementation(userChoice);
                buyView.DispenseProduct(product.Name);
                log.Info("The user bought a " + product.Name);
            }
        }

        private int GetProductId()
        {
            bool isConvertible;

            int userChoice;
            do
            {

                isConvertible = Int32.TryParse(buyView.RequestId(), out userChoice);
                if (!isConvertible)
                {
                    continue;
                }
            } while (!isConvertible);

            return userChoice;
        }

        private bool CheckListIsNull()
        {
            bool isListNull;

            if (!productService.GetProductList().Any())
            {
                isListNull = true;
                shelfView.ListIsNull("There are no products in stock");

            }
            else isListNull = false;

            return isListNull;
        }
        private void AddToHistory(Product product)
        {
           
            DispensedProduct dispensed = new DispensedProduct
            {
                Date = DateTime.Now,
                Name = product.Name,
                Price = product.Price,
                PaymentMethod = paymentUseCase.PaymentMethodChoice.Name
            };

            dispensedProductRepo.AddDispensedProduct(dispensed);
        }
    }
}
