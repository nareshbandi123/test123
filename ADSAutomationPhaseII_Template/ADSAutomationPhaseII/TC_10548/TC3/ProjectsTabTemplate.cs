
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

using ADSAutomationPhaseII.Base;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Extensions;

namespace ADSAutomationPhaseII.TC_10548
{
   
    [TestModule("9BB9787A-7F8D-4D7E-84E5-22B8A8D5FE65", ModuleType.UserCode, 1)]
    public class ProjectsTabTemplate : BaseClass, ITestModule
    {
      
        public ProjectsTabTemplate()
        {
            
        }

        void ITestModule.Run()
        {
         	StartProcess();
        }
        
        bool StartProcess()
        {
        	try 
        	{  
        		Steps.ClickOnProjectTab();
        		Steps.RightClickProjectTab();
        		Steps.SelectNewProject();        		
        		Steps.SelectDataSchemaAndDataExporterTemplate();
        		Steps.BrowseFolderLocation();
        		Steps.ClickOk();        		
        		Steps.ValidateTemplateFromNewProject();
        		Steps.ValidateNewProjectFile();
        		Steps.CloseTab();
        		Steps.RemoveProject();
        		Steps.ClickonServers();
        	} 
        	catch (Exception)
        	{
        	}
        	return true;
        }
    }
}
