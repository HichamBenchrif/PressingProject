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
using Pressing.BL.repository;

namespace Pressing.PL
{
    public partial class FRM_Articl : Form
    {
        ArticlRepository articlerepository = new ArticlRepository();
        public FRM_Articl()
        {
            InitializeComponent();
        }

       

        

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
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


        public static int parentX, panrentY;
        

        private void button7_Click(object sender, EventArgs e)
        {
            new FRM_Ajoute_Articl().ShowDialog();
            //Form modalBackground = new Form();
            //using(modalForm modal = new modalForm())
            //{
                
            //}

        }

        private void button6_Click(object sender, EventArgs e)
        {
            new FRM_Categories().Show();
        }

        private void btnVentes_Click(object sender, EventArgs e)
        {
            new FRM_Ventes().Show();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            new FRM_Caisse().Show();
            Close();
        }

        private void btnProduits_Click(object sender, EventArgs e)
        {

        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            new FRM_Client().Show();
            Close();
        }

        private void btnDépenses_Click(object sender, EventArgs e)
        {
            new FRM_Depenses().Show();
            Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new FRM_Famill().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new FRM_Menu().Show();
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = articlerepository.GetAll();
        }

        private void FRM_Articl_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = articlerepository.GetAll();
        }
    }
}




