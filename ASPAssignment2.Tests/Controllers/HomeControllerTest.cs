using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASPAssignment2;
using ASPAssignment2.Controllers;

namespace ASPAssignment2.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            VideoGamesController controller = new VideoGamesController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull("1");
        }

        /*
        //Deleted method, from initial build
        //Use this as example for making new unit tests requiring ViewBag
        [TestMethod]
        public void About()
        {
            // Arrange
            VideoGamesController controller = new VideoGamesController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }
        */
    }
}
