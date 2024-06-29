using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pressing.PL.les_form_caisse;
using Pressing.BL.repository;
using Pressing.PL.les_form_depenses;
using Pressing.PL.les_form_client;
using Pressing.PL.les_form_ventes;


namespace Pressing.PL.Les_form_services
{
    public partial class FRM_service : Form
    {
        ServiceRepository servicerepository = new ServiceRepository();
        public FRM_service()
        {
            InitializeComponent();
        }
        public static int panrentX;
        private void button7_Click(object sender, EventArgs e)
        {
            // إنشاء الفورم الجديدة
            Form modelBackground = new Form();
            using (FRM_Ajoute_Service model = new FRM_Ajoute_Service())
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Tu as vraiment envie de sortir ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new FRM_Caisse().Show();
            Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = servicerepository.GetAll();
        }

        private void FRM_service_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = servicerepository.GetAll();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = servicerepository.Search(textBox1.Text);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Recherche")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Recherche";
                textBox1.ForeColor = Color.FromArgb(255, 105, 0);
                dataGridView1.DataSource = servicerepository.GetAll();
            }
        }

        private void btnDépenses_Click(object sender, EventArgs e)
        {
            new FRM_Depenses().Show();
            Close();
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            new FRM_Client().Show();
            Close();
        }

        private void btnVentes_Click(object sender, EventArgs e)
        {
            new FRM_Ventes().Show();
            Close();
        }

        private void btnProduits_Click(object sender, EventArgs e)
        {
            new FRM_Articl().Show();
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

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var selectID = dataGridView1.CurrentCell.Value.ToString();

            // إنشاء الفورم الجديدة
            Form modelBackground = new Form();
            using (FRM_Modify_Service model = new FRM_Modify_Service(selectID))
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

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                var SelectCellValue = dataGridView1.CurrentCell.Value.ToString();
                DialogResult res = MessageBox.Show("Voullez vous vraiment supprimer cette ligne ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res == DialogResult.OK)
                {
                    servicerepository.Supprim(SelectCellValue);
                    dataGridView1.DataSource = servicerepository.GetAll();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("seleced id please ", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
