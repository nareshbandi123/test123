using System;

namespace ADSAutomationPhaseII.Commons
{
	public static class Reports
	{
		public static void ReportLog(string log, ADSReportLevel reportlevel, Ranorex.Core.Element element, string category)
        {
			System.Threading.Thread.Sleep(200);
        	switch (reportlevel) 
        	{
        		case ADSReportLevel.Fail:
					Ranorex.Report.Failure(category, log);
        			Ranorex.Report.Screenshot(element);
        			break;
    			case ADSReportLevel.Info:
	    			Ranorex.Report.Info(category, log);        			
	    			break;
    			case ADSReportLevel.Success:
	    			Ranorex.Report.Success(category, log);        			
	    			break;
        		default:        			
        			break;
        	}
        	System.Threading.Thread.Sleep(200);
        } 

		public enum ADSReportLevel
		{
        	Success = 1,
        	Fail = 2,
        	Info = 3
        }
	}
}
