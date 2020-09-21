using PhanLong.DAO;
using PhanLong.EF;
using System;
using System.Web.Mvc;

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


        [HttpGet]
        public PartialViewResult ThanhToanHoaDon(long id, DateTime? ngaythanhtoan = null)
        {
            HoaDon model = new HoaDonDao().GetById(id);
            return PartialView("ThanhToanHoaDon", model);
        }

        [HttpPost]
        public ActionResult ThanhToanHoaDon(HoaDon hoaDon, string NgayBD, string NgayKT)
        {
            if (new HoaDonDao().UpdateThanhToan(hoaDon))
            {
                SetAlert("Đã thêm thành công!", "success");
            }
            else
            {
                SetAlert("Thêm không thành công, vui lòng thử lại!", "warning");
            }
            return RedirectToAction("Index", "HoaDon", new { NgayBD = NgayBD, NgayKT = NgayKT });
        }

    }
}