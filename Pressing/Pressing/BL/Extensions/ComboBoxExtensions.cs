﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pressing.PL.les_form_article;
using System.Windows.Forms;

namespace Pressing.BL.Extensions
{
    public static class ComboBoxExtensions
    {
        public static bool IsEmptyCombobox(this ComboBox Box)
        {
            var Value = Box.SelectedItem;
            if (Value == null)
                return true;
            else
                return false;

        }
    }
}
