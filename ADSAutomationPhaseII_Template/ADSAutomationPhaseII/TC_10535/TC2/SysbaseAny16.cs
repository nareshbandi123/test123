/*
 * Created by Ranorex
 * User: Admin
 * Date: 2/27/2019
 * Time: 10:15 PM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
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

namespace ADSAutomationPhaseII.TC_10535.TC2
{
    /// <summary>
    /// Description of SysBaseAny16.
    /// </summary>
    [TestModule("EF1038D3-E2A8-4D49-AA82-23BDDA7E70BE", ModuleType.UserCode, 1)]
    public class SysbaseAny16 : BaseClass, ITestModule
    {
        public SysbaseAny16()
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
        		Steps.ClickOnERModelerMenu();
        		Steps.SelectNew();
        		Steps.SelectDataTypeAndVersion(Steps.DatabaseTypes.SybaseAnywhere, "16");
        		Steps.ValidateTree(false, true, true, true, true);
        		Steps.RightClickOnTables();
        		Steps.CreateNewTable();
        		Steps.RightClickOnTables();
        		Steps.CreateNewTable();
        		Steps.RightClickOnTable1();       		
        		Steps.SelectProperties();
        		Steps.EnterParentTableName();        		
        		Steps.CreateColumns();
        		Steps.EditColumns();
        		Steps.RightClickOnTable2();       		
        		Steps.SelectProperties();
        		Steps.EnterChildTableName();
        		Steps.CreateColumns();
        		Steps.CreateNewRelationship();
        		Steps.EnterRelationshipName();
        		Steps.SelectParentTableComboBox();
        		Steps.SelectChildTableComboBox();
        		Steps.CheckParentTableCheckbox();
        		Steps.CheckChildTableCheckbox();
        		Steps.ClickRelationshipOkButton();
        		Steps.SaveERD();
        		Steps.ClickOnERModelerMenu();
        		Steps.SelectOpen();
        		Steps.OpenERD();
        	} 
        	catch (Exception ex) 
        	{
        		Reports.ReportLog(ex.ToString(), Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        	return true;
        }
    }
       
}
