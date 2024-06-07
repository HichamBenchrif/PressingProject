using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Pressing.BL.Extensions
{
    static class TextBoxExtensions
    {
        public static bool IsEmpty(this TextBox Box)
        {
            var Value = Box.Text;
            if (Value == "")
                return true;
            else
                return false;

        }
        public static bool IsEmptyCombobox(this ComboBox Box)
        {
            var Value = Box.SelectedValue;
            if (Value == null)
                return true;
            else
                return false;

        }

    }
}
