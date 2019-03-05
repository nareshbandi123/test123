/*
 * Created by Ranorex
 * User: administrator
 * Date: 2/15/2019
 * Time: 6:16 AM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.IO;
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
    public static class CommonMethods
    {
    	public static SQLDMTestAutomationRepository repo = SQLDMTestAutomationRepository.Instance;
    	
        // You can use the "Insert New User Code Method" functionality from the context menu,
        // to add a new method with the attribute [UserCodeMethod].
	    
        public static int nextFileCounter = 1;
		        
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
        	    var treeitem = repo.SQLDM.IderaSQLDiagnosticManagerSQLdmRepo.AllServers;
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
	 	public static void KillApplicationProcess(string application)
        {
        	//Process[] processByName = Process.GetProcessesByName("SQLdmDesktopClient");
        	Process[] processByName = Process.GetProcessesByName(application);
        	int noOfProcesses = processByName.Length;
        	if (processByName.Length != 0)
        	{
        		foreach (Process p in processByName)
        		{
        			p.Kill();
        		}
        	}
        }
	 	
	 	
	 	[UserCodeMethod]
        public static String GetSqlQueriesFilePath()
        {
        	string tcName = GetCurrentTestCase();
        	string[] arrTestCaseName = tcName.Split('_');
        	string tcNumber = arrTestCaseName[0];
        	string startupPath = Environment.CurrentDirectory; // This will get the current WORKING directory (i.e. \bin\Debug)
        	Report.Log(ReportLevel.Info, "Environment.CurrentDirectory=", startupPath);
        	string filePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\/Testdata/Sqlqueries/" + tcNumber + "/" + tcNumber + "_" + CommonMethods.nextFileCounter +".txt"));
        	Report.Log(ReportLevel.Info, "Sql file path=", filePath);
        	return filePath;        	
        }
        
        
        [UserCodeMethod]
        public static String GetCurrentTestCase()
        {
        	//return "C165705";
        	return TestSuite.CurrentTestContainer.Name;
        }
        
        [UserCodeMethod]
        public static string ReadTextFile(string file)
        {   
        	string text = string.Empty;
            if (File.Exists(file))
            {
                // Read entire text file content in one string  
                text = File.ReadAllText(file);
            }
            Report.Log(ReportLevel.Info, "sql query from file=", text);
            return text;
        }
        
        
        [UserCodeMethod]
        public static int NextSqlFileCounter()
        {
          	return nextFileCounter = nextFileCounter + 1;
        }
	        

    }
}

