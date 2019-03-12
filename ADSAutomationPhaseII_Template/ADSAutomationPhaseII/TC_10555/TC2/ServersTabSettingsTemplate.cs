
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

namespace ADSAutomationPhaseII.TC_10555.TC2
{
   
    [TestModule("4B6EEDD5-83FF-4E95-8D69-0B54B030910C", ModuleType.UserCode, 1)]
    public class ServersTabSettingsTemplate :BaseClass, ITestModule
    {
       
        public ServersTabSettingsTemplate()
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
        		TC_10548Steps.ClickonServers();
        		TC_10548Steps.ClickonSettingIcon();
        		TC_10548Steps.ExpandDatabase();        		
        		       		
        	} 
        	catch (Exception)
        	{
        	}
        	return true;
        }

       
    }
}
