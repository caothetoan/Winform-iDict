using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Text.RegularExpressions;
using Net.SourceForge.Vietpad.InputMethod;

namespace iDict
{
    public partial class AdvancedSearch : Form
    {
        AdvacedSearch d = new AdvacedSearch(MainDict.Dicts[MainDict.selected].DuLieuSearch());
        Thread t;
        bool turnOff = false;
        StringBuilder build = new StringBuilder();
        int i, j;
        string meaning, tmp;
        public AdvancedSearch(string s, int Keypad)
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            txtPattern.Text = s;
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
            txtPattern.KeyPress += new KeyPressEventHandler(new VietKeyHandler(txtPattern).OnKeyPress);
        }
        private void AdvancedSearch_Load(object sender, EventArgs e)
        {
            label1.Text = MainDict.Dicts[MainDict.selected].dln[3];
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtPattern.Text.Trim() == "")
            {
                MessageBox.Show("You haven't put word in", "Announcement");
            }
            else
            {
                turnOff = false;
                btnSearch.Enabled = false;
                btnStop.Enabled = true;
                if (rdbSimilarWord.Checked == true)
                    t = new Thread(wild7);
                else if (rdbWildcard.Checked == true)
                {
                    if (rdbWord.Checked == true)
                        t = new Thread(wild1);
                    else if (rdbMeaning.Checked == true)
                        t = new Thread(wild2);
                    else if (rdbSearchAll.Checked == true)
                        t = new Thread(wild3);
                }
                else
                {
                    if (rdbWord.Checked == true)
                        t = new Thread(wild4);
                    else if (rdbMeaning.Checked == true)
                        t = new Thread(wild5);
                    else if (rdbSearchAll.Checked == true)
                        t = new Thread(wild6);
                }
                t.Start();
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            turnOff = true;
            btnStop.Enabled = false;
            btnSearch.Enabled = true;
        }
        void wild1()
        {
            txbResult.Text = "";
            d.ComeBack(); //khôi phục vị trí đầu danh sách data
            string word = "";
            int percent = 0, count = 0, total;
            string pattern = txtPattern.Text; //dùng xâu pattern thay cho txtPattern.Text giúp tăng tốc độ lên 4 lần
            DateTime a = DateTime.Now;
            total = MainDict.Dicts[MainDict.selected].totalWords + MainDict.Dicts[MainDict.selected].coincidentData;
            for (int i = 0; i < total; i++)
            {
                d.ReadNextWord(ref word);
                if (LikeOperator.LikeString(word, pattern, CompareMethod.Text))
                {
                    txbResult.AppendText(word + "\r\n");
                    count++;
                    if (count >= 100)
                    {
                        txbResult.AppendText("Over 100 results, the application stopped searching");
                        turnOff = true;
                        btnStop.Enabled = false;
                        btnSearch.Enabled = true;
                        return;
                    }
                }
                percent = (int)((float)i / (MainDict.Dicts[MainDict.selected].totalWords - 1) * 100);
                if (percent != progressBar1.Value)
                {
                    progressBar1.Value = percent;

                }
                if (turnOff == true)
                {
                    progressBar1.Value = 0;
                    return;
                }
            }
            DateTime b = DateTime.Now;
            TimeSpan c = b.Subtract(a);
            txbResult.AppendText("Total searched time : " + c.TotalSeconds.ToString() + " second");
            turnOff = true;
            btnStop.Enabled = false;
            btnSearch.Enabled = true;
        }
        void wild2()
        {
            txbResult.Text = "";
            d.ComeBack(); //khôi phục vị trí đầu danh sách data
            string word = "", meaning = "";
            int percent = 0, count = 0, total;
            string pattern = txtPattern.Text;
            DateTime a = DateTime.Now;
            total = MainDict.Dicts[MainDict.selected].totalWords + MainDict.Dicts[MainDict.selected].coincidentData;
            for (int i = 0; i < total; i++)
            {
                d.ReadNext(ref word, ref meaning);
                if (LikeOperator.LikeString(meaning, pattern, CompareMethod.Text))
                {
                    if (meaning.Length >= 50)
                        txbResult.AppendText(word + "   :   " + meaning.Substring(0, 50) + ".............\r\n");
                    else txbResult.AppendText(word + "   :   " + meaning + "\r\n");
                    count++;
                    if (count >= 100)
                    {
                        txbResult.AppendText("Over 100 results, the application stopped searching");
                        turnOff = true;
                        btnStop.Enabled = false;
                        btnSearch.Enabled = true;
                        return;
                    }
                }
                percent = (int)((float)i / (MainDict.Dicts[MainDict.selected].totalWords - 1) * 100);
                if (percent != progressBar1.Value)
                {
                    progressBar1.Value = percent;

                }
                if (turnOff == true)
                {
                    progressBar1.Value = 0;
                    return;
                }
            }
            DateTime b = DateTime.Now;
            TimeSpan c = b.Subtract(a);
            txbResult.AppendText("Total searched time: " + c.TotalSeconds.ToString() + " second");
            turnOff = true;
            btnStop.Enabled = false;
            btnSearch.Enabled = true;
        }
        void wild3()
        {
            txbResult.Text = "";
            d.ComeBack(); //khôi phục vị trí đầu danh sách data
            string word = "", meaning = "";
            int percent = 0, count = 0, total;
            string pattern = txtPattern.Text;
            DateTime a = DateTime.Now;
            total = MainDict.Dicts[MainDict.selected].totalWords + MainDict.Dicts[MainDict.selected].coincidentData;
            for (int i = 0; i < total; i++)
            {
                d.ReadNext(ref word, ref meaning);
                if (LikeOperator.LikeString(word, pattern, CompareMethod.Text))
                {
                    txbResult.AppendText(word + "\r\n");
                    count++;
                    if (count >= 100)
                    {
                        txbResult.AppendText("Over 100 results, the application stopped searching");
                        turnOff = true;
                        btnStop.Enabled = false;
                        btnSearch.Enabled = true;
                        return;
                    }
                }
                if (LikeOperator.LikeString(meaning, pattern, CompareMethod.Text))
                {
                    if (meaning.Length >= 50)
                        txbResult.AppendText(word + "   :   " + meaning.Substring(0, 50) + ".............\r\n");
                    else txbResult.AppendText(word + "   :   " + meaning + "\r\n");
                    count++;
                    if (count >= 100)
                    {
                        txbResult.AppendText("Over 100 results, the application stopped searching");
                        turnOff = true;
                        btnStop.Enabled = false;
                        btnSearch.Enabled = true;
                        return;
                    }
                }
                percent = (int)((float)i / (MainDict.Dicts[MainDict.selected].totalWords - 1) * 100);
                if (percent != progressBar1.Value)
                {
                    progressBar1.Value = percent;

                }
                if (turnOff == true)
                {
                    progressBar1.Value = 0;
                    return;
                }
            }
            DateTime b = DateTime.Now;
            TimeSpan c = b.Subtract(a);
            txbResult.AppendText("Total searched time: " + c.TotalSeconds.ToString() + " s");
            turnOff = true;
            btnStop.Enabled = false;
            btnSearch.Enabled = true;
        }
        void wild4()
        {
            try
            {
                txbResult.Text = "";
                d.ComeBack(); //khôi phục vị trí đầu danh sách data
                string word = "";
                int percent = 0, count = 0, total;
                Regex regular = new Regex(txtPattern.Text, RegexOptions.IgnoreCase);
                DateTime a = DateTime.Now;
                total = MainDict.Dicts[MainDict.selected].totalWords + MainDict.Dicts[MainDict.selected].coincidentData;
                for (int i = 0; i < total; i++)
                {
                    d.ReadNextWord(ref word);
                    if (regular.IsMatch(word))
                    {
                        txbResult.AppendText(word + "\r\n");
                        count++;
                        if (count >= 100)
                        {
                            txbResult.AppendText("Over 100 results, the application stopped searching");
                            turnOff = true;
                            btnStop.Enabled = false;
                            btnSearch.Enabled = true;
                            return;
                        }
                    }
                    percent = (int)((float)i / (MainDict.Dicts[MainDict.selected].totalWords - 1) * 100);
                    if (percent != progressBar1.Value)
                    {
                        progressBar1.Value = percent;

                    }
                    if (turnOff == true)
                    {
                        progressBar1.Value = 0;
                        return;
                    }
                }
                DateTime b = DateTime.Now;
                TimeSpan c = b.Subtract(a);
                txbResult.AppendText("Total searched time:" + c.TotalSeconds.ToString() + " second");
                turnOff = true;
                btnStop.Enabled = false;
                btnSearch.Enabled = true;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Error syntax regular expression", "Announcement");
            }
        }
        void wild5()
        {
            try
            {
                txbResult.Text = "";
                d.ComeBack(); //khôi phục vị trí đầu danh sách data
                string word = "", meaning = "";
                int percent = 0, count = 0, total;
                Regex regular;
                regular = new Regex(txtPattern.Text, RegexOptions.IgnoreCase);
                DateTime a = DateTime.Now;
                total = MainDict.Dicts[MainDict.selected].totalWords + MainDict.Dicts[MainDict.selected].coincidentData;
                for (int i = 0; i < total; i++)
                {
                    d.ReadNext(ref word, ref meaning);
                    if (regular.IsMatch(meaning))
                    {
                        if (meaning.Length >= 50)
                            txbResult.AppendText(word + "   :   " + meaning.Substring(0, 50) + ".............\r\n");
                        else txbResult.AppendText(word + "   :   " + meaning + "\r\n");
                        count++;
                        if (count >= 100)
                        {
                            txbResult.AppendText("Over 100 results, the application stopped searching");
                            turnOff = true;
                            btnStop.Enabled = false;
                            btnSearch.Enabled = true;
                            return;
                        }
                    }
                    percent = (int)((float)i / (MainDict.Dicts[MainDict.selected].totalWords - 1) * 100);
                    if (percent != progressBar1.Value)
                    {
                        progressBar1.Value = percent;

                    }
                    if (turnOff == true)
                    {
                        progressBar1.Value = 0;
                        return;
                    }
                }
                DateTime b = DateTime.Now;
                TimeSpan c = b.Subtract(a);
                txbResult.AppendText("Total searched time " + c.TotalSeconds.ToString() + " s");
                turnOff = true;
                btnStop.Enabled = false;
                btnSearch.Enabled = true;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Error syntax regular expression", "Announcement");
            }
        }
        void wild6()
        {
            try
            {
                txbResult.Text = "";
                d.ComeBack(); //khôi phục vị trí đầu danh sách data
                string word = "", meaning = "";
                int percent = 0, count = 0, total;
                Regex regular = new Regex(txtPattern.Text, RegexOptions.IgnoreCase);
                DateTime a = DateTime.Now;
                total = MainDict.Dicts[MainDict.selected].totalWords + MainDict.Dicts[MainDict.selected].coincidentData;
                for (int i = 0; i < total; i++)
                {
                    d.ReadNext(ref word, ref meaning);
                    if (regular.IsMatch(word))
                    {
                        txbResult.AppendText(word + "\r\n");
                        count++;
                        if (count >= 100)
                        {
                            txbResult.AppendText("Over 100 results, the application stopped searching");
                            turnOff = true;
                            btnStop.Enabled = false;
                            btnSearch.Enabled = true;
                            return;
                        }
                    }
                    if (regular.IsMatch(meaning))
                    {
                        if (meaning.Length >= 50)
                            txbResult.AppendText(word + "   :   " + meaning.Substring(0, 50) + ".............\r\n");
                        else txbResult.AppendText(word + "   :   " + meaning + "\r\n");
                        count++;
                        if (count >= 100)
                        {
                            txbResult.AppendText("Over 100 results, the application stopped searching");
                            turnOff = true;
                            btnStop.Enabled = false;
                            btnSearch.Enabled = true;
                            return;
                        }
                    }
                    percent = (int)((float)i / (MainDict.Dicts[MainDict.selected].totalWords - 1) * 100);
                    if (percent != progressBar1.Value)
                    {
                        progressBar1.Value = percent;

                    }
                    if (turnOff == true)
                    {
                        progressBar1.Value = 0;
                        return;
                    }
                }
                DateTime b = DateTime.Now;
                TimeSpan c = b.Subtract(a);
                txbResult.AppendText("Total searched time:" + c.TotalSeconds.ToString() + " second");
                turnOff = true;
                btnStop.Enabled = false;
                btnSearch.Enabled = true;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Error syntax regular expression", "Announcement");
            }
        }
        void wild7()
        {
            txbResult.Text = "";
            d.ComeBack(); //khôi phục vị trí đầu danh sách data
            string word = "";
            int percent = 0, count = 0, total;
            ApproximatString ss = new ApproximatString(MainDict.Dicts[MainDict.selected].ToLower(txtPattern.Text));
            DateTime a = DateTime.Now;
            total = MainDict.Dicts[MainDict.selected].totalWords + MainDict.Dicts[MainDict.selected].coincidentData;
            for (int i = 0; i < total; i++)
            {
                d.ReadNextWord(ref word);
                if (ss.Comparison(MainDict.Dicts[MainDict.selected].ToLower(word)))
                {
                    txbResult.AppendText(word + "\r\n");
                    count++;
                    if (count >= 100)
                    {
                        txbResult.AppendText("Over 100 results, the application stopped searching");
                        turnOff = true;
                        btnStop.Enabled = false;
                        btnSearch.Enabled = true;
                        return;
                    }
                }
                percent = (int)((float)i / (MainDict.Dicts[MainDict.selected].totalWords - 1) * 100);
                if (percent != progressBar1.Value)
                {
                    progressBar1.Value = percent;
                }
                if (turnOff == true)
                {
                    progressBar1.Value = 0;
                    return;
                }
            }
            DateTime b = DateTime.Now;
            TimeSpan c = b.Subtract(a);
            txbResult.AppendText("Total searched time:" + c.TotalSeconds.ToString() + " second");
            turnOff = true;
            btnStop.Enabled = false;
            btnSearch.Enabled = true;

        }
        private void btnLookup_Click(object sender, EventArgs e)
        {
            if (txbResult.SelectedText.Trim() != "")
            {
                tabControl1.SelectedIndex = 1;
                textBox1.Text = txbResult.SelectedText.Trim();
                MultiDict();
            }
        }
        private void MultiDict()
        {
            build.Remove(0, build.Length);
            int count = 0, newDict = MainDict.selected;
            for (i = 0; i < MainDict.Dicts.Length; i++)
            {
                meaning = MainDict.Dicts[i].Lookup2(textBox1.Text, ref MainDict.similarWord, i * 15);
                if (meaning != "")
                {
                    count++;
                    if (count != 1) build.Append("\n<hr>\n");
                    build.Append("#Từ điển " + MainDict.Dicts[i].dln[3] + "\n");
                    build.Append(meaning + "\n");
                }
            }
            if (count == 0)//không có từ nào thì tra từ tiếp theo của từ điển đang chọn
            {

                build.Append("#Không có result nào, lựa chọn các result dưới:\n");
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
                count = Array.BinarySearch(MainDict.similarWord, 0, j, textBox1.Text, MainDict.ss);
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
        private void txtPattern_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                turnOff = false;
                btnSearch.Enabled = false;
                btnStop.Enabled = true;
                if (rdbSimilarWord.Checked == true)
                    t = new Thread(wild7);
                else if (rdbWildcard.Checked == true)
                {
                    if (rdbWord.Checked == true)
                        t = new Thread(wild1);
                    else if (rdbMeaning.Checked == true)
                        t = new Thread(wild2);
                    else if (rdbSearchAll.Checked == true)
                        t = new Thread(wild3);
                }
                else
                {
                    if (rdbWord.Checked == true)
                        t = new Thread(wild4);
                    else if (rdbMeaning.Checked == true)
                        t = new Thread(wild5);
                    else if (rdbSearchAll.Checked == true)
                        t = new Thread(wild6);
                }
                t.Start();
            }
        }
        private void rdbWildcard_Click(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
        }
        private void rdbRegex_Click(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
        }
        private void rdbGanDung_Click(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
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
            textBox1.Text = tmp;
            MultiDict();
        }
    }
}
class ApproximatString
{
    string s;
    int i, j, k, loi, saiSo;
    public ApproximatString(string nhap)
    {
        s = nhap;
        saiSo = (int)Math.Round(s.Length * 0.3);
    }
    public bool Comparison(string s1)
    {
        if (s1.Length < (s.Length - saiSo) || s1.Length > (s.Length + saiSo))
            return false;
        i = j = loi = 0;
        while (i < s.Length && j < s1.Length)
        {
            if (s[i] != s1[j])
            {
                loi++;
                for (k = 1; k <= saiSo; k++)
                {
                    if ((i + k < s.Length) && s[i + k] == s1[j])
                    {
                        i += k;
                        break;
                    }
                    else if ((j + k < s1.Length) && s[i] == s1[j + k])
                    {
                        j += k;
                        break;
                    }
                }
            }
            i++;
            j++;
        }
        loi += s.Length - i + s1.Length - j;
        if (loi <= saiSo)
            return true;
        else return false;
    }
}
public class AdvacedSearch
{
    byte[] bl;
    int StringLength, present = 0;
    Encoding convert = Encoding.UTF8;
    public AdvacedSearch(byte[] dulieu)
    {
        bl = dulieu;
    }
    public void ReadNext(ref string word, ref string meaning)
    {
        StringLength = BitConverter.ToUInt16(bl, present);
        present += 2;
        word = convert.GetString(bl, present, StringLength);
        present += StringLength;
        StringLength = (int)BitConverter.ToInt32(bl, present);
        present += 4;
        meaning = convert.GetString(bl, present, StringLength);
        present += StringLength;
    }
    public void ReadNextWord(ref string word)
    {
        StringLength = BitConverter.ToUInt16(bl, present);
        present += 2;
        word = convert.GetString(bl, present, StringLength);
        present += StringLength;
        StringLength = (int)BitConverter.ToInt32(bl, present);
        present += 4 + StringLength;
    }
    public void ComeBack()
    {
        present = 0;
    }
}