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
        public static void ShowMessage(List<string> allStrings)
        {
            foreach (string strinG in allStrings)
            {
                MessageBox.Show(strinG);

            }
            //  return "Completed";
        }
        public static void ShowElementsData(List<Element> listOfElements)
        {
            foreach (Element item in listOfElements)
            {
                //Debug.Print(item);
                MessageBox.Show(item.Category.Name + " | " + item.Id.ToString());
            }
            //return "completed";
        }
        public static void ShowFamilyInstanceData(List<FamilyInstance> listOfElements)
        {
            foreach (FamilyInstance item in listOfElements)
            {
                //Debug.Print(item);
                MessageBox.Show(item.Category.Name + " | " + item.Id.ToString());
            }
            //return "completed";
        }
        public static void ShowFamilySymbolsData(List<FamilySymbol> listOfElements)
        {
            foreach (FamilySymbol item in listOfElements)
            {
                //Debug.Print(item);
                MessageBox.Show(item.FamilyName + " | " + item.Name);
            }
            //return "completed";
        }
        internal static void ShowElementTypesData(List<ElementType> allColumnsElementTypes)
        {
            foreach (ElementType item in allColumnsElementTypes)
            {
                MessageBox.Show(item.FamilyName + " | " + item.Name);
            }
        }
    }
}
