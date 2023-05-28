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
            RibbonPanel ribbonPanel = aPP.CreateRibbonPanel(tabName, "API Course");
            RibbonPanel ribbonPanel_02 = aPP.CreateRibbonPanel(tabName, "Dimensioning");

            // Get dll assembly path
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            // Create push button data
            CreatePushButton(thisAssemblyPath, ribbonPanel, "Message" + "\r\n" + "Test", "_01_TestMessage", "config.png", "Trinam_96.png", "Test Message", "This is a long description for the command");
            CreatePushButton(thisAssemblyPath, ribbonPanel, "Object" + "\r\n" + "Selection", "_02_Selection_of_Objects", "Trinam_Design_32.png", "Trinam_96.png", "Selection" + "\r\n" + "of Objects", "This is a long description for the command");
            ribbonPanel.AddSeparator();
            ribbonPanel.AddSeparator();
            CreatePushButton(thisAssemblyPath, ribbonPanel, "Instance" + "\r\n" + "Extraction", "_03_Instance_Extraction", "Trinam_Design_32.png", "Trinam_96.png", "Instance" + "\r\n" + "Extraction", "This is a long description for the command");
            CreatePushButton(thisAssemblyPath, ribbonPanel, "Symbol" + "\r\n" + "Extraction", "_04_Symbol_Extraction", "Trinam_Design_32.png", "Trinam_96.png", "Symbol" + "\r\n" + "Extraction", "This is a long description for the command");
            CreatePushButton(thisAssemblyPath, ribbonPanel, "Element Type" + "\r\n" + "Extraction", "_05_Element_Type_Extraction", "Trinam_Design_32.png", "Trinam_96.png", "Element Type" + "\r\n" + "Extraction", "This is a long description for the command");
            ribbonPanel.AddSeparator();
            ribbonPanel.AddSeparator();
            CreatePushButton(thisAssemblyPath, ribbonPanel, "create column" + "\r\n" + "at 0,0,0", "_06_Family_Instance_Creation", "Trinam_Design_32.png", "Trinam_96.png", "Instance" + "\r\n" + " Creation", "This is a long description for the command");
            CreatePushButton(thisAssemblyPath, ribbonPanel, "create 10 Columns" + "\r\n" + "with Data", "_07_Family_with_Data", "icons8-tricorder-32.png", "Trinam_96.png", "Family" + "\r\n" + " with Data", "This is a long description for the command");
            ribbonPanel.AddSeparator();

            ribbonPanel_02.AddSeparator();
            CreatePushButton(thisAssemblyPath, ribbonPanel_02, "Instance" + "" + "\r\n" + "Extraction", "_08_MacroRecorder", "player_record.png", "Trinam_96.png", "Macro" + "\r\n" + "Recorder", "This is a long description for the command");
            CreatePushButton(thisAssemblyPath, ribbonPanel_02, "Instance" + "\r\n" + "Extraction", "_09_ScopeBox", "Trinam_Design_32.png", "Trinam_96.png", "Scope" + "\r\n" + "Box", "This is a long description for the command");
            ribbonPanel_02.AddSeparator();
            ribbonPanel_02.AddSeparator();
            CreatePushButton(thisAssemblyPath, ribbonPanel_02, "Dimension" + "\r\n" + "by Surface", "_11_Dimensioning_bySurface", "icons8-surface-32.png", "Trinam_96.png", "Dimension" + "\r\n" + "by Surface", "Dimension by selecting a Surface");
            CreatePushButton(thisAssemblyPath, ribbonPanel_02, "CurtainWall" + "\r\n" + "Selection", "_10_CurtainWallSelection", "icons8-surface-16.png", "windows.png", "CurtainWall" + "\r\n" + "Selection", "This is a long description for the command");
            CreatePushButton(thisAssemblyPath, ribbonPanel_02, "Dimension" + "\r\n" + "by CurtainGrid", "_11_CurtainWallDimensioning", "icons8-voyager-badge-16.png", "measure (2).png", "CurtainWall" + "\r\n" + "Dimension", "This is a long description for the command");
        }
        public void CreatePushButton(
            string AssemblyPath, 
            RibbonPanel ribbonPanel, 
            string toolTipText, 
            string commandName, 
            string largeImageFileName, 
            string toolTipImageFileName,
            string cmdText,
            string lngDescription)
        {
            // Create a push button
            PushButtonData A1 = new PushButtonData(
                               commandName,
                               cmdText,
                               AssemblyPath,
                               "Revit_Course." + commandName);

            PushButton pb1 = ribbonPanel.AddItem(A1) as PushButton;
            pb1.ToolTip = toolTipText;
            pb1.ToolTipImage = PngImageSource("Revit_Course.Resources.toolTipImages." + toolTipImageFileName);
            pb1.LongDescription = lngDescription;
            pb1.LargeImage = PngImageSource("Revit_Course.Resources." + largeImageFileName);
//          pb1.Enabled = true;

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
