using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pressing.BL.Extensions;
using Pressing.BL.repository;


namespace Pressing.PL.les_form_article
{
    public partial class FRM_Ajoute_Famill : Form
    {
        FamillRepository famillrepository = new FamillRepository();
        public FRM_Ajoute_Famill()
        {
            InitializeComponent();
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
            if ( textBox5.IsEmpty())
            {
                MessageBox.Show("Veuillez saisir les informations requises");
            }
            else
            {
                var ID_famil = label9.Text;
                var Name_famil = textBox5.Text;

                var repository = new FamillRepository();
                repository.Create(ID_famil , Name_famil);
                MessageBox.Show("Créé avec succès");
                Close();
                
            }
        }

        private void FRM_Ajoute_Famill_Load(object sender, EventArgs e)
        {
            label9.Text = famillrepository.GenerateIDFamill();
        }
    }
}
