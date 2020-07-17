 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhanLong.DAO;
using PhanLong.EF;

namespace PhanLong.Areas.ThongKe.Controllers
{
    public class HoaDonController : BaseController
    {
        // GET: ThongKe/HoaDon
        public ActionResult Index(HoaDon hoaDon, string NgayBD, string NgayKT)
        {
            ViewBag.NgayBD = NgayBD;
            ViewBag.NgayKT = NgayKT;
            if (hoaDon.KH != null)
            {
                var kh = new DMKhachHangDao().GetById(hoaDon.KH);
                ViewBag.KhachHang = kh.TenCongTy;
                ViewBag.MaKH = kh.MaKH;
                ViewBag.IDKhachHang = kh.Id;
            }
            if (hoaDon.SoHD != null)
            {
                ViewBag.SoHD = hoaDon.SoHD;
            }
            var dao = new HoaDonDao();
            var model = dao.SearchHoaDon(hoaDon, NgayBD, NgayKT);
            return View(model);
        }
    } 
}