using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pressing.PL.les_form_ventes;
using Pressing.PL.les_form_client;
using Pressing.PL.les_form_article;
using Pressing.PL.les_form_caisse;
using Pressing.PL.les_form_depenses;

namespace Pressing.PL.les_form_article
{
    public partial class FRM_Categories : Form
    {
       
        public FRM_Categories()
        {
            InitializeComponent();

           
        }
        
        private void button7_Click(object sender, EventArgs e)
        {
            new FRM_Ajoute_Client().ShowDialog();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
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

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnVentes_Click(object sender, EventArgs e)
        {
            new FRM_Ventes().Show();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new FRM_Menu().Show();
            Close();
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            new FRM_Client().Show();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new FRM_Caisse().Show();
            Close();
        }

        private void btnDépenses_Click(object sender, EventArgs e)
        {
            new FRM_Depenses().Show();
            Close();
        }
    }
}
