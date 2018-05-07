using Microsoft.VisualStudio.TestTools.UnitTesting;
using GummiBear.Models;
using System;
using Moq;
using System.Linq;
using GummiBear.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GummiBear.Test.ControllerTests
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
                new Item {ItemId = 1, Name = "Blender" },
                new Item {ItemId = 2, Name = "Dishwasher" },
                new Item {ItemId = 3, Name = "Dryer" }
                }.AsQueryable());
            }

            [TestMethod]
            public void Mock_GetViewResultIndex_ActionResult() 
            {
                //Arrange
                DbSetup();
                ItemsController controller = new ItemsController(mock.Object);

                //Act
                var result = controller.Index();

                //Assert
                Assert.IsInstanceOfType(result, typeof(ActionResult));
            }



            [TestMethod]
            public void Mock_IndexContainsModelData_List() 
            {
                // Arrange
                DbSetup();
                ViewResult indexView = new ItemsController(mock.Object).Index() as ViewResult;

                // Act
                var result = indexView.ViewData.Model;

                // Assert
                Assert.IsInstanceOfType(result, typeof(List<Item>));
            }

            [TestMethod]
            public void Mock_DeleteGetModelContainsItem_Item()
            {
                // Arrange
                DbSetup();
                Item item = mock.Object.Items.FirstOrDefault();
                ItemsController controller = new ItemsController(mock.Object);

                // Act
                var resultView = controller.Delete(item.ItemId) as ViewResult;
                var model = resultView.ViewData.Model as Item;

                // Assert
                Assert.IsInstanceOfType(model, typeof(Item));
                Assert.AreEqual(item, model);
            }

            [TestMethod]
            public void Mock_DeleteAllGetModelContainsItem_Item()
            {
                // Arrange
                DbSetup();
                Item item = mock.Object.Items.FirstOrDefault();
                ItemsController controller = new ItemsController(mock.Object);

                // Act
                var resultView = controller.DeleteAll(item.ItemId) as ViewResult;
                var model = resultView.ViewData.Model as Item;

                // Assert
                Assert.IsInstanceOfType(model, typeof(Item));
                Assert.AreEqual(item, model);
            }

            [TestMethod]
            public void Mock_GetViewResultCreatePost_ActionResult() 
            {
                // Arrange
                DbSetup();
                Item item = new Item { ItemId = 3, Name = "Test 3", Description = "Its one more test" };
                ItemsController controller = new ItemsController(mock.Object);

                // Act
                var result = controller.Create(item);

                // Assert
                Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            }

            [TestMethod]
            public void Mock_GetDetails_ReturnsView()
            {
                // Arrange
                Item testItem = new Item
                {
                    ItemId = 1,
                    Description = "Blender"
                };

                DbSetup();
                ItemsController controller = new ItemsController(mock.Object);

                // Act
                var resultView = controller.Details(testItem.ItemId) as ViewResult;
                var model = resultView.ViewData.Model as Item;

                // Assert
                Assert.IsInstanceOfType(resultView, typeof(ViewResult));
                Assert.IsInstanceOfType(model, typeof(Item));
            }

  
        }
    }
}
