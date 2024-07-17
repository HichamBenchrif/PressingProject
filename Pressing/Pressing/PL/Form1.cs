using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using Pressing.PL;
namespace Pressing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //this.Height = Screen.PrimaryScreen.Bounds.Height;
            //this.Top = 0;
        }
        SqlConnection conn = new SqlConnection(@"Data Source=PC_\SQLEXPRESS;Initial Catalog=MLR1;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username, user_password;
            username = txtusername.Text;
            user_password = txtpassword.Text;

            try
            {
                string querry = "SELECT * FROM Login WHERE username = '"+txtusername.Text+"' AND password = '"+txtpassword.Text+"'";
            SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);
                if(dtable.Rows.Count > 0)
                {
                    username = txtusername.Text;
                    user_password = txtpassword.Text;
                //FRM_Menu frm_menu = new FRM_Menu();
                //frm_menu.Show();
                this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid login details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtusername.Clear();
                    txtpassword.Clear();
                    //to forus username 
                    txtusername.Focus();
                 }
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtusername.Clear();
            txtpassword.Clear();

            txtusername.Focus();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
