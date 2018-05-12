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

namespace GummiBear.Test
{
    public class ItemsControllerTest
    {
    [TestClass]
    public class ItemsControllerTests
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

            [TestMethod]
            public void Controller_GetViewResultDetails_IActionResult()
            {
                //Arrange
                DbSetup();
                ItemsController controller = new ItemsController(mock.Object);

                //Act
                var result = controller.Details(1);

                //Assert
                Assert.IsInstanceOfType(result, typeof(Task<IActionResult>));
            }

            [TestMethod]
            public void Controller_GetViewResultCreate_IActionResult()
            {
                //Arrange
                DbSetup();
                ItemsController controller = new ItemsController(mock.Object);

                //Act
                var result = controller.Create();

                //Assert
                Assert.IsInstanceOfType(result, typeof(IActionResult));
            }

            [TestMethod]
            public void Controller_HttpPostCreate_Creates()
            {
                //Arrange
                DbSetup();
                ItemsController controller = new ItemsController(mock.Object);

                //Act
                var result = controller.Create();

                //Assert
                Assert.IsInstanceOfType(result, typeof(ViewResult));
            }

            [TestMethod]
            public void Controller_GetViewEdit_Edits()
            {
                //Arrange
                DbSetup();
                ItemsController controller = new ItemsController(mock.Object);

                //Act
                var result = controller.Edit(1);

                //Assert
                Assert.IsInstanceOfType(result, typeof(Task<IActionResult>));
            }

            [TestMethod]
            public void Controller_HttpPostEdit_Edits()
            {
                //Arrange
                DbSetup();
                ItemsController controller = new ItemsController(mock.Object);

                //Act
                var result = controller.Edit(1);

                //Assert
                Assert.IsInstanceOfType(result, typeof(Task<IActionResult>));
            }

            [TestMethod]
            public void Controller_GetViewDelete_Deletes()
            {
                DbSetup();
                ItemsController controller = new ItemsController(mock.Object);

                //Act
                var result = controller.Delete(1);

                //Assert
                Assert.IsInstanceOfType(result, typeof(Task<IActionResult>));
            }

            [TestMethod]
            public void Controller_HttpPostDeleteConfirm_Confirms()
            {
                DbSetup();
                ItemsController controller = new ItemsController(mock.Object);

                //Act
                var result = controller.DeleteConfirmed(1);

                //Assert
                Assert.IsInstanceOfType(result, typeof(Task<IActionResult>));
            }

            [TestMethod]
            public void Controller_GetViewResultDeleteAllGet_ActionResult() // Confirms route returns view
            {
                DbSetup();
                ItemsController controller = new ItemsController(mock.Object);
                var result = controller.DeleteAll();
                Assert.IsInstanceOfType(result, typeof(ViewResult));
            }

            [TestMethod]
            public void Controller_GetViewResultDeleteAllPost_ActionResult() // Confirms route returns view
            {
                DbSetup();
                ItemsController controller = new ItemsController(mock.Object);
                var result = controller.DeleteAllConfirmed();
                Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            }

        }
    }
}
