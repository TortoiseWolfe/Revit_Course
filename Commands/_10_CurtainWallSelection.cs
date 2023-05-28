using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB.Structure;
namespace Revit_Course
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]

    public class _10_CurtainWallSelection : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // Selection or Extraction
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Element SelectedElement = Extraction.SingleCurtainWallSelection(uiapp);

            // Add the selected element to a list
            List<Element> SelectedElements = new List<Element>();
            if (SelectedElement != null)
            {
                SelectedElements.Add(SelectedElement);
            }

            // Analysis
            Analysis.ShowElementsData(SelectedElements);

            // Creation
            return Result.Succeeded;
        }       
    }
}
