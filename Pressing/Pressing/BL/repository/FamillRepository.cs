using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pressing.DAL.BaseRepository;
using Pressing.DAL;

namespace Pressing.BL.repository
{
    class FamillRepository : baserepository
    {
        public string GenerateIDFamill()
        {
            var count = db.FAMILLs.Count();
            if (count == 0)
                return "F-1";
            var ids = db.FAMILLs.Select(x => x.N_FAMILL).ToList();
            var numbres = ids.Select(x => int.Parse(x.Substring(2, x.Length - 2)));
            var max = numbres.Max();
            var newID = "F-" + (max + 1);
            return newID;

        }
        public dynamic GetAll()
        {
            var result = (from F in db.FAMILLs
                          select new { F.N_FAMILL, F.LIB_FAMILL }).ToList();

            return result;
        }
        public void Create(string id, string name_famil)
        {
            var famill = new FAMILL();
            famill.N_FAMILL = id;
            famill.LIB_FAMILL = name_famil;
            db.FAMILLs.Add(famill);
            db.SaveChanges();
        }
        public dynamic Search(string value)
        {
            

            return (from C in db.CATEGORIE_ARTILCLE
                    where C.ID_CATE.Contains(value) ||
                          C.LIB_CAT_ART.Contains(value)
                    select new { C.ID_CATE, C.LIB_CAT_ART }).ToList();
        }
    }
}
