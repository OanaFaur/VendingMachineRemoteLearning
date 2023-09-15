using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.PurchaseLogic;
using System;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("VendingMachine.Tests")]
namespace iQuest.VendingMachine.UseCases
{
    internal class LookUseCase : IUseCase
    {
        
        private readonly IShelfView shelfView;

        private readonly IProductService productService;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public LookUseCase(IShelfView shelfView, IProductService productService)
        {
            this.shelfView=shelfView ?? throw new ArgumentNullException(nameof(shelfView)); 
            this.productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }
       
        public void Execute()
        {
            string message = "The user viewed the products";

            if (!CheckListIsNull())
            {
                shelfView.DisplayProducts(productService.GetProductList());
            }

            log.Info(message);
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
    }
}
