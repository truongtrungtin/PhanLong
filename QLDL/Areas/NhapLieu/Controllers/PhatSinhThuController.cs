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
    public class PhatSinhThuController : BaseController
    {
        // GET: DMPhi
        public ActionResult Index()
        {
            var dao = new PhatSinhThuDao();
            var model = dao.ListAll();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(int[] chkId, string delete = null)
        {
            var dao = new PhatSinhThuDao();
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
        public PartialViewResult ViewPhatSinhThu()
        {
            var dao = new PhatSinhThuDao();
            var model = dao.ListAll();
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Create(long? id = null, string Copy = null)
        {

            if (id != null && Copy != null)
            {
                var dao = new PhatSinhThuDao();
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
        public ActionResult Create(PhatSinhChiThu phatSinhThu, CTChiThu cTThu, int[] chkId, string delete = null)
        {

            var dao = new PhatSinhThuDao();
            var ctChi = new CTChiDao();
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
            else
            {
                if (ModelState.IsValid)
                {
                    long result = dao.Insert(phatSinhThu);

                    if (result > 0)
                    {
                        if (ctChi.Insert(cTThu, result) > 0)
                        {
                            SetAlert("Đã thêm bảng ghi thành công !", "success");
                            return RedirectToAction("Create", "PhatSinhThu");
                        }
                        SetAlert("Thêm phí không thành công, vui lòng truy cập chi tiết để thêm phí!", "warning");
                        return RedirectToAction("Create", "PhatSinhThu"); ;
                    }
                    else
                    {
                        SetAlert("Thêm bảng ghi không thành công, vui lòng thử lại!", "warning");
                        return RedirectToAction("Create", "PhatSinhThu");
                    }
                }
                else
                {
                    SetAlert("Thêm bảng ghi không thành công, vui lòng thử lại!", "warning");
                    return RedirectToAction("Create", "PhatSinhThu");
                }
            }
            return RedirectToAction("Create", "PhatSinhThu");


        }
        [HttpGet]
        public ActionResult Update(long id)
        {
            var dao = new PhatSinhThuDao();
            var model = dao.GetById(id);
            SetViewBag();
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(PhatSinhChiThu phatSinhThu, int[] chkId, string delete = null)
        {
            var ps = new PhatSinhThuDao();
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
                    var dao = new PhatSinhThuDao();
                    var result = dao.Update(phatSinhThu);
                    if (result)
                    {
                        SetAlert("Cập nhật dữ liệu thành công!", "success");
                        return RedirectToAction("Index", "PhatSinhThu");
                    }
                    else
                    {
                        SetAlert("Cập nhật dữ liệu không thành công", "warning");
                        return RedirectToAction("Update", "PhatSinhThu");
                    }
                }

            }
            return View("Index");
        }


        // Delete
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            var result = new PhatSinhThuDao().Delete(id);
            if (result)
            {
                SetAlert("Xóa dữ liệu thành công", "success");
                return RedirectToAction("Index", "PhatSinhThu");
            }
            else
            {
                SetAlert("Xóa dữ liệu không thành công", "warning");
                return RedirectToAction("Index", "PhatSinhThu");
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

            var Mooc = new DMMoocDao();
            var HinhThucTT = new HinhThucTTDao();
            ViewBag.KhachHang = new SelectList(KhachHang.ListAll(), "Id", "TenCongTy", selectedId);
            ViewBag.CangNhan = new SelectList(Cang.ListAll(), "Id", "TenCang", selectedId);
            ViewBag.CangTra = new SelectList(Cang.ListAll(), "Id", "TenCang", selectedId);
            ViewBag.PhiKH = new SelectList(Phi.ListAll(), "Id", "TenPhi", selectedId);
            ViewBag.PhiCT = new SelectList(Phi.ListAll(), "Id", "TenPhi", selectedId);
            ViewBag.Phi = new SelectList(Phi.ListAll(), "Id", "TenPhi", selectedId);
            ViewBag.Kho = new SelectList(Kho.ListAll(), "Id", "MaKho", selectedId);
            ViewBag.Loai = new SelectList(Loai.ListAll(), "Id", "MaLoai", selectedId);
            ViewBag.NguoiChi = new SelectList(NhanVien.ListAll(), "Id", "TenNV", selectedId);
            ViewBag.NguoiNhan = new SelectList(NhanVien.ListAll(), "Id", "TenNV", selectedId);
            ViewBag.Xe = new SelectList(Xe.ListAll(), "Id", "BienSo", selectedId);
            ViewBag.Mooc = new SelectList(Mooc.ListAll(), "Id", "BienSo", selectedId);
            ViewBag.Bill = new SelectList(Bill.ListAll(), "Id", "MaBill", selectedId);
            ViewBag.HTTT = new SelectList(HinhThucTT.ListAll(), "Id", "MaHT", selectedId);
        }

        //Chi tiết chi
        public ActionResult CTThu(long id)
        {
            var dao = new PhatSinhThuDao().GetById(id);
            ViewBag.IdThu = dao.Id;
            ViewBag.Ngay = dao.Ngay;
            ViewBag.NguoiChiThu = (dao.NguoiChiThu != null ? dao.DMNhanVien1.TenNV : null);
            ViewBag.NguoiNhan = (dao.NguoiNhan != null ? dao.DMNhanVien.TenNV : null);
            ViewBag.HinhThucTT = (dao.HTTT != null ? dao.HinhThucTT.MoTa : null);
            ViewBag.SoHD = (dao.SoHD != null ? dao.SoHD : null);
            ViewBag.Bill = (dao.Bill != null ? dao.DMBill.MaBill : null);
            ViewBag.MaKH = (dao.KhachHang != null ? dao.DMKhachHang.TenCongTy : null);
            var model = new CTChiDao().ListAll(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult CTThu(long id, int[] chkId, string delete = null)
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
            var psc = new PhatSinhThuDao().GetById(id);
            ViewBag.IdChi = psc.Id;
            ViewBag.NgayThu = psc.Ngay;
            ViewBag.NguoiThu = (psc.NguoiChiThu != null ? psc.DMNhanVien1.TenNV : null);
            ViewBag.NguoiNhan = (psc.NguoiNhan != null ? psc.DMNhanVien.TenNV : null);
            ViewBag.HinhThucTT = (psc.HTTT != null ? psc.HinhThucTT.MoTa : null);
            ViewBag.SoHD = (psc.SoHD != null ? psc.SoHD : null);
            ViewBag.Bill = (psc.Bill != null ? psc.DMBill.MaBill : null);
            ViewBag.MaKH = (psc.KhachHang != null ? psc.DMKhachHang.TenCongTy : null);
            var model = dao.ListAll(id);
            return View(model);
        }

        [ChildActionOnly]
        public PartialViewResult ViewCTChi(long id)
        {
            var dao = new PhatSinhThuDao().GetById(id);
            ViewBag.IdChi = dao.Id;
            ViewBag.NgayThu = dao.Ngay;
            ViewBag.NguoiThu = (dao.NguoiChiThu != null ? dao.DMNhanVien1.TenNV : null);
            ViewBag.NguoiNhan = (dao.NguoiNhan != null ? dao.DMNhanVien.TenNV : null);
            ViewBag.HinhThucTT = (dao.HTTT != null ? dao.HinhThucTT.MoTa : null);
            ViewBag.SoHD = (dao.SoHD != null ? dao.SoHD : null);
            ViewBag.Bill = (dao.Bill != null ? dao.DMBill.MaBill : null);
            ViewBag.MaKH = (dao.KhachHang != null ? dao.DMKhachHang.TenCongTy : null);
            var model = new CTChiDao().ListAll(id);
            return PartialView(model);
        }


        [HttpGet]
        public ActionResult CreateCTThu(long id, long? cTThu = null, string Copy = null, long? selectedId = null)
        {
            var Chi = new PhatSinhThuDao().GetById(id);
            if (cTThu != null && Copy != null)
            {
                ViewBag.HoaDon = Chi.SoHD;
                ViewBag.IdChi = Chi.Id;
                ViewBag.Bill = Chi.Bill;
                var dao = new CTChiDao();
                var model = dao.GetById(cTThu);
                SetViewBag();
                return View(model);
            }
            else
            {
                var cont = new CTBillDao();
                ViewBag.Cont = (Chi.Bill != null ? new SelectList(cont.ListAll(Chi.Bill), "Cont", "Cont", selectedId) : null);
                ViewBag.HoaDon = Chi.SoHD;
                ViewBag.IdChi = Chi.Id;
                SetViewBag();
                return View();
            }
        }

        [HttpPost]
        public ActionResult CreateCTThu(CTChiThu cTThu, int[] chkId, string delete = null)
        {
            var ps = new CTChiDao();
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
                    var dao = new CTChiDao();
                    long result = dao.Insert(cTThu);
                    if (result > 0)
                    {
                        SetAlert("Đã thêm bảng ghi thành công !", "success");
                        return RedirectToAction("CTThu", "phatSinhThu", new { id = cTThu.PhatSinhChiThu });
                    }
                    else
                    {
                        SetAlert("Thêm bảng ghi không thành công, vui lòng thử lại!", "warning");
                        return RedirectToAction("CreateCTThu", "phatSinhThu", new { id = cTThu.PhatSinhChiThu1.Id });
                    }

                }
                SetAlert("Vui lòng nhập đầy đủ các ô trống!", "warning");

            }
            return RedirectToAction("CTThu", "phatSinhThu", new { id = cTThu.PhatSinhChiThu1.Id });

        }


        [HttpGet]
        public ActionResult UpdateCTChi(long id)
        {
            var dao = new CTChiDao();
            var model = dao.GetById(id);
            SetViewBag();
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateCTChi(CTChiThu cTThu, int[] chkId, string delete = null)
        {
            var ps = new CTChiDao();
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
                    var dao = new CTChiDao();
                    var result = dao.Update(cTThu);
                    if (result)
                    {
                        SetAlert("Cập nhật dữ liệu thành công!", "success");
                        return RedirectToAction("Update", "CTThu");
                    }
                    else
                    {
                        SetAlert("Cập nhật dữ liệu không thành công", "warning");
                        return RedirectToAction("Update", "CTThu");
                    }
                }
                SetAlert("Không có nội dung nào được chỉnh sửa", "warning");

            }
            return RedirectToAction("CTThu", "PhatSinhChiThu", new { id = cTThu.PhatSinhChiThu1.Id });
        }

    }
}