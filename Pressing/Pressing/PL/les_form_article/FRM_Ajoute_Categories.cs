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
using Pressing.DAL.BaseRepository;
using Pressing.BL.Extensions;

namespace Pressing.PL.les_form_article
{
    public partial class FRM_Ajoute_Categories : Form
    {
        CategorieRepository categorierepository = new CategorieRepository();
       
        
        public FRM_Ajoute_Categories()
        {
            InitializeComponent();

            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.Top = 0;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
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
        
        private void FRM_Ajoute_Categories_Load(object sender, EventArgs e)
        {
            //ID
            label4.Text = categorierepository.GenerateIDCategorie();
            //
            this.Location = new Point(FRM_Categories.panrentX = 460);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if ( textBox5.IsEmpty())
            {
                MessageBox.Show("Veuillez saisir les informations requises");
            }
            else
            {
                var ID_cat = label4.Text;
                var Name = textBox5.Text;
               
                var repository = new CategorieRepository();
                repository.Create(ID_cat , Name);
                MessageBox.Show("Créé avec succès");
                Close();

            }
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
