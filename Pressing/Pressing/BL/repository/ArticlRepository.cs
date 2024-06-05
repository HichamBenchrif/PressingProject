using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pressing.DAL.BaseRepository;
using Pressing.DAL;
using System.Drawing.Imaging;
using System.Windows.Forms;
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
        public void Create(string id, string category, string name_art, decimal prix_R , decimal prix_L ,byte[] image )
        {
            var Article = new ARTICLE();
            Article.REF_ARTICLE = id;
            Article.CATEGORIE_ARTILCLE = category;
            Article.LIB_ARTICLE = name_art;
            Article.PRIX_REPASSAGE = prix_R;
            Article.PRIX_LESSIVE = prix_L;
            Article.IMAGE = image;
            db.ARTICLEs.Add(Article);
            db.SaveChanges();

        }

        internal void Create(string iD_art, string name, object combo, string repasag, string lessiv, Image image)
        {
            throw new NotImplementedException();
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
