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
    public partial class ConvertToPlainText : Form
    {
        public ConvertToPlainText()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            openFileDialog1.InitialDirectory = iDict.MainDict.path + "\\dictionary";
        }
        private void btnCheckWord2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.FileName == "")
                MessageBox.Show("Select a database file to convert to plain text databse, please");
            else
            {
                Thread t = new Thread(ConvertData);
                t.Start();
            }
        }
        private void ConvertData()
        {
            Stream st1 = File.Open(openFileDialog1.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamWriter st2 = new StreamWriter(openFileDialog1.FileName.Substring(0, openFileDialog1.FileName.Length - 3) + "txt");
            Encoding convert = Encoding.UTF8;
            byte[] b = new byte[4], bs;
            int seek,listPosition;
            int length,  TotalWords;
            string word, meaning;
            // đọc 4 byte đầu để lấy vị trí danh sách và tính tổng số từ
            st1.Read(b, 0, 4);           
            listPosition = BitConverter.ToInt32(b, 0);
            TotalWords = (int)((st1.Length - listPosition) / 4);
            byte[] positionList = new byte[TotalWords*4];
            st1.Seek(listPosition,SeekOrigin.Begin);
            st1.Read(positionList, 0, positionList.Length );
            progressBar2.Value = 0;
            progressBar2.Maximum = TotalWords;
            lblProcess.Text = "Tiến trình";
            for(int i=0;i<TotalWords;i++)
            {
                seek=BitConverter.ToInt32(positionList,4*i);
                st1.Seek(seek,SeekOrigin.Begin);
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
                word = word + '\t' + meaning;
                word = word.Replace("\\", "\\\\");
                word = word.Replace("\n", "\\n");
                st2.WriteLine(word);
                progressBar2.Value++;
            }
            st1.Flush();
            st1.Close();
            st2.Flush();
            st2.Close();
            lblProcess.Text = "Complete";
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}