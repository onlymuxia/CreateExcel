using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace Onlymuxia.ExcelOperation
{
    class TextHandler
    {
        public TextHandler(string file,string target)
        {
            this.file = file;
            this.target = target;
        }

        internal void execute()
        {
            try
            {
                ExcelCreator excelCreator = new ExcelCreator();
                //匹配每一行数据，如果格式不到，忽略
                //因为已经匹配格式，理论上String.Split不会出错。
                Regex regex = new Regex(@"^(\d{4})-(\d{1,2})-(\d{1,2})-(\d{1,2})-(\d{1,2})-(\d{1,2}):([a-z0-9]{2}(\s{1,})){49}[a-z0-9]{2}(\s{0,})$", RegexOptions.IgnoreCase);
                var lines = File.ReadAllLines(file);
                foreach (String line in lines)
                {
                    if (regex.IsMatch(line))
                    {
                        string[] sections = line.Split(new char[] { ':' });
                        string[] dates = sections[0].Split(new char[] { '-' });
                        string date = dates[0] + "/" + dates[1] + "/" + dates[2] + " " + dates[3] + ":" + dates[4] + ":" + dates[5];

                        string[] data = sections[1].Split(new char[] { ' ' });
                        int pm25 = DataUtil.toInt(data[2], data[3]);
                        int pm10 = DataUtil.toInt(data[4], data[5]);
                        int tsp = DataUtil.toInt(data[6], data[7]);
                        Double noise = DataUtil.toDouble(data[8], data[9], 10);
                        Double velocity = DataUtil.toDouble(data[10], data[11], 10);
                        int vane = DataUtil.toInt(data[12], data[13]);
                        Double temperature = DataUtil.toDouble(data[14], data[15], data[16], data[17], 100);
                        Double humidity = DataUtil.toDouble(data[18], data[19], 100);
                        Double barometric = DataUtil.toDouble(data[20], data[21], data[22], data[23], 1000);
                        excelCreator.Insert(date, pm25, pm10, tsp, noise, velocity, vane, temperature, humidity, barometric);
                    }
                }
                excelCreator.save(target);
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }

        public string file { get; set; }

        public string target { get; set; }
    }
}
