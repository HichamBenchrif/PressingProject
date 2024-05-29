using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pressing.PL.les_form_article;
using Pressing.PL.les_form_ventes;
using Pressing.PL.les_form_caisse;
using Pressing.PL.les_form_client;
using Pressing.PL.les_form_depenses;

namespace Pressing.PL.les_form_depenses
{
    public partial class FRM_Depenses : Form
    {
        public FRM_Depenses()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new FRM_Caisse().Show();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new FRM_Menu().Show();
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (PNL_Menu.Visible == false)
            {
                PNL_Menu.Visible = true;
            }
            else
            {
                PNL_Menu.Visible = false;
            }
        }

        private void btnProduits_Click(object sender, EventArgs e)
        {
            new FRM_Articl().Show();
            Close();
        }

        private void btnVentes_Click(object sender, EventArgs e)
        {
            new FRM_Ventes().Show();
            Close();
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            new FRM_Client().Show();
            Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
