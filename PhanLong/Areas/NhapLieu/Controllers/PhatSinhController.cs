using PhanLong.Common;
using PhanLong.DAO;
using PhanLong.EF;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace PhanLong.Areas.NhapLieu.Controllers
{
    public class PhatSinhController : BaseController
    {
        public ActionResult Index()
        {
            var dao = new PhatSinhDao();
            var model = dao.ListAll();
            return View(model);
        }


        [HttpPost]
        public ActionResult Index(int[] chkId, string delete = null, string update = null, string kehoach = null)
        {
            var dao = new PhatSinhDao();
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
                return RedirectToAction("Update", "PhatSinh", new { id = chkId[0] });
            }
            else if (kehoach != null && chkId.Length == 1)
            {
                return RedirectToAction("KeHoach", "PhatSinh", new { id = chkId[0] });
            }
            var model = dao.ListAll();
            return View(model);
        }

        public ActionResult KeHoach(long id)
        {
            var dao = new PhatSinhDao();
            var model = dao.GetById(id);
            return View(model);
        }

        [ChildActionOnly]
        public PartialViewResult ViewPhatSinh()
        {
            var dao = new PhatSinhDao();
            var model = dao.ListAll();
            return PartialView(model);
        }


        [HttpGet]
        [HasCredential(RoleId = "ADD_PHATSINH")]
        public ActionResult Create(long? id = null, string Copy = null)
        {

            if (id != null && Copy != null)
            {
                var dao = new PhatSinhDao();
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
        [HasCredential(RoleId = "ADD_PHATSINH")]
        public ActionResult Create(PhatSinh phatSinh, int[] chkId, string delete = null, string update = null, string kehoach = null)
        {
            var ps = new PhatSinhDao();
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
                return RedirectToAction("Update", "PhatSinh", new { id = chkId[0] });
            }
            else if (kehoach != null && chkId.Length == 1)
            {
                return RedirectToAction("KeHoach", "PhatSinh", new { id = chkId[0] });
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var dao = new PhatSinhDao();
                    long result = dao.Insert(phatSinh);
                    if (result > 0)
                    {
                        SetAlert("Đã thêm bảng ghi thành công !", "success");
                        return RedirectToAction("Create", "PhatSinh");
                    }
                    else
                    {
                        SetAlert("Thêm bảng ghi không thành công, vui lòng thử lại!", "warning");
                        return RedirectToAction("Create", "PhatSinh");
                    }
                }
                SetAlert("Vui lòng nhập đầy đủ các ô trống!", "warning");
            }
            return RedirectToAction("Create", "PhatSinh");


        }
        [HttpGet]
        [HasCredential(RoleId = "EDIT_PHATSINH")]
        public ActionResult Update(long id)
        {
            var dao = new PhatSinhDao();
            var model = dao.GetById(id);
            SetViewBag();
            return View(model);
        }
        [HttpPost]
        [HasCredential(RoleId = "EDIT_PHATSINH")]
        public ActionResult Update(PhatSinh phatSinh, int[] chkId, string delete = null, string copy = null)
        {
            var ps = new PhatSinhDao();
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
                    var dao = new PhatSinhDao();
                    var result = dao.Update(phatSinh);
                    if (result)
                    {
                        SetAlert("Cập nhật dữ liệu thành công!", "success");
                        return RedirectToAction("Update", "PhatSinh", phatSinh.Id);
                    }
                    else
                    {
                        SetAlert("Cập nhật dữ liệu không thành công", "warning");
                        return RedirectToAction("Update", "PhatSinh", phatSinh.Id);
                    }
                }
                SetAlert("Không có nội dung nào được chỉnh sửa", "warning");
            }
            return View("Index");
        }


        // Delete
        [HttpDelete]
        [HasCredential(RoleId = "DELETE_PHATSINH")]
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
            ViewBag.Kho = new SelectList(Kho.ListAll(), "Id", "DiaChi", selectedId);
            ViewBag.Loai = new SelectList(Loai.ListAll(), "Id", "MaLoai", selectedId);
            ViewBag.TenTX = new SelectList(NhanVien.ListAll(), "Id", "TenNV", selectedId);
            ViewBag.Xe = new SelectList(Xe.ListAll(), "Id", "BienSo", selectedId);
            ViewBag.SoBill = new SelectList(Bill.ListAll(), "Id", "MaBill", selectedId);
        }

        [ActionName("ImportExcel")]
        [HttpPost]
        [HasCredential(RoleId = "IMPORT_PHATSINH")]
        public ActionResult ImportExcel(PhatSinh phatsinh, DMLoai dMLoai, DMKhachHang dMKhachHang, DMKho dMKho, DMXe dMXe, DMNhanVien dMNhanVien, DMPhi dMPhi, DMThoiGian dMThoiGian, DMCang dMCang, DMBill dMBill, string sheet)
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
                        var dao = new PhatSinhDao();

                        if (dao.importData(dt, phatsinh, dMLoai, dMKhachHang, dMKho, dMXe, dMNhanVien, dMPhi, dMThoiGian, dMCang, dMBill))
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
                        var dao = new PhatSinhDao();

                        if (dao.importData(dt, phatsinh, dMLoai, dMKhachHang, dMKho, dMXe, dMNhanVien, dMPhi, dMThoiGian, dMCang, dMBill))
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
            return RedirectToAction("Index", "PhatSinh");
        }


        public PartialViewResult ajaxDataBill(long id)
        {
            var model = new CTBillDao().getbill(id);
            return PartialView(model);
        }

        public PartialViewResult ajaxInputCont()
        {
            return PartialView();
        }
    }


}