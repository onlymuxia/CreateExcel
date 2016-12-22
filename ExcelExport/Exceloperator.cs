using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using NPOI.HSSF.Util;

namespace Onlymuxia.ExcelOperation
{
    class ExcelCreator
    {
        public ExcelCreator()  
        {
            try
            {
                hssfworkbook = new HSSFWorkbook();
                currentSheet = hssfworkbook.CreateSheet("Sheet1");
                hssfworkbook.CreateSheet("Sheet2");
                hssfworkbook.CreateSheet("Sheet3");

                IRow row = currentSheet.CreateRow(0);
                ICell cell = row.CreateCell(0);
                currentSheet.SetColumnWidth(0, 20 * 256);
                cell.SetCellValue("时间");
                cell.CellStyle = HeadStyle(); 
                //cell.CellStyle = Getcellstyle(wb, stylexls.头);
                
                cell = row.CreateCell(1);
                cell.SetCellValue("PM2.5");
                cell.CellStyle = HeadStyle();

                cell = row.CreateCell(2);
                cell.SetCellValue("PM10");
                cell.CellStyle = HeadStyle();

                cell = row.CreateCell(3);
                cell.SetCellValue("TSP");
                cell.CellStyle = HeadStyle();

                cell = row.CreateCell(4);
                cell.SetCellValue("风速");
                cell.CellStyle = HeadStyle();

                cell = row.CreateCell(5);
                cell.SetCellValue("风速");
                cell.CellStyle = HeadStyle();

                cell = row.CreateCell(6);
                cell.SetCellValue("风向");
                cell.CellStyle = HeadStyle();

                cell = row.CreateCell(7);
                cell.SetCellValue("温度");
                cell.CellStyle = HeadStyle();

                cell = row.CreateCell(8);
                cell.SetCellValue("湿度");
                cell.CellStyle = HeadStyle();

               // wb.SetColumnWidth(9, 15 * 256);
                cell = row.CreateCell(9);
                cell.SetCellValue("大气压");
                cell.CellStyle = HeadStyle();
                Current = 0;


            }
            catch (Exception e)
            {
                 throw e;
            }
        }

        internal void save(string p)
        {
            if (Current == 0)
            {
                throw new UnSaveException("没有数据");
            }
            else
            {
                FileStream Streamfile = new FileStream(p, FileMode.Create);
                hssfworkbook.Write(Streamfile);
                Streamfile.Close();
            }
           
           
        }

        public int Current { get; set; }

        internal void Insert(string date, int pm25, int pm10, int tsp, double noise, double velocity, int vane, double temperature, double humidity, double barometric)
        {
            Current++;

            IRow row = currentSheet.CreateRow(Current);
            ICell cell = row.CreateCell(0);
            cell.SetCellValue(date);
            cell.CellStyle = TimeDataStyle();

            cell = row.CreateCell(1);
            cell.SetCellValue(pm25);
            cell.CellStyle = TextDataStyle();

            cell = row.CreateCell(2);
            cell.SetCellValue(pm10);
            cell.CellStyle = TextDataStyle();

            cell = row.CreateCell(3);
            cell.SetCellValue(tsp);
            cell.CellStyle = TextDataStyle();

            cell = row.CreateCell(4);
            cell.SetCellValue(noise);
            cell.CellStyle = DigitDataStyle();

            cell = row.CreateCell(5);
            cell.SetCellValue(velocity);
            cell.CellStyle = DigitDataStyle();

            cell = row.CreateCell(6);
            cell.SetCellValue(vanes[vane]);
            cell.CellStyle = TextDataStyle();

            cell = row.CreateCell(7);
            cell.SetCellValue(temperature);
            cell.CellStyle = DigitDataStyle();

            cell = row.CreateCell(8);
            cell.SetCellValue(humidity);
            cell.CellStyle = DigitDataStyle();

            cell = row.CreateCell(9);
            cell.SetCellValue(barometric);
            cell.CellStyle = DigitDataStyle(); 
        }

        private Dictionary<int, string> vanes = new Dictionary<int, string>() { { 0, "东北偏北" }, { 1, "东北" }, { 2, "东北偏东" }, { 3, "正东" }, { 4, "东南偏东" }, { 5, "东南" }, { 6, "东南偏南" }, { 7, "正南" }, { 8, "西南偏南" }, { 9, "西南" }, { 10, "西南偏西" }, { 11, "正西" }, { 12, "西北偏西" }, { 13, "西北" }, { 14, "西北偏北" }, { 15, "正北" } };

        public HSSFWorkbook hssfworkbook { get; set; }

        public ISheet currentSheet { get; set; }

        private ICellStyle textDataStyle;
        private ICellStyle timeDataStyle;
        private ICellStyle digitDataStyle;

        private ICellStyle headStyle;
        public ICellStyle TextDataStyle(){
            if (textDataStyle == null)
            {
                IDataFormat dataformat = hssfworkbook.CreateDataFormat();
                textDataStyle = hssfworkbook.CreateCellStyle();
                textDataStyle.Alignment = HorizontalAlignment.Center;
            }
            return textDataStyle;
        }
        public ICellStyle TimeDataStyle()
        {
            if (timeDataStyle == null)
            {
                IDataFormat dataformat = hssfworkbook.CreateDataFormat();
                timeDataStyle = hssfworkbook.CreateCellStyle();
                timeDataStyle.Alignment = HorizontalAlignment.Center;
                timeDataStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Lime.Index;
                timeDataStyle.FillPattern = FillPattern.SolidForeground;
                HSSFPalette palette = hssfworkbook.GetCustomPalette();  //wb HSSFWorkbook对象
                palette.SetColorAtIndex((short)61, (byte)(32), (byte)(218), (byte)(80));
                timeDataStyle.FillForegroundColor = (short)61;

            }
            return timeDataStyle;
        }
        public ICellStyle DigitDataStyle()
        {
            if (digitDataStyle == null)
            {
                IDataFormat dataformat = hssfworkbook.CreateDataFormat();
                digitDataStyle = hssfworkbook.CreateCellStyle();
                digitDataStyle.Alignment = HorizontalAlignment.Center;
                digitDataStyle.DataFormat = dataformat.GetFormat("0.0"); //改变小数精度【小数点后有几个0表示精确到小数点后几位】 
            }
            return digitDataStyle;
        }
        public ICellStyle HeadStyle()
        {
            if (headStyle == null)
            {
                IDataFormat dataformat = hssfworkbook.CreateDataFormat();
                headStyle = hssfworkbook.CreateCellStyle();
                headStyle.Alignment = HorizontalAlignment.Center;

                IFont font = hssfworkbook.CreateFont();
                font.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
                headStyle.SetFont(font);//HEAD 样式

                HSSFPalette palette = hssfworkbook.GetCustomPalette();  //wb HSSFWorkbook对象
                palette.SetColorAtIndex((short)60, (byte)(6), (byte)(238), (byte)(66));
                headStyle.FillForegroundColor = (short)60;

                headStyle.FillPattern = FillPattern.SolidForeground;
            }
            return headStyle;
        }
    }
}
