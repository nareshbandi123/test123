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

namespace IderaADSAutomation.TableEditor
{
    [TestModule("0AAC307F-09EC-4014-B190-E6EABF6F87F0", ModuleType.UserCode, 1)]
    public class TableEditor : ITestModule
    {
    	private string RegisterServerTestDataPath = System.Configuration.ConfigurationManager.AppSettings["RegisterNewServer"].ToString();
    	private string QueryTestDataPath = System.Configuration.ConfigurationManager.AppSettings["Queries"].ToString();
    	RegisterServerData registerServerData = new RegisterServerData();
    	List<Server> servers = new List<Server>();
    	Server server = new Server();
    	IderaADSAutomationRepository repo = IderaADSAutomationRepository.Instance;
    	
        public TableEditor()
        {
        }

        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 0;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            if(repo.Application.SelfInfo.Exists(new Duration(Precondition.ApplicationOpenWaitTime)))
            {
            	var curTestCase = (TestCaseNode)TestSuite.CurrentTestContainer;
	            Precondition.SetTCName(curTestCase);
	            server = registerServerData.GetSingleServer(RegisterServerTestDataPath, Precondition.GetServerName(Precondition.TestCaseName), false);
            
            	repo.Application.Self.Activate();
            	ReportLog("Table Editor Test - Start", ADSReportLevel.Info, null, Precondition.TestCaseName);
	            StartProcess(server);
	            ReportLog("Table Editor Test - End", ADSReportLevel.Info, null, Precondition.TestCaseName);
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
    				Precondition.CloseTab();
					return;
				}
				Precondition.CreateTableWithConstrains(repo, server);
	        	Precondition.CloseTab();
	        	Precondition.TreeItemDoubleClickToExpand(treeitem);
    			ReportLog("Preconditions - Done", ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
    			
	        	TreeItem TableSelected = null;
	        	if(Precondition.SchemaItems.Contains(server.DatabaseKey))
	        	{
	        	   	TreeItem schematreeitem = server.DatabaseKey == "Schema" ? Precondition.GetItem(treeitem, "Schema") : Precondition.GetItem(treeitem, "Keyspaces");
	        		System.Threading.Thread.Sleep(600);
	        		TreeItem adsdbtreeitem = server.DatabaseKey == "Schema" ? Precondition.GetItem(schematreeitem, "ADS_DB") : Precondition.GetItem(schematreeitem, "ads_db");
	        		System.Threading.Thread.Sleep(600);
	        		TreeItem tablestreeitem = Precondition.GetItem(adsdbtreeitem, "Tables");	
	        		System.Threading.Thread.Sleep(600);
	        		TreeItem adsdbtablestreeitem = server.DatabaseKey == "Schema" ? Precondition.GetItem(tablestreeitem, "ADS_TABLE") : Precondition.GetItem(tablestreeitem, "ads_table");
	        		if(adsdbtablestreeitem == null) { adsdbtablestreeitem = server.DatabaseKey == "Schema" ? Precondition.GetItem(tablestreeitem, "ADS_DB.ADS_TABLE") : Precondition.GetItem(tablestreeitem, "ads_db.ads_table");}
	        		if(adsdbtablestreeitem == null) { adsdbtablestreeitem = server.DatabaseKey == "Schema" ? Precondition.GetItem(tablestreeitem, "ADS_DB.ads_table") : Precondition.GetItem(tablestreeitem, "ads_db.ads_table");}
	        		TableSelected = adsdbtablestreeitem;
	        	}
	        	if (server.DatabaseKey == "Databases") 
	        	{
	        		TreeItem schematreeitem = Precondition.GetItem(treeitem, "Databases");
	        		if(restrict.Contains(server.RegistredServerName)) { schematreeitem = Precondition.GetItem(schematreeitem, "aquafold"); }
	        		System.Threading.Thread.Sleep(600);
	        		TreeItem adsdbtreeitem = Precondition.GetItem(schematreeitem, "ads_db");
	        		if(adsdbtreeitem == null) adsdbtreeitem = Precondition.GetItem(schematreeitem, "ADS_DB");
	        		System.Threading.Thread.Sleep(600);
					TreeItem publictreeitem = Precondition.GetItem(adsdbtreeitem, "public");
					if(publictreeitem == null) { publictreeitem = Precondition.GetItem(adsdbtreeitem, "dbo"); }
					if(publictreeitem == null) { publictreeitem = Precondition.GetItem(adsdbtreeitem, "ADMIN"); }
					System.Threading.Thread.Sleep(600);					
					if(publictreeitem == null) publictreeitem = adsdbtreeitem;
	        		TreeItem tablestreeitem = Precondition.GetItem(publictreeitem, "Tables");
	        		System.Threading.Thread.Sleep(600);	
	        		if(tablestreeitem == null){ tablestreeitem = Precondition.GetItem(publictreeitem, "User Tables"); }
					System.Threading.Thread.Sleep(600);        		
	        		TreeItem adsdbtablestreeitem = Precondition.GetItem(tablestreeitem, "public.ads_table");
	        		if(adsdbtablestreeitem == null) { adsdbtablestreeitem = Precondition.GetItem(tablestreeitem, "dbo.ads_table"); }
	        		if(adsdbtablestreeitem == null) { adsdbtablestreeitem = Precondition.GetItem(tablestreeitem, "ads_db.ads_table"); }
	        		if(adsdbtablestreeitem == null) { adsdbtablestreeitem = Precondition.GetItem(tablestreeitem, "ads_table"); }
	        		if(adsdbtablestreeitem == null) { adsdbtablestreeitem = Precondition.GetItem(tablestreeitem, "ADMIN.ADS_TABLE"); }
	        		
	        		TableSelected = adsdbtablestreeitem;
	        	}	
	        	
	        	Precondition.RightClick(TableSelected);
	        	try{repo.ContextMenu.EditTableDataInfo.WaitForExists(new Duration(6000));}catch{Precondition.RightClick(TableSelected);}
	        	Precondition.Click(repo.ContextMenu.EditTableData);
	        	
	        	if(repo.TableDataEditor.SelfInfo.Exists())
	        	{
	        		Precondition.Click(repo.TableDataEditor.OkButton);
	        		ReportLog("Table Editor Not supported", ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
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
					return;
	        	}
	        	
				
				string formtitle = server.RegistredServerName +" : Editing:";
				string formtag = "/form[@title~'^" + formtitle +"']";
				Ranorex.Button AddNewButton = formtag + "//container[@name='contentPanel']//button[@name='gOx']";
				Precondition.Click(AddNewButton);
				
				Ranorex.Table table = formtag + "//container[@name='contentPanel']//container[@name='guS']/container[@name='gLL']//table[@name='gLD']";
				
				int i = 0;
				foreach (var cell in table.Rows[0].Cells)
				{
					i++;
					cell.DoubleClick();
					System.Threading.Thread.Sleep(500);
					Keyboard.Press(i.ToString());
				}
				System.Threading.Thread.Sleep(500);
				
				Ranorex.Button CloseButton = formtag + "//button[@accessiblename='Close']";
				Precondition.Click(CloseButton);
				if(repo.TableModified.SelfInfo.Exists(new Duration(500)))
					Precondition.Click(repo.TableModified.SaveButton);
				else Precondition.CloseTab();
				
				Precondition.RightClick(TableSelected);
				Precondition.SelectQueryFromMenu(repo);
				System.Threading.Thread.Sleep(1000);
				Precondition.Execute(repo, server);
				System.Threading.Thread.Sleep(2000);
				Precondition.CloseTab();
	        	if(repo.FileModified.SelfInfo.Exists(new Duration(500)))
					Precondition.Click(repo.FileModified.DiscardButton);
	        	Precondition.TreeItemCollapse(treeitem);
	        	ReportLog("Table Editor Execution - Done", ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
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
				
				if(repo.TableModified.SelfInfo.Exists(new Duration(1000)))
					Precondition.Click(repo.TableModified.DiscardButton);
				
				ReportLog("Cleanup data - Done", ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
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
				ReportLog(ex.Message.ToString(), ADSReportLevel.Fail, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
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
