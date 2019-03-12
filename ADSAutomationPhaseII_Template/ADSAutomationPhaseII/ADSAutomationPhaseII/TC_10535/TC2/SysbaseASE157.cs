/*
 * Created by Ranorex
 * User: Admin
 * Date: 2/27/2019
 * Time: 10:59 PM
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
    /// Description of SysbaseASE16.
    /// </summary>
    [TestModule("332D5728-64D1-4DCF-85C2-36ADCC2D3948", ModuleType.UserCode, 1)]
    public class SysbaseASE157 : BaseClass, ITestModule
    {
        public SysbaseASE157()
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
        		Steps.SelectDataTypeAndVersion(Steps.DatabaseTypes.SybaseASE, "157");
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
