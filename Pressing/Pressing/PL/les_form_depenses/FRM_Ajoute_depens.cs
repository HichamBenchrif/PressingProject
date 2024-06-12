using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pressing.PL.les_form_depenses
{
    public partial class FRM_Ajoute_depens : Form
    {
        public FRM_Ajoute_depens()
        {
            InitializeComponent();
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.Top = 0;
        }
        
        private void FRM_Ajoute_depens_Load(object sender, EventArgs e)
        {
            this.Location = new Point(FRM_Depenses.panrentX = 360);
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
    }
}
