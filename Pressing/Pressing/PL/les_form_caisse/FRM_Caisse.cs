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
using Pressing.BL.Extensions;
using Pressing.DAL.BaseRepository;

namespace Pressing.PL.les_form_caisse
{
    public partial class FRM_Caisse : Form 
    {
        baserepository db = new baserepository();
        
        CategorieRepository categorierepository = new CategorieRepository();
        ArticlRepository articlerepository = new ArticlRepository();

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
            //combobox affiche category
            comboBox1.DataSource = categorierepository.selctBox();
            comboBox1.ValueMember = "ID_CATE";
            comboBox1.DisplayMember = "name";
            // menu mghadix tkon khdama
            PNL_Menu.Visible = false;
            // combobox ghadi y3mr bhadi 
            dataGridView1.DataSource = articlerepository.GetAll();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Recherche")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            CategorieRepository obj = comboBox1.SelectedItem as CategorieRepository;
            if(obj != null)
            {
                
            }
        }
    }
}
