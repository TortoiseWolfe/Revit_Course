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
    internal class _07_Family_with_Data:IExternalCommand
    {
        public Result Execute(
            ExternalCommandData commandData,
            ref string message,
            ElementSet elements)
        {
            // Selection
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Element selected = Extraction.SingleElementSelection(uiapp);
            ElementId familyTypeId = selected.GetTypeId();
            FamilySymbol famSymb = doc.GetElement(familyTypeId) as FamilySymbol;
            Level level = doc.GetElement(selected.LevelId) as Level;
            List<FamilySymbol> allColumnsfamilySymbols = Extraction.GetAllFamilySymbolsOfCategoryFamilyName(
                doc, 
                BuiltInCategory.OST_StructuralColumns,
                "Concrete-Rectangular-Column");
            //foreach (FamilySymbol item in allColumnsfamilySymbols)
            //{
            //    if(item.FamilyName == famSymb.FamilyName)
            //    {
            //        famSymb= item;
            //    }
            //}
            List<Level> allLevels = Extraction.Levels(doc);

            Location loCation = selected.Location;
            LocationPoint loCationPoint = loCation as LocationPoint;
            XYZ centerPoint = loCationPoint.Point;

            //LocationCurve locationCurve = selected.Location as LocationCurve;
            //LocationCurve locationCurve = selected.Location as LocationCurve;

            //Element - > FamilyInstance
            //ElementType - > FamilyType - > FamilySymbol

            // Creation
            // Transaction
            Transaction tx = new Transaction(doc);
            tx.Start("Transaction Name");
            if (!allColumnsfamilySymbols[0].IsActive)
            {
                allColumnsfamilySymbols[0].Activate();
            }
            FamilyInstance newColumn = doc.Create.NewFamilyInstance(
                   centerPoint.Add(new XYZ(3, 0, 0)),
                   allColumnsfamilySymbols[0],
                   level,
                   StructuralType.NonStructural);
            //     new XYZ(0, 0, 0),
            //     allLevels[0],


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

