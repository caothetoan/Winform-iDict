using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Net.SourceForge.Vietpad.InputMethod;
using System.IO;

namespace iDict
{
    public partial class EditWord : Form
    {
        int i, position,l;
        public EditWord(int Keypad, int editingPosition, string word, string meaning)
        {
            InitializeComponent();
            TextBoxBase textComp = new TextBox();
            VietKeyHandler keyHandler = new VietKeyHandler(textComp);
            textComp.KeyPress += new KeyPressEventHandler(keyHandler.OnKeyPress);
            if (Keypad == 0)
                VietKeyHandler.VietModeEnabled = false;
            else if (Keypad == 1)
            {
                VietKeyHandler.VietModeEnabled = true;
                VietKeyHandler.InputMethod = InputMethods.VNI;
            }
            else if (Keypad == 2)
            {
                VietKeyHandler.VietModeEnabled = true;
                VietKeyHandler.InputMethod = InputMethods.Telex;
            }
            else if (Keypad == 3)
            {
                VietKeyHandler.VietModeEnabled = true;
                VietKeyHandler.InputMethod = InputMethods.VIQR;
            }
            VietKeyHandler.SmartMark = true;
            txbMeaning.KeyPress += new KeyPressEventHandler(new VietKeyHandler(txbMeaning).OnKeyPress);
            txbWord.Text = word;
            txbMeaning.Text = meaning;
            txbMeaning.SelectionStart = 0;
            position = editingPosition;
        }
        private void AddComponent(string s1, string s2)
        {
            i = txbMeaning.SelectionStart;
            l = s1.Length + s2.Length + txbMeaning.SelectionLength;
            txbMeaning.SelectedText = s1 + txbMeaning.SelectedText + s2;
            txbMeaning.Select(i, l);
        }
        private void AddComponent(string s)
        {
            txbMeaning.SelectedText = s;
        }
        private void tsComponent_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.ToolTipText == "Image Folder")
            {
                if (!System.IO.Directory.Exists(iDict.MainDict.path + "\\Images\\"))
                    System.IO.Directory.CreateDirectory(iDict.MainDict.path + "\\Images\\");
                System.Diagnostics.Process.Start(iDict.MainDict.path + "\\Images\\");
            }
            else if (txbMeaning.SelectionStart <= 0 || txbMeaning.Text[txbMeaning.SelectionStart - 1] == '\n')
                AddComponent(e.ClickedItem.ToolTipText);
            else AddComponent("\r\n" + e.ClickedItem.ToolTipText);
        }
        private void tsDinhDang_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "B")
                AddComponent("<b>", "</b>");
            else if (e.ClickedItem.Text == "I")
                AddComponent("<i>", "</i>");
            else if (e.ClickedItem.Text == "U")
                AddComponent("<u>", "</u>");
            else if (e.ClickedItem.Text == "i")
                AddComponent("<i>", "</i>");
            else if (e.ClickedItem.Text == "Sup")
                AddComponent("<sup>", "</sup>");
            else if (e.ClickedItem.Text == "Sub")
                AddComponent("<sub>", "</sub>");
            else if (e.ClickedItem.Text == "Sup")
                AddComponent("<sup>", "</sup>");
            else if (e.ClickedItem.Text == "Transition")
                AddComponent("<a href=\"#reference\">", "</a>");
            else if (e.ClickedItem.Text == "<")
                AddComponent("&lt;");
            else if (e.ClickedItem.Text == ">")
                AddComponent("&gt;");
            else if (e.ClickedItem.Text == "&&")
                AddComponent("&amp;");
            else if (e.ClickedItem.Text == "Space")
                AddComponent("&nbsp;");
        }

        private void tsTranscribe_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "More")
            {
                if (File.Exists(iDict.MainDict.path + "\\Help\\IPA Keyboard.htm"))
                    System.Diagnostics.Process.Start(iDict.MainDict.path + "\\Help\\IPA Keyboard.htm");
                else MessageBox.Show("File Not found", "Error");
            }
            else if (e.ClickedItem.Text == "View")
            {
                webBrowser1.Document.OpenNew(true);
                webBrowser1.DocumentText = Dict.ToHtml(txbMeaning.Text);
            }
            else if (e.ClickedItem.Text == "Display")
            {
                if (splitContainer1.Orientation == Orientation.Horizontal)
                    splitContainer1.Orientation = Orientation.Vertical;
                else splitContainer1.Orientation = Orientation.Horizontal;
            }
            else if (e.ClickedItem.Text == "Edit")
            {
                if ((txbWord.Text = txbWord.Text.Trim()) == "")
                {
                    MessageBox.Show("The Word hasn't had content yet.", "Announcement");
                    return;
                }
                if ((txbMeaning.Text = txbMeaning.Text.Replace("\r", "").Trim()) == "")
                {
                    MessageBox.Show("The Meaning hasn't had content yet.", "Announcement");
                    return;
                }
                i = iDict.MainDict.Dicts[iDict.MainDict.selected].EditWord(position, txbMeaning.Text);
                if (i < 0)
                {
                    MessageBox.Show("This Word has existed.", "Announcement");
                }
                else Close();
            }
            else
                AddComponent(e.ClickedItem.Text);
        }

        private void txbMeaning_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                webBrowser1.Document.OpenNew(true);
                webBrowser1.DocumentText = Dict.ToHtml(txbMeaning.Text);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEditWord_Click(object sender, EventArgs e)
        {
            if ((txbWord.Text = txbWord.Text.Trim()) == "")
            {
                MessageBox.Show("Please, write meaning of word.", "Announcement");
                return;
            }
            if ((txbMeaning.Text = txbMeaning.Text.Replace("\r", "").Trim()) == "")
            {
                MessageBox.Show("Please, write meaning of word", "Announcement");
                return;
            }
            i = iDict.MainDict.Dicts[iDict.MainDict.selected].EditWord(position, txbMeaning.Text);
            if (i < 0)
            {
                MessageBox.Show("This word existed", "Announcement");
            }
            else Close();
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbEditWord_Click(object sender, EventArgs e)
        {
            if ((txbWord.Text = txbWord.Text.Trim()) == "")
            {
                MessageBox.Show("Please, write meaning of word.", "Announcement");
                return;
            }
            if ((txbMeaning.Text = txbMeaning.Text.Replace("\r", "").Trim()) == "")
            {
                MessageBox.Show("Please, write meaning of word", "Announcement");
                return;
            }
            i = iDict.MainDict.Dicts[iDict.MainDict.selected].EditWord(position, txbMeaning.Text);
            if (i < 0)
            {
                MessageBox.Show("This word existed", "Announcement");
            }
            else Close();
        }
    }
}