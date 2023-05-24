using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Revit_Course
{
    internal class Analysis
    {
        public static string ShowMessage(List<string> listAll)
        {
            foreach (string item in listAll)
            {
                //Debug.Print(item);
                MessageBox.Show(item);
            }
            return "completed";
        }
    }
}
