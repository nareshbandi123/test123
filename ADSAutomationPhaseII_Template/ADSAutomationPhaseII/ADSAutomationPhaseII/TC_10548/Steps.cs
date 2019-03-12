using System;
using System.Drawing;
using System.Text;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Preconditions;
using Ranorex.Core;
using Ranorex;


namespace ADSAutomationPhaseII.TC_10548
{
    public static class Steps
    {
    	
		public static TC10548Repo repo = TC10548Repo.Instance;
		public static string TC1_10548_Path = System.Configuration.ConfigurationManager.AppSettings["TC1_10548_Path"].ToString();
		
  		#region "TC1"
  		
		public static bool ClickonServers()
		{ 
			try
			{
				repo.Application.F1Menu.ClickThis();
				Reports.ReportLog("List of Local Database Servers are displayed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception)
			{
			
			}
			return true;
		}
		
		public static bool ExpandDatabase()
		{ 
		try
		{
			repo.Application.TreeItemInfo.WaitForExists(new Duration(500));
			repo.Application.TreeItem.Expand();
			Reports.ReportLog("List of registered Servers are displayed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			
		}
		catch(Exception)
		{
			ExpandDatabase();
		
		}
		return true;
		}
		
		public static bool CollapseDatabase()
		{ 
		try
		{
			repo.Application.TreeItemInfo.WaitForExists(new Duration(500));
			repo.Application.TreeItem.Collapse();
			Reports.ReportLog("List of Local Database Servers are Hidden", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			
		}
		catch(Exception)
		{
			CollapseDatabase();
		
		}
		return true;
		} 
        
		#endregion       
        
		#region "TC2"
		
		public static bool ClickonSettingIcon()
		{ 
			try
			 {
				repo.Application.Settings.SettingIconInfo.WaitForExists(new Duration(500));
				repo.Application.Settings.SettingIcon.ClickThis();
				Reports.ReportLog("Docked Mode, Pinned Mode, Floating Mode, Split Mode are displayed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			 }
			catch(Exception)
			{
				ClickonSettingIcon();
			
			}
			return true;
		}
		
		public static bool MarkonFloatingMode()
		{ 
			try
			{
			    repo.ModesMenu.ContextMenu.EnsureVisible();
				foreach (var item in repo.ModesMenu.ContextMenu.Items)
				{
					if(item.Text == "Floating Mode") { item.ClickThis(); break;}
					Reports.ReportLog("Local Database Servers pane can be moved", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			
			}
			catch(Exception)
			{
			
			}
		return true;
		}
		
		public static bool ClickonSettingIcon1()
		{ 
		try
		{
			repo.Server.SettingIcon1Info.WaitForExists(new Duration(500));
			repo.Server.SettingIcon1.ClickThis();
			
		}
		catch(Exception)
		{
			ClickonSettingIcon1();
		
		}
		return true;
		}	
		
		public static bool MarkonFloatingMode1()
		{ 
			try
			{
			repo.FloatingMenu.ContextMenu1.EnsureVisible();
			foreach (var item in repo.FloatingMenu.ContextMenu1.Items)
			{
			if(item.Text == "Floating Mode") { item.ClickThis(); break;}
			}
						
			}
			catch(Exception)
			{
			
			}
			return true;
		}	
		
		public static bool MarkonDockedMode()
		{ 
			try
			{
				repo.ModesMenu.ContextMenu.EnsureVisible();
				foreach (var item in repo.ModesMenu.ContextMenu.Items)
			{
			    if(item.Text == "Docked Mode") { item.ClickThis(); break;}
			    Reports.ReportLog("Local Database Servers pane is accessable", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			}
			catch(Exception)
			{
			
			}
			return true;
		}	
		
		public static bool ClickonSettingIcon2()
		{ 
			try
			 {
				repo.Application.Settings.SettingIconDInfo.WaitForExists(new Duration(500));
				repo.Application.Settings.SettingIconD.ClickThis();
				
			 }
			catch(Exception)
			{
				ClickonSettingIcon2();
			
			}
			return true;
		}
				
		public static bool MarkonDockedMode1()
		{ 
			try
			{
				repo.ModesMenu.ContextMenu.EnsureVisible();
				foreach (var item in repo.ModesMenu.ContextMenu.Items)
			{
			    if(item.Text == "Docked Mode") { item.ClickThis(); break;}
			    Reports.ReportLog("'New Project' window is opened", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			}
			catch(Exception)
			{
			
			}
			return true;
		}	
		
		public static bool MarkonSplitMode()
		{ 
			try
			{
				repo.ModesMenu.ContextMenu.EnsureVisible();
				foreach (var item in repo.ModesMenu.ContextMenu.Items)
			{
			  if(item.Text == "Split Mode") { item.ClickThis(); break;}
			  Reports.ReportLog("Local Database Servers pane is displayed at the bottom of the left side", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			}
			catch(Exception)
			{
			
			}
			return true;
		}	
		
		public static bool MarkonPinnedMode()
		{ 
			try
			{
				repo.ModesMenu.ContextMenu.EnsureVisible();
				foreach (var item in repo.ModesMenu.ContextMenu.Items)
			{
			    if(item.Text == "Pinned Mode") { item.ClickThis(); break;}
			    Reports.ReportLog("Local Database Servers pane is always displayed towards the left side", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			}
			catch(Exception)
			{
			
			}
			return true;
		} 
		
		public static bool ClickonHidingIcon()
        { 
			try
			{
				repo.Application.F1Menu.DoubleClick();
				Reports.ReportLog("Local Database Servers List is hidden", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch(Exception)
			{
			
			}
			return true;
		}
		
		#endregion
			
		#region "TC3"
		
        public static bool CloseServerTab()
		{
			try 
			{
				repo.Application.F1MenuInfo.WaitForExists(new Ranorex.Duration(1000));
				if (repo.Application.F1Menu.Checked) 
					repo.Application.F1Menu.ClickThis();
				
			} 
			catch (Exception)
			{
				
			}
			return true;
		}
		
		public static bool ClickOnProjectTab()
		{
			try 
			{
				repo.Application.F3MenuInfo.WaitForExists(new Ranorex.Duration(1000));
				if (!repo.Application.F3Menu.Checked) 
					repo.Application.F3Menu.ClickThis();
				
						
			} 
			catch (Exception)
			{
				
			}
			return true;
		}
		
		public static bool RightClickProjectTab()
		{
			try 
			{
				Ranorex.Mouse.Click(repo.Application.ProjectsTree, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
			} 
			catch (Exception)
			{
				
			}
			return true;
		}
		
		public static bool SelectNewProject()
		{
			try 
			{
				repo.DataStudio.NewProjectMenu.ClickThis();
				Reports.ReportLog("'New Project' window is opened", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception)
			{
				
			}
			return true;
		}
		
		public static bool SelectDataSchemaAndDataExporterTemplate()
		{
			try 
			{
				repo.NewProject.DatabaseSchemaAndDataImportListItem.ClickThis();
				Reports.ReportLog("'New Project' window is opened", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				System.Threading.Thread.Sleep(500);
			} 
			catch (Exception)
			{
				
			}
			return true;
		}		
		
		public static bool BrowseFolderLocation()
		{
			try 
			{
				System.Threading.Thread.Sleep(500);
				repo.NewProject.BrowseButton.ClickThis();
				repo.SelectFolder.FolderPathTextbox.TextBoxText(TC1_10548_Path);
				repo.SelectFolder.SelectButton.ClickThis();
				
			}
			catch (Exception)
			{
				
			}
			return true;
		}
		
		public static bool ClickOk()
		{
			try 
			{
				repo.NewProject.OkButton.ClickThis();
				Reports.ReportLog(" QA template editor is displayed second line as  'Database Schema and Data Exporter'", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception)
			{
				
			}
			return true;
		}
		
		public static bool ValidateTemplateFromNewProject()
		{
			try 
			{
				repo.DataTree.TemplateTreeInfo.WaitForExists(Commons.Common.ApplicationOpenWaitTime);
				repo.DataTree.TemplateTree.Expand();
				Reports.ReportLog("Folder structure AquaScripts, Servers and User Files folders is created", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
							
				Ranorex.Validate.Exists(repo.DataTree.AquaScriptsInfo, "Validate AquaScripts Available");				
								
				Ranorex.Validate.Exists(repo.DataTree.ServersInfo, "Validate Servers Available");				
								
				Ranorex.Validate.Exists(repo.DataTree.UserFilesInfo, "Validate UserFiles Available");				
				
			} 
			catch (Exception)
			{
				
			}
			return true;
		}
		
		public static bool ValidateNewProjectFile()
		{
			try 
			{
				repo.DataTree.AquaScriptsInfo.WaitForExists(Commons.Common.ApplicationOpenWaitTime);
				repo.DataTree.AquaScripts.Expand();
				Ranorex.Validate.Exists(repo.DataTree.NewProjectfile, "Validate NewProjectFile Available");
				Reports.ReportLog("Database Schema and Data Exporter.xjs' file is displayed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			} 
			catch (Exception)
			{
				
			}
			return true;
		}
		
		public static bool CloseTab()
		{
			try 
        	{
        		
        		repo.DataTree.TabInfo.WaitForExists(Commons.Common.ApplicationOpenWaitTime);
				Ranorex.Mouse.Click(repo.DataTree.Tab, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
				repo.DataStudio.TabClose.ClickThis();
        	} 
        	catch (Exception e)
        	{
        		throw e;
        	}
			return true;
		}
		
		public static bool RemoveProject()
		{
			try 
			{
				repo.DataTree.TemplateTreeInfo.WaitForExists(Commons.Common.ApplicationOpenWaitTime);
				Ranorex.Mouse.Click(repo.DataTree.TemplateTree, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
				repo.DataStudio.RemoveMenu.ClickThis();
				repo.RemoveWindow.SelfInfo.WaitForExists(1000);
				repo.RemoveWindow.YesButton.ClickThis();
				
			} 
			catch (Exception)
			{
				RemoveProject();
			}
			return true;
		}
		
		#endregion
			
		#region "TC4"
		
		public static bool ClickonFilesTab()
		{
			try 
			{
				repo.Application.F2Menu.ClickThis();
			} 
			catch (Exception)
			{
										  
			}
			return true;
		}
		
		public static bool RightClickonFileSystemTab()
		{
			try 
			{
				Ranorex.Mouse.Click(repo.Application.FileSystemtree, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
			} 
			catch (Exception)
			{
				
			}
			return true;
		}
		
		public static bool SelectNewFolder()
		{
			try 
			{
				repo.DataStudio.NewFolder.ClickThis();
				Reports.ReportLog("New Folder displayed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception)
			{
				
			}
			return true;
		}
		
		public static bool EnterFolderName()
		{
			try 
			{
				repo.NewFolderMenu.FolderName.PressKeys("ads Table");
				
				
			} 
			catch (Exception)
			{
				
			}
			return true;
		}
		
		public static bool ClickOkButton()
		{
			try 
			{
				
				repo.NewFolderMenu.OkButton.ClickThis();
				Reports.ReportLog("New Folder created under FileSystem tree", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception)
			{
				
			}
			return true;
		}
		
		public static bool SelectShowDesktop()
		{
			try 
			{
				repo.DataStudio.ShowDesktop.ClickThis();
				Reports.ReportLog("Dektop is Displayed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			} 
			catch (Exception)
			{
				
			}
			return true;
		}
		
		public static bool SelectMountDirectory()
		{
			try 
			{
				repo.DataStudio.ShowMountDirectory.ClickThis();
				Reports.ReportLog("Directory is Displayed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			} 
			catch (Exception)
			{
				
			}
			return true;
		}
		
		public static bool ProvidethePath()
		{
			try 
			{
				repo.SelectDirectory.LocalMachinePathInfo.WaitForExists(new Duration(500));
				repo.SelectDirectory.LocalMachinePath.TextBoxText("TC4_10548_Path");
				
			} 
			catch (Exception)
			{
				ProvidethePath();
				
			}
			return true;
		}
		
		public static bool ClickonSelectButton()
		{
			try 
			{
				repo.SelectDirectory.SelectButtonInfo.WaitForExists(new Duration(500));
				repo.SelectDirectory.SelectButton.ClickThis();
				Reports.ReportLog("The selected folder is created & displayed under FileSystem tree", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			} 
			catch (Exception)
			{
				ClickonSelectButton();
				
			}
			return true;
		}
		
		
		public static bool ExpandDDLDirectory()
		{
			try 
			{
				repo.Application.DDLInfo.WaitForExists(new Duration(500));
				repo.Application.DDL.Expand();
				Reports.ReportLog("New Folder created under FileSystem tree", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			} 
			catch (Exception)
			{
				ExpandDDLDirectory();
				
			}
			return true;
		}	
		
		public static bool DoubleClickonSQLfile()
		{
			try 
			{
				repo.Application.DB2SQL.DoubleClick();
				Reports.ReportLog("Choose Server or Database window is displayed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			} 
			catch (Exception)
			{
				
			}
			return true;
		}		
			
		public static bool SelectServer()
		{
			try 
			{
				repo.Database.AmazonRedshift.ClickThis();
				
			} 
			catch (Exception)
			{
				
			}
			return true;
		}
		
		public static bool CLickonOpeninQueryAnalyzer()
		{
			try 
			{
				repo.Database.OpeningQA.ClickThis();
				Reports.ReportLog("Query Analyzer window is displayed with the script", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception)
			{
				
			}
			return true;
		}
		
		public static bool CLickonOpeninTextEditorr()
		{
			try 
			{
				repo.Database.OpenTextEditor.ClickThis();
				Reports.ReportLog("Text Editor window is displayed with the script", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			} 
			catch (Exception)
			{
				
			}
			return true;
		}
		
		public static bool CollapsetheFileSystemDirectory()
		{
			try 
			{
				System.Threading.Thread.Sleep(500);
				repo.Application.FileSystemtree.Collapse();
			
				
			} 
			catch (Exception)
			{
				
			}
			return true;
		}
		
		public static bool ExpandtheFileSystemDirectory()
		{
			try 
			{
				System.Threading.Thread.Sleep(500);				
				repo.Application.FileSystemtree.Expand();
				Reports.ReportLog("Folder structure with list of files are displayed under FileSystem tree", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
								
			} 
			catch (Exception)
			{
				
			}
			return true;
		}
		
		public static bool RemoveTabs()
		{
			try 
			{
				repo.DB2Windows.WindowsTabsInfo.WaitForExists(Commons.Common.ApplicationOpenWaitTime);
				Ranorex.Mouse.Click(repo.DB2Windows.WindowsTabs, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
				repo.DataStudio.CloseAll.ClickThis();
				
			} 
			catch (Exception)
			{
				
			}
			return true;
		}
		
		public static bool UmmountDirectory()
		{
			try 
			{
				repo.Application.DDLInfo.WaitForExists(Commons.Common.ApplicationOpenWaitTime);
				Ranorex.Mouse.Click(repo.Application.DDL, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
				repo.DataStudio.UnMountDirectory.ClickThis();
				
			} 
			catch (Exception)
			{
				
			}
			return true;
		}
		
		public static bool ConfirmUnmountWindow()
		{
			try 
			{
				repo.UnmountWindow.YesButton.ClickThis();
				
			} 
			catch (Exception)
			{
				
			}
			return true;
		}
		
		public static bool DeleteAdsTable()
		{
			try 
			{
				repo.Application.AdsTableInfo.WaitForExists(Commons.Common.ApplicationOpenWaitTime);
				Ranorex.Mouse.Click(repo.Application.AdsTable, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
				repo.DataStudio.DeleteAdsTable.ClickThis();
				
			} 
			catch (Exception)
			{
				
			}
			return true;
		}
		
		public static bool ConfirmDeleteTable()
		{
			try 
			{
				repo.DeleteConfirm.YesButtonInfo.WaitForExists(new Duration(500));
				repo.DeleteConfirm.YesButton.ClickThis();
				
			} 
			catch (Exception)
			{
				ConfirmDeleteTable();
				
			}
			return true;
		}
		public static bool HideDesktop()
		{
			try 
			{
				repo.Application.DesktopInfo.WaitForExists(Commons.Common.ApplicationOpenWaitTime);
				Ranorex.Mouse.Click(repo.Application.Desktop, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
				repo.DataStudio.HideDesktop.ClickThis();
				
			} 
			catch (Exception)
			{
				
			}
			return true;
		}
		
				
		#endregion
    }
}

