using System;
using ADSAutomationPhaseII.Extensions;
using System.Configuration;

namespace ADSAutomationPhaseII.Commons
{
	public static class Common
	{	
		public static int ApplicationOpenWaitTime = 180000;
		
		public static void DeleteFile(string filename)
        {
        	try 
        	{
	        	if(System.IO.File.Exists(filename))
	        		System.IO.File.Delete(filename);
        	} 
        	catch (Exception e)
        	{
        		throw e;
        	}
        }
	}
}


