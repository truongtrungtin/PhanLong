using QLDL.DAO;
using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLDL.Controllers
{
    public class PhatSinhController : BaseController
    {
        // GET: DMPhi
        public ActionResult Index()
        {
            var dao = new PhatSinhDao();
            var model = dao.ListAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult Create(PhatSinh phatSinh)
        {
            if (ModelState.IsValid)
            {
                var dao = new PhatSinhDao();

                long id = dao.Insert(phatSinh);
                if (id > 0)
                {
                    SetAlert("Đã thêm bảng ghi thành công !", "success");
                    return RedirectToAction("Index", "PhatSinh");
                }
                else
                {
                    SetAlert("Thêm bảng ghi không thành công, vui lòng thử lại!", "warning");
                    return RedirectToAction("Create", "PhatSinh");
                }

            }
            SetAlert("Vui lòng nhập đầy đủ các ô trống!", "warning");
            return RedirectToAction("Create", "PhatSinh");
        }
        [HttpGet]
        public ActionResult Update(long id)
        {
            var dao = new PhatSinhDao();
            var model = dao.GetById(id);
            SetViewBag();
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(PhatSinh phatSinh)
        {
            if (ModelState.IsValid)
            {
                var dao = new PhatSinhDao();
                var result = dao.Update(phatSinh);
                if (result)
                {
                    SetAlert("Cập nhật dữ liệu thành công!", "success");
                    return RedirectToAction("Index", "PhatSinh");
                }
                else
                {
                    SetAlert("Cập nhật dữ liệu không thành công", "warning");
                    return RedirectToAction("Update", "PhatSinh");
                }
            }
            return View("Index");
        }

        // Delete
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            var result = new PhatSinhDao().Delete(id);
            if (result)
            {
                SetAlert("Xóa dữ liệu thành công", "success");
                return RedirectToAction("Index", "PhatSinh");
            }
            else
            {
                SetAlert("Xóa dữ liệu không thành công", "warning");
                return RedirectToAction("Index", "PhatSinh");
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
            ViewBag.KhachHang = new SelectList(KhachHang.ListAll(), "Id", "TenCongTy", selectedId);
            ViewBag.CangNhan = new SelectList(Cang.ListAll(), "Id", "TenCang", selectedId);
            ViewBag.CangTra = new SelectList(Cang.ListAll(), "Id", "TenCang", selectedId);
            ViewBag.PhiKH = new SelectList(Phi.ListAll(), "Id", "TenPhi", selectedId);
            ViewBag.PhiCT = new SelectList(Phi.ListAll(), "Id", "TenPhi", selectedId);
            ViewBag.Kho = new SelectList(Kho.ListAll(), "Id", "MaKho", selectedId);
            ViewBag.Loai = new SelectList(Loai.ListAll(), "Id", "MaLoai", selectedId);
            ViewBag.TenTX = new SelectList(NhanVien.ListAll(), "Id", "TenNV", selectedId);
            ViewBag.Xe = new SelectList(Xe.ListAll(), "Id", "BienSo", selectedId);
            ViewBag.SoBill = new SelectList(Bill.ListAll(), "Id", "MaBill", selectedId);
        }
    }
}