using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pressing.DAL.BaseRepository;

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
    }
}
