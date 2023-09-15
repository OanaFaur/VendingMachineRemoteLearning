using iQuest.VendingMachine.PresentationLayer.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace VendingMachine.Tests.LookCommandTests
{
    [TestClass]
    public class ConstructorTests
    {
        [TestMethod]
        public void HavingANullUseCaseFactory_WhenInitializingTheCommand_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new LookCommand(null);
            });
        }
    }
}
