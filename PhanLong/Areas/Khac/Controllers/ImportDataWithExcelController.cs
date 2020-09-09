using PhanLong.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using PhanLong.Common;
using System.IO;
using PhanLong.DAO;

namespace PhanLong.Areas.Khac.Controllers
{
    public class ImportDataWithExcelController : BaseController
    {
        // GET: Khac/ImportDataWithExcel
        [HasCredential(RoleId = "IMPORT_DATA")]
        public ActionResult Index()
        {
            return View();
        }

        [HasCredential(RoleId = "IMPORT_DATA")]
        [HttpPost]
        public ActionResult Index(DMKhachHang dMKhachHang, DMKho dMKho, DMXe dMXe, DMNhanVien dMNhanVien, DMPhi dMPhi, DMCang dMCang, DMBill dMBill, PhatSinh phatSinh, DMLoai dMLoai, PhatSinhChiThu phatSinhChiThu, CTChiThu cTChiThu, HoaDon hoaDon, SoPhuNganHang soPhuNganHang, DMMooc dMMooc, HinhThucTT hinhThucTT, DMThoiGian dMThoiGian, string[] chkId)
        {
            if (Request.Files["FileUpload"].ContentLength > 0)
            {
                foreach (var item in chkId)
                {
                    string extension = System.IO.Path.GetExtension(Request.Files["FileUpload"].FileName).ToLower();
                    string connString = "";
                    string[] validFileTypes = { ".xls" };

                    string path1 = string.Format("{0}/{1}", Server.MapPath("~/Content/Uploads/"+ item), Request.Files["FileUpload"].FileName);
                    if (!Directory.Exists(path1))
                    {
                        Directory.CreateDirectory(Server.MapPath("~/Content/Uploads/" + item));
                    }
                    if (validFileTypes.Contains(extension))
                    {
                        DataTable dt;
                        if (System.IO.File.Exists(path1))
                        { 
                            System.IO.File.Delete(path1); 
                        }
                        Request.Files["FileUpload"].SaveAs(path1);
                        if (extension.Trim() == ".xls")
                        {
                            connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path1 + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                            dt = ExcelUpload.ConvertXSLXtoDataTable(path1, connString, item);
                            if (dt.Rows.Count > 0)
                            {
                                ViewBag.Data = dt;
                                if (item == "DMKhachHang")
                                {
                                    var dao = new DMKhachHangDao();

                                    if (dao.importData(dt, dMKhachHang))
                                    {
                                        SetAlert("Thêm khách hàng thành công!", "success");
                                    }
                                    else
                                    {
                                        SetAlert("Thêm khách hàng không thành công!", "warning");
                                        return RedirectToAction("Index", "ImportDataWithExcel");
                                    }
                                }
                                else if (item == "DMKho")
                                {
                                    var dao = new DMKhoDao();

                                    if (dao.importData(dt, dMKho))
                                    {
                                        SetAlert("Thêm kho thành công!", "success");
                                    }
                                    else
                                    {
                                        SetAlert("Thêm kho không thành công!", "warning");
                                        return RedirectToAction("Index", "ImportDataWithExcel");
                                    }
                                }
                                else if (item == "DMCang")
                                {
                                    var dao = new DMCangDao();

                                    if (dao.importData(dt, dMCang))
                                    {
                                        SetAlert("Thêm cảng thành công!", "success");
                                    }
                                    else
                                    {
                                        SetAlert("Thêm cảng không thành công!", "warning");
                                        return RedirectToAction("Index", "ImportDataWithExcel");
                                    }
                                }
                                else if (item == "DMNhanVien")
                                {
                                    var dao = new DMNhanVienDao();

                                    if (dao.importData(dt, dMNhanVien))
                                    {
                                        SetAlert("Thêm nhân viên thành công!", "success");
                                    }
                                    else
                                    {
                                        SetAlert("Thêm nhân viên không thành công!", "warning");
                                        return RedirectToAction("Index", "ImportDataWithExcel");
                                    }
                                }
                                else if (item == "DMPhi")
                                {
                                    var dao = new DMPhiDao();

                                    if (dao.importData(dt, dMPhi))
                                    {
                                        SetAlert("Thêm phí thành công!", "success");
                                    }
                                    else
                                    {
                                        SetAlert("Thêm phí không thành công!", "warning");
                                        return RedirectToAction("Index", "ImportDataWithExcel");
                                    }
                                }
                                else if (item == "DMBill")
                                {
                                    var dao = new DMBillDao();

                                    if (dao.importData(dt, dMBill, dMKhachHang, dMCang))
                                    {
                                        SetAlert("Thêm bill thành công!", "success");
                                    }
                                    else
                                    {
                                        SetAlert("Thêm bill không thành công!", "warning");
                                        return RedirectToAction("Index", "ImportDataWithExcel");
                                    }
                                }
                                else if (item == "CTBill")
                                {
                                    var dao = new CTBillDao();

                                    if (dao.importData(dt, dMLoai, dMKho, dMXe, dMCang, dMBill))
                                    {
                                        SetAlert("Thêm chi tiết bill thành công!", "success");
                                    }
                                    else
                                    {
                                        SetAlert("Thêm  chi tiết bill không thành công!", "warning");
                                        return RedirectToAction("Index", "ImportDataWithExcel");
                                    }
                                }
                                else if (item == "PhatSinh")
                                {
                                    var dao = new PhatSinhDao();

                                    if (dao.importData(dt, phatSinh, dMLoai, dMKhachHang, dMKho, dMXe, dMNhanVien, dMPhi, dMThoiGian, dMCang, dMBill))
                                    {
                                        SetAlert("Thêm Phat Sinh thành công!", "success");
                                    }
                                    else
                                    {
                                        SetAlert("Thêm Phat Sinh không thành công!", "warning");
                                        return RedirectToAction("Index", "ImportDataWithExcel");
                                    }
                                }
                                else if (item == "HoaDon")
                                {
                                    var dao = new HoaDonDao();

                                    if (dao.importData(dt, hoaDon, dMKhachHang, dMBill))
                                    {
                                        SetAlert("Thêm hoá đơn thành công!", "success");
                                    }
                                    else
                                    {
                                        SetAlert("Thêm hoá đơn không thành công!", "warning");
                                        return RedirectToAction("Index", "ImportDataWithExcel");
                                    }
                                }
                                else if (item == "PhatSinhChiThu")
                                {
                                    var dao = new PhatSinhChiDao();

                                    if (dao.importData(dt, phatSinhChiThu, dMNhanVien, hinhThucTT, dMKhachHang, dMBill, dMXe, dMMooc))
                                    {
                                        SetAlert("Thêm phát sinh chi thu thành công!", "success");
                                    }
                                    else
                                    {
                                        SetAlert("Thêm phát sinh chi thu không thành công!", "warning");
                                        return RedirectToAction("Index", "ImportDataWithExcel");
                                    }
                                }
                                else if (item == "CTChiThu")
                                {
                                    var dao = new CTChiDao();

                                    if (dao.importData(dt, cTChiThu, phatSinhChiThu, dMXe, dMMooc, dMPhi))
                                    {
                                        SetAlert("Thêm chi tiết chi thu  thành công!", "success");
                                    }
                                    else
                                    {
                                        SetAlert("Thêm chi tiết chi thu  không thành công!", "warning");
                                        return RedirectToAction("Index", "ImportDataWithExcel");
                                    }
                                }
                                else if (item == "SoPhuNganHang")
                                {
                                    var dao = new SoPhuNganHangDao();

                                    if (dao.importData(dt, soPhuNganHang, dMKhachHang, hinhThucTT, dMPhi))
                                    {
                                        SetAlert("Thêm sổ phụ ngân hàng thành công!", "success");
                                    }
                                    else
                                    {
                                        SetAlert("Thêm sổ phụ ngân hàng  không thành công!", "warning");
                                        return RedirectToAction("Index", "ImportDataWithExcel");
                                    }
                                }
                               

                            }
                            else
                            {
                                SetAlert("Không có dữ liệu để thêm!", "warning");
                            }

                        }
                    }
                }
                
            }
            return RedirectToAction("Index", "ImportDataWithExcel");
        }
    }
}