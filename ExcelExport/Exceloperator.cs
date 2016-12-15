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
                wb = hssfworkbook.CreateSheet("Sheet1");
                hssfworkbook.CreateSheet("Sheet2");
                hssfworkbook.CreateSheet("Sheet3");


                HSSFCellStyle style = (HSSFCellStyle)hssfworkbook.CreateCellStyle();
                //设置边框格式  
                style.Alignment = HorizontalAlignment.Center;
                IFont font = hssfworkbook.CreateFont();
                font.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
                style.SetFont(font);//HEAD 样式

                IRow row = wb.CreateRow(0);
                ICell cell = row.CreateCell(0);
                wb.SetColumnWidth(0, 20 * 256);
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

            IRow row = wb.CreateRow(Current);
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

        public ISheet wb { get; set; }

        public ICellStyle TextDataStyle(){
            IDataFormat dataformat = hssfworkbook.CreateDataFormat(); 
            ICellStyle style = hssfworkbook.CreateCellStyle();
            style.Alignment = HorizontalAlignment.Center;
            return style;
        }
        public ICellStyle TimeDataStyle()
        {
            IDataFormat dataformat = hssfworkbook.CreateDataFormat();
            ICellStyle style = hssfworkbook.CreateCellStyle();
            style.Alignment = HorizontalAlignment.Center;
            style.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Lime.Index;
            style.FillPattern = FillPattern.SolidForeground;
            return style;
        }
        public ICellStyle DigitDataStyle()
        {
            IDataFormat dataformat = hssfworkbook.CreateDataFormat();
            ICellStyle style = hssfworkbook.CreateCellStyle();
            style.Alignment = HorizontalAlignment.Center;
            style.DataFormat = dataformat.GetFormat("0.0"); //改变小数精度【小数点后有几个0表示精确到小数点后几位】 
            return style;
        }
        public ICellStyle HeadStyle()
        {
            IDataFormat dataformat = hssfworkbook.CreateDataFormat();
            ICellStyle style = hssfworkbook.CreateCellStyle();
            style.Alignment = HorizontalAlignment.Center;
            IFont font = hssfworkbook.CreateFont();
            font.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
            style.SetFont(font);//HEAD 样式
            style.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.DarkYellow.Index;
            style.FillPattern = FillPattern.SolidForeground;
            return style;
        }
    }
}
