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
            muvelet.Text = "0";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Button B = sender as Button;

            if (muvelet.Text.Equals("0") && "0123456789(".Contains(B.Tag.ToString()))
            {
                muvelet.Text = "";
            }

            muvelet.Text += B.Tag;
        }

        private void button_Egyenlo_Click(object sender, EventArgs e)
        {
            double eredmeny = Convert.ToDouble(new DataTable().Compute(muvelet.Text, null));
            muvelet.Text =  eredmeny.ToString().Replace(",",".");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (muvelet.Text.Substring(0,1) == "-")
            {
                muvelet.Text = muvelet.Text.Remove(0, 1);
            }
            else
            {
                muvelet.Text = "-" + muvelet.Text;
            }                
        }

        private void button_DEL_Click(object sender, EventArgs e)
        {
            if (muvelet.Text.Length == 1)
            {
                muvelet.Text = "0";
            }
            else
            {
                muvelet.Text = muvelet.Text.Remove(muvelet.Text.Length-1, 1);
            }
        }
    }
}