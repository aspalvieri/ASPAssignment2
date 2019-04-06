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
            //var result = (VideoGame)((ViewResult)controller.Details(1)).Model;
            // Act
            ViewResult result = controller.Details(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }      
}


