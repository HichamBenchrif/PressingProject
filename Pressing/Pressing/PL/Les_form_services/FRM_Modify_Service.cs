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

namespace Pressing.PL.Les_form_services
{
    public partial class FRM_Modify_Service : Form
    {
        ServiceRepository servicerepository = new ServiceRepository();
        string id;
        SERVICE service = new SERVICE();
        
        public FRM_Modify_Service(string id)
        {
            InitializeComponent();
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.Top = 0;

            this.id = id;
        }

        private void timer_service_modify_Tick(object sender, EventArgs e)
        {
            if (Opacity >= 1)
            {
                timer_service_modify.Stop();
            }
            else
            {
                Opacity += 0.03;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            service.LIB_SERVICE = textBox5.Text;
            servicerepository.Update(id, service);
            MessageBox.Show("This Modification succefly");
        }

        private void FRM_Modify_Service_Load(object sender, EventArgs e)
        {
            //
            this.Location = new Point(FRM_service.panrentX = 460);
            //
            try
            {
                var obj = servicerepository.GetById(id);
                service = obj;

                label4.Text = obj.ID_SERVICE;
                textBox5.Text = obj.LIB_SERVICE;
            }
            catch (Exception)
            {
                MessageBox.Show("seleced id please ", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
