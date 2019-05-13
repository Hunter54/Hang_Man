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
	public partial class Meniu : Form
	{
		List<Panel> listPanel = new List<Panel>();
		public static string[] cuvinte0 = { "FEUDAL","GLOB", "CALCULATOR", "MAGHIAR", "DOINA", "AUTOCAMION", "FACULTATE", "IATAGAN", "PAGAN", "VUIET", "AGRESOR", "TABLOU", "FLOARE","DULAP","PANTALON","SCAUN","CALORIFER","DISPONIBIL","SERBARE","TROFEU","ELECTRICITATE","LILIAC","GRATUIT","CIOCAN","CALENDAR","CURAT","ALFABET","INCORECT","PERDEA","SOARE","CASTEL","OCHELAR","MINCINOS","BUCHET","CHEMARE","MOSCHEE","BERECHET","FINISAT","TELEGRAF","REAFIRMARE","FERMECAT","SIFONARE","EVADARE","MASOCHIST","ACUPUNCTURA","BUTOAIE","CABLU","ANTEDATAT","TREIERAT","PUBLICITATE","IMEDIAT",
		"DIVIN","CARTON","CREDIT","ACIDITATE","LAPTE","VALABILITATE","AROMAT","DIFERIT","POSIBIL","ALCOOL","ION","AUTOR","NECTAR","OPOZANT","PENAR","TABLETA","PARIU","PICIOR","YOGA","NOSTIM","FRUCT","ANARHISM","CRIMINAL","PERICULOS","OMNIVOR","RADIO","CAIET","ACARET","ACOPERIT","BLOC","INIMA","CEAS","ANTENA","DULAP","SCOALA","ALINEAT",};


		public static string[] cuvinte1 = { "COTERIE", "ANIMOZITATE", "ETEROCLIT", "OBEDIENT", "VOLUMINOS", "ORNITORINC", "INJONCTIUNE", "PLAVIT", "OSAF", "PATOLOGIC", "PROCELA","SUPRATERAN","ACCIDENT","CAMPION","TRANSLATOR","LONGEVIV","ZGOMOT","ORTODOX","PIX","FUZIUNE","EXTRATERESTRU","INFLAMABIL","MOJIC","FILOSOFIE","EMANCIPARE","HIPNOTIZAT","BIBLIOGRAFIE","DEZORGANIZARE","GASTRONOMIC","TRUNCHI","STRICT","TRANSPLANT",
		"TELEVIZIUNE","APOCALIPTIC","SAXOFON","ANTISPASTIC","INCULPAT","IRASCIBIL","INCONTESTABIL","INTANGIBIL","SUBMINARE","CONFUZ","TRIFTONG","CONSOLIDARE","INDISTRUCTIBIL","EXPOZANT","PORUMB","PLAUZIBIL","INSPIRAT","CENTRALIST","GHIONT","PROMPT","OXIGEN","GRUNJOS","PARALELIPIPED","JURNAL","GHIOZDAN","EXTRAORDINAR","MOTOCICLIST","JURNALIST","COCKTAIL","PRAGMATISM","PROVINCIE","INTRAOCULAR","SCHIMB","INTRAMOLECULAR","SCHIMB","OPTSPREZECE","ABSTRACT","REFLEXIV","ANARHISM","ACCENT","INTRARE","PEDANT","INSCRIPTIBIL","BIBLIORAFT"};
		int difficulty = 0;

        public Meniu()
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
			Joc form2;
			Hide();
			do
			{
				form2 = new Joc(difficulty);
			} while (form2.ShowDialog() == DialogResult.OK);
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

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Meniu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
