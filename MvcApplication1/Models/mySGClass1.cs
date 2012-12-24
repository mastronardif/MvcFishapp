﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace MvcApplication1.Models
{
    public class mySGClass1
    {
        string _F8  = string.Empty;
        string _F9  = string.Empty;
        string _F10 = string.Empty;

        private string sheetPrinterFriendl(SpreadsheetGear.IWorksheet ws)
        {
            string info = string.Empty;

            //double value; // = ws.Cells["$F88"].Value; //12345.6789;
            //double.TryParse(ws.Cells["$F88"].Value.ToString(), out value);
            //Console.WriteLine(value.ToString("C", CultureInfo.CurrentCulture));
            //Console.WriteLine(value.ToString("C3", CultureInfo.CreateSpecificCulture("nl-NL")));


            //ws.UsedRange;
            int rows = ws.UsedRange.Cells.Cells.RowCount;
            long cols = ws.UsedRange.Cells.Cells.CellCount;

            //info = ws.Cells[0,0].Value.ToString();

            info += "<hr/>";
            info += ws.Cells["$F87"].Value; info += "&nbsp;";
            info += ws.Cells["$G87"].Value; info += "&nbsp;";
            info += ws.Cells["$H87"].Value; info += "<br/>";

            info += ws.Cells["$D88"].Value; info += "<br/>";
            //info += ws.Cells["$F88"].Value;        info += "<br/>";
            //info += string.Format("{0:c}", ws.Cells["$F88"].Value); info += "<br/>";
            //info += string.Format("{0,30:C}", ws.Cells["$F88"].Value); info += "<br/>";

            info += string.Format("{0,30:C0}", ws.Cells["$F88"].Value); info += "<br/>";

            //info += ws.Cells["$G88"].Value;        info += "<br/>";
            info += string.Format("{0,30:C0}", ws.Cells["$G88"].Value); info += "<br/>";
            //info += ws.Cells["$H88"].Value;        info += "<br/>";

            //System.Globalization.CultureInfo  nfi = new System.Globalization.CultureInfo("nl-NL");
            System.Globalization.CultureInfo nfi = new System.Globalization.CultureInfo("en-US");

            info += string.Format(nfi,
                                  "{0,30:C0}", ws.Cells["$H88"].Value); info += "<br/>";

            //Response.Write(info);
            return info;

        }

        private string sheetPrinterFriend22(SpreadsheetGear.IWorksheet ws)
        {
            //ws.UsedRange;
            int rows = ws.UsedRange.Cells.Cells.RowCount;
            long cols = ws.UsedRange.Cells.Cells.CellCount;
            StringBuilder sb = new StringBuilder();

            //info = ws.Cells[0,0].Value.ToString();
            sb.Append("<table style=\"width:420px;\">\n");
            sb.Append("<CAPTION style=\"background-color:Aqua; color:Black\">\n"+ws.Name+"</CAPTION>\n");
            sb.Append("<tr>");
            sb.Append("<td> <i>Results</i>"); sb.Append("</td>");
            sb.Append("<td>");
            sb.Append( ws.Cells["$F87"].Value);
            sb.Append("</td>");
            sb.Append("<td>");
             sb.Append( ws.Cells["$G87"].Value);
            sb.Append("</td>");
            sb.Append("<td>");
             sb.Append( ws.Cells["$H87"].Value);
            sb.Append("</td>");
            sb.Append("</tr>");

            sb.Append("<tr>");
            sb.Append("<td>");
            sb.Append(ws.Cells["$D88"].Value);
            sb.Append("</td>");
            //info += ws.Cells["$F88"].Value;        info += "<br/>";
            //info += string.Format("{0:c}", ws.Cells["$F88"].Value); info += "<br/>";
            //info += string.Format("{0,30:C}", ws.Cells["$F88"].Value); info += "<br/>";
            sb.Append("<td>");
            sb.Append( string.Format("{0,30:C0}", ws.Cells["$F88"].Value));
            sb.Append("</td>");

            //info += ws.Cells["$G88"].Value;        info += "<br/>";
            sb.Append("<td>");
            sb.Append( string.Format("{0,30:C0}", ws.Cells["$G88"].Value));
            sb.Append("</td>");
            //info += ws.Cells["$H88"].Value;        info += "<br/>";

            //System.Globalization.CultureInfo  nfi = new System.Globalization.CultureInfo("nl-NL");
            System.Globalization.CultureInfo nfi = new System.Globalization.CultureInfo("en-US");
            sb.Append("<td>");
            sb.Append( string.Format(nfi,
                                  "{0,30:C0}", ws.Cells["$H88"].Value));
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("\n</table>\n");

            return sb.ToString();
        }

        public string getInput()
        {
            string inputHTML = 
            string.Format("Fish released in week nr [F8]: "+
                          "<input type=\"text\" name=\"F8\" value=\"{0}\" maxlength=\"10\" size=\"10\"/>",
                           _F8);
            return inputHTML;
        }

        public string MyGetResults(string F8_value, string F9_value, string F10_value)
        {
            try
            {
                int iResults;
                if (!Int32.TryParse(F8_value, out iResults))
                {
                    return "Log Bad input.";
                }

                _F8 = F8_value;
                int iF8_value = iResults;



                if (!Int32.TryParse(F9_value, out iResults))
                {
                    return "Log Bad input.";
                }
                _F9 = F9_value;
                int iF9_value = iResults;

                if (!Int32.TryParse(F10_value, out iResults))
                {
                    return "Log Bad input.";
                }
                _F10 = F10_value;
                int iF10_value = iResults;

                SpreadsheetGear.IWorkbookSet workbookSet = SpreadsheetGear.Factory.GetWorkbookSet();
                SpreadsheetGear.IWorkbook workbook = workbookSet.Workbooks.Add();

                workbook = workbookSet.Workbooks.Open(@"C:\FxM\downloads\01RFishheads.xls");

                int icnt = workbook.Worksheets.Count;
                icnt = (((workbook.ActiveSheet).Workbook).Sheets).Count;

                //int iRow, iCol, iMaxRow;
                //iCol = 3; //D
                //int iF = 5;
                //iMaxRow = 110;
                string info = string.Empty;

                workbook.Worksheets[0].Cells["$F8"].Value  = iF8_value;
                workbook.Worksheets[0].Cells["$F9"].Value  = iF9_value;
                workbook.Worksheets[0].Cells["$F10"].Value = iF10_value;

                //for (iRow = 1; iRow < iMaxRow; iRow++)
                //{
                //    info += string.Format("[{0}, {1}] ", iRow + 1, iCol);
                //    info += workbook.Worksheets[0].Cells[iRow, iCol].Value;

                //    info += "&nbsp;&nbsp;&nbsp;";
                //    info += workbook.Worksheets[0].Cells[iRow, iF].Value;

                //    info += "\n<br/>";
                //}

                //workbook.Worksheets.WorkbookSet.Workbooks.
                //Response.Write(info);
                //return info;

                string sr = sheetPrinterFriend22(workbook.Worksheets["Printer friendly"]);
                return sr;

                //string sss = workbook.Worksheets["Sheet1"].Cells["A1"].Value.ToString();
                //string sss = workbook.Worksheets["Sheet1"].Cells["A1"].Value.ToString();
                //Response.Write(sss);
            }
            catch (Exception eee)
            {
                string msg = eee.Message;
                return (eee.Message);
            }

            //return "wtf";

        }


        public string MyOpenSheet()
        {
            try
            {
                SpreadsheetGear.IWorkbookSet workbookSet = SpreadsheetGear.Factory.GetWorkbookSet();
                SpreadsheetGear.IWorkbook workbook = workbookSet.Workbooks.Add();

                workbook = workbookSet.Workbooks.Open(@"C:\FxM\downloads\01RFishheads.xls");

                int icnt = workbook.Worksheets.Count;
                icnt = (((workbook.ActiveSheet).Workbook).Sheets).Count;

                int iRow, iCol, iMaxRow;
                iCol = 3; //D
                int iF = 5;
                iMaxRow = 110;
                string info = string.Empty;

                workbook.Worksheets[0].Cells["$F8"].Value = 15;

                for (iRow = 1; iRow < iMaxRow; iRow++)
                {
                    info += string.Format("[{0}, {1}] ", iRow + 1, iCol);
                    info += workbook.Worksheets[0].Cells[iRow, iCol].Value;

                    info += "&nbsp;&nbsp;&nbsp;";
                    info += workbook.Worksheets[0].Cells[iRow, iF].Value;

                    info += "\n<br/>";
                }

                //workbook.Worksheets.WorkbookSet.Workbooks.
                //Response.Write(info);
                return info;

                //sheetPrinterFriendl(workbook.Worksheets["Printer friendly"]);

                //string sss = workbook.Worksheets["Sheet1"].Cells["A1"].Value.ToString();
                //string sss = workbook.Worksheets["Sheet1"].Cells["A1"].Value.ToString();
                //Response.Write(sss);
            }
            catch (Exception eee)
            {
                string msg = eee.Message;
                return (eee.Message);
            }

            //return "wtf";

        }
    
    }
}

/*******************
Date: 12/12/12
 * my notes.
 * 
 * 
 * 


**************************/