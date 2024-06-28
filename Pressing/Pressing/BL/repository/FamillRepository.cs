using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pressing.DAL.BaseRepository;
using Pressing.DAL;

namespace Pressing.BL.repository
{
     public class FamillRepository : baserepository
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
                          select new { ID=F.N_FAMILL, Name= F.LIB_FAMILL }).ToList();

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
            

            return (from C in db.FAMILLs
                    where C.N_FAMILL.Contains(value) ||
                          C.LIB_FAMILL.Contains(value)
                    select new { ID=C.N_FAMILL, Name=C.LIB_FAMILL }).ToList();
        }
        public dynamic selctBox()
        {
            return db.FAMILLs.AsEnumerable().Select(x => new { name = x.LIB_FAMILL, x.N_FAMILL }).ToList();
        }
        public FAMILL GetById(string id)
        {
            return db.FAMILLs.Find(id);
        }
        public void Update(string id, FAMILL famill)
        {
            FAMILL cat = GetById(id);
            cat = famill;
            db.SaveChanges();
        }
    }
}
