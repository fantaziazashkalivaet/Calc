using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EveryDay.Calc.Calculation;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSum()
        {
            // Arrage
            var calc = new Calculator();

            // Act
            var sum = calc.Sum(1, 2);
            var sum1 = calc.Sum(0, 0);
            var sum2 = calc.Sum(1, -1);

            // Assert
            Assert.AreEqual(3, sum);
            Assert.AreEqual(0, sum1);
            Assert.AreEqual(0, sum2);
        }

        [TestMethod]
        public void TestDiv()
        {
            // Arrage
            var calc = new Calculator();

            // Act
            var div = calc.Div(2, 1);
            var div1 = calc.Div(0, 0);
            var div2 = calc.Div(1, -1);

            // Assert
            Assert.AreEqual(2, div);
            Assert.AreEqual(0, div1);
            Assert.AreEqual(-1, div2);
        }
    }
}
