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

namespace Pressing.PL
{
    public partial class FRM_Articl : Form
    {
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Close();
        }

        public static int parentX, parentY;
        private void button7_Click(object sender, EventArgs e)
        {
           
            //تحريك الفورم
            Form nodalBackground = new Form();
            using (FRM_Ajoute_Articl modal = new FRM_Ajoute_Articl())
            {
                nodalBackground.FormBorderStyle = FormBorderStyle.None;
                nodalBackground.Opacity = .50d;
                nodalBackground.BackColor = Color.Black;
                nodalBackground.Size = this.Size;
                nodalBackground.Location = this.Location;
                nodalBackground.ShowInTaskbar = false;
                nodalBackground.Show();
                modal.Owner = nodalBackground;

                parentX = this.Location.X;
                parentY = this.Location.Y;

                modal.ShowDialog();
                nodalBackground.Dispose();
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

        private void button2_Click(object sender, EventArgs e)
        {
            new FRM_Menu().Show();
            Close();
        }
    }
}
