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
        public void Supprim(string value)
        {
            var Obj = (from x in db.DÉPENSES_ET_ENTRÉES
                       where x.ID_DÉPE_ENTR == value
                       select x).FirstOrDefault();
            db.DÉPENSES_ET_ENTRÉES.Remove(Obj);
            db.SaveChanges();

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
        
        
        public void CreateDepens(string id, string fournisseur, string nom, DateTime date, short qntite, decimal prix)
        {
            var depens = new DÉPENSES_ET_ENTRÉES();
            depens.ID_DÉPE_ENTR = id;
            depens.ID_FR = fournisseur;
            depens.LIB_DEPENS = nom;
            depens.DATE = date;
            depens.Q = qntite;
            depens.PRIX = prix;

            db.DÉPENSES_ET_ENTRÉES.Add(depens);
            db.SaveChanges();

        }

        

        public dynamic GetAll()
        {
            var result = (from D in db.DÉPENSES_ET_ENTRÉES
                          join F in db.FOURNISSEURs on D.ID_FR equals F.ID_FR
                          select new
                          {
                              ID=D.ID_DÉPE_ENTR,
                              NOM=D.LIB_DEPENS,
                              Quntite=D.Q,
                              Prix=D.PRIX,
                              Date=D.DATE,
                              NameFournisseur = F.PRN_FR + " " + F.NOM_FR
                          }).ToList();

            return result;
        }
       
       
        public DÉPENSES_ET_ENTRÉES GetByIdDepens(string ID)
        {
            return db.DÉPENSES_ET_ENTRÉES.Find(ID);
        }
        public void UpdateDepens(string ID, DÉPENSES_ET_ENTRÉES depens)
        {
            DÉPENSES_ET_ENTRÉES cat = GetByIdDepens(ID);
            cat = depens;
            db.SaveChanges();
        }
    }
}
