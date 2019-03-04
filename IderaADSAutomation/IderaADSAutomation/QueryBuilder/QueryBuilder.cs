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

namespace IderaADSAutomation.QueryBuilder
{
    [TestModule("D5580B65-D511-49DB-B8C0-7B898D01BDB5", ModuleType.UserCode, 1)]
    public class QueryBuilder : ITestModule
    {
    	
    	private string RegisterServerTestDataPath = System.Configuration.ConfigurationManager.AppSettings["RegisterNewServer"].ToString();
    	private string QueryTestDataPath = System.Configuration.ConfigurationManager.AppSettings["Queries"].ToString();
    	RegisterServerData registerServerData = new RegisterServerData();
    	List<Server> servers = new List<Server>();
    	Server server = new Server();
    	IderaADSAutomationRepository repo = IderaADSAutomationRepository.Instance;
    	Duration duration = new Duration(200);
    	Duration duration5k = new Duration(500);
    	Duration appduration = new Duration(180000);
    	IderaADSAutomation.QueryAnalyzer.QueryAnalyzer queryanalyzer = new IderaADSAutomation.QueryAnalyzer.QueryAnalyzer();
    	
        public QueryBuilder()
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
            
            	ReportLog("Query Builder Test - Start", ADSReportLevel.Info, null, Precondition.TestCaseName);
            	repo.Application.Self.Activate();
            	this.StartProcess(server);
            	ReportLog("Query Builder Test - End", ADSReportLevel.Info, null, Precondition.TestCaseName);
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
				Precondition.CreateDatabase(repo, server);
				Precondition.CloseTab();
				Precondition.RightClick(treeitem);
				Precondition.ReConnectServer(repo);
				Precondition.RightClick(treeitem);
				Precondition.DisconnectServer(repo);
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
				Precondition.CloseTab();
	        	ReportLog("Preconditions - Done", ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
				
	        	ReportLog("Query Builder Execution Start - Done", ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
    			Precondition.Click(repo.Application.QueryBuilder);
    			Precondition.ClickQBNew(repo);
    			
    			Ranorex.MenuItem NewItem = Precondition.GetMenunItem(repo.ContextMenu.ServerContextMenu, "New");
    			Precondition.Click(NewItem);

    			Precondition.Click(repo.Datastudio.ContainerBase.ConnectToServer);
    			Precondition.ClickQBDBTree(repo);
    			
    			repo.ChooseServer.DBTreeInfo.WaitForExists(new Duration(60000));
    			TreeItem selecteditem = Precondition.GetItem(repo.ChooseServer.DBTree, server.RegistredServerName);
    			Precondition.TreeItemExpand(selecteditem);
    			System.Threading.Thread.Sleep(600);
    			
    			string filterDBName = "ads_db";
    			if(restrict.Contains(server.RegistredServerName))
    				filterDBName = "aquafold";
    			
    			TreeItem adsdbitem = Precondition.GetItem(selecteditem, filterDBName);
    			System.Threading.Thread.Sleep(600);
    			if(adsdbitem == null) adsdbitem = Precondition.GetItem(selecteditem, "ADS_DB");
    			if(adsdbitem != null) adsdbitem.Select();
	
    			System.Threading.Thread.Sleep(200);
				Precondition.Click(repo.ExportDBServerList.ButtonOk);
				
				if(restrict.Contains(server.RegistredServerName))
				{
					Precondition.Click(repo.QueryBuilder.VerticaScemaConnectionMenu);
					try { repo.SunAwtWindow.AddSchemaInfo.WaitForExists(new Duration(6000)); } catch { Precondition.Click(repo.QueryBuilder.VerticaScemaConnectionMenu); }
					Precondition.Click(repo.SunAwtWindow.AddSchema);
					try { repo.AddSchema.ads_db_SchemaInfo.WaitForExists(new Duration(6000)); } catch { Precondition.Click(repo.QueryBuilder.VerticaScemaConnectionMenu); Precondition.Click(repo.SunAwtWindow.AddSchema);}
					TreeItem ads_db_item = Precondition.GetItem(repo.AddSchema.ads_db_Schema, "ads_db");
					Precondition.Click(ads_db_item);
					Precondition.Click(repo.AddSchema.OkButton);
				}
				
				TreeItem table = null;
				if(server.RegistredServerName == "SQL Server 172.24.1.199 2016")
				{
					repo.QueryBuilder.DBOTreeInfo.WaitForExists(new Duration(180000));
					repo.QueryBuilder.DBOTree.EnsureVisible();
					repo.QueryBuilder.DBOTree.ExpandAll();
					System.Threading.Thread.Sleep(600);
					repo.QueryBuilder.DBOTree.Items[0].Expand();
					System.Threading.Thread.Sleep(600);
					table = repo.QueryBuilder.DBOTree.Items[0];
					if(table.EnsureVisible() && !table.Expanded)
						table.ExpandAll();
				}
				else if(server.RegistredServerName == "Sybase ASE 172.24.1.145 v16" || server.RegistredServerName == "Sybase ASE 172.24.1.6 v15.7")
				{
					repo.QueryBuilder.QBTableTreeInfo.WaitForExists(new Duration(180000));
					repo.QueryBuilder.QBTableTree.ExpandAll();
					System.Threading.Thread.Sleep(600);
					repo.QueryBuilder.QBTableTree.Items[0].Expand();
					System.Threading.Thread.Sleep(600);
					repo.QueryBuilder.QBTableTree.Items[0].Items[0].Expand();
					System.Threading.Thread.Sleep(600);
					repo.QueryBuilder.QBTableTree.Items[0].Items[0].Items[0].Expand();
					System.Threading.Thread.Sleep(600);
					table = repo.QueryBuilder.QBTableTree.Items[0].Items[0].Items[0];
					if(table.EnsureVisible() && !table.Expanded)
						table.ExpandAll();
				}
				else
				{
					repo.QueryBuilder.QBTableTreeInfo.WaitForExists(new Duration(180000));
					repo.QueryBuilder.QBTableTree.ExpandAll();
					System.Threading.Thread.Sleep(600);
					repo.QueryBuilder.QBTableTree.Items[0].Expand();
					System.Threading.Thread.Sleep(600);
					repo.QueryBuilder.QBTableTree.Items[0].Items[0].Expand();
					System.Threading.Thread.Sleep(600);
					table = repo.QueryBuilder.QBTableTree.Items[0].Items[0];
					if(table.EnsureVisible() && !table.Expanded)
						table.ExpandAll();
				}
				
				if(table == null)
				{
					Precondition.CloseTab();
					ReportLog("Table Creation Failed", ADSReportLevel.Fail, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
					throw new Exception();
				}
				
				repo.QueryBuilder.Self.Activate();
				repo.QueryBuilder.Self.EnsureVisible();
				
				TreeItem firstnameTreeItem = null;
				TreeItem lastnameTreeItem = null;
				
				System.Threading.Thread.Sleep(600);
				foreach (var item in table.Items[0].Items) {
					System.Threading.Thread.Sleep(600);
					string[] itemText = item.Text.Split(':');
					if (itemText[0].Trim().ToLower() == "firstname")
					{
						if(item.EnsureVisible())
						{
							firstnameTreeItem = item;
							break;
						}
					}
				}
				
				if(!server.RegistredServerName.Contains("Teradata 10.90.1.175 v15.0"))
				{
					System.Threading.Thread.Sleep(600);
					foreach (var item in table.Items[0].Items) {
						System.Threading.Thread.Sleep(600);
						string[] itemText = item.Text.Split(':');
						if (itemText[0].Trim().ToLower() == "lastname") 
						{
							if(item.EnsureVisible())
							{
								lastnameTreeItem = item;
								break;
							}
						}
					}
				}
				
				firstnameTreeItem.MoveTo("42;9");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            System.Threading.Thread.Sleep(200);
        		
        		repo.Datastudio.ContainerBase.ContainerPHA.MoveTo("61;8");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            System.Threading.Thread.Sleep(200);
	            
	            if(!server.RegistredServerName.Contains("Teradata 10.90.1.175 v15.0"))
				{
		            lastnameTreeItem.MoveTo("50;10");
		            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
		            System.Threading.Thread.Sleep(200);
		            
		            repo.Datastudio.ContainerBase.ContainerPHA.MoveTo("44;5");
		            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
		            System.Threading.Thread.Sleep(200);
	            }
	            
	            Precondition.Click(repo.Datastudio.ButtonGzu);
	            System.Threading.Thread.Sleep(1000);
	            Precondition.DeleteFiles("ADS_QB.qbw");
	            repo.QueryBuilder.Self.Activate();
				repo.QueryBuilder.Self.EnsureVisible();
	            Precondition.Click(repo.Datastudio.Close1);
	            Precondition.Click(repo.Datastudio.SaveAs);
	            Precondition.Click(repo.Datastudio.FileName);
	            repo.Datastudio.FileName.PressKeys("ADS_QB");
	            Precondition.Click(repo.Datastudio.Open);
	            System.Threading.Thread.Sleep(1000);
	            
	            Precondition.Click(repo.Datastudio.QueryBuilder);
	            Precondition.ClickQBOpen(repo);
	            Precondition.Click(repo.ContextMenu.Open);
	            Precondition.TextboxText(repo.QueryAnalyzerOpenScript.FolderToOpen,"ADS_QB.qbw");
	            Precondition.Click(repo.Datastudio.Open);
	            repo.Datastudio.ButtonGzuInfo.WaitForExists(new Duration(180000));
	            Precondition.Click(repo.Datastudio.ButtonGzu);
            	System.Threading.Thread.Sleep(5000);
	            Precondition.Click(repo.Datastudio.Close1);
	            if(repo.Datastudio.DiscardInfo.Exists(new Duration(1000))) Precondition.Click(repo.Datastudio.Discard);
	            ReportLog("Query Builder Execution End - Done", ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
	            System.Threading.Thread.Sleep(200);
	            
	            ReportLog("Cleanup Data start - Done", ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
	            Precondition.RightClick(treeitem);
	            Precondition.QueryAnalyser(repo);
	            Precondition.SelectDBFromComboBox(repo, server,"ads_db");
				Precondition.DropTable(repo,server);
				Precondition.CloseTab();
				Precondition.RightClick(treeitem);
	            Precondition.DisconnectServer(repo);
	            Precondition.RightClick(treeitem);
	            Precondition.QueryAnalyser(repo);
	            Precondition.DropDatabase(repo, server);
	        	Precondition.CloseTab();
	        	
	        	Precondition.DeleteFiles("ADS_QB.qbw");
	        	
	        	ReportLog("Cleanup Data end - Done", ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
			}
			catch(Exception e)
			{	
				Precondition.Escape();
				if(repo.Datastudio.SelfInfo.Exists(new Duration(1000)))
				{
					repo.Datastudio.Self.Activate();
					repo.Datastudio.Self.Close();
		            if(repo.Datastudio.DiscardInfo.Exists(new Duration(1000))) Precondition.Click(repo.Datastudio.Discard);
				}
				Precondition.CloseTab();
				Precondition.DeleteFiles("ADS_QB.qbw");
				Precondition.RightClick(treeitem);
	            Precondition.QueryAnalyser(repo);
	            Precondition.SelectDBFromComboBox(repo, server,"ads_db");
				Precondition.DropTable(repo,server);
				Precondition.CloseTab();
				Precondition.RightClick(treeitem);
	            Precondition.DisconnectServer(repo);
	            Precondition.RightClick(treeitem);
	            Precondition.QueryAnalyser(repo);
	            Precondition.DropDatabase(repo, server);
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
