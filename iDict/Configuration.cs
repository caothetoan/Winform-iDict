using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SpeechLib;
namespace iDict
{
    public partial class Configuration : Form
    {
        
        SpVoice voice = new SpVoice();
        public Configuration()
        {
            InitializeComponent();
        }

        private void chbStartWithWindows_CheckedChanged(object sender, EventArgs e)
        {
          
          /*if (chbStartWithWindows.Checked == false)
          {
              // Add the value in the registry so that the application runs at startup
              rkApp.SetValue("iDict", Application.ExecutablePath.ToString());
              chbStartWithWindows.Checked = true;
          }
          else
          {
              // Remove the value from the registry so that the application doesn't start
              rkApp.DeleteValue("iDict", false);
              chbStartWithWindows.Checked = false;
          }
           * */
         
        }

        private void chbClipboard_CheckedChanged(object sender, EventArgs e)
        {
            //MainDict.miniDict.timer1.Enabled = !MainDict.miniDict.timer1.Enabled;
            
        }

        private void Configuration_Load(object sender, EventArgs e)
        {
            foreach (ISpeechObjectToken t in voice.GetVoices("", ""))
            {
                cbbVoice.Items.Add(t.GetAttribute("Name"));
            }
            
        }

        private void cbbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbLanguage.SelectedIndex == 0)
            {
                Properties.Settings.Default.Language = "en-US";
                Properties.Settings.Default.Save();
                MessageBox.Show(Properties.Resources.ConfirmMessage,
                    Properties.Resources.ConfirmTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cbbLanguage.SelectedIndex == 1)
            {
                Properties.Settings.Default.Language = "vi-VN";
                Properties.Settings.Default.Save();
                MessageBox.Show(Properties.Resources.ConfirmMessage,
                    Properties.Resources.ConfirmTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Confirm cfm = new Confirm();
            cfm.ShowDialog();
            Application.Restart();
            
        }

        private void cbbVoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            voice.Voice = voice.GetVoices("", "").Item(cbbVoice.SelectedIndex);
        }
    }
}
