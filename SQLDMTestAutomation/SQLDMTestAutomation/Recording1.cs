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
    ///The Recording1 recording.
    /// </summary>
    [TestModule("a3e16002-ad31-41c7-be31-fdb013b90bf3", ModuleType.Recording, 1)]
    public partial class Recording1 : ITestModule
    {
        /// <summary>
        /// Holds an instance of the SQLDMTestAutomationRepository repository.
        /// </summary>
        public static SQLDMTestAutomationRepository repo = SQLDMTestAutomationRepository.Instance;

        static Recording1 instance = new Recording1();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public Recording1()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static Recording1 Instance
        {
            get { return instance; }
        }

#region Variables

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

            Report.Log(ReportLevel.Info, "Application", "Run application 'C:\\Program Files\\Idera\\Idera SQL diagnostic manager\\SQLdmDesktopClient.exe' with arguments '' in normal mode.", new RecordItemIndex(0));
            Host.Local.RunApplication("C:\\Program Files\\Idera\\Idera SQL diagnostic manager\\SQLdmDesktopClient.exe", "", "C:\\Program Files\\Idera\\Idera SQL diagnostic manager", false);
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Wait", "Waiting 5s for the attribute 'Text' to contain the specified value 'SQLDM Today'. Associated repository item: 'IderaSQLDiagnosticManagerSQLdmRepo.SQLDMToday'", repo.IderaSQLDiagnosticManagerSQLdmRepo.SQLDMTodayInfo, new RecordItemIndex(1));
            repo.IderaSQLDiagnosticManagerSQLdmRepo.SQLDMTodayInfo.WaitForAttributeContains(5000, "Text", "SQLDM Today");
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'IderaSQLDiagnosticManagerSQLdmRepo.Server' at Center.", repo.IderaSQLDiagnosticManagerSQLdmRepo.ServerInfo, new RecordItemIndex(2));
            repo.IderaSQLDiagnosticManagerSQLdmRepo.Server.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'IderaSQLDiagnosticManagerSQLdmRepo.Server' at Center.", repo.IderaSQLDiagnosticManagerSQLdmRepo.ServerInfo, new RecordItemIndex(3));
            repo.IderaSQLDiagnosticManagerSQLdmRepo.Server.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'IderaSQLDiagnosticManagerSQLdmRepo.Queries' at Center.", repo.IderaSQLDiagnosticManagerSQLdmRepo.QueriesInfo, new RecordItemIndex(4));
            repo.IderaSQLDiagnosticManagerSQLdmRepo.Queries.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'IderaSQLDiagnosticManagerSQLdmRepo.Queries' at Center.", repo.IderaSQLDiagnosticManagerSQLdmRepo.QueriesInfo, new RecordItemIndex(5));
            repo.IderaSQLDiagnosticManagerSQLdmRepo.Queries.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'IderaSQLDiagnosticManagerSQLdmRepo.SignatureMode' at Center.", repo.IderaSQLDiagnosticManagerSQLdmRepo.SignatureModeInfo, new RecordItemIndex(6));
            repo.IderaSQLDiagnosticManagerSQLdmRepo.SignatureMode.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Delay", "Waiting for 5s.", new RecordItemIndex(7));
            Delay.Duration(5000, false);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'IderaSQLDiagnosticManagerSQLdmRepo.SignatureMode' at Center.", repo.IderaSQLDiagnosticManagerSQLdmRepo.SignatureModeInfo, new RecordItemIndex(8));
            repo.IderaSQLDiagnosticManagerSQLdmRepo.SignatureMode.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Delay", "Waiting for 2s.", new RecordItemIndex(9));
            Delay.Duration(2000, false);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'IderaSQLDiagnosticManagerSQLdmRepo.ConfigureQueryMonitor' at Center.", repo.IderaSQLDiagnosticManagerSQLdmRepo.ConfigureQueryMonitorInfo, new RecordItemIndex(10));
            repo.IderaSQLDiagnosticManagerSQLdmRepo.ConfigureQueryMonitor.MoveTo();
            Delay.Milliseconds(200);
            
            //Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'IderaSQLDiagnosticManagerSQLdmRepo.ConfigureQueryMonitor' at Center.", repo.IderaSQLDiagnosticManagerSQLdmRepo.ConfigureQueryMonitorInfo, new RecordItemIndex(11));
            //repo.IderaSQLDiagnosticManagerSQLdmRepo.ConfigureQueryMonitor.Click();
            //Delay.Milliseconds(200);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
