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

using ADSAutomationPhaseII.Base;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Preconditions;

namespace ADSAutomationPhaseII.TC_10535.TC3
{
    [TestModule("50F19267-023E-4984-B668-2724DDB86DFA", ModuleType.UserCode, 1)]
    public class Cleanup : BaseClass, ITestModule
    {
        public Cleanup()
        {
            
        }

        void ITestModule.Run()
        {
            StarProcess();
        }
        
        bool StarProcess()
        {
        	try 
        	{
        		TreeItem server = Preconditions.Steps.GetServerTreeFromTCName(Config.TestCaseName);
        		Preconditions.Steps.SelectedServerTreeItem = server;
        		Preconditions.Steps.SelectedServerName = server.Text;
        		server.RightClick();
        		Preconditions.Steps.DisconnectServer();
        		Preconditions.Steps.QueryAnalyser();
        		Preconditions.Steps.SelectDBFromComboBox("ads_db");
        		Preconditions.Steps.DropTable();
        		Preconditions.Steps.CloseTab(server.Text);
        		Preconditions.Steps.QueryAnalyser();
        		Preconditions.Steps.DropDatabase();
        	} 
        	catch (Exception) 
        	{
        		
        	}
        	return true;
        }
    }
}
