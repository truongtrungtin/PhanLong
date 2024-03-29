﻿using PhanLong.DAO;
using PhanLong.EF;
using System;
using System.Linq;
using System.Web.Mvc;

namespace PhanLong.Areas.ThongKe.Controllers
{
    public class LuongController : BaseController
    {
        // GET: ThanhToanLuong
        public ActionResult Index(string NgayBD, string NgayKT)
        {
            if (NgayBD == "" || NgayBD == null)
            {
                NgayBD = "2020-06-01";
            }
            if (NgayKT == "" || NgayKT == null)
            {
                NgayKT = DateTime.Now.ToString("yyyy'-'MM'-'dd");
            }
            ViewBag.NgayBD = NgayBD;
            ViewBag.NgayKT = NgayKT;
            var model = new ThongKeLuong().DanhSachThanhToanLuong(NgayBD, NgayKT);
            return View(model);
        }


        public ActionResult CTTTLuong(long id, string NgayBD, string NgayKT)
        {

            if (NgayBD == "" || NgayBD == null)
            {
                NgayBD = "2020-06-01";
            }
            if (NgayKT == "" || NgayKT == null)
            {
                NgayKT = DateTime.Now.ToString("yyyy'-'MM'-'dd");
            }
            if (id != null)
            {
                var mXe = new DMXeDao().GetById(id);
                ViewBag.Xe = mXe.BienSo;
                ViewBag.MaXe = mXe.MaXe;
                ViewBag.IdXe = mXe.Id;
            }
            var xe = new DMXeDao().GetById(id);
            var model = new CTTTLuongDao().PhatSinhLuong(id, NgayBD, NgayKT);
            var ChiLuong = new CTTTLuongDao().ChiLuong(id, NgayBD, NgayKT);
            var TienThuong = new CTTTLuongDao().TienThuong(id, NgayBD, NgayKT);
            var TienKhac = new CTTTLuongDao().TienKhac(id, NgayBD, NgayKT);
            var Loai = new PhatSinhDao().GetLoai(id);
            var tx = new PhatSinhDao().GetNvByXe(id, NgayBD, NgayKT);
            ViewBag.ChiLuong = ChiLuong.OrderBy(x => x.NgayChi);
            ViewBag.TongChiLuong = ChiLuong.Count;
            ViewBag.TienThuong = TienThuong;
            ViewBag.TienKhac = TienKhac;
            ViewBag.id = id;
            ViewBag.tx = tx.DMNhanVien.TenNV;
            ViewBag.Xe = xe.BienSo;
            ViewBag.NgayBD = NgayBD;
            ViewBag.NgayKT = NgayKT;
            ViewBag.N20 = model.Where(x => x.DMLoai.MaLoai == "20N").Count();
            ViewBag.X20 = model.Where(x => x.DMLoai.MaLoai == "20X").Count();
            ViewBag.N40 = model.Where(x => x.DMLoai.MaLoai == "40N").Count();
            ViewBag.X40 = model.Where(x => x.DMLoai.MaLoai == "40X").Count();
            ViewBag.Tong = (ViewBag.N20 + ViewBag.X20 + ViewBag.N40 + ViewBag.X40);
            return View(model);


        }

        [HttpPost]
        public ActionResult CTTTLuong(PhatSinh phatSinh, string NgayBD, string NgayKT)
        {
            var xe = new DMNhanVienDao().GetById(phatSinh.Xe);
            var model = new CTTTLuongDao().PhatSinhLuong(phatSinh.Xe, NgayBD, NgayKT);
            var ChiLuong = new CTTTLuongDao().ChiLuong(phatSinh.Xe, NgayBD, NgayKT);
            var dao = new PhatSinhDao();
            var tx = new PhatSinhDao().GetNvByXe(phatSinh.Xe, NgayBD, NgayKT);
            var Loai = dao.GetLoai(xe.Id);
            ViewBag.ChiLuong = ChiLuong;
            ViewBag.id = phatSinh.Id;
            ViewBag.tx = tx.DMNhanVien.TenNV;
            ViewBag.NgayBD = NgayBD;
            ViewBag.NgayKT = NgayKT;
            ViewBag.N20 = model.Where(x => x.DMLoai.MaLoai == "20N").Count();
            ViewBag.X20 = model.Where(x => x.DMLoai.MaLoai == "20X").Count();
            ViewBag.N40 = model.Where(x => x.DMLoai.MaLoai == "40N").Count();
            ViewBag.X40 = model.Where(x => x.DMLoai.MaLoai == "40X").Count();
            ViewBag.Tong = (ViewBag.N20 + ViewBag.X20 + ViewBag.N40 + ViewBag.X40);
            return RedirectToAction("CTTTLuong", "Luong", new { id = phatSinh.Xe, NgayBD = NgayBD, NgayKT = NgayKT });
        }

        [HttpGet]
        public ActionResult Thanhtoanchiho(long id, string NgayBD, string NgayKT)
        {
            if (NgayBD == "" || NgayBD == null)
            {
                NgayBD = "2020-06-01";
            }
            if (NgayKT == "" || NgayKT == null)
            {
                NgayKT = DateTime.Now.ToString("yyyy'-'MM'-'dd");
            }
            if (id != null)
            {
                var mXe = new DMXeDao().GetById(id);
                ViewBag.Xe = mXe.BienSo;
                ViewBag.MaXe = mXe.MaXe;
                ViewBag.IdXe = mXe.Id;
            }
            var xe = new DMXeDao().GetById(id);
            var model = new CTTTLuongDao().PhatSinhLuong(id, NgayBD, NgayKT);
            var Loai = new PhatSinhDao().GetLoai(id);
            var tx = new PhatSinhDao().GetNvByXe(id, NgayBD, NgayKT);
            ViewBag.id = id;
            ViewBag.tx = tx.DMNhanVien.TenNV;
            ViewBag.Xe = xe.BienSo;
            ViewBag.NgayBD = NgayBD;
            ViewBag.NgayKT = NgayKT;
            ViewBag.N20 = model.Where(x => x.DMLoai.MaLoai == "20N").Count();
            ViewBag.X20 = model.Where(x => x.DMLoai.MaLoai == "20X").Count();
            ViewBag.N40 = model.Where(x => x.DMLoai.MaLoai == "40N").Count();
            ViewBag.X40 = model.Where(x => x.DMLoai.MaLoai == "40X").Count();
            ViewBag.Tong = (ViewBag.N20 + ViewBag.X20 + ViewBag.N40 + ViewBag.X40);
            return View(model);
        }

        [HttpPost]
        public ActionResult Thanhtoanchiho(PhatSinh phatSinh, string NgayBD, string NgayKT)
        {
            var xe = new DMNhanVienDao().GetById(phatSinh.Xe);
            var model = new CTTTLuongDao().PhatSinhLuong(phatSinh.Xe, NgayBD, NgayKT);
            var dao = new PhatSinhDao();
            var tx = new PhatSinhDao().GetNvByXe(phatSinh.Xe, NgayBD, NgayKT);
            var Loai = dao.GetLoai(xe.Id);
            ViewBag.id = phatSinh.Id;
            ViewBag.tx = tx.DMNhanVien.TenNV;
            ViewBag.NgayBD = NgayBD;
            ViewBag.NgayKT = NgayKT;
            ViewBag.N20 = model.Where(x => x.DMLoai.MaLoai == "20N").Count();
            ViewBag.X20 = model.Where(x => x.DMLoai.MaLoai == "20X").Count();
            ViewBag.N40 = model.Where(x => x.DMLoai.MaLoai == "40N").Count();
            ViewBag.X40 = model.Where(x => x.DMLoai.MaLoai == "40X").Count();
            ViewBag.Tong = (ViewBag.N20 + ViewBag.X20 + ViewBag.N40 + ViewBag.X40);
            return RedirectToAction("Thanhtoanchiho", "Luong", new { id = phatSinh.Xe, NgayBD = NgayBD, NgayKT = NgayKT });
        }


        [HttpGet]
        public PartialViewResult EditGhiChu(long id)
        {
            PhatSinh model = new PhatSinhDao().GetById(id);

            return PartialView("EditGhiChuLuong", model);
        }

        [HttpPost]
        public ActionResult EditGhiChu(PhatSinh phatSinh, string NgayBD, string NgayKT)
        {
            if (new PhatSinhDao().UpdateGhiChuLuong(phatSinh))
            {
                SetAlert("Đã thêm ghi chú lương thành công!", "success");
            }
            else
            {
                SetAlert("Thêm ghi chú lương không thành công, vui lòng thử lại!", "warning");
            }
            return RedirectToAction("CTTTLuong", "Luong", new { id = phatSinh.Xe, NgayBD = NgayBD, NgayKT = NgayKT });
        }

        [HttpGet]
        public PartialViewResult EditGhiChuChiPhi(long id)
        {
            PhatSinhChiThu model = new PhatSinhChiThuDao().GetById(id);
            return PartialView("EditGhiChuPhi", model);
        }

        [HttpPost]
        public ActionResult EditGhiChuChiPhi(PhatSinhChiThu phatSinhChiThu, string NgayBD, string NgayKT)
        {
            if (new PhatSinhChiDao().UpdateGhiChu(phatSinhChiThu))
            {
                SetAlert("Đã thêm ghi chú thành công!", "success");
            }
            else
            {
                SetAlert("Thêm ghi chú không thành công, vui lòng thử lại!", "warning");
            }
            return RedirectToAction("CTTTLuong", "Luong", new { id = phatSinhChiThu.NguoiNhan, NgayBD = NgayBD, NgayKT = NgayKT });
        }

        [HttpGet]
        public PartialViewResult EditGhiChuChiHo(long id)
        {
            PhatSinh model = new PhatSinhDao().GetById(id);

            return PartialView("EditGhiChuChiHo", model);
        }

        [HttpPost]
        public ActionResult EditGhiChuChiHo(PhatSinh phatSinh, string NgayBD, string NgayKT)
        {
            if (new PhatSinhDao().UpdateGhiChuChiHo(phatSinh))
            {
                SetAlert("Đã thêm ghi chú lương thành công!", "success");
            }
            else
            {
                SetAlert("Thêm ghi chú lương không thành công, vui lòng thử lại!", "warning");
            }
            return RedirectToAction("Thanhtoanchiho", "Luong", new { id = phatSinh.Xe, NgayBD = NgayBD, NgayKT = NgayKT });
        }


    }
}