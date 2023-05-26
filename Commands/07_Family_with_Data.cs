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
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // Selection
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Element selected = Extraction.SingleElementSelection(uiapp);
            ElementId familyTypeId = selected.GetTypeId();
            FamilySymbol famSymb = doc.GetElement(familyTypeId) as FamilySymbol;
            Level level = doc.GetElement(selected.LevelId) as Level;

            Parameter paraMeter = selected.get_Parameter(BuiltInParameter.INSTANCE_LENGTH_PARAM);
            double length = paraMeter.AsDouble();
            string valUe = selected.LookupParameter("Reference").AsString();

            Location loCation = selected.Location;
            LocationPoint loCationPoint = loCation as LocationPoint;
            XYZ centerPoint = loCationPoint.Point;

            List<XYZ> allPoints = new List<XYZ>();
            for (int i = 1; i < 7; i++)
            {
                XYZ point = centerPoint.Add(new XYZ(length * i, 0, 0));
                allPoints.Add(point);
            }

            //LocationCurve locationCurve = selected.Location as LocationCurve;
            //LocationCurve locationCurve = selected.Location as LocationCurve;

            //Element - > FamilyInstance
            //ElementType - > FamilyType - > FamilySymbol

            // Creation
            // Transaction
            Transaction tx = new Transaction(doc);
            tx.Start("Starting Transaction process name");
            foreach (XYZ point in allPoints)
            {
            FamilyInstance newColumn = doc.Create.NewFamilyInstance(
                   point,   
                   famSymb,
                   level,
                   StructuralType.Column);
                  //centerPoint.Add(new XYZ(length, 0, 0)),
                 //new XYZ(0, 0, 0),
                // allLevels[0],
            newColumn.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS).Set("valued One");
            newColumn.LookupParameter("Reference").Set(valUe);
                }
            tx.Commit();
            return Result.Succeeded;
        }
    }
}

