using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pressing.DAL.BaseRepository;
using Pressing.DAL;

namespace Pressing.BL.repository
{
    public class CaisseRepository : baserepository
    {
        public dynamic Get()
        {
            var result = (from A in db.ARTICLEs
                          select new { A.REF_ARTICLE,  A.LIB_ARTICLE, A.IMAGE, A.PRIX_LESSIVE, A.PRIX_REPASSAGE }).ToList();

            return result;
        }
        public dynamic Search(string value)
        {
           
            return (from C in db.BON_RECEPTION
                    where C.ID_BON_R.Contains(value)
                    select new { C.ID_BON_R }).ToList();
        }

        public dynamic GetByCategoryName(string CategoryName)
        {
            var result = (from A in db.ARTICLEs
                          where A.CATEGORIE_ARTILCLE.LIB_CAT_ART == CategoryName
                          select new { A.REF_ARTICLE, A.LIB_ARTICLE, A.IMAGE }).ToList();

            return result;
        }
        public dynamic GetByServiceName(string ServiceName, string articleID)
        {
            var result = (from B in db.B_R
                          join S in db.SERVICEs on B.ID_SERVICE equals S.ID_SERVICE
                          join A in db.ARTICLEs on B.REF_ARTICLE equals A.REF_ARTICLE
                          where S.LIB_SERVICE == ServiceName && B.REF_ARTICLE == articleID
                          select new { A.PRIX_REPASSAGE, A.PRIX_LESSIVE }).ToList();

            return result;
        }

        public ARTICLE GetArticleByID(string articleID)
        {
            var result = (from A in db.ARTICLEs
                          where A.REF_ARTICLE == articleID
                          select A).FirstOrDefault();

            return result;
        }
    }
}
