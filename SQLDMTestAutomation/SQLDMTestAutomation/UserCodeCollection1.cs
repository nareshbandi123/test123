﻿/*
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

namespace SQLDMTestAutomation
{
    /// <summary>
    /// Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class UserCodeCollection1
    {
        // You can use the "Insert New User Code Method" functionality from the context menu,
        // to add a new method with the attribute [UserCodeMethod].
        
        /// <summary>
    /// Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
	    [UserCodeCollection]
	    public class CleanUpActivity
	    {
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
	        
//	        [UserCodeMethod]
//		    public void ClickQueryMonitorTraceCheckBox(RepoItemInfo checkboxInfo)
//	        {
//	            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'checkboxInfo' at Center.", checkboxInfo);
//	            if (!(checkboxInfo.FindAdapter<CheckBox>().Checked))
//	            {
//	            	checkboxInfo.FindAdapter<CheckBox>().Click();
//	            }
//	        }
	    
	    }
    }
}
