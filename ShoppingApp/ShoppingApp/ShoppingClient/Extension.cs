using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoppingClient
{
    public static class Extension
    {
        public static void AppendLine(this TextBox source, string txt)
        {
            if (source.Text.Length == 0)
            {
                source.Text = txt;
            }
            else
            {
                source.AppendText("\r\n" + txt);
            }
        }
    }
}
