using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pressing.DAL.BaseRepository;
using Pressing.DAL;
namespace Pressing.BL.repository
{
    public class FournisseurRepository :baserepository 
    {
       
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
        public void Create(string id, string prenom, string nom, string telephon)
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
            //return db.FOURNISSEURs
            //    .Select(x => new
            //    {
            //        FullName = x.PRN_FR + " " + x.NOM_FR,
            //        x.ID_FR
            //    }).ToList();
            return db.FOURNISSEURs.AsEnumerable().Select(x => new { FullName = x.PRN_FR+" "+ x.NOM_FR, x.ID_FR }).ToList();
        }


        public dynamic GetAll()
        {
            var result = (from F in db.FOURNISSEURs

                          select new
                          {
                              ID=F.ID_FR,
                              Prenom=F.PRN_FR,
                              Nom=F.NOM_FR,
                              Téléphone=F.TEL_FR,
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

    }
}
