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
            try
            {
                Excel.Application xlexcel;
                Excel.Worksheet xlWorkSheet;
                Excel.Worksheet xlWorkSheetLong;

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


                //Open second workbook to copy worksheet into orginal (two csv files can not be added to same worksheet)
                Excel.Workbook csvWorkbook = xlexcel.Workbooks.Open(longPath);
                Excel.Worksheet worksheetCSV = ((Excel.Worksheet)csvWorkbook.Worksheets[1]);

                worksheetCSV.Copy(xlWorkSheet);

                //Close workbook
                csvWorkbook.Close();

                xlWorkSheetLong = (Excel.Worksheet)xlWorkBooks[1].Sheets["100Hz"];
                xlWorkSheetLong.Shapes.AddChart(misValue, misValue, misValue, misValue, misValue).Select();
                xlexcel.ActiveChart.ApplyCustomType(Excel.XlChartType.xlLineMarkers);
                xlexcel.ActiveChart.SetSourceData(xlWorkSheetLong.Range["$B$1:$C$" + (longLength + 1)]);
            } catch (Exception e)
            {
                Console.WriteLine("Error Message:" + e.ToString());
            }
            
        }

    }
}
