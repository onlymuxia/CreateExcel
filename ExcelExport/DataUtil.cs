﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onlymuxia.ExcelOperation
{
    class DataUtil
    {
        internal static int toInt(string p_1, string p_2)
        {
            Int32 value = (Convert.ToInt32(p_1,16)<<8);
            value += Convert.ToInt32(p_2, 16);
            if (value == 65535)
            {
                return -1;
            }
            return value;
        }

        internal static Double toDouble(string p_1, string p_2, int divisor)
        {
            Int32 value = (Convert.ToInt32(p_1, 16) << 8);
            value += Convert.ToInt32(p_2, 16);
            if (value == 65535)
            {
                return Double.NaN;
            }
            return value/((double)divisor);
        }

        internal static double toDouble(string p_1, string p_2, string p_3, string p_4, int divisor)
        {
            if (p_1.Equals("FF", StringComparison.OrdinalIgnoreCase) && p_2.Equals("FF", StringComparison.OrdinalIgnoreCase) && p_3.Equals("FF", StringComparison.OrdinalIgnoreCase) && p_4.Equals("FF", StringComparison.OrdinalIgnoreCase))
            {
                return Double.NaN;
            }
            long value = (Convert.ToInt64(p_1, 16) << 24);
            value += (Convert.ToInt32(p_2, 16) << 16);
            value +=( Convert.ToInt32(p_3, 16)<< 8);
            value += Convert.ToInt32(p_4, 16);
            return value / ((double)divisor);
        }
    }
}
