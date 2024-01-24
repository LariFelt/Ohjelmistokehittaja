using Microsoft.VisualBasic.ApplicationServices;
using System.IO;
namespace SuosituimmatNimet
{
    public partial class NimetForm : Form
    {
        public NimetForm()
        {
            InitializeComponent();
        }

        private void TarkastaBT_Click(object sender, EventArgs e)
        {
            VastausLB.Text = "";
            VastausLB.Visible = false;
            string[] pojat = File.ReadAllLines("C:\\Users\\lari.felt\\source\\repos\\Ohjelmistokehittaja/SuosituimmatNimet/pojat.txt");
            string[] tytot = File.ReadAllLines("C:\\Users\\lari.felt\\source\\repos\\Ohjelmistokehittaja/SuosituimmatNimet/tytot.txt");
            string nimi = NimiTB.Text;
            int laskurip = 1;
            int laskurit = 1;
            foreach (string poika in pojat) 
            {
            if (nimi == poika)
                {
                    VastausLB.Text = "Nimesi on " + laskurip + ". suosituin poikien nimi vuonna 2020";
                    VastausLB.Visible = true;
                }
                laskurip++;
            }
            foreach (string tytto in tytot)
            {
                if (nimi == tytto) 
                {
                    VastausLB.Text = "Nimesi on " + laskurit + ". suosituin tytt�jen nimi vuonna 2020";
                    VastausLB.Visible = true;
                }
                laskurit++;
            }
            if (VastausLB.Visible == false)
            {
                VastausLB.Text = "Nimesi ei l�ytynyt suosituimpien nimien joukosta! :-(";
                VastausLB.Visible = true;
            }
                }
    }
}