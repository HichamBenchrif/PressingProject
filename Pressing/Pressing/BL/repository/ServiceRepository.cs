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
                          select new { ID = S.ID_SERVICE, NameService = S.LIB_SERVICE }).ToList();

            return result;
        }
        public dynamic Get()
        {
            var result = (from S in db.SERVICEs
                          select new {S.ID_SERVICE, S.LIB_SERVICE }).ToList();

            return result;
        }
        public SERVICE GetById(string id)
        {
            return db.SERVICEs.Find(id);
        }
        public void Update(string id, SERVICE service)
        {
            SERVICE cat = GetById(id);
            cat = service;
            db.SaveChanges();
        }

        public dynamic Search(string value)
        {
            return (from S in db.SERVICEs
                    where S.ID_SERVICE.Contains(value) ||
                          S.LIB_SERVICE.Contains(value)
                    select new {ID= S.ID_SERVICE, NameService = S.LIB_SERVICE }).ToList();
        }
        public void Supprim(string value)
        {
            var Obj = (from x in db.SERVICEs
                       where x.ID_SERVICE == value
                       select x).FirstOrDefault();
            db.SERVICEs.Remove(Obj);
            db.SaveChanges();

        }
        //public dynamic selctBox()
        //{
        //    return db.CATEGORIE_ARTILCLE.AsEnumerable().Select(x => new { name = x.LIB_CAT_ART, x.ID_CATE }).ToList();
        //}
    }
}
