using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.LexicalAnalysis.TokenSeparatorHandlers;
using QLDL.DAO;
using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
                            SetAlert("Đã thêm Bill thành công !", "success");
                            if (ctbill.InsertCTBill(cTBill) > 0)
                            {
                                SetAlert("Cont " + cTBill.Cont + " đã thêm thành công!", "success");
                            }
                            else
                            {
                                SetAlert("Cont " + cTBill.Cont + " chưa thêm thành công!", "warning");
                            }
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
            ViewBag.KH = Bill.DMKhachHang.MaKH;
            ViewBag.CN = Bill.DMCang.MaCang;
            ViewBag.CT = Bill.DMCang1.MaCang;
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


        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["QLDLDBContext"].ConnectionString);
        //OleDbConnection Econ;

        //public ActionResult ImportStatesExcel()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult ImportStatesExcel(HttpPostedFileBase file)
        //{
        //    Guid guidObj = Guid.NewGuid();

        //    string extension = Path.GetExtension(file.FileName);
        //    string filename = guidObj.ToString() + extension;
        //    string filepath = "/excelfolder/" + filename;
        //    file.SaveAs(Path.Combine(Server.MapPath("/excelfolder"), filename));
        //    InsertExceldata(filepath, filename);

        //    return View();
        //}

        //private void ExcelConn(string filepath)
        //{
        //    string constr = string.Format(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = {0};Extended Properties=""Excel 12.0 XML;Persist Security Info=False""", filepath);
        //    Econ = new OleDbConnection(constr);
        //}

        //private void InsertExceldata(string fileepath, string filename)
        //{
        //    string fullpath = Server.MapPath("/excelfolder") + filename;
        //    ExcelConn(fullpath);
        //    string query = string.Format("Select * from [{0}]", "Sheet1");
        //    OleDbCommand Ecom = new OleDbCommand(query, Econ);
        //    Econ.Open();
        //    DataSet ds = new DataSet();
        //    OleDbDataAdapter oda = new OleDbDataAdapter(query, Econ);
        //    Econ.Close();
        //    oda.Fill(ds);

        //    DataTable dt = ds.Tables[0];
        //    SqlBulkCopy objbulk = new SqlBulkCopy(con);
        //    objbulk.DestinationTableName = "DMBill";
        //    objbulk.ColumnMappings.Add("MaBill", "MaBill");
        //    objbulk.ColumnMappings.Add("NgayTauDen", "NgayTauDen");
        //    objbulk.ColumnMappings.Add("KhachHang", "KhachHang");
        //    objbulk.ColumnMappings.Add("CangNhan", "CangNhan");
        //    objbulk.ColumnMappings.Add("CangTra", "CangTra");
        //    con.Open();
        //    objbulk.WriteToServer(dt);
        //    con.Close();


        //}
    }
}