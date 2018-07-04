using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewGUISoftware.Model;

namespace InterviewGUISoftware.Utilities
{
    public class TimeFilter
    {
        public static List<CSVInstanceObject> testObjects = CSVModel.populateInstanceObjects();
        public static List<CSVInstanceObject> filteredTestObjects;

        public static List<MaxMinAvgModel> filterForTime(int timeMax, int timeMin)
        {
            List<MaxMinAvgModel> maxMinAvgList = new List<MaxMinAvgModel>();
            MaxMinAvgModel singleModel;

            //find the difference between min and max in order to select range
            int tDifference = timeMax - timeMin + 1;
            filteredTestObjects = testObjects.GetRange(timeMin, tDifference);

            //populate the maxminavg list
            for (int i = 0; i <= 6; i++)
            {
                singleModel = findMaxMinAvg(i);
                maxMinAvgList.Add(singleModel);
            }

            return maxMinAvgList;
        } 

        static MaxMinAvgModel findMaxMinAvg(int selection)
        {
            decimal max = 0;
            decimal min = 0;
            decimal avg = 0;
            string test = "";

            //loop through the test and find the values needed for specific test.
            //use switch to find values for each test case
            switch (selection)
            {
                case 0:
                    test = "uKL30V";
                    max = filteredTestObjects.Max(CSVInstanceObject => CSVInstanceObject.uKL30V);
                    min = filteredTestObjects.Min(CSVInstanceObject => CSVInstanceObject.uKL30V);
                    avg = filteredTestObjects.Average(CSVInstanceObject => CSVInstanceObject.uKL30V);
                    break;
                case 1:
                    test = "EPB_L";
                    max = filteredTestObjects.Max(CSVInstanceObject => CSVInstanceObject.EPB_L);
                    min = filteredTestObjects.Min(CSVInstanceObject => CSVInstanceObject.EPB_L);
                    avg = filteredTestObjects.Average(CSVInstanceObject => CSVInstanceObject.EPB_L);
                    break;
                case 2:
                    test = "EPB_R";
                    max = filteredTestObjects.Max(CSVInstanceObject => CSVInstanceObject.EPB_R);
                    min = filteredTestObjects.Min(CSVInstanceObject => CSVInstanceObject.EPB_R);
                    avg = filteredTestObjects.Average(CSVInstanceObject => CSVInstanceObject.EPB_R);
                    break;
                case 3:
                    test = "AIN2_MON_VAC_SUP";
                    max = filteredTestObjects.Max(CSVInstanceObject => CSVInstanceObject.AIN2_MON_VAC_SUP);
                    min = filteredTestObjects.Min(CSVInstanceObject => CSVInstanceObject.AIN2_MON_VAC_SUP);
                    avg = filteredTestObjects.Average(CSVInstanceObject => CSVInstanceObject.AIN2_MON_VAC_SUP);
                    break;
                case 4:
                    test = "AIN3";
                    max = filteredTestObjects.Max(CSVInstanceObject => CSVInstanceObject.AIN3);
                    min = filteredTestObjects.Min(CSVInstanceObject => CSVInstanceObject.AIN3);
                    avg = filteredTestObjects.Average(CSVInstanceObject => CSVInstanceObject.AIN3);
                    break;
                case 5:
                    test = "AIN4";
                    max = filteredTestObjects.Max(CSVInstanceObject => CSVInstanceObject.AIN4);
                    min = filteredTestObjects.Min(CSVInstanceObject => CSVInstanceObject.AIN4);
                    avg = filteredTestObjects.Average(CSVInstanceObject => CSVInstanceObject.AIN4);
                    break;
                case 6:
                    test = "AIN5";
                    max = filteredTestObjects.Max(CSVInstanceObject => CSVInstanceObject.AIN5);
                    min = filteredTestObjects.Min(CSVInstanceObject => CSVInstanceObject.AIN5);
                    avg = filteredTestObjects.Average(CSVInstanceObject => CSVInstanceObject.AIN5);
                    break;
                default:
                    break;
            }

            MaxMinAvgModel maxMinAvg = MaxMinAvgModel.maxMinAvgObject(test, max, min, avg);
            return maxMinAvg;
        }
    }
}
