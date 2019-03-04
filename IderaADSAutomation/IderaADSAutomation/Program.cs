using System;
using System.Threading;
using System.Drawing;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using WinForms = System.Windows.Forms;
using System.Configuration;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Reporting;
using Ranorex.Core.Testing;

using IderaADSAutomation.Preconditions;

namespace IderaADSAutomation
{
    class Program
    {
        [STAThread]
        public static int Main(string[] args)
        {	
            Keyboard.AbortKey = System.Windows.Forms.Keys.Pause;
            int error = 0;

            try
            {
                error = TestSuiteRunner.Run(typeof(Program), Environment.CommandLine);
            }
            catch (Exception e)
            {
                Report.Error("Unexpected exception occurred: " + e.ToString());
                error = -1;
            }
            return error;
        }
    }
}
