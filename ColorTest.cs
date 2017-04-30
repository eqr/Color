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
            Paint green = new Paint();
            green.v = 100.0;
            green.r = 0;
            green.g = 50;
            green.b = 0;
            Paint blue = new Paint();
            blue.v = 100.0;
            blue.r = 0;
            blue.g = 0;
            blue.b = 50;

            // Act
            green.Mix(blue);

            // Assert
            Assert.AreEqual(200.0, green.v, 0.01); 
            Assert.AreEqual(0, green.r);

            Assert.AreEqual(25, green.g);
            Assert.AreEqual(25, green.b);
        }
    }
}
