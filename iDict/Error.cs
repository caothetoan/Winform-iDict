using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace iDict
{
    public partial class Error : Form
    {
        public Error(string s)
        {
            InitializeComponent();
            textBox1.Text = s;
        }
    }
}