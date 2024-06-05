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
        
        private void FRM_Ajoute_Articl_Timer_Tick(object sender, EventArgs e)
        {
            //جزء من تحريك الفورم "التوقيت"ه 
            if (Opacity >= 1)
            {
                FRM_Ajoute_Articl_Timer.Stop();
            }
            else
            {
                Opacity += .06 ;

            }
            int y = FRM_Articl.parentY += 3;
            this.Location = new Point(FRM_Articl.parentX + 515, y);
            if(y >= i)
            {
                FRM_Ajoute_Articl_Timer.Stop();
            }
        }
        //جزء من تحريك الفورم 

        int i;
        private static int parentY, parentX ;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.IsEmpty() || textBox5.IsEmpty() || textBox2.IsEmpty() || textBox3.IsEmpty() || comboBox1.IsEmptyCombobox())
            {
                MessageBox.Show("Veuillez saisir les informations requises");
            }
            else
            {
                var ID_art = textBox1.Text;
                var Combo = comboBox1.SelectedItem;
                var Name = textBox5.Text;
                var Repasag = textBox2.Text;
                var Lessiv = textBox3.Text;

                var repository = new ArticlRepository();
                repository.Create(ID_cat, Name);
                MessageBox.Show("Créé avec succès");
                Close();

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int selectedIndex = comboBox1.SelectedIndex;
            //int selectVal = (int)comboBox1.SelectedValue;
            //ComboBoxExtensions selectedCar = (ComboBoxExtensions)comboBox1.SelectedItem;
            //MessageBox.Show(String.Format("Index: [{0}] CarName={1}; Value={2}", selectedIndex, selectedCar.Text, selectVal));
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
            i = FRM_Ajoute_Articl.parentY = 220;
            //this.Location = new Point(FRM_Ajoute_Articl.parentX = 515, FRM_Ajoute_Articl.parentY = 220);


            textBox1.Text = articlrepositry.GenerateIDArticl();
        }
    }
}
