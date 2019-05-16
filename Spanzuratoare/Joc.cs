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
    public partial class Joc : Form
    {

        public string text;
        char[] array;
        int mistakes = 0;
        const int maxmistakes = 7;
        int timp = 45;
		PictureBox[] linie;
        Label[] litera;
        Button[] butoane;

        public Joc( int difficulty,string text)
        {
            InitializeComponent();
			this.text = text;
            array = text.ToCharArray();
            creare();
            if (difficulty == 2)
            {
                timer1.Enabled = true;
                label12.Visible = true;
                label12.Text = timp.ToString();
            }
			pictureBox1.Image = Properties.Resources.Spanzur;

        }

        private void button1_Click(object sender, EventArgs e)//Apasare litera
        {
            bool ok = true;
            if (Verif_litera(((Button)sender).Text.ToCharArray()[0]))
            {
                Afis_Litera(sender);
            }
            else if (mistakes+1 == maxmistakes)
            {
                timer1.Enabled = false;
				mistakes++;
				DesenImag();
				if (MyMessageBox.ShowBox("Ai murit, Cuvantul corect era " + text,text) == "2")
				{
					this.DialogResult = DialogResult.OK;
				}
				else
				{
					this.DialogResult = DialogResult.Cancel;
				}
				Close();
				Dispose();
			}
            else
            {
                mistakes++;
				DesenImag();
				((Button)sender).Enabled = false;
                ((Button)sender).BackColor = Color.FromArgb(255, 0, 0);
            }

           
            ok = Verificare_Castig();
            if (ok)
            {
                text = string.Empty;
                timer1.Enabled = false;
				if(MyMessageBox.ShowBox("AI CASTIGAT!!!") == "2")
				{
					this.DialogResult = DialogResult.OK;
				}
				else
				{
					this.DialogResult = DialogResult.Cancel;
				}
				Close();
				Dispose();
			}
        }

		private void Button_Corect(object sender,int i)
		{
			litera[i].Visible = true;
			litera[i].Text = array[i].ToString();
			array[i] = '0';
			((Button)sender).Enabled = false;
			((Button)sender).BackColor = Color.FromArgb(0, 255, 0);
		}

        private void Afis_Litera(object sender)//Afiseaza litera daca e corect si dezactiveaza litera respectiva
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (((Button)sender).Text.ToCharArray()[0] == array[i])
                {
					Button_Corect(sender, i);
                }
            }
        }

        private bool Verif_litera(char a)//Verificare Litera
        {
            foreach (char b in array)
                if (b.Equals(a))
                    return true;
            return false;
        }

        bool Verificare_Castig()//Verifica daca sunt litere negasite
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (array[i] != '0')
                    return false;
            }
            return true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            timp--;
            label12.Text = timp.ToString();
            if (timp <= 15)
                label12.ForeColor = Color.Red;
            if (timp == 0)
            {
                timer1.Enabled = false;
				if (MyMessageBox.ShowBox("Ai pierdut, Cuvantul corect era " + text,text) == "2")
				{
					this.DialogResult = DialogResult.OK;
				}
				else
				{
					this.DialogResult = DialogResult.Cancel;
				}
				Close();
				Dispose();
			}
        }//Temporizator

		private void DesenImag()
		{
			if (mistakes == 0)
				pictureBox1.Image = Properties.Resources.Spanzur;
			else if (mistakes == 1)
				pictureBox1.Image = Properties.Resources.Spanzur1;
			else if (mistakes == 2)
				pictureBox1.Image = Properties.Resources.Spanzur2;
			else if (mistakes == 3)
				pictureBox1.Image = Properties.Resources.Spanzur3;
			else if (mistakes == 4)
				pictureBox1.Image = Properties.Resources.Spanzur4;
			else if (mistakes == 5)
				pictureBox1.Image = Properties.Resources.Spanzur5;
			else if (mistakes == 6)
				pictureBox1.Image = Properties.Resources.Spanzur6;
			else if (mistakes == 7)
				pictureBox1.Image = Properties.Resources.Spanzur7;
		}

        private void creare()
        {
            litera = new Label[] { label1, label2, label3, label4, label5, label6, label7, label8, label9, label10, label11,label13,label14,label15,label16 };
            linie = new PictureBox[] { pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12,pictureBox13,pictureBox14,pictureBox15,pictureBox16 };
            butoane = new Button[] { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13, button14, button15, button16, button17, button18, button19, button20, button21, button22, button23, button24, button25, button26 };
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }//EXIT

		private void Form2_Load(object sender, EventArgs e)
		{
			int i;
			for (i = 0; i < text.Length; i++)
				linie[i].Visible = true;

			i = 0;
			char a = array[0];
			foreach (char c in array)
			{
				if (c == array[text.Length - 1] || c == a)
				{
					litera[i].Visible = true;
					litera[i].Text = c.ToString();
					array[i] = '0';
					butoane[Convert.ToInt32(c) - 65].Enabled = false;
					butoane[Convert.ToInt32(c) - 65].BackColor = Color.FromArgb(0, 255, 0);
				}
				i++;
			}

		}
	}
}
