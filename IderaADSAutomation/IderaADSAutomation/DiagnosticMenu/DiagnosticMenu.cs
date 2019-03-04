using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;
using IderaADSAutomation.Preconditions;
using IderaADSAutomation.Configuration;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace IderaADSAutomation
{
    
    [TestModule("03C4FD4B-61FE-445E-A5F2-58A5CB022D2C", ModuleType.UserCode, 1)]
    public class DiagnosticMenu : ITestModule
    {
        private string RegisterServerTestDataPath = System.Configuration.ConfigurationManager.AppSettings["RegisterNewServer"].ToString();
    	private string QueryTestDataPath = System.Configuration.ConfigurationManager.AppSettings["Queries"].ToString();
    	
    	RegisterServerData registerServerData = new RegisterServerData();
    	List<Server> servers = new List<Server>();
    	IderaADSAutomationRepository repo = IderaADSAutomationRepository.Instance;
    	Duration appduration = new Duration(180000);
    	
        public DiagnosticMenu()
        {
            servers = registerServerData.GetActiveServers(RegisterServerTestDataPath);
        }

        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 0;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            var curTestCase = (TestCaseNode)TestSuite.CurrentTestContainer;
            Precondition.SetTCName(curTestCase);
			
            if(repo.Application.SelfInfo.Exists(appduration))
            {
            	repo.Application.Self.Activate();
            	ReportLog("Diagnostic Menu Test - Start", ADSReportLevel.Info, null, Precondition.TestCaseName);
            	StartProcess(GetSingleServer(servers));
            	ReportLog("Diagnostic Menu Test - End", ADSReportLevel.Info, null, Precondition.TestCaseName);
            }
        }
        
        Server GetSingleServer(List<Server> Servers)
        {
        	Server updserver = null;
        	foreach (var server in servers)
            {
        		if(Precondition.isTestDataAvailable(server))
            	{
        			updserver = server;
        			break;
        		}
        	}
        	return updserver;
        }
        
        void Delay3k()
        {
        	System.Threading.Thread.Sleep(3000);
        }
        
        void StartProcess(Server server)
        {
        	try 
        	{
        		try
        		{
	        		TreeItem treeitem = Precondition.GetItem(repo.QueryAnalyzerConfiguraion.DBServerList, server.RegistredServerName, false);
					Precondition.RightClick(treeitem);
					Precondition.Click(repo.SunAwtWindow.ServerSupportInformation);
					Delay3k();
					if(repo.ServerInformation.SelfInfo.Exists(new Duration(1000)))
						Precondition.Click(repo.ServerInformation.CancelButton);
					ReportLog("Server Support Information Execution - Done", ADSReportLevel.Success, null, Precondition.TestCaseName);
        		}
        		catch
        		{
        			ReportLog("Server Support Information Execution - Done", ADSReportLevel.Fail, null, Precondition.TestCaseName);
        		}
        		
        		try 
        		{
        			System.Threading.Thread.Sleep(300);
        			Precondition.Click(repo.Datastudio.HelpMenu);
        			System.Threading.Thread.Sleep(300);
					Precondition.Click(repo.Datastudio.Sqllog);
					Delay3k();
					if(repo.SqlLog.SelfInfo.Exists(new Duration(1000)))
						Precondition.Click(repo.SqlLog.CloseButton);
					ReportLog("Sql Log Execution - Done", ADSReportLevel.Success, null, Precondition.TestCaseName);
        		} 
        		catch
        		{
        			ReportLog("Sql Log Execution - Done", ADSReportLevel.Fail, null, Precondition.TestCaseName);
        		}
				
        		try
        		{
        			System.Threading.Thread.Sleep(300);
        			Precondition.Click(repo.Datastudio.HelpMenu);
        			System.Threading.Thread.Sleep(300);
					Precondition.Click(repo.Datastudio.Viewog);
					Delay3k();
					if(repo.ViewLog.SelfInfo.Exists(new Duration(1000)))
						Precondition.Click(repo.ViewLog.CloseButton);
					ReportLog("View Log Execution - Done", ADSReportLevel.Success, null, Precondition.TestCaseName);
        		}
				catch 
        		{
        			ReportLog("View Log Execution - Done", ADSReportLevel.Fail, null, Precondition.TestCaseName);
        		}
				
				try
				{
					System.Threading.Thread.Sleep(300);
					Precondition.Click(repo.Datastudio.HelpMenu);
					System.Threading.Thread.Sleep(300);
					Precondition.Click(repo.Datastudio.MemoryMonitor);
					Delay3k();
					if(repo.MemoryMonitor.SelfInfo.Exists(new Duration(1000)))
						Precondition.Click(repo.MemoryMonitor.CloseButton);
					ReportLog("Memory Monitor Execution - Done", ADSReportLevel.Success, null, Precondition.TestCaseName);
				}
				catch 
        		{
        			ReportLog("Memory Monitor Execution - Done", ADSReportLevel.Fail, null, Precondition.TestCaseName);
        		}
				
				try
				{
					System.Threading.Thread.Sleep(300);
					Precondition.Click(repo.Datastudio.HelpMenu);
					System.Threading.Thread.Sleep(300);
					Precondition.Click(repo.Datastudio.SupportInformation);
					Delay3k();
					if(repo.SupportInformation.SelfInfo.Exists(new Duration(1000)))
						Precondition.Click(repo.SupportInformation.CloseButton);
					ReportLog("Support Information Execution - Done", ADSReportLevel.Success, null, Precondition.TestCaseName);
				}
				catch 
        		{
        			ReportLog("Support Information Execution - Done", ADSReportLevel.Fail, null, Precondition.TestCaseName);
        		}
				
				
				try 
				{
					System.Threading.Thread.Sleep(300);
					Precondition.Click(repo.Datastudio.HelpMenu);
					System.Threading.Thread.Sleep(300);
					Precondition.Click(repo.Datastudio.About);
					if(repo.About.SelfInfo.Exists(new Duration(1000)))
					{
						Precondition.Click(repo.About.JDBCDrivers);
						Delay3k();
						Precondition.Click(repo.About.CloseButton,false);
					}
					ReportLog(" About Execution - Done", ADSReportLevel.Success, null, Precondition.TestCaseName);
				} 
				catch 
				{
					ReportLog("About Execution - Done", ADSReportLevel.Fail, null, Precondition.TestCaseName);
				}
				
        	} 
        	catch (Exception e) 
        	{
        		ReportLog(e.StackTrace.ToString(), ADSReportLevel.Fail, null, Precondition.TestCaseName);
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
