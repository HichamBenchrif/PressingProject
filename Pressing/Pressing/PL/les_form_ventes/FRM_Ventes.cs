using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pressing.PL.les_form_client;
using Pressing.PL.les_form_caisse;
using Pressing.PL.les_form_depenses;
using Pressing.PL.Les_form_services;
using Pressing.BL.repository;

namespace Pressing.PL.les_form_ventes
{
    public partial class FRM_Ventes : Form
    {
        VenteRepository venterepository = new VenteRepository();
        public FRM_Ventes()
        {
            InitializeComponent();
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Tu as vraiment envie de sortir ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnProduits_Click(object sender, EventArgs e)
        {
            new FRM_Articl().Show();
            Close();
        }

        private void btnVentes_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
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

        private void btnRapports_Click(object sender, EventArgs e)
        {
            new FRM_service().Show();
            Close();

        }

        private void FRM_Ventes_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = venterepository.GetAll();
        }
        private  void LoadSalesData()
        {
            
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            LoadSalesData();
        }
    }
}
