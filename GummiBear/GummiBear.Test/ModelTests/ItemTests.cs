using Microsoft.VisualStudio.TestTools.UnitTesting;
using GummiBear.Models;

namespace GummiBear.Tests
{
    [TestClass]
    public class ItemTests
    {
        [TestMethod]
        public void GetName_ReturnsItemName_String()
        {
            //Arrange
            var item = new Item();

            //Act
            var result = item.Name;

            //Assert
            Assert.AreEqual("Blender", result);
        }
    }
}