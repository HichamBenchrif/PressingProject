﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pressing.DAL.BaseRepository;
using Pressing.DAL;

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
            var categorie = new CATEGORIE_ARTILCLE();
            categorie.ID_CATE = id;
            categorie.LIB_CAT_ART = name_Cat;
            db.CATEGORIE_ARTILCLE.Add(categorie);
            db.SaveChanges();
            
        }
        public dynamic GetAll()
        {
            var result = (from C in db.CATEGORIE_ARTILCLE
                          select new { C.ID_CATE, C.LIB_CAT_ART }).ToList();

            return result;
        }
        public dynamic Search(string value)
        {
            //var result = (from C in db.CATEGORIE_ARTILCLE.AsEnumerable()
            //              where C.ID_CATE.Contains(value) ||
            //              C.LIB_CAT_ART.Contains(value)
            //              select new { C.ID_CATE, C.LIB_CAT_ART }).ToList();
            //return result;

            return (from C in db.CATEGORIE_ARTILCLE
                    where C.ID_CATE.Contains(value) ||
                          C.LIB_CAT_ART.Contains(value)
                    select new { C.ID_CATE, C.LIB_CAT_ART }).ToList();
        }
    }
}