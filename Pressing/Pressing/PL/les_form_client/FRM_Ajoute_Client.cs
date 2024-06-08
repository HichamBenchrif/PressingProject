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
    }
}
