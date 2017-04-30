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
            Paint green = new Paint(100.0, 0, 50, 0);
            Paint blue = new Paint(100.0, 0, 0, 50);

            // Act
            green.Mix(blue);

            // Assert
            Assert.AreEqual(200.0, green.volume, 0.01);
            Assert.AreEqual(0, green.red);

            Assert.AreEqual(25, green.green);
            Assert.AreEqual(25, green.blue);
        }
    }
}
