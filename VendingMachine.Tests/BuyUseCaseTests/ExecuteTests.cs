using DataAccess.Models;
using DataAccess.Repositories;
using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.PurchaseLogic;
using iQuest.VendingMachine.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace VendingMachine.Tests.BuyUseCaseTests
{
    [TestClass]
    public class ExecuteTests
    {
        private Mock<IBuyView> buyView;
        private Mock<IShelfView> shelfView;
        private Mock<IConfirmationView> confirmationView;
        private BuyUseCase buyUseCase;
        private Mock<IProductService> productService;
        private Mock<IPaymentUseCase> paymentUseCase;
        private Mock<IDispensedProductRepository> dispensedProductRepo;

        [TestInitialize]

        public void TestInitialize()
        {
            shelfView = new Mock<IShelfView>();
            confirmationView = new Mock<IConfirmationView>();
            buyView = new Mock<IBuyView>();
            productService = new Mock<IProductService>();
            paymentUseCase = new Mock<IPaymentUseCase>();
            dispensedProductRepo = new Mock<IDispensedProductRepository>();
            buyUseCase = new BuyUseCase(buyView.Object, shelfView.Object, productService.Object, confirmationView.Object, paymentUseCase.Object, dispensedProductRepo.Object);
        }

        [TestMethod]

        public void HavingABuyUseCaseInstance_WhenExecuted_ThenUserIsAskedToInsertId()
        {
            //arrange
            productService.Setup(x => x.GetProductList()).Returns(products);
            buyView.Setup(x => x.RequestId()).Returns("1");
            productService.Setup(x => x.GetProductById(1)).Returns(products[0]);
            //act
            buyUseCase.Execute();
            //assert
            buyView.Verify(x => x.RequestId(), Times.Once);
        }
        [TestMethod]
        public void HavingABuyusecase_WhenExecuted_ThenGetUserConfirmation()
        {
            //arrange
            productService.Setup(x => x.GetProductList()).Returns(products);
            buyView.Setup(x => x.RequestId()).Returns("1");
            productService.Setup(x => x.GetProductById(1)).Returns(products[0]);
            confirmationView.Setup(x => x.IsSelectionConfirmed());
            confirmationView.Setup(x => x.UserConfirmation()).Returns("y");
            //act
            buyUseCase.Execute();
            //assert
            confirmationView.Verify(x => x.IsSelectionConfirmed(), Times.AtLeastOnce);
        }

        [TestMethod]

        public void HavingABuyUseCaseInstance_WhenExecuted_ThenGetTotalValidation()
        {
            //arrange
            productService.Setup(x => x.GetProductList()).Returns(products);
            buyView.Setup(x => x.RequestId()).Returns("1");
            productService.Setup(x => x.GetProductById(1)).Returns(products[0]);
            paymentUseCase.Setup(x => x.Execute(3.5));
            //act
            buyUseCase.Execute();
            //assert
            productService.Verify(x => x.GetTotalValidation(1), Times.AtLeastOnce);

        }
        [TestMethod]
        public void HavingABuyUseCaseInstance_WhenExecuted_ThenDecrementProduct()
        {
            //arrange
            productService.Setup(x => x.GetProductList()).Returns(products);
            buyView.Setup(x => x.RequestId()).Returns("1");
            productService.Setup(x => x.GetProductById(1)).Returns(products[0]);
            //act
            buyUseCase.Execute();
            //assert
            productService.Verify(x => x.StockDecrementation(1), Times.AtLeastOnce);

        }

        [TestMethod]
        public void HavingABuyUseCaseInstance_WhenExecuted_ThenDispenseProduct()
        {
            //arrange
            productService.Setup(x => x.GetProductList()).Returns(products);
            buyView.Setup(x => x.RequestId()).Returns("1");
            productService.Setup(x => x.GetProductById(1)).Returns(products[0]);
            //act
            buyUseCase.Execute();
            //assert
            buyView.Verify(x => x.DispenseProduct("Coca Cola"), Times.AtLeastOnce);
        }

        private readonly List<Product> products = new List<Product>()
        {
            new Product(1, "Coca Cola", 3.5, 10),
            new Product(2, "Fanta", 3.5, 10),
            new Product(3, "Sprite", 3.5, 12),
            new Product(4, "Mentos", 2.5, 15),
            new Product(5, "Orbit", 1.5, 0),
            new Product(6, "Cheetos", 3, 10)
        };
    }
}
