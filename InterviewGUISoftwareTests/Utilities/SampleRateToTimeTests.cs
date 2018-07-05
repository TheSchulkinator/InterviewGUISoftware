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
    public class SampleRateToTimeTests
    {
        [TestMethod()]
        public void convertSampleRateToTimeTest()
        {
            int testIndex = 20;
            int testTimeConversion = 10;
            int expected = 200;

            int actual = SampleRateToTime.convertSampleRateToTime(testIndex, testTimeConversion);
            Assert.AreEqual(expected, actual);
        }
    }
}