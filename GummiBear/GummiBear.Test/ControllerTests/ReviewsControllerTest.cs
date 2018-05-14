using Microsoft.VisualStudio.TestTools.UnitTesting;
using GummiBear.Models;
using GummiBear.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Moq;
using System.Linq;

namespace GummiBearTest
{
    [TestClass]
    public class ReviewsControllerTests
    {
        Mock<IReviewRepository> mock = new Mock<IReviewRepository>();
        EFItemRepository dbProd = new EFItemRepository(new TestDbContext());
        EFReviewRepository db = new EFReviewRepository(new TestDbContext());

        private void DbSetUp()
        {
            mock.Setup(m => m.Reviews).Returns(new Review[]
            {
                new Review {ReviewId = 1, Content = "A Review", Rating=4, Author="Frank Ngo"},
                new Review {ReviewId = 2, Content = "Another Review", Rating=4, Author="Joe Smith"},
            }.AsQueryable());
        }

        [TestMethod]
        public void Mock_GetViewResultIndex_ActionResult()
        {
            //arrange
            DbSetUp();
            ReviewsController controller = new ReviewsController(mock.Object);

            //act
            var result = controller.Index();

            //assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Mock_IndexContainsModelData_List()
        {
            //arrange
            DbSetUp();
            ViewResult indexView = new ReviewsController(mock.Object).Index() as ViewResult;

            //act
            var result = indexView.ViewData.Model;

            //assert
            Assert.IsInstanceOfType(result, typeof(List<Review>));
        }

        [TestMethod]
        public void Mock_IndexContainsReviews_Collection()
        {
            //arrange
            DbSetUp();
            ReviewsController controller = new ReviewsController(mock.Object);
            Review review = new Review { ReviewId = 1, Content = "A Review", Rating = 4, Author = "Frank Ngo" };

            //act
            ViewResult indexView = controller.Index() as ViewResult;
            List<Review> collection = indexView.ViewData.Model as List<Review>;

            //assert
            CollectionAssert.Contains(collection, review);
        }

        [TestMethod]
        public void testDb_CreateReview_AddsReviewToDb()
        {
            //arrange
            ReviewsController controller = new ReviewsController(db);
            ItemsController prodController = new ItemsController(dbProd);
            Item testItem = new Item { ItemId = 1, Name = "Blender" };
            Review testReview = new Review { ReviewId = 1, Content = "A Review", Rating = 4, Author = "Frank Ngo" };

            //act
            var collection = (controller.Index() as ViewResult).ViewData.Model as List<Review>;

            //assert
            CollectionAssert.Contains(collection, testReview);
  
        }

        [TestMethod]
        public void testDb_DeleteReview_RemovesReviewFromDb()
        {
            //arrange
            ReviewsController controller = new ReviewsController(db);
            ItemsController prodController = new ItemsController(dbProd);
            Item testItem = new Item { ItemId = 1, Name = "Blender" };
            Review testReview = new Review { ReviewId = 1, Content = "A Review", Rating = 4, Author = "Frank Ngo" };

            //act
            var collection = (controller.Index() as ViewResult).ViewData.Model as List<Review>;

            //assert
            CollectionAssert.DoesNotContain(collection, testReview);
        }
    }
}