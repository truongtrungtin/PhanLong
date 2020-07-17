using PhanLong.DAO;
using PhanLong.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhanLong.Areas.ThongKe.Controllers
{
    public class ChiTietController : BaseController
    {
        // GET: ThongKe/Chitiet
        [HttpGet]
        public ActionResult Index(PhatSinh phatSinh, string sday = null, string eday = null)
        {
            var dao = new PhatSinhDao();
            if (phatSinh.KhachHang != null)
            {
                var KH = new DMKhachHangDao().GetById(phatSinh.KhachHang);
                ViewBag.IdKH = KH.Id;
                ViewBag.MaKh = KH.MaKH;
                ViewBag.KH = KH.TenCongTy;
            }
            if (phatSinh.Kho != null)
            {
                var kho = new DMKhoDao().GetById(phatSinh.Kho);
                ViewBag.Kho = kho.DiaChi;
                ViewBag.MaKho = kho.MaKho;
                ViewBag.IdKho = kho.Id;
            }
            if (phatSinh.Xe != null)
            {
                var xe = new DMXeDao().GetById(phatSinh.Xe);
                ViewBag.Xe = xe.BienSo;
                ViewBag.MaXe = xe.MaXe;
                ViewBag.IdXe = xe.Id;
            }
            if (phatSinh.Loai != null)
            {
                var loai = new DMLoaiDao().GetById(phatSinh.Loai);
                ViewBag.Loai = loai.MaLoai;
                ViewBag.IdLoai = loai.Id;
            }
            ViewBag.sday = sday;
            ViewBag.eday = eday;
            var model = dao.Listtk(phatSinh, sday, eday);  
            ViewBag.N20 = model.Where(x => x.Loai == 1).Count();
            ViewBag.N40 = model.Where(x => x.Loai == 3).Count();
            ViewBag.X20 = model.Where(x => x.Loai == 2).Count();
            ViewBag.X40 = model.Where(x => x.Loai == 4).Count();
            ViewBag.All = (ViewBag.N20 + ViewBag.N40 + ViewBag.X20 + ViewBag.X40);
            var startday = model.Count() > 0 ? model.OrderBy(x => x.Ngay).FirstOrDefault().Ngay.ToShortDateString():null;
            var endday = model.Count() > 0 ? model.OrderByDescending(x => x.Ngay).FirstOrDefault().Ngay.ToShortDateString() : null;
            ViewBag.TongNgay = (Convert.ToDateTime(endday) - Convert.ToDateTime(startday)).TotalDays;
            return View(model);
        }

    }
}