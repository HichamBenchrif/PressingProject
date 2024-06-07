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

       


        public dynamic GetAll()
        {
            var result = (from A in db.ARTICLEs
                          join C in db.CATEGORIE_ARTILCLE on A.ID_CATE equals C.ID_CATE
                          select new { A.REF_ARTICLE, A.LIB_ARTICLE,A.PRIX_REPASSAGE, A.PRIX_LESSIVE,/*A.IMAGE,*/ C.LIB_CAT_ART }).ToList();

            return result;
          
        }
    }
}
