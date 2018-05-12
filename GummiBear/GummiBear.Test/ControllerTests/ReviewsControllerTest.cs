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
    public class ReviewsControllerTest
    {
        [TestClass]
        public class ReviewsControllerTests
        {
            Mock<IReviewRepository> mock = new Mock<IReviewRepository>();

            private void DbSetup()
            {
                mock.Setup(m => m.Reviews).Returns(new Review[]
                {
                new Review {ReviewId = 1, Author = "Blender" },
                new Review {ReviewId = 2, Author = "Dishwasher" },
                new Review {ReviewId = 3, Author = "Dryer" }
                }.AsQueryable());
            }

            [TestMethod]
            public void Mock_GetViewResultIndex_ActionResult()
            {
                //Arrange
                DbSetup();
                ReviewsController controller = new ReviewsController(mock.Object);

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
                ViewResult indexView = new ReviewsController(mock.Object).Index() as ViewResult;

                // Act
                var result = indexView.ViewData.Model;

                // Assert
                Assert.IsInstanceOfType(result, typeof(List<Review>));
            }

         

        

            [TestMethod]
            public void Mock_GetViewResultCreatePost_ActionResult()
            {
                // Arrange
                DbSetup();
                Review Review = new Review { ReviewId = 1, Author = "Blender" };
                ReviewsController controller = new ReviewsController(mock.Object);

                // Act
                var result = controller.Create(Review);

                // Assert
                Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            }

         
        }
    }
}
