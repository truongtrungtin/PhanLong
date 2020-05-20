using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QLDL.DAO
{
    public class DMKhachHangDao
    {
        QLDLContext db = null;
        public DMKhachHangDao()
        {
            db = new QLDLContext();
        }
        public List<DMKhachHang> ListAll()
        {
            return db.DMKhachHangs.OrderBy(x => x.Id).ToList();
        }
    }
}