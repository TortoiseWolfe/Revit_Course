#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Reflection;
using System.Collections.Generic;
#endregion

namespace Revit_Course
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    internal class App : IExternalApplication
    {
        void AddRibbonPanel(UIControlledApplication aPP)
        {
            // Create a custom ribbon tab
            String tabName = "My Tab";
            aPP.CreateRibbonTab(tabName);

            // Add a new ribbon panel
            RibbonPanel ribbonPanel = aPP.CreateRibbonPanel(tabName, "My First Panel");

            // Get dll assembly path
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            // create push button for this command
            PushButtonData buttonData_01 = new PushButtonData(
                "cmdHelloWorld",
                "show a Hello World message", 
                thisAssemblyPath,
                "Revit_Course._01_TestMessage");

            // add tooltip to the button
            buttonData_01.ToolTip = "Say hello to the entire world.";

            // add button to the ribbon panel
            PushButton pushButton_One = ribbonPanel.AddItem(buttonData_01) as PushButton;
            pushButton_One.ToolTip = "Say hello to the entire world.";

            // add image to the button
            //pushButton.LargeImage = PngImageSource("Revit_Course.Resources.hello_world_32x32.png");
        }

        public Result OnStartup(UIControlledApplication aPP)
        {
            AddRibbonPanel(aPP);
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication aPP)
        {
            return Result.Succeeded;
        }
    }
}
