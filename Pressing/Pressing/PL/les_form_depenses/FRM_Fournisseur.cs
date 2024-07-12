using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pressing.BL.repository;

namespace Pressing.PL.les_form_depenses
{
    public partial class FRM_Fournisseur : Form
    {
        FournisseurRepository fournisseurrepository = new FournisseurRepository();
        public FRM_Fournisseur()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new FRM_Depenses().Show();
            Close();
        }
        public static int panrentX;
        private void button7_Click(object sender, EventArgs e)
        {
            // إنشاء الفورم الجديدة
            Form modelBackground = new Form();
            using (FRM_Ajoute_Fournisseur model = new FRM_Ajoute_Fournisseur())
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = fournisseurrepository.GetAll();

        }

        private void FRM_Fournisseur_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = fournisseurrepository.GetAll();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var selectID = dataGridView1.CurrentCell.Value.ToString();
            // إنشاء الفورم الجديدة
            Form modelBackground = new Form();
            using (FRM_Modify_Fournisseur model = new FRM_Modify_Fournisseur(selectID))
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
