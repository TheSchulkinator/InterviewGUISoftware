using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewGUISoftware.Model;
using InterviewGUISoftware.Utilities;
using Prism.Commands;
using System.Windows.Input;
using System.IO;
using System.Reflection;

namespace InterviewGUISoftware.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        //getter setter private methods
        private string tMinValueString;
        private string tMaxValueString;
        private List<MaxMinAvgModel> maxMinAvgList;
        private string errorText;

        //int for converted strings
        int tMinValue;
        int tMaxValue;

        //event to notify UI of change
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        //int to store the current max
        private int tMax = TimeFilter.testObjects.Count * 10 - 10;

        //set the max and min time for the filter
        public string TestMaxHintString
        {
            get { return "Tmax(ms): " + tMax.ToString(); }
            set { }  
        } 
        public string TestMinHintString
        {
            get { return "Tmin(ms): 0"; }
            set { }
        }

        //get text from textbox on submit 
        public string TMinValueString
        {
            get { return tMinValueString; }
            set
            {
                tMinValueString = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(TMinValueString)));
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(SubmitButtonCommand)));
            }
        }

        public string TMaxValueString
        {
            get { return tMaxValueString; }
            set
            {
                tMaxValueString = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(TMaxValueString)));
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(SubmitButtonCommand)));
            }
        }

        //Bind Datagrid 
        public List<MaxMinAvgModel> MinMaxAvgModelData
        {
            get { return maxMinAvgList; }
            set { }
        }

        //Text to display if error occured in time submission
        public string ErrorText
        {
            get { return errorText; }
            set {
                errorText = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(ErrorText)));
            }
        }

        //Text to prompt user to enter valid Range
        public string PromptText
        {
            get { return "Please enter a valid time range between Tmin and Tmax, time interval is 10ms between points"; ; }
            set {}
        }

        //Add click command and validation 
        public ICommand SubmitButtonCommand
        {
            get { return new DelegateCommand<object>(FuncToCall, FuncToEvaluate); }
        }

        private void FuncToCall(object context)
        {
            maxMinAvgList = TimeFilter.filterForTime(tMaxValue, tMinValue);
            PropertyChanged(this, new PropertyChangedEventArgs(nameof(MinMaxAvgModelData)));
        }

        private bool FuncToEvaluate(object context)
        {

            //attempt to convert string to int or propmt user    
            int checkTmax;
            int checkTmin;

            bool isTmax = Int32.TryParse(tMaxValueString, out checkTmax);
            bool isTmin = Int32.TryParse(tMinValueString, out checkTmin);

            if (tMaxValueString == null  || tMinValueString == null)
            {
                return false;
            }

            if (!isTmax  && !isTmin)
            {
                ErrorText = "Please enter a valid number between Tmin and Tmax";
                return false;

            } else {
                tMaxValue = checkTmax;
                tMinValue = checkTmin;
            }
        

            if (tMinValue >= 0 && tMaxValue <= tMax && tMinValue <= tMaxValue)
            {
                ErrorText = "";
                return true;
            }
            else if (!(tMinValue >= 0))
            {
                ErrorText = "Please enter a minimum value greater than or equal to 0";
            }
            else if (!(tMaxValue <= tMax))
            {
                ErrorText = "Please enter a maximum value less than or equal to Tmax";
            }
            else if (!(tMinValue <= tMaxValue))
            {
                ErrorText = "Please enter a value of Tmin that is less than or equal to Tmax";
            }
            return false;
        }

        //Export button click handler
        public ICommand ExportLowButtonCommand
        {
            get { return new DelegateCommand<object>(ExportLowFuncToCall, ExportLowFuncToEvaluate); }
        }

        private void ExportLowFuncToCall(object context)
        {
            //Open file save dialog and save csv file
            Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.Filter = "CSV|*.csv";

            if (dialog.ShowDialog() == true)
            {
                List<CSVInstanceObject> testObjects = CSVModel.populateInstanceObjects();
                List<CSVInstanceObject> reducedSampleRateObjects = SampleRateConverter.ConvertSampleRate(testObjects);
                var csv = CreateCSVFromList.CreateCSV(reducedSampleRateObjects);
                File.WriteAllText(dialog.FileName, csv.ToString());
            }
          
        }

        private bool ExportLowFuncToEvaluate(object context)
        {
            return true;
        }

        //Export button click handler
        public ICommand ExportHighButtonCommand
        {
            get { return new DelegateCommand<object>(ExportHighFuncToCall, ExportHighFuncToEvaluate); }
        }

        private void ExportHighFuncToCall(object context)
        {
            //Open file save dialog and save csv file
            Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.Filter = "CSV|*.csv";

            if (dialog.ShowDialog() == true)
            {
                List<CSVInstanceObject> testObjects = CSVModel.populateInstanceObjects();
                var longCsv = CreateCSVFromList.CreateCSV(testObjects);
                File.WriteAllText(dialog.FileName, longCsv.ToString());
            }

        }

        private bool ExportHighFuncToEvaluate(object context)
        {
            return true;
        }

        //Export button click handler
        public ICommand ExportGraphButtonCommand
        {
            get { return new DelegateCommand<object>(ExportGraphFuncToCall, ExportGraphFuncToEvaluate); }
        }

        private void ExportGraphFuncToCall(object context)
        {
            //write CSV files locally in order to export them to excell
            string fullFilepath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\\100Hz.csv");
            string sampledFilepath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\\10Hz.csv");

            List<CSVInstanceObject> testObjects = CSVModel.populateInstanceObjects();
            var csvFull = CreateCSVFromList.CreateCSV(testObjects);
            File.WriteAllText(fullFilepath, csvFull.ToString());


            List<CSVInstanceObject> reducedSampleRateObjects = SampleRateConverter.ConvertSampleRate(testObjects);
            var shortCsv = CreateCSVFromList.CreateCSV(reducedSampleRateObjects);
            File.WriteAllText(sampledFilepath, shortCsv.ToString());

            AddExcelGraph.exportGraph(sampledFilepath, fullFilepath, reducedSampleRateObjects.Count, testObjects.Count);

        }

        private bool ExportGraphFuncToEvaluate(object context)
        {
            return true;
        }

    }
}
