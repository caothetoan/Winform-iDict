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
    public partial class Rename : Form
    {
        public static int result;
        int position;
        public Rename(int Keypad, int position1, string tu)
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
            txbNewWord.KeyPress += new KeyPressEventHandler(new VietKeyHandler(txbNewWord).OnKeyPress);
            position = position1;
            txbOldWord.Text = tu;
            result = -1;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            if ((txbNewWord.Text = txbNewWord.Text.Replace("\r", "").Trim()) == "")
            {
                MessageBox.Show("Write the new word, please", "Announcement");
                return;
            }
            result = iDict.MainDict.Dicts[iDict.MainDict.selected].RenameTu(position, txbNewWord.Text);
            if (result < 0)
            {
                MessageBox.Show("This word existed", "Announcement");
                return;
            }
            Close();
        }

    }
}