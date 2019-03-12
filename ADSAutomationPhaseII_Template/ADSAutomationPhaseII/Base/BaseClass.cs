using System;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using ADSAutomationPhaseII.Configuration;

namespace ADSAutomationPhaseII.Base
{
	public class BaseClass
	{
		public BaseClass()
		{
			Mouse.DefaultMoveTime = 0;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            Ranorex.Controls.ProgressForm.Hide();  
            
            Config.TestCaseName = ((TestCaseNode)TestSuite.CurrentTestContainer).Name;
		}
	}
}
