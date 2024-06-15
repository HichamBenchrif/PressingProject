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

namespace Pressing.PL.les_form_depenses
{
    public partial class FRM_Ajoute_depens : Form
    {
        DepensRepository depensrepository = new DepensRepository();

        public FRM_Ajoute_depens()
        {
            InitializeComponent();
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.Top = 0;
        }
        
        private void FRM_Ajoute_depens_Load(object sender, EventArgs e)
        {
            this.Location = new Point(FRM_Depenses.panrentX = 360);
            //
            label4.Text = depensrepository.GenerateIDDepens();
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

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (textBox5.IsEmpty() || textBox1.IsEmpty() || textBox2.IsEmpty()  )
            //{
            //    MessageBox.Show("Veuillez saisir les informations requises");
            //}
            //else
            //{
            //    var ID = label4.Text;
            //    var Name_produite = textBox5.Text;
            //    var Qntite =int.Parse( textBox1.Text);
            //    var Prix = decimal.Parse( textBox2.Text);

            //    var Date = DateTime.Parse( dateTimePicker1.Text);
            //    var Prenom = textBox4.Text;
            //    var Nom = textBox7.Text;
            //    var Telephon = textBox6.Text;

            //    var repository = new DepensRepository();
            //    repository.Create(ID, Name_produite, Qntite, Prix, Date, Prenom, Nom, Telephon);
            //    MessageBox.Show("Créé avec succès");
            //    Close();

            //}
        }
    }
}
