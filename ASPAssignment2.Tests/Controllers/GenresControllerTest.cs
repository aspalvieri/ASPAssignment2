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
    public class GenresControllerTest
    {
        /*GenresController controller;
        private DatabaseContext context = new DatabaseContext();
        [TestInitialize]
        public void TestInitialize(){
            Genre comedy = new Genre { Name = "Comedy", Description = "deep breath in your tough life" };
            Genre fps = new Genre { Name = "FPS", Description = "Men's romance" };
            Genre moba = new Genre { Name = "Moba", Description = "Uninstall button onclick" };
            context.Genres.Add(comedy);
            context.Genres.Add(fps);
            context.Genres.Add(moba);
            
        }*/



        [TestMethod]
        public void IndexTest() {
            //Arrange
            FakeGenreBL fake = new FakeGenreBL();
            GenresController controller = new GenresController(fake);
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
            FakeGenreBL fake = new FakeGenreBL();
            GenresController controller = new GenresController(fake);
            controller.testCase = true;
            //var result = (VideoGame)((ViewResult)controller.Details(1)).Model;
            // Act
            ViewResult result = controller.Details(3) as ViewResult;

            // Assert
            //Assert.AreEqual("", result.ViewName);
            Assert.IsNotNull(result.ViewName);
        }

        [TestMethod]
        public void DetailInValidId()
        {
            //Arrange
            FakeGenreBL fake = new FakeGenreBL();
            GenresController controller = new GenresController(fake);
            controller.testCase = true;
            //var result = (VideoGame)((ViewResult)controller.Details(1)).Model;
            // Act
            ViewResult result = controller.Details(300) as ViewResult;

            // Assert
            Assert.AreEqual("Details",result.ViewName);
        }

        [TestMethod]
        public void CreateView()
        {
            //Arrange
            FakeGenreBL fake = new FakeGenreBL();
            GenresController controller = new GenresController(fake);
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
            FakeGenreBL fake = new FakeGenreBL();
            GenresController controller = new GenresController(fake);
            controller.testCase = true;
            Genre test = new Genre {GenreId = 100, Name = "test", Description = "test" };
            //var result = (VideoGame)((ViewResult)controller.Details(1)).Model;
            // Act
            ViewResult result = controller.Create(test) as ViewResult;

            // Assert
            Assert.AreEqual("Create", result.ViewName);
        }


        [TestMethod]
        public void InvalidEdit()
        {
            //Arrange
            FakeGenreBL fake = new FakeGenreBL();
            GenresController controller = new GenresController(fake);
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
            FakeGenreBL fake = new FakeGenreBL();
            GenresController controller = new GenresController(fake);
            controller.testCase = true;
            //var result = (VideoGame)((ViewResult)controller.Details(1)).Model;
            // Act
            ViewResult result = controller.Edit(1) as ViewResult;

            // Assert
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void ValidEditSave()
        {
            //Arrange
            FakeGenreBL fake = new FakeGenreBL();
            GenresController controller = new GenresController(fake);
            controller.testCase = true;
            //var result = (VideoGame)((ViewResult)controller.Details(1)).Model;
            // Act
            Genre fps = new Genre { Name = "FPS", Description = "Men's romance" };
            ViewResult result = controller.Edit(fps) as ViewResult;
            
            // Assert
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void InValidDelete()
        {
            //Arrange
            FakeGenreBL fake = new FakeGenreBL();
            GenresController controller = new GenresController(fake);
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
            FakeGenreBL fake = new FakeGenreBL();
            GenresController controller = new GenresController(fake);
            controller.testCase = true;
            //var result = (VideoGame)((ViewResult)controller.Details(1)).Model;
            // Act
            ViewResult result = controller.Delete(1) as ViewResult;
            

            // Assert
            Assert.AreEqual("Delete", result.ViewName);
        }

        [TestMethod]
        public void DeleteConfirmedInvalidId()
        {
            //Arrange
            FakeGenreBL fake = new FakeGenreBL();
            GenresController controller = new GenresController(fake);
            controller.testCase = true;
            //var result = (VideoGame)((ViewResult)controller.Details(1)).Model;
            // Act
            ViewResult result = controller.DeleteConfirmed(300) as ViewResult;

            // Assert
            Assert.AreEqual("Error", result.ViewName);
        }

        public void DeleteConfirmedValidId()
        {
            //Arrange
            FakeGenreBL fake = new FakeGenreBL();
            GenresController controller = new GenresController(fake);
            controller.testCase = true;
            //var result = (VideoGame)((ViewResult)controller.Details(1)).Model;
            // Act
            System.Web.Mvc.RedirectToRouteResult actual = (System.Web.Mvc.RedirectToRouteResult)controller.DeleteConfirmed(1);
            // Assert
            Assert.AreEqual("Index", actual.RouteValues["action"]);
        }

    }
}


