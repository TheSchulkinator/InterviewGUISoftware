using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewGUISoftware.Model;

namespace InterviewGUISoftware.Utilities
{
    class SampleRateConverter
    {
        public static List<CSVInstanceObject> ConvertSampleRate(List<CSVInstanceObject> csvList)
        {
            return csvList.Where((x, i) => i % 10 == 0).ToList();
        }
    }
}
