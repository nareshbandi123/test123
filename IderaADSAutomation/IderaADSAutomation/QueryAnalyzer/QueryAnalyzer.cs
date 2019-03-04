using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using System.Linq;
using System.Linq.Expressions;
using WinForms = System.Windows.Forms;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using Ranorex.Core.Reporting;
using IderaADSAutomation.Preconditions;
using IderaADSAutomation.Configuration;

namespace IderaADSAutomation.QueryAnalyzer
{
    [TestModule("A21C81DD-C721-45FE-A7FF-8942F0A92A53", ModuleType.UserCode, 1)]
    public class QueryAnalyzer : ITestModule
    {
    	
    	private string RegisterServerTestDataPath = System.Configuration.ConfigurationManager.AppSettings["RegisterNewServer"].ToString();
    	private string QueryTestDataPath = System.Configuration.ConfigurationManager.AppSettings["Queries"].ToString();
    	
    	RegisterServerData registerServerData = new RegisterServerData();
    	List<Server> servers = new List<Server>();
    	Server server = new Server();
    	IderaADSAutomationRepository repo = IderaADSAutomationRepository.Instance;
        Duration appduration = new Duration(180000);
        
    	public QueryAnalyzer()
        {
        }

        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 0;
            Keyboard.DefaultKeyPressTime = 1000;
            Delay.SpeedFactor = 1.0;
            
            if(repo.Application.SelfInfo.Exists(appduration))
            {
            	var curTestCase = (TestCaseNode)TestSuite.CurrentTestContainer;
	            Precondition.SetTCName(curTestCase);
	            server = registerServerData.GetSingleServer(RegisterServerTestDataPath, Precondition.GetServerName(Precondition.TestCaseName), false);
            
            	repo.Application.Self.Activate(); 
            	ReportLog("Query Analyzer Test - Start", ADSReportLevel.Info, null, Precondition.TestCaseName);
            	StartProcess(server);
            	ReportLog("Query Analyzer Test - End", ADSReportLevel.Info, null, Precondition.TestCaseName);
            }
        }
        
        void StartProcess(Server server)
        {	
    		Precondition.CloseTab();
    		string scriptlocation = QueryTestDataPath + server.ServerNameActual + @"\";
			server.TestScriptLocation = scriptlocation;
			if(server.RegistredServerName == "Derby 172.24.1.199 v10.14") { server.DatabaseName  = "APP";} // hack 
			TreeItem treeitem = null; 
			try 
			{
				ReportLog("Preconditions start - Done", ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
    			Precondition.CloseTab();
				treeitem = Precondition.GetItem(repo.QueryAnalyzerConfiguraion.DBServerList, server.RegistredServerName, false);
				Precondition.DoubleClick(treeitem);
				Precondition.SelectedServerTreeItem = treeitem;
				Precondition.RightClick(treeitem);
				Precondition.ConnectServer(repo);
    			if(!Precondition.ValidatePrecondition(repo, server, treeitem)) return;
    			
				Precondition.RightClick(treeitem);
				Precondition.QueryAnalyser(repo);
				Precondition.CreateDatabase(repo, server);
        		Precondition.CloseTab();
        		Precondition.RightClick(treeitem);
				Precondition.ReConnectServer(repo);
				Precondition.RightClick(treeitem);
				Precondition.QueryAnalyser(repo);
				Precondition.SelectDBFromComboBox(repo, server, "ads_db");
				
				string[] restrict = new string[] {"Vertica 10.90.1.54 v9.1", "Vertica 10.90.1.176 v8.0"};
				if(!restrict.Contains(server.RegistredServerName) && !Precondition.VerifyADSDBCombobox(repo, server, "ads_db"))
				{
					Precondition.CloseTab();
					ReportLog("Database Creation Failed", ADSReportLevel.Fail, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
    				Precondition.RightClick(treeitem);
    				Precondition.DisconnectServer(repo);
					return;
				}
				Precondition.CreateTable(repo, server);
				Precondition.InsertTable(repo, server);
				ReportLog("DDL/DML Execution - Done", ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
				Precondition.SelectTable(repo, server);						
				Precondition.ValidateTable(repo, server);
				ReportLog("Compare Inserted Data - Done", ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
				Precondition.DropTable(repo, server);
				Precondition.CloseTab();
				ReportLog("Drop DB Table - Done", ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
				Precondition.RightClick(treeitem);
				Precondition.QueryAnalyser(repo);
				Precondition.DropDatabase(repo, server);
				ReportLog("Drop DB- Done", ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
				Precondition.CloseTab();
				Precondition.RightClick(treeitem);
				Precondition.DisconnectServer(repo);
				
			} 
			catch(Exception e)
			{
				Precondition.CloseTab();
				ReportLog(e.StackTrace.ToString(), ADSReportLevel.Fail, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
				Precondition.CloseTab();
				Precondition.RightClick(treeitem);
				Precondition.QueryAnalyser(repo);
				if(server.DatabaseKey == "Schema"){Precondition.QAComboBox(repo, server);Precondition.DropTable(repo, server);}
				Precondition.SelectDBFromComboBox(repo, server, server.DatabaseName);
				Precondition.DropDatabase(repo, server);
				Precondition.RightClick(treeitem);
				Precondition.DisconnectServer(repo);
			}
        }
        
		public void ReportLog(string log, ADSReportLevel reportlevel, Element element, string category)
        {
        	switch (reportlevel) {
        		case ADSReportLevel.Fail:
					Report.Failure(category, log);
        			//Report.Screenshot(element);
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
