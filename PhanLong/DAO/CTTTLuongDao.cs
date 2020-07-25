﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;
using PhanLong.EF;
using PhanLong.Models;

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
            IQueryable<PhatSinh> model = db.PhatSinhs.Where(x=>x.Xe == id);
            if (!string.IsNullOrEmpty(ngayBD) && !string.IsNullOrEmpty(ngayKT))
            {
                model = model.Where(x => x.SoCont != "" && x.Loai != null &&( (ngayBD == "" && ngayKT == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
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
                       where xe.Id == id where ctc.DMPhi.MaPhi == "T.ứng"
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

    }

}
   
