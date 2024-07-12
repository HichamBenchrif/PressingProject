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

namespace Pressing.PL.les_form_depenses
{
    public partial class FRM_Modify_Depens : Form
    {
        DepensRepository depensrepository = new DepensRepository();
        string id;
        
       
        DÉPENSES_ET_ENTRÉES depens = new DÉPENSES_ET_ENTRÉES();
        public FRM_Modify_Depens(string id )
        {
            InitializeComponent();
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.Top = 0;

            this.id = id;
        }

        private void FRM_Modify_Depens_Load(object sender, EventArgs e)
        {
            this.Location = new Point(FRM_Depenses.panrentX = 460);
            

            
            //depnes
            var obj1 = depensrepository.GetByIdDepens(id);
            depens = obj1;

            label4.Text = obj1.ID_DÉPE_ENTR;
            comboBox1.Text= obj1.ID_FR;
            textBox5.Text = obj1.LIB_DEPENS;
            dateTimePicker1.Text = obj1.DATE.ToString() ;
            textBox1.Text = obj1.Q.ToString();
            textBox2.Text = obj1.PRIX.ToString();




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

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            depens.ID_FR = comboBox1.SelectedValue.ToString();
            depens.LIB_DEPENS = textBox5.Text;
            depens.DATE = DateTime.Parse(dateTimePicker1.Text);
            depens.Q = short.Parse(textBox1.Text);
            depens.PRIX = decimal.Parse(textBox2.Text);
            depensrepository.UpdateDepens(id, depens);
            MessageBox.Show("This Modification succefly");
        }
    }
}
