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
    public partial class FRM_Modify_Famill : Form
    {
        FamillRepository famillrepository = new FamillRepository();
        string id;
        FAMILL famill = new FAMILL();
        public FRM_Modify_Famill( string id )
        {
            InitializeComponent();
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.Top = 0;

            this.id = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            famill.LIB_FAMILL = textBox5.Text;
            famillrepository.Update(id, famill);
            MessageBox.Show("This Modification succefly");
            Close();
        }

        private void Timer_famill_Tick(object sender, EventArgs e)
        {
            if (Opacity >= 1)
            {
                Timer_famill.Stop();
            }
            else
            {
                Opacity += 0.03;
            }
        }

        private void FRM_Modify_Famill_Load(object sender, EventArgs e)
        {
            //
            this.Location = new Point(FRM_Famill.panrentX = 460);
            //
            var obj = famillrepository.GetById(id);
            famill = obj;

            label9.Text = obj.N_FAMILL;
            textBox5.Text = obj.LIB_FAMILL;
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
