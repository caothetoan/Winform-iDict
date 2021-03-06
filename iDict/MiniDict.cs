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
    public partial class MiniDict : Form
    {
        StringBuilder build = new StringBuilder(10000);
        int count = 0, i, j;
        string meaning, tmp, st;
        string[] list1;
        SpVoice voice1 = new SpVoice();
        public MiniDict(int length)
        {
            InitializeComponent();
            list1 = new string[length * 15];
            this.Opacity = 100;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            try            
            {
                if (Clipboard.ContainsText(TextDataFormat.Text) && st != Clipboard.GetText(TextDataFormat.UnicodeText))
                {
                    textBox1.Text = st = Clipboard.GetText(TextDataFormat.UnicodeText);
                    if ((Cursor.Position.X + 7 + this.Width) > Screen.PrimaryScreen.WorkingArea.Width)
                        this.Left = Cursor.Position.X - 7 - this.Width;
                    else this.Left = Cursor.Position.X + 7;
                    if ((Cursor.Position.Y + 10 + this.Height) > Screen.PrimaryScreen.WorkingArea.Height)
                        this.Top = Cursor.Position.Y - 10 - this.Height;
                    else 
                        this.Top = Cursor.Position.Y + 10;
                    
                    this.Show();
                    this.Top = 0;
                    this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
                    TopLevel = true;
                    MultiDict();                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to scan clipboard");
            }
            
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            tmp = MainDict.Dicts[MainDict.selected].ToLower(textBox1.Text) ;
            for (i = 0; i < MainDict.Dicts.Length; i++)
                MainDict.Dicts[i].Lookup(tmp, ref list1, i * 15);
            Array.Sort(list1, MainDict.ss);
            j = 0; count = 0;
            for (i = 0; i < list1.Length; i++)
            {
                if (list1[i] != list1[j])
                {
                    count++;
                    j++;
                    list1[j] = list1[i];
                }
            }
            count = Array.BinarySearch(list1, 0, j, tmp, MainDict.ss);
            if (count < 0) count = ~count;
            for (i = count; i < count + 15; i++)
            {
                if ((i >= 0) && (i <= j) && list1[i] != "")
                {
                    listBox1.Items[i-count] = "";
                    listBox1.Items[i-count] = list1[i];
                }
            }
            listBox1.Visible = true;
            btnShowHide.Text = "Hide";
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MultiDict();
                textBox1.SelectAll();
            }
            else if (e.KeyCode == Keys.Back && e.Shift == true)
            {
                textBox1.Text = "";
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
            }
        }
        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            textBox1.Text = e.Data.GetData(DataFormats.UnicodeText).ToString();
            MultiDict();
        }

        private void MultiDict()
        {
            tmp = textBox1.Text;
            build.Remove(0, build.Length);
            listBox1.Visible = false;
            btnShowHide.Text = "Show";
            int count = 0, newDict = MainDict.selected;
            for (i = 0; i < MainDict.Dicts.Length; i++)
            {
                meaning = MainDict.Dicts[i].Lookup2(tmp, ref MainDict.similarWord, i * 15);
                if (meaning != "")
                {
                    count++;
                    if (count != 1) build.Append("\n<hr>\n");
                    build.Append("#Dictionary " + MainDict.Dicts[i].dln[3] + "\n");
                    build.Append(meaning + "\n");
                }
            }
            if (count == 0)//không có từ nào thì tra từ tiếp theo của từ điển đang chọn
            {
                build.Append("#No exactly result, select the below results:\n");
                Array.Sort(MainDict.similarWord, MainDict.ss);
                //lọc phần tử trùng nhau
                j = 0;
                for (i = 0; i < MainDict.similarWord.Length; i++)
                {
                    if (MainDict.similarWord[i] != MainDict.similarWord[j])
                    {
                        j++;
                        MainDict.similarWord[j] = MainDict.similarWord[i];
                    }
                }
                count = Array.BinarySearch(MainDict.similarWord, 0, j, tmp, MainDict.ss);
                if (count < 0) count = ~count;
                for (i = count - 7; i < count; i++)
                {
                    if ((i >= 0) && (i <= j) && MainDict.similarWord[i] != "")
                        build.Append("<a href='#reference'>" + MainDict.similarWord[i] + "</a> , ");
                }
                build.Append("&lt; &gt; ");
                for (i = count; i < count + 8; i++)
                {
                    if ((i >= 0) && (i <= j) && MainDict.similarWord[i] != "")
                        build.Append("<a href='#reference'>" + MainDict.similarWord[i] + "</a> , ");
                }
            }
            else
            {
                build.Insert(0, "<i><u>There're : " + count.ToString() + " results</u></i>\n");
            }
            webBrowser1.Document.OpenNew(true);
            webBrowser1.DocumentText =Dict.ToHtml(build.ToString());
        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser wb = sender as WebBrowser;
            if (wb.Url.Fragment != "#reference") return;
            if (wb.Document.ActiveElement.TagName == "A")
            {
                tmp = wb.Document.ActiveElement.OuterText;
            }
            else
            {
                tmp = wb.Document.ActiveElement.OuterText;
                if (tmp.Substring(0, 6) != "blank#")
                {
                    return;
                }
                else
                {
                    tmp = tmp.Substring(6);
                }
            }
            textBox1.Text = tmp;
            MultiDict();
        }
        //
        private void MiniDict_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
            }
            else if (e.KeyCode == Keys.Back && e.Shift == true)
            {
                textBox1.Text = "";
            }
            
        }
        //
        private void MiniDict_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Hide();
                e.Cancel = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
           
        }
        private void btnShowHide_Click(object sender, EventArgs e)
        {
            listBox1.Visible = !listBox1.Visible;
            if (listBox1.Visible == false)
                btnShowHide.Text = "Show";
            else btnShowHide.Text = "Hide";
        }

        private void btnLocation_Click(object sender, EventArgs e)
        {
            if (this.Left == Screen.PrimaryScreen.WorkingArea.Width - this.Width)
                this.Left = 0;
            else this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
            this.Top = 25;
        }
        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = listBox1.SelectedItem.ToString();
            MultiDict();
        }
        // 
        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Text = listBox1.SelectedItem.ToString();
                MultiDict();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
            }
        }
        //
        private void btnPronounce_Click(object sender, EventArgs e)
        {
            //voice1.Speak(textBox1.Text, SpeechVoiceSpeakFlags.SVSFDefault);
            voice1.Speak(textBox1.Text, SpeechVoiceSpeakFlags.SVSFNLPSpeakPunc);
        }

        private void cbbVoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            voice1.Voice = voice1.GetVoices("", "").Item(cbbVoice.SelectedIndex);
            
        }

        private void MiniDict_Load(object sender, EventArgs e)
        {
            foreach (ISpeechObjectToken t in voice1.GetVoices("", ""))
            {
                cbbVoice.Items.Add(t.GetAttribute("Name"));
            }
            
        }
        
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            double opacity = this.trackBar1.Value;
            if (opacity != 0)
                opacity = opacity / 10;
            this.Opacity = opacity;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
                this.TopMost = true;
            else this.TopMost = false;
        } 
    }
}