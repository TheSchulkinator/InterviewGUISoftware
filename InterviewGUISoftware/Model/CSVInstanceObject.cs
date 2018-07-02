using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewGUISoftware.Model
{
    class CSVInstanceObject
    {
        //Create a class that will map the CSV file into objects

        // vars that map to CSV 
        int index;
        decimal uKL30V;
        decimal EPB_L;
        decimal EPB_R;
        decimal AIN2_MON_VAC_SUP;
        decimal AIN3;
        decimal AIN4;
        decimal AIN5;


        //Map string to objects
        public static CSVInstanceObject CSVToObject(string currentLine)
        {
            //Split csv string into string array
            string[] values = currentLine.Split(';');
            CSVInstanceObject instanceObject = new CSVInstanceObject();
            instanceObject.index = Convert.ToInt32(values[0]);
            instanceObject.uKL30V = Convert.ToDecimal(values[1]);
            instanceObject.EPB_L = Convert.ToDecimal(values[2]);
            instanceObject.EPB_R = Convert.ToDecimal(values[3]);
            instanceObject.AIN2_MON_VAC_SUP = Convert.ToDecimal(values[4]);
            instanceObject.AIN3 = Convert.ToDecimal(values[5]);
            instanceObject.AIN4 = Convert.ToDecimal(values[6]);
            instanceObject.AIN5 = Convert.ToDecimal(values[7]);

            return instanceObject;
        }
    }
}
