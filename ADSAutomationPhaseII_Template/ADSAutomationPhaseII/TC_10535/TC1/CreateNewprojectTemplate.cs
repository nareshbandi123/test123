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
using ADSAutomationPhaseII.Preconditions;
using ADSAutomationPhaseII.TC_10535;


namespace ADSAutomationPhaseII.TC_10535.TC1
{
    [TestModule("531D89B1-515A-4CC6-BD2F-3383EE006211", ModuleType.UserCode, 1)]
    public class CreateNewprojectTemplate : BaseClass, ITestModule
    {
        public CreateNewprojectTemplate()
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
        		Steps.CloseServerTab();
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
        		Steps.CloseProjectTab();
        		Steps.OpenServerTab();
        	} 
        	catch (Exception)
        	{
        		
        	}
        	return true;
        }
        
        
        
    }
}
