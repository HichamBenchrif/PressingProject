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
        FamillRepository famillrepository = new FamillRepository();

       

        public FRM_Ajoute_Articl()
        {
            InitializeComponent();

            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.Top = 0;
            //
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
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
            try {
                if (checkBox2.Checked)
                {
                    textBox2.Text = null;
                }
                else if (textBox5.IsEmpty() || textBox2.IsEmpty() || textBox3.IsEmpty() || comboBox1.IsEmptyCombobox() || comboBox2.IsEmptyCombobox())
                {

                    MessageBox.Show("Veuillez saisir les informations requises");
                }
                else
                {
                    var ID_art = label9.Text;
                    var comboboxfamill = comboBox2.SelectedValue.ToString();
                    var Comboboxcategory = comboBox1.SelectedValue.ToString();
                    var Name = textBox5.Text;
                    var Repasag = decimal.Parse(textBox2.Text);
                    var Lessiv = decimal.Parse(textBox3.Text);
                    var Image = imagebox.Image;

                    var ms = new System.IO.MemoryStream();

                    Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);



                    var repository = new ArticlRepository();
                    repository.Create(ID_art, comboboxfamill, Comboboxcategory, Name, Repasag, Lessiv, ms.ToArray());
                    MessageBox.Show("Créé avec succès");
                    //id dyal articl
                    label9.Text = articlrepositry.GenerateIDArticl();
                    //combobox affiche category
                    comboBox1.DataSource = categorierepository.selctBox();
                    comboBox1.ValueMember = "ID_CATE";
                    comboBox1.DisplayMember = "name";
                    //combobox affiche famill
                    comboBox2.DataSource = famillrepository.selctBox();
                    comboBox2.ValueMember = "N_FAMILL";
                    comboBox2.DisplayMember = "name";
                    //
                    textBox5.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    imagebox.Image = null;
                }
                

            }
            catch (Exception)
            {
                MessageBox.Show("Quelque chose ne va pas !", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
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

                    imagebox.ImageLocation = imageLocation;
                }
            }
            catch(Exception)
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void FRM_Ajoute_Articl_Load(object sender, EventArgs e)
        {
            this.Location = new Point(FRM_Articl.panrentX = 460);

            //id dyal articl
            label9.Text = articlrepositry.GenerateIDArticl();
            //combobox affiche category
            comboBox1.DataSource =  categorierepository.selctBox();
            comboBox1.ValueMember = "ID_CATE";
            comboBox1.DisplayMember = "name";
            //combobox affiche famill
            comboBox2.DataSource = famillrepository.selctBox();
            comboBox2.ValueMember = "N_FAMILL";
            comboBox2.DisplayMember = "name";

        }

        private void timerarticl_Tick(object sender, EventArgs e)
        {
            if (Opacity >= 1)
            {
                timerarticl.Stop();
            }
            else
            {
                Opacity += 0.03;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
                textBox2.Text = string.Empty;
                textBox2.Enabled = false;
            }
            else
            {
                textBox2.Enabled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
                textBox2.Enabled = true;
            }
        }
    }
}
