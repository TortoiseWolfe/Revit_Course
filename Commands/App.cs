#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Reflection;
using System.Collections.Generic;
//using System.Windows.Media.Imaging;
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
            String tabName = "Trinam";
            aPP.CreateRibbonTab(tabName);

            // Add a new ribbon panel
            RibbonPanel ribbonPanel = aPP.CreateRibbonPanel(tabName, "Dimensioning");

            // Get dll assembly path
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            // Create push button data
            CreatePushButton(thisAssemblyPath, ribbonPanel, "Message Test", "_01_TestMessage", "Trinam_Design_32.png", "Trinam_Design_16.png", "Test Message");
            CreatePushButton(thisAssemblyPath, ribbonPanel, "Object Selection", "_02_Selection_of_Objects", "Trinam_Design_32.png", "Trinam_Design_16.png", "Selection of Objects");
            CreatePushButton(thisAssemblyPath, ribbonPanel, "Instance Extraction", "_03_Instance_Extraction", "Trinam_Design_32.png", "Trinam_Design_16.png", "Instance Extraction");
            CreatePushButton(thisAssemblyPath, ribbonPanel, "Symbol Extraction", "_04_Symbol_Extraction", "Trinam_Design_32.png", "Trinam_Design_16.png", "Symbol Extraction");
            CreatePushButton(thisAssemblyPath, ribbonPanel, "Element Type Extraction", "_05_Element_Type_Extraction", "Trinam_Design_32.png", "Trinam_Design_16.png", "Elment Type Extraction");
            CreatePushButton(thisAssemblyPath, ribbonPanel, "create column at 0,0,0", "_06_Family_Instance_Creation", "Trinam_Design_32.png", "Trinam_Design_16.png", "Family Instance Creation");
            CreatePushButton(thisAssemblyPath, ribbonPanel, "create 10 Columns", "_07_Family_with_Data", "Trinam_Design_32.png", "Trinam_Design_16.png", "Family with Data");
            //CreatePushButton(thisAssemblyPath, ribbonPanel, "Show a toolTip Message", "_08_MacroRecorder", "player_record.png", "player_record.png", "cmdText");
            //CreatePushButton(thisAssemblyPath, ribbonPanel, "Show a toolTip Message", "_09_ScopeBox", "Trinam_Design_32.png", "Trinam_Design_16.png", "cmdText");
            //CreatePushButton(thisAssemblyPath, ribbonPanel, "Show a toolTip Message", "_10_CurtainWallSelection", "Trinam_Design_32.png", "Trinam_Design_16.png", "cmdText");
            //CreatePushButton(thisAssemblyPath, ribbonPanel, "Show a toolTip Message", "_11_CurtainWallDimensioning", "Trinam_Design_32.png", "Trinam_Design_16.png","cmdText");
        }
        public void CreatePushButton(
            string AssemblyPath, 
            RibbonPanel ribbonPanel, 
            string toolTipText, 
            string commandName, 
            string largeImageFileName, 
            string smallImageFileName,
            string cmdText)
        {
            // Create a push button
            PushButtonData A1 = new PushButtonData(
                               commandName,
                               cmdText,
                               AssemblyPath,
                               "Revit_Course." + commandName);

            PushButton pb1 = ribbonPanel.AddItem(A1) as PushButton;
            pb1.ToolTip = toolTipText;
            //pb1.LongDescription = "This is a long description for the command";

            //Uri uriImageLarge = new Uri(@"C:\Users\JonPo\source\repos\TortoiseWolfe\RevitAPI_Course\RevitAPI_Course\Images\" + largeImageFileName);
            //BitmapImage largeImage = new BitmapImage(uriImageLarge);
            //.LargeImage = largeImage;

            //Uri uriImageSmall = new Uri(@"C:\Users\JonPo\source\repos\TortoiseWolfe\RevitAPI_Course\RevitAPI_Course\Images\" + smallImageFileName);
            //BitmapImage smallImage = new BitmapImage(uriImageSmall);
            //pb1.Image = smallImage;
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
