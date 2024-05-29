using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pressing.PL.les_form_caisse
{
    public partial class FRM_Caisse : Form
    {
        public FRM_Caisse()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (PNL_Menu.Visible == false)
            {
                PNL_Menu.Visible = true;
            }
            else
            {
                PNL_Menu.Visible = false;
            }
        }

        private void panelArticl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FRM_Caisse_Load(object sender, EventArgs e)
        {
            PNL_Menu.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Recherche")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.WhiteSmoke;
            }

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Recherche";
                textBox1.ForeColor = Color.FromArgb(255, 105, 0);
            }
        }
    }
}
