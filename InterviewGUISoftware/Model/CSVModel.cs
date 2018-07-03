using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewGUISoftware.Model;
using System.IO;

namespace InterviewGUISoftware
{
    public class CSVModel
    {
        //Read data from CSV file then create a list of instance objects to hold it
        //CSV Data added to output folder so using relative path to reference
       public static List<CSVInstanceObject> populateInstanceObjects() {
            List<CSVInstanceObject> instanceObjectValues = File.ReadAllLines("Data\\Data.csv")
                .Skip(2)
                .Select(v => CSVInstanceObject.CSVToObject(v))
                .ToList();

            return instanceObjectValues;
        }
    }
}
