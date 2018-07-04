using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewGUISoftware.Model;

namespace InterviewGUISoftware.Utilities
{
    class CreateCSVFromList
    {
        public static dynamic CreateCSV(List<CSVInstanceObject> list)
        {
            var csv = new StringBuilder();

            //Add header string first before adding all values
            var time = "Time(ms)";
            var EPBL = "EPB_L";
            var EPBR = "EPB_R";
            var line = string.Format("{0},{1},{2}", time, EPBL, EPBR);
            csv.AppendLine(line);

            for (int i = 0; i < list.Count ; i++)
            {
                //convert sample rate index to time before adding to list
                int convertedTime = SampleRateToTime.convertSampleRateToTime(list[i].index, 10);

                time = convertedTime.ToString();
                EPBL = list[i].EPB_L.ToString();
                EPBR = list[i].EPB_R.ToString();
                line = string.Format("{0},{1},{2}", time, EPBL, EPBR);
                csv.AppendLine(line);
            }

            return csv;
        } 
    }
}
