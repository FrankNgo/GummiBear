using Microsoft.VisualStudio.TestTools.UnitTesting;
using GummiBear.Models;

namespace GummiBear.Tests
{
    [TestClass]
    public class ReviewTests
    {
        [TestMethod]
        public void GetAuthor_ReturnsReviewAuthor_String()
        {
            //Arrange
            var review = new Review();

            //Act
            review.Author = "Jake";
            var result = review.Author;

            //Assert
            Assert.AreEqual("Jake", result);
        }

        [TestMethod]
        public void GetContent_ReturnsReviewContent_String()
        {
            //Arrange
            var review = new Review();

            //Act
            review.Content = "It was ok";
            var result = review.Content;

            //Assert
            Assert.AreEqual("It was ok", result);
        }

        [TestMethod]
        public void GetRating_ReturnsReviewRating_Int()
        {
            //Arrange
            var review = new Review();

            //Act
            review.Rating = "5";
            var result = review.Rating;

            //Assert
            Assert.AreEqual("5", result);
        }

    }
}