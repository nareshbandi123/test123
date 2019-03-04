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
using System.IO;
using IderaADSAutomation.Preconditions;

namespace IderaADSAutomation.OpenCloseApplication
{
    [TestModule("041DFC4C-F254-4D88-B2DB-9A5D2B2EF4BF", ModuleType.UserCode, 1)]
    public class OpenApplication : ITestModule
    {
    	
    	public readonly string applicationPath = System.Configuration.ConfigurationManager.AppSettings["APP_PATH"].ToString();

    	public OpenApplication()
        {
        }

        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 0;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            var curTestCase = (TestCaseNode)TestSuite.CurrentTestContainer;
            Precondition.SetTCName(curTestCase);
            
            this.OpenADSApplication(applicationPath);
        }
        
        private void OpenADSApplication(string appPath)
        {
        	try 
        	{
        		Host.Local.RunApplication(appPath);
        		ReportLog("ADS Application Opened", ADSReportLevel.Success, null, Precondition.TestCaseName);
        	} 
        	catch (Exception)
        	{
        		ReportLog("ADS Application Open Failed", ADSReportLevel.Fail, null, Precondition.TestCaseName);
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
