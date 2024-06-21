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

namespace Pressing.PL.Les_form_services
{
    public partial class FRM_Ajoute_Service : Form
    {
        ServiceRepository servicerepository = new ServiceRepository();

        public FRM_Ajoute_Service()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox5.IsEmpty())
            {
                MessageBox.Show("Veuillez saisir les informations requises");
            }
            else
            {
                var ID_service = label4.Text;
                var Name = textBox5.Text;

                var repository = new ServiceRepository();
                repository.Create(ID_service, Name);
                MessageBox.Show("Créé avec succès");

                label4.Text = servicerepository.GenerateIDService();
                textBox5.Clear();

            }
        }

        private void FRM_Ajoute_Service_Load(object sender, EventArgs e)
        {
            this.Location = new Point(FRM_service.panrentX = 460);
        }

        private void FRM_Ajoute_Categories_Timer_Tick(object sender, EventArgs e)
        {
            if (Opacity >= 1)
            {
                FRM_Ajoute_Categories_Timer.Stop();
            }
            else
            {
                Opacity += 0.03;
            }
        }
    }
}
