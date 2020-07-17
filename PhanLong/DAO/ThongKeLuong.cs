using PhanLong.EF;
using PhanLong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhanLong.DAO
{
    public class ThongKeLuong
    {
        PhanLongDBContext db = null;
        public ThongKeLuong()
        {
            db = new PhanLongDBContext();
        }

        public List<ThanhToanLuongModel> ListAll(string ngayBD, string ngayKT)
        {
            DateTime sdate = (ngayBD != "") ? Convert.ToDateTime(ngayBD).Date : new DateTime();
            DateTime edate = (ngayKT != "") ? Convert.ToDateTime(ngayKT).Date : new DateTime();
            var data = from nv in db.DMNhanViens
                       join ps in db.PhatSinhs on nv.Id equals ps.TenTX
                       where (ngayBD == "" && ngayKT == "") || ( ps.Ngay >= sdate && ps.Ngay <= edate)
                       select new ThanhToanLuongModel()
                       {
                           Id = nv.Id,
                           MaTX = nv.MaNV,
                           TaiXe = nv.TenNV,
                           Cont = ps.SoCont,
                           tiencuoc = ps.CuocTX
                       };
            return data.OrderBy(x => x.Id).ToList();
        }

    
    }
}