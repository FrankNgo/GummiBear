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
            item.Name = "Blender";
            var result = item.Name;
        
            //Assert
            Assert.AreEqual("Blender", result);
        }

        [TestMethod]
        public void GetCost_ReturnsItemCost_String()
        {
            //Arrange
            var item = new Item();

            //Act
            item.Cost = "10.00";
            var result = item.Cost;

            //Assert
            Assert.AreEqual("10.00", result);
        }

        [TestMethod]
        public void GetDescription_ReturnsItemDescription_String()
        {
            //Arrange
            var item = new Item();

            //Act
            item.Description = "A portable blender";
            var result = item.Description;

            //Assert
            Assert.AreEqual("A portable blender", result);
        }

    }
}