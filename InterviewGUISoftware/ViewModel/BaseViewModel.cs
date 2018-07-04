using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewGUISoftware.Model;
using Prism.Commands;
using System.Windows.Input;
using InterviewGUISoftware.Model;

namespace InterviewGUISoftware.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private int tMinValue;
        private int tMaxValue;
        private int tMax = TimeFilter.testObjects.Count;
        private List<MaxMinAvgModel> maxMinAvgList;
        private string errorText;

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        //set the max and min time for the filter
        public string TestMaxHintString
        {
            get { return "Tmax: " + TimeFilter.testObjects.Count.ToString(); }
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
            } else if (!(tMinValue >= 0))
            {
                ErrorText = "Please enter a minimum value greater than or equal to 0";
            } else if (!(tMaxValue <= tMax))
            {
                ErrorText = "Please enter a maximum value less than or equal to Tmax";
            } else if(!(tMinValue <= tMaxValue))
            {
                ErrorText = "Please enter a value of Tmin that is less than or equal to Tmax";
            }
            return false;
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
    }
}
