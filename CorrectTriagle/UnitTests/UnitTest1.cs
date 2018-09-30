using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static CorrectTriagle.Program;

namespace UnitTests {
    [TestClass]
    public class UnitTest1 {

        [TestMethod] //1
        public void NegativeNumber( ) {
            bool result;
            try {
                result = isCorrectTriagle(4, -2, 5);
            }
            catch (Exception e) {
                Assert.AreEqual(e.Message, "Must be positive");
                return;
            }
                 Assert.Fail("Exception expected");
        }

        [TestMethod] //2
        public void TwoInfinity( ) {
            bool result;
            try {
                result = isCorrectTriagle(float.PositiveInfinity, 4, float.PositiveInfinity);
            } catch (Exception e) {
                Assert.AreEqual(e.Message, "Uncertainty");
                return;
            }
            Assert.Fail("Exception expected");
        }

        [TestMethod] //3
        public void OneInfinity( ) {
            bool result;
            try {
                result = isCorrectTriagle(4, float.PositiveInfinity, 5);
                Assert.AreEqual(result, false);
           } catch (Exception e) {
                Assert.Fail("Exception not expected");
            }
        }

        [TestMethod] //4
        public void NotNAN() {
            bool result;
            try {
                result = isCorrectTriagle(float.NaN, 4, 5);
            } catch (Exception e) {
                Assert.AreEqual(e.Message, "Must be number");
                return;
            }
            Assert.Fail("Exception expected");
        }

        [TestMethod] //5
        public void Line( ) {
            bool result;
            try {
                result = isCorrectTriagle(4, 3, 7);
                Assert.AreEqual(result, false);
            } catch (Exception e) {
                Assert.Fail("Exception not expected");
            }
        }

        [TestMethod] //6
        public void FewerBorders( ) {
            bool result;
            try {
                result = isCorrectTriagle(4, (float)2.99999, 7);
                Assert.AreEqual(result, false);
            } catch (Exception e) {
                Assert.Fail("Exception not expected");
            }
        }

        [TestMethod] //7
        public void MoreBorders( ) {
            bool result;
            try {
                result = isCorrectTriagle(4, (float)3.00009, 7);
                Assert.AreEqual(result, true);
            } catch (Exception e) {
                Assert.Fail("Exception not expected");
            }
        }

        [TestMethod] //8
        public void MuchMoreBorders( ) {
            bool result;
            try {
                result = isCorrectTriagle(11, 17, 23);
                Assert.AreEqual(result, true);
            } catch (Exception e) {
                Assert.Fail("Exception not expected");
            }
        }

        [TestMethod] //9
        public void MuchFewerBorders( ) {
            bool result;
            try {
                result = isCorrectTriagle(1, 17, 23);
                Assert.AreEqual(result, false);
            } catch (Exception e) {
                Assert.Fail("Exception not expected");
            }
        }

        [TestMethod] //10
        public void EquilateralTriangle( ) {
            bool result;
            try {
                result = isCorrectTriagle(14, 7, 14);
                Assert.AreEqual(result, true);
            } catch (Exception e) {
                Assert.Fail("Exception not expected");
            }
        }
    }
}
