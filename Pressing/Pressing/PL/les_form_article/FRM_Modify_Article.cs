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
using System.IO;
namespace Pressing.PL.les_form_article
{
    public partial class FRM_Modify_Article : Form
    {
        ArticlRepository articlerepository = new ArticlRepository();
        CategorieRepository categoryrepository = new CategorieRepository();
        FamillRepository famillrepository = new FamillRepository();
        string id;
        ARTICLE article = new ARTICLE();

        public FRM_Modify_Article(string id)
        {
            InitializeComponent();
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.Top = 0;

            this.id = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            article.LIB_ARTICLE = textBox5.Text;
            articlerepository.Update(id, article);
            MessageBox.Show("This Modification succefly");
        }

        private void FRM_Modify_Article_Timer_Tick(object sender, EventArgs e)
        {
            
        }

        private void FRM_Modify_Article_Load(object sender, EventArgs e)
        {
            this.Location = new Point(FRM_Articl.panrentX = 460);
            //
            //combobox affiche category
            comboBox1.DataSource = categoryrepository.selctBox();
            comboBox1.ValueMember = "ID_CATE";
            comboBox1.DisplayMember = "name";
            //combobox affiche famill
            comboBox2.DataSource = famillrepository.selctBox();
            comboBox2.ValueMember = "N_FAMILL";
            comboBox2.DisplayMember = "name";

            var obj = articlerepository.GetById(id);
            article = obj;


            label9.Text = obj.REF_ARTICLE;
            comboBox2.SelectedValue = obj.N_FAMILL;
            comboBox1.SelectedValue = obj.ID_CATE;
            textBox5.Text = obj.LIB_ARTICLE;
            textBox2.Text = obj.PRIX_REPASSAGE.ToString();
            textBox3.Text = obj.PRIX_LESSIVE.ToString();
            var ms = new System.IO.MemoryStream(obj.IMAGE);
            imagebox.Image = Image.FromStream(ms);


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

        private void button3_Click(object sender, EventArgs e)
        {
            string imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;

                    imagebox.ImageLocation = imageLocation;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private byte[] ImageToByteArray (Image imageIn)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            article.N_FAMILL = comboBox2.SelectedValue.ToString();
            article.ID_CATE = comboBox1.SelectedValue.ToString();
            article.LIB_ARTICLE = textBox5.Text;
            article.PRIX_REPASSAGE = decimal.Parse( textBox2.Text);
            article.PRIX_LESSIVE = decimal.Parse(textBox3.Text);

            article.IMAGE = ImageToByteArray(imagebox.Image);

           


            articlerepository.Update(id, article);
            MessageBox.Show("This Modification succefly");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
