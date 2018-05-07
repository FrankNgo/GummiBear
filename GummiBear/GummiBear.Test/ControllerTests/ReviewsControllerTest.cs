using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using GummiBear.Models;
using GummiBear.Tests;
using Moq;

namespace GummiBear.Controllers.Tests
{
    [TestClass]
    public class ReviewsControllerTests
    {
        private Mock<IReviewRepository> mock = new Mock<IReviewRepository>();
        private Mock<IItemRepository> mockItem = new Mock<IItemRepository>();
        //EFItemRepository db = new EFItemRepository(new TestDbContext());
        //EFItemRepository dbItem = new EFItemRepository(new TestDbContext());
        private void DbSetup()
        {
            mockItem.Setup(m => m.Items).Returns(new Item[]
                {
                    new Item { ItemId = 1, Name = "Test 1", Description = "Its a test" },
                    new Item { ItemId = 2, Name = "Test 2", Description = "Its another test"}
                }.AsQueryable());

            mock.Setup(m => m.Reviews).Returns(new Review[]
                {
                    new Review { Rating = 3, Content = "this is some content", ItemId = mockItem.Object.Items.FirstOrDefault().ItemId },
                    new Review { Rating = 4, Content = "this is some more content", ItemId = mockItem.Object.Items.LastOrDefault().ItemId }
                }.AsQueryable());
        }

     

        [TestMethod]
        public void Mock_GetViewResultIndex_ActionResult() // Confirms route returns view
        {
            DbSetup();
            ReviewsController controller = new ReviewsController(mock.Object);
            var result = controller.Index(mockItem.Object.Items.FirstOrDefault().ItemId);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
        [TestMethod]
        public void Mock_GetViewResultCreateGet_ActionResult() // Confirms route returns view
        {
            DbSetup();
            ReviewsController controller = new ReviewsController(mock.Object);
            var result = controller.Create();
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
        [TestMethod]
        public void Mock_GetViewResultCreatePost_ActionResult() // Confirms route returns view
        {
            DbSetup();
            int ItemId = mockItem.Object.Items.FirstOrDefault().ItemId;
            Review review = new Review { Rating = 2, Content = "some test content", ItemId = ItemId };
            ReviewsController controller = new ReviewsController(mock.Object);
            var result = controller.Create(review);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void Mock_IndexModelContainsItems_Collection()
        {
            DbSetup();
            ReviewsController controller = new ReviewsController(mock.Object);
            int ItemId = mockItem.Object.Items.FirstOrDefault().ItemId;

            ViewResult indexView = controller.Index(ItemId) as ViewResult;
            var collection = indexView.ViewData.Model as List<Review>;

            Assert.IsInstanceOfType(collection, typeof(List<Review>));
        }
    }
}