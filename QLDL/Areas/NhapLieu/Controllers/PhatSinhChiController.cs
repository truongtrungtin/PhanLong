using QLDL.DAO;
using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace QLDL.Areas.NhapLieu.Controllers
{
    public class PhatSinhChiController : BaseController
    {
        // GET: DMPhi
        public ActionResult Index()
        {
            var dao = new PhatSinhChiDao();
            var model = dao.ListAll();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(int[] chkId, string delete = null)
        {
            var dao = new PhatSinhChiDao();
            if (delete != null && chkId != null)
            {
                var result = dao.checkbox(chkId);
                if (result)
                {
                    SetAlert("Đã xóa thành công!", "success");
                }
                else
                {
                    SetAlert("Xóa không thành công, vui lòng thử lại!", "warning");
                }
            }
            var model = dao.ListAll();
            return View(model);
        }

        [ChildActionOnly]
        public PartialViewResult ViewPhatSinhChi()
        {
            var dao = new PhatSinhChiDao();
            var model = dao.ListAll();
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Create(long? id = null, string Copy = null)
        {

            if (id != null && Copy != null)
            {
                var dao = new PhatSinhChiDao();
                var model = dao.GetById(id);
                SetViewBag();
                return View(model);
            }
            else
            {

                SetViewBag();
                return View();
            }
        }

        [HttpPost]
        public ActionResult Create(PhatSinhChi phatSinhChi, int[] chkId, string delete = null)
        {
            var ps = new PhatSinhChiDao();
            if (delete != null && chkId != null)
            {
                var result = ps.checkbox(chkId);
                if (result)
                {
                    SetAlert("Đã xóa thành công!", "success");
                }
                else
                {
                    SetAlert("Xóa không thành công, vui lòng thử lại!", "warning");
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var dao = new PhatSinhChiDao();
                    long result = dao.Insert(phatSinhChi);
                    if (result > 0)
                    {
                        SetAlert("Đã thêm bảng ghi thành công !", "success");
                        return RedirectToAction("Create", "PhatSinhChi");
                    }
                    else
                    {
                        SetAlert("Thêm bảng ghi không thành công, vui lòng thử lại!", "warning");
                        return RedirectToAction("Create", "PhatSinhChi");
                    }

                }
                SetAlert("Vui lòng nhập đầy đủ các ô trống!", "warning");

            }
            return RedirectToAction("Create", "PhatSinhChi");


        }
        [HttpGet]
        public ActionResult Update(long id)
        {
            var dao = new PhatSinhChiDao();
            var model = dao.GetById(id);
            SetViewBag();
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(PhatSinhChi phatSinhChi, int[] chkId, string delete = null)
        {
            var ps = new PhatSinhChiDao();
            if (delete != null && chkId != null)
            {
                var result = ps.checkbox(chkId);
                if (result)
                {
                    SetAlert("Đã xóa thành công!", "success");
                }
                else
                {
                    SetAlert("Xóa không thành công, vui lòng thử lại!", "warning");
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var dao = new PhatSinhChiDao();
                    var result = dao.Update(phatSinhChi);
                    if (result)
                    {
                        SetAlert("Cập nhật dữ liệu thành công!", "success");
                        return RedirectToAction("Update", "PhatSinhChi");
                    }
                    else
                    {
                        SetAlert("Cập nhật dữ liệu không thành công", "warning");
                        return RedirectToAction("Update", "PhatSinhChi");
                    }
                }
                SetAlert("Không có nội dung nào được chỉnh sửa", "warning");

            }
            return View("Update");
        }


        // Delete
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            var result = new PhatSinhChiDao().Delete(id);
            if (result)
            {
                SetAlert("Xóa dữ liệu thành công", "success");
                return RedirectToAction("Index", "PhatSinhChi");
            }
            else
            {
                SetAlert("Xóa dữ liệu không thành công", "warning");
                return RedirectToAction("Index", "PhatSinhChi");
            }
        }

        public void SetViewBag(long? selectedId = null)
        {
            var KhachHang = new DMKhachHangDao();
            var Bill = new DMBillDao();
            var Cang = new DMCangDao();
            var Kho = new DMKhoDao();
            var Phi = new DMPhiDao();
            var Loai = new DMLoaiDao();
            var NhanVien = new DMNhanVienDao();
            var Xe = new DMXeDao();
            var HinhThucTT = new HinhThucTTDao();
            ViewBag.KhachHang = new SelectList(KhachHang.ListAll(), "Id", "TenCongTy", selectedId);
            ViewBag.CangNhan = new SelectList(Cang.ListAll(), "Id", "TenCang", selectedId);
            ViewBag.CangTra = new SelectList(Cang.ListAll(), "Id", "TenCang", selectedId);
            ViewBag.PhiKH = new SelectList(Phi.ListAll(), "Id", "TenPhi", selectedId);
            ViewBag.PhiCT = new SelectList(Phi.ListAll(), "Id", "TenPhi", selectedId);
            ViewBag.Kho = new SelectList(Kho.ListAll(), "Id", "MaKho", selectedId);
            ViewBag.Loai = new SelectList(Loai.ListAll(), "Id", "MaLoai", selectedId);
            ViewBag.NguoiChi = new SelectList(NhanVien.ListAll(), "Id", "TenNV", selectedId);
            ViewBag.NguoiNhan = new SelectList(NhanVien.ListAll(), "Id", "TenNV", selectedId);
            ViewBag.Xe = new SelectList(Xe.ListAll(), "Id", "BienSo", selectedId);
            ViewBag.Bill = new SelectList(Bill.ListAll(), "Id", "MaBill", selectedId);
            ViewBag.HTTT = new SelectList(HinhThucTT.ListAll(), "Id", "MaHT", selectedId);
        }

        //Chi tiết chi
        public ActionResult CTChi(long id)
        {
            var dao = new PhatSinhChiDao().GetById(id);
            ViewBag.NgayChi = dao.NgayChi;
            ViewBag.NguoiChi = dao.DMNhanVien1.TenNV;
            ViewBag.NguoiNhan = dao.DMNhanVien.TenNV;
            ViewBag.HinhThucTT = dao.HinhThucTT.MoTa;
            ViewBag.SoHD = dao.SoHD;
            if (dao.DMBill != null)
            {
                ViewBag.Bill = dao.DMBill.MaBill;
            }
            ViewBag.MaKH = dao.DMKhachHang.TenCongTy;
            var model = new CTChiDao().ListAll(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult CTChi(long id, int[] chkId, string delete = null)
        {
            var dao = new CTChiDao();
            if (delete != null && chkId != null)
            {
                var result = dao.checkbox(chkId);
                if (result)
                {
                    SetAlert("Đã xóa thành công!", "success");
                }
                else
                {
                    SetAlert("Xóa không thành công, vui lòng thử lại!", "warning");
                }
            }
            var psc = new PhatSinhChiDao().GetById(id);
            ViewBag.NgayChi = psc.NgayChi;
            ViewBag.NguoiChi = psc.DMNhanVien1.TenNV;
            ViewBag.NguoiNhan = psc.DMNhanVien.TenNV;
            ViewBag.HinhThucTT = psc.HinhThucTT.MoTa;
            ViewBag.SoHD = psc.SoHD;
            if (psc.DMBill != null)
            {
                ViewBag.Bill = psc.DMBill.MaBill;
            }
            ViewBag.MaKH = psc.DMKhachHang.TenCongTy;
            var model = dao.ListAll(id);
            return View(model);
        }
    }
}