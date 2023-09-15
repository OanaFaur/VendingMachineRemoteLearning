using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.PurchaseLogic;
using iQuest.VendingMachine.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace VendingMachine.Tests.LookUseCaseTests
{
    [TestClass]
    public class ConstructorTests
    {
        private Mock<IShelfView> shelfView;
        private Mock<IProductService> productService;


        [TestInitialize]
        public void TestInitialize()
        {
            shelfView = new Mock<IShelfView>();
            productService = new Mock<IProductService>();
        }

        [TestMethod]
        public void HavingANullShelfView_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new LookUseCase(null, productService.Object);
            });
        }
        [TestMethod]
        public void HavingANullProductService_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new LookUseCase(shelfView.Object, null);
            });
        }

    }


}
