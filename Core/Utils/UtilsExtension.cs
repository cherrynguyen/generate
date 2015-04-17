using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Core
{
    public static class UtilsExtension
    {
        public static void BindingListControl(this ListControl lst, DataTable source, string textField, string valueField)
        {
            lst.DisplayMember = textField;
            lst.ValueMember = valueField;
            lst.DataSource = source;
        }
        public static void BindingListControl<T>(this ListControl lst, IList<T> source, string textField, string valueField)
        {
            lst.DisplayMember = textField;
            lst.ValueMember = valueField;
            lst.DataSource = source;
        }
    }
}
