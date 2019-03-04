using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using WinForms = System.Windows.Forms;
using System.Xml.Linq;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using System.Data;
using IderaADSAutomation.Configuration;
using System.Configuration;
using IderaADSAutomation.Preconditions;

namespace IderaADSAutomation.Scripting
{
	
    [TestModule("CEEE1B4E-3682-44A4-97D1-20600F8DA359", ModuleType.UserCode, 1)]
    public class Scripting : ITestModule
    {
    	private string RegisterServerTestDataPath = System.Configuration.ConfigurationManager.AppSettings["RegisterNewServer"].ToString();
    	private string SCRIPTFILE = System.Configuration.ConfigurationManager.AppSettings["ScriptFile"].ToString();
    	private string QueryTestDataPath = System.Configuration.ConfigurationManager.AppSettings["Queries"].ToString();
    	RegisterServerData registerServerData = new RegisterServerData();
    	List<Server> servers = new List<Server>();
    	Server server = new Server();
    	IderaADSAutomationRepository repo = IderaADSAutomationRepository.Instance;
    	string[] restrict = new string[] {"Vertica 10.90.1.54 v9.1", "Vertica 10.90.1.176 v8.0"};
    	
        public Scripting()
        {
        }

        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 0;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            if(repo.Application.SelfInfo.Exists(new Duration(180000)))
            {
            	var curTestCase = (TestCaseNode)TestSuite.CurrentTestContainer;
	            Precondition.SetTCName(curTestCase);
	            server = registerServerData.GetSingleServer(RegisterServerTestDataPath, Precondition.GetServerName(Precondition.TestCaseName), false);
            
            	repo.Application.Self.Activate();
            	ReportLog("Scripting Test - Start", ADSReportLevel.Info, null, Precondition.TestCaseName);
	            StartProcess(server);
	            ReportLog("Scripting Test - End", ADSReportLevel.Info, null, Precondition.TestCaseName);
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
    			/* Database 1- Start */
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
				Precondition.CreateDatabase1(repo, server);
				Precondition.CloseTab();
				Precondition.ReConnectServer(repo);
				Precondition.RightClick(treeitem);
				Precondition.QueryAnalyser(repo);
				if(server.DatabaseKey == "Schema"){server.DatabaseName = "ADS_DB1";} else {server.DatabaseName = "ads_db1";}
				Precondition.SelectDBFromComboBox(repo, server, server.DatabaseName);
				if(!restrict.Contains(server.RegistredServerName) && !Precondition.VerifyADSDBCombobox(repo, server, "ads_db1"))
				{
					Precondition.CloseTab();
					ReportLog("Database Creation Failed", ADSReportLevel.Fail, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
    				Precondition.RightClick(treeitem);
    				Precondition.DisconnectServer(repo);
    				Precondition.CloseTab();
					return;
				}
				if(restrict.Contains(server.RegistredServerName)) { Precondition.CreateSecondTable(repo, server); } else { Precondition.CreateTable(repo, server); }
				Precondition.CloseTab();
				/* Database 1- End */
				
				/* Database 2- Start */
				Precondition.RightClick(treeitem);
				Precondition.QueryAnalyser(repo);
        		Precondition.CreateDatabase(repo, server);
        		Precondition.CloseTab();
        		Precondition.RightClick(treeitem);
				Precondition.ReConnectServer(repo);
				Precondition.RightClick(treeitem);
				Precondition.QueryAnalyser(repo);
				string dbnameforschema = "ADS_DB";
				if(server.DatabaseKey != "Schema") { dbnameforschema = "ads_db";}
				Precondition.SelectDBFromComboBox(repo, server, dbnameforschema);
				
				if(!restrict.Contains(server.RegistredServerName) && !Precondition.VerifyADSDBCombobox(repo, server, "ads_db"))
				{
					Precondition.CloseTab();
					ReportLog("Database Creation Failed", ADSReportLevel.Fail, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
    				Precondition.RightClick(treeitem);
    				Precondition.DisconnectServer(repo);
    				Precondition.CloseTab();
					return;
				}
				
				Precondition.CreateTable(repo, server);
				Precondition.CloseTab();
				/* Database 2- End */
				ReportLog("Preconditions - Done", ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
				
				Precondition.ClickTools(repo);
				System.Threading.Thread.Sleep(120);				
				Precondition.ClickScriptGenerator(repo);
				System.Threading.Thread.Sleep(120);
				Precondition.ClickExportServerList(repo);
				
				TreeItem root = Precondition.GetItem(repo.ChooseFromServer.DBServerList, "root");
				System.Threading.Thread.Sleep(600);
				
				TreeItem localdbServers = Precondition.GetItem(root, "Local Database Servers");
				System.Threading.Thread.Sleep(600);
				
				TreeItem registeredServer = Precondition.GetItem(localdbServers, server.RegistredServerName);
				System.Threading.Thread.Sleep(600);
				
				if(restrict.Contains(server.RegistredServerName))
				{
					TreeItem database = Precondition.GetItem(registeredServer, "aquafold");
					Precondition.Click(database);
					System.Threading.Thread.Sleep(600);
					
					Precondition.Click(repo.ExportDBServerList.ButtonOk);						
					System.Threading.Thread.Sleep(600);
					
					Precondition.TextboxText(repo.ScriptGenerator.SchemaComboboxText, server.DatabaseName);
					System.Threading.Thread.Sleep(600);
				}
				else
				{
					if(server.RegistredServerName == ServerNameConstants.Netezza_72) server.DatabaseName = server.DatabaseName.ToUpper();
					TreeItem database = Precondition.GetItem(registeredServer, server.DatabaseName);
					Precondition.Click(database);
					System.Threading.Thread.Sleep(600);
					Precondition.Click(repo.ExportDBServerList.ButtonOk);						
					System.Threading.Thread.Sleep(600);
				}

				
				
				Precondition.Click(repo.ScriptGenerator.UnselectObject);
				System.Threading.Thread.Sleep(600);
				
				if(server.DatabaseKey == "Schema") { Precondition.ScanForTables(repo.ScriptGenerator.TablesObjectForSchema); } else { Precondition.ScanForTables(repo.ScriptGenerator.TablesObjectForDB); }
				System.Threading.Thread.Sleep(600);
				if(repo.ScriptGenerator.TablesObjectTable.Rows.Count > 1)
				{
					Precondition.Click(repo.ScriptGenerator.UnselectObjectTable,false);
					System.Threading.Thread.Sleep(600);
					Precondition.ScanTableName(repo.ScriptGenerator.TablesObjectTable);
					System.Threading.Thread.Sleep(600);
				}
				Precondition.Click(repo.ScriptGenerator.NextButton);
				Precondition.Click(repo.ScriptGenerator.BrowseButton);
				Precondition.DeleteFilesFromPath(SCRIPTFILE);
				Precondition.TextboxText(repo.Select.LocationTextbox, SCRIPTFILE + server.RegistredServerName + ".txt" );
				Precondition.Click(repo.Select.SelectButton);
				Precondition.Click(repo.ScriptGenerator.NextButton);
				try { repo.ScriptGenerator.ScriptGeneratorStatusInfo.WaitForExists(new Duration(180000));} catch (Exception e) { throw e; }
				Precondition.Click(repo.ScriptGenerator.CancelButton);
				ReportLog("Schema Script generated - Done", ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
				
				Precondition.ClickTools(repo);
				System.Threading.Thread.Sleep(120);
				
				Precondition.ClickCompare(repo);
				System.Threading.Thread.Sleep(120);
				
				Precondition.ClickSchemaCompare(repo);
				System.Threading.Thread.Sleep(120);
				
				
				try{ repo.SchemaCompare.ChooseServerLeftInfo.WaitForExists(new Duration(600)); }
				catch
				{ 
					Precondition.Click(repo.QueryAnalyzerConfiguraion.ExportData.Tools); 
					Precondition.Click(repo.CompareMenu.Compare); 
					Precondition.Click(repo.SchemaCompareMenu.Compare);
				}
				
				Precondition.Click(repo.SchemaCompare.ChooseServerLeft);
				System.Threading.Thread.Sleep(600);		
				
				TreeItem root1 = Precondition.GetItem(repo.ChooseFromServer.DBServerList, "root");
				System.Threading.Thread.Sleep(600);
				
				TreeItem localdbServers1 = Precondition.GetItem(root1, "Local Database Servers");
				System.Threading.Thread.Sleep(600);
				
				TreeItem registeredServer1 = Precondition.GetItem(localdbServers1, server.RegistredServerName);
				System.Threading.Thread.Sleep(600);
				
				TreeItem database1 = restrict.Contains(server.RegistredServerName) ? Precondition.GetItem(registeredServer1, "aquafold") : Precondition.GetItem(registeredServer1, server.DatabaseName);
				System.Threading.Thread.Sleep(600);
				
				database1.Select();
				System.Threading.Thread.Sleep(600);
				
				Precondition.Click(repo.ExportDBServerList.ButtonOk);
				System.Threading.Thread.Sleep(600);
				
				Precondition.Click(repo.SchemaCompare.ChooseServerRight);
				System.Threading.Thread.Sleep(600);
				TreeItem root2 = Precondition.GetItem(repo.ChooseFromServer.DBServerList, "root");
			
				System.Threading.Thread.Sleep(600);
				TreeItem localdbServers2 = Precondition.GetItem(root2, "Local Database Servers");
			
				System.Threading.Thread.Sleep(600);
				TreeItem registeredServer2 = Precondition.GetItem(localdbServers2, server.RegistredServerName);
		
				System.Threading.Thread.Sleep(600);
				TreeItem database2 = restrict.Contains(server.RegistredServerName) ? Precondition.GetItem(registeredServer2, "aquafold") : Precondition.GetItem(registeredServer2, "ads_db");
		
				System.Threading.Thread.Sleep(600);
				if(server.DatabaseKey == "Schema"){ database2 = Precondition.GetItem(registeredServer2, "ADS_DB");  }
			
				System.Threading.Thread.Sleep(600);
				database2.Select();
				System.Threading.Thread.Sleep(600);
				Precondition.Click(repo.ExportDBServerList.ButtonOk);
				System.Threading.Thread.Sleep(600);
				
				if(restrict.Contains(server.RegistredServerName))
				{
					Precondition.TextboxText(repo.SchemaCompare.LeftSchemaComboboxText, "ads_db1");
					Precondition.TextboxText(repo.SchemaCompare.RightSchemaComboboxText, "ads_db");
				}
				System.Threading.Thread.Sleep(600);
				
				if(server.DatabaseKey == "Schema")
				{
					Precondition.Click(repo.SchemaCompare.SchemaUnselectSchemaObject);
					
					Precondition.ScanForTables(repo.SchemaCompare.MiddleTableSchema);
//					System.Threading.Thread.Sleep(1000);
				}
				else
				{
					if(!restrict.Contains(server.RegistredServerName)) Precondition.TextboxText(repo.SchemaCompare.SchemaCombobxRight, repo.SchemaCompare.SchemaCombobxLeft.TextValue);
//					System.Threading.Thread.Sleep(1000);
					
					Precondition.Click(repo.SchemaCompare.UnselectSchemaObject);
										
					Precondition.ScanForTables(repo.SchemaCompare.MiddleTableDB);
//					System.Threading.Thread.Sleep(1000);
				}
				
				if(repo.SchemaCompare.LeftObjectTable.Rows.Count > 1)
				{
					Precondition.Click(repo.SchemaCompare.LeftUnselectObject);
					Precondition.ScanTableName(repo.SchemaCompare.LeftObjectTable);
				}
				
				if(repo.SchemaCompare.RightObjectTable.Rows.Count > 1)
				{
					Precondition.Click(repo.SchemaCompare.RightUnselectObject);
					Precondition.ScanTableName(repo.SchemaCompare.RightObjectTable);
				}
				
				Precondition.Click(repo.SchemaCompare.CompareButton);
				System.Threading.Thread.Sleep(5000);
				
				Precondition.Click(repo.Application.CompareTable, false);
				
				if(repo.Application.CompareResultTextInfo.Exists(new Duration(10000)))
				{
					repo.Application.CompareResultText.EnsureVisible();
					ReportLog("Schema Script Compared - Done", ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
				}
				
				Precondition.CloseTab();
				Precondition.RightClick(treeitem);
				Precondition.DisconnectServer(repo);
				 
				Precondition.RightClick(treeitem);
				Precondition.QueryAnalyser(repo);
				Precondition.SelectDBFromComboBox(repo, server, "ads_db"); 
				Precondition.DropTable(repo,server); 
				Precondition.CloseTab();
				
				Precondition.RightClick(treeitem);
				Precondition.QueryAnalyser(repo);
				Precondition.SelectDBFromComboBox(repo, server, "ads_db1"); 
				if(restrict.Contains(server.RegistredServerName)) { Precondition.DropScondTable(repo,server); } else { Precondition.DropTable(repo,server); }
				Precondition.CloseTab();
								
				Precondition.RightClick(treeitem);
				Precondition.QueryAnalyser(repo);
				Precondition.DropDatabase(repo, server);				
				Precondition.DropDatabase1(repo, server);
				Precondition.CloseTab();
				Precondition.DeleteFilesFromPath(SCRIPTFILE);
				
				ReportLog("Clean up - Done", ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
				
			}
			catch(Exception e)
			{   
				Precondition.DeleteFilesFromPath(SCRIPTFILE);
				Precondition.CloseTab();
				Precondition.CloseTab();
				Precondition.RightClick(treeitem);
				Precondition.DisconnectServer(repo);
				 
				Precondition.RightClick(treeitem);
				Precondition.QueryAnalyser(repo);
				Precondition.SelectDBFromComboBox(repo, server, "ads_db"); 
				Precondition.DropTable(repo,server); 
				Precondition.CloseTab();
				
				Precondition.RightClick(treeitem);
				Precondition.QueryAnalyser(repo);
				Precondition.SelectDBFromComboBox(repo, server, "ads_db1"); 
				if(restrict.Contains(server.RegistredServerName)) { Precondition.DropScondTable(repo,server); } else { Precondition.DropTable(repo,server); }
				Precondition.CloseTab();
								
				Precondition.RightClick(treeitem);
				Precondition.QueryAnalyser(repo);
				Precondition.DropDatabase(repo, server);
				Precondition.DropDatabase1(repo, server);
				Precondition.CloseTab();
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
