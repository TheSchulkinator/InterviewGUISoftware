using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewGUISoftware.Model;

namespace InterviewGUISoftware.Utilities
{
    public class SampleRateConverter
    {
        //Reduce the sample rate of the file from 100hz to 10 hz
        public static List<CSVInstanceObject> ConvertSampleRate(List<CSVInstanceObject> csvList)
        {
            return csvList.Where((x, i) => i % 10 == 0).ToList();
        }
    }
}
