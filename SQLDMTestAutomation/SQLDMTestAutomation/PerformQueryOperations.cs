﻿///////////////////////////////////////////////////////////////////////////////
//
// This file was automatically generated by RANOREX.
// DO NOT MODIFY THIS FILE! It is regenerated by the designer.
// All your modifications will be lost!
// http://www.ranorex.com
//
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using Ranorex.Core.Repository;

namespace SQLDMTestAutomation
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The PerformQueryOperations recording.
    /// </summary>
    [TestModule("5b779250-b3a7-4063-b353-0b036b507719", ModuleType.Recording, 1)]
    public partial class PerformQueryOperations : ITestModule
    {
        /// <summary>
        /// Holds an instance of the SQLDMTestAutomationRepository repository.
        /// </summary>
        public static SQLDMTestAutomationRepository repo = SQLDMTestAutomationRepository.Instance;

        static PerformQueryOperations instance = new PerformQueryOperations();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public PerformQueryOperations()
        {
            Query = "select [QueryMonitorTopPlanCountFilter],[QueryMonitorTopPlanCategoryFilter],[QueryMonitorQueryStoreMonitoringEnabled] from MonitoredSQLServers";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static PerformQueryOperations Instance
        {
            get { return instance; }
        }

#region Variables

        string _Query;

        /// <summary>
        /// Gets or sets the value of variable Query.
        /// </summary>
        [TestVariable("08d49f5f-06d5-4360-8d85-82206a6ab74e")]
        public string Query
        {
            get { return _Query; }
            set { _Query = value; }
        }

#endregion

        /// <summary>
        /// Starts the replay of the static recording <see cref="Instance"/>.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("Ranorex", "8.2")]
        public static void Start()
        {
            TestModuleRunner.Run(Instance);
        }

        /// <summary>
        /// Performs the playback of actions in this recording.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        [System.CodeDom.Compiler.GeneratedCode("Ranorex", "8.2")]
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.00;

            Init();

            Report.Log(ReportLevel.Info, "Application", "Run application 'C:\\Program Files (x86)\\Microsoft SQL Server\\100\\Tools\\Binn\\VSShell\\Common7\\IDE\\Ssms.exe' with arguments '' in normal mode.", new RecordItemIndex(0));
            Host.Local.RunApplication("C:\\Program Files (x86)\\Microsoft SQL Server\\100\\Tools\\Binn\\VSShell\\Common7\\IDE\\Ssms.exe", "", "C:\\Program Files (x86)\\Microsoft SQL Server\\100\\Tools\\Binn\\VSShell\\Common7\\IDE", false);
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Wait", "Waiting 5s for the attribute 'Text' to contain the specified value 'SQLDM Today'. Associated repository item: 'IderaSQLDiagnosticManagerSQLdmRepo.SQLDMToday'", repo.IderaSQLDiagnosticManagerSQLdmRepo.SQLDMTodayInfo, new RecordItemIndex(1));
            repo.IderaSQLDiagnosticManagerSQLdmRepo.SQLDMTodayInfo.WaitForAttributeContains(5000, "Text", "SQLDM Today");
            
            Report.Log(ReportLevel.Info, "Delay", "Waiting for 20s.", new RecordItemIndex(2));
            Delay.Duration(20000, false);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'ConnectionDialog.ServerNameToConnect' at Center.", repo.ConnectionDialog.ServerNameToConnectInfo, new RecordItemIndex(3));
            repo.ConnectionDialog.ServerNameToConnect.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key 'Ctrl+A' Press with focus on 'ConnectionDialog.ServerNameToConnect'.", repo.ConnectionDialog.ServerNameToConnectInfo, new RecordItemIndex(4));
            Keyboard.PrepareFocus(repo.ConnectionDialog.ServerNameToConnect);
            Keyboard.Press(System.Windows.Forms.Keys.A | System.Windows.Forms.Keys.Control, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence 'AUT-SQL-DEV-001' with focus on 'ConnectionDialog.ServerNameToConnect'.", repo.ConnectionDialog.ServerNameToConnectInfo, new RecordItemIndex(5));
            repo.ConnectionDialog.ServerNameToConnect.PressKeys("AUT-SQL-DEV-001");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'ConnectionDialog.Connect' at Center.", repo.ConnectionDialog.ConnectInfo, new RecordItemIndex(6));
            repo.ConnectionDialog.Connect.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'ConnectionDialog.Connect' at Center.", repo.ConnectionDialog.ConnectInfo, new RecordItemIndex(7));
            repo.ConnectionDialog.Connect.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'MicrosoftSQLServerManagementStudio.Databases' at Center.", repo.MicrosoftSQLServerManagementStudio.DatabasesInfo, new RecordItemIndex(8));
            repo.MicrosoftSQLServerManagementStudio.Databases.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left DoubleClick item 'MicrosoftSQLServerManagementStudio.Databases' at Center.", repo.MicrosoftSQLServerManagementStudio.DatabasesInfo, new RecordItemIndex(9));
            repo.MicrosoftSQLServerManagementStudio.Databases.DoubleClick();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'MicrosoftSQLServerManagementStudio.SQLdmRepository' at Center.", repo.MicrosoftSQLServerManagementStudio.SQLdmRepositoryInfo, new RecordItemIndex(10));
            repo.MicrosoftSQLServerManagementStudio.SQLdmRepository.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Invoke action", "Invoking Select() on item 'MicrosoftSQLServerManagementStudio.SQLdmRepository'.", repo.MicrosoftSQLServerManagementStudio.SQLdmRepositoryInfo, new RecordItemIndex(11));
            repo.MicrosoftSQLServerManagementStudio.SQLdmRepository.Select();
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Right Click item 'MicrosoftSQLServerManagementStudio.SQLdmRepository' at Center.", repo.MicrosoftSQLServerManagementStudio.SQLdmRepositoryInfo, new RecordItemIndex(12));
            repo.MicrosoftSQLServerManagementStudio.SQLdmRepository.Click(System.Windows.Forms.MouseButtons.Right);
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Right Click item 'SSMS_SomeContextMenu.NewQuery' at Center.", repo.SSMS_SomeContextMenu.NewQueryInfo, new RecordItemIndex(13));
            repo.SSMS_SomeContextMenu.NewQuery.Click(System.Windows.Forms.MouseButtons.Right);
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'MicrosoftSQLServerManagementStudio.QueryEditor' at Center.", repo.MicrosoftSQLServerManagementStudio.QueryEditorInfo, new RecordItemIndex(14));
            repo.MicrosoftSQLServerManagementStudio.QueryEditor.Click();
            Delay.Milliseconds(200);
            
            Set_value_QueryEditor(repo.MicrosoftSQLServerManagementStudio.QueryEditorInfo);
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'MicrosoftSQLServerManagementStudio.Execute' at Center.", repo.MicrosoftSQLServerManagementStudio.ExecuteInfo, new RecordItemIndex(16));
            repo.MicrosoftSQLServerManagementStudio.Execute.Click();
            Delay.Milliseconds(200);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
