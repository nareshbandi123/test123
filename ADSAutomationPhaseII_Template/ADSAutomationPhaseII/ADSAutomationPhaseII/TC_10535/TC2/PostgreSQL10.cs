﻿/*
 * Created by Ranorex
 * User: Admin
 * Date: 2/27/2019
 * Time: 10:14 PM
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
    /// Description of PostgreSQL10.
    /// </summary>
    [TestModule("39FB5C1D-E084-482D-847C-AF72B1AB9800", ModuleType.UserCode, 1)]
    public class PostgreSQL10 : BaseClass, ITestModule
    {
        public PostgreSQL10()
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
        		Steps.SelectDataTypeAndVersion(Steps.DatabaseTypes.PostgreSQL, "10");
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
