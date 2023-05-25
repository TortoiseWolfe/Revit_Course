#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;
#endregion

namespace Revit_Course
{
    internal class Analysis
    {
        public static void ShowElementsData(List<Element> listOfElements)
        {
            foreach (Element item in listOfElements)
            {
                //Debug.Print(item);
                MessageBox.Show(item.Category.Name + " | " + item.Id.ToString());
            }
            //return "completed";
        }
    }
}
