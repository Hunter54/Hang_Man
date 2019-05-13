using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spanzuratoare
{
    public partial class Form1 : Form
    {
        List<Panel> listPanel = new List<Panel>();
        public static string[] cuvinte0 = { "FEUDAL", "CALCULATOR", "MAGHIAR", "AUTOCAMION", "FACULTATE" };
        int difficulty = 0;
        \1 \2 \3
        Regex rx= new Regex("(.*)\\[(.*)\\](.*)")

        public Form1()
        {
            InitializeComponent();
            panel2.Visible = true;
            panel2.BringToFront();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listPanel.Add(panel1);
            listPanel.Add(panel2);
        }

        private void button3_Click(object sender, EventArgs e)//BUTON JOC NOU
        {

            Form2 form2 = new Form2(difficulty);
			Hide();
            form2.ShowDialog();
            form2.Dispose();
            Show();
        }

        private void button2_Click(object sender, EventArgs e)//DIFICULTATE
        {
            //if (index > 0)
            //listPanel[0].BringToFront();
            panel2.Visible = false;
            panel1.Visible = true;
            panel1.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)//DIFICULTATE USOR
        {
            //if (index < listPanel.Count - 1)
            //listPanel[1].BringToFront();
            difficulty = 0;
            panel1.Visible = false;
            panel2.Visible = true;
            panel2.BringToFront();

        }

        private void button4_Click(object sender, EventArgs e)//DIFICULTATE MEDIU
        {
            difficulty = 1;
            panel1.Visible = false;
            panel2.Visible = true;
            panel2.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)//DIFICULTATE GREU
        {
            difficulty = 2;
            panel1.Visible = false;
            panel2.Visible = true;
            panel2.BringToFront();
        }

        
	}
}
