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
using IderaADSAutomation.Configuration;
using System.Configuration;
using ADSAutomation.TestRail;
	
namespace IderaADSAutomation.Preconditions
{
    public static class Precondition 
    {
    	public static int ApplicationOpenWaitTime = 180000;
    	public static IderaADSAutomationRepository repo = IderaADSAutomationRepository.Instance;
    	
		public const int iCreate = 0;
		public const int iInsert = 1;
		public const int iSelect = 2;
		public const int iValidate = 3;
		public const int iDropTable = 4;
		public const int iCreateDB = 5;
		public const int iDropDB = 6;
		public const int iCreateSecond = 7;
		public const int iInsertSecond = 8;
		public const int iCreateConstarins = 9;
		public const int iCreateView = 10;
		public const int iCreateIndex = 11;
		public const int iCreateTrigger = 12;
		public const int iDropView = 13;
		public const int iDropIndex = 14;
		public const int iDropTrigger = 15;
		public const int iCreateDB1 = 16;
		public const int iDropDB1 = 17;
//		public const int iSelectSecond = 18;
//		public const int iDropSecondTable = 19;		
		
    	public static string QueryTestDataPath = System.Configuration.ConfigurationManager.AppSettings["Queries"].ToString();
    	
    	public static void ExecuteScript(IderaADSAutomationRepository repo, Server server, int index)
        {
    		try
    		{
    			System.Threading.Thread.Sleep(200);
    			Click(repo.QueryAnalyzerConfiguraion.AmazonRedshiftDB.OpenScript);
    			
    			try{repo.QueryAnalyzerOpenScript.FolderToOpenInfo.WaitForExists(new Duration(5000));}
    			catch{Click(repo.QueryAnalyzerConfiguraion.AmazonRedshiftDB.OpenScript);}
    			
	        	repo.QueryAnalyzerOpenScript.FolderToOpen.TextValue = server.TestScriptLocation;
    			Click(repo.QueryAnalyzerOpenScript.OpenButton);
	    		
	    		var items = repo.QueryAnalyzerOpenScript.FileList.Items;
	    		if(items.Count == 0 )
	    		{ 
	    			//Ranorex.Form open = @"/form[@title='Open']"; 
	    			//open.Close(); 
	    			return;
	    		}
	    		items[index].EnsureVisible();
				items[index].Focus();
				items[index].Select();
				Click(repo.QueryAnalyzerOpenScript.OpenButton, false);
				ExecuteQuery(repo, server);
				System.Threading.Thread.Sleep(200);
    		}
    		catch
    		{
    			RightClick(SelectedServerTreeItem);
    			QueryAnalyser(repo);
    			
    		}
        }
    	
    	public static void CreateDatabase1(IderaADSAutomationRepository repo, Server server)
        {
        	ExecuteScript(repo, server, iCreateDB1);
        }
    	
        public static void CreateDatabase(IderaADSAutomationRepository repo, Server server)
        {
        	ExecuteScript(repo, server, iCreateDB);
        }
        
        public static void CreateTable(IderaADSAutomationRepository repo, Server server)
        {
        	ExecuteScript(repo, server, iCreate);
        }
        
        public static void InsertTable(IderaADSAutomationRepository repo, Server server)
        {
        	ExecuteScript(repo, server, iInsert);
        }
        
        public static void SelectTable(IderaADSAutomationRepository repo, Server server)
        {
        	System.Threading.Thread.Sleep(200);
        	ExecuteScript(repo, server, iSelect);
        	System.Threading.Thread.Sleep(200);
        }
        
        public static void ValidateTable(IderaADSAutomationRepository repo, Server server)
        {
        	ExecuteScript(repo, server, iValidate);
        	System.Threading.Thread.Sleep(1000);
        }
        
        public static void DropTable(IderaADSAutomationRepository repo, Server server)
        {
        	ExecuteScript(repo, server, iDropTable);
        }
        
        public static void DropScondTable(IderaADSAutomationRepository repo, Server server)
        {
        	ExecuteScript(repo, server, iDropTable);
        }
        
        public static void DropDatabase(IderaADSAutomationRepository repo, Server server)
        {
        	ExecuteScript(repo, server, iDropDB);
        }
        
        public static void DropDatabase1(IderaADSAutomationRepository repo, Server server)
        {
        	ExecuteScript(repo, server, iDropDB1);
        }
        
        public static void CreateSecondTable(IderaADSAutomationRepository repo, Server server)
        {
        	ExecuteScript(repo, server, iCreateSecond);
        }
        
        public static void InsertScondTable(IderaADSAutomationRepository repo, Server server)
        {
        	ExecuteScript(repo, server, iInsertSecond);
        }
        
        public static void SelectSecondTable(IderaADSAutomationRepository repo, Server server)
        {
        	ExecuteScript(repo, server, iSelect);
        }
        
        public static void CreateTableWithConstrains(IderaADSAutomationRepository repo, Server server)
        {
        	ExecuteScript(repo, server, iCreateConstarins);
        }
        
        public static void DropView(IderaADSAutomationRepository repo, Server server)
        {
        	ExecuteScript(repo, server, iDropView);
        }
        
        public static void CreateView(IderaADSAutomationRepository repo, Server server)
        {
        	ExecuteScript(repo, server, iCreateView);
        }
        
        public static void DropIndex(IderaADSAutomationRepository repo, Server server)
        {
        	ExecuteScript(repo, server, iDropIndex);
        }
        
        public static void CreateIndex(IderaADSAutomationRepository repo, Server server)
        {
        	ExecuteScript(repo, server, iCreateIndex);
        }
        
         public static void DropTrigger(IderaADSAutomationRepository repo, Server server)
        {
        	ExecuteScript(repo, server, iDropTrigger);
        }
        
        public static void CreateTrigger(IderaADSAutomationRepository repo, Server server)
        {
        	ExecuteScript(repo, server, iCreateTrigger);
        }
        
        public static void ExecuteQuery(IderaADSAutomationRepository repo, Server server)
        {
        	try 
        	{
        		string[] restrictservers = new string[] {"Oracle 172.24.1.140 v11g R2", "Oracle 172.24.1.199 v12.1.0.2.0"};
        		System.Threading.Thread.Sleep(200);
        		Keyboard.Press(Keyboard.ToKey("Ctrl+E"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
        		if(!restrictservers.Contains(server.RegistredServerName))
        		{
	        		//repo.ProjectMenuF3.QueryTickInfo.WaitForExists(new Duration(180000));
	        		//repo.ProjectMenuF3.QueryTick.EnsureVisible();
        		}
        		System.Threading.Thread.Sleep(200);
        	} 
        	catch (Exception e) 
        	{
        		CloseTab();
        		throw e;
        	}
        }
        
        public static void Execute(IderaADSAutomationRepository repo, Server server)
        {
        	try 
        	{
        		Keyboard.Press(Keyboard.ToKey("Ctrl+E"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
        		/*Click(repo.QueryAnalyzerConfiguraion.RunButton);
        		repo.ProjectMenuF3.QueryTickInfo.WaitForExists(new Duration(180000));
        		repo.ProjectMenuF3.QueryTick.EnsureVisible();*/
        		System.Threading.Thread.Sleep(200);
        	} 
        	catch (Exception e) 
        	{
        		CloseTab();
        		throw e;
        	}
        }
        
        public static void CloseTab()
		{
        	try 
        	{
        		Keyboard.Press(Keyboard.ToKey("Ctrl+F4"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
        		
        		if(repo.FileModified.SelfInfo.Exists(new Duration(500)))
					Precondition.Click(repo.FileModified.DiscardButton);
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
        		Keyboard.Press(Keys.Escape, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
        	} 
        	catch (Exception e)
        	{
        		throw e;
        	}
			
		}
        
        public static void RightClick(Element element)
        {
        	try
        	{
        		element.EnsureVisible();
	        	Mouse.Click(element,System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
	        	System.Threading.Thread.Sleep(200);
        	}
        	catch(Exception e)
        	{
        		throw e;
        	}
        }
        
        public static void ConnectServer(IderaADSAutomationRepository repo)
        {
        	try
        	{
        		Keyboard.Press(Keyboard.ToKey("Ctrl+Insert"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
        		System.Threading.Thread.Sleep(8000);
        		/*repo.ContextMenu.ConnectInfo.WaitForExists(new Duration(3000));
        		Click(repo.ContextMenu.Connect);
        		System.Threading.Thread.Sleep(8000);
        		
        		if(repo.QueryBuilder.SelfInfo.Exists(new Duration(1000)))
    			{
    				repo.QueryBuilder.Self.Close();
    				Click(repo.SaveChanges.DiscardButton);
    				RightClick(SelectedServerTreeItem);
    				ConnectServer(repo);
    			}*/
        	}
        	catch
        	{
     			Escape();
        		RightClick(SelectedServerTreeItem);
        		ConnectServer(repo);
        	}
        }
        
     	public static void ReConnectServer(IderaADSAutomationRepository repo)
        {
     		Keyboard.Press(Keyboard.ToKey("Ctrl+Insert"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
     		Keyboard.Press(Keyboard.ToKey("F5"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
    		System.Threading.Thread.Sleep(3500);
     		/*try
     		{
     			repo.ContextMenu.ReconnectInfo.WaitForExists(new Duration(3000));
     			Click(repo.ContextMenu.Reconnect);
     			
     			if(repo.QueryBuilder.SelfInfo.Exists(new Duration(1000)))
    			{
    				repo.QueryBuilder.Self.Close();
    				Click(repo.SaveChanges.DiscardButton);
    				RightClick(SelectedServerTreeItem);
    				ReConnectServer(repo);
    			}
     		}
     		catch
     		{
     			Escape();
     			RightClick(SelectedServerTreeItem);
     			ReConnectServer(repo);
     		}*/
        }
     	
     	public static void DisconnectServer(IderaADSAutomationRepository repo)
        {
     		try
     		{
     			Keyboard.Press(Keyboard.ToKey("Ctrl+Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
     			System.Threading.Thread.Sleep(120);
     			/*repo.ContextMenu.DisconnectInfo.WaitForExists(new Duration(3000));
     			Click(repo.ContextMenu.Disconnect);
     			
     			if(repo.QueryBuilder.SelfInfo.Exists(new Duration(1000)))
    			{
    				repo.QueryBuilder.Self.Close();
    				Click(repo.SaveChanges.DiscardButton);
    				RightClick(SelectedServerTreeItem);
    				DisconnectServer(repo);
    			}*/
        	}
     		catch
     		{
     			Escape();
     			RightClick(SelectedServerTreeItem);
     			DisconnectServer(repo);
     		}
        }
        
     	public static void QueryAnalyser(IderaADSAutomationRepository repo, bool isMongo = false)
        {
     		try
     		{
     			//repo.ContextMenu.QueryAnalyzerInfo.WaitForExists(new Duration(3000));
     			Keyboard.Press(Keyboard.ToKey("Ctrl+Q"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
     			System.Threading.Thread.Sleep(120);
    			//Click(repo.ContextMenu.QueryAnalyzer);
    			
    			if(repo.QueryBuilder.SelfInfo.Exists(new Duration(1000)))
    			{
    				repo.QueryBuilder.Self.Close();
    				Click(repo.SaveChanges.DiscardButton);
    				RightClick(SelectedServerTreeItem);
    				QueryAnalyser(repo);
    			}
    		}
     		catch
     		{
     			Escape();
     			RightClick(SelectedServerTreeItem);
     			QueryAnalyser(repo);
     		}
        }
     	
        public static void SelectDBFromComboBox(IderaADSAutomationRepository repo, Server server, string dbName)
        {
        	if(server.DatabaseKey == "Schema")
			{
    			try
    			{
    				repo.QueryAnalyzerConfiguraion.ExportData.SchemaComboTextInfo.WaitForExists(new Duration(1000));
                    repo.QueryAnalyzerConfiguraion.ExportData.SchemaComboText.TextValue = dbName;
    			}
    			catch
    			{
    				Escape();
    				RightClick(SelectedServerTreeItem);
     				QueryAnalyser(repo);
     				SelectDBFromComboBox(repo, server, dbName);
    			}
			}
			else
			{
				try
    			{
					repo.QueryAnalyzerConfiguraion.QueryAnalyzerDBSelectInfo.WaitForExists(new Duration(1000));
					repo.QueryAnalyzerConfiguraion.QueryAnalyzerDBSelect.TextValue = dbName ?? server.DatabaseName;
				}
				catch
				{
					Escape();
    				RightClick(SelectedServerTreeItem);
     				QueryAnalyser(repo);
					SelectDBFromComboBox(repo, server, dbName);
				}
			}
			System.Threading.Thread.Sleep(200);
        }
        
        public static void VerifyQueryAnalyzerTabOpened(IderaADSAutomationRepository repo, Server server, TreeItem item)
        {
        	try
        	{ 
        		System.Threading.Thread.Sleep(200);
        		if(server.DatabaseKey == "Schema" && repo.QueryAnalyzerConfiguraion.ExportData.SchemaComboTextInfo.Exists(new Duration(600)))
        		{
        		}
				else if(server.DatabaseKey != "Schema" && repo.QueryAnalyzerConfiguraion.QueryAnalyzerDBSelectInfo.Exists(new Duration(600)))
				{
				}
				else
				{
					Precondition.CloseTab();
					System.Threading.Thread.Sleep(200);
	        		Precondition.RightClick(item);
	        		System.Threading.Thread.Sleep(200);
					Precondition.ReConnectServer(repo);
					System.Threading.Thread.Sleep(200);
					Precondition.RightClick(item);
					System.Threading.Thread.Sleep(200);
					Precondition.QueryAnalyser(repo);
					System.Threading.Thread.Sleep(200);
				}
        	}        	
        	catch(Exception e)
        	{
        		throw e;
        	}
        }
        
        public static bool VerifyADSDBCombobox(IderaADSAutomationRepository repo, Server server, string dbName)
        {
        	try
        	{
        		System.Threading.Thread.Sleep(200);
        		string databasename = dbName;
        		if(server.DatabaseKey == "Schema" && repo.QueryAnalyzerConfiguraion.ExportData.SchemaComboText.EnsureVisible())
        		{
        			if(repo.QueryAnalyzerConfiguraion.ExportData.SchemaComboText.TextValue == dbName.ToUpper() ||
        			   repo.QueryAnalyzerConfiguraion.ExportData.SchemaComboText.TextValue == dbName.ToLower())
        			{
						return true;
        			}
        			else
        				return false;
        		}
				else
				{
					
					if(repo.QueryAnalyzerConfiguraion.QueryAnalyzerDBSelect.TextValue == dbName.ToUpper() ||
        			   repo.QueryAnalyzerConfiguraion.QueryAnalyzerDBSelect.TextValue == dbName.ToLower() ||
        			   repo.QueryAnalyzerConfiguraion.QueryAnalyzerDBSelect.TextValue.Contains(dbName))
        			{
						return true;
        			}
        			else
        				return false;
        			
						   
					//return repo.QueryAnalyzerConfiguraion.QueryAnalyzerDBSelect.TextValue.Contains(databasename);
				}
							 	
        	}
        	catch(Exception e)
        	{
        		throw e;
        	}
        }
        
        public static void SelectQueryFromMenu(IderaADSAutomationRepository repo)
        {
        	try
        	{
        		Click(repo.Datastudio.SelectTop1000Rows);
			}
        	catch(Exception e)
        	{
        		throw e;
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
        
        public static void ClickTools(IderaADSAutomationRepository repo)
        {
        	try
        	{	
        		repo.QueryAnalyzerConfiguraion.ExportData.ToolsInfo.WaitForExists(new Duration(1000));
				Precondition.Click(repo.QueryAnalyzerConfiguraion.ExportData.Tools);
        	}
        	catch
        	{
        		Escape();
        		CloseTab();
        		ClickTools(repo);
        	}
        }
        
        public static void ClickExport(IderaADSAutomationRepository repo)
        {
        	try
        	{	
        		repo.Datastudio.ExportInfo.WaitForExists(new Duration(1000));
				Precondition.Click(repo.Datastudio.Export);
        	}
        	catch
        	{
        		Escape();
        		CloseTab();
        		ClickTools(repo);
        		ClickExport(repo);
        	}
        }
        
        public static void ClickImport(IderaADSAutomationRepository repo)
        {
        	try
        	{	
        		repo.Datastudio.ImportInfo.WaitForExists(new Duration(1000)); 
				Precondition.Click(repo.Datastudio.Import);
        	}
        	catch
        	{
        		Escape();
        		CloseTab();
        		ClickTools(repo);
        		ClickImport(repo);
        	}
        }
        
        public static void ClickCompare(IderaADSAutomationRepository repo)
        {
        	try
        	{	
        		repo.CompareMenu.CompareInfo.WaitForExists(new Duration(1000));
				Click(repo.CompareMenu.Compare);
        	}
        	catch
        	{
        		Escape();
        		CloseTab();
        		ClickTools(repo);
        		ClickCompare(repo);
        	}
        }
        
        public static void ClickSchemaCompare(IderaADSAutomationRepository repo)
        {
        	try
        	{	
        		repo.SchemaCompareMenu.CompareInfo.WaitForExists(new Duration(1000));
				Click(repo.SchemaCompareMenu.Compare);
        	}
        	catch
        	{
        		Escape();
        		CloseTab();
        		ClickTools(repo);
        		ClickCompare(repo);
        		ClickSchemaCompare(repo);
        	}
        }
        
        public static void ClickExportServerList(IderaADSAutomationRepository repo)
        {
        	try
        	{	
        		repo.ChooseFromServer.DBServerListInfo.WaitForExists(new Duration(1000));
        	}
        	catch
        	{
        		Escape();
        		CloseTab();
        		ClickTools(repo);
        		ClickExport(repo);
        	}
        }
        
        public static void ClickImportServerList(IderaADSAutomationRepository repo)
        {
        	try
        	{	
        		repo.ChooseFromServer.DBServerListInfo.WaitForExists(new Duration(1000));
        	}
        	catch
        	{
        		Escape();
        		CloseTab();
        		ClickTools(repo);
        		ClickImport(repo);
        	}
        }
        
        public static void ClickQBOpen(IderaADSAutomationRepository repo)
        {
        	try
        	{	
        		repo.ContextMenu.OpenInfo.WaitForExists(new Duration(1000));
        	}
        	catch
        	{
        		Click(repo.Datastudio.QueryBuilder);
        	}
        }
        
        public static void ClickQBNew(IderaADSAutomationRepository repo)
        {
        	try
        	{	
        		repo.ContextMenu.ServerContextMenuInfo.WaitForExists(new Duration(1000));
        	}
        	catch
        	{
        		Click(repo.Application.QueryBuilder);
        	}
        }
        
        public static void ClickQBDBTree(IderaADSAutomationRepository repo)
        {
        	try
        	{	
        		repo.ChooseServer.DBTreeInfo.WaitForExists(new Duration(1000));
        	}
        	catch
        	{
        		Click(repo.Datastudio.ContainerBase.ConnectToServer);
        	}
        }
        
        public static void ClickERDGenerate(IderaADSAutomationRepository repo)
        {
        	try
        	{	
        		repo.ContextMenu.GenerateInfo.WaitForExists(new Duration(1000));
        	}
        	catch
        	{
        		Click(repo.Datastudio.ERModeler);
        	}
        }
        
        public static void ClickERDOpen(IderaADSAutomationRepository repo)
        {
        	try
        	{	
        		repo.ContextMenu.OpenInfo.WaitForExists(new Duration(1000));
        	}
        	catch
        	{
        		Click(repo.Datastudio.ERModeler);
        	}
        }
        
        public static void ClickScriptGenerator(IderaADSAutomationRepository repo)
        {
        	try
        	{	
        		repo.Datastudio.SchemaScriptGeneratorInfo.WaitForExists(new Duration(1000));
        		Click(repo.Datastudio.SchemaScriptGenerator);
        	}
        	catch
        	{
        		Escape();
        		CloseTab();
        		ClickTools(repo);
        		ClickScriptGenerator(repo);
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
        
        public static void QAComboBox(IderaADSAutomationRepository repo ,Server server)
        {
        	try 
        	{
        		Click(repo.QueryAnalyzerConfiguraion.QADropdownArrowbutton);
        		System.Threading.Thread.Sleep(200);
				foreach (var item in repo.ContextMenu.ExportDBComboList.Items) 
				{
					if(String.Equals(item.Text, server.DatabaseName , StringComparison.Ordinal))
					{
						if(item.EnsureVisible())
						{
							item.DoubleClick();
							break;
						}
					}
					
				}
				System.Threading.Thread.Sleep(200);
        	} 
        	catch (Exception e)
        	{
        		throw e;
        	}
			
        }
        
        public static void ExportComboBox(IderaADSAutomationRepository repo, Server server)
        {
        	try 
        	{
				Click(repo.QueryAnalyzerConfiguraion.ExportData.ExportDBComboIcon);
				foreach (var item in repo.ContextMenu.ExportDBComboList.Items) 
				{
					if(String.Equals(item.Text, server.DatabaseName , StringComparison.Ordinal))
					{
						if(item.EnsureVisible())
						{
							item.DoubleClick();
							break;
						}
					}
				}
			} 
        	catch (Exception e)
        	{
        		throw e;
        	}
        }
        
        public static bool ScanTableName(IderaADSAutomationRepository repo)
        {
        	try 
        	{
        		bool result = false; 
	        	foreach (var row in repo.QueryAnalyzerConfiguraion.ExportData.ScanDBTableName.Rows) {
	        		if(row.Cells[1].Text == "true")
	        			Click(row.Cells[1]);
	        	}	
	        	
	        	foreach (var row in repo.QueryAnalyzerConfiguraion.ExportData.ScanDBTableName.Rows) {
	        		if(row.Cells[3].Text.ToLower() == "ads_table" && row.Cells[1].Text == "false")
	        		{
	        			result = true;
	        			Click(row.Cells[1]);
	        			break;
	        		}
	        	}

				return result;        		
        	} 
        	catch (Exception e)
        	{
        		throw e;
        	}
        }
        
        public static void DeleteFiles(string filename)
        {
        	try 
        	{
	        	string fullpath = @"C:\Users\Admin\Desktop\" + filename;
	        	if(System.IO.File.Exists(fullpath))
	        		System.IO.File.Delete(fullpath);
        	} 
        	catch (Exception e)
        	{
        		throw e;
        	}
        }
        
        public static void DeleteFilesFromPath(string path)
        {
        	try 
        	{
	        	string[] filenames = System.IO.Directory.GetFiles(path);
	        	foreach (var file in filenames) 
	        	{
	        		if(System.IO.File.Exists(file))
		        		System.IO.File.Delete(file);
	        	}
	        	
	        	string[] dirnames = System.IO.Directory.GetDirectories(path);
	        	foreach (var dir in dirnames) 
	        	{
	        		if(System.IO.File.Exists(dir))
		        		System.IO.File.Delete(dir);
	        	}
        	} 
        	catch (Exception e)
        	{
        		throw e;
        	}
        }
        
        public static void DeleteFolderFiles(string path)
        {
        	try 
        	{
        		System.IO.Directory.Delete(path,true);
    		} 
        	catch (Exception e)
        	{
        		throw e;
        	}
        }
        
        public static void GetItem(Ranorex.List list, int index)
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
        
        public static TreeItem GetItem(Ranorex.TreeItem treeitem, string dbkey, bool isExpand = true)
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
        
        public static Ranorex.MenuItem GetMenunItem(Ranorex.ContextMenu treeitem, string dbkey)
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

		public static TreeItem GetItem(Ranorex.Tree tree, string dbkey, bool isExpand = true)
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
		
		public static void ExportComboBox(IderaADSAutomationRepository repo, string dbname)
        {
			try 
			{
				Click(repo.ERDiagram.ComboboxIcon);
				foreach (var item in repo.ContextMenu.ExportDBComboList.Items) 
				{
					if(String.Equals(item.Text, dbname , StringComparison.Ordinal))
					{
						if(item.EnsureVisible())
						{
							item.DoubleClick();
							break;
						}
					}
				}
			} 
        	catch (Exception e)
        	{
        		throw e;
        	}
        }
        
        public static void QAComboBox(IderaADSAutomationRepository repo, string dbname)
        {
        	try
        	{
        		Click(repo.QueryAnalyzerConfiguraion.QADropdownArrowbutton);
				foreach (var item in repo.ContextMenu.ExportDBComboList.Items) 
				{
					if(String.Equals(item.Text, dbname , StringComparison.Ordinal))
					{
						if(item.EnsureVisible())
						{
							item.DoubleClick();
							break;
						}
					}
				}
			} 
        	catch (Exception e)
        	{
        		throw e;
        	}
        }
        
        public static void ScanTableName(Table table)
        {	
        	try
        	{
		    	CheckUnselected(table);
		    	foreach (var row in table.Rows) 
		    	{
		    		if((row.Cells[3].Text.ToLower() == "ads_table" || row.Cells[3].Text.ToLower() == "ADS_TABLE") && row.Cells[1].Text == "false")
		    		{
		    			Click(row.Cells[1]);
		    			break;
		    		}
		    	}	
	    	} 
        	catch (Exception e)
        	{
        		throw e;
        	}
        }
        
        public static void ScanForTables(Table table)
        {	
        	try
        	{
	        	CheckUnselected(table);
	        	foreach (var row in table.Rows) 
	        	{
	        		if((row.Cells[2].Text.ToLower() == "tables" || row.Cells[2].Text.ToLower() == "Tables") && row.Cells[1].Text == "false")
	        		{
	        			Click(row.Cells[1]);
	        			break;
	        		}	        		
	        	}
        	} 
        	catch (Exception e)
        	{
        		throw e;
        	}
        }
        
        public static void CheckUnselected(Table table)
        {
        	try
        	{
	        	foreach (var row in table.Rows) 
	        	{
	        		if(row.Cells[1].Text == "true" || row.Cells[1].Text == "True")
	        		{
	        			Click(row.Cells[1]);
	        			break;
	        		}
	        	}
        	} 
        	catch (Exception e)
        	{
        		throw e;
        	}
        }
        
        public static void UpdateStatus(int statusId,string caseId)
		{
        	Rail oRail = new Rail();
        	try 
        	{
        		oRail.UpdateCaseStatus(statusId, caseId);	
        	} 
        	catch (Exception e) 
        	{
        		throw e;
        	}
        	
		}
        
        public static void AddRun()
		{
        	Rail oRail = new Rail();
        	try 
        	{
        		oRail.AddRun();
    		} 
        	catch (Exception e) 
        	{
        		throw e;
        	}
        	oRail = null;
		}
        
		public static void GetRunId()
		{
        	Rail oRail = new Rail();
        	try 
        	{
	        	oRail.GetRunId();
    		} 
        	catch (Exception e) 
        	{
        		throw e;
        	}
        	
        	oRail = null;
		}
		
		public static List<Case> GetCases()
		{
        	Rail oRail = new Rail();
        	var iCases = oRail.GetCases();
        	if(iCases != null)
        	{
	        	List<Case> cases = new List<Case>(iCases);
	        	oRail = null;
	        	return cases;
        	}
        	return null;
		}
		
		public static string GetCase(string registeredServerName, string issueNumber)
		{
			string caseNumber = "";
			var cases = GetCases();
			if(cases != null)
			{
				foreach (var ocase in cases) 
				{
					if(ocase.Titile.Contains(registeredServerName) && ocase.Titile.Contains(issueNumber))
				   	{
					   	caseNumber = ocase.RunId.TrimStart('C');
					   	break;
				   	}
				}
			}
			
			return caseNumber;
		}
		
		public static bool isTestDataAvailable(Server server)
        {
			try
			{
				if(System.IO.Directory.Exists(QueryTestDataPath + server.RegistredServerName))
				{
					string[] TestFiles = System.IO.Directory.GetFiles(QueryTestDataPath + server.RegistredServerName);
					return TestFiles.Length == 0 ? false : true;
				}
			} 
        	catch (Exception e)
        	{
        		throw e;
        	}	
			return false;
        }
		
		public static void SetTCName(TestCaseNode tcNode)
		{
			Precondition.TestCaseName = tcNode.Name;
		}
		
		public static void QuerybuilderSaveDiscard(IderaADSAutomationRepository repo)
		{
			if(repo.QueryBuilder.SelfInfo.Exists(new Duration(18000)))
			{
				Precondition.Click(repo.QueryBuilder.QBCloseButton);
				if(repo.SaveChanges.SelfInfo.Exists(new Duration(18000)))
				{
					Precondition.Click(repo.SaveChanges.DiscardButton);
				}
			}
		}
		
		public static void QuerybuilderOverwriteSave(IderaADSAutomationRepository repo)
		{
			if(repo.OverWrite.Self.Visible)
            {
            	if(repo.OverWrite.YesButton.Visible)
            	{
            		Precondition.Click(repo.OverWrite.YesButton);
            	}
            }
		}
		
		public static bool ValidatePrecondition(IderaADSAutomationRepository repo, Server server, TreeItem treeitem)
		{
			if(treeitem.Items.Count == 1)
			{ 
				Precondition.CloseTab();
				Precondition.RightClick(treeitem);
				Precondition.DisconnectServer(repo);
				ReportLog("Connection Failed", ADSReportLevel.Fail, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
				return false;
			}
			
			if(!Precondition.isTestDataAvailable(server))
    		{
    			Precondition.CloseTab();
    			Precondition.RightClick(treeitem);
				Precondition.DisconnectServer(repo);
				ReportLog("Test Data Not Available", ADSReportLevel.Fail, null, Precondition.TestCaseName +  ":" + server.RegistredServerName);
				return false;
    		}
			
			return true;
		}
		
		public static string[] SchemaItems = new string[] { "Schema", "Keyspaces"};		
		
		public static string TestCaseName { get; set; }
		
		public static Element SelectedServerTreeItem {get; set;}
		
		public static string GetServerName(string TCName)
		{
			var tcName = TCName.Replace('_', ' ');
			
			if(tcName.Contains(ServerNameConstants.Amazon_Redshift)) return ServerNameConstants.Amazon_Redshift;
			if(tcName.Contains(ServerNameConstants.Cassandra_22)) return ServerNameConstants.Cassandra_22;	
			if(tcName.Contains(ServerNameConstants.Cassandra_37)) return ServerNameConstants.Cassandra_37;	
			if(tcName.Contains(ServerNameConstants.Apache_Derby_1014)) return ServerNameConstants.Apache_Derby_1014;
			if(tcName.Contains(ServerNameConstants.Derby_1013)) return ServerNameConstants.Derby_1013;
			
			if(tcName.Contains(ServerNameConstants.DB2_LUW_105 )) return ServerNameConstants.DB2_LUW_105 ;
			if(tcName.Contains(ServerNameConstants.DB2_LUW_111 )) return ServerNameConstants.DB2_LUW_111 ;	
			if(tcName.Contains(ServerNameConstants.Greenplum_50)) return ServerNameConstants.Greenplum_50;	
			if(tcName.Contains(ServerNameConstants.Informix_1210)) return ServerNameConstants.Informix_1210;
			
			if(tcName.Contains(ServerNameConstants.Informix_1170)) return ServerNameConstants.Informix_1170;
			if(tcName.Contains(ServerNameConstants.MongoDB_341)) return ServerNameConstants.MongoDB_341;	
			if(tcName.Contains(ServerNameConstants.MongoDB_321)) return ServerNameConstants.MongoDB_321;	
			if(tcName.Contains(ServerNameConstants.Netezza_72)) return ServerNameConstants.Netezza_72;
			
			if(tcName.Contains(ServerNameConstants.Oracle_121020)) return ServerNameConstants.Oracle_121020;
			if(tcName.Contains(ServerNameConstants.Oracle_11gR2 )) return ServerNameConstants.Oracle_11gR2 ;	
			if(tcName.Contains(ServerNameConstants.PostgreSQL_96 )) return ServerNameConstants.PostgreSQL_96 ;	
			if(tcName.Contains(ServerNameConstants.PostgreSQL_100)) return ServerNameConstants.PostgreSQL_100;
			if(tcName.Contains(ServerNameConstants.SAP_Hana_20 )) return ServerNameConstants.SAP_Hana_20 ;
			
			if(tcName.Contains(ServerNameConstants.SAP_Hana_10 )) return ServerNameConstants.SAP_Hana_10 ;
			if(tcName.Contains(ServerNameConstants.SQL_Server_2017)) return ServerNameConstants.SQL_Server_2017;	
			if(tcName.Contains(ServerNameConstants.SQL_Server_2016)) return ServerNameConstants.SQL_Server_2016;
			if(tcName.Contains(ServerNameConstants.Sybase_Any_17 )) return ServerNameConstants.Sybase_Any_17 ;
			
			if(tcName.Contains(ServerNameConstants.Sybase_Any_16 )) return ServerNameConstants.Sybase_Any_16 ;
			if(tcName.Contains(ServerNameConstants.Sybase_ASE_16 )) return ServerNameConstants.Sybase_ASE_16 ;	
			if(tcName.Contains(ServerNameConstants.Sybase_ASE_157)) return ServerNameConstants.Sybase_ASE_157;	
			if(tcName.Contains(ServerNameConstants.Sybase_IQ_160)) return ServerNameConstants.Sybase_IQ_160;
			if(tcName.Contains(ServerNameConstants.Sybase_IQ_154)) return ServerNameConstants.Sybase_IQ_154;
			
			if(tcName.Contains(ServerNameConstants.MariaDB_102)) return ServerNameConstants.MariaDB_102;
			if(tcName.Contains(ServerNameConstants.MySQL_57)) return ServerNameConstants.MySQL_57;	
			if(tcName.Contains(ServerNameConstants.MySQL_80)) return ServerNameConstants.MySQL_80;	
			if(tcName.Contains(ServerNameConstants.Excel )) return ServerNameConstants.Excel ;
			if(tcName.Contains(ServerNameConstants.Teradata_1620)) return ServerNameConstants.Teradata_1620;
			
			if(tcName.Contains(ServerNameConstants.Teradata_150)) return ServerNameConstants.Teradata_150;
			if(tcName.Contains(ServerNameConstants.Vertica_91 )) return ServerNameConstants.Vertica_91 ;	
			if(tcName.Contains(ServerNameConstants.Vertica_80 )) return ServerNameConstants.Vertica_80 ;	
			
			return null;
		}
		
		public static void ReportLog(string log, ADSReportLevel reportlevel, Element element, string category)
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
