#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System.IO;
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
            CreatePushButton(thisAssemblyPath, ribbonPanel, "Message" + "\r\n" + "Test", "_01_TestMessage", "config.png", "Trinam_Design_16.png", "Test Message");
            CreatePushButton(thisAssemblyPath, ribbonPanel, "Object" + "\r\n" + "Selection", "_02_Selection_of_Objects", "Trinam_Design_32.png", "Trinam_Design_16.png", "Selection of Objects");
            CreatePushButton(thisAssemblyPath, ribbonPanel, "Instance" + "\r\n" + "Extraction", "_03_Instance_Extraction", "Trinam_Design_32.png", "Trinam_Design_16.png", "Instance Extraction");
            CreatePushButton(thisAssemblyPath, ribbonPanel, "Symbol" + "\r\n" + "Extraction", "_04_Symbol_Extraction", "Trinam_Design_32.png", "Trinam_Design_16.png", "Symbol Extraction");
            CreatePushButton(thisAssemblyPath, ribbonPanel, "Element Type" + "\r\n" + "Extraction", "_05_Element_Type_Extraction", "Trinam_Design_32.png", "Trinam_Design_16.png", "Elment Type Extraction");
            CreatePushButton(thisAssemblyPath, ribbonPanel, "create column" + "\r\n" + "at 0,0,0", "_06_Family_Instance_Creation", "Trinam_Design_32.png", "Trinam_Design_16.png", "Family Instance Creation");
            CreatePushButton(thisAssemblyPath, ribbonPanel, "create 10 Columns" + "\r\n" + "with Data", "_07_Family_with_Data", "icons8-enterprise-nx-01-36.png", "icons8-voyager-badge-16.png", "Family with Data");
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
            pb1.LongDescription = "This is a long description for the command";
            pb1.LargeImage = PngImageSource("Revit_Course.Resources." + largeImageFileName);
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
        public System.Windows.Media.ImageSource PngImageSource(string embeddedPath)
        {
            Stream stream = this.GetType().Assembly.GetManifestResourceStream(embeddedPath);
            var decoder = new System.Windows.Media.Imaging.PngBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            return decoder.Frames[0];
        }
    }
}
