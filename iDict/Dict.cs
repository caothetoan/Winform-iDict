using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Globalization;
using System.Windows.Forms;

public class Dict
{
    Stream st;
    public string[] dln;//mã sắp xếp, sdk phát âm , giọng , Dictionary Name , tác giả
    //string tu, meaning;
    byte[] b = new byte[4], bs = new byte[200];
    static StringBuilder value = new StringBuilder(10000);
    public int totalWords, coincidentData;
    int listPosition, wordPosition, tgu;
    int StringLength, mid, left, right, tgi;
    Encoding convert = Encoding.UTF8;
    CultureInfo ci;
    string word, meaning;
    public string fileName;
    //
    //method phụ
    //
    int LowerComparison(string x, string y)
    {
        return ci.CompareInfo.Compare(x.ToLower(ci), y.ToLower(ci), CompareOptions.StringSort);
    }
    int UpperComparison(string x, string y)
    {
        return ci.CompareInfo.Compare(x, y, CompareOptions.StringSort);
    }
    public static string ToHtml(string s)
    {
        value.Remove(0, value.Length);
        if (s == null || s.Length == 0) return "";
        char character = s[0];
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
                        value.Append(iDict.MainDict.path + "\\Images");
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
        value.Insert(0, "<html><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"></head><body><small style = \"font-family: tahoma;\">");
        value.Append("</small></body></html>");
        return value.ToString();
    }
    public string ToLower(string s)
    {
        return s.ToLower(ci);
    }
    //
    //Public method
    //
    public Dict(string path)
    {
        fileName = Path.GetFileNameWithoutExtension(path);
        st = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.Read);
        st.Read(b, 0, 4);           // đọc 4 byte đầu để lấy vị trí danh sách và tính tổng số từ
        listPosition = BitConverter.ToInt32(b, 0);
        totalWords = (int)(st.Length - listPosition) / 4;
        st.Read(b, 0, 2);          //Đọc 2 byte lưu trữ số lần phát sinh dl thừa
        coincidentData = BitConverter.ToUInt16(b, 0);
        st.Read(b, 0, 2);
        StringLength = BitConverter.ToUInt16(b, 0);
        if (StringLength > bs.Length) bs = new byte[StringLength];
        st.Read(bs, 0, StringLength);
        word = convert.GetString(bs, 0, StringLength);
        dln = word.Split('\0');
        st.Read(bs, 0, StringLength);
        ci = new CultureInfo(dln[0]);
    }
    public string ReadWord(int i)
    {
        if (i >= totalWords) return "";
        st.Seek(listPosition + i * 4, SeekOrigin.Begin);      //nhảy đến vị trí từ trong danh sách
        st.Read(b, 0, 4);
        wordPosition = BitConverter.ToInt32(b, 0);
        st.Seek(wordPosition, SeekOrigin.Begin); // nhảy đến dữ liệu từ đó
        st.Read(b, 0, 2);     //đọc từ
        StringLength = BitConverter.ToUInt16(b, 0);
        if (StringLength > bs.Length) bs = new byte[StringLength];
        st.Read(bs, 0, StringLength);
        return convert.GetString(bs, 0, StringLength);
    }
    public string ReadMeaning(int i)
    {
        if (i >= totalWords) return "";
        st.Seek(listPosition + i * 4, SeekOrigin.Begin);      //nhảy đến vị trí từ trong danh sách
        st.Read(b, 0, 4);
        wordPosition = BitConverter.ToInt32(b, 0);
        st.Seek(wordPosition, SeekOrigin.Begin); // nhảy đến dữ liệu từ đó
        st.Read(b, 0, 2);     //đọc độ dài từ
        StringLength = BitConverter.ToUInt16(b, 0);
        st.Seek(StringLength, SeekOrigin.Current);
        st.Read(b, 0, 4);     //đọc độ dài nghĩa
        StringLength = BitConverter.ToInt32(b, 0);
        if (StringLength > bs.Length) bs = new byte[StringLength];
        st.Read(bs, 0, StringLength);
        return convert.GetString(bs, 0, StringLength);
    }
    public void ReadMeaning(int i, ref string tu, ref string meaning)
    {
        if (i >= totalWords)
        {
            tu = meaning = "";
            return;
        }
        st.Seek(listPosition + i * 4, SeekOrigin.Begin);      //nhảy đến vị trí từ trong danh sách
        st.Read(b, 0, 4);
        wordPosition = BitConverter.ToInt32(b, 0);
        st.Seek(wordPosition, SeekOrigin.Begin); // nhảy đến dữ liệu từ đó
        st.Read(b, 0, 2);     //đọc từ
        StringLength = BitConverter.ToUInt16(b, 0);
        if (StringLength > bs.Length) bs = new byte[StringLength];
        st.Read(bs, 0, StringLength);
        tu = convert.GetString(bs, 0, StringLength);
        st.Read(b, 0, 4);     //đọc độ dài nghĩa
        StringLength = BitConverter.ToInt32(b, 0);
        if (StringLength > bs.Length) bs = new byte[StringLength];
        st.Read(bs, 0, StringLength);
        meaning = convert.GetString(bs, 0, StringLength);
    }
    public void LoadWordsList(int start, ref string[] list, int count)
    {
        for (tgi = 0; tgi < count; tgi++)
            if (((tgi + start) >= 0) && ((tgi + start) < totalWords))
                list[tgi] = ReadWord(tgi + start);
            else list[tgi] = "";
    }
    public void Lookup(string s, ref int position, ref string returnMeaning, ref string[] list)
    {
        /* phần tra từ này hơi khác thường, thay vì nếu từ = nhau thì trả về, ta vẫn coi nó như là nhỏ
         * hơn bởi vì đôi khi có từ trùng ví dụ a b c d d d e f g nếu nhảy đến phần tử d cuối thì chương
         * trình vẫn nhảy trở lại d đầu
         */
        left = 0;
        right = (int)(totalWords - 1);
        if (totalWords == 0)
        {
            position = -1;
            return;
        }
        while (left <= right)
        {
            mid = (left + right) >> 1;
            if ((StringLength = LowerComparison(s, ReadWord(mid))) <= 0)
                right = mid - 1;
            else left = mid + 1;
        }
        if (left == totalWords) left--; //nếu từ cần tìm ra khỏi phần hiển thị của danh sách thì nhảy về vị trí từ cuối
        ReadMeaning(left, ref list[0], ref meaning);
        tgi = left;
        if (LowerComparison(list[0], s) == 0) // lấy hết các result không phân biệt hoa thường
        {
            returnMeaning = meaning;
            tgi++;
            ReadMeaning(tgi, ref word, ref meaning);
            while (LowerComparison(word, s) == 0)
            {
                returnMeaning += "\n<hr>\n" + meaning;
                tgi++;
                ReadMeaning(tgi, ref word, ref meaning);
            }
            position = left;
        }
        else
        {
            position = ~left;
            returnMeaning = meaning;
        }
        for (tgi = 1; tgi < list.Length; tgi++)
        {
            if ((tgi + left) < totalWords)
                list[tgi] = ReadWord(tgi + left);
            else list[tgi] = "";
        }
    }
    public void Lookup(string s, ref string[] list, int position) // cái này dùng cho iDict small 
    {
        left = 0;
        right = (int)(totalWords - 1);
        if (totalWords == 0)
            return;
        while (left <= right)
        {
            mid = (left + right) >> 1;
            if ((StringLength = LowerComparison(s, ReadWord(mid))) <= 0)
                right = mid - 1;
            else left = mid + 1;
        }
        if (left == totalWords) left--; //nếu từ cần tìm ra khỏi phần hiển thị của danh sách thì nhảy về vị trí từ cuối
        for (tgi = 0; tgi < 15; tgi++)
        {
            if ((tgi + left) < totalWords)
                list[tgi + position] = ReadWord(tgi + left);
            else list[tgi + position] = "";
        }
    }
    // dùng khi tra đa từ điển, các từ điển phụ chỉ cần quan tâm đến nghĩa trả về thôi, 
    // nếu không có thì trả về danh sách gần đúng
    public string Lookup2(string s, ref string[] listtotal, int position1)
    {
        /* phần tra từ này hơi khác thường, thay vì nếu từ = nhau thì trả về, ta vẫn coi nó như là nhỏ
             * hơn bởi vì đôi khi có từ trùng ví dụ a b c d d d e f g nếu nhảy đến phần tử d cuối thì chương
             * trình vẫn nhảy trở lại d đầu
             */
        left = 0;
        right = (int)(totalWords - 1);
        if (totalWords == 0)
            return "";
        while (left <= right)
        {
            mid = (left + right) >> 1;
            if ((StringLength = LowerComparison(s, ReadWord(mid))) <= 0)
                right = mid - 1;
            else left = mid + 1;
        }
        ReadMeaning(left, ref word, ref meaning);
        if (LowerComparison(word, s) == 0) // lấy hết các result không phân biệt hoa thường
        {
            string fullMeaning = "";
            fullMeaning = meaning;
            left++;
            ReadMeaning(left, ref word, ref meaning);
            while (LowerComparison(word, s) == 0)
            {
                fullMeaning += "\n<hr>\n" + meaning;
                left++;
                ReadMeaning(left, ref word, ref meaning);
            }
            return fullMeaning;
        }
        else
        {
            //load các từ gấn đúng nhỏ hơn vào danh sách chung
            for (tgi = 0; tgi < 15; tgi++)
                if (((tgi + left - 7) >= 0) && ((tgi + left - 7) < totalWords))
                    listtotal[tgi + position1] = ReadWord(tgi + left - 7);
                else listtotal[tgi + position1] = "";
            return "";
        }
    }
    //dùng khi cập nhật dữ liệu, có phân biệt chữ hoa thường , 
    //nếu không tìm thấy thì trả về dương (hơi ngược)
    public int LookupUpper(string s)
    {
        left = 0;
        right = (int)(totalWords - 1);
        if (totalWords == 0)
            return 0;
        while (left <= right)
        {
            mid = (left + right) >> 1;
            if ((StringLength = UpperComparison(s, ReadWord(mid))) <= 0)
                right = mid - 1;
            else left = mid + 1;
        }
        if (UpperComparison(s, ReadWord(left)) != 0) return left;
        else return ~left;
    }
    public int Translator(string s)
    //trong chức năng tra văn bản, trả về đúng nếu từ này có trong từ điển  
   
    {
        left = 0;
        right = (int)(totalWords - 1);
        if (totalWords == 0)
            return -1;
        while (left <= right)
        {
            mid = (left + right) >> 1;
            if ((StringLength = LowerComparison(s, ReadWord(mid))) <= 0)
                right = mid - 1;
            else left = mid + 1;
        }
        ReadMeaning(left, ref word, ref meaning);
        if (LowerComparison(word, s) == 0) return 1; //có trong dict
        else if (word.ToLower(ci).IndexOf(s.ToLower(ci))==0) return 0; //nằm trong 1 từ trong dict
        else return -1;// không có
    }
    //
    //Cap Nhat Data
    //
    public int AddWord(string word, string meaning)
    {
        mid = LookupUpper(word);
        if (mid < 0) return mid;
        byte[] bList = new byte[st.Length - listPosition];
        st.Seek(listPosition, SeekOrigin.Begin);
        st.Read(bList, 0, bList.Length);         //đọc cả danh sách
        st.Seek(listPosition, SeekOrigin.Begin);
        //
        //ghi từ vào cuối phần nội dung
        //
        bs = convert.GetBytes(word);
        b = BitConverter.GetBytes(bs.Length);
        st.Write(b, 0, 2);//2byte ghi độ dài
        st.Write(bs, 0, bs.Length);
        //
        //ghi nội dung nghĩa
        //
        bs = convert.GetBytes(meaning);
        b = BitConverter.GetBytes(bs.Length);
        st.Write(b, 0, 4); //4 byte ghi độ dài
        st.Write(bs, 0, bs.Length);
        tgu = (int)st.Position;      //nhớ vị trí danh sách mới
        st.Write(bList, 0, mid * 4);    //ghi lại danh sách
        st.Write(BitConverter.GetBytes(listPosition), 0, 4);
        st.Write(bList, mid * 4, bList.Length - mid * 4);
        st.Seek(0, SeekOrigin.Begin);   //Nhảy sang vị trí đầu tiên ghi vị trí danh sách mới
        st.Write(BitConverter.GetBytes(tgu), 0, 4);
        listPosition = tgu;   //sửa lại thông tin vị trí danh sách và tổng số từ
        totalWords += 1;
        st.Flush();
        return mid;
    }
    public int EditWord(int editingPosition, string editingMeaning)//sửa được từ thì return vị trí sửa , nếu không return-1
    {
        if (editingPosition >= totalWords || editingPosition < 0) return -1;
        st.Seek(listPosition + editingPosition * 4, SeekOrigin.Begin);      //nhảy đến vị trí từ trong danh sách
        st.Read(b, 0, 4);
        wordPosition = BitConverter.ToInt32(b, 0);
        st.Seek(wordPosition, SeekOrigin.Begin);
        st.Read(b, 0, 2);     //đọc từ
        StringLength = BitConverter.ToUInt16(b, 0);
        if (StringLength > bs.Length) bs = new byte[StringLength];
        st.Read(bs, 0, StringLength);
        word = convert.GetString(bs, 0, StringLength);
        st.Seek(-StringLength - 2, SeekOrigin.Current);//nhảy ngược lại phần đầu từ để ghi đè dữ liệu thành '\0'(không dùng nữa)
        st.Read(b, 0, 2);
        StringLength = BitConverter.ToUInt16(b, 0);
        bs = new byte[StringLength];  //tạo mảng byte nguyên thuỷ
        st.Write(bs, 0, StringLength);  //ghi vào để lúc tìm kiếm nâng cao khỏi tìm thấy
        st.Read(b, 0, 4);     //đọc độ dài nghĩa
        StringLength = BitConverter.ToInt32(b, 0);
        bs = new byte[StringLength];  //tương tự trên
        st.Write(bs, 0, StringLength);
        //sửa từ
        byte[] bList = new byte[st.Length - listPosition];
        st.Seek(listPosition, SeekOrigin.Begin);
        st.Read(bList, 0, bList.Length);         //đọc cả danh sách
        st.Seek(listPosition, SeekOrigin.Begin);
        //
        //ghi từ vào cuối phần nội dung
        //
        bs = convert.GetBytes(word);
        b = BitConverter.GetBytes(bs.Length);
        st.Write(b, 0, 2);//2byte ghi độ dài
        st.Write(bs, 0, bs.Length);
        //
        //ghi nội dung nghĩa
        //
        bs = convert.GetBytes(editingMeaning);
        b = BitConverter.GetBytes(bs.Length);
        st.Write(b, 0, 4); //4 byte ghi độ dài
        st.Write(bs, 0, bs.Length);
        tgu = (int)st.Position;      //nhớ vị trí danh sách mới
        b = BitConverter.GetBytes(listPosition);
        for (tgi = 0; tgi < 4; tgi++) //ghi vị trí của từ mới
        {
            bList[tgi + editingPosition * 4] = b[tgi];
        }
        st.Write(bList, 0, bList.Length);
        st.Seek(0, SeekOrigin.Begin);   //Nhảy sang vị trí đầu tiên ghi vị trí danh sách mới
        st.Write(BitConverter.GetBytes(tgu), 0, 4);
        coincidentData++;
        st.Write(BitConverter.GetBytes(coincidentData), 0, 2);       // đoạn này ghi dữ liệu thừa phát sinh
        listPosition = tgu;   //sửa lại thông tin vị trí danh sách
        st.Flush();
        return editingPosition;
    }
    public int DeleteWord(int position)
    {
        if (position >= totalWords || position < 0) return -1;
        //đoạn này ghi phần dữ liệu thừa thành '\0' hết
        st.Seek(listPosition + position * 4, SeekOrigin.Begin);      //nhảy đến vị trí từ trong danh sách
        st.Read(b, 0, 4);
        wordPosition = BitConverter.ToInt32(b, 0);
        st.Seek(wordPosition, SeekOrigin.Begin);
        st.Read(b, 0, 2);     //đọc từ
        StringLength = BitConverter.ToUInt16(b, 0);
        bs = new byte[StringLength];  //tạo mảng byte nguyên thuỷ
        st.Write(bs, 0, StringLength);  //ghi vào để lúc tìm kiếm nâng cao khỏi tìm thấy
        st.Read(b, 0, 4);     //đọc độ dài nghĩa
        StringLength = BitConverter.ToInt32(b, 0);
        bs = new byte[StringLength];  //tương tự trên
        st.Write(bs, 0, StringLength);

        //bắt đầu xoá phần tử
        byte[] bList = new byte[(totalWords - position - 1) * 4];
        st.Seek(listPosition + position * 4 + 4, SeekOrigin.Begin);
        st.Read(bList, 0, bList.Length);         //đọc danh sách từ phía sau
        st.Seek(listPosition + position * 4, SeekOrigin.Begin);  // ghi lại danh sách đó đè lên vị trí xoá
        st.Write(bList, 0, bList.Length);    //ghi lại danh sách , khuyết vị trí cần xoà
        st.SetLength(st.Position);            //định lại kích thước file (giảm 4 byte mất khi xoá vị trí danh sách)
        st.Seek(4, SeekOrigin.Begin);
        coincidentData++;
        totalWords--;
        st.Write(BitConverter.GetBytes(coincidentData), 0, 2);       // đoạn này ghi dữ liệu thừa phát sinh
        return position;
    }
    public int RenameTu(int position1, string tu)
    {
        if (LookupUpper(tu) < 0 || position1 >= totalWords || position1 < 0) return -1;
        meaning = ReadMeaning(position1);  // lấy nghĩa giữ lại sau khi đổi từ
        DeleteWord(position1);     //xoá từ cần đổi
        return AddWord(tu, meaning);    //thêm lại từ đó với từ mới nhưng nghĩa cũ
    }
    //
    //Cung cấp dữ liệu cho tìm nâng cao
    //
    public byte[] DuLieuSearch()
    {
        st.Seek(6, SeekOrigin.Begin);
        st.Read(b, 0, 2);
        StringLength = BitConverter.ToUInt16(b, 0);
        st.Seek(StringLength, SeekOrigin.Current);
        byte[] data = new byte[listPosition - st.Position];
        st.Read(data, 0, data.Length);
        return data;
    }
    //
    //tắt , mở kết nối với data để xoá dữ liệu thừa
    //
    public void tatKetNoi()
    {
        st.Flush();
        st.Close();
    }
}
