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
    ///The PreconditionQueryMonitor recording.
    /// </summary>
    [TestModule("0291cea1-dc2d-4c65-bd36-64defc99dc49", ModuleType.Recording, 1)]
    public partial class PreconditionQueryMonitor : ITestModule
    {
        /// <summary>
        /// Holds an instance of the SQLDMTestAutomation.SQLDMTestAutomationRepository repository.
        /// </summary>
        public static SQLDMTestAutomation.SQLDMTestAutomationRepository repo = SQLDMTestAutomation.SQLDMTestAutomationRepository.Instance;

        static PreconditionQueryMonitor instance = new PreconditionQueryMonitor();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public PreconditionQueryMonitor()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static PreconditionQueryMonitor Instance
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

            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'SQLdmDesktopClient.QueryMonitorLeftPane' at Center.", repo.SQLdmDesktopClient.QueryMonitorLeftPaneInfo, new RecordItemIndex(0));
            repo.SQLdmDesktopClient.QueryMonitorLeftPane.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'SQLdmDesktopClient.QueryMonitorLeftPane' at Center.", repo.SQLdmDesktopClient.QueryMonitorLeftPaneInfo, new RecordItemIndex(1));
            repo.SQLdmDesktopClient.QueryMonitorLeftPane.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Delay", "Waiting for 2s.", new RecordItemIndex(2));
            Delay.Duration(2000, false);
            
            CommonMethods.ClickCheckBox(repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.EnableQueryMonitorTraceCheckBoxInfo, ValueConverter.ArgumentFromString<bool>("requireChecked", "True"));
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'SQLDM.MonitoredSqlServerInstancePropertiesDial.QueryMilliseconds' at Center.", repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.QueryMillisecondsInfo, new RecordItemIndex(4));
            repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.QueryMilliseconds.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key 'Ctrl+A' Press with focus on 'SQLDM.MonitoredSqlServerInstancePropertiesDial.QueryMilliseconds'.", repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.QueryMillisecondsInfo, new RecordItemIndex(5));
            Keyboard.PrepareFocus(repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.QueryMilliseconds);
            Keyboard.Press(System.Windows.Forms.Keys.A | System.Windows.Forms.Keys.Control, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Set value", "Setting attribute Text to '500' on item 'SQLDM.MonitoredSqlServerInstancePropertiesDial.QueryMilliseconds'.", repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.QueryMillisecondsInfo, new RecordItemIndex(6));
            repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.QueryMilliseconds.Element.SetAttributeValue("Text", "500");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Invoke action", "Invoking EnsureVisible() on item 'SQLDM.MonitoredSqlServerInstancePropertiesDial.AdvancedOptionsButton'.", repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.AdvancedOptionsButtonInfo, new RecordItemIndex(7));
            repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.AdvancedOptionsButton.EnsureVisible();
            Delay.Milliseconds(0);
            
            //Report.Log(ReportLevel.Info, "Invoke action", "Invoking Press() on item 'SQLDM.MonitoredSqlServerInstancePropertiesDial.AdvancedOptionsButton'.", repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.AdvancedOptionsButtonInfo, new RecordItemIndex(8));
            //repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.AdvancedOptionsButton.Press();
            //Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence '{ENTER}' with focus on 'SQLDM.MonitoredSqlServerInstancePropertiesDial.AdvancedOptionsButton'.", repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.AdvancedOptionsButtonInfo, new RecordItemIndex(9));
            repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.AdvancedOptionsButton.PressKeys("{ENTER}");
            Delay.Milliseconds(0);
            
            CommonMethods.ClickCheckBox(repo.AdvancedQueryFilterConfigurationDialog.ChkExcludeDMInfo, ValueConverter.ArgumentFromString<bool>("requireChecked", "False"));
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Invoke action", "Invoking Press() on item 'AdvancedQueryFilterConfigurationDialog.OkButton'.", repo.AdvancedQueryFilterConfigurationDialog.OkButtonInfo, new RecordItemIndex(11));
            repo.AdvancedQueryFilterConfigurationDialog.OkButton.Press();
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
