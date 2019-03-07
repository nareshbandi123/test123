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
    ///The Verifyquerydatadefaultcollectionoption recording.
    /// </summary>
    [TestModule("b459d5ec-28a3-4b56-8f55-f7e6a1b623bb", ModuleType.Recording, 1)]
    public partial class Verifyquerydatadefaultcollectionoption : ITestModule
    {
        /// <summary>
        /// Holds an instance of the SQLDMTestAutomation.SQLDMTestAutomationRepository repository.
        /// </summary>
        public static SQLDMTestAutomation.SQLDMTestAutomationRepository repo = SQLDMTestAutomation.SQLDMTestAutomationRepository.Instance;

        static Verifyquerydatadefaultcollectionoption instance = new Verifyquerydatadefaultcollectionoption();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public Verifyquerydatadefaultcollectionoption()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static Verifyquerydatadefaultcollectionoption Instance
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

            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.Server2005' at Center.", repo.SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.Server2005Info, new RecordItemIndex(0));
            repo.SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.Server2005.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Middle Click item 'SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.Server2005' at Center.", repo.SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.Server2005Info, new RecordItemIndex(1));
            repo.SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.Server2005.Click(System.Windows.Forms.MouseButtons.Middle);
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Right Click item 'SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.Server2005' at Center.", repo.SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.Server2005Info, new RecordItemIndex(2));
            repo.SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.Server2005.Click(System.Windows.Forms.MouseButtons.Right);
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'SQLDM.SQLdmDesktopClient.Properties' at Center.", repo.SQLDM.SQLdmDesktopClient.PropertiesInfo, new RecordItemIndex(3));
            repo.SQLDM.SQLdmDesktopClient.Properties.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'SQLDM.SQLdmDesktopClient.Properties' at Center.", repo.SQLDM.SQLdmDesktopClient.PropertiesInfo, new RecordItemIndex(4));
            repo.SQLDM.SQLdmDesktopClient.Properties.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Delay", "Waiting for 1s.", new RecordItemIndex(5));
            Delay.Duration(1000, false);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'SQLDM.MonitoredSqlServerInstancePropertiesDial.QueryMonitor' at Center.", repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.QueryMonitorInfo, new RecordItemIndex(6));
            repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.QueryMonitor.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'SQLDM.MonitoredSqlServerInstancePropertiesDial.QueryMonitor' at Center.", repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.QueryMonitorInfo, new RecordItemIndex(7));
            repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.QueryMonitor.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'SQLDM.MonitoredSqlServerInstancePropertiesDial.EnableQueryMonitorTraceCheckBox' at Center.", repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.EnableQueryMonitorTraceCheckBoxInfo, new RecordItemIndex(8));
            repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.EnableQueryMonitorTraceCheckBox.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'SQLDM.MonitoredSqlServerInstancePropertiesDial.EnableQueryMonitorTraceCheckBox' at Center.", repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.EnableQueryMonitorTraceCheckBoxInfo, new RecordItemIndex(9));
            repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.EnableQueryMonitorTraceCheckBox.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'SQLDM.MonitoredSqlServerInstancePropertiesDial.TableLayoutPanel19.CollectQueryDataUsingSQLTrace' at Center.", repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.TableLayoutPanel19.CollectQueryDataUsingSQLTraceInfo, new RecordItemIndex(10));
            repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.TableLayoutPanel19.CollectQueryDataUsingSQLTrace.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Checked='true') on item 'SQLDM.MonitoredSqlServerInstancePropertiesDial.TableLayoutPanel19.CollectQueryDataUsingSQLTrace'.", repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.TableLayoutPanel19.CollectQueryDataUsingSQLTraceInfo, new RecordItemIndex(11));
            Validate.AttributeEqual(repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.TableLayoutPanel19.CollectQueryDataUsingSQLTraceInfo, "Checked", "true");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'SQLDM.MonitoredSqlServerInstancePropertiesDial.Cancle' at Center.", repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.CancleInfo, new RecordItemIndex(12));
            repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.Cancle.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Delay", "Waiting for 1s.", new RecordItemIndex(13));
            Delay.Duration(1000, false);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'SQLDM.MonitoredSqlServerInstancePropertiesDial.Cancle' at Center.", repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.CancleInfo, new RecordItemIndex(14));
            repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.Cancle.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.Server2008' at Center.", repo.SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.Server2008Info, new RecordItemIndex(15));
            repo.SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.Server2008.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Middle Click item 'SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.Server2008' at Center.", repo.SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.Server2008Info, new RecordItemIndex(16));
            repo.SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.Server2008.Click(System.Windows.Forms.MouseButtons.Middle);
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Right Click item 'SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.Server2008' at Center.", repo.SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.Server2008Info, new RecordItemIndex(17));
            repo.SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.Server2008.Click(System.Windows.Forms.MouseButtons.Right);
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'SQLDM.SQLdmDesktopClient.Properties' at Center.", repo.SQLDM.SQLdmDesktopClient.PropertiesInfo, new RecordItemIndex(18));
            repo.SQLDM.SQLdmDesktopClient.Properties.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'SQLDM.SQLdmDesktopClient.Properties' at Center.", repo.SQLDM.SQLdmDesktopClient.PropertiesInfo, new RecordItemIndex(19));
            repo.SQLDM.SQLdmDesktopClient.Properties.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Delay", "Waiting for 1s.", new RecordItemIndex(20));
            Delay.Duration(1000, false);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'SQLDM.MonitoredSqlServerInstancePropertiesDial.QueryMonitor' at Center.", repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.QueryMonitorInfo, new RecordItemIndex(21));
            repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.QueryMonitor.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'SQLDM.MonitoredSqlServerInstancePropertiesDial.QueryMonitor' at Center.", repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.QueryMonitorInfo, new RecordItemIndex(22));
            repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.QueryMonitor.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'SQLDM.MonitoredSqlServerInstancePropertiesDial.EnableQueryMonitorTraceCheckBox' at Center.", repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.EnableQueryMonitorTraceCheckBoxInfo, new RecordItemIndex(23));
            repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.EnableQueryMonitorTraceCheckBox.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'SQLDM.MonitoredSqlServerInstancePropertiesDial.EnableQueryMonitorTraceCheckBox' at Center.", repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.EnableQueryMonitorTraceCheckBoxInfo, new RecordItemIndex(24));
            repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.EnableQueryMonitorTraceCheckBox.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'SQLDM.MonitoredSqlServerInstancePropertiesDial.TableLayoutPanel19.CollectQueryDataUsingExtendedEvents' at Center.", repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.TableLayoutPanel19.CollectQueryDataUsingExtendedEventsInfo, new RecordItemIndex(25));
            repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.TableLayoutPanel19.CollectQueryDataUsingExtendedEvents.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Checked='true') on item 'SQLDM.MonitoredSqlServerInstancePropertiesDial.TableLayoutPanel19.CollectQueryDataUsingExtendedEvents'.", repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.TableLayoutPanel19.CollectQueryDataUsingExtendedEventsInfo, new RecordItemIndex(26));
            Validate.AttributeEqual(repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.TableLayoutPanel19.CollectQueryDataUsingExtendedEventsInfo, "Checked", "true");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'SQLDM.MonitoredSqlServerInstancePropertiesDial.Cancle' at Center.", repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.CancleInfo, new RecordItemIndex(27));
            repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.Cancle.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'SQLDM.MonitoredSqlServerInstancePropertiesDial.Cancle' at Center.", repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.CancleInfo, new RecordItemIndex(28));
            repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.Cancle.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.Server2016' at Center.", repo.SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.Server2016Info, new RecordItemIndex(29));
            repo.SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.Server2016.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Right Click item 'SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.Server2016' at Center.", repo.SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.Server2016Info, new RecordItemIndex(30));
            repo.SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.Server2016.Click(System.Windows.Forms.MouseButtons.Right);
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'SQLDM.SQLdmDesktopClient.Properties' at Center.", repo.SQLDM.SQLdmDesktopClient.PropertiesInfo, new RecordItemIndex(31));
            repo.SQLDM.SQLdmDesktopClient.Properties.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'SQLDM.SQLdmDesktopClient.Properties' at Center.", repo.SQLDM.SQLdmDesktopClient.PropertiesInfo, new RecordItemIndex(32));
            repo.SQLDM.SQLdmDesktopClient.Properties.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Delay", "Waiting for 1s.", new RecordItemIndex(33));
            Delay.Duration(1000, false);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'SQLDM.MonitoredSqlServerInstancePropertiesDial.QueryMonitor' at Center.", repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.QueryMonitorInfo, new RecordItemIndex(34));
            repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.QueryMonitor.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'SQLDM.MonitoredSqlServerInstancePropertiesDial.QueryMonitor' at Center.", repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.QueryMonitorInfo, new RecordItemIndex(35));
            repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.QueryMonitor.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'SQLDM.MonitoredSqlServerInstancePropertiesDial.EnableQueryMonitorTraceCheckBox' at Center.", repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.EnableQueryMonitorTraceCheckBoxInfo, new RecordItemIndex(36));
            repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.EnableQueryMonitorTraceCheckBox.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'SQLDM.MonitoredSqlServerInstancePropertiesDial.EnableQueryMonitorTraceCheckBox' at Center.", repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.EnableQueryMonitorTraceCheckBoxInfo, new RecordItemIndex(37));
            repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.EnableQueryMonitorTraceCheckBox.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'SQLDM.MonitoredSqlServerInstancePropertiesDial.TableLayoutPanel19.CollectQueryDataUsingExtendedEvents' at Center.", repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.TableLayoutPanel19.CollectQueryDataUsingExtendedEventsInfo, new RecordItemIndex(38));
            repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.TableLayoutPanel19.CollectQueryDataUsingExtendedEvents.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Checked='true') on item 'SQLDM.MonitoredSqlServerInstancePropertiesDial.TableLayoutPanel19.CollectQueryDataUsingExtendedEvents'.", repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.TableLayoutPanel19.CollectQueryDataUsingExtendedEventsInfo, new RecordItemIndex(39));
            Validate.AttributeEqual(repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.TableLayoutPanel19.CollectQueryDataUsingExtendedEventsInfo, "Checked", "true");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'SQLDM.MonitoredSqlServerInstancePropertiesDial.Cancle' at Center.", repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.CancleInfo, new RecordItemIndex(40));
            repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.Cancle.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'SQLDM.MonitoredSqlServerInstancePropertiesDial.Cancle' at Center.", repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.CancleInfo, new RecordItemIndex(41));
            repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.Cancle.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.CloseMainWindow' at Center.", repo.SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.CloseMainWindowInfo, new RecordItemIndex(42));
            repo.SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.CloseMainWindow.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.CloseMainWindow' at Center.", repo.SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.CloseMainWindowInfo, new RecordItemIndex(43));
            repo.SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.CloseMainWindow.Click();
            Delay.Milliseconds(200);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
