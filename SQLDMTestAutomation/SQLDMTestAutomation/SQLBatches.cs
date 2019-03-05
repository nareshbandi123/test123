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
    ///The SQLBatches recording.
    /// </summary>
    [TestModule("29cc5df4-1723-40c1-b7f8-d357dfa95b8c", ModuleType.Recording, 1)]
    public partial class SQLBatches : ITestModule
    {
        /// <summary>
        /// Holds an instance of the SQLDMTestAutomationRepository repository.
        /// </summary>
        public static SQLDMTestAutomationRepository repo = SQLDMTestAutomationRepository.Instance;

        static SQLBatches instance = new SQLBatches();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SQLBatches()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static SQLBatches Instance
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

            Report.Log(ReportLevel.Info, "Delay", "Waiting for 2s.", new RecordItemIndex(0));
            Delay.Duration(2000, false);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'IderaSQLDiagnosticManagerSQLdmRepo.ServerCMWIN2016' at Center.", repo.IderaSQLDiagnosticManagerSQLdmRepo.ServerCMWIN2016Info, new RecordItemIndex(1));
            repo.IderaSQLDiagnosticManagerSQLdmRepo.ServerCMWIN2016.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'IderaSQLDiagnosticManagerSQLdmRepo.ServerCMWIN2016' at Center.", repo.IderaSQLDiagnosticManagerSQLdmRepo.ServerCMWIN2016Info, new RecordItemIndex(2));
            repo.IderaSQLDiagnosticManagerSQLdmRepo.ServerCMWIN2016.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Wait", "Waiting 50s to exist. Associated repository item: 'IderaSQLDiagnosticManagerSQLdmRepo.Queries'", repo.IderaSQLDiagnosticManagerSQLdmRepo.QueriesInfo, new ActionTimeout(50000), new RecordItemIndex(3));
            repo.IderaSQLDiagnosticManagerSQLdmRepo.QueriesInfo.WaitForExists(50000);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'IderaSQLDiagnosticManagerSQLdmRepo.Queries' at Center.", repo.IderaSQLDiagnosticManagerSQLdmRepo.QueriesInfo, new RecordItemIndex(4));
            repo.IderaSQLDiagnosticManagerSQLdmRepo.Queries.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'IderaSQLDiagnosticManagerSQLdmRepo.Queries' at Center.", repo.IderaSQLDiagnosticManagerSQLdmRepo.QueriesInfo, new RecordItemIndex(5));
            repo.IderaSQLDiagnosticManagerSQLdmRepo.Queries.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Delay", "Waiting for 2s.", new RecordItemIndex(6));
            Delay.Duration(2000, false);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'IderaSQLDiagnosticManagerSQLdmRepo.StatementMode' at Center.", repo.IderaSQLDiagnosticManagerSQLdmRepo.StatementModeInfo, new RecordItemIndex(7));
            repo.IderaSQLDiagnosticManagerSQLdmRepo.StatementMode.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'IderaSQLDiagnosticManagerSQLdmRepo.StatementMode' at Center.", repo.IderaSQLDiagnosticManagerSQLdmRepo.StatementModeInfo, new RecordItemIndex(8));
            repo.IderaSQLDiagnosticManagerSQLdmRepo.StatementMode.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Delay", "Waiting for 4s.", new RecordItemIndex(9));
            Delay.Duration(4000, false);
            
            VerifyFilterOpetions();
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Delay", "Waiting for 5s.", new RecordItemIndex(11));
            Delay.Duration(5000, false);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'IderaSQLDiagnosticManagerSQLdmRepo.ShowSqlBatches' at Center.", repo.IderaSQLDiagnosticManagerSQLdmRepo.ShowSqlBatchesInfo, new RecordItemIndex(12));
            repo.IderaSQLDiagnosticManagerSQLdmRepo.ShowSqlBatches.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'IderaSQLDiagnosticManagerSQLdmRepo.ShowSqlBatches' at Center.", repo.IderaSQLDiagnosticManagerSQLdmRepo.ShowSqlBatchesInfo, new RecordItemIndex(13));
            repo.IderaSQLDiagnosticManagerSQLdmRepo.ShowSqlBatches.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Delay", "Waiting for 20s.", new RecordItemIndex(14));
            Delay.Duration(20000, false);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
