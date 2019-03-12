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
    [TestModule("D1A21C94-76C4-46B3-B287-B754C4E68916", ModuleType.UserCode, 1)]
    public class ServersTabSettingsTemplate : BaseClass, ITestModule
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
        		//Steps.ClickonServers();
        		Steps.ClickonSettingIcon();
        		Steps.MarkonDockedMode();
        		Steps.ClickonSettingIcon2();
        		Steps.MarkonDockedMode1();
        		Steps.ClickonSettingIcon();
        		Steps.MarkonPinnedMode();
        		Steps.ClickonSettingIcon();
        		Steps.MarkonPinnedMode();
        		Steps.ClickonSettingIcon();
        		Steps.MarkonFloatingMode();
        		Steps.ClickonSettingIcon1();
        		Steps.MarkonFloatingMode1();
        		Steps.ClickonSettingIcon();
        		Steps.MarkonSplitMode();
        		Steps.ClickonSettingIcon();
        		Steps.MarkonSplitMode();
        		Steps.ClickonServers();
        		
        		
        	} 
        	catch (Exception)
        	{
        	}
        	return true;
        }
    }
}
