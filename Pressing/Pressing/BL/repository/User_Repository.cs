using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pressing.DAL.BaseRepository;
using Pressing.DAL;

namespace Pressing.BL.repository
{
    public class User_Repository : baserepository
    {
        public string GenerateID()
        {
            var count = db.Logins.Count();
            if (count == 0)
                return "1";
            var ids = db.Logins.Select(x => x.ID).ToList();
            var numbres = ids.Select(x => int.Parse(x.Substring(0, x.Length - 0)));
            var max = numbres.Max();
            var newID = "" + (max + 1);
            return newID;

        }
        public void Create(string id, string username, string password)
        {
            var log  = new Login();
            log.ID = id;
            log.username = username;
            log.password = password;
            db.Logins.Add(log);
            db.SaveChanges();

        }
    }
}
