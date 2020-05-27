using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;
using QLDL.EF;
using QLDL.Models;

namespace QLDL.DAO
{
    public class CTTTLuongDao
    {
        QLDLDBContext db = null;
        public CTTTLuongDao()
        {
            db = new QLDLDBContext();
        }

        public List<CTTTLuongModel> ListAll(long id, string ngayBD, string ngayKT)
        {
            DateTime sdate = (ngayBD != "") ? Convert.ToDateTime(ngayBD).Date : new DateTime();
            DateTime edate = (ngayKT != "") ? Convert.ToDateTime(ngayKT).Date : new DateTime();

            var data = from nv in db.DMNhanViens
                       join ps in db.PhatSinhs on nv.Id equals ps.TenTX
                       join kh in db.DMKhachHangs on ps.KhachHang equals kh.Id
                       join kho in db.DMKhoes on ps.Kho equals kho.Id
                       join loai in db.DMLoais on ps.Loai equals loai.Id
                       join CN in db.DMCangs on ps.CangNhan equals CN.Id
                       join CT in db.DMCangs on ps.CangTra equals CT.Id
                       where nv.Id == id
                       select new CTTTLuongModel()
                       {
                           Ngay = ps.Ngay,
                           Loai = loai.MaLoai,
                           KhachHang = kh.MaKH,
                           Kho = kho.DiaChi,
                           SoCont = ps.SoCont,
                           CangNhan = CN.TenCang,
                           CangTra = CT.TenCang,
                           TienCuoc = ps.CuocTX,
                           ghichu = ps.GhiChu
                       };
            if (!string.IsNullOrEmpty(ngayBD) && !string.IsNullOrEmpty(ngayKT))
            {
                var model = data.Where(x => (ngayBD == "" && ngayKT == "") || (x.Ngay >= sdate && x.Ngay <= edate));
                return model.OrderBy(x => x.Ngay).Distinct().ToList();
            }
            return data.OrderBy(x => x.Ngay).Distinct().ToList();
        }

    }

}
   
