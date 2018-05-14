using Microsoft.VisualStudio.TestTools.UnitTesting;
using GummiBear.Models;
using GummiBear.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Moq;
using System.Linq;

namespace GummiBear
{
    [TestClass]
    public class ItemsControllerTests
    {
        Mock<IItemRepository> mock = new Mock<IItemRepository>();
        EFItemRepository db = new EFItemRepository(new TestDbContext());

        private void DbSetUp()
        {
            mock.Setup(m => m.Items).Returns(new Item[]
            {
                new Item {ItemId = 1, Name = "Blender"},
                new Item {ItemId = 1, Name = "Ipod"},
                new Item {ItemId = 1, Name = "Hat"}
            }.AsQueryable());
        }

        [TestMethod]
        public void Mock_GetViewResultIndex_ActionResult()
        {
            //arrange
            DbSetUp();
            ItemsController controller = new ItemsController(mock.Object);

            //act
            var result = controller.Index();

            //assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Mock_IndexContainsData_List()
        {
            //arrange
            DbSetUp();
            ViewResult indexView = new ItemsController(mock.Object).Index() as ViewResult;

            //act
            var result = indexView.ViewData.Model;

            //assert
            Assert.IsInstanceOfType(result, typeof(List<Item>));
        }

        [TestMethod]
        public void Mock_IndexContainsItems_Collection()
        {
            //arrange
            DbSetUp();
            ItemsController controller = new ItemsController(mock.Object);
            Item item = new Item { ItemId = 1, Name = "Blender" };

            //act
            ViewResult indexView = controller.Index() as ViewResult;
            List<Item> collection = indexView.ViewData.Model as List<Item>;

            //assert
            CollectionAssert.Contains(collection, item);
        }

        [TestMethod]
        public void Mock_HttpGetDetails_ReturnsView()
        {
            //arrange
            Item item = new Item { ItemId = 1, Name = "Blender" };
            DbSetUp();
            ItemsController controller = new ItemsController(mock.Object);

            //act
            var resultView = controller.Details(item.ItemId) as ViewResult;
            var model = resultView.ViewData.Model as Item;

            //assert
            Assert.IsInstanceOfType(resultView, typeof(ViewResult));
            Assert.IsInstanceOfType(model, typeof(Item));
        }

        [TestMethod]
        public void testDb_CreateWorks_CreateInDB()
        {
            //arrange
            ItemsController controller = new ItemsController(db);
            Item testItem = new Item { ItemId = 1, Name = "Blender" };


            //act
            controller.Create(testItem);
            var collection = (controller.Index() as ViewResult).ViewData.Model as List<Item>;

            //assert
            CollectionAssert.Contains(collection, testItem);
            db.RemoveAll();
        }

        [TestMethod]
        public void testDb_DeleteWorks_RemovesInDB()
        {
            //arrange
            ItemsController controller = new ItemsController(db);
            Item testItem = new Item { ItemId = 1, Name = "Blender" };

            //act
            var collection = (controller.Index() as ViewResult).ViewData.Model as List<Item>;

            //assert
            CollectionAssert.DoesNotContain(collection, testItem);
        }

        [TestMethod]
        public void testDb_EditWOrks_UpdatesInDb()
        {
            //arrange
            ItemsController controller = new ItemsController(db);
            Item testItem = new Item { ItemId = 1, Name = "Blender" };
            Item updatedItem = new Item { ItemId = 1, Name = "Blender" };

            //act
            testItem.Name = "Blender";
            var returnedItem = (controller.Details(1) as ViewResult).ViewData.Model as Item;

            //assert
            Assert.AreEqual(returnedItem.Name, "Blender");
        }
    }
}