using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Colors
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange 
            var greenColor = new PigmentColor(0, 50, 0);
            Paint green = new Paint(100.0, greenColor);
            var blueColor = new PigmentColor(0, 0, 50);
            Paint blue = new Paint(100.0, blueColor);

            // Act
            green.Mix(blue);

            // Assert
            Assert.AreEqual(200.0, green.Volume, 0.01);
            Assert.AreEqual(0, green.Color.Red);

            Assert.AreEqual(25, green.Color.Green);
            Assert.AreEqual(25, green.Color.Blue);
        }
    }
}
