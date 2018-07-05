using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterviewGUISoftware.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewGUISoftware.Utilities.Tests
{
    [TestClass()]
    public class RoundTimeTests
    {
        [TestMethod()]
        public void RoundToNearestTenTest()
        {
            int number = 12;
            int numberTwo = 15;
            int numberThree = 29;

            int expected = 10;
            int expectedTwo = 20;
            int expectedThree = 30;

           int actual = RoundTime.RoundToNearestTen(number);
           int actualTwo = RoundTime.RoundToNearestTen(numberTwo);
           int actualThree = RoundTime.RoundToNearestTen(numberThree);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedTwo, actualTwo);
            Assert.AreEqual(expectedThree, actualThree);
        }
    }
}