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

namespace Pressing.PL.les_form_article
{
    public partial class FRM_Modify_Category : Form
    {
        CategorieRepository categorierepository = new CategorieRepository();
        string id;
        CATEGORIE_ARTILCLE category_article = new CATEGORIE_ARTILCLE();
        

        public FRM_Modify_Category( string id)
        {

            InitializeComponent();
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.Top = 0;

            this.id = id;
            
        }

        

        private void FRM_Modify_Categories_Timer_Tick(object sender, EventArgs e)
        {
            if (Opacity >= 1)
            {
                FRM_Modify_Categories_Timer.Stop();
            }
            else
            {
                Opacity += 0.03;
            }
        }

        private void FRM_Modify_Category_Load(object sender, EventArgs e)
        {
            ////ID
            //label4.Text = categorierepository.GenerateIDCategorie();
            //
            this.Location = new Point(FRM_Categories.panrentX = 460);
            //
            var obj = categorierepository.GetById(id);
            category_article = obj;

            label4.Text = obj.ID_CATE;
            textBox5.Text = obj.LIB_CAT_ART;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            category_article.LIB_CAT_ART = textBox5.Text;
            categorierepository.Update(id, category_article);
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
