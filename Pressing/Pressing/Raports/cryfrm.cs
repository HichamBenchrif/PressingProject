using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pressing.DAL.BaseRepository;
using Pressing.DAL;

namespace Pressing.Raports
{
    public partial class cryfrm : Form
    {
        mbarkEntities db = new mbarkEntities();
        private string id_recu;
        public cryfrm(string id)
        {
            InitializeComponent();
            id_recu = id;
        }

        private void cryfrm_Load(object sender, EventArgs e)
        {
            //var db = new baserepository();
            var clt = (from x in db.CLIENTs
                       join R in db.BON_RECEPTION on x.ID_CLIENT equals R.ID_CLIENT
                       join Recu in db.B_R on R.ID_BON_R equals Recu.ID_BON_R
                       where R.ID_BON_R == id_recu
                       orderby R.ID_BON_R
                       select new { nomclient = x.NOM_CLT, prenomclient = x.PRENOM_CLT, idrecu = R.ID_BON_R }).ToList();
            CrystalReport1 report = new CrystalReport1();
            report.SetDataSource(clt );
            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.RefreshReport();
        }
    }
}
