using QLDL.EF;
using QLDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLDL.DAO
{
    public class ThongKeLuong
    {
        QLDLDBContext db = null;
        public ThongKeLuong()
        {
            db = new QLDLDBContext();
        }

        public List<ThanhToanLuongModel> ListAll()
        {
            var data = from nv in db.DMNhanViens
                       join ps in db.PhatSinhs on nv.Id equals ps.TenTX
                       select new ThanhToanLuongModel()
                       {
                           Id = nv.Id,
                           MaTX = nv.MaNV,
                           TaiXe = nv.TenNV
                       };

            return data.OrderBy(x => x.Id).Distinct().ToList();
        }
    }
}