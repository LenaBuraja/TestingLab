using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static CorrectTriagle.Program;

namespace UnitTests {
    [TestClass]
    public class UnitTest1 {

        [TestMethod] //1
        public void NegativeNumber( ) {
            Assert.AreEqual(isTriagle(4, -2, 5), false);
        }

        [TestMethod] //2
        public void TwoInfinity( ) {
            Assert.AreEqual(isTriagle(float.PositiveInfinity, 4, float.PositiveInfinity), false);
        }

        [TestMethod] //3
        public void OneInfinity( ) {
            Assert.AreEqual(isTriagle(4, float.PositiveInfinity, 5), false);
        }

        [TestMethod] //4
        public void NotNAN() {
            Assert.AreEqual(isTriagle(float.NaN, 4, 5), false);
        }

        [TestMethod] //5
        public void Line( ) {
            Assert.AreEqual(isTriagle(4, 3, 7), false);
        }

        [TestMethod] //6
        public void FewerBorders( ) {
            Assert.AreEqual(isTriagle(4, (float)2.99999, 7), false);
        }

        [TestMethod] //7
        public void MuchFewerBorders( ) {
            Assert.AreEqual(isTriagle(1, 17, 23), false);
        }

        [TestMethod] //8
        public void MoreBorders( ) {
            Assert.AreEqual(isTriagle(4, (float)3.00009, 7), true);
        }

        [TestMethod] //9
        public void MuchMoreBorders( ) {
            Assert.AreEqual(isTriagle(11, 17, 23), true);
        }


        [TestMethod] //10
        public void EquilateralTriangle( ) {
            Assert.AreEqual(isTriagle(14, 7, 14), true);
        }
    }
}
