using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using GummiBear.Models;
using GummiBear.Tests;
using Moq;
using GummiBear.Controllers;
using System.Threading.Tasks;


namespace GummiBear.Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Controller_ReturnsViewIndex_Index()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}