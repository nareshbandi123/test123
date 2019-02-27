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

namespace SQLDMTestAutomation.SQLDMRecordings
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The SelectServer recording.
    /// </summary>
    [TestModule("24f6bd52-083e-4e49-bf06-cf2fe2ae5d7d", ModuleType.Recording, 1)]
    public partial class SelectServer : ITestModule
    {
        /// <summary>
        /// Holds an instance of the SQLDMTestAutomation.SQLDMTestAutomationRepository repository.
        /// </summary>
        public static SQLDMTestAutomation.SQLDMTestAutomationRepository repo = SQLDMTestAutomation.SQLDMTestAutomationRepository.Instance;

        static SelectServer instance = new SelectServer();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SelectServer()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static SelectServer Instance
        {
            get { return instance; }
        }

#region Variables

        /// <summary>
        /// Gets or sets the value of variable ServerName.
        /// </summary>
        [TestVariable("1414cc25-97b1-4e47-ab61-5d306e2f14c6")]
        public string ServerName
        {
            get { return repo.ServerName; }
            set { repo.ServerName = value; }
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

            Report.Log(ReportLevel.Info, "User", "$ServerName", new RecordItemIndex(0));
            
            Report.Log(ReportLevel.Info, "Invoke action", "Invoking EnsureVisible() on item 'SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.Server'.", repo.SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.ServerInfo, new RecordItemIndex(1));
            repo.SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.Server.EnsureVisible();
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.Server' at Center.", repo.SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.ServerInfo, new RecordItemIndex(2));
            repo.SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.Server.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.Server' at Center.", repo.SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.ServerInfo, new RecordItemIndex(3));
            repo.SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.Server.Click();
            Delay.Milliseconds(200);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
