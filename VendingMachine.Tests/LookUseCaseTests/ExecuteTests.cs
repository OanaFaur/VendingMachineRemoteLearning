using DataAccess.Models;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.PurchaseLogic;
using iQuest.VendingMachine.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace VendingMachine.Tests.LookUseCaseTests
{

    [TestClass]
    public class ExecuteTests
    {
        private Mock<IShelfView> shelfView;
        private LookUseCase lookUseCase;

        private Mock<IProductService> service;

        [TestInitialize]

        public void TestInitialize()
        {
            shelfView = new Mock<IShelfView>();
            service = new Mock<IProductService>();
            lookUseCase = new LookUseCase(shelfView.Object, service.Object);
        }

        [TestMethod]

        public void HavingALookUseCaseInstance_IfListIsNull_ThenDisplayMessage()
        {
            //arrange
            service.Setup(x => x.GetProductList()).Returns(new List<Product>());

            //act
            lookUseCase.Execute();

            //assert
            shelfView.Verify(x => x.ListIsNull(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void HavingALookUseCaseInstance_IfListIsNotNull_ThenList()
        {
            //arrange
            List<Product> products = new List<Product>()
            {
                new Product(1, "Coca Cola", 3.5, 10),
                new Product(2, "Fanta", 3.5, 10),
                new Product(3, "Sprite", 3.5, 12),
                new Product(4, "Mentos", 2.5, 15)
            };

            service.Setup(x => x.GetProductList()).Returns(products);
            //act
            lookUseCase.Execute();
            //assert
            shelfView.Verify(x => x.DisplayProducts(products), Times.Once);

        }
    }
}
