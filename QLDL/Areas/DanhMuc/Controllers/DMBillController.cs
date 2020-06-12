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
    public class DMBillController : BaseController
    {
        public ActionResult Index()
        {
            var dao = new DMBillDao();
            var model = dao.ListAll();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(int[] chkId, string delete = null)
        {
            var dao = new DMBillDao();
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
        public PartialViewResult ViewDMBill()
        {
            var dao = new DMBillDao();
            var model = dao.ListAll();
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Create(long? id = null, string Copy = null)
        {

            if (id != null && Copy != null)
            {
                var dao = new DMBillDao();
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
        public ActionResult Create(DMBill dMBill, CTBill cTBill, int[] chkId, string delete = null)
        {
            var ps = new DMBillDao();
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
                    var dao = new DMBillDao();
                    var ctbill = new CTBillDao();
                    var Check = dao.Check(dMBill.MaBill);
                    if (Check.Count > 0)
                    {
                        SetAlert("Mã Bill này đã tồn tại! " +
                            "Vui lòng nhập mã Bill khác!", "warning");
                        return RedirectToAction("Create", "DMBill");
                    }
                    else
                    {
                        long id = dao.Insert(dMBill);
                        if (id > 0)
                        {
                            if (cTBill.Cont != null)
                            {
                                if (ctbill.InsertCTBill(cTBill) > 0)
                                {
                                    SetAlert("Cont " + cTBill.Cont + " đã thêm thành công!", "success");
                                }
                                else
                                {
                                    SetAlert("Cont " + cTBill.Cont + " chưa thêm thành công!", "warning");
                                }
                            }
                           
                            SetAlert("Đã thêm Bill thành công !", "success");
                            return RedirectToAction("CTBill", "DMBill", new { id = ctbill.GetLastIdBill().Id });
                        }
                        else
                        {
                            SetAlert("Thêm Bill không thành công, vui lòng thử lại!", "warning");
                            return RedirectToAction("Create", "DMBill");
                        }
                    }
                }
                SetAlert("Vui lòng nhập đầy đủ các ô trống!", "warning");

            }
            return RedirectToAction("Create", "DMBill");
        }

        public void SetViewBag(long? selectedId = null)
        {
            var KhachHang = new DMKhachHangDao();
            var Cang = new DMCangDao();
            var Xe = new DMXeDao();
            var Loai = new DMLoaiDao();
            var Kho = new DMKhoDao();
            ViewBag.KhachHang = new SelectList(KhachHang.ListAll(), "Id", "TenCongTy", selectedId);
            ViewBag.CangNhan = new SelectList(Cang.ListAll(), "Id", "TenCang", selectedId);
            ViewBag.CangTra = new SelectList(Cang.ListAll(), "Id", "TenCang", selectedId);
            ViewBag.SoXe = new SelectList(Xe.ListAll(), "Id", "BienSo", selectedId);
            ViewBag.Loai = new SelectList(Loai.ListAll(), "Id", "MaLoai", selectedId);
            ViewBag.Kho = new SelectList(Kho.ListAll(), "Id", "MaKho", selectedId);
        }

        [HttpGet]
        public ActionResult Update(long id)
        {
            var dao = new DMBillDao();
            var model = dao.GetById(id);
            SetViewBag();
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(DMBill dMBill, int[] chkId, string delete = null)
        {
            var ps = new DMBillDao();
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
                    var dao = new DMBillDao();
                    var Check1 = dao.Check(dMBill.MaBill);
                    var Check2 = dao.GetById(dMBill.Id);
                    if (Check1.Count > 0 && Check2.MaBill != dMBill.MaBill)
                    {
                        SetAlert("Mã Bill này đã tồn tại! " +
                            "Vui lòng nhập mã Bill khác!", "warning");
                        return RedirectToAction("Update", "DMBill", new { id = dMBill.Id });
                    }
                    else
                    {
                        var result = dao.Update(dMBill);
                        if (result)
                        {
                            SetAlert("Cập nhật dữ liệu Bill thành công!", "success");
                            return RedirectToAction("Index", "DMBill");
                        }
                        else
                        {
                            SetAlert("Cập nhật dữ liệu Bill không thành công", "warning");
                            return RedirectToAction("Update", "DMBill");
                        }
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
            var result = new DMBillDao().Delete(id);
            if (result)
            {
                SetAlert("Xóa Bill thành công", "success");
                return RedirectToAction("Index", "DMBill");
            }
            else
            {
                SetAlert("Xóa Bill không thành công", "warning");
                return RedirectToAction("Index", "DMBill");
            }
        }

        // CTBill

        public ActionResult CTBill(long id, int[] chkId, string delete = null)
        {
            var dao = new CTBillDao();
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
            var Bill = new DMBillDao().GetById(id);

            var model = dao.ListAll(id);
            ViewBag.Bill = Bill.MaBill;
            ViewBag.IdBill = Bill.Id;
            ViewBag.KH = (Bill.KhachHang != null ? Bill.DMKhachHang.MaKH: null);
            ViewBag.CN = (Bill.CangNhan != null ? Bill.DMCang.MaCang: null);
            ViewBag.CT = (Bill.CangTra != null ? Bill.DMCang1.MaCang: null);
            return View(model);
        }


        [HttpGet]
        public ActionResult CreateCTBill(long? id, long? cTBill = null, string Copy = null)
        {
            var Bill = new DMBillDao().GetById(id);
            if (cTBill != null && Copy == "Copy")
            {
                ViewBag.Bill = Bill.MaBill;
                ViewBag.IdBill = Bill.Id;
                var dao = new CTBillDao();
                var model = dao.GetById(cTBill);
                SetViewBag();
                return View(model);
            }
            else
            {
                ViewBag.Bill = Bill.MaBill;
                ViewBag.IdBill = Bill.Id;
                SetViewBag();
                return View();
            }
        }
        [HttpPost]
        public ActionResult CreateCTBill(CTBill dMBill, int[] chkId, string delete = null)
        {
            var ps = new CTBillDao();
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
                var dao = new CTBillDao();

                long id = dao.Insert(dMBill);
                if (id > 0)
                {
                    SetAlert("Đã thêm giá trị thành công !", "success");
                    return RedirectToAction("CreateCTBill", "DMBill");
                }
                else
                {
                    SetAlert("Thêm giá trị không thành công, vui lòng thử lại!", "warning");
                    return RedirectToAction("CreateCTBill", "DMBill");
                }

            }
            return RedirectToAction("CreateCTBill", "DMBill");
        }
        [ChildActionOnly]
        public PartialViewResult ViewCTBill(long id)
        {
            var dao = new CTBillDao();
            var Bill = new DMBillDao().GetById(id);
            var model = dao.ListAll(Bill.Id);
            ViewBag.IdBill = Bill.Id;
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult UpdateCTBill(long id, long? CTBill = null)
        {
            var Bill = new DMBillDao().GetById(id);
            ViewBag.Bill = Bill.MaBill;
            ViewBag.IdBill = Bill.Id;
            var dao = new CTBillDao();
            var model = dao.GetById(CTBill);
            ViewBag.CTBill = CTBill;
            SetViewBag();
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateCTBill(CTBill cTBill)
        {
            if (ModelState.IsValid)
            {
                var dao = new CTBillDao();

                var result = dao.Update(cTBill);
                if (result)
                {
                    SetAlert("Cập nhật dữ liệu thành công!", "success");
                    return RedirectToAction("CTBill", "DMBill", new { id = cTBill.Bill });
                }
                else
                {
                    SetAlert("Cập nhật dữ liệu không thành công", "warning");
                    return RedirectToAction("CTBill", "DMBill", new { id = cTBill.Bill });
                }
            }
            SetAlert("Không có nội dung nào được chỉnh sửa", "warning");

            return RedirectToAction("CTBill", "DMBill", new { id = cTBill.Bill });
        }

        // Delete
        [HttpDelete]
        public ActionResult DeleteCTBill(long id)
        {
            var bill = new CTBillDao().GetById(id).Bill;
            var result = new CTBillDao().Delete(id);
            if (result)
            {
                SetAlert("Xóa giá trị thành công", "success");
                return RedirectToAction("CTBill", "DMBill", new { id = bill });
            }
            else
            {
                SetAlert("Xóa giá trị không thành công", "warning");
                return RedirectToAction("CTBill", "DMBill", new { id = bill });
            }
        }

        [ActionName("Importexcel")]
        [HttpPost]
        public ActionResult ImportExcel(DMBill dMBill, DMKhachHang dMKhachHang, DMCang dMCang, string sheet)
        {
            if (Request.Files["FileUpload"].ContentLength > 0)
            {
                string extension = System.IO.Path.GetExtension(Request.Files["FileUpload"].FileName).ToLower();
                string query = null;
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
                        var dao = new DMBillDao();

                        if (dao.importData(dt, dMBill,dMKhachHang,dMCang))
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
                        var dao = new DMBillDao();

                        if (dao.importData(dt, dMBill, dMKhachHang, dMCang))
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
            return RedirectToAction("Index", "DMBill");
        }

        [ActionName("ImportExcelCTBill")]
        [HttpPost]
        public ActionResult ImportExcelCTBill(DMLoai dMLoai, DMKhachHang dMKhachHang, DMKho dMKho, DMXe dMXe, DMNhanVien dMNhanVien, DMPhi dMPhi, DMThoiGian dMThoiGian, DMCang dMCang, DMBill dMBill, string sheet)
        {
            if (Request.Files["FileUpload"].ContentLength > 0)
            {
                string extension = System.IO.Path.GetExtension(Request.Files["FileUpload"].FileName).ToLower();
                string query = null;
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
                        var dao = new CTBillDao();

                        if (dao.importData(dt, dMLoai, dMKho, dMXe, dMCang, dMBill))
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
                        var dao = new CTBillDao();

                        if (dao.importData(dt, dMLoai, dMKho, dMXe, dMCang, dMBill))
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
            return RedirectToAction("CTBill", "DMBill");
        }
    }
}