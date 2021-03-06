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
    public partial class InfoDict : Form
    {
        public static int result=-1;
        //int i;
        Stream st1;
        Stream st2;
        BufferedStream buff2;
        Encoding convert = Encoding.UTF8;
        Thread t;
        byte[] b = new byte[4], bs;
        int seek, listPosition;
        int length, totalWords, percent;
        string s, tmp;
        public InfoDict()
        {
            InitializeComponent();
            txbCultureInfo.Text = MainDict.Dicts[MainDict.selected].dln[0];
            cbbVoice.Text = MainDict.Dicts[MainDict.selected].dln[1] + "-" + MainDict.Dicts[MainDict.selected].dln[2];
            txbFileName.Text = MainDict.Dicts[MainDict.selected].fileName;
            txbDictName.Text = MainDict.Dicts[MainDict.selected].dln[3];
            txbAuthor.Text = MainDict.Dicts[MainDict.selected].dln[4].Replace("\n", "\r\n");
            txbCoincidentData.Text = MainDict.Dicts[MainDict.selected].coincidentData.ToString();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnCorrect_Click(object sender, EventArgs e)
        {
            if ((txbFileName.Text = txbFileName.Text.Trim()) == "")
                MessageBox.Show("Write dictionary file name, please.", "Announcement");
            else if (txbCultureInfo.Text == "")
                MessageBox.Show("Write CultureInfo, please", "Announcement");
            else if (txbDictName.Text.Trim() == "")
                MessageBox.Show("Write dictionary name, please.", "Announcement");
            else if ((cbbVoice.Text == "") || (cbbVoice.Text.Length < 2) || cbbVoice.Text.IndexOf('-') == -1)
                MessageBox.Show("Write dictionary pronounce voice, please.", "Announcement");
            else
            {
                t = new Thread(ConvertData);
                t.Start();
            }
        }
        void ConvertData()
        {
            st1 = File.Open(MainDict.path + "\\Dictionary\\" + MainDict.Dicts[MainDict.selected].fileName + ".idt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            st2 = File.Create(MainDict.path + "\\Dictionary\\" + MainDict.Dicts[MainDict.selected].fileName + ".tmp");
            buff2 = new BufferedStream(st2, 10000);
            convert = Encoding.UTF8;
            buff2.Write(b, 0, 4);        // ghi tạm 4 byte, tí nữa sẽ gi lại vị trí ds mới
            buff2.WriteByte(0);      // ghi 2 byte giá trị 0 , để xác định lại là không có dữ liệu thừa
            buff2.WriteByte(0);
            st1.Read(b, 0, 4);           // đọc 4 byte đầu để lấy vị trí danh sách và tính tổng số từ
            listPosition = BitConverter.ToInt32(b, 0);
            st1.Seek(6, SeekOrigin.Begin);
            st1.Read(b, 0, 2);         // đọc độ dài tác giả 
            length = BitConverter.ToUInt16(b, 0);
            st1.Seek(length, SeekOrigin.Current);//nhảy qua
            //ghi phần tác giả mới
            if (cbbVoice.Text.Length > 2) tmp = cbbVoice.Text[0] + "\0" + cbbVoice.Text.Substring(2);
            else tmp = "\0";
            s = txbCultureInfo.Text + "\0" + tmp + "\0" + txbDictName.Text.Trim() + "\0"
                + txbAuthor.Text.Replace("\r", "");
            bs = convert.GetBytes(s);
            b = BitConverter.GetBytes((ushort)bs.Length);
            buff2.Write(b, 0, 2);
            buff2.Write(bs, 0, bs.Length);
            totalWords = (int)((st1.Length - listPosition) / 4);
            byte[] positionList = new byte[totalWords * 4], newPositionList = new byte[totalWords * 4];
            st1.Seek(listPosition, SeekOrigin.Begin);      // đọc vị trí từ cũ
            st1.Read(positionList, 0, positionList.Length);
            for (int i = 0; i < totalWords; i++)
            {
                b = BitConverter.GetBytes((int)buff2.Position);
                newPositionList[i * 4] = b[0];  // ghi vị trí từ mới
                newPositionList[i * 4 + 1] = b[1];
                newPositionList[i * 4 + 2] = b[2];
                newPositionList[i * 4 + 3] = b[3];
                seek = BitConverter.ToInt32(positionList, 4 * i);
                st1.Seek(seek, SeekOrigin.Begin);
                //
                //Đọc từ
                //
                st1.Read(b, 0, 2);
                length = BitConverter.ToUInt16(b, 0);
                bs = new byte[length];
                st1.Read(bs, 0, length);
                buff2.Write(b, 0, 2);   //ghi phần từ
                buff2.Write(bs, 0, length);
                //
                //Đọc nghĩa
                //
                st1.Read(b, 0, 4);
                length = BitConverter.ToInt32(b, 0);
                bs = new byte[length];
                st1.Read(bs, 0, length);
                buff2.Write(b, 0, 4);   //ghi phần nghĩa
                buff2.Write(bs, 0, length);
                percent = (int)((i + 1) * 100 / totalWords);
                if ((i + 1) * 100 / totalWords != progressBar1.Value)
                    progressBar1.Value = (i + 1) * 100 / totalWords;
            }
            st1.Flush();
            st1.Close();
            buff2.Seek(0, SeekOrigin.Begin);//ghi vị trí bắt đầu danh sách
            buff2.Write(BitConverter.GetBytes((int)buff2.Length), 0, 4);
            buff2.Seek(0, SeekOrigin.End);
            buff2.Write(newPositionList, 0, positionList.Length);
            buff2.Flush();
            buff2.Close();
            MainDict.Dicts[MainDict.selected].tatKetNoi();
            File.Delete(MainDict.path + "\\Dictionary\\" + MainDict.Dicts[MainDict.selected].fileName + ".idt");
            File.Move(MainDict.path + "\\Dictionary\\" + MainDict.Dicts[MainDict.selected].fileName + ".tmp", MainDict.path + "\\Dictionary\\" + MainDict.Dicts[MainDict.selected].fileName + ".idt");
            MainDict.Dicts[MainDict.selected] = new Dict(MainDict.path + "\\Dictionary\\" + MainDict.Dicts[MainDict.selected].fileName + ".idt");
            progressBar1.Value = 0;
            txbCoincidentData.Text = "0";
            result = 0;
        }
    }
}