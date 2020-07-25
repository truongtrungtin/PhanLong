using PhanLong.Common;
using PhanLong.DAO;
using PhanLong.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace PhanLong.Areas.NhapLieu.Controllers
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
        public ActionResult Index(int[] chkId, string delete = null, string update = null, string chitiet = null)
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
            else if (update != null && chkId.Length == 1)
            {
                return RedirectToAction("Update", "PhatSinhChi", new { id = chkId[0] });
            }
            else if (chitiet != null && chkId.Length == 1)
            {
                return RedirectToAction("CTChi", "PhatSinhChi", new { id = chkId[0] });
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
        public ActionResult Create(PhatSinhChiThu phatSinhChi, CTChiThu cTChi, int[] chkId, string delete = null, string update = null, string chitiet = null)
        {
            var dao = new PhatSinhChiDao();
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
            else if (update != null && chkId.Length == 1)
            {
                return RedirectToAction("Update", "PhatSinhChi", new { id = chkId[0] });
            }
            else if (chitiet != null && chkId.Length == 1)
            {
                return RedirectToAction("CTChi", "PhatSinhChi", new { id = chkId[0] });
            }
            else
            {
                if (ModelState.IsValid)
                {
                    long result = dao.Insert(phatSinhChi);

                    if (result > 0)
                    {
                        if (ctChi.Insert(cTChi, result) > 0)
                        {
                            SetAlert("Đã thêm bảng ghi thành công !", "success");
                            return RedirectToAction("CTChi", "PhatSinhChi", new { id = result });
                        }
                        else
                        {
                            SetAlert("Thêm phí không thành công, vui lòng truy cập chi tiết để thêm phí!", "warning");
                            return RedirectToAction("CTChi", "PhatSinhChi", new { id = result });
                        }
                        
                    }
                    else
                    {
                        SetAlert("Thêm bảng ghi không thành công, vui lòng thử lại!", "warning");
                        return RedirectToAction("Create", "PhatSinhChi");
                    }
                }
                else
                {
                    SetAlert("Thêm bảng ghi không thành công, vui lòng thử lại!", "warning");
                    return RedirectToAction("Create", "PhatSinhChi");
                }
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
        public ActionResult Update(PhatSinhChiThu phatSinhChi, int[] chkId, string delete = null)
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
                        return RedirectToAction("CTChi", "PhatSinhChi", new { id = phatSinhChi.Id });
                    }
                    else
                    {
                        SetAlert("Cập nhật dữ liệu không thành công", "warning");
                        return RedirectToAction("Update", "PhatSinhChi");
                    }
                }
                SetAlert("Không có nội dung nào được chỉnh sửa", "warning");

            }
            return RedirectToAction("CTChi", "PhatSinhChi", new { id = phatSinhChi.Id });
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
        public ActionResult CTChi(long id)
        {
            var dao = new PhatSinhChiDao().GetById(id);
            ViewBag.IdChi = dao.Id;
            ViewBag.Ngay = dao.Ngay;
            ViewBag.NguoiChi = (dao.NguoiChiThu != null ? dao.DMNhanVien.TenNV : null);
            ViewBag.NguoiNhan = (dao.NguoiNhan != null ? dao.DMNhanVien.TenNV : null);
            ViewBag.HinhThucTT = (dao.HTTT != null ? dao.HinhThucTT.MoTa : null);
            ViewBag.Xe = (dao.Xe != null ? dao.DMXe.BienSo : null);
            ViewBag.Mooc = (dao.Mooc != null ? dao.DMMooc.BienSo : null);
            ViewBag.SoHD = (dao.SoHD != null ? dao.SoHD : null);
            ViewBag.Bill = (dao.Bill != null ? dao.DMBill.MaBill : null);
            ViewBag.MaKH = (dao.KhachHang != null ? dao.DMKhachHang.TenCongTy : null);
            var model = new CTChiDao().ListAll(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult CTChi(long id, int[] chkId, string delete = null, string update = null)
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
            else if (update != null && chkId.Length == 1)
            {
                return RedirectToAction("UpdateCTChi", "PhatSinhChi", new { id = chkId[0] });
            }
            var psc = new PhatSinhChiDao().GetById(id);
            ViewBag.IdChi = psc.Id;
            ViewBag.Ngay = psc.Ngay;
            ViewBag.NguoiChi = (psc.NguoiChiThu != null ? psc.DMNhanVien.TenNV : null);
            ViewBag.NguoiNhan = (psc.NguoiNhan != null ? psc.DMNhanVien.TenNV : null);
            ViewBag.HinhThucTT = (psc.HTTT != null ? psc.HinhThucTT.MoTa : null);
            ViewBag.Xe = (psc.Xe != null ? psc.DMXe.BienSo : null);
            ViewBag.Mooc = (psc.Mooc != null ? psc.DMMooc.BienSo : null);
            ViewBag.SoHD = (psc.SoHD != null ? psc.SoHD : null);
            ViewBag.Bill = (psc.Bill != null ? psc.DMBill.MaBill : null);
            ViewBag.MaKH = (psc.KhachHang != null ? psc.DMKhachHang.TenCongTy : null);
            var model = dao.ListAll(id);
            return View(model);
        }

        [ChildActionOnly]
        public PartialViewResult ViewCTChi(long id)
        {
            var dao = new PhatSinhChiDao().GetById(id);
            ViewBag.IdChi = dao.Id;
            ViewBag.Ngay = dao.Ngay;
            ViewBag.NguoiChi = (dao.NguoiChiThu != null ? dao.DMNhanVien.TenNV : null);
            ViewBag.NguoiNhan = (dao.NguoiNhan != null ? dao.DMKhachHang1.TenCongTy : null);
            ViewBag.HinhThucTT = (dao.HTTT != null ? dao.HinhThucTT.MoTa : null);
            ViewBag.Xe = (dao.Xe != null ? dao.DMXe.BienSo : null);
            ViewBag.Mooc = (dao.Mooc != null ? dao.DMMooc.BienSo : null);
            ViewBag.SoHD = (dao.SoHD != null ? dao.SoHD : null);
            ViewBag.Bill = (dao.Bill != null ? dao.DMBill.MaBill : null);
            ViewBag.MaKH = (dao.KhachHang != null ? dao.DMKhachHang.TenCongTy : null);
            var model = new CTChiDao().ListAll(id);
            return PartialView(model);
        }


        [HttpGet]
        public ActionResult CreateCTChi(long id, long? cTChi = null, string Copy = null, long? selectedId = null)
        {
            var Chi = new PhatSinhChiDao().GetById(id);
            if (cTChi != null && Copy != null)
            {
                ViewBag.HoaDon = Chi.SoHD;
                ViewBag.IdChi = Chi.Id;
                ViewBag.Bill = Chi.Bill;
                var dao = new CTChiDao();
                var model = dao.GetById(cTChi);
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
        public ActionResult CreateCTChi(CTChiThu cTChi, int[] chkId, string delete = null, string update = null)
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
            else if (update != null && chkId.Length == 1)
            {
                return RedirectToAction("UpdateCTChi", "PhatSinhChi", new { id = chkId[0] });
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var dao = new CTChiDao();
                    long result = dao.Insert(cTChi);
                    if (result > 0)
                    {
                        SetAlert("Đã thêm bảng ghi thành công !", "success");
                        return RedirectToAction("CTChi", "PhatSinhChi", new { id = cTChi.PhatSinhChiThu });
                    }
                    else
                    {
                        SetAlert("Thêm bảng ghi không thành công, vui lòng thử lại!", "warning");
                        return RedirectToAction("CreateCTChi", "PhatSinhChi", new { id = cTChi.PhatSinhChiThu1.Id });
                    }

                }
                SetAlert("Vui lòng nhập đầy đủ các ô trống!", "warning");

            }
            return RedirectToAction("CTChi", "PhatSinhChi", new { id = cTChi.PhatSinhChiThu1.Id });

        }


        [HttpGet]
        public ActionResult UpdateCTChi(long id)
        {
            var dao = new CTChiDao();
            var model = dao.GetById(id);
            ViewBag.HoaDon = model.PhatSinhChiThu != null ? model.PhatSinhChiThu1.SoHD : null;
            ViewBag.IdChi = model.PhatSinhChiThu;
            ViewBag.Bill = model.PhatSinhChiThu != null ? model.PhatSinhChiThu1.Bill : null;
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateCTChi(CTChiThu cTChi, int[] chkId, string delete = null)
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
                    var result = dao.Update(cTChi);
                    if (result)
                    {
                        SetAlert("Cập nhật dữ liệu thành công!", "success");
                        return RedirectToAction("CTChi", "PhatSinhChi", new { id = cTChi.PhatSinhChiThu1.Id });
                    }
                    else
                    {
                        SetAlert("Cập nhật dữ liệu không thành công", "warning");
                        return RedirectToAction("UpdateCTChi", "PhatSinhChi", new { id = cTChi.PhatSinhChiThu1.Id });
                    }
                }
                SetAlert("Không có nội dung nào được chỉnh sửa", "warning");

            }
            return RedirectToAction("CTChi", "PhatSinhChi", new { id = cTChi.PhatSinhChiThu1.Id });
        }

        [ActionName("Importexcel")]
        [HttpPost]
        public ActionResult ImportExcel(PhatSinhChiThu phatSinhChiThu, DMNhanVien dMNhanVien, HinhThucTT hinhThucTT, DMKhachHang dMKhachHang, DMBill dMBill, DMXe dMXe, DMMooc dMMooc, string sheet)
        {
            if (Request.Files["FileUpload"].ContentLength > 0)
            {
                string extension = System.IO.Path.GetExtension(Request.Files["FileUpload"].FileName).ToLower();
                string connString = "";
                string[] validFileTypes = { ".xls", ".xlsx", ".csv" };

                string path1 = string.Format("{0}/{1}", Server.MapPath("~/Content/Uploads"), Request.Files["FileUpload"].FileName);
                if (!Directory.Exists(path1))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Content/Uploads"));
                }
                if (validFileTypes.Contains(extension))
                {
                    DataTable dt;
                    if (System.IO.File.Exists(path1))
                    { System.IO.File.Delete(path1); }
                    Request.Files["FileUpload"].SaveAs(path1);
                    if (extension == ".csv")
                    {
                        dt = ExcelUpload.ConvertCSVtoDataTable(path1);
                        ViewBag.Data = dt;
                    }
                    //Connection String to Excel Workbook  
                    else if (extension.Trim() == ".xls")
                    {
                        connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path1 + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                        dt = ExcelUpload.ConvertXSLXtoDataTable(path1, connString, sheet);
                        ViewBag.Data = dt;
                        var dao = new PhatSinhChiDao();

                        if (dao.importData(dt, phatSinhChiThu, dMNhanVien, hinhThucTT, dMKhachHang, dMBill, dMXe, dMMooc))
                        {
                            SetAlert("Thêm thành công!", "success");
                        }
                        else
                        {
                            SetAlert("Thêm không thành công!", "warning");
                        }
                    }
                    else if (extension.Trim() == ".xlsx")
                    {
                        connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path1 + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                        dt = ExcelUpload.ConvertXSLXtoDataTable(path1, connString, sheet);
                        ViewBag.Data = dt;
                        var dao = new PhatSinhChiDao();

                        if (dao.importData(dt, phatSinhChiThu, dMNhanVien, hinhThucTT, dMKhachHang, dMBill, dMXe, dMMooc))
                        {
                            SetAlert("Thêm thành công!", "success");
                        }
                        else
                        {
                            SetAlert("Thêm không thành công!", "warning");
                        }
                    }
                }
                else
                {
                    ViewBag.Error = "Please Upload Files in .xls, .xlsx or .csv format";
                }
            }
            return RedirectToAction("Index", "PhatSinhChi");
        }

        [ActionName("ImportExcelCTPS")]
        [HttpPost]
        public ActionResult ImportExcelCTPS(CTChiThu cTChiThu, PhatSinhChiThu phatSinhChiThu, DMXe dMXe, DMMooc dMMooc, DMPhi dMPhi, string sheet)
        {
            if (Request.Files["FileUpload"].ContentLength > 0)
            {
                string extension = System.IO.Path.GetExtension(Request.Files["FileUpload"].FileName).ToLower();
                string connString = "";
                string[] validFileTypes = { ".xls", ".xlsx", ".csv" };

                string path1 = string.Format("{0}/{1}", Server.MapPath("~/Content/Uploads/DMBill/CTBill"), Request.Files["FileUpload"].FileName);
                if (!Directory.Exists(path1))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Content/Uploads/DMBill/CTBill"));
                }
                if (validFileTypes.Contains(extension))
                {
                    DataTable dt;
                    if (System.IO.File.Exists(path1))
                    { System.IO.File.Delete(path1); }
                    Request.Files["FileUpload"].SaveAs(path1);
                    if (extension == ".csv")
                    {
                        dt = ExcelUpload.ConvertCSVtoDataTable(path1);
                        ViewBag.Data = dt;
                    }
                    //Connection String to Excel Workbook  
                    else if (extension.Trim() == ".xls")
                    {
                        connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path1 + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                        dt = ExcelUpload.ConvertXSLXtoDataTable(path1, connString, sheet);
                        ViewBag.Data = dt;
                        var dao = new CTChiDao();

                        if (dao.importData(dt, cTChiThu, phatSinhChiThu, dMXe, dMMooc, dMPhi))
                        {
                            SetAlert("Thêm thành công!", "success");
                        }
                        else
                        {
                            SetAlert("Thêm không thành công!", "warning");
                        }
                    }
                    else if (extension.Trim() == ".xlsx")
                    {
                        connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path1 + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                        dt = ExcelUpload.ConvertXSLXtoDataTable(path1, connString, sheet);
                        ViewBag.Data = dt;
                        var dao = new CTChiDao();

                        if (dao.importData(dt, cTChiThu, phatSinhChiThu, dMXe, dMMooc, dMPhi))
                        {
                            SetAlert("Thêm thành công!", "success");
                        }
                        else
                        {
                            SetAlert("Thêm không thành công!", "warning");
                        }
                    }
                }
                else
                {
                    ViewBag.Error = "Please Upload Files in .xls, .xlsx or .csv format";
                }
            }
            return RedirectToAction("Index", "PhatSinhChi");
        }

    }
}