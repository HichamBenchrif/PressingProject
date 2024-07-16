using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pressing.DAL.BaseRepository;
using Pressing.DAL;

namespace Pressing.BL.repository
{
    
    
    public class ClientRepository :baserepository
    {

        public string GenerateIDClient()
        {
            var count = db.CLIENTs.Count();
            if (count == 0)
                return "Cli-1";
            var ids = db.CLIENTs.Select(x => x.ID_CLIENT).ToList();
            var numbres = ids.Select(x => int.Parse(x.Substring(4, x.Length - 4)));
            var max = numbres.Max();
            var newID = "Cli-" + (max + 1);
            return newID;

        }
        public void Create(string id, string name_Cli , string prenom_Cli , string telephon, string adress)
        {
            var client = new CLIENT();
            client.ID_CLIENT= id;
            client.NOM_CLT = name_Cli;
            client.PRENOM_CLT = prenom_Cli;
            client.TEL_CLT = telephon;
            client.ADRESSE = adress;
            db.CLIENTs.Add(client);
            db.SaveChanges();

        }
        public dynamic Search(string value)
        {
           

            return (from C in db.CLIENTs
                    where C.ID_CLIENT.Contains(value) ||
                          C.PRENOM_CLT.Contains(value)||
                          C.NOM_CLT.Contains(value) ||
                          C.TEL_CLT.Contains(value)||
                          C.ADRESSE.Contains(value)
                    select new { C.ID_CLIENT, C.NOM_CLT, C.PRENOM_CLT, C.TEL_CLT, C.ADRESSE }).ToList();
        }
        public dynamic GetAll()
        {
            var result = (from C in db.CLIENTs
                          select new { C.ID_CLIENT, C.NOM_CLT, C.PRENOM_CLT, C.TEL_CLT, C.ADRESSE }).ToList();

            return result;
        }
        public string GetTotal()
        {
            var result = (from x in db.CLIENTs
                          group x by x.ID_CLIENT).Count().ToString();
            return result;
        }
        //public dynamic selctBox()
        //{
        //    var clients = db.CLIENTs.AsEnumerable().ToList();
        //    var result = clients.Select(x => new { FullName = x.NOM_CLT + " " + x.PRENOM_CLT as string, ID_CLIENT = x.ID_CLIENT }).ToList();

        //    return result;
        //}
        public dynamic selctBox3()
        {
            return db.CLIENTs.AsEnumerable().Select(x => new { Name = x.PRENOM_CLT +" " + x.NOM_CLT, x.ID_CLIENT }).ToList();
        }
        public CLIENT GetById(string id)
        {
            return db.CLIENTs.Find(id);
        }
        public void Update(string id, CLIENT client)
        {
            CLIENT cat = GetById(id);
            cat = client;
            db.SaveChanges();
        }
    }
}
