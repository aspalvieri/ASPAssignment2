using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASPAssignment2;
using ASPAssignment2.Controllers;
using ASPAssignment2.Models;
using moq;

namespace ASPAssignment2.Tests.Controllers
{
    [TestClass]
    public class GenresControllerTest
    {
        GenresController controller;
        List<Genre> genres;
    

        [TestInitialize]
        public void TestInitialize(){
            Genre comedy = new Genre { Name = "Comedy", Description = "deep breath in your tough life" };
            Genre fps = new Genre { Name = "FPS", Description = "Men's romance" };
            Genre moba = new Genre { Name = "Moba", Description = "Uninstall button onclick" };
            genres = new List<Genre> { comedy, fps, moba };

           
        }
    }      
}


