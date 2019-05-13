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
    public partial class Form2 : Form
    {

        static string text;
        char[] array;
        int mistakes = 0;
        int maxmistakes = 3;
        int difficulty;
        int timp = 60;
        Form1 parrent;
        PictureBox[] linie;
        Label[] litera;
        Button[] butoane;
        Random rn = new Random();


        public Form2(int difficulty)
        {
            InitializeComponent();
            this.difficulty = difficulty;
            if (difficulty == 0)
                text = Form1.cuvinte0[rn.Next(1,5)-1];
            else if (difficulty == 2)
                text = Form1.cuvinte0[rn.Next(1, 5) - 1];
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
			DesenImag();
            bool ok = true;
            if (Verif_litera(((Button)sender).Text.ToCharArray()[0]))
            {
                Afis_Litera(sender);
            }
            else if (mistakes == maxmistakes)
            {
                if (MyMessageBox.ShowBox("Ai pierdut, Cuvantul corect era " + text) == "2")
                {
                    Close();
                    Dispose();
                    Restart(difficulty);
                }
                else
                {
                    Close();
                }
            }
            else
            {
                mistakes++;
                //pictureBox1.Image = imagine[mistakes-1];
                ((Button)sender).Enabled = false;
                ((Button)sender).BackColor = Color.FromArgb(255, 0, 0);
            }

           
            ok = Verificare_Castig();
            if (ok)
            {
                if (MyMessageBox.ShowBox("AI CASTIGAT") == "2")
                {
                    Close();
                    Dispose();
                    Restart(difficulty);

                }
                else
                {
                    Close();
                }
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
            if (timp <= 10)
                label12.ForeColor = Color.Red;
            if (timp == 0)
            {
                timer1.Enabled = false;
                MyMessageBox.ShowBox("Ai pierdut, Cuvantul corect era "+text);
                Close();

            }
        }//Temporizator

        private void Form2_Load(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i < text.Length; i++)
                linie[i].Visible = true;

            i = 0;
            foreach (char c in array)
            {
                if (c == array[text.Length - 1] || c == array[0])
                {
					litera[i].Visible = true;
					litera[i].Text = c.ToString();
					array[i] = '0';
					butoane[Convert.ToInt32(c) - 65].Enabled = false;
					butoane[Convert.ToInt32(c) - 65].BackColor = Color.FromArgb(0,255,0);
				}
                i++;
            }

        }

		private void DesenImag()
		{
			Image bit = pictureBox1.Image;
			
			using (Graphics g = Graphics.FromImage(bit))
			{
				Pen pen = new Pen(Color.Black, 3);
				if (mistakes == 1)
					g.DrawLine(pen, 100, 20, 40, 40);
				else if(mistakes==2)
				g.DrawEllipse(pen, 50, 50, 20, 20);
                g.DrawLine(pen, 100, 100, 200, 200);
			}
			pictureBox1.Image = bit;
		}

        private void creare()
        {
            litera = new Label[] { label1, label2, label3, label4, label5, label6, label7, label8, label9, label10, label11 };
            linie = new PictureBox[] { pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12 };
            butoane = new Button[] { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13, button14, button15, button16, button17, button18, button19, button20, button21, button22, button23, button24, button25, button26 };
        }

        static public void Restart(int difficulty)
        {
            Form2 form2 = new Form2(difficulty);
            form2.ShowDialog();

        }

        private void button27_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

     
    }
}
