using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulátor
{
    public partial class Form_Kalkulator : Form
    {
        public Form_Kalkulator()
        {
            InitializeComponent();
        }

        private void button_AC_Click(object sender, EventArgs e)
        {
            kijelzo.Text = "0";
        }

        private void Szamjegyek_Click(object sender, EventArgs e)
        {
            Button Gomb = sender as Button;

            if ("+-*/".Contains(kijelzo.Text.Substring(kijelzo.Text.Length - 1, 1)) && "+-*/".Contains(Gomb.Tag.ToString()))
            {
                //-- Ha a kijelzőn az utolsó karakter műveleti jel és újra műveleti jelet használ, akkor nem rögzítjük
                return;
            }
            if (kijelzo.Text.Equals("0") && "0123456789(/*-".Contains(Gomb.Tag.ToString()))
            {
                //-- Ha kijelzőn CSAK a nulla számjegy szerepel, akkor eltüntetjük. Ne kezdődjön nullával!
                kijelzo.Text = "";
            }
            kijelzo.Text += Gomb.Tag;
        }

        private void button_Egyenlo_Click(object sender, EventArgs e)
        {
            try
            {
                double eredmeny = Convert.ToDouble(new DataTable().Compute(kijelzo.Text, null));
                kijelzo.Text = eredmeny.ToString().Replace(",", ".");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hibás képlet!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void button_Elojelvalto_Click(object sender, EventArgs e)
        {
            if (kijelzo.Text.Substring(0,1) == "-")
            {
                kijelzo.Text = kijelzo.Text.Remove(0, 1);
            }
            else
            {
                kijelzo.Text = "-" + kijelzo.Text;
            }                
        }

        private void button_DEL_Click(object sender, EventArgs e)
        {
            if (kijelzo.Text.Length == 1)
            {
                kijelzo.Text = "0";
            }
            else
            {
                kijelzo.Text = kijelzo.Text.Remove(kijelzo.Text.Length-1, 1);
            }
        }
    }
}