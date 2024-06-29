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
using Pressing.PL.Les_form_services;

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
            DialogResult res = MessageBox.Show("Tu as vraiment envie de sortir ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {
                Application.Exit();
            }
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




        public static int panrentX;

        private void button7_Click(object sender, EventArgs e)
        {

            Form modelBackground = new Form();
            using (FRM_Ajoute_Articl model = new FRM_Ajoute_Articl())
            {
                modelBackground.StartPosition = FormStartPosition.Manual;
                modelBackground.FormBorderStyle = FormBorderStyle.None;
                modelBackground.Opacity = 0.50;
                modelBackground.BackColor = Color.Black;
                modelBackground.Size = this.Size;
                modelBackground.Location = this.Location;
                modelBackground.ShowInTaskbar = false;
                modelBackground.Show();
                model.Owner = modelBackground;

                panrentX = this.Location.X;

                model.ShowDialog();
                modelBackground.Dispose();

            }

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
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = articlerepository.GetAll();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 100;

            }
        }

        private void FRM_Articl_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = articlerepository.GetAll();

            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 100;
                
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRapports_Click(object sender, EventArgs e)
        {
            new FRM_service().Show();
            Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            var selectID = dataGridView1.CurrentCell.Value.ToString();

            Form modelBackground = new Form();
            using (FRM_Modify_Article model = new FRM_Modify_Article(selectID))
            {
                modelBackground.StartPosition = FormStartPosition.Manual;
                modelBackground.FormBorderStyle = FormBorderStyle.None;
                modelBackground.Opacity = 0.50;
                modelBackground.BackColor = Color.Black;
                modelBackground.Size = this.Size;
                modelBackground.Location = this.Location;
                modelBackground.ShowInTaskbar = false;
                modelBackground.Show();
                model.Owner = modelBackground;

                panrentX = this.Location.X;

                model.ShowDialog();
                modelBackground.Dispose();

            }
        }
    }
}




