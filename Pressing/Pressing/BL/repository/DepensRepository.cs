using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pressing.DAL.BaseRepository;
using Pressing.DAL;
using System.Data.Entity.Validation;

namespace Pressing.BL.repository
{
    public class DepensRepository : baserepository
    {
        public string GenerateIDDepens()
        {
            var count = db.DÉPENSES_ET_ENTRÉES.Count();
            if (count == 0)
                return "Dep-1";
            var ids = db.DÉPENSES_ET_ENTRÉES.Select(x => x.ID_DÉPE_ENTR).ToList();
            var numbres = ids.Select(x => int.Parse(x.Substring(4, x.Length - 4)));
            var max = numbres.Max();
            var newID = "Dep-" + (max + 1);
            return newID;

        }
        public string GenerateIDfournisseur()
        {
            var count = db.FOURNISSEURs.Count();
            if (count == 0)
                return "Fr-1";
            var ids = db.FOURNISSEURs.Select(x => x.ID_FR).ToList();
            var numbres = ids.Select(x => int.Parse(x.Substring(3, x.Length - 3)));
            var max = numbres.Max();
            var newID = "Fr-" + (max + 1);
            return newID;

        }
        public void Create(string id, string prenom , string nom ,string telephon )
        {
            var fournisseur = new FOURNISSEUR();
            fournisseur.ID_FR = id;
            fournisseur.PRN_FR = prenom;
            fournisseur.NOM_FR = nom;
            fournisseur.TEL_FR = telephon;
            db.FOURNISSEURs.Add(fournisseur);
            db.SaveChanges();

        }
        public dynamic selctBox()
        {
            return db.FOURNISSEURs.AsEnumerable().Select(x => new { name = x.PRN_FR + x.NOM_FR, x.ID_FR }).ToList();
        }


        //public dynamic GetAll()
        //{
        //    var result = (from C in db.CATEGORIE_ARTILCLE
        //                  select new { C.ID_CATE, C.LIB_CAT_ART }).ToList();

        //    return result;
        //}
        //}
    }
}
