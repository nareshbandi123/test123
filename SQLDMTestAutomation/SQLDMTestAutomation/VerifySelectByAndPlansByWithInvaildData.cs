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
    ///The VerifySelectByAndPlansByWithInvaildData recording.
    /// </summary>
    [TestModule("3317ce09-3f34-4b64-ad5c-42f441333426", ModuleType.Recording, 1)]
    public partial class VerifySelectByAndPlansByWithInvaildData : ITestModule
    {
        /// <summary>
        /// Holds an instance of the SQLDMTestAutomationRepository repository.
        /// </summary>
        public static SQLDMTestAutomationRepository repo = SQLDMTestAutomationRepository.Instance;

        static VerifySelectByAndPlansByWithInvaildData instance = new VerifySelectByAndPlansByWithInvaildData();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public VerifySelectByAndPlansByWithInvaildData()
        {
            durationCombo = "";
            EnabledValue = "";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static VerifySelectByAndPlansByWithInvaildData Instance
        {
            get { return instance; }
        }

#region Variables

        string _durationCombo;

        /// <summary>
        /// Gets or sets the value of variable durationCombo.
        /// </summary>
        [TestVariable("afd11ac8-affc-463c-8306-416cdad6af45")]
        public string durationCombo
        {
            get { return _durationCombo; }
            set { _durationCombo = value; }
        }

        string _EnabledValue;

        /// <summary>
        /// Gets or sets the value of variable EnabledValue.
        /// </summary>
        [TestVariable("f20da09f-ff5e-4d16-a63e-11bd7aae25f0")]
        public string EnabledValue
        {
            get { return _EnabledValue; }
            set { _EnabledValue = value; }
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

            Report.Log(ReportLevel.Info, "Invoke action", "Invoking EnsureVisible() on item 'MonitoredSqlServerInstancePropertiesDial.UpDownEdit'.", repo.MonitoredSqlServerInstancePropertiesDial.UpDownEditInfo, new RecordItemIndex(0));
            repo.MonitoredSqlServerInstancePropertiesDial.UpDownEdit.EnsureVisible();
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Enabled='True') on item 'MonitoredSqlServerInstancePropertiesDial.UpDownEdit'.", repo.MonitoredSqlServerInstancePropertiesDial.UpDownEditInfo, new RecordItemIndex(1));
            Validate.AttributeEqual(repo.MonitoredSqlServerInstancePropertiesDial.UpDownEditInfo, "Enabled", "True");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key 'Ctrl+A' Press with focus on 'MonitoredSqlServerInstancePropertiesDial.UpDownEdit'.", repo.MonitoredSqlServerInstancePropertiesDial.UpDownEditInfo, new RecordItemIndex(2));
            Keyboard.PrepareFocus(repo.MonitoredSqlServerInstancePropertiesDial.UpDownEdit);
            Keyboard.Press(System.Windows.Forms.Keys.A | System.Windows.Forms.Keys.Control, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence '-1' with focus on 'MonitoredSqlServerInstancePropertiesDial.UpDownEdit'.", repo.MonitoredSqlServerInstancePropertiesDial.UpDownEditInfo, new RecordItemIndex(3));
            repo.MonitoredSqlServerInstancePropertiesDial.UpDownEdit.PressKeys("-1");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Invoke action", "Invoking Focus() on item 'MonitoredSqlServerInstancePropertiesDial.OkButton'.", repo.MonitoredSqlServerInstancePropertiesDial.OkButtonInfo, new RecordItemIndex(4));
            repo.MonitoredSqlServerInstancePropertiesDial.OkButton.Focus();
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence '{ENTER}' with focus on 'MonitoredSqlServerInstancePropertiesDial.OkButton'.", repo.MonitoredSqlServerInstancePropertiesDial.OkButtonInfo, new RecordItemIndex(5));
            repo.MonitoredSqlServerInstancePropertiesDial.OkButton.PressKeys("{ENTER}");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Delay", "Waiting for 2s.", new RecordItemIndex(6));
            Delay.Duration(2000, false);
            
            Report.Log(ReportLevel.Info, "Wait", "Waiting 40s to exist. Associated repository item: 'IderaSQLDiagnosticManagerSQLdmRepo.ConfigureQueryMonitor'", repo.IderaSQLDiagnosticManagerSQLdmRepo.ConfigureQueryMonitorInfo, new ActionTimeout(40000), new RecordItemIndex(7));
            repo.IderaSQLDiagnosticManagerSQLdmRepo.ConfigureQueryMonitorInfo.WaitForExists(40000);
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence '{ENTER}' with focus on 'IderaSQLDiagnosticManagerSQLdmRepo.ConfigureQueryMonitor'.", repo.IderaSQLDiagnosticManagerSQLdmRepo.ConfigureQueryMonitorInfo, new RecordItemIndex(8));
            repo.IderaSQLDiagnosticManagerSQLdmRepo.ConfigureQueryMonitor.PressKeys("{ENTER}");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Invoke action", "Invoking EnsureVisible() on item 'MonitoredSqlServerInstancePropertiesDial.UpDownEdit'.", repo.MonitoredSqlServerInstancePropertiesDial.UpDownEditInfo, new RecordItemIndex(9));
            repo.MonitoredSqlServerInstancePropertiesDial.UpDownEdit.EnsureVisible();
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Text='1') on item 'MonitoredSqlServerInstancePropertiesDial.UpDownEdit'.", repo.MonitoredSqlServerInstancePropertiesDial.UpDownEditInfo, new RecordItemIndex(10));
            Validate.AttributeEqual(repo.MonitoredSqlServerInstancePropertiesDial.UpDownEditInfo, "Text", "1");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key 'Ctrl+A' Press with focus on 'MonitoredSqlServerInstancePropertiesDial.UpDownEdit'.", repo.MonitoredSqlServerInstancePropertiesDial.UpDownEditInfo, new RecordItemIndex(11));
            Keyboard.PrepareFocus(repo.MonitoredSqlServerInstancePropertiesDial.UpDownEdit);
            Keyboard.Press(System.Windows.Forms.Keys.A | System.Windows.Forms.Keys.Control, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Invoke action", "Invoking Paste('abc') on item 'MonitoredSqlServerInstancePropertiesDial.UpDownEdit'.", repo.MonitoredSqlServerInstancePropertiesDial.UpDownEditInfo, new RecordItemIndex(12));
            repo.MonitoredSqlServerInstancePropertiesDial.UpDownEdit.Element.InvokeActionWithText("Paste", "abc");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Invoke action", "Invoking Focus() on item 'MonitoredSqlServerInstancePropertiesDial.OkButton'.", repo.MonitoredSqlServerInstancePropertiesDial.OkButtonInfo, new RecordItemIndex(13));
            repo.MonitoredSqlServerInstancePropertiesDial.OkButton.Focus();
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence '{ENTER}' with focus on 'MonitoredSqlServerInstancePropertiesDial.OkButton'.", repo.MonitoredSqlServerInstancePropertiesDial.OkButtonInfo, new RecordItemIndex(14));
            repo.MonitoredSqlServerInstancePropertiesDial.OkButton.PressKeys("{ENTER}");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Delay", "Waiting for 2s.", new RecordItemIndex(15));
            Delay.Duration(2000, false);
            
            Report.Log(ReportLevel.Info, "Wait", "Waiting 50s to exist. Associated repository item: 'IderaSQLDiagnosticManagerSQLdmRepo.ConfigureQueryMonitor'", repo.IderaSQLDiagnosticManagerSQLdmRepo.ConfigureQueryMonitorInfo, new ActionTimeout(50000), new RecordItemIndex(16));
            repo.IderaSQLDiagnosticManagerSQLdmRepo.ConfigureQueryMonitorInfo.WaitForExists(50000);
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence '{ENTER}' with focus on 'IderaSQLDiagnosticManagerSQLdmRepo.ConfigureQueryMonitor'.", repo.IderaSQLDiagnosticManagerSQLdmRepo.ConfigureQueryMonitorInfo, new RecordItemIndex(17));
            repo.IderaSQLDiagnosticManagerSQLdmRepo.ConfigureQueryMonitor.PressKeys("{ENTER}");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Invoke action", "Invoking EnsureVisible() on item 'MonitoredSqlServerInstancePropertiesDial.UpDownEdit'.", repo.MonitoredSqlServerInstancePropertiesDial.UpDownEditInfo, new RecordItemIndex(18));
            repo.MonitoredSqlServerInstancePropertiesDial.UpDownEdit.EnsureVisible();
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Text='1') on item 'MonitoredSqlServerInstancePropertiesDial.UpDownEdit'.", repo.MonitoredSqlServerInstancePropertiesDial.UpDownEditInfo, new RecordItemIndex(19));
            Validate.AttributeEqual(repo.MonitoredSqlServerInstancePropertiesDial.UpDownEditInfo, "Text", "1");
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
