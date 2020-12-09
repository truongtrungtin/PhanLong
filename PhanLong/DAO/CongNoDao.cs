using PhanLong.EF;
using PhanLong.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhanLong.DAO
{
    public class CongNoDao
    {

        PhanLongDBContext db = null;
        public CongNoDao()
        {
            db = new PhanLongDBContext();
        }

        public List<CongNoModel> ListAll(CongNoModel congNoModel, string ngayBD, string ngayKT)
        {
            DateTime sdate = (ngayBD != "") ? Convert.ToDateTime(ngayBD).Date : new DateTime();
            DateTime edate = (ngayKT != "") ? Convert.ToDateTime(ngayKT).Date : new DateTime();
            var data = from nv in db.DMKhachHangs
                       join ps in db.PhatSinhs on nv.Id equals ps.KhachHang
                       select new CongNoModel()
                       {
                           Ngay = ps.Ngay,
                           KhachHang = nv.MaKH,
                           Cont = ps.SoCont,
                           Cuoc = ps.CuocKH,
                           TienNang = ps.TienNang,
                           TienHa = ps.TienHa,
                           TienKhachHang = ps.TienPhiKH,
                       };
            var model = data;
            if (!string.IsNullOrEmpty(ngayBD) && !string.IsNullOrEmpty(ngayKT))
            {
                model = model.Where(x => (ngayBD == "" && ngayKT == "") || (x.Ngay >= sdate && x.Ngay <= edate));
            }
            if (congNoModel.KhachHang != null)
            {
                model = model.Where(x => x.KhachHang == congNoModel.KhachHang);
            }
            return model.OrderBy(x => x.KhachHang).ToList();
        }

        public DMKhachHang GetByMa(string MaKH)
        {
            return db.DMKhachHangs.SingleOrDefault(x => x.MaKH == MaKH);
        }
    }
}