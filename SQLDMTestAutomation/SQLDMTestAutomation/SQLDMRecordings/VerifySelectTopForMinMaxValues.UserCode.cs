﻿///////////////////////////////////////////////////////////////////////////////
//
// This file was automatically generated by RANOREX.
// Your custom recording code should go in this file.
// The designer will only add methods to this file, so your custom code won't be overwritten.
// http://www.ranorex.com
//
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Repository;
using Ranorex.Core.Testing;

namespace SQLDMTestAutomation.SQLDMRecordings
{
    public partial class VerifySelectTopForMinMaxValues
    {
        /// <summary>
        /// This method gets called right after the recording has been started.
        /// It can be used to execute recording specific initialization code.
        /// </summary>
        private void Init()
        {
            // Your recording specific initialization code goes here.
        }

        public void Key_sequence_OkButton(RepoItemInfo buttonInfo)
        {
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence '{ENTER}' with focus on 'buttonInfo'.", buttonInfo);
            buttonInfo.FindAdapter<Button>().PressKeys("{ENTER}");
        }

        public void Invoke_action_OkButton(RepoItemInfo buttonInfo)
        {
            Report.Log(ReportLevel.Info, "Invoke action", "Invoking Focus() on item 'buttonInfo'.", buttonInfo);
            buttonInfo.FindAdapter<Button>().Focus();
        }

        public void Key_sequence_UpDownEdit(RepoItemInfo textInfo)
        {
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence '0' with focus on 'textInfo'.", textInfo);
            textInfo.FindAdapter<Text>().PressKeys("0");
        }

        public void Key_shortcut_UpDownEdit(RepoItemInfo textInfo)
        {
            Report.Log(ReportLevel.Info, "Keyboard", "Key 'Ctrl+A' Press with focus on 'textInfo'.", textInfo);
            Keyboard.PrepareFocus(textInfo.FindAdapter<Text>());
            Keyboard.Press(System.Windows.Forms.Keys.A | System.Windows.Forms.Keys.Control, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
        }

        public void Validate_UpDownEdit(RepoItemInfo textInfo)
        {
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Enabled='True') on item 'textInfo'.", textInfo);
            Validate.AttributeEqual(textInfo, "Enabled", "True");
        }

        public void Invoke_action_UpDownEdit(RepoItemInfo textInfo)
        {
            Report.Log(ReportLevel.Info, "Invoke action", "Invoking EnsureVisible() on item 'textInfo'.", textInfo);
            textInfo.FindAdapter<Text>().EnsureVisible();
        }

    }
}
