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
    internal class Extraction
    {
        public static Element singleElementSelection(UIApplication uiapp)
        {

        Document doc = uiapp.ActiveUIDocument.Document;
        Selection sel = uiapp.ActiveUIDocument.Selection;
        Reference pickRef = null;
        Element Selected = null;
        // Extraction
        // Analysis

        // Creation
        Transaction tx = new Transaction(doc);
        tx.Start("Transaction Name");
        try
            {
            pickRef = sel.PickObject(ObjectType.Element, "Select an element");
            Selected = doc.GetElement(pickRef);
            // Creation Process
            // Modification
            // Transaction
            // Return
            }
            catch (Exception ex)
            {

            }
            tx.Commit();
            return Selected;
        }
        public static List<Element> multipleElementSelection(UIApplication uiapp)
        {
            List<Element> allSelected = new List<Element>();
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;
            Reference pickRef = null;
            Boolean flag = true;
            // Extraction
            // Analysis

            // Creation
            Transaction tx = new Transaction(doc);
            tx.Start("Transaction Name");
            while (flag)
            try
            {
                pickRef = sel.PickObject(ObjectType.Element, "Select an element");
                Element Selected = doc.GetElement(pickRef);
                allSelected.Add(Selected);
                // Creation Process
                // Modification
                // Transaction
                // Return
            }
            catch (Exception ex)
            {
                    flag = false;
            }
            tx.Commit();
            return allSelected;
        }
        public static List<Element> multipleStructuralColumnElementSelection(UIApplication uiapp)
        {
            List<Element> allSelected = new List<Element>();
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;
            ISelectionFilter structuralColumnFilter = new StructuralColumnSelectionFilter();
            Reference pickRef = null;
            Boolean flag = true;
            // Extraction
            // Analysis

            // Creation
            Transaction tx = new Transaction(doc);
            tx.Start("Transaction Name");
            while (flag)
                try
                {
                    pickRef = sel.PickObject(ObjectType.Element, structuralColumnFilter, "Select an element");
                    Element Selected = doc.GetElement(pickRef);
                    allSelected.Add(Selected);
                    // Creation Process
                    // Modification
                    // Transaction
                    // Return
                }
                catch (Exception ex)
                {
                    flag = false;
                }
            tx.Commit();
            return allSelected;
        }
        public class StructuralColumnSelectionFilter : ISelectionFilter
        {
            public bool AllowElement(Element elem)
            {
                if (elem.Category.Name == "Structural Columns")
                {
                    return true;
                }
                return false;
            }

            public bool AllowReference(Reference reference, XYZ position)
            {
                return false;
            }
        }
        public static List<FamilyInstance> getAllFamilyInsancesOfCategory(Document doc, BuiltInCategory category)
        {
            List<FamilyInstance> allFamInstances = new List<FamilyInstance>();
            FilteredElementCollector collector = new FilteredElementCollector(doc).OfCategory(category).WhereElementIsNotElementType();
            FilteredElementIterator famIterator = collector.GetElementIterator();
            famIterator.Reset();
            while (famIterator.MoveNext())
            {
                Element famItId = famIterator.Current as Element;
                FamilyInstance famInstance = famIterator.Current as FamilyInstance;
                allFamInstances.Add(famInstance);
                /*
                */
            }
            return allFamInstances;
        }

        public static List<FamilySymbol> getAllFamilySymbolsOfCategory(Document doc, BuiltInCategory category)
        {
            List<FamilySymbol> allFamSymbols = new List<FamilySymbol>();
            FilteredElementCollector collector = new FilteredElementCollector(doc).OfCategory(category).OfClass(typeof(FamilySymbol));
            FilteredElementIdIterator famIterator = collector.GetElementIdIterator();
            famIterator.Reset();
            while (famIterator.MoveNext())
            {
                ElementId famItId = famIterator.Current;
                FamilySymbol famSymbol = doc.GetElement(famItId) as FamilySymbol;
                allFamSymbols.Add(famSymbol);
                /*
                */
            }
            return allFamSymbols;
        }
    }
}
