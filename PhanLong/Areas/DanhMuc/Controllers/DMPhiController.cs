using PhanLong.Common;
using PhanLong.DAO;
using PhanLong.EF;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.Mvc;


namespace PhanLong.Areas.DanhMuc.Controllers
{
    public class DMPhiController : BaseController
    {
        // GET: DMPhi
        public ActionResult Index()
        {
            var dao = new DMPhiDao();
            var model = dao.ListAll();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(int[] chkId, string delete = null)
        {
            var dao = new DMPhiDao();
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
        public PartialViewResult ViewDMPhi()
        {
            var dao = new DMPhiDao();
            var model = dao.ListAll();
            return PartialView(model);
        }
        [HttpGet]
        [HasCredential(RoleId = "ADD_PHI")]
        public ActionResult Create(long? id = null, string Copy = null)
        {
            if (id != null && Copy != null)
            {
                var dao = new DMPhiDao();
                var model = dao.GetById(id);
                return View(model);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [HasCredential(RoleId = "ADD_PHI")]
        public ActionResult Create(DMPhi dMPhi, int[] chkId, string delete = null)
        {
            var item = new DMPhiDao();
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
                    var dao = new DMPhiDao();
                    var Check = dao.Check(dMPhi.MaPhi);
                    if (Check.Count > 0)
                    {
                        SetAlert("Mã Phí này đã tồn tại! " +
                            "Vui lòng nhập mã Phí khác!", "warning");
                        return RedirectToAction("Create", "DMPhi");
                    }
                    else
                    {
                        long id = dao.Insert(dMPhi);
                        if (id > 0)
                        {
                            SetAlert("Đã thêm Phí thành công !", "success");
                            return RedirectToAction("Create", "DMPhi");
                        }
                        else
                        {
                            SetAlert("Thêm Phí không thành công, vui lòng thử lại!", "warning");
                            return RedirectToAction("Create", "DMPhi");
                        }
                    }
                }
                SetAlert("Vui lòng nhập đầy đủ các ô trống!", "warning");

            }
            return RedirectToAction("Create", "DMPhi");
        }
        [HttpGet]
        [HasCredential(RoleId = "EDIT_PHI")]
        public ActionResult Update(long id)
        {
            var dao = new DMPhiDao();
            var model = dao.GetById(id);
            return View(model);
        }
        [HttpPost]
        [HasCredential(RoleId = "EDIT_PHI")]
        public ActionResult Update(DMPhi dMPhi, int[] chkId, string delete = null)
        {
            var item = new DMPhiDao();
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
                    var dao = new DMPhiDao();
                    var Check1 = dao.Check(dMPhi.MaPhi);
                    var Check2 = dao.GetById(dMPhi.Id);
                    if (Check1.Count > 0 && Check2.MaPhi != dMPhi.MaPhi)
                    {
                        SetAlert("Mã Phí này đã tồn tại! " +
                            "Vui lòng nhập mã Phí khác!", "warning");
                        return RedirectToAction("Index", "DMPhi", new { id = dMPhi.Id });
                    }
                    else
                    {
                        var result = dao.Update(dMPhi);
                        if (result)
                        {
                            SetAlert("Cập nhật dữ liệu Phí thành công!", "success");
                            return RedirectToAction("Update", "DMPhi");
                        }
                        else
                        {
                            SetAlert("Cập nhật dữ liệu Phí không thành công", "warning");
                            return RedirectToAction("Update", "DMPhi");
                        }
                    }
                }
                SetAlert("Không có nội dung nào được chỉnh sửa", "warning");

            }
            return View("Index");
        }

        // Delete
        [HttpDelete]
        [HasCredential(RoleId = "DELETE_PHI")]
        public ActionResult Delete(long id)
        {
            var result = new DMPhiDao().Delete(id);
            if (result)
            {
                SetAlert("Xóa Phí thành công", "success");
                return RedirectToAction("Index", "DMPhi");
            }
            else
            {
                SetAlert("Xóa Phí không thành công", "warning");
                return RedirectToAction("Index", "DMPhi");
            }
        }

        [ActionName("ImportExcel")]
        [HttpPost]
        [HasCredential(RoleId = "IMPORT_PHI")]
        public ActionResult ImportExcel(DMPhi dMPhi, string sheet)
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
                        var dao = new DMPhiDao();

                        if (dao.importData(dt, dMPhi))
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
                        var dao = new DMPhiDao();

                        if (dao.importData(dt, dMPhi))
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
            return RedirectToAction("Index", "DMPhi");
        }
    }
}