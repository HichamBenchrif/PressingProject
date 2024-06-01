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

namespace Pressing.PL
{
    public partial class FRM_Ajoute_Articl : Form
    {
        ArticlRepository articlrepositry = new ArticlRepository();
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

        }

        private void FRM_Ajoute_Articl_Load(object sender, EventArgs e)
        {
            i = FRM_Ajoute_Articl.parentY = 220;
            //this.Location = new Point(FRM_Ajoute_Articl.parentX = 515, FRM_Ajoute_Articl.parentY = 220);


            textBox1.Text = articlrepositry.GenerateIDArticl();
        }
    }
}
