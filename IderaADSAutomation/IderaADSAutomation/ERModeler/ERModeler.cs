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

namespace IderaADSAutomation.ERModeler
{
    [TestModule("75191B2C-E5EC-4163-A070-FC09D4FB9622", ModuleType.UserCode, 1)]
    public class ERModeler : ITestModule
    {
    	private string RegisterServerTestDataPath = System.Configuration.ConfigurationManager.AppSettings["RegisterNewServer"].ToString();
    	private string QueryTestDataPath = System.Configuration.ConfigurationManager.AppSettings["Queries"].ToString();
    	
    	RegisterServerData registerServerData = new RegisterServerData();
    	List<Server> servers = new List<Server>();
    	Server server = new Server();
    	IderaADSAutomationRepository repo = IderaADSAutomationRepository.Instance;
    	Duration appduration = new Duration(180000);
    	
        public ERModeler()
        {
        }

        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 0;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
           
            if(repo.Application.SelfInfo.Exists(appduration))
            {
            	var curTestCase = (TestCaseNode)TestSuite.CurrentTestContainer;
	            Precondition.SetTCName(curTestCase);
	            server = registerServerData.GetSingleServer(RegisterServerTestDataPath, Precondition.GetServerName(Precondition.TestCaseName), false);
            
            	repo.Application.Self.Activate();
            	ReportLog("ER Modeler Test - Start", ADSReportLevel.Info, null, Precondition.TestCaseName);
	            StartProcess(server);
	            ReportLog("ER Modeler Test - End", ADSReportLevel.Info, null, Precondition.TestCaseName);
            }
        }
        
        void StartProcess(Server Server)
        {
        	Precondition.CloseTab();
    		string scriptlocation = QueryTestDataPath + server.ServerNameActual + @"\";
			server.TestScriptLocation = scriptlocation;
			if(server.RegistredServerName == "Derby 172.24.1.199 v10.14") { server.DatabaseName  = "APP";} // hack 
			TreeItem treeitem = null;
			try
			{
    			ReportLog("Preconditions start - Done", ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
    			Precondition.DeleteFiles(server.RegistredServerName + "ads_table_ERDiagram.xed");
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
    				Precondition.RightClick(treeitem);
    				Precondition.QueryAnalyser(repo);
    				Precondition.DropDatabase(repo, server);
    				Precondition.CloseTab();
					return;
				}
				Precondition.CreateTable(repo, server);
	        	Precondition.CloseTab();
	        	ReportLog("Preconditions end - Done", ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
	        	
	        	Precondition.Click(repo.Datastudio.ERModeler);
	        	Precondition.ClickERDGenerate(repo);
	        	Precondition.Click(repo.ContextMenu.Generate);
	        	
	        	TreeItem rootitem = Precondition.GetItem(repo.ExportDBServerList.DBServerList,"root", false);
	        	System.Threading.Thread.Sleep(600);
	        	TreeItem dbservsersitem = Precondition.GetItem(rootitem,"Local Database Servers",false);
	        	System.Threading.Thread.Sleep(600);
	        	TreeItem selecteditem = Precondition.GetItem(dbservsersitem,server.RegistredServerName, false);
	        	System.Threading.Thread.Sleep(600);
				selecteditem.Select();
				
				Precondition.Click(repo.ExportDBServerList.ButtonOk);
				if(server.DatabaseKey == "Schema") { Precondition.TextboxText(repo.ERDiagram.ComboboxTextbox, "ads_db"); } else { Precondition.TextboxText(repo.ERDiagram.SelectDB, "ads_db"); }
				Precondition.Click(repo.ERDiagram.UnSelectObjectType);
				Precondition.ScanForTables(repo.ERDiagram.ObjectTypeTable);
				if(repo.ERDiagram.ObjectTable.Rows.Count > 1)
				{
					Precondition.Click(repo.ERDiagram.UnSelectTable);
		        	System.Threading.Thread.Sleep(1000);
					Precondition.ScanTableName(repo.ERDiagram.ObjectTable);
				}
				System.Threading.Thread.Sleep(1000);
				Precondition.Click(repo.ERDiagram.NextButton);
				Precondition.Click(repo.ERDiagramWindow.SaveButton);
				Precondition.Click(repo.Save.Desktop);
				Precondition.TextboxText(repo.Save.SaveLocationText,server.RegistredServerName + "ads_table_ERDiagram");
				Precondition.Click(repo.Save.SaveButton);
				Precondition.Click(repo.ERDiagramWindow.CloseButton);
				ReportLog("ERModeler generated - Done", ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
				Precondition.RightClick(treeitem);
				Precondition.DisconnectServer(repo);
				Precondition.RightClick(treeitem);
				Precondition.QueryAnalyser(repo);
				Precondition.SelectDBFromComboBox(repo, server, "ads_db");
				Precondition.DropTable(repo, server);
				Precondition.CloseTab();
				Precondition.RightClick(treeitem);
				Precondition.QueryAnalyser(repo);
				Precondition.DropDatabase(repo, server);
				Precondition.CloseTab();
				
				Precondition.Click(repo.Datastudio.ERModeler);
				Precondition.ClickERDOpen(repo);
				Precondition.Click(repo.ContextMenu.Open);
	        	Precondition.Click(repo.QueryAnalyzerOpenScript.Desktop);
				
				foreach (var item in repo.QueryAnalyzerOpenScript.FileList.Items) {
					if(item.Text.Contains(server.RegistredServerName+ "ads_table_ERDiagram.xed"))
					{
						item.Focus();
						Delay.Milliseconds(200);
						item.DoubleClick();
						Delay.Milliseconds(1000);
						break;
					}
				}
				
				Precondition.Click(repo.ERDiagramWindow.CloseButton);
				
				Precondition.DeleteFiles(server.RegistredServerName + "ads_table_ERDiagram.xed");
				ReportLog("Cleanup - Done", ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
			}
			catch(Exception ex)
			{
				Precondition.RightClick(treeitem);
				Precondition.DisconnectServer(repo);
				Precondition.RightClick(treeitem);
				Precondition.QueryAnalyser(repo);
				Precondition.SelectDBFromComboBox(repo, server, "ads_db");
				Precondition.DropTable(repo, server);
				Precondition.CloseTab();
				Precondition.RightClick(treeitem);
				Precondition.QueryAnalyser(repo);
				Precondition.DropDatabase(repo, server);
				Precondition.CloseTab();
				ReportLog(ex.StackTrace.ToString(), ADSReportLevel.Fail, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);						
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
