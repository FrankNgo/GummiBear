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
    public class GummisControllerTest
    {
        Mock<IItemRepository> mock = new Mock<IItemRepository>();

        private void DbSetup()
        {
            mock.Setup(m => m.Items).Returns(new Item[]
            {
                new Item {ItemId = 1, Description = "A new red gummi" },
                new Item {ItemId = 2, Description = "A new blue gummi"},
                new Item {ItemId = 3, Description = "A new green gummi"}
            }.AsQueryable());
        }

        [TestMethod]
        public void Controller_GetViewResultIndex_IActionResult()
        {
            //Arrange
            DbSetup();
            ItemsController controller = new ItemsController(mock.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(Task<IActionResult>));
        }


    }
}