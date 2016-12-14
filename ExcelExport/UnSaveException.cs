using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onlymuxia.ExcelOperation
{
    class UnSaveException:Exception
    {
        public UnSaveException(Exception e) : base(e.Message) { }
        public UnSaveException(string s) : base(s) { }
    }
}
