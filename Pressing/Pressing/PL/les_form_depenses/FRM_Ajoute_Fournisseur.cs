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
using Pressing.BL.Extensions;

namespace Pressing.PL.les_form_depenses
{
    public partial class FRM_Ajoute_Fournisseur : Form
    {
        FournisseurRepository fournisseurrepository = new FournisseurRepository();
        public FRM_Ajoute_Fournisseur()
        {
            InitializeComponent();
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.Top = 0;
        }

        private void FRM_Ajoute_Fournisseur_Load(object sender, EventArgs e)
        {
            //ID
            label13.Text = fournisseurrepository.GenerateIDfournisseur();
            //
            this.Location = new Point(FRM_Fournisseur.panrentX = 460);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.IsEmpty() || textBox7.IsEmpty() || textBox6.IsEmpty())
            {
                MessageBox.Show("Veuillez saisir les informations requises");
            }
            else
            {
                var ID_fr = label13.Text;
                var prenom = textBox4.Text;
                var nom = textBox7.Text;
                var tele = textBox6.Text;
                var repository = new FournisseurRepository();
                repository.Create(ID_fr, prenom, nom, tele);
                MessageBox.Show("Créé avec succès");
                //ID
                label13.Text = fournisseurrepository.GenerateIDfournisseur();
                //
                textBox4.Clear();
                textBox7.Clear();
                textBox6.Clear();
            }
        }

        private void timerdepens_Tick(object sender, EventArgs e)
        {
            if (Opacity >= 1)
            {
                timerdepens.Stop();
            }
            else
            {
                Opacity += 0.03;
            }
        }
    }
}
