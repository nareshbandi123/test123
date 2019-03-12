using System;
using System.CodeDom;
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
using System.Configuration;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Commons;

namespace ADSAutomationPhaseII.Preconditions
{
	public static class Steps
	{
		public static int ApplicationOpenWaitTime = 180000;
    	
		public const int iCreate = 0;
		public const int iInsert = 1;
		public const int iSelect = 2;
		public const int iValidate = 3;
		public const int iDropTable = 4;
		public const int iCreateDB = 5;
		public const int iDropDB = 6;
		public const int iCreateSecond = 7;
		public const int iSelectTable = 8;
		public const int iCreateConstarins = 9;
		public const int iCreateView = 10;
		public const int iCreateIndex = 11;
		public const int iCreateTrigger = 12;
		public const int iDropView = 13;
		public const int iDropIndex = 14;
		public const int iDropTrigger = 15;
		public const int iCreateDB1 = 16;
		public const int iDropDB1 = 17;
		public const int iDropSecondTable = 18;		
		
    	public static string QueryTestDataPath = System.Configuration.ConfigurationManager.AppSettings["Queries"].ToString();
    	
    	public static PreconditionRepo repo = PreconditionRepo.Instance;
    	
    	public static void Sleep()
    	{
    		System.Threading.Thread.Sleep(200);
    	}
    	
    	public static void RightClick(this Ranorex.TreeItem item)
        {
        	try
        	{
        		Sleep();
	        	Mouse.Click(item,System.Windows.Forms.MouseButtons.Left, new Point(30, 10));
	        	Sleep();
        	}
        	catch(Exception e)
        	{
        		throw e;
        	}
        }
    	
    	public static void RightClick(this Ranorex.TabPage tab)
        {
        	try
        	{
        		Sleep();
	        	Mouse.Click(tab,System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
	        	Sleep();
        	}
        	catch(Exception e)
        	{
        		throw e;
        	}
        }
    	
    	public static void CloseTab(string tabName)
		{
        	try 
        	{
        		Sleep();
        		string tabpageName = string.Format("//tabpage[@title~'^root@{0}']", tabName);
        		Ranorex.TabPage tabPage = repo.QueryAnalyzer.Tab.FindSingle(tabpageName);
        		tabPage.RightClick();
        		repo.SunAwtWindow.CloseTab.ClickThis();
        		Sleep();
        	} 
        	catch (Exception e)
        	{
        		throw e;
        	}
			
		}
        
        public static void Escape()
		{
        	try 
        	{
        		Sleep();
        		Keyboard.Press(Keys.Escape, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
        		Sleep();
        	} 
        	catch (Exception e)
        	{
        		throw e;
        	}
			
		}
        
        public static void ConnectServer()
        {
        	try
        	{
        		Sleep();
        		Keyboard.Press(Keyboard.ToKey("Ctrl+Insert"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
        		Sleep();
        	}
        	catch
        	{
     			
        	}
        }
        
     	public static void ReConnectServer()
        {
     		try
     		{
     			Sleep();
        		Keyboard.Press(Keyboard.ToKey("Ctrl+Insert"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
        		Sleep();
     		}
     		catch
     		{
     			
     		}
        }
     	
     	public static void DisconnectServer()
        {
     		try
     		{
     			Sleep();
        		Keyboard.Press(Keyboard.ToKey("Ctrl+Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
        		Sleep();
        	}
     		catch
     		{
     			
     		}
        }
     	
     	public static void QueryAnalyser()
        {
     		try
     		{
     			Sleep();
        		Keyboard.Press(Keyboard.ToKey("Ctrl+Q"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
        		Sleep();
    		}
     		catch
     		{
     			
     		}
        }
     	
     	public static void ClickQAOpenFile()
        {
    		try
    		{
    			Sleep();
        		Keyboard.Press(Keyboard.ToKey("Ctrl+O"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
        		Sleep();
    		}
    		catch(Exception e)
    		{
    			throw e;
    		}
        }
     	
     	public static void ClickQARun()
        {
    		try
    		{
    			Sleep();
        		Keyboard.Press(Keyboard.ToKey("Ctrl+E"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
        		Sleep();
    		}
    		catch(Exception e)
    		{
    			throw e;
    		}
        }
     	
    	public static void ExecuteScript(int index)
        {
    		try
    		{
    			Sleep();
    			ClickQAOpenFile();    			
	        	repo.Open.FilePathTextbox.TextValue =  QueryTestDataPath + SelectedServerName;
	        	var items = repo.Open.QueryScriptList.Items;
	        	items[index].DoubleClick();
    			//Click(repo.Open.OpenButton);
				ClickQARun();
				Sleep();
    		}
    		catch(Exception e)
    		{
    			throw e;
    		}
        }
    	
    	public static void CreateDatabase1()
        {
			Sleep();
        	ExecuteScript(iCreateDB1);
        	Sleep();
        }
    	
        public static void CreateDatabase()
        {
        	Sleep();
        	ExecuteScript(iCreateDB);
        	Sleep();
        }
        
        public static void CreateTable()
        {
        	Sleep();
        	ExecuteScript(iCreate);
        	Sleep();
        }
        
        public static void InsertTable()
        {
        	Sleep();
        	ExecuteScript(iInsert);
        	Sleep();
        }
        
        public static void SelectTable()
        {
        	Sleep();
        	ExecuteScript(iSelect);
        	Sleep();
        }
        
        public static void ValidateTable()
        {
        	Sleep();
        	ExecuteScript(iValidate);
        	Sleep();
        }
        
        public static void DropTable()
        {
        	Sleep();
        	ExecuteScript(iDropTable);
        	Sleep();
        }
        
        public static void DropScondTable()
        {
        	Sleep();
        	ExecuteScript(iDropSecondTable);
        	Sleep();
        }
        
        public static void DropDatabase()
        {
        	Sleep();
        	ExecuteScript(iDropDB);
        	Sleep();
        }
        
        public static void DropDatabase1()
        {
        	Sleep();
        	ExecuteScript(iDropDB1);
        	Sleep();
        }
        
        public static void CreateSecondTable()
        {
        	Sleep();
        	ExecuteScript(iCreateSecond);
        	Sleep();
        }
        
        public static void SelectSecondTable()
        {
        	Sleep();
        	ExecuteScript(iSelectTable);
        	Sleep();
        }
        
        public static void CreateTableWithConstrains()
        {
        	Sleep();
        	ExecuteScript(iCreateConstarins);
        	Sleep();
        }
        
        public static void DropView()
        {
        	Sleep();
        	ExecuteScript(iDropView);
        	Sleep();
        }
        
        public static void CreateView()
        {
        	Sleep();
        	ExecuteScript(iCreateView);
        	Sleep();
        }
        
        public static void DropIndex()
        {
        	Sleep();
        	ExecuteScript(iDropIndex);
        	Sleep();
        }
        
        public static void CreateIndex()
        {
        	Sleep();
        	ExecuteScript(iCreateIndex);
        	Sleep();
        }
        
        public static void DropTrigger()
        {
        	Sleep();
        	ExecuteScript(iDropTrigger);
        	Sleep();
        }
        
        public static void CreateTrigger()
        {
        	Sleep();
        	ExecuteScript(iCreateTrigger);
        	Sleep();
        }
     	
        public static void SelectDBFromComboBox(string dbName)
        {
        	Sleep();
        	repo.QueryAnalyzer.QAComboTextbox.TextBoxText(dbName);
        	Sleep();
        }
        
        public static bool VerifyQueryAnalyzerTabOpened(TreeItem item)
        {
        	try
        	{ 
        		Sleep();
        		return repo.QueryAnalyzer.QAComboTextboxInfo.Exists(new Duration(1000));
        	}
        	catch
        	{
        		return false;
        	}
        }
        
        public static bool VerifyADSDBCombobox(string dbName)
        {
        	try
        	{
        		Sleep();
				return repo.QueryAnalyzer.QAComboTextbox.TextValue == dbName;
        	}
        	catch
        	{
        		return false;
        	}
        }        
        
        public static void TreeItemExpand(TreeItem treeitem)
        {
        	try
        	{
	        	treeitem.EnsureVisible();
	        	treeitem.Expand();
        	}
        	catch(Exception e)
        	{
        		throw e;
        	}
        }
        
        public static void TreeItemCollapse(TreeItem treeitem)
        {
        	try
        	{
	        	treeitem.EnsureVisible();
	        	treeitem.CollapseAll();
        	}
        	catch(Exception e)
        	{
        		throw e;
        	}
        }
        
        public static void TreeItemDoubleClickToExpand(TreeItem treeitem)
        {
        	try
        	{
	        	treeitem.EnsureVisible();
	        	treeitem.DoubleClick();
        	}
        	catch(Exception e)
        	{
        		throw e;
        	}
        }
        
        public static void Click(Element element, bool ensure = true)
        {
        	try
        	{	
	        	if (ensure) element.EnsureVisible();
	        	element.Focus();
	        	Ranorex.Mouse.MoveTo(element);
	        	Ranorex.Mouse.Click(element);
	        	System.Threading.Thread.Sleep(100);
        	}
        	catch(Exception e)
        	{
        		throw e;
        	}
        }
        
        public static void Close(Ranorex.Form form, bool ensure = true)
        {
        	try
        	{
	        	if (ensure) form.EnsureVisible();
	        	form.Close();
        	}
        	catch(Exception e)
        	{
        		throw e;
        	}
        }
        
        public static void DoubleClick(Element element, bool ensure = true)
        {
        	try
        	{
	        	if (ensure) element.EnsureVisible();
	        	Ranorex.Mouse.DoubleClick(element);
        	}
        	catch(Exception e)
        	{
        		throw e;
        	}
        }
        
        public static void TextboxText(Text text, string value)
        {
        	try
        	{
        		text.TextValue = value;
        	}
        	catch(Exception e)
        	{
        		throw e;
        	}
        }
        
        public static void InvokeTextboxText(Text text, string value)
        {
        	try
        	{
        		text.TextValue = value;
    		}
        	catch(Exception e)
        	{
        		throw e;
        	}
        }
        
        public static void QAComboBox(string dbName)
        {
        	try 
        	{
        		Sleep();
				foreach (var item in repo.QueryAnalyzerComboList.DBServerList.Items) 
				{
					if(String.Equals(item.Text, dbName, StringComparison.Ordinal))
					{
						if(item.EnsureVisible())
						{
							item.DoubleClick();
							break;
						}
					}
					
				}
				Sleep();
        	} 
        	catch (Exception e)
        	{
        		throw e;
        	}
			
        }
        
        public static void GetItem(this Ranorex.List list, int index)
        {
        	try 
        	{
	        	list.Items[index].Select();
        	} 
        	catch (Exception e)
        	{
        		throw e;
        	}
        }
        
        public static TreeItem GetItem(this Ranorex.TreeItem treeitem, string dbkey, bool isExpand = true)
        {
        	TreeItem item = null;
        	try 
        	{
	        	foreach (var itemtree in treeitem.Items)
	        	{
	        		if(itemtree.Text.Trim() == dbkey)
	    			{
	        			if(isExpand)
	        			{
	        				itemtree.EnsureVisible();
		        			itemtree.Expand();
	        			}
						item = itemtree;
						System.Threading.Thread.Sleep(500);
	    				break;
	    			}
	        	}
        	} 
        	catch (Exception e)
        	{
        		throw e;
        	}
        	return item;
        }
        
        public static Ranorex.MenuItem GetMenunItem(this Ranorex.ContextMenu treeitem, string dbkey)
        {
        	Ranorex.MenuItem item = null;
        	try 
        	{
	        	foreach (var itemtree in treeitem.Items)
	        	{
	        		if(itemtree.Text.Trim() == dbkey)
	    			{
						item = itemtree;
						System.Threading.Thread.Sleep(500);
	    				break;
	    			}
	        	}
        	} 
        	catch (Exception e)
        	{
        		throw e;
        	}
        	return item;
        }

		public static TreeItem GetItem(this Ranorex.Tree tree, string dbkey, bool isExpand = true)
        {
        	TreeItem item = null;
        	try 
        	{
	        	foreach (var itemtree in tree.Items) 
	        	{
	        		if(itemtree.Text.Trim() == dbkey)
	    			{
	        			itemtree.Collapse();
	        			if(isExpand)
	        			{
		        			itemtree.Expand();
		        			itemtree.EnsureVisible();
	        			}
						item = itemtree;
						System.Threading.Thread.Sleep(500);
	    				break;
	    			}
	        	}
        	} 
        	catch (Exception e)
        	{
        		throw e;
        	}
        	return item;
        }
		
		public static TreeItem GetServerTreeFromTCName(string TCName)
        {
			if(TCName.Contains(ServerListConstants.Amazon_Redshift))
				return repo.ServersList.AmazonRedshift;
			if(TCName.Contains(ServerListConstants.Cassandra_37))
				return repo.ServersList.Cassandra37;
			if(TCName.Contains(ServerListConstants.Cassandra_22))
				return repo.ServersList.Cassandra22;
			if(TCName.Contains(ServerListConstants.Apache_Derby_1014))
				return repo.ServersList.Derby1014;
			if(TCName.Contains(ServerListConstants.Derby_1013))
				return repo.ServersList.Derby1013;
			if(TCName.Contains(ServerListConstants.DB2_LUW_111))
				return repo.ServersList.DB2111;
			if(TCName.Contains(ServerListConstants.DB2_LUW_105))
				return repo.ServersList.DB2105;
			if(TCName.Contains(ServerListConstants.Greenplum_50))
				return repo.ServersList.Greenplum50;
//			if(TCName.Contains(ServerListConstants.Greenplum_4312))
//				return repo.ServersList.Greenplum4312;
			if(TCName.Contains(ServerListConstants.Informix_1170))
				return repo.ServersList.Informix1170;
			if(TCName.Contains(ServerListConstants.Informix_1210))
				return repo.ServersList.Informix1210;
			if(TCName.Contains(ServerListConstants.MariaDB_102))
				return repo.ServersList.MariaDB;
			if(TCName.Contains(ServerListConstants.MongoDB_321))
				return repo.ServersList.MongoDB321;
			if(TCName.Contains(ServerListConstants.MongoDB_341))
				return repo.ServersList.MongoDB341;
			if(TCName.Contains(ServerListConstants.MySQL_80))
				return repo.ServersList.MySQL80;
			if(TCName.Contains(ServerListConstants.MySQL_57))
				return repo.ServersList.MySQL57;
			if(TCName.Contains(ServerListConstants.Netezza_72))
				return repo.ServersList.Netezza72;
			if(TCName.Contains(ServerListConstants.Oracle_121020))
				return repo.ServersList.Oracle20;
			if(TCName.Contains(ServerListConstants.Oracle_11gR2))
				return repo.ServersList.OracleR2;
			if(TCName.Contains(ServerListConstants.PostgreSQL_100))
				return repo.ServersList.PostgreSQL100;
			if(TCName.Contains(ServerListConstants.PostgreSQL_96))
				return repo.ServersList.PostgreSQL96;
			if(TCName.Contains(ServerListConstants.SAP_Hana_20))
				return repo.ServersList.SAPHana20;
			if(TCName.Contains(ServerListConstants.Microsoft_SQL_Azure_RTM_12020008))
				return repo.ServersList.MicrosoftSQLAzure08;
			if(TCName.Contains(ServerListConstants.SQL_Server_2017))
				return repo.ServersList.SQLServer2017;
			if(TCName.Contains(ServerListConstants.SQL_Server_2016))
				return repo.ServersList.SQLServer2016;
			if(TCName.Contains(ServerListConstants.Sybase_Any_16))
				return repo.ServersList.SybaseAny16;
			if(TCName.Contains(ServerListConstants.Sybase_Any_17))
				return repo.ServersList.SybaseAny17;
			if(TCName.Contains(ServerListConstants.Sybase_ASE_16))
				return repo.ServersList.SybaseASE16;
			if(TCName.Contains(ServerListConstants.Sybase_ASE_157))
				return repo.ServersList.SybaseASE157;
			if(TCName.Contains(ServerListConstants.Sybase_IQ_154))
				return repo.ServersList.SybaseIQ154;
			if(TCName.Contains(ServerListConstants.Sybase_IQ_160))
				return repo.ServersList.SybaseIQ160;
//			if(TCName.Contains(ServerListConstants.Teradata_150))
//				return repo.ServersList.Teradata151;
			if(TCName.Contains(ServerListConstants.Teradata_1620))
				return repo.ServersList.Teradata1620;
			if(TCName.Contains(ServerListConstants.Vertica_80))
				return repo.ServersList.Vertica80;
			if(TCName.Contains(ServerListConstants.Vertica_91))
				return repo.ServersList.Vertica91;
			
			return null;
        }
		
		public static Element SelectedServerTreeItem {get; set;}
		public static string SelectedServerName {get; set;}
	}
}
