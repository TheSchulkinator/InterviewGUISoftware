using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewGUISoftware.Utilities
{
    class SampleRateToTime
    {
        public static int convertSampleRateToTime(int index, int timeConversion)
        {
            return index *= timeConversion;
        }
    }
}
