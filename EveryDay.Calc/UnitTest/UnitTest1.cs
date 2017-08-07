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
            var sum = calc.Sum("1", "2");
            var sum1 = calc.Sum("0", "0");
            var sum2 = calc.Sum("1", "-1");

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
            var div = calc.Div("2", "1");
            var div1 = calc.Div("0", "0");
            var div2 = calc.Div("1", "-1");

            // Assert
            Assert.AreEqual(2, div);
            Assert.AreEqual(0, div1);
            Assert.AreEqual(-1, div2);
        }

        [TestMethod]
        public void TestSqr()
        {
            // Arrage
            var calc = new Calculator();

            // Act
            var sqr = calc.Sqr("2");
            var sqr1 = calc.Sqr("0");
            var sqr2 = calc.Sqr("-5");

            // Assert
            Assert.AreEqual(4, sqr);
            Assert.AreEqual(0, sqr1);
            Assert.AreEqual(25, sqr2);
        }

        [TestMethod]
        public void TestSqrt()
        {
            // Arrage
            var calc = new Calculator();

            // Act
            var sqrt = calc.Sqrt("25");
            var sqrt1 = calc.Sqrt("0");
            var sqrt2 = calc.Sqrt("-16");

            // Assert
            Assert.AreEqual(5, sqrt);
            Assert.AreEqual(0, sqrt1);
            Assert.AreEqual(-4, sqrt2);
        }

        [TestMethod]
        public void TestMult()
        {
            // Arrage
            var calc = new Calculator();

            // Act
            var str = new string[] {"mult", "5", "2"};
            var str1 = new string[] { "mult", "0", "2" };
            var str2 = new string[] { "mult", "2", "-1", "5" };
            var mul = calc.Mult(str);
            var mul1 = calc.Mult(str1);
            var mul2 = calc.Mult(str2);

            // Assert
            Assert.AreEqual(10, mul);
            Assert.AreEqual(0, mul1);
            Assert.AreEqual(-10, mul2);
        }

        [TestMethod]
        public void TestPercOf()
        {
            // Arrage
            var calc = new Calculator();

            // Act
            var perc = calc.PercOf("10", "10");
            var perc1 = calc.PercOf("0", "5");
            var perc2 = calc.PercOf("1", "300");

            // Assert
            Assert.AreEqual(1, perc);
            Assert.AreEqual(0, perc1);
            Assert.AreEqual(3, perc2);
        }
    }
}
