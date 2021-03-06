using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace iDict
{
    public partial class CheckWord : Form
    {
        public CheckWord()
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
                MessageBox.Show("Select a database file to check, please.");
            else
            {
                Thread t = new Thread(ConvertData);
                t.Start();
            }
        }
        void ConvertData()
        {
            Stream st1 = File.Open(openFileDialog1.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            Encoding convert = Encoding.UTF8;
            byte[] b = new byte[4], bs;
            int seek, listPosition;
            int length, TotalWords;
            string word1, word2;
            StringBuilder trungLap = new StringBuilder(10000);
            st1.Read(b, 0, 4);           // đọc 4 byte đầu để lấy vị trí danh sách và tính tổng số từ
            listPosition = BitConverter.ToInt32(b, 0);
            TotalWords = (int)((st1.Length - listPosition) / 4);
            byte[] positionList = new byte[TotalWords * 4];
            st1.Seek(listPosition, SeekOrigin.Begin);
            st1.Read(positionList, 0, positionList.Length);
            progressBar1.Value = 0;
            progressBar1.Maximum = TotalWords;
            // đọc từ đầu tiên
            seek = BitConverter.ToInt32(positionList, 4 * 0);
            st1.Seek(seek, SeekOrigin.Begin);
            st1.Read(b, 0, 2);
            length = BitConverter.ToUInt16(b, 0);
            bs = new byte[length];
            st1.Read(bs, 0, length);
            word1 = convert.GetString(bs).Trim();
            for (int i = 1; i < TotalWords; i++)
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
                word2 = convert.GetString(bs).Trim();
                if (word1 == word2)
                    trungLap.Append(word1+"\r\n");
                word1 = word2;
                progressBar1.Value++;
            }
            st1.Flush();
            st1.Close();
            word1=trungLap.ToString();
            if (word1 == "")
            {
                Error frm = new Error("Không có từ trùng lặp");
                frm.ShowDialog();
            }
            else
            {
                Error frm = new Error("Danh sách các từ trùng:\r\n\r\n" + word1);
                frm.ShowDialog();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }      
    }
}