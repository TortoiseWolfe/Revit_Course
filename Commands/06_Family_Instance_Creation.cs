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
    internal class _06_Family_Instance_Creation:IExternalCommand
    {
        public Result Execute(
            ExternalCommandData commandData,
            ref string message,
            ElementSet elements)
        {
            // Selection
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            List<FamilySymbol> allColumnsfamilySymbols = Extraction.GetAllFamilySymbolsOfCategoryFamilyName(doc, BuiltInCategory.OST_StructuralColumns, "Concrete-Rectangular-Column");
            List<Level> allLevels = Extraction.Levels(doc);

            // Creation
            // Transaction
            Transaction tx = new Transaction(doc);
            tx.Start("Starting Transaction Name");
            if (!allColumnsfamilySymbols[0].IsActive)
            {
                allColumnsfamilySymbols[0].Activate();
                doc.Regenerate();
            }
            // Creation Process
            FamilyInstance newFamilyInstance = doc.Create.NewFamilyInstance(new XYZ(0, 0, 0), allColumnsfamilySymbols[0], allLevels[0], StructuralType.Column);
            tx.Commit();
            return Result.Succeeded;
        }
    }
}

