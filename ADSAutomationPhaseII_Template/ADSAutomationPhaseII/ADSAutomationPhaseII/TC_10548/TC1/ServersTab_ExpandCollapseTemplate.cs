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



namespace ADSAutomationPhaseII.TC_10548
{
   
    [TestModule("9A67720B-A9A2-4040-B33E-17FF7277703F", ModuleType.UserCode, 1)]
    public class ServersTab_ExpandCollapseTemplate :BaseClass, ITestModule
    {
        public ServersTab_ExpandCollapseTemplate()
        {
        
        }

  		void ITestModule.Run()
        {
         	StartProcess();
        }
        
        bool StartProcess()
        {
        	try 
        	{
        		Steps.ClickonServers();
        		Steps.CollapseDatabase();
        		Steps.ExpandDatabase();
        	} 
        	catch (Exception)
        	{
        	}
        	return true;
        }
    }
}
