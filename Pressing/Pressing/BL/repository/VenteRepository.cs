using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pressing.DAL.BaseRepository;

namespace Pressing.BL.repository
{
    class VenteRepository : baserepository
    {
        public dynamic GetAll()
        {
            var result = (from C in db.BON_RECEPTION
                          join s in db.CLIENTs on C.ID_CLIENT equals s.ID_CLIENT
                          select new { ID = C.ID_BON_R, Date = C.DATE_BR, Client = s.PRENOM_CLT + " " + s.NOM_CLT, MontantTotal = C.MONTANTSTOTAL,Statut = C.STATUT }).ToList();

            return result;
        }
        public string GetTotal()
        {
            var result = (from x in db.BON_RECEPTION
                          group x by x.ID_BON_R).Count().ToString();
            return result;
        }
    }
}
