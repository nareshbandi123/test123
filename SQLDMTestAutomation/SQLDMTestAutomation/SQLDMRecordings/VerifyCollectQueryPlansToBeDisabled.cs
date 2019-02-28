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
    ///The VerifyCollectQueryPlansToBeDisabled recording.
    /// </summary>
    [TestModule("79464ac0-d913-4fe2-8642-ef9c687ae205", ModuleType.Recording, 1)]
    public partial class VerifyCollectQueryPlansToBeDisabled : ITestModule
    {
        /// <summary>
        /// Holds an instance of the SQLDMTestAutomation.SQLDMTestAutomationRepository repository.
        /// </summary>
        public static SQLDMTestAutomation.SQLDMTestAutomationRepository repo = SQLDMTestAutomation.SQLDMTestAutomationRepository.Instance;

        static VerifyCollectQueryPlansToBeDisabled instance = new VerifyCollectQueryPlansToBeDisabled();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public VerifyCollectQueryPlansToBeDisabled()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static VerifyCollectQueryPlansToBeDisabled Instance
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

            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'SQLDM.MonitoredSqlServerInstancePropertiesDial.TableLayoutPanel19.RButtonUseTrace' at Center.", repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.TableLayoutPanel19.RButtonUseTraceInfo, new RecordItemIndex(0));
            repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.TableLayoutPanel19.RButtonUseTrace.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Enabled='False') on item 'SQLDM.MonitoredSqlServerInstancePropertiesDial.TableLayoutPanel19.ChkCollectQueryPlans'.", repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.TableLayoutPanel19.ChkCollectQueryPlansInfo, new RecordItemIndex(1));
            Validate.AttributeEqual(repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.TableLayoutPanel19.ChkCollectQueryPlansInfo, "Enabled", "False");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Enabled='False') on item 'SQLDM.MonitoredSqlServerInstancePropertiesDial.TableLayoutPanel19.ChkCollectEstimatedQueryPlans'.", repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.TableLayoutPanel19.ChkCollectEstimatedQueryPlansInfo, new RecordItemIndex(2));
            Validate.AttributeEqual(repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.TableLayoutPanel19.ChkCollectEstimatedQueryPlansInfo, "Enabled", "False");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Invoke action", "Invoking Focus() on item 'SQLDM.MonitoredSqlServerInstancePropertiesDial.OkButton'.", repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.OkButtonInfo, new RecordItemIndex(3));
            repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.OkButton.Focus();
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence '{ENTER}' with focus on 'SQLDM.MonitoredSqlServerInstancePropertiesDial.OkButton'.", repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.OkButtonInfo, new RecordItemIndex(4));
            repo.SQLDM.MonitoredSqlServerInstancePropertiesDial.OkButton.PressKeys("{ENTER}");
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
