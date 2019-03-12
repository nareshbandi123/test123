using System;
using System.Drawing;
using System.Text;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Commons;
using Ranorex.Core;
using Ranorex;



namespace ADSAutomationPhaseII.TC_10555
{
   
    public static class Steps
	{
		public static TC10555Repo repo = TC10555Repo.Instance;
		
		
		public static bool ClickonHelpMenu()
		{
			try
			{
				//f1(repo.Application.HelpInfo);
				repo.Application.HelpInfo.WaitForExists(new Duration(200));
				repo.Application.Help.ClickThis();
				
			}
			catch(Exception)
			{
				ClickonHelpMenu();				
			}
			return true;
		}
		
		public static bool ClickonAboutAquaDataStudio()
		{
			try
			{
				repo.DataStudio.AboutADSInfo.WaitForExists(new Duration(500));
				repo.DataStudio.AboutADS.ClickThis();
				Reports.ReportLog("Opened with following tabs:'About''System''Fonts''JDBS Drivers''Graphics'with all corresponding information", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception)
			{
				ClickonHelpMenu();
				ClickonAboutAquaDataStudio();
			}
			return true;
		}
		
			
		public static bool ClickOnLicense()
		{
			try
			{
			   repo.SunAwtWindow.LicenseInfo.WaitForExists(new Duration(500));
			   repo.SunAwtWindow.License.ClickThis();
			   Reports.ReportLog("License for Aqua Data Studio' pop-up opened", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception)
			{
				ClickOnLicense();
			}
			return true;
		}
		
		#region "To Do"
		
		public static bool EnterLicenseCredentials()
		{
		try
		{
			
			
		}
		catch(Exception)
		{
			
		}
		return true;
		}
		
		public static bool ClickActivateButton()
		{
		try
		{
			
			
		}
		catch(Exception)
		{
			
		}
		return true;
		}
		
		public static bool VerifyAccessInternetBox()
		{
			try
			{
			
			}
			catch(Exception)
			{
				
			}
			return true;
		}
		
		public static bool VerifyEnabledFields()
		{
			try
			{
			
			}
			catch(Exception)
			{
				
			}
			return true;
		}
		
		public static bool ConfirmDeativate()
		{
			try
			{
				
			}
			catch(Exception)
			{
				
			}
			return true;
		}
		
		public static bool ClickManualactivation()
		{
			try
			{
				
			}
			catch(Exception)
			{
				
			}
			return true;
		}
		
		public static bool EnterActivationCode()
		{
			try
			{
				
			}
			catch(Exception)
			{
				
			}
			return true;
		}
		
		public static bool OkButton()
		{
			try
			{
				
			}
			catch(Exception)
			{
				
			}
			return true;
		}
		
		public static bool ClickManualDeactivation()
		{
			try
			{
				
			}
			catch(Exception)
			{
				
			}
			return true;
		} 
		
		public static bool ConfirmDeactivate()
		{
			try
			{
				
			}
			catch(Exception)
			{
				
			}
			return true;
		}
		
		public static bool EnterDeactivationCode()
		{
			try
			{
				
			}
			catch(Exception)
			{
				
			}
			return true;
		}
		
		public static bool ClickOkButton()
		{
			try
			{
				
			}
			catch(Exception)
			{
				
			}
			return true;
		}
		
		#endregion
		
		public static bool ClickonProxySetting()
		{
			try
			{
				repo.LicenseforADS.ProxySetting.ClickThis();
				Reports.ReportLog("'Proxy Settings' pop-up opened", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception)
			{
				
			}
			return true;
		}
		    	
		public static bool ProxyWindowClose()
		{
			try
			{
				repo.ProxyWindow.Close.ClickThis();
				Reports.ReportLog("'Proxy Settings popup closed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception)
			{
				
			}
			return true;
		}
		
		public static bool DeactivateButton()
		{
			try
			{
				repo.ADSMenu.DeactivateButton.ClickThis();
				Reports.ReportLog("'New Project' window is opened", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception)
			{
				
			}
			return true;
		}
		
		public static bool ClickonLicenseAgreement()
		{
			try
			{
				repo.LicenseforADS.LicenceAgreement.ClickThis();
				Reports.ReportLog("License Agreement' text file opened and contains all license agreement", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception)
			{
				
			}
			return true;
		}
		
		public static bool CloseLicenseAgreement()
		{
			try
			{
				repo.LicenseAgreementWindow.Close.ClickThis();
				Reports.ReportLog("License Agreement' text file closed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception)
			{
				
			}
			return true;
		} 
		
		public static bool ClickonJDBCDerivers()
		{
			try
			{
				ClickonHelpMenu();
				ClickonAboutAquaDataStudio();
				repo.ADSMenu.JDBCdrivers.Click();
				Reports.ReportLog("JDBS Drivers tab opened and contains Driver Class with all existing drivers", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception)
			{
				ClickonJDBCDerivers();
			}
			return true;
		}
		
		public static bool CloseJDBC()
		{
			try
			{
				repo.JDBCMenu.Close.ClickThis();
				Reports.ReportLog("About Aqua Data Studio' pop-up closed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception)
			{
				
			}
			return true;
		} 
		
		public static bool ClickonSupportInformation()
		{
			try
			{
				ClickonHelpMenu();				
				repo.DataStudio.SupportInformation.ClickThis();
				Reports.ReportLog("'New Project' window is opened", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception)
			{
				
			}
			return true;
		}
		
		public static bool CloseSupportInformation()
		{
			try
			{
				repo.SupportInfoMenu.Close.ClickThis();
				Reports.ReportLog("Server Information' pop-up should be displayed and contains all information related to selected server", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception)
			{
				
			}
			return true;
		} 
		
		public static bool CloseLicWindow()
		{
			try 
			{
				repo.LicenseforADS.CancelButton.ClickThis();
			} 
			catch (Exception) 
			{
			}
			return true;
		}
		
		public static bool ClickonServers()
		{ 
			try
			{
				repo.Application.F1Menu.ClickThis();
				
			}
			catch(Exception)
			{
			
			}
			return true;
		}
          
    }
}
    
      
        	
        	
        	
        	
        	
        	
        	
        	
        	
      