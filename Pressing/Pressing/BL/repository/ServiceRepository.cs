using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pressing.DAL.BaseRepository;
using Pressing.DAL;

namespace Pressing.BL.repository
{
    public class ServiceRepository : baserepository
    {
        public string GenerateIDService()
        {
            var count = db.SERVICEs.Count();
            if (count == 0)
                return "Ser-1";
            var ids = db.SERVICEs.Select(x => x.ID_SERVICE).ToList();
            var numbres = ids.Select(x => int.Parse(x.Substring(4, x.Length - 4)));
            var max = numbres.Max();
            var newID = "Ser-" + (max + 1);
            return newID;

        }
        public void Create(string id, string name_ser)
        {
            var service = new SERVICE();
            service.ID_SERVICE = id;
            service.LIB_SERVICE = name_ser;
            db.SERVICEs.Add(service);
            db.SaveChanges();

        }
        public dynamic GetAll()
        {
            var result = (from S in db.SERVICEs
                          select new { S.ID_SERVICE, S.LIB_SERVICE }).ToList();

            return result;
        }
        public dynamic Get()
        {
            var result = (from S in db.SERVICEs
                          select new { S.LIB_SERVICE }).ToList();

            return result;
        }
        //public dynamic Get()
        //{
        //    var result = (from C in db.CATEGORIE_ARTILCLE
        //                  select new { C.LIB_CAT_ART }).FirstOrDefault();

        //    return result;
        //}

        //public dynamic Search(string value)
        //{
        //    //var result = (from C in db.CATEGORIE_ARTILCLE.AsEnumerable()
        //    //              where C.ID_CATE.Contains(value) ||
        //    //              C.LIB_CAT_ART.Contains(value)
        //    //              select new { C.ID_CATE, C.LIB_CAT_ART }).ToList();
        //    //return result;

        //    return (from C in db.CATEGORIE_ARTILCLE
        //            where C.ID_CATE.Contains(value) ||
        //                  C.LIB_CAT_ART.Contains(value)
        //            select new { C.ID_CATE, C.LIB_CAT_ART }).ToList();
        //}
        //public dynamic selctBox()
        //{
        //    return db.CATEGORIE_ARTILCLE.AsEnumerable().Select(x => new { name = x.LIB_CAT_ART, x.ID_CATE }).ToList();
        //}
    }
}
