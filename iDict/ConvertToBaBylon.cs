using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace iDict
{
    public partial class ConvertToBaBylon : Form
    {
        public ConvertToBaBylon()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            openFileDialog1.InitialDirectory = iDict.MainDict.path + "\\dictionary";
        }
        
        void ConvertData()
        {
            Stream st1 = File.Open(openFileDialog1.FileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamWriter st2 = new StreamWriter(openFileDialog1.FileName.Substring(0, openFileDialog1.FileName.Length - 3) + "gls");
            Encoding convert = Encoding.UTF8;
            byte[] b = new byte[4], bs;
            int seek, listPosition;
            int length, TotalWords;
            string word, meaning;

            st1.Read(b, 0, 4);           // đọc 4 byte đầu để lấy vị trí danh sách và tính tổng số từ
            listPosition = BitConverter.ToInt32(b, 0);
            TotalWords = (int)((st1.Length - listPosition) / 4);
            st1.Seek(2, SeekOrigin.Current);
            st1.Read(b, 0, 2);  // đọc 2 byte độ dài từ điển
            length = BitConverter.ToUInt16(b, 0);
            bs = new byte[length];
            st1.Read(bs, 0, length);
            word = convert.GetString(bs);
            string[] dln = word.Split('\0');
            //
            //Đoạn này ghi phần đầu của file babylon gls
            //
            word = "### Glossary title:" + dln[3] + "\r\n";
            word += @"### Author:
### Description:";
            word += dln[4]+"\r\n";
            word += @"### Source language:English
### Source alphabet:Default
### Target language:English
### Target alphabet:Default
### Icon:
### Icon2:
### Browsing enabled?Yes
### Type of glossary:00008000
### Case sensitive words?0
; DO NOT EDIT THE NEXT **SIX** LINES  - Babylon-Builder generated text !!!!!!
### Glossary id:0293635a6282896c866e9c869d8a89447c6e7c9d868685869d68955b9578689c7681869b826f683f85918894719d7198757589447c6e799c788b705f5f5650a040272ca09a566059
### Confirmation string:B4213IAS
### File build number:0131B34F
### Build:
### Glossary settings:00000000
### Gls type:00000001
; DO NOT EDIT THE PREVIOUS **SIX** LINES  - Babylon-Builder generated text !!!!!!
### Part of speech table:
### Private label id:
### Min version:0
### Regular expression:

### Glossary section:

";
            st2.Write(word);
            byte[] positionList = new byte[TotalWords * 4];
            st1.Seek(listPosition, SeekOrigin.Begin);
            st1.Read(positionList, 0, positionList.Length);
            progressBar1.Value = 0;
            progressBar1.Maximum = TotalWords;
            label1.Text = "Tiến trình";
            for (int i = 0; i < TotalWords; i++)
            {
                seek = BitConverter.ToInt32(positionList, 4 * i);
                st1.Seek(seek, SeekOrigin.Begin);
                //
                //Đọc từ
                //
                st1.Read(b, 0, 2);
                length = BitConverter.ToUInt16(b, 0);
                bs = new byte[length];
                st1.Read(bs, 0, length);
                word = convert.GetString(bs);
                //
                //Đọc nghĩa
                //
                st1.Read(b, 0, 4);
                length = BitConverter.ToInt32(b, 0);
                bs = new byte[length];
                st1.Read(bs, 0, length);
                meaning = convert.GetString(bs);
                word = word + "\r\n" + ToHtml(meaning).Replace("\n", "") +"\r\n\r\n";
                st2.Write(word);
                progressBar1.Value++;
            }
            st1.Flush();
            st1.Close();
            st2.Flush();
            st2.Close();
            label1.Text = "Complete";
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }
        public string ToHtml(string s)
        {
            if (s.Length == 0) return "";
            char character = s[0];
            StringBuilder value = new StringBuilder(10000);
            for (int i = 0; i < s.Length; i++)
            {
                if (i == 0 || s[i - 1] == '\n')
                {
                    if (i != 0)
                    {
                        switch (character)
                        {
                            case '@':
                                value.Append("</font></b><br>");
                                break;
                            case '#':
                                value.Append("</b><br>");
                                break;
                            case '*':
                                value.Append("</div></font></b>");
                                break;
                            case '-':
                                value.Append("</div>");
                                break;
                            case '=':
                                value.Append("</div></font>");
                                break;
                            case '+':
                                value.Append("</div></font>");
                                break;
                            case '!':
                                value.Append("</b></div></font>");
                                break;
                            case '~':
                                value.Append("\"></center>");
                                break;
                            default:
                                value.Append("<br>");
                                break;
                        }
                    }
                    switch (s[i])
                    {
                        case '@':
                            value.Append("<font color = red><b>@");
                            break;
                        case '#':
                            value.Append("<b>#");
                            break;
                        case '*':
                            value.Append("<div style=\"margin-left: 20px;\"><font color =blue><b>*");
                            break;
                        case '-':
                            value.Append("<div style=\"margin-left: 40px;\">-");
                            break;
                        case '=':
                            value.Append("<div style=\"margin-left: 60px;\"><font color = green>=");
                            break;
                        case '+':
                            value.Append("<div style=\"margin-left: 60px;\"><font color =gray>+");
                            break;
                        case '!':
                            value.Append("<div style=\"margin-left: 20px;\"><font color = brown><b>!");
                            break;
                        case '~':
                            value.Append("<center><img src = \"");
                            value.Append(Application.StartupPath + "\\Images");
                            value.Append("\\");
                            break;
                        default:
                            value.Append(s[i].ToString());
                            break;
                    }
                    character = s[i];
                }
                else value.Append(s[i].ToString());
            }
            switch (character)
            {
                case '@':
                    value.Append("</font></b><br>");
                    break;
                case '#':
                    value.Append("</b><br>");
                    break;
                case '*':
                    value.Append("</div></font></b>");
                    break;
                case '-':
                    value.Append("</div>");
                    break;
                case '=':
                    value.Append("</div></font>");
                    break;
                case '+':
                    value.Append("</div></font>");
                    break;
                case '!':
                    value.Append("</b></div></font>");
                    break;
                case '~':
                    value.Append("\"></center>");
                    break;
                default:
                    value.Append("<br>");
                    break;
            }
            return value.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {               
            if (openFileDialog1.FileName == "")
                MessageBox.Show("Select a database file to convert to babylon database, please.");
            else
            {
                Thread t = new Thread(ConvertData);
                t.Start();
            }
        }
    }
}