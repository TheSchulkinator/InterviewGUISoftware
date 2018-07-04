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
        private int tMinValue;
        private int tMaxValue;
        private int tMax = TimeFilter.testObjects.Count - 1;
        private List<MaxMinAvgModel> maxMinAvgList;
        private string errorText;
        private string promptText;

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        //set the max and min time for the filter
        public string TestMaxHintString
        {
            get { return "Tmax: " + tMax.ToString(); }
            set { }  
        } 
        public string TestMinHintString
        {
            get { return "Tmin: 0"; }
            set { }
        }

        //get text from textbox on submit 
        public int TMinValue
        {
            get { return tMinValue; }
            set
            {
                tMinValue = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(TMinValue)));
            }
        }

        public int TMaxValue
        {
            get { return tMaxValue; }
            set
            {
                tMaxValue = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(TMaxValue)));
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
            get { return promptText; }
            set {
                promptText = "Please enter a valid time range between Tmin and Tmax";
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(PromptText)));
            }
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
                var csv = CreateCSVFromList.CreateCSV(testObjects);
                File.WriteAllText(dialog.FileName, csv.ToString());
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
            string filepath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\Names.txt");

            List<CSVInstanceObject> testObjects = CSVModel.populateInstanceObjects();
            var csvFull = CreateCSVFromList.CreateCSV(testObjects);
            File.WriteAllText(filepath, csvFull.ToString());

        }

        private bool ExportGraphFuncToEvaluate(object context)
        {
            return true;
        }

    }
}
