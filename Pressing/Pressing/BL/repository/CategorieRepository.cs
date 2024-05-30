using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pressing.DAL.BaseRepository;

namespace Pressing.BL.repository
{
    class CategorieRepository : baserepository
    {
        public string GenerateIDCategorie()
        {
            var count = db.CATEGORIE_ARTILCLE.Count();
            if (count == 0)
                return "Cat-1";
            var ids = db.CATEGORIE_ARTILCLE.Select(x => x.ID_CATE).ToList();
            var numbres = ids.Select(x => int.Parse(x.Substring(4, x.Length - 4)));
            var max = numbres.Max();
            var newID = "Cat-" + (max + 1);
            return newID;

        }
        public void Create(string id, string name_Cat )
        {
            var categorie = new CA
            absence.ID = id;
            absence.STG = stg;
            absence.ABSDate = absdate;

            db.Absences.Add(absence);
            db.SaveChanges();



        }
    }
}
