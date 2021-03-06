using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using System.Globalization;
using System.IO;
using System.Diagnostics;
using SpeechLib;
namespace iDict
{
    public partial class ConvertToIDT : Form
    {
        string s, word, meaning;
        CompareInfo ci;
        IComparer ss;
        StreamReader str;
        Encoding convert = Encoding.UTF8;
        int i, j = 0, tmp, TotalWords = 0;
        Stream st;
        BufferedStream buff;
        StringBuilder build = new StringBuilder(10000);
        string[] key;
        int[] val;
        byte[] b = new byte[4], bs;
        SpVoice voice1 = new SpVoice();
        class Comparison : IComparer
        {
            CompareInfo ci;
            public Comparison(CompareInfo a)
            {
                ci = a;
            }
            int IComparer.Compare(Object x, Object y)
            {
                return ci.Compare((string)x, (string)y, CompareOptions.StringSort);
            }
        }
        public ConvertToIDT()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            openFileDialog1.InitialDirectory = iDict.MainDict.path + "\\dictionary";
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }
        private void btnCheckWord_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.FileName == "")
                MessageBox.Show("Select a dictionary file, please.", "Announcement");
            else if (cbbCultureInfo.Text == "")
                MessageBox.Show("Write Culture Info, please.", "Announcement");
            else if (txbDictName.Text.Trim() == "")
                MessageBox.Show("Write dictionary name, please", "Announcement");
            else
            {
                Thread t = new Thread(ConvertData);
                t.Start();
            }
        }
        private void ConvertData()
        {
            ci = new CultureInfo(cbbCultureInfo.Text).CompareInfo;
            ss = new Comparison(ci);
            str = new StreamReader(openFileDialog1.FileName);
            //
            //Kiểm tra và đếm số từ
            //
            s = str.ReadToEnd();
            str.Close();
            word = "";
            TotalWords = 0;
            //nếu phần từ hoặc phần nghĩa không có nội dung tức liền trước và liền sau \t là ký tự hết dòng hoặc không có tab thì Error
            for (i = 0; i < s.Length; i++)
            {
                if (s[i] == '\t')
                {
                    j = 1;
                    if (i == 0 || s[i - 1] == '\n') // nếu trước tab không phải là đầu file hoặc đầu dòng
                        //đánh dấu là có tab trong 1 dòng để phân cách từ
                        build.Append("Error phần từ không có nội dung ở dòng thứ : " + (TotalWords + 1).ToString() + "\r\n");
                }
                else if (s[i] == '\r')
                {
                    if (i == 0 || s[i - 1] == '\t') // trước /r là đầu file hoặc tab
                        build.Append("Error phần nghĩa không có nội dung ở dòng thứ : " + (TotalWords + 1).ToString() + "\r\n");
                }
                else if (s[i] == '\n')
                {
                    if (j == 1) //trong 1 dòng phải có tab
                        j = 0;
                    else
                        build.Append("Error không có phân cách tab ở dòng thứ : " + (TotalWords + 1).ToString() + "\r\n");
                    TotalWords++;
                }
            }
            //khởi tạo file idt
            if (build.Length != 0)
            {
                Error frm = new Error(build.ToString());
                frm.ShowDialog();
                build.Remove(0, build.Length);
                return;
            }
            //
            //bắt đầu tạo file từ điển idt
            //
            st = File.Open(openFileDialog1.FileName.Substring(0, openFileDialog1.FileName.Length - 3) + "idt", FileMode.Create);
            buff = new BufferedStream(st);
            progressBar1.Value = 10;
            key = new string[TotalWords];
            val = new int[TotalWords];
            buff.Write(b, 0, 4);//vị trí của danh sách
            buff.WriteByte(0);//số lần phát sinh dữ liệu thừa
            buff.WriteByte(0);
            //
            //Ghi thông tin từ điển
            //
            if (cbbVoice.Text.Length > 2) meaning = cbbVoice.Text[0] + "\0" + cbbVoice.Text.Substring(2);
            else meaning = "\0";
            word = cbbCultureInfo.Text + "\0" + meaning + "\0" + txbDictName.Text.Trim() + "\0"
                + txbAuthor.Text.Replace("\r", "");
            bs = convert.GetBytes(word);
            b = BitConverter.GetBytes((ushort)bs.Length);
            buff.Write(b, 0, 2);//2byte ghi độ dài
            buff.Write(bs, 0, bs.Length);
            lblProcess.Text = "Storing data";
            //
            //Bắt đầu ghi file
            //
            j = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '\\')
                {
                    if (s[i + 1] == '\\')
                    {
                        build.Append('\\');
                        i++;
                    }
                    else if (s[i + 1] == 'n')
                    {
                        build.Append('\n');
                        i++;
                    }
                }
                else if (s[i] == '\n')
                {
                    val[j] = (int)buff.Position;//ghi vị trí của từ và nghĩa
                    word = build.ToString();
                    build.Remove(0, build.Length); //xoá build để ghi string mới
                    tmp = word.IndexOf('\t');
                    meaning = word.Substring(tmp + 1);
                    word = word.Substring(0, tmp);
                    key[j] = word;// ghi từ vào key
                    //
                    //ghi nội dung từ
                    //
                    bs = convert.GetBytes(word);
                    b = BitConverter.GetBytes(bs.Length);
                    buff.Write(b, 0, 2);//2byte ghi độ dài
                    buff.Write(bs, 0, bs.Length);
                    //
                    //ghi nội dung nghĩa
                    //
                    bs = convert.GetBytes(meaning);
                    b = BitConverter.GetBytes(bs.Length);
                    buff.Write(b, 0, 4);//4 byte ghi độ dài
                    buff.Write(bs, 0, bs.Length);
                    progressBar1.Value = (j * 70) / TotalWords + 10;
                    j++;
                }
                else if (s[i] != '\r') build.Append(s[i]);
            }

            //
            //ghi phần nội dung
            //
            //
            //Soft và ghi danh sách
            //
            lblProcess.Text = "Processing";
            buff.Seek(0, SeekOrigin.Begin);//ghi vị trí bắt đầu danh sách
            buff.Write(BitConverter.GetBytes((int)buff.Length), 0, 4);
            buff.Seek(0, SeekOrigin.End);
            Array.Sort(key, val, ss);
            for (i = 0; i < TotalWords; i++)
            {
                buff.Write(BitConverter.GetBytes(val[i]), 0, 4);
            }
            buff.Flush();
            buff.Close();
            progressBar1.Value = 100;
            lblProcess.Text = "Complete";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbbVoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            voice1.Voice = voice1.GetVoices("", "").Item(cbbVoice.SelectedIndex);
            
        }

    }
}