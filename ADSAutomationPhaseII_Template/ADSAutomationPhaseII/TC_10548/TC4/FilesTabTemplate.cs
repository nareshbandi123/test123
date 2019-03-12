
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

namespace ADSAutomationPhaseII.TC_10548.TC4
{
    
    [TestModule("2C58DC65-1681-456B-91A7-7ED47F452401", ModuleType.UserCode, 1)]
    public class FilesTabTemplate : BaseClass, ITestModule
    {
       
        public FilesTabTemplate()
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
        		Steps.ClickonFilesTab();
        		Steps.RightClickonFileSystemTab();
        		Steps.SelectNewFolder();
        		Steps.EnterFolderName();
        		Steps.ClickOkButton();
        		Steps.RightClickonFileSystemTab();
        		Steps.SelectShowDesktop();
        		Steps.RightClickonFileSystemTab();
        		Steps.SelectMountDirectory();
        		Steps.ProvidethePath();
        		Steps.ClickonSelectButton();
        		Steps.ExpandDDLDirectory();        		
        		Steps.DoubleClickonSQLfile();
        		Steps.SelectServer();
        		Steps.CLickonOpeninQueryAnalyzer();
        		Steps.DoubleClickonSQLfile();
        		Steps.SelectServer();
        		Steps.CLickonOpeninTextEditorr();
        		Steps.RemoveTabs();
        		Steps.CollapsetheFileSystemDirectory();
        		Steps.ExpandtheFileSystemDirectory();
        		Steps.UmmountDirectory();
        		Steps.ConfirmUnmountWindow();
        		Steps.DeleteAdsTable();
        		Steps.ConfirmDeleteTable();
        		Steps.HideDesktop();
        		Steps.ClickonServers();
        		        		        		
        	} 
        	catch (Exception)
        	{
        	}
        	return true;
        }
    }
}
