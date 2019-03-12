using System;
using System.Drawing;
using System.Text;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Commons;

namespace ADSAutomationPhaseII.TC_10535
{
	public static class Steps
	{
		public static TC10535Repo repo = TC10535Repo.Instance;
		public static string TC1_10535_Path = System.Configuration.ConfigurationManager.AppSettings["TC1_10535_Path"].ToString();
		
		#region "10535_TC1- Steps"
		
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
				
				if(repo.Application.TemplateTreeInfo.Exists(1000))
					RemoveProject();
				
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
				//repo.NewProject.FolderPathTextbox.TextBoxText(TC1_10535_Path);
				repo.NewProject.BrowseButton.ClickThis();
				repo.SelectFolder.FolderPathTextbox.TextBoxText(TC1_10535_Path);
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
				Reports.ReportLog("New Database Schema template created successfully", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
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
				repo.Application.TemplateTreeInfo.WaitForExists(Commons.Common.ApplicationOpenWaitTime);
				repo.Application.TemplateTree.Expand();
				Reports.ReportLog("Schema tree is expanded", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
				Ranorex.Validate.Exists(repo.Application.AquaScriptsInfo, "Validate AquaScripts Available");				
				Reports.ReportLog("Schema tree is contains AquaScripts", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
				Ranorex.Validate.Exists(repo.Application.ServersInfo, "Validate Servers Available");				
				Reports.ReportLog("Schema tree is contains Servers", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
				Ranorex.Validate.Exists(repo.Application.UserFilesInfo, "Validate UserFiles Available");				
				Reports.ReportLog("Schema tree is contains UserFiles", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
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
				repo.Application.AquaScriptsInfo.WaitForExists(Commons.Common.ApplicationOpenWaitTime);
				repo.Application.AquaScripts.Expand();
				Ranorex.Validate.Exists(repo.Application.NewProjectFileInfo, "Validate NewProjectFile Available");
				Reports.ReportLog("AquaScripts' is expanded and contains 'Database Schema and Data Exporter.xjs' file", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception)
			{
				
			}
			return true;
		}
		
		public static bool RemoveProject()
		{
			try 
			{
				repo.Application.TemplateTreeInfo.WaitForExists(Commons.Common.ApplicationOpenWaitTime);
				Ranorex.Mouse.Click(repo.Application.TemplateTree, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
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
		
		public static bool OpenServerTab()
		{
			try 
			{
				if(!repo.Application.F1Menu.Checked)
					repo.Application.F1Menu.ClickThis();
			} 
			catch (Exception)
			{
				
			}
			return true;
		}
		
		public static bool CloseProjectTab()
		{
			try 
			{
				if(repo.Application.F3Menu.Checked)
					repo.Application.F3Menu.ClickThis();
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
        		//Ranorex.Keyboard.Press(Ranorex.Keyboard.ToKey("Ctrl+F4"), Ranorex.Keyboard.DefaultScanCode, Ranorex.Keyboard.DefaultKeyPressTime, 1, true);
        		repo.Application.TabInfo.WaitForExists(Commons.Common.ApplicationOpenWaitTime);
				Ranorex.Mouse.Click(repo.Application.Tab, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
				repo.DataStudio.TabCloseMenu.ClickThis();
        	} 
        	catch (Exception e)
        	{
        		throw e;
        	}
			return true;
		}
		
		#endregion
		
		public enum DatabaseTypes
		{
			Amazon,
			ApacheCassandra,
			ApacheDerby,
			DB2LUW,
			Greenplum,
			Informix,
			MariaDB,
			MongoDB,
			MSSQLServer,
			MySQL,
			Netezza,
			Oracle,
			PostgreSQL,
			SybaseAnywhere,
			SybaseASE,
			SybaseIQ,
			TeradataDatabase,
			Vertica,
			SAPHana,
			MSSQLAzure
		}
		
		public static bool ClickOnERModelerMenu()
		{
			try
			{
				repo.Application.Self.Activate();
				repo.Application.Self.EnsureVisible();
				repo.Application.ERModelerMenu.ClickThis();
			}
			catch(Exception)
			{
				
			}
			return true;
		}
		
		public static bool SelectNew()
		{
			try
			{
				
				if(repo.SunAwtWindow.NewInfo.Exists(new Ranorex.Duration(1000)))
				{
					repo.SunAwtWindow.New.ClickThis();
					
				}
				else
				{
					ClickOnERModelerMenu();
					SelectNew();
				}
				Reports.ReportLog("New Entity Relationship Diagram window opened", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception)
			{
				
			}
			return true;
		}
		
		public static bool SelectOpen()
		{
			try
			{
				
				if(repo.SunAwtWindow.OpenInfo.Exists(new Ranorex.Duration(1000)))
					repo.SunAwtWindow.Open.ClickThis();
				else
				{
					ClickOnERModelerMenu();
					SelectOpen();
				}
			}
			catch(Exception)
			{
				
			}
			return true;
		}
		
		public static bool SelectDataTypeAndVersion(DatabaseTypes dbTypes, string version = "")
		{
			try
			{
				if(repo.NewERDDatatype.SelfInfo.Exists(new Ranorex.Duration(600)))
				{				
					switch (dbTypes) 
		        	{
						case DatabaseTypes.Amazon:
							repo.NewERDDatatype.Amazon.ClickThis();				
							repo.NewERDDatatype.AmazonVersion.V1.ClickThis();
							break;
						case DatabaseTypes.ApacheCassandra:
							repo.NewERDDatatype.ApacheCassandra.ClickThis();
							if(version == "37")
								repo.NewERDDatatype.Cassandra.V37.ClickThis();
							else
								repo.NewERDDatatype.Cassandra.V22.ClickThis();
							break;
						case DatabaseTypes.ApacheDerby:
							repo.NewERDDatatype.ApacheDerby.ClickThis();
							if(version == "1014")
								repo.NewERDDatatype.Derby.V1014.ClickThis();
							else
								repo.NewERDDatatype.Derby.V1013.ClickThis();
							break;
						case DatabaseTypes.DB2LUW:
							repo.NewERDDatatype.DB2LUW.ClickThis();
							if(version == "111")
								repo.NewERDDatatype.DB2.V111.ClickThis();
							else
								repo.NewERDDatatype.DB2.V105.ClickThis();
							break;
						case DatabaseTypes.Greenplum :
							repo.NewERDDatatype.Greenplum.ClickThis();
							if(version == "5")
								repo.NewERDDatatype.GreenplumDB.V5.ClickThis();
							else
								repo.NewERDDatatype.GreenplumDB.V4312.ClickThis();
							break;
						case DatabaseTypes.Informix:
							repo.NewERDDatatype.Informix.ClickThis();
							if(version == "117")
								repo.NewERDDatatype.InformixDB.V117.ClickThis();
							else
								repo.NewERDDatatype.InformixDB.V121.ClickThis();
							break;
						case DatabaseTypes.MariaDB:
							repo.NewERDDatatype.MariaDB.ClickThis();
							repo.NewERDDatatype.Maria10XDB.V102.ClickThis();
							break;
						case DatabaseTypes.MongoDB:
							repo.NewERDDatatype.MongoDB.ClickThis();
							if(version == "341")
								repo.NewERDDatatype.MongoXDB.V341.ClickThis();
							else
								repo.NewERDDatatype.MongoXDB.V321.ClickThis();
							break;
						case DatabaseTypes.MSSQLAzure:
							repo.NewERDDatatype.MSSQLAzure.ClickThis();
							repo.NewERDDatatype.MSAzureDB.V12.ClickThis();
							break;						
						case DatabaseTypes.MSSQLServer:
							repo.NewERDDatatype.MSSQLServer.ClickThis();
							if(version == "2017")
								repo.NewERDDatatype.MSSQLDB.V2017.ClickThis();
							else
								repo.NewERDDatatype.MSSQLDB.V2016.ClickThis();
							break;
						case DatabaseTypes.MySQL:
							repo.NewERDDatatype.MySQL.ClickThis();
							if(version == "8")
								repo.NewERDDatatype.MySQLDB.V8.ClickThis();
							else
								repo.NewERDDatatype.MySQLDB.V57.ClickThis();
							break;
						case DatabaseTypes.Netezza:
							repo.NewERDDatatype.Netezza.ClickThis();
							repo.NewERDDatatype.Netteza.V72.ClickThis();
							break;
						case DatabaseTypes.Oracle:
							repo.NewERDDatatype.Oracle.ClickThis();
							if(version == "12")
								repo.NewERDDatatype.OracleDB.V12.ClickThis();
							else
								repo.NewERDDatatype.OracleDB.V11.ClickThis();
							break;
						case DatabaseTypes.PostgreSQL:
							repo.NewERDDatatype.PostgreSQL.ClickThis();
							if(version == "10")
								repo.NewERDDatatype.PostgreSQLDB.V10.ClickThis();
							else
								repo.NewERDDatatype.PostgreSQLDB.V96.ClickThis();
							break;
						case DatabaseTypes.SAPHana:
							repo.NewERDDatatype.SAPHana.ClickThis();
							repo.NewERDDatatype.SAPHanaDB.V2.ClickThis();
							break;
						case DatabaseTypes.SybaseAnywhere:
							repo.NewERDDatatype.SybaseAnywhere.ClickThis();
							if(version == "17")
								repo.NewERDDatatype.SybaseAny.V17.ClickThis();
							else
								repo.NewERDDatatype.SybaseAny.V16.ClickThis();
							break;
						case DatabaseTypes.SybaseASE:
							repo.NewERDDatatype.SybaseASE.ClickThis();
							if(version == "16")
								repo.NewERDDatatype.SybaseASEDB.V16.ClickThis();
							else
								repo.NewERDDatatype.SybaseASEDB.V157.ClickThis();
							break;
						case DatabaseTypes.SybaseIQ:
							repo.NewERDDatatype.SybaseIQ.ClickThis();
							if(version == "16")
								repo.NewERDDatatype.SybaseIQDB.V16.ClickThis();
							else
								repo.NewERDDatatype.SybaseIQDB.V154.ClickThis();
							break;
						case DatabaseTypes.TeradataDatabase:
							repo.NewERDDatatype.TeradataDatabase.ClickThis();
							if(version == "1620")
								repo.NewERDDatatype.Teradata.V1620.ClickThis();
							else
								repo.NewERDDatatype.Teradata.V1510.ClickThis();
							break;
						case DatabaseTypes.Vertica:
							repo.NewERDDatatype.Vertica.ClickThis();
							if(version == "8")
								repo.NewERDDatatype.VerticaDB.V8.ClickThis();
							else
								repo.NewERDDatatype.VerticaDB.V91.ClickThis();						
							break;
						default:        			
	        			break;
					}
				}
				else
				{
					ClickOnERModelerMenu();
					repo.SunAwtWindow.New.ClickThis();
					SelectDataTypeAndVersion(dbTypes, version);
				}
				Reports.ReportLog("Database Type & Version Selected", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				repo.NewERDDatatype.OkButton.ClickThis();
				repo.EntityRelationshipDiagram.Self.Activate();
			}
			catch(Exception)
			{
				
			}
			
			return true;
		}
		
		public static bool ValidateTree(bool Collections, bool Tables, bool views, bool Relationship, bool Notes)
		{
			try
			{
				if(repo.EntityRelationshipDiagram.SelfInfo.Exists(new Ranorex.Duration(1000)))
				{
					if(Tables) Ranorex.Validate.Exists(repo.EntityRelationshipDiagram.TablesInfo, "Validate Tables exists in tree");
					if(views) Ranorex.Validate.Exists(repo.EntityRelationshipDiagram.ViewsInfo, "Validate Tables views in tree");
					if(Relationship) Ranorex.Validate.Exists(repo.EntityRelationshipDiagram.RelationshipsInfo, "Validate Tables Relationship in tree");
					if(Notes) Ranorex.Validate.Exists(repo.EntityRelationshipDiagram.NotesInfo, "Validate Tables notes in tree");
				}
				else
				{
					if(repo.NewERDDatatype.OkButtonInfo.Exists(new Ranorex.Duration(1000)))
					{
						repo.NewERDDatatype.OkButton.ClickThis();
						ValidateTree(Collections, Tables,views, Relationship, Notes);
					}
				}
			}
			catch(Exception)
			{
				
			}
			return true;
		}
		
		public static bool RightClickOnTables()
		{
			try 
			{	
				repo.EntityRelationshipDiagram.SelfInfo.WaitForExists(Common.ApplicationOpenWaitTime);
				Ranorex.Mouse.Click(repo.EntityRelationshipDiagram.Tables, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
			} 
			catch (Exception) 
			{
				RightClickOnTables();
			}
			return true;
		}
		
		public static bool RightClickOnCollections()
		{
			try 
			{	
				repo.EntityRelationshipDiagram.SelfInfo.WaitForExists(Common.ApplicationOpenWaitTime);
				if(repo.EntityRelationshipDiagram.Collections.EnsureVisible())
					Ranorex.Mouse.Click(repo.EntityRelationshipDiagram.Collections, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
			} 
			catch (Exception) 
			{
				RightClickOnCollections();
			}
			return true;
		}
		
		public static bool CreateNewTable()
		{
			try 
			{	
				repo.SunAwtWindow.NewTable.ClickThis();
			} 
			catch (Exception) 
			{
			}
			return true;
		}
		
		public static bool CreateNewCollection()
		{
			try 
			{	
				repo.SunAwtWindow.NewCollection.ClickThis();
			} 
			catch (Exception) 
			{
			}
			return true;
		}
		
		public static bool RightClickOnTable1()
		{
			try 
			{	
				repo.EntityRelationshipDiagram.Table1.ClickThis();
				Ranorex.Mouse.Click(repo.EntityRelationshipDiagram.Table1, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
				Reports.ReportLog("Parent Table created", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception) 
			{
			}
			return true;
		}
		
		public static bool RightClickOnTable2()
		{
			try 
			{	
				repo.EntityRelationshipDiagram.Table2.ClickThis();
				Ranorex.Mouse.Click(repo.EntityRelationshipDiagram.Table2, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
				Reports.ReportLog("Child Table created", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception) 
			{
			}
			return true;
		}
		
		public static bool RightClickOnCollection1()
		{
			try 
			{	
				repo.EntityRelationshipDiagram.Collection1.ClickThis();
				Ranorex.Mouse.Click(repo.EntityRelationshipDiagram.Collection1, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
				Reports.ReportLog("Parent Collection created", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception) 
			{
			}
			return true;
		}
		
		public static bool RightClickOnCollection2()
		{
			try 
			{	
				repo.EntityRelationshipDiagram.Collection2.ClickThis();
				Ranorex.Mouse.Click(repo.EntityRelationshipDiagram.Collection2, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
				Reports.ReportLog("Child Collection created", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception) 
			{
			}
			return true;
		}
		
		public static bool SelectProperties()
		{
			try
			{
				repo.SunAwtWindow.PropertiesInfo.WaitForExists(new Ranorex.Duration(1000));
				repo.SunAwtWindow.Properties.ClickThis();
			}
			catch(Exception)
			{
				
			}
			return true;
		}
		
		public static bool EnterParentTableName()
		{
			try
			{
				if(repo.TableProperties.TableNameTextboxInfo.Exists(new Ranorex.Duration(1000)))
				{
					repo.TableProperties.TableNameTextbox.TextBoxText("ads_ParentTable");
				}
				else
				{
					RightClickOnTable1();
					SelectProperties();
					EnterParentTableName();
				}
			}
			catch(Exception)
			{
				
			}
			return true;
		}
		
		public static bool EnterParentCollectionName()
		{
			try
			{
				if(repo.CollectionProperties.CollectionNameTextBoxInfo.Exists(new Ranorex.Duration(1000)))
				{
					repo.CollectionProperties.CollectionNameTextBox.TextBoxText("ads_ParentTable");
				}
				else
				{
					RightClickOnCollection1();
					SelectProperties();
					EnterParentCollectionName();
				}
			}
			catch(Exception)
			{
				
			}
			return true;
		}
		
		public static bool EnterChildTableName()
		{
			try
			{
				if(repo.TableProperties.TableNameTextboxInfo.Exists(new Ranorex.Duration(1000)))
				{
					repo.TableProperties.TableNameTextbox.TextBoxText("ads_ChildTable");
				}
				else
				{
					RightClickOnTable2();
					SelectProperties();
					EnterChildTableName();
				}
			}
			catch(Exception)
			{
				
			}
			return true;
		}
		
		public static bool EnterChildCollectionName()
		{
			try
			{
				if(repo.CollectionProperties.CollectionNameTextBoxInfo.Exists(new Ranorex.Duration(1000)))
				{
					repo.CollectionProperties.CollectionNameTextBox.TextBoxText("ads_ChildTable");
				}
				else
				{
					RightClickOnCollection2();
					SelectProperties();
					EnterChildCollectionName();
				}
			}
			catch(Exception)
			{
				
			}
			return true;
		}
		
		public static bool CreateColumns()
		{
			try
			{
				repo.TableProperties.Row1Column1.DoubleClick();
				System.Threading.Thread.Sleep(200);
				repo.TableProperties.Row1Column1.PressKeys("ID");
				Ranorex.Keyboard.Press(Ranorex.Keyboard.ToKey("Enter"), Ranorex.Keyboard.DefaultScanCode, Ranorex.Keyboard.DefaultKeyPressTime, 1, true);
				
				repo.TableProperties.Row1Column2.DoubleClick();
				System.Threading.Thread.Sleep(200);
				repo.TableProperties.Row1Column2.PressKeys("int");
				
				repo.TableProperties.Row1Column4.DoubleClick();
				System.Threading.Thread.Sleep(200);
				if(repo.TableProperties.Row1Column4.Text == "true")
					repo.TableProperties.Row1Column4.Click();
				
				
				repo.TableProperties.Row2Column1.DoubleClick();
				System.Threading.Thread.Sleep(200);
				repo.TableProperties.Row2Column1.PressKeys("Name");
				Ranorex.Keyboard.Press(Ranorex.Keyboard.ToKey("Enter"), Ranorex.Keyboard.DefaultScanCode, Ranorex.Keyboard.DefaultKeyPressTime, 1, true);
				
				repo.TableProperties.Row2Column3.DoubleClick();
				System.Threading.Thread.Sleep(200);
				repo.TableProperties.Row2Column3.PressKeys("50");
				
				
				repo.TableProperties.Row3Column1.DoubleClick();
				System.Threading.Thread.Sleep(200);
				repo.TableProperties.Row3Column1.PressKeys("DOB");
				Ranorex.Keyboard.Press(Ranorex.Keyboard.ToKey("Enter"), Ranorex.Keyboard.DefaultScanCode, Ranorex.Keyboard.DefaultKeyPressTime, 1, true);
				
				repo.TableProperties.Row3Column2.DoubleClick();
				System.Threading.Thread.Sleep(200);
				repo.TableProperties.Row3Column2.PressKeys("Date");
				
				
				repo.TableProperties.Row4Column1.DoubleClick();
				System.Threading.Thread.Sleep(200);
				repo.TableProperties.Row4Column1.PressKeys("Active");
				
				repo.TableProperties.Row4Column2.DoubleClick();
				System.Threading.Thread.Sleep(200);
				repo.TableProperties.Row4Column2.PressKeys("bool");
				
				repo.TableProperties.OKButton.ClickThis();
				
				Reports.ReportLog("Columns added to the Table and Saved", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception)
			{
				
			}
			return true;
		}
		
		public static bool CreateCollectionColumns()
		{
			try
			{
				repo.CollectionProperties.Row1Column1.DoubleClick();
				repo.CollectionProperties.Row1Column1.PressKeys("ID");
				Ranorex.Keyboard.Press(Ranorex.Keyboard.ToKey("Enter"), Ranorex.Keyboard.DefaultScanCode, Ranorex.Keyboard.DefaultKeyPressTime, 1, true);
				
				repo.CollectionProperties.Row1Column2.DoubleClick();
				repo.CollectionProperties.Row1Column2.PressKeys("int");
				
				repo.CollectionProperties.Row1Column4.DoubleClick();
				if(repo.CollectionProperties.Row1Column4.Text == "true")
					repo.CollectionProperties.Row1Column4.Click();
				
				
				repo.CollectionProperties.Row2Column1.DoubleClick();
				repo.CollectionProperties.Row2Column1.PressKeys("Name");
				Ranorex.Keyboard.Press(Ranorex.Keyboard.ToKey("Enter"), Ranorex.Keyboard.DefaultScanCode, Ranorex.Keyboard.DefaultKeyPressTime, 1, true);
				
				repo.CollectionProperties.Row2Column3.DoubleClick();
				repo.CollectionProperties.Row2Column3.PressKeys("50");
				
				
				repo.CollectionProperties.Row3Column1.DoubleClick();
				repo.CollectionProperties.Row3Column1.PressKeys("DOB");
				Ranorex.Keyboard.Press(Ranorex.Keyboard.ToKey("Enter"), Ranorex.Keyboard.DefaultScanCode, Ranorex.Keyboard.DefaultKeyPressTime, 1, true);
				
				repo.CollectionProperties.Row3Column2.DoubleClick();
				repo.CollectionProperties.Row3Column2.PressKeys("Date");
				
				
				repo.CollectionProperties.Row4Column1.DoubleClick();
				repo.CollectionProperties.Row4Column1.PressKeys("Active");
				
				repo.CollectionProperties.Row4Column2.DoubleClick();
				repo.CollectionProperties.Row4Column2.PressKeys("bool");
				
				repo.CollectionProperties.OKButton.ClickThis();
				
				Reports.ReportLog("Columns added to the Table and Saved", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception)
			{
				
			}
			return true;
		}
		
		public static bool EditColumns()
		{
			try
			{
				Ranorex.TreeItem ads_ParentTable = repo.EntityRelationshipDiagram.Tables.FindSingle("//treeitem[@text='ads_ParentTable']");
				ads_ParentTable.EnsureVisible();
				
				Ranorex.Mouse.Click(ads_ParentTable, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
				SelectProperties();
				
				if(repo.TableProperties.SelfInfo.Exists(new Ranorex.Duration(1000)))
				{
					repo.TableProperties.Row1Column1.DoubleClick();
					repo.TableProperties.Row1Column1.PressKeys("EMPID");
					
					repo.TableProperties.OKButton.ClickThis();
				}
				else
				{
					EditColumns();
				}
				
				Reports.ReportLog("Columns Edited and Saved", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception)
			{
				
			}
			return true;
		}
		
		public static bool EditCollectionColumns()
		{
			try
			{
				Ranorex.TreeItem ads_ParentTable = repo.EntityRelationshipDiagram.Collections.FindSingle("//treeitem[@text='ads_ParentTable']");
				ads_ParentTable.EnsureVisible();
				
				Ranorex.Mouse.Click(ads_ParentTable, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
				SelectProperties();
				
				if(repo.CollectionProperties.SelfInfo.Exists(new Ranorex.Duration(1000)))
				{
					repo.CollectionProperties.Row1Column1.DoubleClick();
					repo.CollectionProperties.Row1Column1.PressKeys("EMPID");
					
					repo.CollectionProperties.OKButton.ClickThis();
				}
				else
				{
					EditCollectionColumns();
				}
				
				Reports.ReportLog("Columns Edited and Saved", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception)
			{
				
			}
			return true;
		}
		
		public static bool CreateNewRelationship()
		{
			try 
			{
				Ranorex.TreeItem ads_ParentTable = repo.EntityRelationshipDiagram.Tables.FindSingle("//treeitem[@text='ads_ParentTable']");
				Ranorex.Mouse.Click(ads_ParentTable, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
				repo.SunAwtWindow.NewRelationshipInfo.WaitForExists(new Ranorex.Duration(1000));
				repo.SunAwtWindow.NewRelationship.ClickThis();
			} 
			catch (Exception) 
			{
				
			}
			return true;
		}
		
		public static bool CreateNewCollectionRelationship()
		{
			try 
			{
				Ranorex.TreeItem ads_ParentTable = repo.EntityRelationshipDiagram.Collections.FindSingle("//treeitem[@text='ads_ParentTable']");
				Ranorex.Mouse.Click(ads_ParentTable, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
				repo.SunAwtWindow.NewRelationshipInfo.WaitForExists(new Ranorex.Duration(1000));
				repo.SunAwtWindow.NewRelationship.ClickThis();
			} 
			catch (Exception) 
			{
				
			}
			return true;
		}
		
		public static bool EnterRelationshipName()
		{
			try
			{
				repo.RelationshipProperties.RelationshipNameTextboxInfo.WaitForExists(new Ranorex.Duration(1000));
				repo.RelationshipProperties.RelationshipNameTextbox.TextBoxText("ads_Relation");
			}
			catch(Exception)
			{
				CreateNewRelationship();
			}
			return true;
		}
		
		public static bool SelectParentTableComboBox()
		{
			try 
			{
				repo.RelationshipProperties.ParentTableComboboxInfo.WaitForExists(new Ranorex.Duration(1000));
				repo.RelationshipProperties.ParentTableCombobox.Text = "ads_ParentTable";	
			} 
			catch (Exception) 
			{
				CreateNewRelationship();
				EnterRelationshipName();
				SelectParentTableComboBox();
			}
			return true;
		}
		
		public static bool SelectChildTableComboBox()
		{
			try 
			{
				repo.RelationshipProperties.ChildTableComboboxInfo.WaitForExists(new Ranorex.Duration(1000));
				repo.RelationshipProperties.ChildTableCombobox.Text = "ads_ChildTable";	
			} 
			catch (Exception) 
			{
				CreateNewRelationship();
				EnterRelationshipName();
				SelectParentTableComboBox();
				SelectChildTableComboBox();
			}
			return true;
		}
		
		public static bool CheckParentTableCheckbox()
		{
			try 
			{
				repo.RelationshipProperties.ParentTableIDColumnInfo.WaitForExists(new Ranorex.Duration(1000));
				repo.RelationshipProperties.ParentTableIDColumn.Rows[0].Cells[0].Click();
			} 
			catch (Exception) 
			{
				CreateNewRelationship();
				EnterRelationshipName();
				SelectParentTableComboBox();
				SelectChildTableComboBox();
				CheckParentTableCheckbox();
			}
			return true;
		}
		
		public static bool CheckChildTableCheckbox()
		{
			try 
			{
				repo.RelationshipProperties.ChildTableIDColumnInfo.WaitForExists(new Ranorex.Duration(1000));
				repo.RelationshipProperties.ChildTableIDColumn.Rows[0].Cells[0].Click();
			} 
			catch (Exception) 
			{
				CreateNewRelationship();
				EnterRelationshipName();
				SelectParentTableComboBox();
				SelectChildTableComboBox();
				CheckParentTableCheckbox();
				CheckChildTableCheckbox();
			}
			return true;
		}
		
		public static bool ClickRelationshipOkButton()
		{
			try 
			{
				repo.RelationshipProperties.OkButtonInfo.WaitForExists(new Ranorex.Duration(1000));
				repo.RelationshipProperties.OkButton.ClickThis();
			} 
			catch (Exception) 
			{
				CreateNewRelationship();
				EnterRelationshipName();
				SelectParentTableComboBox();
				SelectChildTableComboBox();
				CheckParentTableCheckbox();
				CheckChildTableCheckbox();
				ClickRelationshipOkButton();
			}
			return true;
		}
		
		public static bool SaveERD()
		{
			try 
			{
				repo.EntityRelationshipDiagram.SaveButtonInfo.WaitForExists(Common.ApplicationOpenWaitTime);
				repo.EntityRelationshipDiagram.SaveButton.ClickThis();
				string fileName = string.Format("{0}/{1}", TC1_10535_Path, "TC2_ERD");
				Common.DeleteFile(fileName+".xed");	
				repo.SaveWindow.SaveFilePathInfo.WaitForExists(Common.ApplicationOpenWaitTime);
				repo.SaveWindow.SaveFilePath.TextBoxText(fileName);
				repo.SaveWindow.SaveButton.ClickThis();
				CloseERD();
				Reports.ReportLog("New Entity Relationship created and Saved", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception) 
			{
				
			}
			return true;
		}
		
		public static bool CloseERD()
		{
			try 
			{
				repo.EntityRelationshipDiagram.SelfInfo.WaitForExists(new Ranorex.Duration(1000));
				repo.EntityRelationshipDiagram.Self.Close();
				repo.EntityRelationshipDiagram.SelfInfo.WaitForNotExists(new Ranorex.Duration(1000));	
			} 
			catch (Exception) 
			{
			}
			return true;
		}
		
		public static bool OpenERD()
		{
			try 
			{
				string fileName = string.Format("{0}/{1}", TC1_10535_Path, "TC2_ERD.xed");
				repo.OpenWindow.FilePathTextboxInfo.WaitForExists(1000);
				repo.OpenWindow.FilePathTextbox.TextBoxText(fileName);
				repo.OpenWindow.OpenButton.ClickThis();
				try 
				{
					repo.OpenWindow.OpenButtonInfo.WaitForNotExists(new Ranorex.Duration(1000));	
				} 
				catch 
				{
					repo.OpenWindow.OpenButton.ClickThis();
				}
				CloseERD();
				Reports.ReportLog("Validate the Saved ERD", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception) 
			{
				
			}
			return true;
		}
	}
}
