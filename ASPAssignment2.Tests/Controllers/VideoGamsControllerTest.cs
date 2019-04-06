using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASPAssignment2;
using ASPAssignment2.Controllers;
using Moq;
using ASPAssignment2.Models;

namespace ASPAssignment2.Tests.Controllers
{
    [TestClass]
    public class VideoGamsControllerTest
    {
        /*VideoGamesController controller;
        List<VideoGame> videogames;
        Mock<IVideoGamesMock> mock;

        [TestInitialize]
        public void TestInitialize()
        {
            // Arrange
            mock = new Mock<IVideoGamesMock>();
            Genre fps = new Genre { Name = "FPS", Description = "Men's romance" };
            List<VideoGame> videogames = new List<VideoGame> {
                new VideoGame {
                    VideoGameId = 1,
                    GenreId = 1,
                    Name = "CSGO",
                    Price = 20m,
                    Developer = "UK",
                    Publisher = "steam",
                    Description = "FPS Game",
                    Genre = fps
                },
                new VideoGame {
                    VideoGameId = 2,
                    Name = "CS1.5",
                    Price = 40m,
                    Developer = "UK",
                    Publisher = "UK",
                    Description = "FPS Game",
                    Genre = fps
                },
                new VideoGame {
                    VideoGameId = 3,
                    Name = "CS1.6",
                    Price = 30m,
                    Developer = "UK",
                    Publisher = "steam",
                    Description = "FPS Game",
                    Genre = fps
                }
            };

            //popolate interface from data
            mock.Setup(m => m.videoGames).Returns(videogames.AsQueryable());
            controller = new VideoGamesController(mock.Object);

        }
        [TestMethod]
        public void IndexViewTest()
        {


            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual(result.ViewName, "Index");
        }





        [TestMethod]
        public void VideoGamesViewTest()
        {
            // Act
            ViewResult result = controller.VideoGames() as ViewResult;

            // Assert
            Assert.AreEqual(result.ViewName, "VideoGames");
        }

        [TestMethod]
        public void DetailValidId()
        {
            //var result = (VideoGame)((ViewResult)controller.Details(1)).Model;
            // Act
            ViewResult result = controller.Details(1) as ViewResult;

            // Assert
            Assert.AreEqual(result.ViewName, "Details");
        }

        [TestMethod]
        public void DetailInvalidId()
        {
            // Act
            ViewResult result = controller.Details(100) as ViewResult;

            // Assert
            Assert.AreEqual(result.ViewName, "Error");
        }

        [TestMethod]
        public void DetailNullId()
        {
            // Act
            ViewResult result = controller.Details(null) as ViewResult;

            // Assert
            Assert.AreEqual(result.ViewName, "Error");
        }

        [TestMethod]
        public void AddInvalideview()
        {
            // Act
            var result = controller.AddReview(-1, -1, "", -1, "");

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void DeleteInvalid()
        {
            //Arrange
            int id = 100;
            // Act
            ViewResult result = controller.Delete(id) as ViewResult;

            // Assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void DeleteValid()
        {
            //Arrange
            int id = 1;
            // Act
            ViewResult result = controller.Delete(id) as ViewResult;

            // Assert
            Assert.AreEqual("Delete", result.ViewName);
        }

        [TestMethod]
        public void DeleteNull()
        {
            //Arrange
            int id = 1;
            // Act
            ViewResult result = controller.Delete(null) as ViewResult;

            // Assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void DeleteNullReview()
        {
            // Act
            ActionResult result = controller.DeleteReview(1, 1);

            // Assert
            Assert.AreEqual("Error", result.ToString());
        }

        [TestMethod]
        public void CreateInvalid()
        {
            controller.ModelState.AddModelError("key", "error data");
            // Act
            ViewResult result = controller.Create(null) as ViewResult;

            // Assert
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void CreateValid()
        {
            //arrange
            Genre fps = new Genre { Name = "FPS", Description = "Men's romance" };
            VideoGame videoGame1 = new VideoGame
            {
                VideoGameId = 100,
                GenreId = 1,
                Name = "CSGO",
                Price = 20m,
                Developer = "UK",
                Publisher = "steam",
                Description = "FPS Game",
                Genre = fps
            };
            // Act
            ViewResult result = controller.Create(videoGame1) as ViewResult;

            // Assert
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void CreateView()
        {
            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.AreEqual("Create", result.ViewName);

        }*/
    }
}
