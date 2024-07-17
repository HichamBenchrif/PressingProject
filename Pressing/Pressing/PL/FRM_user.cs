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

namespace Pressing.PL
{
    public partial class FRM_user : Form
    {
        User_Repository userrepository = new User_Repository();
        public FRM_user()
        {
            InitializeComponent();
        }

        private void FRM_user_Load(object sender, EventArgs e)
        {
            textBox5.Text = userrepository.GenerateID();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.IsEmpty() || textBox2.IsEmpty())
            {
                MessageBox.Show("Veuillez saisir les informations requises");
            }
            else
            {
                var ID = textBox5.Text;
                var username = textBox1.Text;
                var password = textBox2.Text;

                var repository = new User_Repository();
                repository.Create(ID, username,password);
                MessageBox.Show("Créé avec succès");

            }
        }
    }
}
