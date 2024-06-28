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
        public dynamic selctBox()
        {
            return db.FOURNISSEURs
                .Select(x => new
                {
                    FullName = x.PRN_FR + " "+ x.NOM_FR,
                    x.ID_FR
                }).ToList();
         }


        public dynamic GetAll()
        {
            var result = (from D in db.DÉPENSES_ET_ENTRÉES
                          join F in db.FOURNISSEURs on D.ID_FR equals F.ID_FR
                          select new
                          {
                              D.ID_DÉPE_ENTR,
                              D.LIB_DEPENS,
                              D.Q, D.PRIX,
                              D.DATE,
                              Namefournisseur = F.PRN_FR + " " + F.NOM_FR
                          }).ToList();

            return result;
        }
        public FOURNISSEUR GetById(string id)
        {
            return db.FOURNISSEURs.Find(id);
        }
        public void Update(string id, FOURNISSEUR fournisseur)
        {
            FOURNISSEUR cat = GetById(id);
            cat = fournisseur;
            db.SaveChanges();
        }
        public DÉPENSES_ET_ENTRÉES GetByIdDepens(string id)
        {
            return db.DÉPENSES_ET_ENTRÉES.Find(id);
        }
        public void UpdateDepens(string id, DÉPENSES_ET_ENTRÉES depens)
        {
            DÉPENSES_ET_ENTRÉES cat = GetByIdDepens(id);
            cat = depens;
            db.SaveChanges();
        }
    }
}
