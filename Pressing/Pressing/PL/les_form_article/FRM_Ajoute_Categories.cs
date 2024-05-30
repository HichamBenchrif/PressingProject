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
        baserepository db = new baserepository();
        
        public FRM_Ajoute_Categories()
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

        private void FRM_Ajoute_Categories_Timer_Tick(object sender, EventArgs e)
        {

            
            
        }
        
        private void FRM_Ajoute_Categories_Load(object sender, EventArgs e)
        {
            textBox1.Text = categorierepository.GenerateIDCategorie();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.IsEmpty() || textBox5.IsEmpty())
            {
                MessageBox.Show("Please fill the required textboxes");
            }
            else
            {
                var ID = textBox1.Text;
                var STG = textBox5.Text;
               
                var repository = new CategorieRepository();
                repository.Create(ID, STG, ABSDate);
                MessageBox.Show("this creation succefly");
            }

        }
    }
}
