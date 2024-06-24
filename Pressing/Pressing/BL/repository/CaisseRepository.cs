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
    }
}
