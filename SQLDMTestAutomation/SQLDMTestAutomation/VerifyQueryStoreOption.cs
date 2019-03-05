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
    ///The VerifyQueryStoreOption recording.
    /// </summary>
    [TestModule("09608eda-f4ed-43a7-b814-dbecd6ac6248", ModuleType.Recording, 1)]
    public partial class VerifyQueryStoreOption : ITestModule
    {
        /// <summary>
        /// Holds an instance of the SQLDMTestAutomationRepository repository.
        /// </summary>
        public static SQLDMTestAutomationRepository repo = SQLDMTestAutomationRepository.Instance;

        static VerifyQueryStoreOption instance = new VerifyQueryStoreOption();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public VerifyQueryStoreOption()
        {
            Checked = "";
            NewVariable = "true";
            NewVariable1 = "false";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static VerifyQueryStoreOption Instance
        {
            get { return instance; }
        }

#region Variables

        string _Checked;

        /// <summary>
        /// Gets or sets the value of variable Checked.
        /// </summary>
        [TestVariable("cef3d19e-8467-4800-a45a-06cac0a950f3")]
        public string Checked
        {
            get { return _Checked; }
            set { _Checked = value; }
        }

        string _NewVariable;

        /// <summary>
        /// Gets or sets the value of variable NewVariable.
        /// </summary>
        [TestVariable("ecbf2b68-dfe7-4aed-95e3-95817be99f9f")]
        public string NewVariable
        {
            get { return _NewVariable; }
            set { _NewVariable = value; }
        }

        string _NewVariable1;

        /// <summary>
        /// Gets or sets the value of variable NewVariable1.
        /// </summary>
        [TestVariable("b2b279f9-3bc3-440b-aee9-a255f3631049")]
        public string NewVariable1
        {
            get { return _NewVariable1; }
            set { _NewVariable1 = value; }
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

            Report.Log(ReportLevel.Info, "Wait", "Waiting 5s to exist. Associated repository item: 'MonitoredSqlServerInstancePropertiesDial.WaitMonitoring'", repo.MonitoredSqlServerInstancePropertiesDial.WaitMonitoringInfo, new ActionTimeout(5000), new RecordItemIndex(0));
            repo.MonitoredSqlServerInstancePropertiesDial.WaitMonitoringInfo.WaitForExists(5000);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'MonitoredSqlServerInstancePropertiesDial.WaitMonitoring' at Center.", repo.MonitoredSqlServerInstancePropertiesDial.WaitMonitoringInfo, new RecordItemIndex(1));
            repo.MonitoredSqlServerInstancePropertiesDial.WaitMonitoring.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'MonitoredSqlServerInstancePropertiesDial.WaitMonitoring' at Center.", repo.MonitoredSqlServerInstancePropertiesDial.WaitMonitoringInfo, new RecordItemIndex(2));
            repo.MonitoredSqlServerInstancePropertiesDial.WaitMonitoring.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'MonitoredSqlServerInstancePropertiesDial.UseExtendedEvents' at Center.", repo.MonitoredSqlServerInstancePropertiesDial.UseExtendedEventsInfo, new RecordItemIndex(3));
            repo.MonitoredSqlServerInstancePropertiesDial.UseExtendedEvents.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Checked='true') on item 'MonitoredSqlServerInstancePropertiesDial.UseExtendedEvents'.", repo.MonitoredSqlServerInstancePropertiesDial.UseExtendedEventsInfo, new RecordItemIndex(4));
            Validate.AttributeEqual(repo.MonitoredSqlServerInstancePropertiesDial.UseExtendedEventsInfo, "Checked", "true");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'MonitoredSqlServerInstancePropertiesDial.UseQueryStore' at Center.", repo.MonitoredSqlServerInstancePropertiesDial.UseQueryStoreInfo, new RecordItemIndex(5));
            repo.MonitoredSqlServerInstancePropertiesDial.UseQueryStore.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Checked='false') on item 'MonitoredSqlServerInstancePropertiesDial.UseQueryStore'.", repo.MonitoredSqlServerInstancePropertiesDial.UseQueryStoreInfo, new RecordItemIndex(6));
            Validate.AttributeEqual(repo.MonitoredSqlServerInstancePropertiesDial.UseQueryStoreInfo, "Checked", "false");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'MonitoredSqlServerInstancePropertiesDial.Cancle' at Center.", repo.MonitoredSqlServerInstancePropertiesDial.CancleInfo, new RecordItemIndex(7));
            repo.MonitoredSqlServerInstancePropertiesDial.Cancle.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Delay", "Waiting for 1s.", new RecordItemIndex(8));
            Delay.Duration(1000, false);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'MonitoredSqlServerInstancePropertiesDial.Cancle' at Center.", repo.MonitoredSqlServerInstancePropertiesDial.CancleInfo, new RecordItemIndex(9));
            repo.MonitoredSqlServerInstancePropertiesDial.Cancle.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'IderaSQLDiagnosticManagerSQLdmRepo.CloseMainWindow' at Center.", repo.IderaSQLDiagnosticManagerSQLdmRepo.CloseMainWindowInfo, new RecordItemIndex(10));
            repo.IderaSQLDiagnosticManagerSQLdmRepo.CloseMainWindow.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'IderaSQLDiagnosticManagerSQLdmRepo.CloseMainWindow' at Center.", repo.IderaSQLDiagnosticManagerSQLdmRepo.CloseMainWindowInfo, new RecordItemIndex(11));
            repo.IderaSQLDiagnosticManagerSQLdmRepo.CloseMainWindow.Click();
            Delay.Milliseconds(200);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
