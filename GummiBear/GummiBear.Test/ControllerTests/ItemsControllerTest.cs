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
using GummiBear.Models.Repositories;

namespace GummiBear.Test
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
                    new Item {ItemId = 2, Name = "Mixer Cup"},
                    new Item {ItemId = 3, Name = "Coffee"}
                }.AsQueryable());
            }

        [TestMethod]
        public void MockDB_IndexReturnsView_ActionResult()
        {
            //arrange
            DbSetup();
            ItemsController controller = new ItemsController(mock.Object);

            //act
            var result = controller.Index();

            //assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Mock_ItemIndexContainsData_List()
        {
            //arrange
            DbSetup();
            ViewResult indexView = new ItemsController(mock.Object).Index() as ViewResult;

            //act
            var result = indexView.ViewData.Model;

            //assert
            Assert.IsInstanceOfType(result, typeof(List<Item>));
        }

        [TestMethod]
        public void Mock_IndexModelContainsItems_Collection()
        {
            //arrange
            DbSetup();
            Item testItem = new Item { ItemId = 1, Name = "Blender" };
            ItemsController controller = new ItemsController(mock.Object);

            //act
            ViewResult indexView = controller.Index() as ViewResult;
            List<Item> collection = indexView.ViewData.Model as List<Item>;

            //assert
            CollectionAssert.Contains(collection, testItem);
        }


        [TestMethod]
        public void Mock_PostViewResultCreate_ViewResult()
        {
            //arrange
            DbSetup();
            Item testItem = new Item { ItemId = 1, Name = "Blender"};
            ItemsController controller = new ItemsController(mock.Object);

            //act
            var resultView = controller.Create(testItem);

            //assert
            Assert.IsInstanceOfType(resultView, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void Mock_GetDetails_ReturnsView()
        {
            //arrange
            DbSetup();
            Item testItem = new Item { ItemId = 1, Name = "Blender"};
            ItemsController controller = new ItemsController(mock.Object);

            //act
            var resultView = controller.Details(testItem.ItemId) as ViewResult;

            //assert
            Assert.IsInstanceOfType(resultView, typeof(ViewResult));
        }

        [TestMethod]
        public void Mock_EditItem_ReturnsView()
        {
            //arrange
            DbSetup();
            Item testItem = new Item { ItemId = 1, Name = "Blender" };
            ItemsController controller = new ItemsController(mock.Object);

            //act
            var resultView = controller.Edit(testItem.ItemId) as ViewResult;
            var model = resultView.ViewData.Model as Item;

            //assert
            Assert.IsInstanceOfType(resultView, typeof(ViewResult));
            Assert.IsInstanceOfType(model, typeof(Item));
        }

        [TestMethod]
        public void Mock_DeleteItem_ReturnsView()
        {
            //arrange
            DbSetup();
            Item testItem = new Item { ItemId = 1, Name = "Blender" };
            ItemsController controller = new ItemsController(mock.Object);


            //act
            var resultView = controller.Delete(testItem.ItemId) as ViewResult;
            var model = resultView.ViewData.Model as Item;

            //assert
            Assert.IsInstanceOfType(resultView, typeof(ViewResult));
            Assert.IsInstanceOfType(model, typeof(Item));
        }

        [TestMethod]
        public void Mock_DeleteAllItems_ReturnsView()
        {
            //arrange
            DbSetup();
            Item testItem = new Item { ItemId = 1, Name = "Blender"};
            ItemsController controller = new ItemsController(mock.Object);

            //act
            var resultView = controller.DeleteAll() as ViewResult;

            //assert
            Assert.IsInstanceOfType(resultView, typeof(ViewResult));
        }

    }
}
