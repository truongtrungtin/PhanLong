using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLDL.DAO
{
    public class DMKhoDao
    {
        QLDLContext db = null;
        public DMKhoDao()
        {
            db = new QLDLContext();
        }
        public List<DMKho> ListAll()
        {
            return db.DMKhoes.OrderBy(x => x.Id).ToList();
        }
    }
}