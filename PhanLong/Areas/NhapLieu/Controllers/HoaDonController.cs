using PhanLong.DAO;
using PhanLong.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhanLong.Common;
using Syncfusion.XlsIO;

namespace PhanLong.Areas.NhapLieu.Controllers
{
    public class HoaDonController : BaseController
    {
        // GET: NhapLieu/HoaDon
        public ActionResult Index()
        {
            var dao = new HoaDonDao();
            var model = dao.ListAll();
            return View(model);
        }


        [HttpPost]
        public ActionResult Index(int[] chkId, string delete = null, string update = null)
        {
            var dao = new HoaDonDao();
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
                return RedirectToAction("Update", "HoaDon", new { id = chkId[0] });
            }
            var model = dao.ListAll();
            return View(model);
        }

        public ActionResult KeHoach(long id)
        {
            var dao = new HoaDonDao();
            var model = dao.GetById(id);
            SetViewBag();
            return View(model);
        }

        [ChildActionOnly]
        public PartialViewResult ViewHoaDon()
        {
            var dao = new HoaDonDao();
            var model = dao.ListAll();
            return PartialView(model);
        }


        [HttpGet]
        public ActionResult Create(long? id = null, string Copy = null)
        {

            if (id != null && Copy != null)
            {
                var dao = new HoaDonDao();
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
        public ActionResult Create(HoaDon hoaDon, int[] chkId, string delete = null, string update = null)
        {
            var ps = new HoaDonDao();
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
                return RedirectToAction("Update", "HoaDon", new { id = chkId[0] });
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var dao = new HoaDonDao();
                    long result = dao.Insert(hoaDon);
                    if (result > 0)
                    {
                        SetAlert("Đã thêm bảng ghi thành công !", "success");
                        return RedirectToAction("Create", "HoaDon");
                    }
                    else
                    {
                        SetAlert("Thêm bảng ghi không thành công, vui lòng thử lại!", "warning");
                        return RedirectToAction("Create", "HoaDon");
                    }

                }
                SetAlert("Vui lòng nhập đầy đủ các ô trống!", "warning");

            }
            return RedirectToAction("Create", "HoaDon");


        }
        [HttpGet]
        public ActionResult Update(long id)
        {
            var dao = new HoaDonDao();
            var model = dao.GetById(id);
            SetViewBag();
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(HoaDon hoaDon, int[] chkId, string delete = null, string update = null)
        {
            var ps = new HoaDonDao();
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
                    var dao = new HoaDonDao();
                    var result = dao.Update(hoaDon);
                    if (result)
                    {
                        SetAlert("Cập nhật dữ liệu thành công!", "success");
                        return RedirectToAction("Index", "HoaDon");
                    }
                    else
                    {
                        SetAlert("Cập nhật dữ liệu không thành công", "warning");
                        return RedirectToAction("Update", "HoaDon");
                    }
                }
                SetAlert("Không có nội dung nào được chỉnh sửa", "warning");
            }
            return View("Index");
        }


        // Delete
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            var result = new HoaDonDao().Delete(id);
            if (result)
            {
                SetAlert("Xóa dữ liệu thành công", "success");
                return RedirectToAction("Index", "HoaDon");
            }
            else
            {
                SetAlert("Xóa dữ liệu không thành công", "warning");
                return RedirectToAction("Index", "HoaDon");
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
            ViewBag.Kho = new SelectList(Kho.ListAll(), "Id", "DiaChi", selectedId);
            ViewBag.Loai = new SelectList(Loai.ListAll(), "Id", "MaLoai", selectedId);
            ViewBag.TenTX = new SelectList(NhanVien.ListAll(), "Id", "TenNV", selectedId);
            ViewBag.Xe = new SelectList(Xe.ListAll(), "Id", "BienSo", selectedId);
            ViewBag.SoBill = new SelectList(Bill.ListAll(), "Id", "MaBill", selectedId);
        }

        [ActionName("ImportExcel")]
        [HttpPost]
        public ActionResult ImportExcel(HoaDon hoaDon, DMKhachHang dMKhachHang, DMBill dMBill, string sheet)
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
                        var dao = new HoaDonDao();

                        if (dao.importData(dt, hoaDon, dMKhachHang, dMBill))
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
                        var dao = new HoaDonDao();

                        if (dao.importData(dt, hoaDon, dMKhachHang, dMBill))
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
            return RedirectToAction("Index", "HoaDon");
        }
    }
}