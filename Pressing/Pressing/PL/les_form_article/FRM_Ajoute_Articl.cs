using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pressing.PL.les_form_article;
using Pressing.BL.repository;
using Pressing.BL.Extensions;
using System.Drawing.Imaging;


namespace Pressing.PL
{
    public partial class FRM_Ajoute_Articl : Form
    {
        ArticlRepository articlrepositry = new ArticlRepository();
        CategorieRepository categorierepository = new CategorieRepository();
        public FRM_Ajoute_Articl()
        {
            InitializeComponent();

            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        
        


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ( textBox5.IsEmpty() || textBox2.IsEmpty() || textBox3.IsEmpty() || comboBox1.IsEmptyCombobox()  )
            {
                MessageBox.Show("Veuillez saisir les informations requises");
            }
            else
            {
                var ID_art = label9.Text;
                var Combo = comboBox1.SelectedValue.ToString() ;
                var Name = textBox5.Text;
                var Repasag = decimal.Parse( textBox2.Text);
                var Lessiv =decimal.Parse( textBox3.Text);
                var Image =image.Image;

                var repository = new ArticlRepository();
                repository.Create(ID_art, Name, Combo, Repasag, Lessiv, Image);
                MessageBox.Show("Créé avec succès");
                Close();

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";

                if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                     imageLocation = dialog.FileName;

                    image.ImageLocation = imageLocation;
                }
            }
            catch(Exception)
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void FRM_Ajoute_Articl_Load(object sender, EventArgs e)
        {

            //id dyal articl
            label9.Text = articlrepositry.GenerateIDArticl();
            //combobox affiche
            comboBox1.DataSource =  categorierepository.selctBox();
            comboBox1.ValueMember = "ID_CATE";
            comboBox1.DisplayMember = "name";

        }
    }
}
