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
    ///The AddServerAndVerifyQueryPlanOptionEnabled recording.
    /// </summary>
    [TestModule("0d45aeec-90f8-4043-a0cf-91a511febd51", ModuleType.Recording, 1)]
    public partial class AddServerAndVerifyQueryPlanOptionEnabled : ITestModule
    {
        /// <summary>
        /// Holds an instance of the SQLDMTestAutomationRepository repository.
        /// </summary>
        public static SQLDMTestAutomationRepository repo = SQLDMTestAutomationRepository.Instance;

        static AddServerAndVerifyQueryPlanOptionEnabled instance = new AddServerAndVerifyQueryPlanOptionEnabled();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public AddServerAndVerifyQueryPlanOptionEnabled()
        {
            Server1 = "JS-XW7S9\\SQL2008";
            Server2 = "JS-XW7S7\\SQL2008";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static AddServerAndVerifyQueryPlanOptionEnabled Instance
        {
            get { return instance; }
        }

#region Variables

        string _Server1;

        /// <summary>
        /// Gets or sets the value of variable Server1.
        /// </summary>
        [TestVariable("b7fbac2d-ddd1-480c-a5b8-8a7f98bffefb")]
        public string Server1
        {
            get { return _Server1; }
            set { _Server1 = value; }
        }

        string _Server2;

        /// <summary>
        /// Gets or sets the value of variable Server2.
        /// </summary>
        [TestVariable("cdd259bc-3721-4617-adf6-6e9987ddebe1")]
        public string Server2
        {
            get { return _Server2; }
            set { _Server2 = value; }
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

            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'IderaSQLDiagnosticManagerSQLdmRepo.File' at Center.", repo.IderaSQLDiagnosticManagerSQLdmRepo.FileInfo, new RecordItemIndex(0));
            repo.IderaSQLDiagnosticManagerSQLdmRepo.File.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'SomeContextMenu.ManageServers' at Center.", repo.SomeContextMenu.ManageServersInfo, new RecordItemIndex(1));
            repo.SomeContextMenu.ManageServers.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'SomeContextMenu.ManageServers' at Center.", repo.SomeContextMenu.ManageServersInfo, new RecordItemIndex(2));
            repo.SomeContextMenu.ManageServers.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Delay", "Waiting for 1s.", new RecordItemIndex(3));
            Delay.Duration(1000, false);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'ManageServersDialog.AddButton' at Center.", repo.ManageServersDialog.AddButtonInfo, new RecordItemIndex(4));
            repo.ManageServersDialog.AddButton.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'ManageServersDialog.AddButton' at Center.", repo.ManageServersDialog.AddButtonInfo, new RecordItemIndex(5));
            repo.ManageServersDialog.AddButton.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'AddServersWizard.NextButton' at Center.", repo.AddServersWizard.NextButtonInfo, new RecordItemIndex(6));
            repo.AddServersWizard.NextButton.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'AddServersWizard.NextButton' at Center.", repo.AddServersWizard.NextButtonInfo, new RecordItemIndex(7));
            repo.AddServersWizard.NextButton.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'AddServersWizard.NextButton' at Center.", repo.AddServersWizard.NextButtonInfo, new RecordItemIndex(8));
            repo.AddServersWizard.NextButton.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'AddServersWizard.NextButton' at Center.", repo.AddServersWizard.NextButtonInfo, new RecordItemIndex(9));
            repo.AddServersWizard.NextButton.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Set value", "Setting attribute Text to '$Server1' on item 'AddServersWizard.Text'.", repo.AddServersWizard.TextInfo, new RecordItemIndex(10));
            repo.AddServersWizard.Text.Element.SetAttributeValue("Text", Server1);
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence '{ENTER}' with focus on 'AddServersWizard.Text'.", repo.AddServersWizard.TextInfo, new RecordItemIndex(11));
            repo.AddServersWizard.Text.PressKeys("{ENTER}");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Set value", "Setting attribute Text to '$Server2' on item 'AddServersWizard.Text'.", repo.AddServersWizard.TextInfo, new RecordItemIndex(12));
            repo.AddServersWizard.Text.Element.SetAttributeValue("Text", Server2);
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence '{ENTER}' with focus on 'AddServersWizard.Text'.", repo.AddServersWizard.TextInfo, new RecordItemIndex(13));
            repo.AddServersWizard.Text.PressKeys("{ENTER}");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'AddServersWizard.NextButton' at Center.", repo.AddServersWizard.NextButtonInfo, new RecordItemIndex(14));
            repo.AddServersWizard.NextButton.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'AddServersWizard.NextButton' at Center.", repo.AddServersWizard.NextButtonInfo, new RecordItemIndex(15));
            repo.AddServersWizard.NextButton.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'AddServersWizard.EnableQueryMonitorTraceCheckBox' at Center.", repo.AddServersWizard.EnableQueryMonitorTraceCheckBoxInfo, new RecordItemIndex(16));
            repo.AddServersWizard.EnableQueryMonitorTraceCheckBox.MoveTo();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'AddServersWizard.EnableQueryMonitorTraceCheckBox' at Center.", repo.AddServersWizard.EnableQueryMonitorTraceCheckBoxInfo, new RecordItemIndex(17));
            repo.AddServersWizard.EnableQueryMonitorTraceCheckBox.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Text='Duration (milliseconds)') on item 'AddServersWizard.PlansBy'.", repo.AddServersWizard.PlansByInfo, new RecordItemIndex(18));
            Validate.AttributeEqual(repo.AddServersWizard.PlansByInfo, "Text", "Duration (milliseconds)");
            Delay.Milliseconds(0);
            
            //Report.Log(ReportLevel.Info, "Invoke action", "Invoking Press() on item 'AddServersWizard.Cancel'.", repo.AddServersWizard.CancelInfo, new RecordItemIndex(19));
            //repo.AddServersWizard.Cancel.Press();
            //Delay.Milliseconds(0);
            
            //Report.Log(ReportLevel.Info, "Delay", "Waiting for 1s.", new RecordItemIndex(20));
            //Delay.Duration(1000, false);
            
            //Report.Log(ReportLevel.Info, "Invoke action", "Invoking Press() on item 'ManageServersDialog.CancelButton'.", repo.ManageServersDialog.CancelButtonInfo, new RecordItemIndex(21));
            //repo.ManageServersDialog.CancelButton.Press();
            //Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
