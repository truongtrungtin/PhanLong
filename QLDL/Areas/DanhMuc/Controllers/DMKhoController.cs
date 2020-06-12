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
    public class DMKhoController : BaseController
    {
        // GET: DMKho
        public ActionResult Index()
        {
            var dao = new DMKhoDao();
            var model = dao.ListAll();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(int[] chkId, string delete = null)
        {
            var dao = new DMKhoDao();
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


        //[HttpGet]
        //public ActionResult CreateDocument()
        //{
        //    using (ExcelEngine excelEngine = new ExcelEngine())
        //    {
        //        IApplication application = excelEngine.Excel;

        //        application.DefaultVersion = ExcelVersion.Excel2016;

        //        //Create a workbook
        //        IWorkbook workbook = application.Workbooks.Create(1);
        //        IWorksheet worksheet = workbook.Worksheets[0];

        //        //Add a picture
        //        IPictureShape shape = worksheet.Pictures.AddPicture(1, 1, Server.MapPath("~/Images/logo.png"));

        //        //Disable gridlines in the worksheet
        //        worksheet.IsGridLinesVisible = false;

        //        //Enter values to the cells from A3 to A5
        //        worksheet.Range["A3"].Text = "46036 Michigan Ave";
        //        worksheet.Range["A4"].Text = "Canton, USA";
        //        worksheet.Range["A5"].Text = "Phone: +1 231-231-2310";

        //        //Make the text bold
        //        worksheet.Range["A3:A5"].CellStyle.Font.Bold = true;

        //        //Merge cells
        //        worksheet.Range["D1:E1"].Merge();

        //        //Enter text to the cell D1 and apply formatting.
        //        worksheet.Range["D1"].Text = "INVOICE";
        //        worksheet.Range["D1"].CellStyle.Font.Bold = true;
        //        worksheet.Range["D1"].CellStyle.Font.RGBColor = Color.FromArgb(42, 118, 189);
        //        worksheet.Range["D1"].CellStyle.Font.Size = 35;

        //        //Apply alignment in the cell D1
        //        worksheet.Range["D1"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignRight;
        //        worksheet.Range["D1"].CellStyle.VerticalAlignment = ExcelVAlign.VAlignTop;

        //        //Enter values to the cells from D5 to E8
        //        worksheet.Range["D5"].Text = "INVOICE#";
        //        worksheet.Range["E5"].Text = "DATE";
        //        worksheet.Range["D6"].Number = 1028;
        //        worksheet.Range["E6"].Value = "12/31/2018";
        //        worksheet.Range["D7"].Text = "CUSTOMER ID";
        //        worksheet.Range["E7"].Text = "TERMS";
        //        worksheet.Range["D8"].Number = 564;
        //        worksheet.Range["E8"].Text = "Due Upon Receipt";

        //        //Apply RGB backcolor to the cells from D5 to E8
        //        worksheet.Range["D5:E5"].CellStyle.Color = Color.FromArgb(42, 118, 189);
        //        worksheet.Range["D7:E7"].CellStyle.Color = Color.FromArgb(42, 118, 189);

        //        //Apply known colors to the text in cells D5 to E8
        //        worksheet.Range["D5:E5"].CellStyle.Font.Color = ExcelKnownColors.White;
        //        worksheet.Range["D7:E7"].CellStyle.Font.Color = ExcelKnownColors.White;

        //        //Make the text as bold from D5 to E8
        //        worksheet.Range["D5:E8"].CellStyle.Font.Bold = true;

        //        //Apply alignment to the cells from D5 to E8
        //        worksheet.Range["D5:E8"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;
        //        worksheet.Range["D5:E5"].CellStyle.VerticalAlignment = ExcelVAlign.VAlignCenter;
        //        worksheet.Range["D7:E7"].CellStyle.VerticalAlignment = ExcelVAlign.VAlignCenter;
        //        worksheet.Range["D6:E6"].CellStyle.VerticalAlignment = ExcelVAlign.VAlignTop;

        //        //Enter value and applying formatting in the cell A7
        //        worksheet.Range["A7"].Text = "  BILL TO";
        //        worksheet.Range["A7"].CellStyle.Color = Color.FromArgb(42, 118, 189);
        //        worksheet.Range["A7"].CellStyle.Font.Bold = true;
        //        worksheet.Range["A7"].CellStyle.Font.Color = ExcelKnownColors.White;

        //        //Apply alignment
        //        worksheet.Range["A7"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
        //        worksheet.Range["A7"].CellStyle.VerticalAlignment = ExcelVAlign.VAlignCenter;

        //        //Enter values in the cells A8 to A12
        //        worksheet.Range["A8"].Text = "Steyn";
        //        worksheet.Range["A9"].Text = "Great Lakes Food Market";
        //        worksheet.Range["A10"].Text = "20 Whitehall Rd";
        //        worksheet.Range["A11"].Text = "North Muskegon,USA";
        //        worksheet.Range["A12"].Text = "+1 231-654-0000";

        //        //Create a Hyperlink for e-mail in the cell A13
        //        IHyperLink hyperlink = worksheet.HyperLinks.Add(worksheet.Range["A13"]);
        //        hyperlink.Type = ExcelHyperLinkType.Url;
        //        hyperlink.Address = "Steyn@greatlakes.com";
        //        hyperlink.ScreenTip = "Send Mail";

        //        //Merge column A and B from row 15 to 22
        //        worksheet.Range["A15:B15"].Merge();
        //        worksheet.Range["A16:B16"].Merge();
        //        worksheet.Range["A17:B17"].Merge();
        //        worksheet.Range["A18:B18"].Merge();
        //        worksheet.Range["A19:B19"].Merge();
        //        worksheet.Range["A20:B20"].Merge();
        //        worksheet.Range["A21:B21"].Merge();
        //        worksheet.Range["A22:B22"].Merge();

        //        //Enter details of products and prices
        //        worksheet.Range["A15"].Text = "  DESCRIPTION";
        //        worksheet.Range["C15"].Text = "QTY";
        //        worksheet.Range["D15"].Text = "UNIT PRICE";
        //        worksheet.Range["E15"].Text = "AMOUNT";
        //        worksheet.Range["A16"].Text = "Cabrales Cheese";
        //        worksheet.Range["A17"].Text = "Chocos";
        //        worksheet.Range["A18"].Text = "Pasta";
        //        worksheet.Range["A19"].Text = "Cereals";
        //        worksheet.Range["A20"].Text = "Ice Cream";
        //        worksheet.Range["C16"].Number = 3;
        //        worksheet.Range["C17"].Number = 2;
        //        worksheet.Range["C18"].Number = 1;
        //        worksheet.Range["C19"].Number = 4;
        //        worksheet.Range["C20"].Number = 3;
        //        worksheet.Range["D16"].Number = 21;
        //        worksheet.Range["D17"].Number = 54;
        //        worksheet.Range["D18"].Number = 10;
        //        worksheet.Range["D19"].Number = 20;
        //        worksheet.Range["D20"].Number = 30;
        //        worksheet.Range["D23"].Text = "Total";

        //        //Apply number format
        //        worksheet.Range["D16:E22"].NumberFormat = "$.00";
        //        worksheet.Range["E23"].NumberFormat = "$.00";

        //        //Apply incremental formula for column Amount by multiplying Qty and UnitPrice
        //        application.EnableIncrementalFormula = true;
        //        worksheet.Range["E16:E20"].Formula = "=C16*D16";

        //        //Formula for Sum the total
        //        worksheet.Range["E23"].Formula = "=SUM(E16:E22)";

        //        //Apply borders
        //        worksheet.Range["A16:E22"].CellStyle.Borders[ExcelBordersIndex.EdgeTop].LineStyle = ExcelLineStyle.Thin;
        //        worksheet.Range["A16:E22"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
        //        worksheet.Range["A16:E22"].CellStyle.Borders[ExcelBordersIndex.EdgeTop].Color = ExcelKnownColors.Grey_25_percent;
        //        worksheet.Range["A16:E22"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].Color = ExcelKnownColors.Grey_25_percent;
        //        worksheet.Range["A23:E23"].CellStyle.Borders[ExcelBordersIndex.EdgeTop].LineStyle = ExcelLineStyle.Thin;
        //        worksheet.Range["A23:E23"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
        //        worksheet.Range["A23:E23"].CellStyle.Borders[ExcelBordersIndex.EdgeTop].Color = ExcelKnownColors.Black;
        //        worksheet.Range["A23:E23"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].Color = ExcelKnownColors.Black;

        //        //Apply font setting for cells with product details
        //        worksheet.Range["A3:E23"].CellStyle.Font.FontName = "Arial";
        //        worksheet.Range["A3:E23"].CellStyle.Font.Size = 10;
        //        worksheet.Range["A15:E15"].CellStyle.Font.Color = ExcelKnownColors.White;
        //        worksheet.Range["A15:E15"].CellStyle.Font.Bold = true;
        //        worksheet.Range["D23:E23"].CellStyle.Font.Bold = true;

        //        //Apply cell color
        //        worksheet.Range["A15:E15"].CellStyle.Color = Color.FromArgb(42, 118, 189);

        //        //Apply alignment to cells with product details
        //        worksheet.Range["A15"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
        //        worksheet.Range["C15:C22"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;
        //        worksheet.Range["D15:E15"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;

        //        //Apply row height and column width to look good
        //        worksheet.Range["A1"].ColumnWidth = 36;
        //        worksheet.Range["B1"].ColumnWidth = 11;
        //        worksheet.Range["C1"].ColumnWidth = 8;
        //        worksheet.Range["D1:E1"].ColumnWidth = 18;
        //        worksheet.Range["A1"].RowHeight = 47;
        //        worksheet.Range["A2"].RowHeight = 15;
        //        worksheet.Range["A3:A4"].RowHeight = 15;
        //        worksheet.Range["A5"].RowHeight = 18;
        //        worksheet.Range["A6"].RowHeight = 29;
        //        worksheet.Range["A7"].RowHeight = 18;
        //        worksheet.Range["A8"].RowHeight = 15;
        //        worksheet.Range["A9:A14"].RowHeight = 15;
        //        worksheet.Range["A15:A23"].RowHeight = 18;

        //        //Save the workbook to disk in xlsx format
        //        workbook.SaveAs("Output.xlsx", HttpContext.ApplicationInstance.Response, ExcelDownloadType.Open);
        //    }
        //    return View();
        //}

        [ChildActionOnly]
        public PartialViewResult ViewDMKho()
        {
            var dao = new DMKhoDao();
            var model = dao.ListAll();
            return PartialView(model);
        }
        [HttpGet]
        public ActionResult Create(long? id = null, string Copy = null)
        {
            if (id != null && Copy != null)
            {
                var dao = new DMKhoDao();
                var model = dao.GetById(id);
                return View(model);
            }
            else
            {

                return View();
            }
        }
        [HttpPost]
        public ActionResult Create(DMKho dMKho, int[] chkId, string delete = null)
        {
            var item = new DMKhoDao();
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
                    var dao = new DMKhoDao();
                    var Check = dao.Check(dMKho.MaKho);

                    if (Check.Count > 0)
                    {
                        SetAlert("Mã kho này đã tồn tại! " +
                            "Vui lòng nhập mã kho khác!", "warning");
                        return RedirectToAction("Create", "DMKho");
                    }
                    else
                    {
                        long id = dao.Insert(dMKho);
                        if (id > 0)
                        {
                            SetAlert("Đã thêm Kho thành công!", "success");
                            return RedirectToAction("Create", "DMKho");
                        }
                        else
                        {
                            SetAlert("Thêm Kho không thành công, vui lòng thử lại!", "warning");
                            return RedirectToAction("Create", "DMkho");
                        }
                    }
                }
                SetAlert("Vui lòng nhập đầy đủ các ô trống!", "warning");

            }
            return RedirectToAction("Create", "DMkho");
        }
        [HttpGet]
        public ActionResult Update(long id)
        {
            var dao = new DMKhoDao();
            var model = dao.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(DMKho dMKho, int[] chkId, string delete = null)
        {
            var item = new DMKhoDao();
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
                    var dao = new DMKhoDao();
                    var Check1 = dao.Check(dMKho.MaKho);
                    var Check2 = dao.GetById(dMKho.Id);
                    if (Check1.Count > 0 && Check2.MaKho != dMKho.MaKho)
                    {
                        SetAlert("Mã kho này đã tồn tại! " +
                            "Vui lòng nhập mã kho khác!", "warning");
                        return RedirectToAction("Update", "DMKho", new { id = dMKho.Id });
                    }
                    else
                    {
                        var result = dao.Update(dMKho);
                        if (result)
                        {
                            SetAlert("Cập nhật dữ liệu kho thành công!", "success");
                            return RedirectToAction("Index", "DMKho");
                        }
                        else
                        {
                            SetAlert("Cập nhật dữ liệu kho không thành công", "warning");
                            return RedirectToAction("Update", "DMKho");
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
            var result = new DMKhoDao().Delete(id);
            if (result)
            {
                SetAlert("Xóa kho thành công", "success");
                return RedirectToAction("Index", "DMKho");
            }
            else
            {
                SetAlert("Xóa kho không thành công", "warning");
                return RedirectToAction("Index", "DMKho");
            }
        }

        [ActionName("Importexcel")]
        [HttpPost]
        public ActionResult ImportExcel(DMKho dMKho, string sheet)
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
                        var dao = new DMKhoDao();

                        if (dao.importData(dt, dMKho))
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
                        var dao = new DMKhoDao();

                        if (dao.importData(dt, dMKho))
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
            return RedirectToAction("Index", "DMKho");
        }
    }
}