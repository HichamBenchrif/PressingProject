using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pressing.DAL.BaseRepository;
using Pressing.DAL;

namespace Pressing.BL.repository
{
    class BRRepository : baserepository
    {

        public void Create(List<B_R> brs)
        {
            foreach(var br in brs)
            {
                db.B_R.Add(br);
                db.SaveChanges();
            }
        }
    }
}
