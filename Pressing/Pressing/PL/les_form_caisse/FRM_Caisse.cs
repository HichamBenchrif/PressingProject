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
using Pressing.PL.Les_form_services;

namespace Pressing.PL.les_form_caisse
{
    public partial class FRM_Caisse : Form 
    {
        //baserepository db = new baserepository();
        
        CategorieRepository categorierepository = new CategorieRepository();
        ArticlRepository articlerepository = new ArticlRepository();
        ClientRepository clientrepository = new ClientRepository();

        private string SelectedItem;
        private string SelectedService;
        private Color defaultButtonColor;

        public FRM_Caisse()
        {
            InitializeComponent( );
            PNL_Menu.Visible = false;

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
            //combobox affiche client
            comboBox2.DataSource = clientrepository.selctBox3();
            comboBox2.ValueMember = "ID_CLIENT";
            comboBox2.DisplayMember = "Name";
            // menu mghadix tkon khdama
            PNL_Menu.Visible = false;
            //// lform ghadi y3mr bhadi 
            //dataGridView1.DataSource = articlerepository.GetAll();
            //
            dataGridView2.Columns.Add("Column 1", "produit");
            dataGridView2.Columns.Add("Column 2", "service");
            //
            defaultButtonColor = btn_tshirt.BackColor;

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
            //CategorieRepository obj = comboBox1.SelectedItem as CategorieRepository;
            //if(obj != null)
            //{
                
            //}
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //combobox affiche client
            comboBox1.DataSource = categorierepository.selctBox();
            comboBox1.ValueMember = "ID_CATE";
            comboBox1.DisplayMember = "name";
        }

        private void btnRapports_Click(object sender, EventArgs e)
        {
            new FRM_service().Show();
            Close();
        }

        private void btn_ajt_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SelectedItem)&& !string.IsNullOrEmpty(SelectedService))
            {
                int rowIndex = dataGridView2.Rows.Add();
                DataGridViewRow row = dataGridView2.Rows[rowIndex];
                row.Cells[0].Value = SelectedItem;
                row.Cells[1].Value = SelectedService;
                SelectedItem = string.Empty;
                SelectedService = string.Empty;
                btn_rep.BackColor = defaultButtonColor;
                btn_tshirt.BackColor = defaultButtonColor;


            }
            else
            {
                MessageBox.Show("please select an item first");
            }
        }

        private void btn_tshirt_Click(object sender, EventArgs e)
        {
            SelectedItem = "T-Shirt";
            //MessageBox.Show("t-shirt selected");
            btn_tshirt.BackColor = Color.LightBlue;
            btn_rep.BackColor = defaultButtonColor;
        }

        private void btn_rep_Click(object sender, EventArgs e)
        {
            SelectedService = "repassage";
            //MessageBox.Show("repassage select");
            btn_rep.BackColor = Color.LightBlue;
            btn_tshirt.BackColor = defaultButtonColor;
        }
    }
}
