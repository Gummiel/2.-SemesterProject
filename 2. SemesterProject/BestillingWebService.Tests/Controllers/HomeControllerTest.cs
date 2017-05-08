#region References

using System.Web.Mvc;
using BestillingWebService.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace BestillingWebService.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}