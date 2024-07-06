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
        public void Create(string articl, string color, string service, string quntite, string prixtotal, string remis)
        {
            var commande = new B_R();
            commande.REF_ARTICLE = articl;
            commande.COULEUR = color;
            commande.ID_SERVICE = service;

            short parsedQuntite;
            decimal parsedPrixtotal, parsedRemis;
            if(short.TryParse(quntite, out parsedQuntite)&& decimal.TryParse(prixtotal, out parsedPrixtotal)&&decimal.TryParse(remis, out parsedRemis))
            {
                commande.QNTE_S =parsedQuntite;
                commande.MONTANT_TOTAL =parsedPrixtotal;
                commande.REMIS =parsedRemis;

                db.B_R.Add(commande);
                db.SaveChanges();
            }
            
            

        }
    }
}
