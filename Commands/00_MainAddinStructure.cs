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
//          List<FamilySymbol> allColumnsfamilySymbols = Extraction.getAllFamilySymbolsOfCategory(doc, BuiltInCategory.OST_StructuralColumns);
            List<FamilySymbol> allColumnsfamilySymbols = Extraction.getAllFamilySymbolsOfCategoryFamilyName(doc, BuiltInCategory.OST_StructuralColumns, "Concrete-Rectangular-Column");
            List<ElementType> allColumnsElementTypes = Extraction.getAllElementTpyesOfCategory(doc, BuiltInCategory.OST_StructuralColumns);

            //Element - > FamilyInstance
            //ElementType - > FamilyType - > FamilySymbol
            // Analysis
            //MessageBox.Show(
            //    "Selected Element: " + 
            //    SelectedElement.Category.Name + 
            //    ":|:" + 
            //    SelectedElement.Id.ToString());
            //          Analysis.ShowElementsData(SelectedElements);
  //          Analysis.ShowFamilyInstanceData(allColumns);
            Analysis.ShowFamilySymbolsData(allColumnsfamilySymbols);
  //          Analysis.ShowElementTypesData(allColumnsElementTypes);
            return Result.Succeeded;
        }

    }
}
