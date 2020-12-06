using PhanLong.EF;
using PhanLong.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhanLong.DAO
{
    public class CTTTLuongDao
    {
        PhanLongDBContext db = null;
        public CTTTLuongDao()
        {
            db = new PhanLongDBContext();
        }

        public List<PhatSinh> PhatSinhLuong(long? id, string ngayBD, string ngayKT)
        {
            DateTime sdate = (ngayBD != "") ? Convert.ToDateTime(ngayBD).Date : new DateTime();
            DateTime edate = (ngayKT != "") ? Convert.ToDateTime(ngayKT).Date : new DateTime();
            IQueryable<PhatSinh> model = db.PhatSinhs.Where(x => x.Xe == id);
            if (!string.IsNullOrEmpty(ngayBD) && !string.IsNullOrEmpty(ngayKT))
            {
                model = model.Where(x => x.SoCont != "" && x.Loai != null && ((ngayBD == "" && ngayKT == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
            }

            return model.OrderBy(x => x.Ngay).ToList();
        }



        public List<ChiLuongModel> ChiLuong(long? id, string ngayBD, string ngayKT)
        {
            DateTime sdate = (ngayBD != "") ? Convert.ToDateTime(ngayBD).Date : new DateTime();
            DateTime edate = (ngayKT != "") ? Convert.ToDateTime(ngayKT).Date : new DateTime();

            var data = from xe in db.DMXes
                       join psc in db.PhatSinhChiThus on xe.Id equals psc.Xe
                       join ctc in db.CTChiThus on psc.Id equals ctc.PhatSinhChiThu
                       join phi in db.DMPhis on ctc.Phi equals phi.Id
                       join loaiPhi in db.LoaiPhis on phi.LoaiPhi equals loaiPhi.Id
                       where xe.Id == id
                       where loaiPhi.Id == 3
                       where psc.Xe != null
                       select new ChiLuongModel()
                       {
                           Id = psc.Id,
                           NgayChi = psc.Ngay,
                           NoiDung = ctc.NoiDung,
                           HinhThucTT = psc.HinhThucTT.MoTa,
                           TienTru = ctc.DonGia * ctc.SoLuong,
                           ghichu = psc.GhiChu,
                       };

            if (!string.IsNullOrEmpty(ngayBD) && !string.IsNullOrEmpty(ngayKT))
            {
                var model = data.Where(x => (ngayBD == "" && ngayKT == "") || (x.NgayChi >= sdate && x.NgayChi <= edate));
                return model.OrderBy(x => x.NgayChi).Distinct().ToList();
            }
            return data.OrderBy(x => x.NgayChi).Distinct().ToList();
        }



        public List<ThuongTaiXeModel> TienThuong(long? id, string ngayBD, string ngayKT)
        {
            DateTime sdate = (ngayBD != "") ? Convert.ToDateTime(ngayBD).Date : new DateTime();
            DateTime edate = (ngayKT != "") ? Convert.ToDateTime(ngayKT).Date : new DateTime();

            var data = from xe in db.DMXes
                       join psc in db.PhatSinhChiThus on xe.Id equals psc.Xe
                       join ctc in db.CTChiThus on psc.Id equals ctc.PhatSinhChiThu
                       join phi in db.DMPhis on ctc.Phi equals phi.Id
                       join loaiPhi in db.LoaiPhis on phi.LoaiPhi equals loaiPhi.Id
                       where xe.Id == id
                       where loaiPhi.Id == 4
                       where psc.Xe != null
                       select new ThuongTaiXeModel()
                       {
                           Id = psc.Id,
                           Ngay = psc.Ngay,
                           NoiDung = ctc.NoiDung,
                           HinhThucTT = psc.HinhThucTT.MoTa,
                           TienThuong = ctc.DonGia * ctc.SoLuong,
                           ghichu = psc.GhiChu,
                       };
            if (!string.IsNullOrEmpty(ngayBD) && !string.IsNullOrEmpty(ngayKT))
            {
                var model = data.Where(x => (ngayBD == "" && ngayKT == "") || (x.Ngay >= sdate && x.Ngay <= edate));
                return model.OrderBy(x => x.Ngay).Distinct().ToList();
            }
            return data.OrderBy(x => x.Ngay).Distinct().ToList();
        }

        public List<TienKhacModel> TienKhac(long? id, string ngayBD, string ngayKT)
        {
            DateTime sdate = (ngayBD != "") ? Convert.ToDateTime(ngayBD).Date : new DateTime();
            DateTime edate = (ngayKT != "") ? Convert.ToDateTime(ngayKT).Date : new DateTime();

            var data = from xe in db.DMXes
                       join psc in db.PhatSinhChiThus on xe.Id equals psc.Xe
                       join ctc in db.CTChiThus on psc.Id equals ctc.PhatSinhChiThu
                       join phi in db.DMPhis on ctc.Phi equals phi.Id
                       join loaiPhi in db.LoaiPhis on phi.LoaiPhi equals loaiPhi.Id
                       where xe.Id == id
                       where loaiPhi.Id == 4 || loaiPhi.Id == 3
                       where psc.Xe != null
                       select new TienKhacModel()
                       {
                           Id = psc.Id,
                           Ngay = psc.Ngay,
                           NoiDung = ctc.NoiDung,
                           HinhThucTT = psc.HinhThucTT.MoTa,
                           LoaiPhi = loaiPhi.Id,
                           Phi = phi.Id,
                           TienKhac = ctc.DonGia * ctc.SoLuong,
                           ghichu = psc.GhiChu,
                       };
            if (!string.IsNullOrEmpty(ngayBD) && !string.IsNullOrEmpty(ngayKT))
            {
                var model = data.Where(x => (ngayBD == "" && ngayKT == "") || (x.Ngay >= sdate && x.Ngay <= edate));
                return model.OrderBy(x => x.Ngay).ToList();
            }
            return data.OrderBy(x => x.Ngay).ToList();
        }

    }

}

