using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Net.SourceForge.Vietpad.InputMethod;

namespace iDict
{
    public partial class Translation : Form
    {
        StringBuilder build = new StringBuilder(10000);
        int i, j, previous, count;
        int[] position = new int[50];
        string[] word = new string[50];
        string st = " ,.;:?_<>(){}[]\r\n\t", tmp, meaning;
        public Translation(int Keypad)
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
            txbParagraph.KeyPress += new KeyPressEventHandler(new VietKeyHandler(txbParagraph).OnKeyPress);
            for (i = 0; i < MainDict.Dicts.Length; i++)
            {
                lstDict.Items.Add(MainDict.Dicts[i].dln[3]);
            }
        }
        private void btnTranslation_Click(object sender, EventArgs e)
        {
            if (txbParagraph.SelectionStart == -1 || txbParagraph.SelectionStart == txbParagraph.Text.Length)
                txbParagraph.SelectionStart = 0;
            if (txbParagraph.SelectedText == "")
                WordCut(txbParagraph.Text.Substring(txbParagraph.SelectionStart));
            else WordCut(txbParagraph.SelectedText);
        }
        bool Check(char c)
        {
            for (j = 0; j < st.Length; j++)
                if (c == st[j]) return true;
            return false;
        }
        public void WordCut(string s)
        {
            listBox1.Items.Clear();
            //tách các từ cho vào mảng
            count = 0;
            previous = -1;
            if (s == "") return;
            for (i = 0; i < s.Length; i++)
            {
                if (Check(s[i]))
                {
                    if (i - previous > 1)
                    {
                        word[count] = s.Substring(previous + 1, i - previous - 1);
                        position[count] = previous + 1;
                        count++;
                        if (count >= position.Length)
                            break;
                    }
                    previous = i;
                }
            }
            if (!Check(s[s.Length - 1]) && (i - previous > 1) && count < position.Length)
            {
                word[count] = s.Substring(previous + 1, i - previous - 1);
                position[count] = previous + 1;
                count++;
            }

            //tìm các từ ghép để thêm vào trước khi đổ vào list
            if (lstDict.SelectedIndex == -1) lstDict.SelectedIndex = 0;
            for (i = 0; i < count; i++)
            {
                listBox1.Items.Add(word[i]);
                for (j = i + 1; j < count; j++)
                {
                    tmp = s.Substring(position[i], position[j] - position[i] + word[j].Length);
                    previous = MainDict.Dicts[lstDict.SelectedIndex].Translator(tmp);
                    if (previous == 1) listBox1.Items.Add(tmp);
                    else if (previous == -1)
                        break;
                }
            }
            if (listBox1.Items.Count > 0)
                MultiDict(listBox1.Items[0].ToString());
            txbParagraph.SelectionStart = txbParagraph.SelectionStart + position[0];
            txbParagraph.ScrollToCaret();
            txbParagraph.SelectionLength = position[count - 1] - position[0] + word[count - 1].Length;
            txbParagraph.Focus();
        }
        private void MultiDict(string word)
        {
            build.Remove(0, build.Length);
            int count = 0, newDict = MainDict.selected;
            for (i = 0; i < MainDict.Dicts.Length; i++)
            {
                meaning = MainDict.Dicts[i].Lookup2(word, ref MainDict.similarWord, i * 15);
                if (meaning != "")
                {
                    count++;
                    if (count != 1) build.Append("\n<hr>\n");
                    build.Append("#The dictionary " + MainDict.Dicts[i].dln[3] + "\n");
                    build.Append(meaning + "\n");
                }
            }
            if (count == 0)//không có từ nào thì tra từ tiếp theo của từ điển đang chọn
            {
                build.Append("#Không có result nào, các bạn có thể lựa chọn các result dưới:\n");
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
                count = Array.BinarySearch(MainDict.similarWord, 0, j, word, MainDict.ss);
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
            webBrowser1.DocumentText = Dict.ToHtml(build.ToString());
        }
        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
                MultiDict(listBox1.Items[listBox1.SelectedIndex].ToString());
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser w = sender as WebBrowser;
            if (w.Url.Fragment != "#reference") return;
            if (w.Document.ActiveElement.TagName == "A") 
            {
                tmp = w.Document.ActiveElement.OuterText;
            }
            else
            {
                tmp = w.Document.ActiveElement.OuterText;
                if (tmp.Substring(0, 6) != "blank#")
                {
                    return;
                }
                else
                {
                    tmp = tmp.Substring(6);
                }
            }
            MultiDict(tmp);
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && (listBox1.SelectedIndex != -1))
                MultiDict(listBox1.Items[listBox1.SelectedIndex].ToString());
        }
        private void btnLookup_Click(object sender, EventArgs e)
        {
            if (txbParagraph.SelectedText != "") MultiDict(txbParagraph.SelectedText);
        }
    }
}