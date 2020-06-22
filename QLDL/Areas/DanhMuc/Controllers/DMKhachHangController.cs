using QLDL.Common;
using QLDL.DAO;
using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace QLDL.Areas.DanhMuc.Controllers
{
    public class DMKhachHangController : BaseController
    {
        // GET: DMKhachHang
        public ActionResult Index()
        {
            var dao = new DMKhachHangDao();
            var model = dao.ListAll();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(int[] chkId, string delete = null)
        {
            var dao = new DMKhachHangDao();
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
        public PartialViewResult ViewDMKhachHang()
        {
            var dao = new DMKhachHangDao();
            var model = dao.ListAll();
            return PartialView(model);
        }
        [HttpGet]
        public ActionResult Create(long? id = null, string Copy = null)
        {
            if (id != null && Copy != null)
            {
                var dao = new DMKhachHangDao();
                var model = dao.GetById(id);
                return View(model);
            }
            else
            {

                return View();
            }
        }
        [HttpPost]
        public ActionResult Create(DMKhachHang dMKhachHang, int[] chkId, string delete = null)
        {
            var item = new DMKhachHangDao();
            if (delete != null && chkId != null)
            {
                var result = item.checkbox(chkId);
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
                    var dao = new DMKhachHangDao();
                    var Check = dao.Check(dMKhachHang.MaKH);
                    if (Check.Count > 0)
                    {
                        SetAlert("Mã khách hàng này đã tồn tại! " +
                            "Vui lòng nhập mã khách hàng khác!", "warning");
                        return RedirectToAction("Create", "DMKhachHang");
                    }
                    else
                    {
                        long id = dao.Insert(dMKhachHang);
                        if (id > 0)
                        {
                            SetAlert("Đã thêm Khách hàng thành công!", "success");
                            return RedirectToAction("Create", "DMKhachHang");
                        }
                        else
                        {
                            SetAlert("Thêm Khách hàng không thành công, vui lòng thử lại!", "warning");
                            return RedirectToAction("Create", "DMKhachHang");
                        }
                    }
                }
                SetAlert("Vui lòng nhập đầy đủ các ô trống!", "warning");

            }
            return RedirectToAction("Create", "DMKhachHang");
        }

        [HttpGet]
        public ActionResult Update(long id)
        {
            var dao = new DMKhachHangDao();
            var model = dao.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(DMKhachHang dMKhachHang, int[] chkId, string delete = null)
        {
            var item = new DMKhachHangDao();
            if (delete != null && chkId != null)
            {
                var result = item.checkbox(chkId);
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
                    var dao = new DMKhachHangDao();
                    var Check1 = dao.Check(dMKhachHang.MaKH);
                    var Check2 = dao.GetById(dMKhachHang.Id);
                    if (Check1.Count > 0 && Check2.MaKH != dMKhachHang.MaKH)
                    {
                        SetAlert("Mã khách hàng này đã tồn tại! " +
                            "Vui lòng nhập mã khách hàng khác!", "warning");
                        return RedirectToAction("Update", "DMKhachHang", new { id = dMKhachHang.Id });
                    }
                    else
                    {
                        var result = dao.Update(dMKhachHang);
                        if (result)
                        {
                            SetAlert("Cập nhật dữ liệu khách hàng thành công!", "success");
                            return RedirectToAction("Index", "DMKhachHang");
                        }
                        else
                        {
                            SetAlert("Cập nhật dữ liệu khách hàng không thành công", "warning");
                            return RedirectToAction("Update", "DMKhachHang");
                        }
                    }
                }
                SetAlert("Không có nội dung nào được chỉnh sửa", "warning");

            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            var result = new DMKhachHangDao().Delete(id);
            if (result)
            {
                SetAlert("Xóa khách hàng thành công", "success");
                return RedirectToAction("Index", "DMKhachHang");
            }
            else
            {
                SetAlert("Xóa khách hàng không thành công", "warning");
                return RedirectToAction("Index", "DMKhachHang");
            }
        }

        [ActionName("Importexcel")]
        [HttpPost]
        public ActionResult ImportExcel(DMKhachHang dMKhachHang, string sheet)
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
                        var dao = new DMKhachHangDao();

                        if (dao.importData(dt, dMKhachHang))
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
                        var dao = new DMKhachHangDao();

                        if (dao.importData(dt, dMKhachHang))
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
            return RedirectToAction("Index", "DMKhachHang");
        }
    }
}