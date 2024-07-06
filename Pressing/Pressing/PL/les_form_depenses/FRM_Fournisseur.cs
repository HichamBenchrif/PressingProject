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
    public partial class FRM_Fournisseur : Form
    {
        public FRM_Fournisseur()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new FRM_Depenses().Show();
        }
        public static int panrentX;
        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}
