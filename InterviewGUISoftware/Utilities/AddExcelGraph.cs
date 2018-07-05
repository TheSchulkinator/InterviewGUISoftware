using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace InterviewGUISoftware.Utilities
{
    class AddExcelGraph
    {
        //Use office interop to create an excel spreadsheet with a basic graph
        public static void exportGraph(string shortPath, string longPath, int shortLength, int longLength)
        {
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;

            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Excel.Application();
            var xlWorkBooks = xlexcel.Workbooks;
            xlexcel.Visible = true;


            xlWorkBooks.OpenText(shortPath, misValue, misValue, Excel.XlTextParsingType.xlDelimited,
                                 Excel.XlTextQualifier.xlTextQualifierNone, misValue, misValue,
                                 misValue, misValue, misValue, misValue, misValue, misValue, misValue,
                                 misValue, misValue, misValue, misValue);

            xlWorkSheet = (Excel.Worksheet)xlWorkBooks[1].Worksheets.get_Item(1);
            xlWorkSheet.Shapes.AddChart(misValue, misValue, misValue, misValue, misValue).Select();
            xlexcel.ActiveChart.ApplyCustomType(Excel.XlChartType.xlLineMarkers);
            xlexcel.ActiveChart.SetSourceData(xlWorkSheet.Range["$B$1:$C$" + (shortLength + 1)]);

            Excel.Worksheet newWorksheet;
            newWorksheet = (Excel.Worksheet)xlWorkBooks[1].Worksheets.Add();

            //Open second workbook to copy worksheet into orginal (two csv files can not be added to same worksheet)
            var xlApp = new Excel.Application { Visible = false };
            Excel.Workbook csvWorkbook = xlApp.Workbooks.Open(longPath);
            Excel.Worksheet worksheetCSV = ((Excel.Worksheet)csvWorkbook.Worksheets[1]);
            worksheetCSV.Copy(worksheetCSV);

            newWorksheet.Paste();

        }

    }
}
