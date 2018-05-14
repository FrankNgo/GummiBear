using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GummiBear.Controllers;
using GummiBear.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GummiBear.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void HomeController_ReturnView_View()
        {
            //arrange
            HomeController controller = new HomeController();

            //act
            var Index = new HomeController().Index();

            //assert
            Assert.IsInstanceOfType(Index, typeof(ViewResult));
        }

    }
}