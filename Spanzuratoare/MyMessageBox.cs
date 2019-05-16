using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spanzuratoare
{
    public partial class MyMessageBox : Form
    {
        public MyMessageBox()
        {
            InitializeComponent();
        }

        static MyMessageBox newMessageBox;

        static string button_id;

		public static string ShowBox(string txtMessage,string text)
		{
			newMessageBox = new MyMessageBox();
			if (!text.Equals(""))
			{
				newMessageBox.richTextBox1.Enabled = true;
				newMessageBox.richTextBox1.Visible = true;
				newMessageBox.richTextBox1.Text = DefDex.GetDef(text.ToLower());
				newMessageBox.label1.ForeColor = Color.Red;
			}
			else
			{
				newMessageBox.pictureBox1.Visible = true;
				newMessageBox.label1.ForeColor = Color.DarkGreen;
			}
			newMessageBox.label1.Text = txtMessage;
			newMessageBox.ShowDialog();

			newMessageBox.Dispose();

			return button_id;
		}

        public static string ShowBox(string txtMessage)
        {
            newMessageBox = new MyMessageBox();
			newMessageBox.pictureBox1.Visible = true;
			newMessageBox.label1.ForeColor = Color.DarkGreen;

			newMessageBox.label1.Text = txtMessage;

			newMessageBox.ShowDialog();

			newMessageBox.Dispose();

			return button_id;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            button_id = "1";
			Close();
		}

        private void button2_Click(object sender, EventArgs e)
        {
            button_id = "2";
			Close();
		}

	}
}
