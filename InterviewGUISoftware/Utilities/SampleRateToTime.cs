﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewGUISoftware.Utilities
{
    public class SampleRateToTime
    {
        //Pass in sample rate and convert to ms
        public static int convertSampleRateToTime(int index, int timeConversion)
        {
            return index *= timeConversion;
        }
    }
}
