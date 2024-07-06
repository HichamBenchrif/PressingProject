using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pressing.BL.Extensions;
using Pressing.BL.repository;

namespace Pressing.PL.les_form_depenses
{
    public partial class FRM_Ajoute_depens : Form
    {
        DepensRepository depensrepository = new DepensRepository();
        FournisseurRepository fournisseurrepository = new FournisseurRepository();
        public FRM_Ajoute_depens()
        {
            InitializeComponent();
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.Top = 0;
        }
        
        private void FRM_Ajoute_depens_Load(object sender, EventArgs e)
        {
            this.Location = new Point(FRM_Depenses.panrentX = 460);
            //
            label4.Text = depensrepository.GenerateIDDepens();
            
            //combobox affiche fournisseur
            var data = fournisseurrepository.selctBox();
            //
            //foreach(var item in data)
            //{
            //    Console.WriteLine($"FullName:{item.FullName},ID_FR: {item.ID_FR}");
            //}

            comboBox1.DataSource = null;
            comboBox1.DisplayMember = string.Empty;
            comboBox1.ValueMember = string.Empty;

            comboBox1.DataSource = data;
            comboBox1.ValueMember = "ID_FR";
            comboBox1.DisplayMember = "FullName";
            

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox5.IsEmpty() || textBox1.IsEmpty() || textBox2.IsEmpty())
            {
                MessageBox.Show("Veuillez saisir les informations requises");
            }
            else
            {
                var ID = label4.Text;
                var Fournisseur = comboBox1.SelectedValue.ToString();
                var Name = textBox5.Text;
                var Date =DateTime.Parse (dateTimePicker1.Text);
                var Qntite = short.Parse(textBox1.Text);
                var Prix = decimal.Parse(textBox2.Text);
                var repository = new DepensRepository();
                repository.CreateDepens(ID,Fournisseur, Name, Date, Qntite, Prix);
                MessageBox.Show("Créé avec succès");
                Close();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //if (textBox4.IsEmpty() || textBox7.IsEmpty() || textBox6.IsEmpty())
            //{
            //    MessageBox.Show("Veuillez saisir les informations de fournisseur");
            //}
            //else
            //{
            //    var ID = label13.Text;
            //    var Prenom = textBox4.Text;
            //    var Nom = textBox7.Text;
            //    var Telephon = textBox6.Text;

            //    var repository = new DepensRepository();
            //    repository.Create(ID,Prenom ,Name , Telephon);
            //    MessageBox.Show("Créé avec succès");
            //    //
            //    label13.Text = depensrepository.GenerateIDfournisseur();
            //    textBox4.Clear();
            //    textBox7.Clear();   
            //    textBox6.Clear();
            //    //combobox affiche fournisseur
            //    comboBox1.DataSource = depensrepository.selctBox();
            //    comboBox1.ValueMember = "ID_FR";
            //    comboBox1.DisplayMember = "FullName";


            //}
        }

        //private void pictureBox1_Click(object sender, EventArgs e)
        //{
        //    Close();
        //}
    }
}
