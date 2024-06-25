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
using Pressing.PL.les_form_article;
using Pressing.PL.les_form_caisse;
using Pressing.PL.les_form_client;
using Pressing.PL.les_form_depenses;
using Pressing.DAL.BaseRepository;
using Pressing.DAL;
using Pressing.BL.repository;
using Pressing.PL.Les_form_services;

namespace Pressing.PL.les_form_client
{
    public partial class FRM_Client : Form
    {
        ClientRepository clientrepository = new ClientRepository();
        public FRM_Client()
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

        private void button2_Click(object sender, EventArgs e)
        {
            
            //new FRM_Menu().Show();
            Close();
        }

        private void btnProduits_Click(object sender, EventArgs e)
        {
            new FRM_Articl().Show();
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

        private void btnClients_Click(object sender, EventArgs e)
        {

        }
        public static int panrentX;

        private void button7_Click(object sender, EventArgs e)
        {
            // إنشاء الفورم الجديدة
            Form modelBackground = new Form();
            using (FRM_Ajoute_Client model = new FRM_Ajoute_Client())
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

        private void FRM_Client_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clientrepository.GetAll();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clientrepository.GetAll();

        }

        private void btnRapports_Click(object sender, EventArgs e)
        {
            new FRM_service().Show();
            Close();

        }
    }
}
