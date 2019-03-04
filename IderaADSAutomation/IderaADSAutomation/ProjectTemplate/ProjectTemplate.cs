using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;
using IderaADSAutomation.Preconditions;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace IderaADSAutomation.ProjectTemplate
{
    [TestModule("F283D07B-9EA1-47F1-ADDD-7FA06B2C53DD", ModuleType.UserCode, 1)]
    public class ProjectTemplate : ITestModule
    {
    	IderaADSAutomationRepository repo = IderaADSAutomationRepository.Instance;
    	private string PROJECTS = System.Configuration.ConfigurationManager.AppSettings["Projects"].ToString();
    	
    	public void GetProject(ProjectOptions options, out int projectIndex)
    	{	
    		projectIndex = 0;
    		switch (options) {
    			case ProjectTemplate.ProjectOptions.Create:
    				projectIndex = (int)ProjectOptions.Create;
    				break;
    			case ProjectTemplate.ProjectOptions.Database:
    				projectIndex = (int)ProjectOptions.Database;
    				break;
    			case ProjectTemplate.ProjectOptions.File:
    				projectIndex = (int)ProjectOptions.File;
    				break;
    			case ProjectTemplate.ProjectOptions.Multi:
    				projectIndex =(int) ProjectOptions.Multi;
    				break;
    			case ProjectTemplate.ProjectOptions.Random:
    				projectIndex = (int)ProjectOptions.Random;
    				break;
    			case ProjectTemplate.ProjectOptions.Schema:
    				projectIndex = (int)ProjectOptions.Schema;
    				break;
    		}
    	}
    	
    	public void GetProject(ProjectOptions options, out string projectIndex)
    	{	
    		projectIndex = "none";
    		switch (options) {
    			case ProjectTemplate.ProjectOptions.Create:
    				projectIndex = "Create and Email Excel File";
    				break;
    			case ProjectTemplate.ProjectOptions.Database:
    				projectIndex = "Database Schema and Data Exporter";
    				break;
    			case ProjectTemplate.ProjectOptions.File:
    				projectIndex = "File Transfer and Remote Command Execution";
    				break;
    			case ProjectTemplate.ProjectOptions.Multi:
    				projectIndex = "Multi Server Script Execute";
    				break;
    			case ProjectTemplate.ProjectOptions.Random:
    				projectIndex = "Random Table And Data Generation";
    				break;
    			case ProjectTemplate.ProjectOptions.Schema:
    				projectIndex = "Schema Compare";
    				break;
    		}
    	}

		public enum ProjectOptions
    	{
    		Create = 1,
    		Database = 2,
    		File = 3,
    		Multi = 4,
    		Random = 5,
    		Schema = 6
    	}
    	
        public ProjectTemplate()
        {
            
        }

        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 0;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            var curTestCase = (TestCaseNode)TestSuite.CurrentTestContainer;
            Precondition.SetTCName(curTestCase);
			
            if(repo.Application.SelfInfo.Exists(new Duration(180000)))
            {
            	repo.Application.Self.Activate();
            	ReportLog("Project Template Test - Start", ADSReportLevel.Info, null, Precondition.TestCaseName);
	            StartProcess();
	            ReportLog("Project Template Test - End", ADSReportLevel.Info, null, Precondition.TestCaseName);
            }
        }
        
        void StartProcess()
        {
        	string ProjectIndex = "None";
        	try
        	{
        		this.GetProject(ProjectOptions.Create, out ProjectIndex);
	        	CreateNewProject(ProjectOptions.Create);
	        	
	        	ReportLog(ProjectIndex, ADSReportLevel.Success, null, Precondition.TestCaseName);
        	}
        	catch(Exception ex)
        	{
        		
        		ReportLog(ex.StackTrace.ToString(), ADSReportLevel.Fail, null, ProjectIndex + " : " + Precondition.TestCaseName);
        	}
        	
        	try
        	{
        		this.GetProject(ProjectOptions.Database, out ProjectIndex);
	        	CreateNewProject(ProjectOptions.Database);
	        	ReportLog(ProjectIndex, ADSReportLevel.Success, null, Precondition.TestCaseName);
        	}
        	catch(Exception ex)
        	{
        		ReportLog(ex.StackTrace.ToString(), ADSReportLevel.Fail, null, ProjectIndex + " : " + Precondition.TestCaseName);
        	}
	        

        	try 
        	{
        		this.GetProject(ProjectOptions.File, out ProjectIndex);
	        	CreateNewProject(ProjectOptions.File);
	        	ReportLog(ProjectIndex, ADSReportLevel.Success, null, Precondition.TestCaseName);
        	} 
        	catch (Exception ex) 
        	{
        		ReportLog(ex.StackTrace.ToString(), ADSReportLevel.Fail, null, ProjectIndex + " : " + Precondition.TestCaseName);
        	}
        		
        	try
        	{
        		this.GetProject(ProjectOptions.Multi, out ProjectIndex);
	        	CreateNewProject( ProjectOptions.Multi);
	        	ReportLog(ProjectIndex, ADSReportLevel.Success, null, Precondition.TestCaseName);
        	}
        	catch (Exception ex) 
        	{
        		ReportLog(ex.StackTrace.ToString(), ADSReportLevel.Fail, null, ProjectIndex + " : " + Precondition.TestCaseName);
        	}	
	        	
        	
        	try
        	{
        		this.GetProject(ProjectOptions.Random, out ProjectIndex);
	        	CreateNewProject(ProjectOptions.Random);
	        	ReportLog(ProjectIndex, ADSReportLevel.Success, null, Precondition.TestCaseName);
        	}
	        catch (Exception ex) 
        	{
        		ReportLog(ex.StackTrace.ToString(), ADSReportLevel.Fail, null, ProjectIndex + " : " + Precondition.TestCaseName);
        	}	
	        	
	        	
	        try
	        {
	        	this.GetProject(ProjectOptions.Schema, out ProjectIndex);
	        	CreateNewProject(ProjectOptions.Schema);
	        	ReportLog(ProjectIndex, ADSReportLevel.Success, null, Precondition.TestCaseName);
	        }
	        catch (Exception ex) 
        	{
        		ReportLog(ex.StackTrace.ToString(), ADSReportLevel.Fail, null, ProjectIndex + " : " + Precondition.TestCaseName);
        	}	
	        	
        	if(!repo.ProjectMenuF3.F1.Checked) Precondition.Click(repo.ProjectMenuF3.F1);        	
        	
        }
        
        void CreateNewProject(ProjectOptions options)
        {
        	if(!repo.ProjectMenuF3.F3.Checked) Precondition.Click(repo.ProjectMenuF3.F3);
        	
        	Precondition.RightClick(repo.ProjectMenuF3.ProjectTree);
        	Delay.Milliseconds(1000);
        	
        	Precondition.Click(repo.Datastudio.NewProject);
        	Delay.Milliseconds(1000);
        	
        	Precondition.Click(repo.NewProject.BrowseIcon);        	
        	Delay.Milliseconds(1000);
        	
        	Precondition.TextboxText(repo.SelectFolder.LocationTextbox, PROJECTS);
        	Delay.Milliseconds(1000);
        	
        	Precondition.Click(repo.SelectFolder.SelectButton);
        	Delay.Milliseconds(1000);
        	
        	Precondition.GetItem(repo.NewProject.ProjectsList, (int)options);
        	Delay.Milliseconds(1000);
        	
        	Precondition.Click(repo.NewProject.CreateButton,false);
        	Delay.Milliseconds(1000);
        	
        	try{Precondition.CloseTab();}catch{}
        	Delay.Milliseconds(1000);
        	
        	Precondition.RightClick(repo.ProjectMenuF3.ProjectTree.Items[0]);
        	Delay.Milliseconds(1000);
        	
        	Precondition.Click(repo.Datastudio.Remove);
        	Delay.Milliseconds(1000);
        	
        	Precondition.Click(repo.Remove.YesButton);
        	Delay.Milliseconds(1000);
        	
        	Precondition.DeleteFolderFiles(PROJECTS);
        	Delay.Milliseconds(1000);
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
