using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.PresentationLayer.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace VendingMachine.Tests.BuyCommandTests
{
    [TestClass]
    public class CanExecuteTests
    {
        private Mock<IAuthenticationService> authenticationService;
        private Mock<ILoginView> loginView;
        private Mock<IUseCaseFactory> useCaseFactory;

        [TestInitialize]

        public void TestInitialize()
        {
            loginView = new Mock<ILoginView>();

            authenticationService = new Mock<IAuthenticationService>();

            useCaseFactory = new Mock<IUseCaseFactory>();
        }

        [TestMethod]
        public void HavingNoAdminLoggedIn_ReturnsTrue()
        {
            authenticationService.Setup(x => x.IsUserAuthenticated).Returns(false);
            LoginCommand loginUseCase = new LoginCommand(useCaseFactory.Object, authenticationService.Object);

            Assert.IsTrue(loginUseCase.CanExecute);
        }

        [TestMethod]
        public void HavingAdminLoggedIn_ReturnsFalse()
        {
            authenticationService.Setup(x => x.IsUserAuthenticated).Returns(true);

            LoginCommand loginUseCase = new LoginCommand(useCaseFactory.Object, authenticationService.Object);

            Assert.IsFalse(loginUseCase.CanExecute);
        }
    }
}
