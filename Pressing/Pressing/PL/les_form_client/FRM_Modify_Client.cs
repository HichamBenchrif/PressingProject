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

namespace Pressing.PL.les_form_client
{
    public partial class FRM_Modify_Client : Form
    {
        ClientRepository clientrepository = new ClientRepository();
        string id;
        CLIENT client = new CLIENT();
        public FRM_Modify_Client(string id)
        {
            InitializeComponent( );
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.Top = 0;

            this.id = id;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timerclient_Tick(object sender, EventArgs e)
        {
            if (Opacity >= 1)
            {
                timerclient.Stop();
            }
            else
            {
                Opacity += 0.03;
            }
        }

        private void FRM_Modify_Client_Load(object sender, EventArgs e)
        {
            //
            this.Location = new Point(FRM_Client.panrentX = 460);
            //
            var obj = clientrepository.GetById(id);
            client = obj;

            try
            {
                label9.Text = obj.ID_CLIENT;
            textBox2.Text = obj.NOM_CLT;
            textBox3.Text = obj.PRENOM_CLT;
            textBox5.Text = obj.TEL_CLT;
            textBox1.Text = obj.ADRESSE;
            }
            catch (Exception)
            {
                MessageBox.Show("seleced id please ", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.NOM_CLT = textBox2.Text;
            client.PRENOM_CLT = textBox3.Text;
            client.TEL_CLT = textBox5.Text;
            client.ADRESSE = textBox1.Text;


            clientrepository.Update(id, client);
            MessageBox.Show("This Modification succefly");
            Close();
        }
    }
}
