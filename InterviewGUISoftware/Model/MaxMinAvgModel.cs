using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewGUISoftware.Model
{
    class MaxMinAvgModel
    {
        //vars to store the max min and avg for test results
        string test;
        decimal max;
        decimal min;
        decimal avg;

        public static MaxMinAvgModel maxMinAvgObject(string valueTest, decimal valueMax, decimal valueMin,
            decimal valueAvg)
        {
            //store values into model to load into datagrid
            MaxMinAvgModel maxMinAvgObject = new MaxMinAvgModel();
            maxMinAvgObject.test = valueTest;
            maxMinAvgObject.max = valueMax;
            maxMinAvgObject.min = valueMin;
            maxMinAvgObject.avg = valueAvg;

            return maxMinAvgObject;
        }

    }
}
