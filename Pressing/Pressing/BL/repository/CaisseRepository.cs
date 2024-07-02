using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pressing.DAL.BaseRepository;

namespace Pressing.BL.repository
{
    public class CaisseRepository : baserepository
    {
        public dynamic Get()
        {
            var result = (from A in db.ARTICLEs
                          select new { A.LIB_ARTICLE, A.IMAGE, A.PRIX_LESSIVE, A.PRIX_REPASSAGE }).ToList();

            return result;
        }

        public dynamic GetByCategoryName(string CategoryName)
        {
            var result = (from A in db.ARTICLEs
                          where A.CATEGORIE_ARTILCLE.LIB_CAT_ART == CategoryName
                          select new { A.LIB_ARTICLE, A.IMAGE }).ToList();

            return result;
        }
        public dynamic GetByServiceName(string ServiceName)
        {
            var result = (from B in db.B_R
                          join S in db.SERVICEs on B.ID_SERVICE equals S.ID_SERVICE
                          join A in db.ARTICLEs on B.REF_ARTICLE equals A.REF_ARTICLE
                          where S.LIB_SERVICE == ServiceName
                          select new { A.PRIX_REPASSAGE, A.PRIX_LESSIVE }).ToList();

            return result;
        }

    }
}
