using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Controls;

namespace QRWin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string b32digits = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";
            int b32diglng = b32digits.Length;
            StringBuilder b = new StringBuilder();
            Random rand = new Random();
            for (int i = 0; i < 32; i++)
            {
                b.Append(b32digits[rand.Next(0, b32diglng - 1)]);
            }
            txtKey.Text = b.ToString();
        }

        private void btnMakeQR_Click(object sender, EventArgs e)
        {
            qrCon1.Text = String.Format("otpauth://totp/{0}?secret={1}", txtName.Text, txtKey.Text);
        }
    }
}
