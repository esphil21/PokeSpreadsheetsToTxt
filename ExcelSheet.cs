using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using OfficeOpenXml;


namespace PokeSpreadsheetsToTxt
{
    public class ExcelSheet
    {
        
        //string path = "";
        //_Application excel = new _Excel.Application();
        //Workbook wb;
        //Worksheet ws;

        //public ExcelSheet(string path, int sheetNum)
        //{
        //    this.path = path;
        //    wb = excel.Workbooks.Open(path);
        //    ws = (Worksheet)wb.Worksheets[sheetNum];
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="i"></param>
        ///// <param name="j"></param>
        ///// <returns></returns>
        //public string ReadCell(int i, int j) 
        //{
        //    i++; j++;
        //    if (ws.Cells[i, j] != null)
        //        return ws.Cells[i, j].ToString();
        //    else
        //        return "";
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="i"></param>
        ///// <param name="j"></param>
        ///// <param name="input"></param>
        ///// <param name="overwrite"></param>
        ///// <returns></returns>
        //public bool WriteCell(int i, int j, string input, bool overwrite = false)
        //{
        //    i++; j++;
        //    if (ws.Cells[i, j] != null)
        //    {
        //        if (overwrite)
        //        {
        //            ws.Cells[i, j] = input;
        //            return true;
        //        }
        //        return false;
        //    }
        //    else
        //    {
        //        ws.Cells[i, j] = input;
        //        return true;
        //    }
        //}

    }
}
