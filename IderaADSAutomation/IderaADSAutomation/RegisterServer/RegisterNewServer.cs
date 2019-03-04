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

namespace IderaADSAutomation.RegisterServer
{
    [TestModule("CF519057-3BD0-4865-B1D4-9B4CE07B5C8E", ModuleType.UserCode, 1)]
    public class RegisterNewServer : ITestModule
    {	
    	private string RegisterServerTestDataPath = System.Configuration.ConfigurationManager.AppSettings["RegisterNewServer"].ToString();
    	RegisterServerData registerServerData = new RegisterServerData();
    	List<Server> servers = new List<Server>();
    	Server server = new Server();
    	List<TestCase> testcases = new List<TestCase>();
    	IderaADSAutomationRepository repo = IderaADSAutomationRepository.Instance;
    	Duration duration = new Duration(200);
    	Duration duration5k = new Duration(500);
    	Duration appduration = new Duration(180000);
    	string TestCaseNo = "10470";
    	
        public RegisterNewServer()
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
            
            if(repo.Application.SelfInfo.Exists(appduration))
            {
            	repo.Application.Self.Activate();
            	ShowMainWindow();
	            StartProcess(server);
            }
        }
        
        void StartProcess(List<Server> Servers)
        {
        	foreach (var server in servers)
            {
				try 
				{
		    		ReportLog(server.ServerName + " - Start", ADSReportLevel.Info, null, Precondition.TestCaseName + " : " + server.ServerName);
		    		if(!ClickOnServerTab(server)) continue; 
		            if(!SelectRegisterServer(server)) continue;
		            if(!ClickOnGeneralTab(server)) continue;
		            if(!SelectDBServer(server)) continue;
		            if(!EnterNameText(server)) continue;
		            if(server.ServerName.ToLower().Contains("oracle")){repo.RegisterServer.OracleConnectAsCombobox.SelectedItemIndex = 2;}
		            if(server.ServerName.ToLower().Contains("mongodb")){MongoDBNoAuthentication(server);}
		            else{if(!EnterLoginNameText(server)) continue;if(!EnterLoginPasswordText(server)) continue;}
		            if(!EnterHostText(server)) continue;
		            if(!EnterPortText(server)) continue;
		            if(!EnterDatabaseText(server)) continue;
		            if(!ClickOnTestConnectionButton(server)) continue;
		            ReportLog(server.ServerName + " - End", ADSReportLevel.Info, null, Precondition.TestCaseName + " : " + server.ServerName);
		            
	            } 
        		catch (Exception e) 
        		{
        			ReportLog(e.StackTrace.ToString(), ADSReportLevel.Fail, null, Precondition.TestCaseName + " : " + server.ServerName);
				}   
            }
        	ShowMainWindow();
        	
        }
        
        void StartProcess(Server server)
        {
			try 
			{
	    		ReportLog(server.ServerName + " - Start", ADSReportLevel.Info, null, Precondition.TestCaseName + " : " + server.ServerName);
	    		if(!ClickOnServerTab(server)) return; 
	            if(!SelectRegisterServer(server)) return;
	            if(!ClickOnGeneralTab(server)) return;
	            if(!SelectDBServer(server)) return;
	            if(!EnterNameText(server)) return;
	            if(server.ServerName.ToLower().Contains("oracle")){repo.RegisterServer.OracleConnectAsCombobox.SelectedItemIndex = 2;}
	            if(server.ServerName.ToLower().Contains("mongodb")){MongoDBNoAuthentication(server);}
	            else{if(!EnterLoginNameText(server)) return;if(!EnterLoginPasswordText(server)) return;}
	            if(!EnterHostText(server)) return;
	            if(!EnterPortText(server)) return;
	            if(!EnterDatabaseText(server)) return;
	            if(!ClickOnTestConnectionButton(server)) return;
	            ReportLog(server.ServerName + " - End", ADSReportLevel.Info, null, Precondition.TestCaseName + " : " + server.ServerName);
	            
            } 
    		catch (Exception e) 
    		{
    			ReportLog(e.StackTrace.ToString(), ADSReportLevel.Fail, null, Precondition.TestCaseName + " : " + server.ServerName);
    			string caseNo = Precondition.GetCase(server.RegistredServerName, TestCaseNo);
    			Precondition.UpdateStatus(5, caseNo);
			}   
        }
        
        public bool ClickOnServerTab(Server server)
        {
        	string message = "";
        	try 
        	{	
        		ShowMainWindow();
        		Precondition.Click(repo.Application.Server);
        		message = string.Format("{0} {1}", RegistrationConstants.ServerMenu, RegistrationConstants.Clicked);
        		ReportLog(message, ADSReportLevel.Success, null, server.ServerName);
	        	return true;
        	} 
        	catch
        	{
        		message = string.Format("{0} {1} {2}", RegistrationConstants.ServerMenu, RegistrationConstants.Click, RegistrationConstants.Failed);
        		ReportLog(message, ADSReportLevel.Fail, repo.Application.Menubar, server.ServerName);
        		return false;
        	}     	
        }
        
        public bool SelectRegisterServer(Server server, bool isRetry = false)
        {
        	string message = "";
        	try
        	{
        		if(!repo.ContextMenu.ServerContextMenuInfo.Exists(new Duration(1000)))Precondition.Click(repo.Application.Server);
        		var items = repo.ContextMenu.ServerContextMenu.Items;
        		foreach (var item in items) 
        		{
        			if(item.Text.ToLower() == "register server")
        			{
        				Precondition.Click(item);
        				if(!isRetry)
        				{
	        				message = "Register New Server Menu Item Selected : " + server.ServerName;
		        			ReportLog(message, ADSReportLevel.Success, null, server.ServerName);
        				}
	        			break;
        			}        			
        		}
        		return true;
        	}
        	catch
        	{
        		message = "Register New Server Menu Item Selection failed";
	        	ReportLog(message, ADSReportLevel.Fail, repo.ContextMenu.ServerContextMenu, server.ServerName);
        		return false;
        	}
        }
        
        public bool ClickOnGeneralTab(Server server)
        {	
        	string message = "";
        	try
        	{
        		if(!repo.RegisterServer.GeneralTabInfo.Exists(new Duration(1000))){Precondition.Click(repo.Application.Server);SelectRegisterServer(server, true);}
	        	Precondition.Click(repo.RegisterServer.GeneralTab);
	        	message = "General tab selected";
		        ReportLog(message, ADSReportLevel.Success, null, server.ServerName);
				return true;	        	
        	}
        	catch
        	{
        		message = "General tab selection failed";
		        ReportLog(message, ADSReportLevel.Fail, repo.RegisterServer.Self, server.ServerName); 
        		CloseRegistrationWindow();
				return false;        		
        	}
        }
        
        public bool SelectDBServer(Server server)
        {
        	string message = "";
        	bool returnvalue = false;
        	try
        	{
        		var items = repo.RegisterServer.DBServerList.Items;
        		foreach (var item in items) 
        		{
        			if(item.Text == server.ServerName)
        			{
        				Precondition.Click(item);
						message = "Select the Database Server -" + item.Text;
		        		ReportLog(message, ADSReportLevel.Success, null, server.ServerName);
						returnvalue = true;		        		
		        		break;
        			}
        		}
        	} 
        	catch
        	{
        		message = "Select the Database Server failed -" + server.ServerName;
    			ReportLog(message, ADSReportLevel.Fail, repo.RegisterServer.DBServerList, server.ServerName);  
        		CloseRegistrationWindow();
        	}
        	
        	return returnvalue;
        }
        
        bool InvokeControls(string xPath, string controlValue, string controlName, Server server)
        {
        	string message = "";
        	if(string.IsNullOrEmpty(xPath)) return true;
        	
        	try 
        	{
        		Ranorex.Text text = @"/form[@title~'^Register\ Server\ ']/container[@name='fMn']/container[@name='fRq']//container[@name='fSn']" + xPath;
        		Precondition.InvokeTextboxText(text, controlValue);
        		
        		if(!controlName.ToLower().Contains("login password"))
        			ReportLog(controlName  + " : " + controlValue, ADSReportLevel.Success, null, server.ServerName); 	        			
        		
				return true;	        	
        	} 
        	catch
        	{
        		message = controlName + " control not available";
    			ReportLog(message, ADSReportLevel.Fail, repo.RegisterServer.NameContainer, server.ServerName); 	        			
				CloseRegistrationWindow();        		
        		return false;
        	}        	
        }
        
        public bool EnterNameText(Server server)
        {
        	return InvokeControls(server.NameXPath, server.RegistredServerName, "Name", server);
        }
        
        bool MongoDBNoAuthentication(Server server)
        {
        	try
        	{
				Keyboard.PrepareFocus(repo.RegisterServer.ComboBoxESn);
	            Keyboard.Press(System.Windows.Forms.Keys.Up, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
	        	ReportLog("No Authentication selected", ADSReportLevel.Success, null, server.ServerName); 	        			
	        	return true;
        	}
        	catch
        	{
        		ReportLog("No Authentication selected", ADSReportLevel.Fail, repo.RegisterServer.ComboBoxESn, server.ServerName); 
        		return false;
        	}
        }
        
        bool EnterLoginNameText(Server server)
        {
        	return InvokeControls(server.LoginNameXPath, server.LoginName, "Login Name", server);
        }
        
        bool EnterLoginPasswordText(Server server)
        {
        	return InvokeControls(server.LoginPasswordXPath, server.LoginPassword, "Login Password", server);	
        }
        
        bool EnterHostText(Server server)
        {
        	return InvokeControls(server.HostXPath, server.HostName, "Host", server);
        }
        
        bool EnterPortText(Server server)
        {
        	return InvokeControls(server.PortXPath, server.PortNumber, "Port", server);   	
        }
        
        bool EnterDatabaseText(Server server)
        {
        	return InvokeControls(server.DBXPath, server.DatabaseName, "Database Name", server);
        }
        
        public bool ClickOnTestConnectionButton(Server server, bool isSave = false)
        {
        	try 
        	{	
        		System.Threading.Thread.Sleep(200);
	        	Precondition.Click(repo.Datastudio.TestConnection);
	        	ReportLog("Click On Test Connection", ADSReportLevel.Success, null, server.ServerName);
	        	try 
	        	{
	        		if(repo.ConnectionSuccess.SelfInfo.Exists()){SuccessMessage(server, isSave);} 
	        		else if(repo.ConnectionFailure.SelfInfo.Exists()){FailureMessage(server);}
	        		else{ShowMainWindow();}
	        	} 
	        	catch 
	        	{	
        			ReportLog("Click On Test Connection failed", ADSReportLevel.Fail, repo.Datastudio.TestConnection, server.ServerName);
        			return false;
	        	}
	        	
	        	return true;
        	} 
        	catch
        	{
        		ReportLog("Click On Test Connection failed", ADSReportLevel.Fail, repo.Datastudio.TestConnection, server.ServerName);
        		return false;
        	}
        }
        
        void CloseSidebar()
        {
        	try
        	{
        		if(repo.Application.SidebarMenuInfo.Exists(duration))
        		{
        			repo.Application.Self.Activate();
        			Keyboard.PrepareFocus(repo.Application.SidebarMenu);
        			Keyboard.Press(System.Windows.Forms.Keys.F1, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
        		}
        	}
        	catch
        	{
        		
        	}
        }
        
        void CloseRegistrationWindow()
        {
        	try
        	{
        		Precondition.Close(repo.RegisterServer.Self);
        	}
        	catch
        	{
        		
        	}
        }

        void ClickOnSaveButton()
        {
        	try 
        	{
	        	Precondition.Click(repo.RegisterServer.SaveButton.Element);
        	} 
        	catch{}
        }
        
        void ClickOnCancelButton()
        {
        	try 
        	{
        		repo.RegisterServer.CancelButton.EnsureVisible();
        		if(repo.RegisterServer.CancelButtonInfo.Exists(new Duration(6000)))
	        		Precondition.Click(repo.RegisterServer.CancelButton);
        	} 
        	catch{}
        }
        
        void SuccessMessage(Server server, bool isSave)
        {
        	try
        	{
        		if(repo.ConnectionSuccess.CloseInfo.Exists(new Duration(6000)))
        			Precondition.Click(repo.ConnectionSuccess.Close);
				
				if(isSave)
				{
					ClickOnSaveButton();
				}
				else
				{
					ClickOnCancelButton();
				}
					
	        	ReportLog("Test Connection Success", ADSReportLevel.Success, null, server.ServerName);
        	}
        	catch
        	{ 
        		FailureMessage(server);
        	}
        }
        
        void FailureMessage(Server server)
        {
        	try 
        	{
	        	ReportLog("Test Connection Failed", ADSReportLevel.Fail, null, server.ServerName);        			
	        	if(repo.ConnectionFailure.SelfInfo.Exists(new Duration(6000)))
					Precondition.Click(repo.ConnectionFailure.Close);
	        	ClickOnCancelButton();
        	} 
        	catch
        	{
        		ReportLog("Test Connection Failed", ADSReportLevel.Fail, null, server.ServerName);        			
	        	if(repo.ConnectionFailure.SelfInfo.Exists(new Duration(6000)))
	        	{
					Precondition.Click(repo.ConnectionFailure.Close);
	        	}
	        	ClickOnCancelButton();
        	}
        }
        
        public void ShowMainWindow()
        {
        	if(repo.ConnectionSuccess.SelfInfo.Exists(duration5k))
        	{
        		Precondition.Close(repo.ConnectionSuccess.Self);
        	}        	
        	else if(repo.ConnectionFailure.SelfInfo.Exists(duration5k))
        	{
        		Precondition.Close(repo.ConnectionFailure.Self);
        	}
        	
        	if(repo.RegisterServer.SelfInfo.Exists(duration5k))
        	{
        		CloseRegistrationWindow();
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
    
	public static class RegistrationConstants
    {
    	public static string Click = "click";
    	public static string Clicked = "clicked";
    	public static string Found = "found"; 
		public static string NotFound = "not found";
		public static string Exists = "exists";
		public static string QuestionMark = "?";
		public static string Failed = "failed";
		
    	public static string ServerMenu = "server menu";
    }
}
