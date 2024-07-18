using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pressing.DAL.BaseRepository;
using Pressing.DAL;

namespace Pressing.BL.repository
{
    public class CommandeRepository : baserepository
    {
       
            public string GenerateID()
            {
                var count = db.BON_RECEPTION.Count();
                if (count == 0)
                    return "1";
                var ids = db.BON_RECEPTION.Select(x => x.ID_BON_R).ToList();
                var numbres = ids.Select(x => int.Parse(x.Substring(0, x.Length - 0)));
                var max = numbres.Max();
                var newID = "" + (max + 1);
                return newID;

            }
        //public string ID()
        //{
        //    var count = db.ARTICLE_AJOUTE.Count();
        //    if (count == 0)
        //        return "1";
        //    var ids = db.ARTICLE_AJOUTE.Select(x => x.ID_ARTICLE_AJOUTE).ToList();
        //    var numbres = ids.Select(x => int.Parse(x.Substring(0, x.Length - 0)));
        //    var max = numbres.Max();
        //    var newID = "" + (max + 1);
        //    return newID;

        //}
        public void Create(string id, string client, string statut, string date, string heure, string modepaye,string reste, string montant)
        {
            var commande = new BON_RECEPTION();
            commande.ID_BON_R = id;
            commande.ID_CLIENT = client;
            commande.STATUT = statut;
            commande.DATE_BR = DateTime.Parse(date);
            commande.HEURE_BR = DateTime.Parse(heure);
            commande.TYPE_PAIEMENT = modepaye;
            commande.RESTE = decimal.Parse( reste);
            commande.MONTANTSTOTAL =decimal.Parse( montant);

            db.BON_RECEPTION.Add(commande);
            db.SaveChanges();

            //short parsedQuntite;
            //decimal parsedPrixtotal, parsedRemis;
            //if(short.TryParse(quntite, out parsedQuntite)&& decimal.TryParse(prixtotal, out parsedPrixtotal)&&decimal.TryParse(remis, out parsedRemis))
            //{
            //    commande.QNTE_S =parsedQuntite;
            //    commande.MONTANT_TOTAL =parsedPrixtotal;
            //    commande.REMIS =parsedRemis;

            //    db.B_R.Add(commande);
            //    db.SaveChanges();
            //}
        }
        //public void Crt(/*string id,*/ string srv, string art,  string remis, string montant)
        //{
        //    var commande = new B_R();
        //    //commande.ID_BON_R = id;
        //    commande.ID_SERVICE = srv;
        //    commande.REF_ARTICLE = art;
           
        //    commande.REMIS =decimal.Parse( remis);
        //    commande.MONTANT_TOTAL =decimal.Parse( montant.Replace(" DH", "").Trim());
        //    db.B_R.Add(commande);
        //    db.SaveChanges();

            
        //}
        //public void ajout_articl(string id, string art, string srv, string prix, string color, string quantite)
        //{
        //    var commande = new ARTICLE_AJOUTE();
        //    commande.ID_ARTICLE_AJOUTE = id;
        //    commande.ID_SERVICE = srv;
        //    commande.REF_ARTICLE = art;
        //    commande.PRIX =decimal.Parse( prix);
        //    commande.COLOR = color;
        //    commande.QUANTITE =int.Parse( quantite);

            
        //    db.ARTICLE_AJOUTE.Add(commande);
        //    db.SaveChanges();


        //}
    }
}
