/*
 * Created by Ranorex
 * User: Admin
 * Date: 2/27/2019
 * Time: 10:01 PM
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
    /// Description of MariaDB341.
    /// </summary>
    [TestModule("CEF9809D-9820-4FF5-92F8-B351FAA24CC1", ModuleType.UserCode, 1)]
    public class MongoDB341 : BaseClass, ITestModule
    {
       
        public MongoDB341()
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
        		Steps.SelectDataTypeAndVersion(Steps.DatabaseTypes.MongoDB, "341");
        		Steps.ValidateTree(true,false, true, true, true);
        		Steps.RightClickOnCollections();
        		Steps.CreateNewCollection();
        		Steps.RightClickOnCollections();
        		Steps.CreateNewCollection();
        		Steps.RightClickOnCollection1();
        		Steps.SelectProperties();
        		Steps.EnterParentCollectionName();
        		Steps.CreateCollectionColumns();
        		Steps.EditCollectionColumns();
        		Steps.RightClickOnCollection2();
        		Steps.SelectProperties();
        		Steps.EnterChildCollectionName();
        		Steps.CreateCollectionColumns();
        		Steps.CreateNewCollectionRelationship();
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
