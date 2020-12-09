using PhanLong.EF;
using PhanLong.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

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
            var data = from xe in db.DMXes
                       join ps in db.PhatSinhs on xe.Id equals ps.Xe
                       join nv in db.DMNhanViens on ps.TenTX equals nv.Id
                       where (ngayBD == "" && ngayKT == "") || (ps.Ngay >= sdate && ps.Ngay <= edate)
                       select new ThanhToanLuongModel()
                       {
                           Xe = xe.Id,
                           TenTX = nv.TenNV,
                           Cont = ps.SoCont,
                           tiencuoc = ps.CuocTX,
                           tiennang = ps.TienNang,
                           tienha = ps.TienHa,
                           phict = ps.DMPhi.TenPhi,
                           tienphict = ps.TienPhiCT,
                           phikhachhang = ps.PhiKH,
                           tienphikhachhang = ps.TienPhiKH,

                       };
            return data.OrderBy(x => x.Xe).ToList();

        }

        public List<ThanhToanLuong> DanhSachThanhToanLuong(string ngayBD, string ngayKT)
        {
            DateTime sdate = (ngayBD != "") ? Convert.ToDateTime(ngayBD) : new DateTime();
            DateTime edate = (ngayKT != "") ? Convert.ToDateTime(ngayKT).Date : new DateTime();
            object[] parameters =
            {
                new SqlParameter("@ngaybd",sdate.ToString("yyyy'-'MM'-'dd")),
                new SqlParameter("@ngaykt",edate.ToString("yyyy'-'MM'-'dd"))
            };
            var res = db.Database.SqlQuery<ThanhToanLuong>("DanhSachThanhToanLuong @ngaybd, @ngaykt", parameters).ToList();

            return res;
        }



    }
}