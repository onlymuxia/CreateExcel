using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace ExcelExport
{
    public enum InputType
    {
        String,  //字符串  
        Number,  //数字  
        Regex,   //自定义正则表达式  
    }

    public partial class LimitTextBox : TextBox
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg,
            int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        private string regexValue = string.Empty;
        /// <summary>  
        /// 输入值须符合的正则表达式，由用户输入  
        /// </summary>  
        public string RegexValue
        {
            get { return regexValue; }
            set { regexValue = value; }
        }

        private string hintText = string.Empty;
        /// <summary>  
        /// 提示文字  
        /// </summary>  
        public string HintText
        {
            get { return hintText; }
            set
            {
                hintText = value;
                SendMessage(this.Handle, EM_SETCUEBANNER, 0, HintText);
            }
        }

        /// <summary>  
        /// 输入类型  
        /// </summary>  
        private InputType textInputType = InputType.String;
        public InputType TextInputType
        {
            get { return textInputType; }
            set { textInputType = value; }
        }

        /// <summary>  
        /// 重载设置的逻辑，检查输入是否符合规定  
        /// </summary>  
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                if (true == IsValid(value))
                {
                    base.Text = value;

                }
            }
        }

        public LimitTextBox() :base(){ 
        }

        /// <summary>  
        /// 检查输入值是否符合设定的正则表达式  
        /// </summary>  
        /// <param name="val">输入值</param>  
        /// <returns>true：符合；false：不符合</returns>  
        public bool IsValid(string val)
        {
            string strRegexValue = string.Empty;

            switch (textInputType)
            {
                //若用户选择输入类型为字符串，则不需要做后续判断  
                case InputType.String:
                    return true;
                //设置为数字输入的正则表达式  
                case InputType.Number:
                    strRegexValue = @"^(-)?\d+(\.)?\d*$|^-$";
                    break;
                //设置用户输入的正则表达式  
                case InputType.Regex:
                    strRegexValue = regexValue;
                    break;
                default:
                    break;
            }

            //若用户未设定正则表达式，则不需要做后续判断  
            if (true == string.IsNullOrEmpty(strRegexValue))
            {
                return true;
            }

            //匹配正则表达式  
            if (true == Regex.IsMatch(val, strRegexValue))
            {
                return true;
            }

            return false;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            do
            {
                char cKey = e.KeyChar;
                //输入字符为控制字符则不需要做后续判断  
                if (true == char.IsControl(cKey))
                {
                    break;
                }

                if (true == string.IsNullOrEmpty(cKey.ToString()))
                {
                    e.Handled = true;
                    return;
                }

                string strNewText = base.Text.Substring(0, base.SelectionStart) + cKey.ToString() + base.Text.Substring(base.SelectionStart + base.SelectionLength);

                if (false == IsValid(strNewText))
                {
                    e.Handled = true;
                }
            } while (false);

            base.OnKeyPress(e);
        }
    }
}