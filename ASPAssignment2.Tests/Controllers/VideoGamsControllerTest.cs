﻿using System;
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
    public class VideoGamsControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            VideoGamesController controller = new VideoGamesController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual(result.ViewName,"");
        }

        [TestMethod]
        public void VideoGames()
        {
            // Arrange
            VideoGamesController controller = new VideoGamesController();

            // Act
            ViewResult result = controller.VideoGames() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
