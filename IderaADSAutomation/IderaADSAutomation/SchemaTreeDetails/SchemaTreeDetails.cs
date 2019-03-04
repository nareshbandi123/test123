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

namespace IderaADSAutomation.SchemaTreeDetails
{
    [TestModule("80FEAB30-714C-4CF4-B40C-2528EEBF934E", ModuleType.UserCode, 1)]
    public class SchemaTreeDetails : ITestModule
    {
    	private string RegisterServerTestDataPath = System.Configuration.ConfigurationManager.AppSettings["RegisterNewServer"].ToString();
    	private string SCRIPTFILE = System.Configuration.ConfigurationManager.AppSettings["ScriptFile"].ToString();
    	private string QueryTestDataPath = System.Configuration.ConfigurationManager.AppSettings["Queries"].ToString();
    	RegisterServerData registerServerData = new RegisterServerData();
    	List<Server> servers = new List<Server>();
    	Server server = new Server();
    	IderaADSAutomationRepository repo = IderaADSAutomationRepository.Instance;
    	
        public SchemaTreeDetails()
        {
        }

        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 0;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            var curTestCase = (TestCaseNode)TestSuite.CurrentTestContainer;
            Precondition.SetTCName(curTestCase);
            server = registerServerData.GetSingleServer(RegisterServerTestDataPath, Precondition.GetServerName(Precondition.TestCaseName), false);
            
			
            if(repo.Application.SelfInfo.Exists(new Duration(180000)))
            {
            	repo.Application.Self.Activate();
            	ReportLog("Schema Tree Test - Start", ADSReportLevel.Info, null, Precondition.TestCaseName);
	            StartProcess(server);
	            ReportLog("Schema Tree Test - End", ADSReportLevel.Info, null, Precondition.TestCaseName);
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
	        	Precondition.CreateView(repo, server);
				Precondition.CreateIndex(repo, server);
				Precondition.CreateTrigger(repo, server);
				Precondition.CloseTab();
				
				ReportLog("Preconditions - Done", ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
	        	Precondition.TreeItemDoubleClickToExpand(treeitem);
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
	        		System.Threading.Thread.Sleep(600);
					TreeItem publictreeitem = Precondition.GetItem(adsdbtreeitem, "public");
					if(publictreeitem == null) { publictreeitem = Precondition.GetItem(adsdbtreeitem, "dbo"); }
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
	        		TableSelected = adsdbtablestreeitem;
	        	}
	        	
	        	TableSelected.Expand();
	        	foreach (var items in TableSelected.Items) // ads_table
	        	{
	        		items.EnsureVisible();
	        		items.Expand();
        			ReportLog("Validate Schema tree : " + items.Text, ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
        			System.Threading.Thread.Sleep(1000);
	        		foreach (var childitem in items.Items) // columns, constraints, indexes
	        		{
	        			childitem.EnsureVisible();
	        			childitem.Expand();
        				ReportLog("Validate Schema tree : " + childitem.Text , ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
	        			System.Threading.Thread.Sleep(1000);
        				foreach (var enditem in childitem.Items) // individual child
		        		{
	        				enditem.EnsureVisible();
	        				enditem.Expand();
	        				ReportLog("Validate Schema tree : " + enditem.Text , ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
		        			System.Threading.Thread.Sleep(1000);
        				}
	        		}
	        	}
	        	
	        	ReportLog("Verify the Schema tree - Done", ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
	        	treeitem.CollapseAll();
				Precondition.RightClick(treeitem);
				Precondition.DisconnectServer(repo);
				
				Precondition.RightClick(treeitem);
				Precondition.QueryAnalyser(repo);
				Precondition.SelectDBFromComboBox(repo, server, "ads_db");
				Precondition.DropTrigger(repo, server);
				Precondition.DropIndex(repo, server);
				Precondition.DropView(repo, server);
				Precondition.DropTable(repo,server);
				Precondition.CloseTab();
				
				Precondition.RightClick(treeitem);
				Precondition.QueryAnalyser(repo);
				Precondition.DropDatabase(repo, server);
				Precondition.CloseTab();
				ReportLog("Clean up - Done", ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
			}
			catch(Exception e)
			{
				ReportLog(e.StackTrace.ToString(), ADSReportLevel.Fail, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
				treeitem.CollapseAll();
				Precondition.RightClick(treeitem);
				Precondition.DisconnectServer(repo);
				Precondition.RightClick(treeitem);
				Precondition.QueryAnalyser(repo);
				Precondition.SelectDBFromComboBox(repo, server, "ads_db"); 
				Precondition.DropTable(repo,server);
				Precondition.DropDatabase(repo, server);
				Precondition.CloseTab();
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
