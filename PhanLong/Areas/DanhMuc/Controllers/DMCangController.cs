using PhanLong.Common;
using PhanLong.DAO;
using PhanLong.EF;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace PhanLong.Areas.DanhMuc.Controllers
{
    public class DMCangController : BaseController
    {
        // GET: DMCang
        public ActionResult Index()
        {
            var dao = new DMCangDao();
            var model = dao.ListAll();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(int[] chkId, string delete = null, string update = null)
        {
            var dao = new DMCangDao();
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
        public PartialViewResult ViewDMCang()
        {
            var dao = new DMCangDao();
            var model = dao.ListAll();
            return PartialView(model);
        }
        [HttpGet]
        [HasCredential(RoleId = "ADD_CANG")]
        public ActionResult Create(long? id = null, string Copy = null)
        {
            if (id != null && Copy != null)
            {
                var dao = new DMCangDao();
                var model = dao.GetById(id);
                return View(model);
            }
            else
            {

                return View();
            }
        }
        [HttpPost]
        [HasCredential(RoleId = "ADD_CANG")]
        public ActionResult Create(DMCang dMCang, int[] chkId, string delete = null)
        {
            var item = new DMCangDao();
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
                    var dao = new DMCangDao();
                    var Check = dao.Check(dMCang.MaCang);
                    if (Check.Count > 0)
                    {
                        SetAlert("Mã cảng này đã tồn tại! " +
                            "Vui lòng nhập mã cảng khác!", "warning");
                        return RedirectToAction("Create", "DMCang");
                    }
                    else
                    {
                        long id = dao.Insert(dMCang);
                        if (id > 0)
                        {
                            SetAlert("Đã thêm cảng thành công !", "success");
                            return RedirectToAction("Create", "DMCang");
                        }
                        else
                        {
                            SetAlert("Thêm cảng không thành công, vui lòng thử lại!", "warning");
                            return RedirectToAction("Create", "DMCang");
                        }
                    }
                }
                SetAlert("Vui lòng nhập đầy đủ các ô trống!", "warning");
            }
            return RedirectToAction("Create", "DMCang");
        }
        [HttpGet]
        [HasCredential(RoleId = "EDIT_CANG")]
        public ActionResult Update(long id)
        {
            var dao = new DMCangDao();
            var model = dao.GetById(id);
            return View(model);
        }
        [HttpPost]
        [HasCredential(RoleId = "EDIT_CANG")]
        public ActionResult Update(DMCang dMCang, int[] chkId, string delete = null)
        {
            var item = new DMCangDao();
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
                    var dao = new DMCangDao();
                    var Check1 = dao.Check(dMCang.MaCang);
                    var Check2 = dao.GetById(dMCang.Id);
                    if (Check1.Count > 0 && Check2.MaCang != dMCang.MaCang)
                    {
                        SetAlert("Mã cảng này đã tồn tại! " +
                            "Vui lòng nhập mã cảng khác!", "warning");
                        return RedirectToAction("Update", "DMCang", new { id = dMCang.Id });
                    }
                    else
                    {
                        var result = dao.Update(dMCang);
                        if (result)
                        {
                            SetAlert("Cập nhật dữ liệu cảng thành công!", "success");
                            return RedirectToAction("Index", "DMCang");
                        }
                        else
                        {
                            SetAlert("Cập nhật dữ liệu cảng không thành công", "warning");
                            return RedirectToAction("Update", "DMCang");
                        }
                    }
                }
                SetAlert("Không có nội dung nào được chỉnh sửa", "warning");

            }
            return View("Index");
        }

        // Delete
        [HttpDelete]
        [HasCredential(RoleId = "DELETE_CANG")]
        public ActionResult Delete(long id)
        {
            var result = new DMCangDao().Delete(id);
            if (result)
            {
                SetAlert("Xóa cảng thành công", "success");
                return RedirectToAction("Index", "DMCang");
            }
            else
            {
                SetAlert("Xóa cảng không thành công", "warning");
                return RedirectToAction("Index", "DMCang");
            }
        }

        [ActionName("Importexcel")]
        [HttpPost]
        [HasCredential(RoleId = "IMPORT_CANG")]
        public ActionResult ImportExcel(DMCang dMCang, string sheet)
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
                        var dao = new DMCangDao();

                        if (dao.importData(dt, dMCang))
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
                        var dao = new DMCangDao();

                        if (dao.importData(dt, dMCang))
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
            return RedirectToAction("Index", "DMCang");
        }
    }
}