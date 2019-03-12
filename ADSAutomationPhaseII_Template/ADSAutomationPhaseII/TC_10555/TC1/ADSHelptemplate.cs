
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


namespace ADSAutomationPhaseII.TC_10555.TC1
{
    
    [TestModule("B7AE4BC4-95E1-4196-8066-823138436853", ModuleType.UserCode, 1)]
    public class ADSHelptemplate : BaseClass, ITestModule
    {
        
        public ADSHelptemplate()
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
        		Steps.ClickonHelpMenu();
        		Steps.ClickOnLicense();  
//        		Steps.EnterLicenseCredentials(); // To Do
//        		Steps.ClickActivateButton(); // To Do
        		Steps.ClickonProxySetting(); 
//        		Steps.VerifyAccessInternetBox(); // To Do
//         		Steps.VerifyEnabledFields(); // To Do
        		Steps.ProxyWindowClose();
//        		Steps.DeactivateButton();
//        		Steps.ConfirmDeativate(); // To Do
//        		Steps.ClickManualactivation(); // To Do
//        		Steps.EnterActivationCode(); // To Do
//        		Steps.OkButton(); // To Do
//        		Steps.ClickManualDeactivation(); // To Do	
//             	Steps.ConfirmDeactivate(); // To Do
//        		Steps.EnterDeactivationCode(); // To Do      		
//       		Steps.ClickOkButton(); // To Do
        		Steps.ClickonLicenseAgreement();
        		Steps.CloseLicenseAgreement();
        		Steps.CloseLicWindow();
        		Steps.ClickonJDBCDerivers();
        		Steps.CloseJDBC();
        		Steps.ClickonSupportInformation();
        		Steps.CloseSupportInformation();
        		Steps.ClickonServers();
        		
        	} 
        	catch (Exception)
        		
        		
        	{
        	}
        	return true;
        }
    }
}
    