#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

#endregion
namespace Revit_Course
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    internal class _01_TestMessage:IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //UIApplication uiapp = commandData.Application;
            //UIDocument uidoc = uiapp.ActiveUIDocument;
            //Application app = uiapp

            //Document doc = uidoc.Document;

            //Selection sel = uidoc.Selection;
            
            string str = "Revit Course 01 Test Message";
            double num = .1;
            int i = 1;
            string str2 = "t1|t2|t3";
            List<string> listAll = new List<string>();
            listAll.Add(str);
            listAll.Add(num.ToString());
            listAll.Add(i.ToString());
            listAll.Add(str2);

            foreach (string item in listAll)
            {
                Debug.Print(item);
                MessageBox.Show(item);
            }

            //throw new NotImplementedException();
            return Result.Succeeded;
        }
    }
}
