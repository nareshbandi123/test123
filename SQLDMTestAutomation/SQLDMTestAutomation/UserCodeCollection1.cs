/*
 * Created by Ranorex
 * User: administrator
 * Date: 2/15/2019
 * Time: 6:16 AM
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
using System.Diagnostics;

namespace SQLDMTestAutomation
{
    /// <summary>
    /// Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public static class UserCodeCollection1
    {
    	public static SQLDMTestAutomationRepository repo = SQLDMTestAutomationRepository.Instance;
    	
        // You can use the "Insert New User Code Method" functionality from the context menu,
        // to add a new method with the attribute [UserCodeMethod].
	        
        [UserCodeMethod]
        public static void CleanUp()
        {
           IList<Ranorex.WebDocument> AllDoms = Host.Local.FindChildren<Ranorex.WebDocument>();
		   if (AllDoms.Count >=1)
		   {
			  foreach (WebDocument myDom in AllDoms)
			  {
			     myDom.Close();
			  }            
		   }
        }
	        
	        
	    [UserCodeMethod]  
	    public static void CollapseAllServers()
        {
        	TreeItem item = null; bool isFound = false;
        	try 
        	{
        	    var treeitem = repo.IderaSQLDiagnosticManagerSQLdmRepo.AllServers;
	        	foreach (var itemtree in treeitem.Items)
	        	{
	        		if(itemtree.Expanded)
	        		{
	        			itemtree.Collapse();
	        		}
	        	}
        	} 
        	catch (Exception e)
        	{
        		throw e;
        	}
        } 
	        
        [UserCodeMethod]
	 	public static void KillApplicationProcess()
        {
        	Process[] processByName = Process.GetProcessesByName("SQLdmDesktopClient");
        	int noOfProcesses = processByName.Length;
        	if (processByName.Length != 0)
        	{
        		foreach (Process p in processByName)
        		{
        			p.Kill();
        		}
//	            Report.Log(ReportLevel.Info, "Application", "Run application 'C:\\Program Files\\Idera\\Idera SQL diagnostic manager\\SQLdmDesktopClient.exe' with arguments '' in normal mode.");
//	            Host.Local.RunApplication("C:\\Program Files\\Idera\\Idera SQL diagnostic manager\\SQLdmDesktopClient.exe", "", "C:\\Program Files\\Idera\\Idera SQL diagnostic manager", false);
//	            
//	            Report.Log(ReportLevel.Info, "Wait", "Waiting 5s for the attribute 'Text' to contain the specified value 'SQLDM Today'. Associated repository item: 'textInfo'", textInfo);
//            	textInfo.WaitForAttributeContains(5000, "Text", "SQLDM Today");
//            	
//            	Report.Log(ReportLevel.Info, "Delay", "Waiting for 5s.");
//            	Delay.Duration(5000, false);
        	}
        }

    }
}
