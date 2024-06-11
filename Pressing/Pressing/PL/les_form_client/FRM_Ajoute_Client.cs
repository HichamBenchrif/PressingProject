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

namespace Pressing.PL.les_form_client
{
    public partial class FRM_Ajoute_Client : Form
    {
        ClientRepository clientrepository = new ClientRepository();
        public FRM_Ajoute_Client()
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

        private void FRM_Ajoute_Client_Load(object sender, EventArgs e)
        {
            //id 
            label9.Text = clientrepository.GenerateIDClient();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.IsEmpty() || textBox3.IsEmpty() || textBox5.IsEmpty() || textBox1.IsEmpty())
            {
                MessageBox.Show("Veuillez saisir les informations requises");
            }
            else
            {
                var ID_Cli= label9.Text;
                var Name = textBox2.Text;
                var Prenom = textBox3.Text;
                var tele = textBox5.Text;
                var Adress = textBox1.Text;

                var repository = new ClientRepository();
                repository.Create(ID_Cli, Name,Prenom, tele, Adress);
                MessageBox.Show("Créé avec succès");
                Close();

            }
        }
    }
}
