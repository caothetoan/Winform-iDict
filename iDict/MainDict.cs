using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Globalization;
using Microsoft.Win32;
using Net.SourceForge.Vietpad.InputMethod; //namespace của bộ gõ tích hợp
using SAPIEngineLib;// SpeechAPI engine
using SpeechLib;//Speech engine
using System.Runtime.InteropServices;
using System.Reflection;

using AgentObjects;
using AgentServerObjects;//Msagent

/* Thiết lập từ điển Dòng đầu gồm 4 số
       Bộ gõ lưu bằng số :0 1 2 3
       Có tự tắt bật bộ gõ không : 0 1
       có chuyển đổi từ điển khi tra nhiều hay không: 0 1
       form ẩn hay hiện khi khởi động : 0 1
       Dòng 2 trở đi là tên các từ điển sẽ dùng*/
namespace iDict
{
    public partial class MainDict : Form
    {
        public static string[] listDict;
        public static string path, establish, strFileName;
        public static Dict[] Dicts;
        public static int selected = 0;

        public static string[] similarWord;
        int i, j, position, listLength, scrollOld = 0;
        
        string meaning, tmp;
        StringBuilder build = new StringBuilder(10000);
        public static IComparer ss = new Comparison();
        RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        MiniDict miniDict;
        //SPWORDPRONUNCIATION voice1 = new SPWORDPRONUNCIATION();
        SpVoice voice = new SpVoice();
        IAgentCharacterEx CharacterEx = null;
        int dwReqID = 0;

        public MainDict()
        {
            InitializeComponent();
            cbbKeypad.SelectedIndex = 0;
            TextBoxBase textComp = new TextBox();
            VietKeyHandler keyHandler = new VietKeyHandler(textComp);
            textComp.KeyPress += new KeyPressEventHandler(keyHandler.OnKeyPress);
            VietKeyHandler.InputMethod = InputMethods.Telex;  
            
            VietKeyHandler.VietModeEnabled = false;
            VietKeyHandler.SmartMark = true;
            cbbWord.KeyPress += new KeyPressEventHandler(new VietKeyHandler(cbbWord).OnKeyPress);
        }
        
        private void MainDict_Load(object sender, EventArgs e)
        {
            //kiểm tra khởi động cùng windows
            if (rkApp.GetValue("iDict") == null)
            {
                cmsStartWithWindows.Checked = false;
            }
            else
            {
                cmsStartWithWindows.Checked = true;
            }
            //load từ điển và các thiết lập
            path = Application.StartupPath;
            //
            //strFileName = path + "\\resources\\msagent\\genie.acs";
            strFileName = path + "\\resources\\msagent\\vrgirl.acs";
            //strFileName = "\\" + CBSelectStyle.SelectedItem.ToString() + ".acs";
            
            // Hien thi agent
            ShowAgent();            
            // Doc loi chao mung.
            CharacterEx.Speak("Hi, I'm a virtual girl, also your assistant. Thanks for using iDict, a multi language, multi function and very smart dictionary. Nice day!", null, out dwReqID);
            string[] tmpArray = File.ReadAllLines(path + "\\stored.dat");
            establish = tmpArray[0];
            listDict = new string[tmpArray.Length - 1];
            for (i = 1; i < tmpArray.Length; i++)
                listDict[i - 1] = tmpArray[i];
            if (listDict.Length > 0)
            {
                Dicts = new Dict[listDict.Length];
                bool notFoundDict = false;
                for (i = 0; i < Dicts.Length; i++)
                {
                    if (File.Exists(path + "\\Dictionary\\" + listDict[i] + ".idt"))
                    {
                        Dicts[i] = new Dict(path + "\\Dictionary\\" + listDict[i] + ".idt");
                        tabDictList.TabPages.Add(Dicts[i].dln[3]);
                    }
                    else
                    {
                        notFoundDict = true;
                        Dicts[i] = null;
                    }
                }
                //nếu không thấy từ điển thì ghi lại file stored.dat
                if (notFoundDict == true)
                {
                    StreamWriter stw = File.CreateText(path + "\\stored.dat");
                    stw.Write(establish);
                    for (i = 0; i < Dicts.Length; i++)
                        if (Dicts[i] != null) stw.Write("\r\n" + Dicts[i].fileName);
                    stw.Flush();
                    stw.Close();
                    Application.Restart();
                    return;
                }
                //load item vào combobox
                if (File.Exists(path + "\\Items.txt"))
                {
                    StreamReader str = new StreamReader(path + "\\Items.txt");
                    int i = 0;
                    while ((tmp = str.ReadLine()) != null && i < 50)
                    {
                        cbbWord.Items[i] = tmp;
                        i++;
                    }
                    str.Close();
                }
                //bắt đầu thiết lập thuộc tính cho từ điển
                cbbKeypad.SelectedIndex = int.Parse(establish[0].ToString());
            }
            else
            {
                DialogResult result = MessageBox.Show("There's no database in the dictionary. Do you want to create or use the one?", "Announcement", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    ManageDict frm = new ManageDict(cbbKeypad.SelectedIndex);
                    frm.ShowDialog();
                }
                else MessageBox.Show("The application can't run without at least a database.", "Announcement");
                Application.Exit();
                return;
            }
            // Lay giong phat am
            foreach (ISpeechObjectToken t in voice.GetVoices("", ""))
            {
                cbbVoice.Items.Add(t.GetAttribute("Name"));
            }
            miniDict = new MiniDict(Dicts.Length);
            similarWord = new string[15 * tabDictList.TabCount];
            listLength = (lstWordsList.Height - 4) / lstWordsList.ItemHeight;
            listDict = new string[listLength];
            for (i = 0; i < listDict.Length; i++) lstWordsList.Items.Add("");
            OpenDict();
            
        }
        // Mo tu dien
        private void OpenDict()
        {
            // chỉnh vscrollbar
            selected = tabDictList.SelectedIndex;
            vScrollBar1.Maximum = Dicts[selected].totalWords + listLength - 2;
            vScrollBar1.LargeChange = listLength;
            // chỉnh lable hiển thị vị trí phần tử
            lblTotalWord.Text = "/ " + Dicts[selected].totalWords.ToString();
            //tra từ
            scrollOld = -1;
            Lookup();
            //chỉnh bộ gõ
            if (establish[1] == '1')
            {
                if (Dicts[selected].dln[0] == "vi-VN")
                {
                    cbbKeypad.Enabled = true;
                    if (cbbKeypad.SelectedIndex == 0)
                        VietKeyHandler.VietModeEnabled = false;
                    else if (cbbKeypad.SelectedIndex == 1)
                    {
                        VietKeyHandler.VietModeEnabled = true;
                        VietKeyHandler.InputMethod = InputMethods.VNI;
                    }
                    else if (cbbKeypad.SelectedIndex == 2)
                    {
                        VietKeyHandler.VietModeEnabled = true;
                        VietKeyHandler.InputMethod = InputMethods.Telex;
                    }
                    else if (cbbKeypad.SelectedIndex == 3)
                    {
                        VietKeyHandler.VietModeEnabled = true;
                        VietKeyHandler.InputMethod = InputMethods.VIQR;
                    }
                }
                else
                {
                    cbbKeypad.Enabled = false;
                    VietKeyHandler.VietModeEnabled = false;
                }
            }
        }
        // Phuong thuc tra tu
        private void Lookup()
        {
            Dicts[selected].Lookup(cbbWord.Text, ref position, ref meaning, ref listDict);
            if (position >= 0)
            {
                vScrollBar1.Value = position;
                cbbWord.BackColor = Color.Yellow;
            }
            else
            {
                vScrollBar1.Value = ~position;
                cbbWord.BackColor = Color.White;
            }
            txbPosition.Text = (scrollOld + 1).ToString();
            webBrowser1.Document.OpenNew(true);
            webBrowser1.DocumentText = Dict.ToHtml(meaning);
        }
        //
        private void cbbKeypad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbKeypad.SelectedIndex == 0)
                VietKeyHandler.VietModeEnabled = false;
            else if (cbbKeypad.SelectedIndex == 1)
            {
                VietKeyHandler.VietModeEnabled = true;
                VietKeyHandler.InputMethod = InputMethods.VNI;
            }
            else if (cbbKeypad.SelectedIndex == 2)
            {
                VietKeyHandler.VietModeEnabled = true;
                VietKeyHandler.InputMethod = InputMethods.Telex;
            }
            else if (cbbKeypad.SelectedIndex == 3)
            {
                VietKeyHandler.VietModeEnabled = true;
                VietKeyHandler.InputMethod = InputMethods.VIQR;
            }
        }
        //
        private void tabDictList_SelectedIndexChanged(object sender, EventArgs e)
        {
            OpenDict();
        }
        private void MultiDict()
        {
            build.Remove(0, build.Length);
            int count = 0, newDict = selected;
            Dicts[selected].Lookup(cbbWord.Text, ref position, ref meaning, ref listDict);
            if (position >= 0)
            {
                vScrollBar1.Value = position;
                build.Append(meaning);
                count = 1;
            }
            else
            {
                vScrollBar1.Value = ~position;
                Dicts[selected].LoadWordsList(vScrollBar1.Value - 7, ref similarWord, 15);
                tmp = meaning;
            }
            txbPosition.Text = (scrollOld + 1).ToString();
            for (i = 1; i < tabDictList.TabPages.Count; i++)
            {
                position = (i + selected) % tabDictList.TabPages.Count;
                meaning = Dicts[position].Lookup2(cbbWord.Text, ref similarWord, i * 15);
                if (meaning != "")
                {
                    newDict = position; //ghi lại từ điển có xuất hiện nghĩa
                    count++;
                    if (count != 1) build.Append("\n<hr>\n");
                    build.Append("#Từ điển " + Dicts[position].dln[3] + "\n");
                    build.Append(meaning + "\n");
                }
            }
            if (count == 0)//không có từ nào thì tra từ tiếp theo của từ điển đang chọn
            {

                build.Append("#Không có result nào, các bạn có thể lựa chọn các result dưới:\n");
                Array.Sort(similarWord, ss);
                //lọc phần tử trùng nhau
                j = 0;
                for (i = 0; i < similarWord.Length; i++)
                {
                    if (similarWord[i] != similarWord[j])
                    {
                        j++;
                        similarWord[j] = similarWord[i];
                    }
                }
                count = Array.BinarySearch(similarWord, 0, j, cbbWord.Text, ss);
                if (count < 0) count = ~count;
                for (i = count - 7; i < count; i++)
                {
                    if ((i >= 0) && (i <= j) && similarWord[i] != "")
                        build.Append("<a href='#reference'>" + similarWord[i] + "</a> , ");
                }
                build.Append("&lt; &gt; ");
                for (i = count; i < count + 8; i++)
                {
                    if ((i >= 0) && (i <= j) && similarWord[i] != "")
                        build.Append("<a href='#reference'>" + similarWord[i] + "</a> , ");
                }

            }
            //nếu thiết lập chuyển được chọn và chỉ có 1 từ điển có nội dung
            else if (count == 1 && selected != newDict && establish[2] == '1') 
            {
                tabDictList.SelectedIndex = newDict;
                cbbWord.Focus();
                UpdateCbb();
            }
            else
            {
                build.Insert(0, "<i><u>There're : " + count.ToString() + " results</u></i>\n");
                UpdateCbb();
            }
            webBrowser1.Document.OpenNew(true);
            webBrowser1.DocumentText = Dict.ToHtml(build.ToString());
        }
        private void LoadList()
        {
            Dicts[selected].LoadWordsList(vScrollBar1.Value, ref listDict, listDict.Length);
            for (i = 0; i < listDict.Length; i++)
            {
                // vì khi gán, nếu giá trị mới là viết hoa hay viết thường của giá trị cũ thì giá trị cũ
                // không được thay thế , nên phải gán bằng "" thì mới thay thế được hoàn toàn
                lstWordsList.Items[i] = "";
                lstWordsList.Items[i] = listDict[i];
            }
            txbPosition.Text = (vScrollBar1.Value + 1).ToString();
        }
        void UpdateCbb()
        {
            if (cbbWord.Text == "") return;
            tmp = cbbWord.Text;
            for (int i = 0; i < cbbWord.Items.Count; i++)
                if (cbbWord.Text == cbbWord.Items[i].ToString())
                {
                    for (j = i; j > 0; j--)
                        cbbWord.Items[j] = cbbWord.Items[j - 1];
                    cbbWord.Items[0] = tmp;
                    cbbWord.SelectedIndex = 0;
                    return;
                }
            for (j = 99; j > 0; j--)
                cbbWord.Items[j] = cbbWord.Items[j - 1];
            cbbWord.Items[0] = tmp;
            cbbWord.SelectedIndex = 0;
        }
        //
        //Các phương thức xử lý load danh sách nhanh
        //
        // scrollOld kt xem có = value không, nếu không thì thực hiện và gán =value
        private void timer1_Tick(object sender, EventArgs e) 
        {
            if (scrollOld != vScrollBar1.Value)
            {
                Dicts[selected].LoadWordsList(vScrollBar1.Value, ref listDict, listDict.Length);
                for (i = 0; i < listDict.Length; i++)
                {
                    // vì khi gán, nếu giá trị mới là viết hoa hay viết thường của giá trị cũ thì giá trị cũ
                    // không được thay thế , nên phải gán bằng "" thì mới thay thế được hoàn toàn
                    lstWordsList.Items[i] = "";
                    lstWordsList.Items[i] = listDict[i];
                }
                txbPosition.Text = (vScrollBar1.Value + 1).ToString();
                scrollOld = vScrollBar1.Value;
            }
        }
        private void lstWordsList_MouseClick(object sender, MouseEventArgs e)
        {
            cbbWord.Text = lstWordsList.SelectedItem.ToString();
            meaning = Dicts[selected].ReadMeaning(vScrollBar1.Value + lstWordsList.SelectedIndex);
            webBrowser1.Document.OpenNew(true);
            webBrowser1.DocumentText = Dict.ToHtml(meaning);
            txbPosition.Text = (vScrollBar1.Value + lstWordsList.SelectedIndex + 1).ToString();
            cbbWord.Text = lstWordsList.SelectedItem.ToString();
            UpdateCbb();
        }
        private void lstWordsList_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if ((vScrollBar1.Value - 5) > 0) vScrollBar1.Value -= 5;
                else vScrollBar1.Value = 0;
            }
            else if ((vScrollBar1.Value + 5) < Dicts[selected].totalWords) vScrollBar1.Value += 5;
            else vScrollBar1.Value = (int)Dicts[selected].totalWords - 1;
        }
        private void lstWordsList_KeyDown(object sender, KeyEventArgs e)
        {
            //xử lý nút mũi tên lên
            if ((e.KeyValue == 38) && (lstWordsList.SelectedIndex == 0))
                
            {
                if (vScrollBar1.Value > 0) vScrollBar1.Value--;
            }
            else if ((e.KeyValue == 40) && (lstWordsList.SelectedIndex == (listLength - 1)))//xử lý nút mũi tên xuống
            {
                if (vScrollBar1.Value < (Dicts[selected].totalWords - 1)) vScrollBar1.Value++;
            }
            else if (e.KeyData == Keys.PageUp) // nút pageUp
            {
                if (lstWordsList.SelectedIndex != 0) return;
                if ((vScrollBar1.Value - vScrollBar1.LargeChange - 1) > 0) vScrollBar1.Value -= vScrollBar1.LargeChange - 1;
                else vScrollBar1.Value = 0;
            }
            else if (e.KeyData == Keys.PageDown) // nút pageDown
            {
                if (lstWordsList.SelectedIndex != (listLength - 1)) return;
                if ((vScrollBar1.Value + vScrollBar1.LargeChange - 1) < Dicts[selected].totalWords) vScrollBar1.Value += lstWordsList.SelectedIndex;
                else vScrollBar1.Value = (int)(Dicts[selected].totalWords - 1);
            }
            else if (e.KeyData == Keys.Home)// nút home
                vScrollBar1.Value = 0;
            else if (e.KeyData == Keys.End) // nút end
                vScrollBar1.Value = vScrollBar1.Maximum - vScrollBar1.LargeChange + 1;
            else if (e.KeyCode == Keys.Enter)
            {
                cbbWord.Text = (string)lstWordsList.SelectedItem;
                meaning = Dicts[selected].ReadMeaning(vScrollBar1.Value + lstWordsList.SelectedIndex);
                webBrowser1.Document.OpenNew(true);
                webBrowser1.DocumentText = Dict.ToHtml(meaning);
                txbPosition.Text = (vScrollBar1.Value + lstWordsList.SelectedIndex + 1).ToString();
                UpdateCbb();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
            }
        }
        private void MainDict_Resize(object sender, EventArgs e)
        {
            listLength = (lstWordsList.Height - 4) / lstWordsList.ItemHeight;
            if (listLength != listDict.Length)
            {
                listDict = new string[listLength];
                if (listLength > lstWordsList.Items.Count)
                {
                    while (listLength != lstWordsList.Items.Count) lstWordsList.Items.Add("");
                }
                else if (listLength < lstWordsList.Items.Count)
                {
                    lstWordsList.Items.Clear();
                    for (i = 0; i < listLength; i++) lstWordsList.Items.Add("");
                }
                Dicts[selected].LoadWordsList(vScrollBar1.Value, ref listDict, listDict.Length);
                for (i = 0; i < listDict.Length; i++)
                    lstWordsList.Items[i] = listDict[i];
                txbPosition.Text = (vScrollBar1.Value + 1).ToString();
            }
        }
        //
        //Xử lý cbbWord
        //
        private void cbbWord_TextUpdate(object sender, EventArgs e)
        {
            Lookup();
        }
        private void MainDict_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Hide();
                e.Cancel = true;
            }
            StreamWriter str = new StreamWriter(path + "\\Items.txt");
            for (i = 0; i < 99; i++)
                str.WriteLine(cbbWord.Items[i]);
            str.Flush();
            str.Close();
            Stream stw = File.Open(path + "\\stored.dat", FileMode.Open, FileAccess.Write, FileShare.Read);
            establish = cbbKeypad.SelectedIndex.ToString() + establish[1] + establish[2];
            if (this.Visible == false) establish += '0';
            else if (WindowState == FormWindowState.Minimized) establish += '1';
            else if (WindowState == FormWindowState.Normal) establish += '2';
            else if (WindowState == FormWindowState.Maximized) establish += '3';
            for (i = 0; i < 4; i++)
                stw.WriteByte((byte)establish[i]);
            stw.Flush();
            stw.Close();
        }
        //
        private void MainDict_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
            }
            else if (e.KeyCode == Keys.Q && e.Alt == true)
            {
                Application.Exit();
            }
            else if (e.KeyCode == Keys.F1)
            {
                if (File.Exists(path + "\\help\\Help.chm"))
                    System.Diagnostics.Process.Start(path + "\\help\\Help.chm");
                else MessageBox.Show("File Help Not found", "Error");
            }
        }
        //
        private void cbbWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MultiDict();
                cbbWord.SelectAll();
            }
            else if (e.KeyCode == Keys.Back && e.Shift == true)
            {
                cbbWord.Text = "";
            }
        }
        //
        private void cbbWord_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.UnicodeText))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        //
        private void cbbWord_DragDrop(object sender, DragEventArgs e)
        {
            //
            cbbWord.Text = e.Data.GetData(DataFormats.UnicodeText).ToString();
            // tra nhieu tu dien
            MultiDict();
            // hien thi msagent
            ShowAgent();
            CharacterEx.Speak("You can drag drop sentence into combo box to translate them.", null, out dwReqID);

        }
        private void cbbWord_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbbWord.Text = cbbWord.Items[cbbWord.SelectedIndex].ToString();
            MultiDict();
        }
        //
        //Các button
        //
        private void btnAddWord_Click(object sender, EventArgs e)
        {
            AddWord frm = new AddWord(cbbKeypad.SelectedIndex, cbbWord.Text);
            frm.ShowDialog();
            //
            //ShowAgent();
            //CharacterEx.Speak("You should check word and its meaning carefully before adding it into the dictionary data. Thanks.", null, out dwReqID);
           
            if (AddWord.result >= 0)
            {
                vScrollBar1.Value = AddWord.result;
                LoadList();
                lstWordsList.SelectedIndex = 0;
                lstWordsList_MouseClick(null, null);
                lblTotalWord.Text = "/ " + Dicts[selected].totalWords.ToString();
                vScrollBar1.Maximum = vScrollBar1.Maximum = Dicts[selected].totalWords + listLength - 2;
            }
        }
        private void btnEditWord_Click(object sender, EventArgs e)
        {
            if (lstWordsList.SelectedIndex == -1)
                lstWordsList.SelectedIndex = 0;
            if ((lstWordsList.SelectedIndex + vScrollBar1.Value) >= Dicts[selected].totalWords)
            {
                MessageBox.Show("The selected word is not in words list", "Announcement");
                return;
            }
            tmp = lstWordsList.SelectedItem.ToString();
            meaning = Dicts[selected].ReadMeaning(vScrollBar1.Value + lstWordsList.SelectedIndex);
            EditWord frm = new EditWord(cbbKeypad.SelectedIndex, lstWordsList.SelectedIndex + vScrollBar1.Value, tmp, meaning.Replace("\n", "\r\n"));
            frm.ShowDialog();
            lstWordsList_MouseClick(null, null);
        }
        private void btnDeleteWord_Click(object sender, EventArgs e)
        {
            ShowAgent();
            CharacterEx.Speak("Are you sure to delete this word, sir? If your answer is yes, click on button Yes, please!", null, out dwReqID);
            if (lstWordsList.SelectedIndex == -1)
                lstWordsList.SelectedIndex = 0;
            if ((lstWordsList.SelectedIndex + vScrollBar1.Value) >= Dicts[selected].totalWords)
            {
                MessageBox.Show("The selected word is out of words list", "Announcement");
                return;
            }
            DialogResult result = MessageBox.Show("Do you want to delete this word ?", "Announcement", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Dicts[selected].DeleteWord(lstWordsList.SelectedIndex + vScrollBar1.Value);
                LoadList();
                vScrollBar1.Maximum = vScrollBar1.Maximum = Dicts[selected].totalWords + listLength - 2;
                lblTotalWord.Text = "/ " + Dicts[selected].totalWords.ToString();
                lstWordsList_MouseClick(null, null);
            }
        }
        private void btnRename_Click(object sender, EventArgs e)
        {
            if (lstWordsList.SelectedIndex == -1)
                lstWordsList.SelectedIndex = 0;
            if ((lstWordsList.SelectedIndex + vScrollBar1.Value) >= Dicts[selected].totalWords)
            {
                MessageBox.Show("The selected word is out of words list", "Announcement");
                return;
            }
            Rename frm = new Rename(cbbKeypad.SelectedIndex, lstWordsList.SelectedIndex + vScrollBar1.Value, lstWordsList.SelectedItem.ToString());
            frm.ShowDialog();
            if (Rename.result >= 0)
            {
                vScrollBar1.Value = Rename.result;
                LoadList();
                lstWordsList.SelectedIndex = 0;
                lstWordsList_MouseClick(null, null);
            }
        }
        private void btnAbout_Click(object sender, EventArgs e)
        {
            ShowAgent();
            CharacterEx.Speak("You're using the dictionary iDict version 1.0. Coded by HTTP Team, from K50 CD, College of Technology, Vietnam National University, Hanoi. With this dictionary, You can drag drop words into combo box, press enter to translate word into multi language and speak the pronounce of word.", null, out dwReqID);
            About frm = new About();
            frm.ShowDialog();
        }
        
        private void txbPosition_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                try
                {
                    i = int.Parse(txbPosition.Text);
                }
                catch
                {
                    txbPosition.Text = (vScrollBar1.Value + 1).ToString();
                    return;
                }
                if (i < 1)
                {
                    vScrollBar1.Value = 0;
                    scrollOld = -1;
                }
                else if (i > Dicts[selected].totalWords)
                {
                    vScrollBar1.Value = (int)(Dicts[selected].totalWords - 1);
                    scrollOld = -1;
                }
                else
                {
                    vScrollBar1.Value = i - 1;
                    scrollOld = -1;
                }
            }
        }
        // Su kien khi bam vao button Help
        private void btnHelp_Click(object sender, EventArgs e)
        {
            // Kiem tra su ton tai cua duong dan toi file Help.chm
            if (File.Exists(path + "\\help\\Help.chm"))
                // Neu co bat dau tien trinh doc file tu duong dan
                System.Diagnostics.Process.Start(path + "\\help\\Help.chm");
            // Neu khong, thong bao loi khong tim thay file
            else MessageBox.Show("File Help Not found", "Error");
            //
            ShowAgent();
            CharacterEx.Speak("What may i help you, gentle man?", null, out dwReqID);
        }
        //
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
            cbbWord.Text = tmp;
            MultiDict();
        }
        // Xu ly su kien khi bam vao contextmenustrip iDictCV
        private void cmsIDictCV_Click(object sender, EventArgs e)
        {
            ConvertToPlainText frm = new ConvertToPlainText();
            frm.Show();
        }
        // Xu ly su kien khi bam vao contextmenustrip DictTabCV
        private void cmsDictTabCV_Click(object sender, EventArgs e)
        {
            ConvertToIDT frm = new ConvertToIDT();
            frm.Show();
        }
        // Xu ly su kien khi bam vao contextmenustrip BabylonCV
        private void cmsBabylonCV_Click(object sender, EventArgs e)
        {
            ConvertToBaBylon frm = new ConvertToBaBylon();
            frm.Show();
        }
        // Xu ly su kien khi bam vao contextmenustrip StardictDictCV
        private void cmsStardictCV_Click(object sender, EventArgs e)
        {
            if (File.Exists(path + "\\stardict\\stardict-editor.exe"))
                System.Diagnostics.Process.Start(path + "\\stardict\\stardict-editor.exe");
            else MessageBox.Show("File not found", "Error");
        }
        // Xu ly su kien khi bam vao contextmenustrip ClipboardCV
        private void cmsClipboard_Click(object sender, EventArgs e)
        {
            // Hien thi agent va doc thong bao
            ShowAgent();
            CharacterEx.Speak("Scan clipboard function is off.", null, out dwReqID);
            // tat bo dem thoi gian
            timer1.Enabled = !timer1.Enabled;
        }
        //
        private void cmsCheckWord_Click(object sender, EventArgs e)
        {
            CheckWord frm = new CheckWord();
            frm.Show();
        }
        //
        private void cmsHelp_Click(object sender, EventArgs e)
        {
            ShowAgent();
            CharacterEx.Speak("What can i help you, sir?", null, out dwReqID);
            if (File.Exists(path + "\\help\\Help.chm"))
                System.Diagnostics.Process.Start(path + "\\help\\Help.chm");
            else MessageBox.Show("File not found", "Error");
        }
        //
        private void cmsStartWithWindows_Click(object sender, EventArgs e)
        {
            ShowAgent();
            CharacterEx.Speak("The application will start with your windows.", null, out dwReqID);
            try
            {
                if (cmsStartWithWindows.Checked == false)
                {
                    // Add the value in the registry so that the application runs at startup
                    rkApp.SetValue("iDict", Application.ExecutablePath.ToString());
                    cmsStartWithWindows.Checked = true;
                }
                else
                {
                    // Remove the value from the registry so that the application doesn't start
                    rkApp.DeleteValue("iDict", false);
                    cmsStartWithWindows.Checked = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to start with windows");
            }
            
        }
        //
        private void cmsExit_Click(object sender, EventArgs e)
        {
            ShowAgent();
            CharacterEx.Speak("You want to exit the application,don't you? So good bye and see you soon.", null, out dwReqID);
            Confirm cfm = new Confirm();
            cfm.ShowDialog();

        }
        //
        private void cmsAbout_Click(object sender, EventArgs e)
        {
            //
            ShowAgent();
            CharacterEx.Speak("This is the information about the dictionary.", null, out dwReqID);
            //
            About about = new About();
            about.ShowDialog();
            about.Top = 400;
            about.Left = 300;
        }
        //
        private void cmsMainDict_Click(object sender, EventArgs e)
        {
            //
            this.Show();
            this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height)/2;
            ShowAgent();
            CharacterEx.Speak("This is the main dictionary.", null, out dwReqID);
        }
        private void btnAdvancedSearch_Click(object sender, EventArgs e)
        {
            AdvancedSearch frm = new AdvancedSearch(cbbWord.Text, cbbKeypad.SelectedIndex);
            frm.ShowDialog();
            GC.Collect();
        }
        private void btnDictInfo_Click(object sender, EventArgs e)
        {
            
            //
            //ShowAgent();
            //CharacterEx.Speak("This is information about the dictionary that you're using.", null, out dwReqID);
            //
            InfoDict frm = new InfoDict();
            frm.ShowDialog();
        }
        private void btnManageDict_Click(object sender, EventArgs e)
        {
            //                       
            ManageDict frm = new ManageDict(cbbKeypad.SelectedIndex);
            frm.ShowDialog();
        }
        private void MainDict_Shown(object sender, EventArgs e)
        {
            if (establish[3] == '0') this.Hide();
            else if (establish[3] == '1') this.WindowState = FormWindowState.Minimized;
            else if (establish[3] == '3') this.WindowState = FormWindowState.Maximized;
            this.Opacity = 100;
        }
        private void cmsPronounce_Click(object sender, EventArgs e)
        {
            ShowAgent();
            CharacterEx.Speak("Hi, iam iDict, a multi language, multi function dictionary. Thanks for using this dictionary.", null, out dwReqID);
            
        }
        private void iDictNotify_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            this.Show();
            this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height)/2;
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width)/2;
            ShowAgent();
            CharacterEx.Speak("This is the main dictionary.", null, out dwReqID);
            CharacterEx.Prepare(10, "I'm ready", 2000, out dwReqID);

        }
        /*
        private void iDictNotify_MouseClick(object sender, MouseEventArgs e)
        {
            miniDict.Show();
            miniDict.Left = Screen.PrimaryScreen.WorkingArea.Width - miniDict.Width;
            miniDict.Top = 0;
        }
         * */
        private void cmsMiniDict_Click(object sender, EventArgs e)
        {
            
            miniDict.Show();
            miniDict.Left = Screen.PrimaryScreen.WorkingArea.Width - miniDict.Width;
            miniDict.Top = 0;
            ShowAgent();
            CharacterEx.Speak("This is the mini dictionary. You can lookup from clipboard.", null, out dwReqID);
            CharacterEx.Think("...", out dwReqID);
        }
        private void cmsTranslation_Click(object sender, EventArgs e)
        {
            Translation frm = new Translation(cbbKeypad.SelectedIndex);
            frm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ShowAgent();
            CharacterEx.Speak("You want to exit the application, don't you? So Bye bye.See you again.", null, out dwReqID);
            Confirm cfm = new Confirm();
            cfm.ShowDialog();
        }

        private void btnPronounce_Click(object sender, EventArgs e)
        {
            ShowAgent();          
            /*
             * AgentServer Srv = new AgentServer();
            if (Srv == null)
            {
                MessageBox.Show("ERROR: Agent Server couldn't be started!");

            }

            IAgentEx SrvEx;
            // The following cast does the QueryInterface to fetch IAgentEx interface from the IAgent interface, directly supported by the object
            SrvEx = (IAgentEx)Srv;

            // First try to load the default character
            int dwCharID = 0, dwReqID = 0;
            try
            {
                // null is used where VT_EMPTY variant is expected by the COM object
                String strAgentCharacterFile = null;
                if (!strFileName.Equals(string.Empty))
                    //Get the acs path
                    strAgentCharacterFile = strFileName;
                else
                {
                    MessageBox.Show("Select Style");
                    return;
                }

                if (cbbWord.Text.Equals(string.Empty))
                {
                    cbbWord.Text = "Please enter text in comboBox";
                }
                SrvEx.Load(strAgentCharacterFile, out dwCharID, out dwReqID);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load Agent character! Exception details:");
            }

            SrvEx.GetCharacterEx(dwCharID, out CharacterEx);
            */

            //CharacterEx.SetLanguageID(MAKELANGID(LANG_ENGLISH, SUBLANG_ENGLISH_US));

            // Show the character.  The first parameter tells Microsoft
            // Agent to show the character by playing an animation.

            // Make the character speak
            // Second parameter will be transferred to the COM object as NULL                                    
            
            try
            {
                
                voice.Speak(cbbWord.Text, SpeechVoiceSpeakFlags.SVSFNLPSpeakPunc);
                //voice.Speak(cbbWord.Text, SpeechVoiceSpeakFlags.SVSFDefault);
                
            }
            catch (ExecutionEngineException)
            {
                MessageBox.Show("Failed to speak the word");
            }
            CharacterEx.Speak(cbbWord.Text, null, out dwReqID);
            //CharacterEx.Wait(2000, out dwReqID);

            //CharacterEx.Listen(2000);
            
        }
        // Show Agent
        /// <summary>
        /// Show Agent
        /// </summary>
        private void ShowAgent()
        {
            AgentServer Srv = new AgentServer();
            
            if (Srv == null)
            {
                MessageBox.Show("ERROR: Agent Server couldn't be started!");

            }

            IAgentEx SrvEx;
            // The following cast does the QueryInterface to fetch IAgentEx interface from the IAgent interface, directly supported by the object
            SrvEx = (IAgentEx)Srv;

            // First try to load the default character
            int dwCharID = 0, dwReqID = 0;
            try
            {
                // null is used where VT_EMPTY variant is expected by the COM object
                String strAgentCharacterFile = null;
                if (!strFileName.Equals(string.Empty))
                    //Get the acs path
                    strAgentCharacterFile = strFileName;
                else
                {
                    MessageBox.Show("Select Style");
                    return;
                }

                if (cbbWord.Text.Equals(string.Empty))
                {
                    cbbWord.Text = "Please enter text in textbox";
                }

                //load the acs file
                SrvEx.Load(strAgentCharacterFile, out dwCharID, out dwReqID);

            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load Agent character! Exception details:");
            }

            SrvEx.GetCharacterEx(dwCharID, out CharacterEx);
            //show the agent
            CharacterEx.Show(0, out dwReqID);

        }
        /// <summary>
        /// Hide Agent
        /// </summary>
        private void HideAgent()
        {
            int dwReqID = 0;
            CharacterEx.Speak("I'm going for a while", null, out dwReqID);
            switch (strFileName.ToUpper())
            {
                case "\\GENIE.ACS":
                    CharacterEx.Hide(0, out dwReqID);
                    break;
                case "\\MERLIN.ACS":
                    CharacterEx.Hide(0, out dwReqID);
                    break;
                case "\\PEEDY.ACS":
                    CharacterEx.Hide(0, out dwReqID);
                    break;
                case "\\ROBBY.ACS":
                    CharacterEx.Hide(0, out dwReqID);
                    break;
                default:
                    break;
            }
        }

        
        //
        private void cbbVoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            voice.Voice = voice.GetVoices("", "").Item(cbbVoice.SelectedIndex);
            ShowAgent();
            //CharacterEx.Speak("You selected voice " + cbbVoice.Items[cbbWord.SelectedIndex].ToString(), null, out dwReqID);
        }

        private void btnTranslate_Click(object sender, EventArgs e)
        {
            
            cbbWord.Text = cbbWord.Items[cbbWord.SelectedIndex].ToString();
            MultiDict();
            //ShowAgent();
            //CharacterEx.Speak(cbbWord.Text, null, out dwReqID);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cbbWord.Text = "";
        }

        private void btnConfiguration_Click(object sender, EventArgs e)
        {
            
            //CharacterEx.Speak("This is Configuration form of the application", null, out dwReqID);
            Configuration pref = new Configuration();
            pref.ShowDialog();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            double opacity = this.trackBar1.Value;
            if (opacity != 0)
                opacity = opacity / 10;
            this.Opacity = opacity;
        }        
    }
}
class Comparison : IComparer
{
    CompareInfo ci = new CultureInfo("en-US").CompareInfo;
    int IComparer.Compare(Object x, Object y)
    {
        return ci.Compare((string)x, (string)y, CompareOptions.StringSort);
    }
}