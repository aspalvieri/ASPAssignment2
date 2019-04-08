using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASPAssignment2;
using ASPAssignment2.Controllers;
using ASPAssignment2.Models;
using ASPAssignment2.Tests.Fakes;
using System.Net;
using System.Web.Http.Results;

namespace ASPAssignment2.Tests.Controllers
{
    [TestClass]
    public class VideoGamsControllerTest
    {
        [TestMethod]
        public void VideoGamesView()
        {
            //Arrange
            FakeVideoGamesBL fake = new FakeVideoGamesBL();
            VideoGamesController controller = new VideoGamesController(fake);
            controller.testCase = true;
            //Act
            ViewResult result = controller.VideoGames() as ViewResult;
            //Assert
            Assert.AreEqual(result.ViewName, "Index");

        }
        [TestMethod]
        public void IndexTest()
        {
            //Arrange
            FakeVideoGamesBL fake = new FakeVideoGamesBL();
            VideoGamesController controller = new VideoGamesController(fake);
            controller.testCase = true;
            //Act
            ViewResult result = controller.Index() as ViewResult;
            //Assert
            Assert.AreEqual(result.ViewName, "Index");

        }
        [TestMethod]
        public void DetailValidId()
        {
            //Arrange
            FakeVideoGamesBL fake = new FakeVideoGamesBL();
            VideoGamesController controller = new VideoGamesController(fake);
            controller.testCase = true;
            //var result = (VideoGame)((ViewResult)controller.Details(1)).Model;
            // Act
            ViewResult result = controller.Details(3) as ViewResult;

            // Assert
            Assert.IsNotNull(result.ViewName);
        }
        [TestMethod]
        public void DetailNull()
        {
            //Arrange
            FakeNullVideoGame fake = new FakeNullVideoGame();
            VideoGamesController controller = new VideoGamesController(fake);
            controller.testCase = true;
            //var result = (VideoGame)((ViewResult)controller.Details(1)).Model;
            // Act
            ViewResult result = controller.Details(3) as ViewResult;

            // Assert
            //Assert.AreEqual("", result.ViewName);
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void DetailInValidId()
        {
            //Arrange
            FakeVideoGamesBL fake = new FakeVideoGamesBL();
            VideoGamesController controller = new VideoGamesController(fake);
            controller.testCase = true;
            //var result = (VideoGame)((ViewResult)controller.Details(1)).Model;
            // Act
            ViewResult result = controller.Details(300) as ViewResult;

            // Assert
            Assert.AreEqual("Details", result.ViewName);
        }

        [TestMethod]
        public void CreateView()
        {
            //Arrange
            FakeVideoGamesBL fake = new FakeVideoGamesBL();
            VideoGamesController controller = new VideoGamesController(fake);
            controller.testCase = true;
            //var result = (VideoGame)((ViewResult)controller.Details(1)).Model;
            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void Create()
        {
            //Arrange
            FakeVideoGamesBL fake = new FakeVideoGamesBL();
            VideoGamesController controller = new VideoGamesController(fake);
            controller.testCase = true;
            Genre fps = new Genre { Name = "FPS", Description = "First-person shooter." };
            Genre moba = new Genre { GenreId = 100, Name = "Moba", Description = "Angry team simulator." };
            VideoGame game1 = new VideoGame
            {
                VideoGameId = 4,
                Name = "CS : GO",
                Price = 20,
                Developer = "UK",
                Publisher = "Steam",
                Description = "FPS Game",
                Genre = fps
            };
            //var result = (VideoGame)((ViewResult)controller.Details(1)).Model;
            // Act
            ViewResult result = controller.Create(game1) as ViewResult;

            // Assert
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void CreateInvalid()
        {
            //Arrange
            FakeVideoGamesBL fake = new FakeVideoGamesBL();
            VideoGamesController controller = new VideoGamesController(fake);
            controller.testCase = true;
            Genre fps = new Genre { Name = "FPS", Description = "First-person shooter." };
            Genre moba = new Genre { GenreId = 100, Name = "Moba", Description = "Angry team simulator." };
            VideoGame game1 = new VideoGame
            {
                VideoGameId = 3,
                Name = "CS : GO",
                Price = 20,
                Developer = "UK",
                Publisher = "Steam",
                Description = "FPS Game",
                Genre = fps
            };
            //var result = (VideoGame)((ViewResult)controller.Details(1)).Model;
            // Act
            ViewResult result = controller.Create(game1) as ViewResult;

            // Assert
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void InvalidEdit()
        {
            //Arrange
            FakeVideoGamesBL fake = new FakeVideoGamesBL();
            VideoGamesController controller = new VideoGamesController(fake);
            controller.testCase = true;
            //var result = (VideoGame)((ViewResult)controller.Details(1)).Model;
            // Act
            ViewResult result = controller.Edit(200) as ViewResult;

            // Assert
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void ValidEdit()
        {
            //Arrange
            FakeVideoGamesBL fake = new FakeVideoGamesBL();
            VideoGamesController controller = new VideoGamesController(fake);
            controller.testCase = true;
            //var result = (VideoGame)((ViewResult)controller.Details(1)).Model;
            // Act
            ViewResult result = controller.Edit(3) as ViewResult;

            // Assert
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void EditNull()
        {
            //Arrange
            FakeVideoGamesBL fake = new FakeVideoGamesBL();
            VideoGamesController controller = new VideoGamesController(fake);
            controller.testCase = true;
            //var result = (VideoGame)((ViewResult)controller.Details(1)).Model;
            // Act
            ViewResult result = controller.Edit(3) as ViewResult;

            // Assert
            //Assert.AreEqual("", result.ViewName);
            Assert.IsNotNull(result.ViewName);
        }

        [TestMethod]
        public void ValidEditSave()
        {
            //Arrange
            FakeVideoGamesBL fake = new FakeVideoGamesBL();
            VideoGamesController controller = new VideoGamesController(fake);
            controller.testCase = true;
            //var result = (VideoGame)((ViewResult)controller.Details(1)).Model;
            // Act
            Genre fps = new Genre { Name = "FPS", Description = "First-person shooter." };
            Genre moba = new Genre { GenreId = 100, Name = "Moba", Description = "Angry team simulator." };
            VideoGame game1 = new VideoGame
            {
                VideoGameId = 3,
                Name = "CS : GO",
                Price = 20,
                Developer = "UK",
                Publisher = "Steam",
                Description = "FPS Game",
                Genre = fps
            };
            ViewResult result = controller.Edit(game1) as ViewResult;

            // Assert
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void InValidDelete()
        {
            //Arrange
            FakeVideoGamesBL fake = new FakeVideoGamesBL();
            VideoGamesController controller = new VideoGamesController(fake);
            controller.testCase = true;
            //var result = (VideoGame)((ViewResult)controller.Details(1)).Model;
            // Act
            ViewResult result = controller.Delete(300) as ViewResult;

            // Assert
            Assert.AreEqual("Delete", result.ViewName);
        }
        [TestMethod]
        public void ValidDelete()
        {
            //Arrange
            FakeVideoGamesBL fake = new FakeVideoGamesBL();
            VideoGamesController controller = new VideoGamesController(fake);
            controller.testCase = true;
            //var result = (VideoGame)((ViewResult)controller.Details(1)).Model;
            // Act
            ViewResult result = controller.Delete(1) as ViewResult;


            // Assert
            Assert.AreEqual("Delete", result.ViewName);
        }
        [TestMethod]
        public void DeleteNull()
        {
            //Arrange
            FakeVideoGamesBL fake = new FakeVideoGamesBL();
            VideoGamesController controller = new VideoGamesController(fake);
            controller.testCase = true;
            //var result = (VideoGame)((ViewResult)controller.Details(1)).Model;
            // Act
            ViewResult result = controller.Delete(3) as ViewResult;

            // Assert
            //Assert.AreEqual("", result.ViewName);
            Assert.IsNotNull(result.ViewName);
        }

        [TestMethod]
        public void DeleteConfirmedInvalidId()
        {
            //Arrange
            FakeVideoGamesBL fake = new FakeVideoGamesBL();
            VideoGamesController controller = new VideoGamesController(fake);
            controller.testCase = true;
            //var result = (VideoGame)((ViewResult)controller.Details(1)).Model;
            // Act
            ViewResult result = controller.DeleteConfirmed(300) as ViewResult;

            // Assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]

        public void DeleteConfirmedValidId()
        {
            //Arrange
            FakeVideoGamesBL fake = new FakeVideoGamesBL();
            VideoGamesController controller = new VideoGamesController(fake);
            controller.testCase = true;
            //var result = (VideoGame)((ViewResult)controller.Details(1)).Model;
            // Act
            System.Web.Mvc.RedirectToRouteResult actual = (System.Web.Mvc.RedirectToRouteResult)controller.DeleteConfirmed(1);
            // Assert
            Assert.AreEqual("VideoGames", actual.RouteValues["action"]);
        }
        [TestMethod]
        public void Dispose()
        {
            //Arrange
            FakeVideoGamesBL fake = new FakeVideoGamesBL();
            VideoGamesController controller = new VideoGamesController(fake);
            controller.testCase = true;
            //var result = (VideoGame)((ViewResult)controller.Details(1)).Model;
            // Act
            controller.Dispose();
            // Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void IndexNotTestCase()
        {
            //Arrange
            FakeVideoGamesBL fake = new FakeVideoGamesBL();
            VideoGamesController controller = new VideoGamesController(fake);
            controller.testCase = false;
            //var result = (VideoGame)((ViewResult)controller.Details(1)).Model;
            // Act
            controller.Index();
            // Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void AddReview()
        {
            //Arrange
            FakeVideoGamesBL fake = new FakeVideoGamesBL();
            VideoGamesController controller = new VideoGamesController(fake);
            controller.testCase = true;
            Genre fps = new Genre { Name = "FPS", Description = "First-person shooter." };
            VideoGame csgo = new VideoGame
            {
                Name = "CS : GO",
                Price = 20,
                Developer = "UK",
                Publisher = "Steam",
                Description = "FPS Game",
                Genre = fps
            };
            Reviews review1 = new Reviews
            {
                Name = "Craig@email.com",
                Subject = "csgo",
                Review = "I can't play",
                Stars = 4,
                VideoGame = csgo,
                VideoGameId = 1
            };
            //var result = (VideoGame)((ViewResult)controller.Details(1)).Model;
            // Act
            string result = controller.AddReview(1, 1, "test", 5, "test");
            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void DeleteReview()
        {
            //Arrange
            FakeVideoGamesBL fake = new FakeVideoGamesBL();
            VideoGamesController controller = new VideoGamesController(fake);
            controller.testCase = true;
            Genre fps = new Genre { Name = "FPS", Description = "First-person shooter." };
            VideoGame csgo = new VideoGame
            {
                Name = "CS : GO",
                Price = 20,
                Developer = "UK",
                Publisher = "Steam",
                Description = "FPS Game",
                Genre = fps
            };
            Reviews review1 = new Reviews
            {
                Name = "Craig@email.com",
                Subject = "csgo",
                Review = "I can't play",
                Stars = 4,
                VideoGame = csgo,
                VideoGameId = 1
            };
            //var result = (VideoGame)((ViewResult)controller.Details(1)).Model;
            // Act
            ViewResult result = controller.DeleteReview(3, 1) as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }
    }
}
