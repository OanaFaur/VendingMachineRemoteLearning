using DataAccess.Repositories;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.PurchaseLogic;
using iQuest.VendingMachine.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace VendingMachine.Tests.BuyUseCaseTests
{
    [TestClass]
    public class ConstructorTests
    {
        private Mock<IBuyView> buyView;
        private Mock<IShelfView> shelfView;
        private Mock<IConfirmationView> confirmationView;
        private Mock<IProductService> productService;
        private Mock<IDispensedProductRepository> dispensedProductRepo;
        private Mock<IPaymentUseCase> paymentUseCase;


        [TestInitialize]
        public void TestInitialize()
        {
            shelfView = new Mock<IShelfView>();
            buyView = new Mock<IBuyView>();
            confirmationView = new Mock<IConfirmationView>();
            dispensedProductRepo = new Mock<IDispensedProductRepository>();
            productService = new Mock<IProductService>();
            paymentUseCase = new Mock<IPaymentUseCase>();
        }

        [TestMethod]
        public void HavingANullShelfView_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new BuyUseCase( buyView.Object, null,  productService.Object, confirmationView.Object, paymentUseCase.Object, dispensedProductRepo.Object);
            });
        }

        [TestMethod]
        public void HavingANullBuyView_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new BuyUseCase( null, shelfView.Object, productService.Object, confirmationView.Object, paymentUseCase.Object, dispensedProductRepo.Object);
            });
        }
        [TestMethod]
        public void HavingANullConfirmationView_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new BuyUseCase(buyView.Object, shelfView.Object, productService.Object, null, paymentUseCase.Object, dispensedProductRepo.Object);
            });
        }


        [TestMethod]
        public void HavingANullProductService_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new BuyUseCase(buyView.Object, shelfView.Object, null, confirmationView.Object, paymentUseCase.Object, dispensedProductRepo.Object);
            });
        }
    }
}
