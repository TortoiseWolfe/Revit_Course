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
    internal class _00_MainAddinStructure:IExternalCommand
    {
        public Result Execute(
            ExternalCommandData commandData,
            ref string message,
            ElementSet elements)
        {
            // Selection
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            //List<Element> SelectedElements = Extraction.multipleStructuralColumnElementSelection(uiapp);
            List<FamilyInstance> allColumns = Extraction.getAllFamilyInsancesOfCategory(doc, BuiltInCategory.OST_StructuralColumns);

        //Element - > FamilyInstance
        //ElementType - > FamilyType - > FamilySymbol
            // Analysis
            //MessageBox.Show(
            //    "Selected Element: " + 
            //    SelectedElement.Category.Name + 
            //    ":|:" + 
            //    SelectedElement.Id.ToString());
//          Analysis.ShowElementsData(SelectedElements);
            Analysis.ShowFamilyInstanceData(allColumns);
            return Result.Succeeded;
        }

    }
}
