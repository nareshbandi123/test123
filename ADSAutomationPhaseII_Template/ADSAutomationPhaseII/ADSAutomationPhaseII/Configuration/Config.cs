using System;

namespace ADSAutomationPhaseII.Configuration
{
	public static class Config
	{
		public static string AppPath = System.Configuration.ConfigurationManager.AppSettings["APP_PATH"].ToString();
		public static int ProcessID;
		public static string TestCaseName;
	}
}
