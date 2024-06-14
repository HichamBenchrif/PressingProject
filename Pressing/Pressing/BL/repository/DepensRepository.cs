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
        //public void Create(string id, string name_produit , int quntite, decimal prix , DateTime date , string prenom , string nom , string telephon)
        //{
        //    var depens = new DÉPENSES_ET_ENTRÉES();
        //    depens.ID_DÉPE_ENTR = id;

        //    var lib_produit = new PRODUIT();
        //    lib_produit.LIB_PRODUIT = name_produit;

        //    var achete = new ACHETER();
        //    achete.QNTE_ACH = (short)quntite;
        //    achete.PU_ACH = prix;

        //    var bon_achete = new BON_ACHAT();
        //    bon_achete.DATE_B_A = date;

        //    var fr = new FOURNISSEUR();
        //    fr.PRN_FR = prenom;
        //    fr.NOM_FR = nom;
        //    fr.TEL_FR = telephon;
        //    try
        //    {
        //        db.DÉPENSES_ET_ENTRÉES.Add(depens);
        //        db.PRODUITs.Add(lib_produit);
        //        db.ACHETERs.Add(achete);
        //        db.BON_ACHAT.Add(bon_achete);
        //        db.FOURNISSEURs.Add(fr);
        //        db.SaveChanges();
        //    }
        //    catch (DbEntityValidationException ex)
        //    {
        //        foreach (var ValidationErrors in ex.EntityValidationErrors)
        //        {
        //            foreach(var ValidationError in ValidationErrors.ValidationErrors)
        //            {
        //                Console.WriteLine($"Property: {ValidationError.PropertyName} Error:{ValidationError.ErrorMessage}");
        //            }
        //        }
        //        throw;
        //    }

            //}
            //public dynamic GetAll()
            //{
            //    var result = (from C in db.CATEGORIE_ARTILCLE
            //                  select new { C.ID_CATE, C.LIB_CAT_ART }).ToList();

            //    return result;
            //}
        }
    }
}
