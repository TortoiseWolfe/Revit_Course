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
    public class _11_CurtainWallDimensioning : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // Selection or Extraction
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Wall selectedElement = Extraction.SingleCurtainWallSelection(uiapp) as Wall;

            // Add the selected element to a list
            List<Element> selectedElements = new List<Element>();
            if (selectedElement != null)
            {
                selectedElements.Add(selectedElement);
            }

            // Analysis
            Analysis.ShowElementsData(selectedElements);

            // Select an elevation view
            ViewSection elevationView = doc.ActiveView as ViewSection;

            // Create the dimension
            if (elevationView != null && selectedElement != null)
            {
                using (Transaction trans = new Transaction(doc, "Create Dimension"))
                {
                    trans.Start();

                    // Use the bottom line of the wall's bounding box as a reference line
                    BoundingBoxXYZ boundingBox = selectedElement.get_BoundingBox(elevationView);
                    Line refLine = Line.CreateBound(boundingBox.Min, new XYZ(boundingBox.Max.X, boundingBox.Min.Y, boundingBox.Min.Z));

                    // Create a reference array containing the wall
                    ReferenceArray ra = new ReferenceArray();

                    // Extract GeometryElement and face references from the selected element
                    Options opt = new Options();
                    opt.ComputeReferences = true;
                    GeometryElement geoElem = selectedElement.get_Geometry(opt);

                    if (geoElem != null)
                    {
                        TaskDialog.Show("Debug Info", "GeometryElement is successfully retrieved.");
                        foreach (GeometryObject obj in geoElem)
                        {
                            Solid solid = obj as Solid;
                            if (solid != null)
                            {
                                foreach (Face face in solid.Faces)
                                {
                                    ra.Append(face.Reference);
                                    TaskDialog.Show("Debug Info", "Face reference is added to the ReferenceArray.");
                                }
                            }
                        }
                    }
                    else
                    {
                        TaskDialog.Show("Debug Info", "GeometryElement is null.");
                    }

                    // Get the location curve of the wall and use its endpoints to create references
                    LocationCurve locationCurve = selectedElement.Location as LocationCurve;
                    if (locationCurve != null)
                    {
                        Curve curve = locationCurve.Curve;
                        if (curve != null)
                        {
                            ReferenceArray references = new ReferenceArray();
                            references.Append(curve.GetEndPointReference(0));
                            references.Append(curve.GetEndPointReference(1));
                            Line curveLine = Line.CreateBound(curve.GetEndPoint(0), curve.GetEndPoint(1));
                            Dimension dim = doc.Create.NewDimension(elevationView, curveLine, references);
                        }
                    }
                    else
                    {
                        TaskDialog.Show("Debug Info", "LocationCurve is null.");
                    }

                    // Create the dimension
                    if (ra.Size > 1)
                    {
                        Dimension dim = doc.Create.NewDimension(elevationView, refLine, ra);
                    }
                    else
                    {
                        message = "Error: Invalid number of references.";
                        TaskDialog.Show("Error", "The number of references in the reference array is: " + ra.Size);
                    }

                    foreach (Reference reference in ra)
                    {
                        try
                        {
                            Element e = doc.GetElement(reference);
                            TaskDialog.Show("Reference Info", "Reference conversion success. Element Id: " + e.Id);
                        }
                        catch
                        {
                            TaskDialog.Show("Reference Info", "Reference conversion failed.");
                        }
                    }

                    trans.Commit();
                }
            }

            return Result.Succeeded;
        }
    }
}

