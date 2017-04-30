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
            MixedPaint paint = new MixedPaint();
            
            // Act
            paint.MixIn(green);
            paint.MixIn(blue);

            // Assert
            Assert.AreEqual(200.0, paint.Volume, 0.01);
            Assert.AreEqual(0, paint.Color.Red);

            Assert.AreEqual(25, paint.Color.Green);
            Assert.AreEqual(25, paint.Color.Blue);

            Assert.IsTrue(paint.Constituents.Contains(green));
            Assert.IsTrue(paint.Constituents.Contains(blue));
        }
    }
}
