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
    public class _08_MacroRecorder : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            List<string> messages = new List<string> { "You have clicked on _08_MacroRecorder" };
            Analysis.ShowMessage(messages);
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class _09_ScopeBox : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            List<string> messages = new List<string> { "You have clicked on _09_ScopeBox" };
            Analysis.ShowMessage(messages);
            return Result.Succeeded;
        }
    }

    ////[Transaction(TransactionMode.Manual)]
    ////[Regeneration(RegenerationOption.Manual)]
    ////public class _10_CurtainWallSelection : IExternalCommand
    ////{
    ////    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    ////    {
    ////        List<string> messages = new List<string> { "You have clicked on _10_CurtainWallSelection" };
    ////        Analysis.ShowMessage(messages);
    ////        return Result.Succeeded;
    ////    }
    ////}

    //[Transaction(TransactionMode.Manual)]
    //[Regeneration(RegenerationOption.Manual)]
    //public class _11_CurtainWallDimensioning : IExternalCommand
    //{
    //    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    //    {
    //        List<string> messages = new List<string> { "You have clicked on _11_CurtainWallDimensioning" };
    //        Analysis.ShowMessage(messages);
    //        return Result.Succeeded;
    //    }
    //}
}
