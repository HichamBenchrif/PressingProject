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
using Pressing.DAL;


namespace Pressing.PL.les_form_depenses
{
    public partial class FRM_Modify_Fournisseur : Form
    {
        FournisseurRepository fournisseurrepository = new FournisseurRepository();
        FOURNISSEUR fournisseur = new FOURNISSEUR();
        string id;
        public FRM_Modify_Fournisseur(string id)
        {
            InitializeComponent();
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.Top = 0;

            this.id = id;
        }

        private void FRM_Modify_Fournisseur_Load(object sender, EventArgs e)
        {
            //
            this.Location = new Point(FRM_Fournisseur.panrentX = 460);
            //fournisseur
            var obj = fournisseurrepository.GetById(id);
            fournisseur = obj;

            label13.Text = obj.ID_FR;
            textBox4.Text = obj.PRN_FR;
            textBox7.Text = obj.NOM_FR;
            textBox6.Text = obj.TEL_FR;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fournisseur.PRN_FR = textBox4.Text;
            fournisseur.NOM_FR = textBox7.Text;
            fournisseur.TEL_FR = textBox6.Text;
            fournisseurrepository.Update(id, fournisseur);
            MessageBox.Show("This Modification succefly");
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
