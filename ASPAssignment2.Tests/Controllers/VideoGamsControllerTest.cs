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
        VideoGamesController controller;
        List<VideoGame> videogames;
        Mock<IVideoGamesMock> mock;

        [TestInitialize]
        public void TestInitialize() {
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
        public void IndexTest()
        {
            

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result.ViewName);
        }


            
  

        [TestMethod]
        public void VideoGames()
        {
            // Act
            ViewResult result = controller.VideoGames() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
