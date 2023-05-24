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
            pickRef = sel.PickObject(ObjectType.Element, "Select an element");
            Selected = doc.GetElement(pickRef);
            // Creation Process
            // Modification
            // Transaction
            // Return
            tx.Commit();
            return Selected;
        }

    }
}
