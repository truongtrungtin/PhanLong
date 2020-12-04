using PhanLong.DAO;
using PhanLong.EF;
using System;
using System.Linq;
using System.Web.Mvc;

namespace PhanLong.Areas.ThongKe.Controllers
{
    public class ChiTietController : BaseController
    {
        // GET: ThongKe/Chitiet
        [HttpGet]
        public ActionResult Index(PhatSinh phatSinh, string sday = null, string eday = null, string _Search = null, string _ThanhToanCuoc = null)
        {
            var dao = new PhatSinhDao();
  
            if (_Search != null && _Search != "" )
            {
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
                if (phatSinh.SoBill != null)
                {
                    var Bill = new DMBillDao().GetById(phatSinh.SoBill);
                    ViewBag.Bill = Bill.MaBill;
                    ViewBag.IdBill = Bill.Id;
                }
            }
            else if (_ThanhToanCuoc  != null && _ThanhToanCuoc != "")
            {
                return RedirectToAction("ThanhToanCuoc", "ChiTiet", new { @KhachHang = phatSinh.KhachHang, @SoBill = phatSinh.SoBill, @sday = sday, @eday = eday });
            }
            ViewBag.sday = sday;
            ViewBag.eday = eday;
            var model = dao.Listtk(phatSinh, sday, eday);
            ViewBag.N20 = model.Where(x => x.Loai == 3).Count();
            ViewBag.N40 = model.Where(x => x.Loai == 4).Count();
            ViewBag.X20 = model.Where(x => x.Loai == 2).Count();
            ViewBag.X40 = model.Where(x => x.Loai == 1).Count();
            ViewBag.All = (ViewBag.N20 + ViewBag.N40 + ViewBag.X20 + ViewBag.X40);
            var startday = model.Count() > 0 ? model.OrderBy(x => x.Ngay).FirstOrDefault().Ngay.ToShortDateString() : null;
            var endday = model.Count() > 0 ? model.OrderByDescending(x => x.Ngay).FirstOrDefault().Ngay.ToShortDateString() : null;
            ViewBag.TongNgay = (Convert.ToDateTime(endday) - Convert.ToDateTime(startday)).TotalDays;
            return View(model);
        }

        public ActionResult ThanhToanCuoc(PhatSinh phatSinh, string sday = null, string eday = null)
        {
            var dao = new PhatSinhDao();
            if (phatSinh.SoBill != null)
            {
                var Bill = new DMBillDao().GetById(phatSinh.SoBill);
                ViewBag.Bill = Bill.MaBill;
                ViewBag.IdBill = Bill.Id;
                ViewBag.KH = Bill.KhachHang != null ? Bill.DMKhachHang.TenCongTy : null;
            }
            if (phatSinh.KhachHang != null)
            {
                var KH = new DMKhachHangDao().GetById(phatSinh.KhachHang);
                ViewBag.IdKH = KH.Id;
                ViewBag.MaKh = KH.MaKH;
                ViewBag.KH = KH.TenCongTy;
            }
            var model = dao.ThanhToanCuoc(phatSinh, sday, eday);
            ViewBag.sday = sday;
            ViewBag.eday = eday;
            ViewBag.N20 = model.Where(x => x.DMLoai.MaLoai == "20N").Count();
            ViewBag.N40 = model.Where(x => x.DMLoai.MaLoai == "40N").Count();
            ViewBag.X20 = model.Where(x => x.DMLoai.MaLoai == "20X").Count();
            ViewBag.X40 = model.Where(x => x.DMLoai.MaLoai == "40X").Count();
            ViewBag.All = (ViewBag.N20 + ViewBag.N40 + ViewBag.X20 + ViewBag.X40);
            var startday = model.Count() > 0 ? model.OrderBy(x => x.Ngay).FirstOrDefault().Ngay.ToShortDateString() : null;
            var endday = model.Count() > 0 ? model.OrderByDescending(x => x.Ngay).FirstOrDefault().Ngay.ToShortDateString() : null;
            ViewBag.TongNgay = (Convert.ToDateTime(endday) - Convert.ToDateTime(startday)).TotalDays;
            return View(model);
        }


        [HttpGet]
        public PartialViewResult EditGhiChuThanhToan(long id)
        {
            PhatSinh model = new PhatSinhDao().GetById(id);

            return PartialView("EditGhiChuThanhToan", model);
        }


        [HttpPost]
        public ActionResult EditGhiChuThanhToan(PhatSinh phatSinh, string NgayBD, string NgayKT)
        {
            if (new PhatSinhDao().UpdateGhiChuThanhToan(phatSinh))
            {
                SetAlert("Đã thêm ghi chú lương thành công!", "success");
            }
            else
            {
                SetAlert("Thêm ghi chú lương không thành công, vui lòng thử lại!", "warning");
            }
            return RedirectToAction("ThanhToanCuoc", "ChiTiet", new { SoBill = phatSinh.SoBill, KhachHang = phatSinh.KhachHang, sday = NgayBD, eday = NgayKT });
        }

        [HttpPost]
        public JsonResult ChangeStatusVAT(long id)
        {
            var result = new PhatSinhDao().ChangeStatusVAT(id);
            return Json(new
            {
                VAT = result
            });
        }

    }
}