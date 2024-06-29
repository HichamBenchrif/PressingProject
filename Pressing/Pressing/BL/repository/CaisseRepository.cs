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
                          select new { A.LIB_ARTICLE, A.IMAGE }).ToList();

            return result;
        }

        public dynamic GetByCategoryName(string CategoryName)
        {
            var result = (from A in db.ARTICLEs
                          where A.CATEGORIE_ARTILCLE.LIB_CAT_ART == CategoryName
                          select new { A.LIB_ARTICLE, A.IMAGE }).ToList();

            return result;
        }
    }
}
