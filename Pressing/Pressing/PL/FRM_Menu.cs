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
using Pressing.PL.les_form_caisse;
using Pressing.PL.les_form_depenses;
using Pressing.BL.repository;
using Pressing.PL.Les_form_services;

namespace Pressing.PL
{
    public partial class FRM_Menu : Form

    {
        ClientRepository clientrepository = new ClientRepository();
        
        public FRM_Menu()
        {
            InitializeComponent();

            //PNL_Menu.Visible = true;


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
            if(PNL_Menu.Visible == false)
            {
                PNL_Menu.Visible = true;
            }
            else
            { 
                PNL_Menu.Visible = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new FRM_Ventes().Show();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new FRM_Depenses().Show();
        }

        private void Produits_Click(object sender, EventArgs e)
        {


            new FRM_Articl().ShowDialog();
          
            


        }

        private void Clients_Click(object sender, EventArgs e)
        {
            new FRM_Client().Show();
        }

        private void Rapports_Click(object sender, EventArgs e)
        {
            
        }

       

        private void FRM_Menu_Load(object sender, EventArgs e)
        {
            label1.Text = clientrepository.GetTotal();
        }

        private void panelAjouteProduite_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelAficher_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            new FRM_Caisse().Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Tu as vraiment envie de sortir ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void PNL_Menu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = clientrepository.GetTotal();
        }

        private void btnRapports_Click(object sender, EventArgs e)
        {
            new FRM_service().Show();
        }
    }
}
