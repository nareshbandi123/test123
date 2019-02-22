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
    ///The CloseMonitoredSqlServerWindow recording.
    /// </summary>
    [TestModule("10938416-b5ae-4e32-9f33-2396104249f6", ModuleType.Recording, 1)]
    public partial class CloseMonitoredSqlServerWindow : ITestModule
    {
        /// <summary>
        /// Holds an instance of the SQLDMTestAutomationRepository repository.
        /// </summary>
        public static SQLDMTestAutomationRepository repo = SQLDMTestAutomationRepository.Instance;

        static CloseMonitoredSqlServerWindow instance = new CloseMonitoredSqlServerWindow();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CloseMonitoredSqlServerWindow()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static CloseMonitoredSqlServerWindow Instance
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

            //Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Move item 'MonitoredSqlServerInstancePropertiesDial.Close' at Center.", repo.MonitoredSqlServerInstancePropertiesDial.CloseInfo, new RecordItemIndex(0));
            //repo.MonitoredSqlServerInstancePropertiesDial.Close.MoveTo();
            //Delay.Milliseconds(200);
            
            //Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'MonitoredSqlServerInstancePropertiesDial.Close' at Center.", repo.MonitoredSqlServerInstancePropertiesDial.CloseInfo, new RecordItemIndex(1));
            //repo.MonitoredSqlServerInstancePropertiesDial.Close.Click();
            //Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Invoke action", "Invoking Press() on item 'MonitoredSqlServerInstancePropertiesDial.Close'.", repo.MonitoredSqlServerInstancePropertiesDial.CloseInfo, new RecordItemIndex(2));
            repo.MonitoredSqlServerInstancePropertiesDial.Close.Press();
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Delay", "Waiting for 2s.", new RecordItemIndex(3));
            Delay.Duration(2000, false);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
