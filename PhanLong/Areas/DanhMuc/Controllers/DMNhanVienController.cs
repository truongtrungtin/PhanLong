using PhanLong.Common;
using PhanLong.DAO;
using PhanLong.EF;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.Mvc;


namespace PhanLong.Areas.DanhMuc.Controllers
{
    public class DMNhanVienController : BaseController
    {
        // GET: DMNhanVien
        public ActionResult Index()
        {
            var dao = new DMNhanVienDao();
            var model = dao.ListAll();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(int[] chkId, string delete = null)
        {
            var dao = new DMNhanVienDao();
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
        public PartialViewResult ViewDMNhanVien()
        {
            var dao = new DMNhanVienDao();
            var model = dao.ListAll();
            return PartialView(model);
        }
        [HttpGet]
        [HasCredential(RoleId = "ADD_NHANVIEN")]
        public ActionResult Create(long? id = null, string Copy = null)
        {
            if (id != null && Copy != null)
            {
                var dao = new DMNhanVienDao();
                var model = dao.GetById(id);
                return View(model);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [HasCredential(RoleId = "ADD_NHANVIEN")]
        public ActionResult Create(DMNhanVien dMNhanVien, int[] chkId, string delete = null)
        {
            var item = new DMNhanVienDao();
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
                    var dao = new DMNhanVienDao();
                    var Check = dao.Check(dMNhanVien.MaNV);
                    if (Check.Count > 0)
                    {
                        SetAlert("Mã nhân viên này đã tồn tại! " +
                            "Vui lòng nhập mã nhân viên khác!", "warning");
                        return RedirectToAction("Create", "DMNhanVien");
                    }
                    else
                    {
                        long id = dao.Insert(dMNhanVien);
                        if (id > 0)
                        {
                            SetAlert("Đã thêm Khách hàng thành công!", "success");
                            return RedirectToAction("Create", "DMNhanVien");
                        }
                        else
                        {
                            SetAlert("Thêm Khách hàng không thành công, vui lòng thử lại!", "warning");
                            return RedirectToAction("Create", "DMNhanVien");
                        }
                    }
                }
                SetAlert("Vui lòng nhập đầy đủ các ô trống!", "warning");

            }
            return RedirectToAction("Create", "DMNhanVien");
        }

        [HttpGet]
        [HasCredential(RoleId = "EDIT_NHANVIEN")]
        public ActionResult Update(long id)
        {
            var dao = new DMNhanVienDao();
            var model = dao.GetById(id);
            return View(model);
        }
        [HttpPost]
        [HasCredential(RoleId = "EDIT_NHANVIEN")]
        public ActionResult Update(DMNhanVien dMNhanVien, int[] chkId, string delete = null)
        {
            var item = new DMNhanVienDao();
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
                    var dao = new DMNhanVienDao();
                    var Check1 = dao.Check(dMNhanVien.MaNV);
                    var Check2 = dao.GetById(dMNhanVien.Id);
                    if (Check1.Count > 0 && Check2.MaNV != dMNhanVien.MaNV)
                    {
                        SetAlert("Mã nhân viên này đã tồn tại! " +
                            "Vui lòng nhập mã xe khác!", "warning");
                        return RedirectToAction("Update", "DMNhanVien", new { id = dMNhanVien.Id });
                    }
                    else
                    {
                        var result = dao.Update(dMNhanVien);
                        if (result)
                        {
                            SetAlert("Cập nhật dữ liệu nhân viên thành công!", "success");
                            return RedirectToAction("Index", "DMNhanVien");
                        }
                        else
                        {
                            SetAlert("Cập nhật dữ liệu nhân viên không thành công", "warning");
                            return RedirectToAction("Update", "DMNhanVien");
                        }
                    }
                }
                SetAlert("Không có nội dung nào được chỉnh sửa", "warning");

            }
            return View("Index");
        }

        [HttpDelete]
        [HasCredential(RoleId = "DELETE_NHANVIEN")]
        public ActionResult Delete(long id)
        {
            var result = new DMNhanVienDao().Delete(id);
            if (result)
            {
                SetAlert("Xóa nhân viên thành công", "success");
                return RedirectToAction("Index", "DMNhanVien");
            }
            else
            {
                SetAlert("Xóa nhân viên không thành công", "warning");
                return RedirectToAction("Index", "DMNhanVien");
            }
        }

        [ActionName("Importexcel")]
        [HttpPost]
        [HasCredential(RoleId = "IMPORT_NHANVIEN")]
        public ActionResult ImportExcel(DMNhanVien dMNhanVien, string sheet)
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
                        var dao = new DMNhanVienDao();

                        if (dao.importData(dt, dMNhanVien))
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
                        var dao = new DMNhanVienDao();

                        if (dao.importData(dt, dMNhanVien))
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
            return RedirectToAction("Index", "DMNhanVien");
        }
    }
}