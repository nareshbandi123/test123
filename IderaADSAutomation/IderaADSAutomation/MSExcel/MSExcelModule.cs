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
using IderaADSAutomation.RegisterServer;
using IderaADSAutomation.Preconditions;

namespace IderaADSAutomation.MSExcel
{
    [TestModule("80828B85-13A1-4FBB-A61B-B5F22D1E5A1E", ModuleType.UserCode, 1)]
    public class MSExcelModule : ITestModule
    {
    	Server server = null;
    	IderaADSAutomationRepository repo = IderaADSAutomationRepository.Instance;
    	RegisterNewServer registerNewServer = new RegisterNewServer();
    	Duration appduration = new Duration(180000);
    	
    	public MSExcelModule()
        {
    		server = new Server
    		{
    			ServerName = "MS Excel",
    			NameXPath = "//container[@name='fSl']//text[@name='ea']",
    			RegistredServerName = "MS Excel"
    		};
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
				ReportLog("MS Excel Test - Start", ADSReportLevel.Info, null, Precondition.TestCaseName);
				registerNewServer.ShowMainWindow();
				ReportLog("MS Excel Test - End", ADSReportLevel.Info, null, Precondition.TestCaseName);
				Start_Process();
            }
        }
        
        void Start_Process()
        {
        	TreeItem treeitem =  null;
    		
    		try 
    		{
	    		treeitem = GetItem(repo.QueryAnalyzerConfiguraion.DBServerList, server.RegistredServerName);
	        	if(treeitem == null)
	        	{
		    		registerNewServer.ClickOnServerTab(server);
		            registerNewServer.SelectRegisterServer(server);
		            registerNewServer.ClickOnGeneralTab(server);
		            registerNewServer.SelectDBServer(server);
		            registerNewServer.EnterNameText(server);
		            SetDirectory(server);
		            registerNewServer.ClickOnTestConnectionButton(server, true);
	        	}
	        	
	        	if(repo.Datastudio.MyFirstComponent.MSExcel != null && repo.Datastudio.MyFirstComponent.MSExcel.EnsureVisible())
				{
					repo.Datastudio.MyFirstComponent.MSExcel.Click();
					repo.Datastudio.MyFirstComponent.MSExcel.Click(System.Windows.Forms.MouseButtons.Right, "26;7");
					repo.ContextMenu.Connect.Click();
						
					TreeItem databasestreeitem = GetItem(treeitem, "Databases");
					TreeItem databasetreeitem = GetItem(databasestreeitem, "TC_10473");
					TreeItem schematreeitem = GetItem(databasetreeitem, "bistudio_example");
					TreeItem tablestreeitem = GetItem(schematreeitem, "Tables");
					TreeItem tabletreeitem = GetItem(tablestreeitem, "bistudio_example");
					
					repo.Datastudio.MyFirstComponent.BistudioExample.Click();
					repo.Datastudio.MyFirstComponent.BistudioExample.Click(System.Windows.Forms.MouseButtons.Right, "21;8");
					repo.Datastudio.SelectObjectAs.Click();
					repo.ContextMenu.SELECTAsterisk.Click();
					repo.QueryAnalyzerConfiguraion.AmazonRedshiftDB.ButtonGzu.Click();
					repo.Datastudio.Jꆗᢂꏨthis.Messages.Click();
					repo.Datastudio.Jꆗᢂꏨthis.Grid.Click();
					repo.Datastudio.Jꆗᢂꏨthis.Vꎟꉢ.Click();
					
					ReportLog("Preconditions - Done", ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
					ReportLog("MS Excel Data Execution start - Done", ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
					repo.Datastudio.ContainerDob.CardType.Click();
					repo.Datastudio.ContainerDob.CardType.MoveTo("58;9");
					Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
					Delay.Milliseconds(200);
					repo.Datastudio.ContainerDob.CardType.MoveTo("66;1");
					Delay.Milliseconds(200);
					repo.Datastudio.ContainerDob.ContainerPHA.MoveTo("63;7");
					Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
					Delay.Milliseconds(200);
					repo.Datastudio.ContainerDob.City.Click();
					Delay.Milliseconds(200);
					repo.Datastudio.ContainerDob.City.MoveTo("35;7");
					Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
					Delay.Milliseconds(200);
					repo.Datastudio.ContainerDob.City.MoveTo("43;1");
					Delay.Milliseconds(200);
					repo.Datastudio.ContainerDob.ContainerPHA1.MoveTo("67;9");
					Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
					Delay.Milliseconds(200);
					repo.Datastudio.Worksheet1.Oꐷᢨthrows.MoveTo("373;92");
					Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
					Delay.Milliseconds(200);
					repo.Datastudio.Worksheet1.Oꐷᢨthrows.MoveTo("373;92");
					Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
					Delay.Milliseconds(200);
					repo.Datastudio.Close1.Click();					
					if(repo.SaveChanges.DiscardButtonInfo.Exists())
						repo.SaveChanges.DiscardButton.Click();
					
					repo.QueryAnalyzerConfiguraion.QueryAnalyzerDBSelect.EnsureVisible();
					Precondition.CloseTab();

					if(repo.FileModified.DiscardButtonInfo.Exists())
						repo.FileModified.DiscardButton.Click();
					Delay.Milliseconds(200);
					repo.Datastudio.MyFirstComponent.MSExcel.Click(System.Windows.Forms.MouseButtons.Right, "55;8");
					Delay.Milliseconds(200);
					repo.ContextMenu.Disconnect.Click();
					Delay.Milliseconds(200);
					
					ReportLog("MS Excel Data Execution end - Done", ADSReportLevel.Success, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
				}
				else
				{	
					ReportLog("MS Excel data not found", ADSReportLevel.Fail, repo.Datastudio.MyFirstComponent.MSExcel, Precondition.TestCaseName +  ":" + server.RegistredServerName);
				}
    		} 
    		catch (Exception ex) 
    		{
    			ReportLog(ex.StackTrace.ToString(), ADSReportLevel.Fail, repo.Datastudio.MyFirstComponent.MSExcel, Precondition.TestCaseName +  ":" + server.RegistredServerName);
    		}	
        }
        
        void SetDirectory(Server server)
        {
        	string xPath = "//container[@name='fZc']//text[@name='fZb']";
        	var nameContainer = repo.RegisterServer.NameContainer.Find<Ranorex.Text>(xPath);
        	nameContainer[0].Focus();
    		nameContainer[0].TextValue = @"C:\Users\Admin\Documents\Ranorex\RanorexStudio Projects\IderaADSAutomation\IderaADSAutomation\Testdata\TC_10473"; 
        }
        
        public TreeItem GetItem(Ranorex.TreeItem treeitem, string dbkey, bool isExpand = true)
        {
        	TreeItem item = null;
        	foreach (var itemtree in treeitem.Items) 
        	{
        		if(itemtree.Text.Trim() == dbkey)
    			{
        			itemtree.Collapse();
        			if(isExpand)
        			{
	        			itemtree.Expand();
	        			itemtree.UseEnsureVisible = true;
        			}
					item = itemtree;
					System.Threading.Thread.Sleep(500);
    				break;
    			}
        	}
        	return item;
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
