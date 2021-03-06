using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Net.SourceForge.Vietpad.InputMethod;
using SpeechLib;
namespace iDict
{
    public partial class ManageDict : Form
    {
        int typing;
        SpVoice voice = new SpVoice();
        public ManageDict(int keypad)
        {
            InitializeComponent();
            typing = keypad;
            TextBoxBase textComp = new TextBox();
            VietKeyHandler keyHandler = new VietKeyHandler(textComp);
            
            textComp.KeyPress += new KeyPressEventHandler(keyHandler.OnKeyPress);
            if (keypad == 0)
                VietKeyHandler.VietModeEnabled = false;
            else if (keypad == 1)
            {
                VietKeyHandler.VietModeEnabled = true;
                VietKeyHandler.InputMethod = InputMethods.VNI;
            }
            else if (keypad == 2)
            {
                VietKeyHandler.VietModeEnabled = true;
                VietKeyHandler.InputMethod = InputMethods.Telex;
            }
            else if (keypad == 3)
            {
                VietKeyHandler.VietModeEnabled = true;
                VietKeyHandler.InputMethod = InputMethods.VIQR;
            }
            VietKeyHandler.SmartMark = true;
            txbDictName.KeyPress += new KeyPressEventHandler(new VietKeyHandler(txbDictName).OnKeyPress);
            txbAuthor.KeyPress += new KeyPressEventHandler(new VietKeyHandler(txbAuthor).OnKeyPress);
            // Them giong phat am vao combobox
            foreach (ISpeechObjectToken t in voice.GetVoices("", ""))
            {
                cbbVoice.Items.Add(t.GetAttribute("Name"));
            }
            
            int i;
            string[] s1;
            //load từ điển đang dùng và từ điển không dùng
            if (MainDict.Dicts == null) //khi không có từ điển nào
                s1 = new string[0];
            else s1 = new string[MainDict.Dicts.Length];
            for (i = 0; i < s1.Length; i++)
                s1[i] = MainDict.Dicts[i].fileName;
            listBox1.Items.AddRange(s1);
            string[] s2 = Directory.GetFiles(MainDict.path + "\\Dictionary\\", "*.idt", SearchOption.TopDirectoryOnly);
            for (i = 0; i < s2.Length; i++)
            {
                s2[i] = Path.GetFileNameWithoutExtension(s2[i]);
                if (Array.IndexOf(s1, s2[i]) == -1)
                    listBox2.Items.Add(s2[i]);
            }
            // Kiểm tra các tuỳ chọn tra cứu
            if (MainDict.establish[1] == '1')
                chbChangeKeypad.Checked = true;
            else chbChangeKeypad.Checked = false;
            if (MainDict.establish[2] == '1')
                chbMoveDict.Checked = true;
            else chbMoveDict.Checked = false;
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if ((txbFileName.Text = txbFileName.Text.Trim()) == "")
                MessageBox.Show("Write dictionary file name, please", "Announcement");
            else if (cbbCultureInfo.Text == "")
                MessageBox.Show("Write CultureInfo, please", "Announcement");
            else if (txbDictName.Text == "")
                MessageBox.Show("Write dictionary name, please.", "Announcement");
            else if (File.Exists(iDict.MainDict.path + "\\Dictionary\\" + txbFileName.Text + ".idt") == true)
                MessageBox.Show("This dictionary existed.", "Announcement");
            else if ((cbbVoice.Text == "") || (cbbVoice.Text.Length < 2) || cbbVoice.Text.IndexOf('-') == -1)
                MessageBox.Show("Write dictionary pronounce voice, please.", "Announcement");
            else
            {
                Encoding convert = Encoding.UTF8;
                Stream st = File.Create(iDict.MainDict.path + "\\Dictionary\\" + txbFileName.Text + ".idt");
                byte[] b = new byte[4], bs;
                string word, meaning;
                st.Write(b, 0, 4);
                st.Write(b, 0, 2);
                if (cbbVoice.Text.Length > 2) meaning = cbbVoice.Text[0] + "\0" + cbbVoice.Text.Substring(2);
                else meaning = "\0";
                word = cbbCultureInfo.Text + "\0" + meaning + "\0" + txbDictName.Text.Trim() + "\0"
                    + txbAuthor.Text.Replace("\r", "");
                bs = convert.GetBytes(word);
                b = BitConverter.GetBytes((ushort)bs.Length);
                st.Write(b, 0, 2);//2byte ghi độ dài
                st.Write(bs, 0, bs.Length);
                st.Seek(0, SeekOrigin.Begin);//ghi vị trí bắt đầu danh sách
                st.Write(BitConverter.GetBytes((int)st.Length), 0, 4);
                listBox2.Items.Add(txbFileName.Text);
                tabCreateNewDict.SelectedIndex = 0;
                listBox2.SelectedItem = txbFileName.Text;
                listBox1.SelectedIndex = -1;
            }
        }
        private void btnMoveRight_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                listBox2.Items.Add(listBox1.SelectedItem);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }
        private void btnMoveLeft_Click(object sender, EventArgs e)
        {
            if ((listBox2.SelectedIndex != -1) && (listBox1.Items.Count < 10))
            {
                listBox1.Items.Add(listBox2.SelectedItem);
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
            }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            /* Thiết lập từ điển Dòng đầu gồm 4 số
            Bộ gõ lưu bằng số :0 1 2 3
            Có tự tắt bật bộ gõ không : 0 1
            có chuyển đổi từ điển khi tra nhiều hay không: 0 1
            form ẩn hay hiện khi khởi động : 0 1
            Dòng 2 trở đi là tên các từ điển sẽ dùng*/
            if (listBox1.Items.Count == 0)
                MessageBox.Show("Must use at least a dictionary. ", "Announcement");
            else
            {
                StreamWriter stw = new StreamWriter(MainDict.path + "\\stored.dat");
                MainDict.establish = MainDict.establish[0].ToString();
                if (chbChangeKeypad.Checked == true) MainDict.establish += '1';
                else MainDict.establish += '0';
                if (chbMoveDict.Checked == true) MainDict.establish += '1';
                else MainDict.establish += '0';
                MainDict.establish += '0';
                
                stw.Write(MainDict.establish);
                for (int i = 0; i < listBox1.Items.Count; i++)  
                    //ghi các từ điển dùng
                    stw.Write("\r\n" + listBox1.Items[i].ToString());
                stw.Flush();
                stw.Close();
                Application.Restart();
            }
        }    

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOpenDictFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(MainDict.path + "\\dictionary\\");
            Confirm cfm = new Confirm();
            cfm.ShowDialog();
        }

        private void cbbVoice_SelectedIndexChanged(object sender, EventArgs e)
        {
           voice.Voice = voice.GetVoices("", "").Item(cbbVoice.SelectedIndex);
        }  
    }
}