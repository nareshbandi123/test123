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

namespace IderaADSAutomation.ExportImport
{
    [TestModule("F92451A5-6535-40E3-B8A6-52C7FA89E247", ModuleType.UserCode, 1)]
    public class ExportImport : ITestModule
    {
    	private string RegisterServerTestDataPath = System.Configuration.ConfigurationManager.AppSettings["RegisterNewServer"].ToString();
    	private string QueryTestDataPath = System.Configuration.ConfigurationManager.AppSettings["Queries"].ToString();
    	private string ExportDataPath = System.Configuration.ConfigurationManager.AppSettings["ExportData"].ToString();
    	
    	RegisterServerData registerServerData = new RegisterServerData();
    	Server server = new Server();
    	List<Server> servers = new List<Server>();
    	IderaADSAutomationRepository repo = IderaADSAutomationRepository.Instance;
        Duration appduration = new Duration(180000);
        
        public ExportImport()
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
            	Precondition.CloseTab();
            	ReportLog("Export Import Test - Start", ADSReportLevel.Info, null, Precondition.TestCaseName);
            	this.StartProcess(server);
            	ReportLog("Export Import Test - End", ADSReportLevel.Info, null, Precondition.TestCaseName);
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
    			Precondition.CloseTab();
				treeitem = Precondition.GetItem(repo.QueryAnalyzerConfiguraion.DBServerList, server.RegistredServerName, false);
				Precondition.DoubleClick(treeitem);
				Precondition.SelectedServerTreeItem = treeitem;
				Precondition.RightClick(treeitem);
				Precondition.ConnectServer(repo);
				if(server.RegistredServerName == ServerNameConstants.Sybase_Any_17){System.Threading.Thread.Sleep(2000);}
				if(!Precondition.ValidatePrecondition(repo, server, treeitem)) return;
				
				ReportLog("Connect to Server - Done", ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
				Precondition.RightClick(treeitem);
				Precondition.DisconnectServer(repo);
				Precondition.RightClick(treeitem);
				Precondition.QueryAnalyser(repo);
				Precondition.CreateDatabase1(repo, server);
				Precondition.CloseTab();
				Precondition.RightClick(treeitem);
				Precondition.ReConnectServer(repo);
				Precondition.RightClick(treeitem);
				Precondition.DisconnectServer(repo);
				Precondition.RightClick(treeitem);
				Precondition.QueryAnalyser(repo);
				if(server.DatabaseKey == "Schema"){server.DatabaseName = "ADS_DB1";} else {server.DatabaseName = "ads_db1";}
				Precondition.SelectDBFromComboBox(repo, server, "ads_db1");
				
				
				string[] restrict = new string[] {"Vertica 10.90.1.54 v9.1", "Vertica 10.90.1.176 v8.0"};				
				if(!restrict.Contains(server.RegistredServerName) && !Precondition.VerifyADSDBCombobox(repo, server, server.DatabaseName))
				{
					Precondition.CloseTab();
					ReportLog("Database Creation Failed", ADSReportLevel.Fail, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
    				Precondition.RightClick(treeitem);
    				Precondition.DisconnectServer(repo);
    				Precondition.CloseTab();
					return;
				}
				
				if(restrict.Contains(server.RegistredServerName))
				{
					Precondition.CreateSecondTable(repo, server);				
					Precondition.InsertScondTable(repo, server);
				}
				else
				{
					Precondition.CreateTable(repo, server);				
					Precondition.InsertTable(repo, server);
				}
				Precondition.CloseTab();
				ReportLog("Export Preconditions - Done", ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
				
				ReportLog("Export process start - Done", ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
				Precondition.ClickTools(repo);
				System.Threading.Thread.Sleep(120);	
				Precondition.ClickExport(repo);
				Precondition.ClickExportServerList(repo);
				TreeItem root = Precondition.GetItem(repo.ChooseFromServer.DBServerList, "root", false);
				TreeItem localdbServers = Precondition.GetItem(root, "Local Database Servers", false);
				TreeItem registeredServer = Precondition.GetItem(localdbServers, server.RegistredServerName);
				Precondition.TreeItemCollapse(registeredServer);
				registeredServer.Select();
				Precondition.Click(repo.ExportDBServerList.ButtonOk);
				if(server.DatabaseKey == "Schema" || restrict.Contains(server.RegistredServerName)) { Precondition.ExportComboBox(repo, server);	} else { Precondition.TextboxText(repo.QueryAnalyzerConfiguraion.ExportData.DatabaseComboboxText, server.DatabaseName); }
				Precondition.Click(repo.QueryAnalyzerConfiguraion.ExportData.RemoveSelectedObjectTypes);
				System.Threading.Thread.Sleep(1000);
				Precondition.Click(repo.QueryAnalyzerConfiguraion.ExportData.SelectTableObjectTypes);
				System.Threading.Thread.Sleep(1000);
				if(!Precondition.ScanTableName(repo))
				{
					Precondition.CloseTab();
					ReportLog("Table creation failed", ADSReportLevel.Fail, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
    				Precondition.RightClick(treeitem);
    				Precondition.DisconnectServer(repo);
    				Precondition.RightClick(treeitem);
    				Precondition.QueryAnalyser(repo);
    				Precondition.DropDatabase1(repo, server);
    				Precondition.DisconnectServer(repo);
					return;
				}
				System.Threading.Thread.Sleep(1000);
				Precondition.Click(repo.QueryAnalyzerConfiguraion.ExportData.NextButton);
				Precondition.DeleteFilesFromPath(ExportDataPath);
				string exportedPath = string.Format("{0}Export.csv", ExportDataPath);
				Precondition.TextboxText(repo.QueryAnalyzerConfiguraion.ExportData.BrowseLocation, exportedPath);
				Precondition.Click(repo.QueryAnalyzerConfiguraion.ExportData.SecondNextButton);
				System.Threading.Thread.Sleep(1000);

				repo.QueryAnalyzerConfiguraion.ExportData.ExportStatusInfo.WaitForExists(new Duration(180000));
				Precondition.Click(repo.QueryAnalyzerConfiguraion.ExportData.CloseButton);
				
				ReportLog("Export process end - Done", ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
				
				if(!System.IO.File.Exists(exportedPath))
				{
					ReportLog("Export failed", ADSReportLevel.Fail, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
					Precondition.RightClick(treeitem);
					Precondition.QueryAnalyser(repo);
					if(server.DatabaseKey == "Schema") { Precondition.QAComboBox(repo, server);} else { Precondition.SelectDBFromComboBox(repo, server, server.DatabaseName); }
					Precondition.DropTable(repo, server);
					Precondition.CloseTab();
					Precondition.DisconnectServer(repo);
					return;
				}
				
				Precondition.RightClick(treeitem);
				Precondition.QueryAnalyser(repo);
				Precondition.CreateDatabase(repo,server);
				Precondition.CloseTab();
				Precondition.RightClick(treeitem);
				Precondition.ReConnectServer(repo);
				Precondition.RightClick(treeitem);
				Precondition.DisconnectServer(repo);
				Precondition.RightClick(treeitem);
				Precondition.QueryAnalyser(repo);
				Precondition.SelectDBFromComboBox(repo, server,"ads_db");
				
				if(!restrict.Contains(server.RegistredServerName) && !Precondition.VerifyADSDBCombobox(repo, server, "ads_db"))
				{
					Precondition.CloseTab();
					ReportLog("Database Creation Failed", ADSReportLevel.Fail, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
    				Precondition.RightClick(treeitem);
    				Precondition.DisconnectServer(repo);
    				Precondition.RightClick(treeitem);
    				Precondition.QueryAnalyser(repo);
    				Precondition.DropDatabase1(repo, server);
    				Precondition.DisconnectServer(repo);
					return;
				}
				
				Precondition.CreateTable(repo,server);
				Precondition.CloseTab();
				
				ReportLog("Import Preconditions - Done", ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
				
				ReportLog("Import Process start - Done", ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
				Precondition.ClickTools(repo);
				System.Threading.Thread.Sleep(120);
				Precondition.ClickImport(repo);
				System.Threading.Thread.Sleep(120);
				Precondition.ClickImportServerList(repo);
				
				root = Precondition.GetItem(repo.ChooseFromServer.DBServerList, "root", false);
				localdbServers = Precondition.GetItem(root, "Local Database Servers", false);
				registeredServer = Precondition.GetItem(localdbServers, server.RegistredServerName);
				Precondition.TreeItemCollapse(registeredServer);
				registeredServer.Select();
				Precondition.Click(repo.ExportDBServerList.ButtonOk);
				Precondition.TextboxText(repo.QueryAnalyzerSelectScript.FolderToOpen, exportedPath);
				Precondition.DoubleClick(repo.QueryAnalyzerSelectScript.FileList.Items[0]);
				Precondition.Click(repo.QueryAnalyzerConfiguraion.ImportData.NextButton);
				if(server.DatabaseKey == "Schema" || restrict.Contains(server.RegistredServerName))
					Precondition.TextboxText(repo.QueryAnalyzerConfiguraion.ImportData.ImportNewSchemaText, "ads_db");
				else
					Precondition.TextboxText(repo.QueryAnalyzerConfiguraion.ImportData.ImportNewDBText, "ads_db");
				Precondition.Click(repo.QueryAnalyzerConfiguraion.ImportData.SecondNextButton);
				Precondition.Click(repo.QueryAnalyzerConfiguraion.ImportData.SecondNextButton);
				Precondition.Click(repo.QueryAnalyzerConfiguraion.ImportData.SecondNextButton);
				
				string[] cassandraServer = new string[] { "Cassandra 172.24.1.77 3.7", "Cassandra 172.24.1.122 2.2" };
				if(cassandraServer.Contains(server.RegistredServerName))
				{
					System.Threading.Thread.Sleep(200);
					Precondition.Click(repo.QueryAnalyzerConfiguraion.ImportData.CloseButton);
				}
				else
				{
					repo.QueryAnalyzerConfiguraion.ImportData.ImportStatusInfo.WaitForExists(new Duration(60000));
					Precondition.Click(repo.QueryAnalyzerConfiguraion.ImportData.CloseButton);
				}
				
				ReportLog("Import Process End - Done", ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
								
				ReportLog("Cleanup start - Done", ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
				Precondition.RightClick(treeitem);
				Precondition.DisconnectServer(repo);
				Precondition.RightClick(treeitem);
				Precondition.QueryAnalyser(repo);
				Precondition.SelectDBFromComboBox(repo, server,server.DatabaseName);
				if(!restrict.Contains(server.RegistredServerName)) { Precondition.SelectTable(repo, server); } else { Precondition.SelectSecondTable(repo, server); }
				Precondition.DropScondTable(repo, server);
				Precondition.CloseTab();
				server.DatabaseName = "ads_db";
				Precondition.RightClick(treeitem);
				Precondition.DisconnectServer(repo);
				Precondition.RightClick(treeitem);
				Precondition.QueryAnalyser(repo);
				Precondition.SelectDBFromComboBox(repo, server,server.DatabaseName);
				Precondition.SelectTable(repo, server);
				Precondition.DropTable(repo, server);
				Precondition.CloseTab();
				Precondition.RightClick(treeitem);
				Precondition.QueryAnalyser(repo);
				Precondition.DropDatabase1(repo, server);
				Precondition.CloseTab();
				Precondition.RightClick(treeitem);
				Precondition.QueryAnalyser(repo);
				Precondition.DropDatabase(repo, server);
				Precondition.CloseTab();
				Precondition.RightClick(treeitem);
				Precondition.DisconnectServer(repo);
				ReportLog("Cleanup end - Done", ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
			}
			catch(Exception e)
			{
				Precondition.RightClick(treeitem);
				Precondition.DisconnectServer(repo);
				Precondition.RightClick(treeitem);
				Precondition.QueryAnalyser(repo);
				if(server.DatabaseKey == "Schema") { Precondition.QAComboBox(repo, server);} else { Precondition.SelectDBFromComboBox(repo, server, server.DatabaseName); }
				Precondition.SelectTable(repo, server);
				Precondition.DropTable(repo, server);
				server.DatabaseName = "ads_db";
				if(server.DatabaseKey == "Schema") { Precondition.QAComboBox(repo, server);} else { Precondition.SelectDBFromComboBox(repo, server, server.DatabaseName); }
				Precondition.SelectTable(repo, server);
				Precondition.DropTable(repo, server);
				Precondition.CloseTab();
				Precondition.RightClick(treeitem);
				Precondition.QueryAnalyser(repo);
				Precondition.DropDatabase1(repo, server);
				Precondition.CloseTab();
				Precondition.RightClick(treeitem);
				Precondition.QueryAnalyser(repo);
				Precondition.DropDatabase(repo, server);
				Precondition.CloseTab();
				Precondition.RightClick(treeitem);
				Precondition.DisconnectServer(repo);
				ReportLog(e.StackTrace.ToString(), ADSReportLevel.Fail, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
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
