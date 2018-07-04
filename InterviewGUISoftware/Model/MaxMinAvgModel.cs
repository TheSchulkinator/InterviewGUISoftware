using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewGUISoftware.Model
{
    public class MaxMinAvgModel
    {
        //vars to store the max min and avg for test results
       
        public string Test { get; set; }
        public decimal Max { get; set; }
        public decimal Min { get; set; }
        public decimal Avg { get; set; }

        public static MaxMinAvgModel maxMinAvgObject(string valueTest, decimal valueMax, decimal valueMin,
            decimal valueAvg)
        {
            //store values into model to load into datagrid
            MaxMinAvgModel maxMinAvgObject = new MaxMinAvgModel();
            maxMinAvgObject.Test = valueTest;
            maxMinAvgObject.Max = valueMax;
            maxMinAvgObject.Min = valueMin;
            maxMinAvgObject.Avg = valueAvg;

            return maxMinAvgObject;
        }

    }
}
