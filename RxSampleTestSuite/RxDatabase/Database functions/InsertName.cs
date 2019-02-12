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

namespace RxDatabase.Database_functions
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The InsertName recording.
    /// </summary>
    [TestModule("5dbc6118-c253-45cd-9662-b2b1649e6373", ModuleType.Recording, 1)]
    public partial class InsertName : ITestModule
    {
        /// <summary>
        /// Holds an instance of the global::RxDatabase.RxDatabaseRepository repository.
        /// </summary>
        public static global::RxDatabase.RxDatabaseRepository repo = global::RxDatabase.RxDatabaseRepository.Instance;

        static InsertName instance = new InsertName();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public InsertName()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static InsertName Instance
        {
            get { return instance; }
        }

#region Variables

#endregion

        /// <summary>
        /// Starts the replay of the static recording <see cref="Instance"/>.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("Ranorex", "8.3")]
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
        [System.CodeDom.Compiler.GeneratedCode("Ranorex", "8.3")]
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.00;

            Init();

            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'RxMainFrame.RxTabStandard.FirstName' at 14;7.", repo.RxMainFrame.RxTabStandard.FirstNameInfo, new RecordItemIndex(0));
            repo.RxMainFrame.RxTabStandard.FirstName.Click("14;7");
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence 'John' with focus on 'RxMainFrame.RxTabStandard.FirstName'.", repo.RxMainFrame.RxTabStandard.FirstNameInfo, new RecordItemIndex(1));
            repo.RxMainFrame.RxTabStandard.FirstName.PressKeys("John");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'RxMainFrame.RxTabStandard.LastName' at 9;5.", repo.RxMainFrame.RxTabStandard.LastNameInfo, new RecordItemIndex(2));
            repo.RxMainFrame.RxTabStandard.LastName.Click("9;5");
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence 'Public' with focus on 'RxMainFrame.RxTabStandard.LastName'.", repo.RxMainFrame.RxTabStandard.LastNameInfo, new RecordItemIndex(3));
            repo.RxMainFrame.RxTabStandard.LastName.PressKeys("Public");
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}