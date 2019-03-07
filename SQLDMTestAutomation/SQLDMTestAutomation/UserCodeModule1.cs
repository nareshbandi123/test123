/*
 * Created by Ranorex
 * User: administrator
 * Date: 2/28/2019
 * Time: 5:57 AM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
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

namespace SQLDMTestAutomation
{
    /// <summary>
    /// Description of UserCodeModule1.
    /// </summary>
    [TestModule("91CB902D-C598-41F6-84BE-50D089216803", ModuleType.UserCode, 1)]
    public class UserCodeModule1 : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public UserCodeModule1()
        {
            // Do not delete - a parameterless constructor is required!
        }

        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
//            var repo = SQLDMTestAutomationRepository.Instance;
//            var showSqlStatements = repo.IderaSQLDiagnosticManagerSQLdmRepo.ShowSqlStatements;
            
            
        }
    }
}
