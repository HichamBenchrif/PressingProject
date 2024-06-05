using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pressing.DAL.BaseRepository;
using Pressing.DAL;
using System.Drawing;

namespace Pressing.BL.repository
{
    class ArticlRepository : baserepository
    {
        public string GenerateIDArticl()
        {
             var count = db.ARTICLEs.Count();
            if (count == 0)
                return "Art-1";
            var ids = db.ARTICLEs.Select(x => x.REF_ARTICLE).ToList();
            var numbres = ids.Select(x => int.Parse(x.Substring(4, x.Length - 4)));
            var max = numbres.Max();
            var newID = "Art-" + (max + 1);
            return newID;

        }
        public void Create(string id, string category, string name_art, string prix_R , string prix_L ,byte image )
        {
            var Article = new ARTICLE();
            Article.
            Article.
            db.CATEGORIE_ARTILCLE.Add(categorie);
            db.SaveChanges();

        }
        //public dynamic GetAll()
        //{
        //    //var result = (from C in db.CATEGORIE_ARTILCLE
        //    //              join A in db.ACHETERs on C.ID_CATE equals A.REF_PRODUIT
        //    //              select new { A.REF_PRODUIT , C.LIB_CAT_ART ,  }).ToList();

        //    //return result;





        //    //var result = (from A in db.Absences
        //    //              join S in db.Stagiaires on A.STG equals S.ID
        //    //              join G in db.Groupes on S.GRP equals G.CODE
        //    //              select new { A.ID, A.STG, A.ABSDate, S.Nom, S.Prenom, S.GRP, G.FL }).ToList();
        //}
    }
}
