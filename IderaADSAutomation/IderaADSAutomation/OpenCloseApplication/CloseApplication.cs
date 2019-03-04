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
using System.Diagnostics;
using IderaADSAutomation.RegisterServer;

namespace IderaADSAutomation.OpenCloseApplication
{
    [TestModule("F311E767-6DD1-4938-B58D-B63E1DBD2F72", ModuleType.UserCode, 1)]
    public class CloseApplication : ITestModule
    {
        public CloseApplication()
        {
        }

        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 0;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            ExitApplication();
            Delay.Seconds(3);
        }
        
        void ExitApplication()
        {	
        	try 
        	{
        		RegisterNewServer o = new RegisterNewServer();
	        	o.ShowMainWindow();
	        	ReportLog("ADS Application Closed", ADSReportLevel.Success, null, "ADS Application Close");
	        	IderaADSAutomationRepository.Instance.Application.MainWindowCloseButton.Click();
	        	IderaADSAutomationRepository.Instance.CloseWindow.ExitButton.Click();
        	} 
        	catch
        	{
        		ReportLog("ADS Application Closed failed", ADSReportLevel.Fail, null, "ADS Application Close");
        	}
        }
        
        public void ReportLog(string log, ADSReportLevel reportlevel, Element element, string category)
        {
        	switch (reportlevel) {
        		case ADSReportLevel.Fail:
					Report.Failure(category, log);
        			Report.Screenshot(element);
        			break;
    			case ADSReportLevel.Info:
	    			Report.Info(category, log);        			
	    			break;
    			case ADSReportLevel.Success:
	    			Report.Success(category, log);        			
	    			break;
        		default:        			
        			break;
        	}
        }        
                
		public enum ADSReportLevel{
        	Success = 1,
        	Fail = 2,
        	Info = 3
        }
    }
}
