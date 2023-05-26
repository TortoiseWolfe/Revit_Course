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
using Autodesk.Revit.DB.Structure;
#endregion
namespace Revit_Course
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    internal class _07_Main_Addin_Structure:IExternalCommand
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
            //List<FamilyInstance> allColumns = Extraction.getAllFamilyInsancesOfCategory(doc, BuiltInCategory.OST_StructuralColumns);
//          List<FamilySymbol> allColumnsfamilySymbols = Extraction.getAllFamilySymbolsOfCategory(doc, BuiltInCategory.OST_StructuralColumns);
            List<FamilySymbol> allColumnsfamilySymbols = Extraction.GetAllFamilySymbolsOfCategoryFamilyName(doc, BuiltInCategory.OST_StructuralColumns, "Concrete-Rectangular-Column");
            //List<ElementType> allColumnsElementTypes = Extraction.getAllElementTpyesOfCategory(doc, BuiltInCategory.OST_StructuralColumns);
            List<Level> allLevels = Extraction.Levels(doc);
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

            // Creation
            // Transaction
            Transaction tx = new Transaction(doc);
            tx.Start("Transaction Name");
            if (!allColumnsfamilySymbols[0].IsActive)
            {
                allColumnsfamilySymbols[0].Activate();
            }
            //FamilyInstance newColumn = doc.Create.NewFamilyInstance(
            //                   new XYZ(0, 0, 0),
            //                   allColumnsfamilySymbols[0],
            //                   StructuralType.NonStructural);
            FamilyInstance newColumn = doc.Create.NewFamilyInstance(
                   new XYZ(0, 0, 0),
                   allColumnsfamilySymbols[0],
                   allLevels[0],
                   StructuralType.NonStructural);


            try
            {
                // Creation
                
                // Modification
                // Return
                tx.Commit();
                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                return Result.Succeeded;

            }
        }
    }
}

