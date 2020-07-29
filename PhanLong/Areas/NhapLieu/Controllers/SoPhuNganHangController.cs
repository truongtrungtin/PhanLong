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

namespace PhanLong.Areas.NhapLieu.Controllers
{
    public class SoPhuNganHangController : BaseController
    {
        // GET: NhapLieu/SoPhuNganHang
        public ActionResult Index()
        {  
             
            var dao = new SoPhuNganHangDao();
            var model = dao.ListAll();
            return View(model);
        }


        [HttpPost]
        public ActionResult Index(int[] chkId, string delete = null, string update = null)
        {
            var dao = new SoPhuNganHangDao();
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
                return RedirectToAction("Update", "SoPhuNganHang", new { id = chkId[0] });
            }
            var model = dao.ListAll();
            return View(model);
        }

        [ChildActionOnly]
        public PartialViewResult ViewSoPhuNganHang()
        {
            var dao = new SoPhuNganHangDao();
            var model = dao.ListAll();
            return PartialView(model);
        }


        [HttpGet]
        [HasCredential(RoleId = "ADD_SOPHUNGANHANG")]
        public ActionResult Create(long? id = null)
        {
            return View();
        }

        [HttpPost]
        [HasCredential(RoleId = "ADD_SOPHUNGANHANG")]
        public ActionResult Create(SoPhuNganHang soPhuNganHang, int[] chkId, string delete = null, string update = null)
        {
            var ps = new SoPhuNganHangDao();
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
                return RedirectToAction("Update", "SoPhuNganHang", new { id = chkId[0] });
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var dao = new SoPhuNganHangDao();
                    long result = dao.Insert(soPhuNganHang);
                    if (result > 0)
                    {
                        SetAlert("Đã thêm bảng ghi thành công !", "success");
                        return RedirectToAction("Create", "SoPhuNganHang");
                    }
                    else
                    {
                        SetAlert("Thêm bảng ghi không thành công, vui lòng thử lại!", "warning");
                        return RedirectToAction("Create", "SoPhuNganHang");
                    }

                }
                SetAlert("Vui lòng nhập đầy đủ các ô trống!", "warning");

            }
            return RedirectToAction("Create", "SoPhuNganHang");


        }
        [HttpGet]
        [HasCredential(RoleId = "EDIT_SOPHUNGANHANG")]
        public ActionResult Update(long id)
        {
            var dao = new SoPhuNganHangDao();
            var model = dao.GetById(id);
            return View(model);
        }
        [HttpPost]
        [HasCredential(RoleId = "EDIT_SOPHUNGANHANG")]
        public ActionResult Update(SoPhuNganHang soPhuNganHang, int[] chkId, string delete = null)
        {
            var ps = new SoPhuNganHangDao();
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
                    var dao = new SoPhuNganHangDao();
                    var result = dao.Update(soPhuNganHang);
                    if (result)
                    {
                        SetAlert("Cập nhật dữ liệu thành công!", "success");
                        return RedirectToAction("Index", "SoPhuNganHang");
                    }
                    else
                    {
                        SetAlert("Cập nhật dữ liệu không thành công", "warning");
                        return RedirectToAction("Update", "SoPhuNganHang");
                    }
                }
                SetAlert("Không có nội dung nào được chỉnh sửa", "warning");
            }
            return View("Index");
        }


        // Delete
        [HttpDelete]
        [HasCredential(RoleId = "DELETE_SOPHUNGANHANG")]
        public ActionResult Delete(long id)
        {
            var result = new SoPhuNganHangDao().Delete(id);
            if (result)
            {
                SetAlert("Xóa dữ liệu thành công", "success");
                return RedirectToAction("Index", "SoPhuNganHang");
            }
            else
            {
                SetAlert("Xóa dữ liệu không thành công", "warning");
                return RedirectToAction("Index", "SoPhuNganHang");
            }
        }

        [ActionName("ImportExcel")]
        [HttpPost]
        [HasCredential(RoleId = "IMPORT_SOPHUNGANHANG")]
        public ActionResult ImportExcel(SoPhuNganHang soPhuNganHang, DMKhachHang dMKhachHang, HinhThucTT hinhThucTT, DMPhi dMPhi, string sheet)
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
                        var dao = new SoPhuNganHangDao();

                        if (dao.importData(dt, soPhuNganHang, dMKhachHang, hinhThucTT, dMPhi))
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
                        var dao = new SoPhuNganHangDao();

                        if (dao.importData(dt, soPhuNganHang, dMKhachHang, hinhThucTT, dMPhi))
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
            return RedirectToAction("Index", "SoPhuNganHang");
        }
    }
}