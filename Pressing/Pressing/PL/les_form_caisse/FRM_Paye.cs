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

namespace Pressing.PL.les_form_caisse
{
    public partial class FRM_Paye : Form
    {
        CommandeRepository commanderepository = new CommandeRepository();

        public string Article { get; set; }
        public string Color { get; set; }
        public string Service { get; set; }
        public string Quntite { get; set; }
        public string Remis { get; set; }
        public string MontantTotal { get; set; }
        public string Clients { get; set; }
        public FRM_Paye()
        {
            InitializeComponent();
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.Top = 0;
        }

        private void FRM_Paye_Load(object sender, EventArgs e)
        {
            this.Location = new Point(FRM_Caisse.panrentX = 460);
            textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
            label10.Text = commanderepository.GenerateID();
            label3.Text = Clients;
            label5.Text = MontantTotal;
            textBox1.Text = MontantTotal.Replace(" DH","").Trim();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_ajt_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CalcuateReste();
        }
        private void CalcuateReste()
        {
            decimal total = 0;
            decimal paye = 0;
            if (decimal.TryParse(label5.Text.Replace(" DH", "").Trim(), out total) && decimal.TryParse(textBox1.Text, out paye))
            {
                decimal reste = total - paye;
                label9.Text = reste.ToString();
            }
            else
            {
                MessageBox.Show("entrée invalide");
            }
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
    }
}
