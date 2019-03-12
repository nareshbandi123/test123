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

namespace ADSAutomationPhaseII.TC_10548
{
    [TestModule("61F0E5D9-E58E-4068-B8B5-2B57CD377432", ModuleType.UserCode, 1)]
    public class Cleanup :Base.BaseClass, ITestModule
    {
        public Cleanup()
        {
            
        }

        void ITestModule.Run()
        {
        	Steps.ClickonServers();
        }
    }
}
