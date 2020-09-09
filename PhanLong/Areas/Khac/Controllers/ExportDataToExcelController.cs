using DocumentFormat.OpenXml.Drawing;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;
using PhanLong.DAO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhanLong.Areas.Khac.Controllers
{
    public class ExportDataToExcelController : BaseController
    {
        // GET: Khac/ExportDataToExcel
        public ActionResult Index()
        {
            return View();
        }
        
        private Stream CreateExcelFile(string TableName, string[] selectroles, Stream stream = null)
        {
            
            
            using (var excelPackage = new ExcelPackage(stream ?? new MemoryStream()))
            {
                // Tạo author cho file Excel
                excelPackage.Workbook.Properties.Author = "Hanker";
                // Tạo title cho file Excel
                excelPackage.Workbook.Properties.Title = "EPP test background";
                // thêm tí comments vào làm màu 
                excelPackage.Workbook.Properties.Comments = "This is my fucking generated Comments";
                // Add Sheet vào file Excel
                excelPackage.Workbook.Worksheets.Add("First Sheet");
                // Lấy Sheet bạn vừa mới tạo ra để thao tác 
                var workSheet = excelPackage.Workbook.Worksheets["First Sheet"];
                // Đổ data vào Excel file
                if (TableName == "DMBill")
                {
                    var list = new DMBillDao().GetList(TableName, selectroles);
                    workSheet.Cells[1, 1].LoadFromCollection(list, true, TableStyles.Dark9);
                }
               
                // BindingFormatForExcel(workSheet, list);
                excelPackage.Save();
                return excelPackage.Stream;
            }
        }


        [HttpPost]
        public ActionResult Index(string TableName, string[] selectroles)
        {
            // Gọi lại hàm để tạo file excel
            var stream = CreateExcelFile(TableName, selectroles);
            // Tạo buffer memory strean để hứng file excel
            var buffer = stream as MemoryStream;
            // Đây là content Type dành cho file excel, còn rất nhiều content-type khác nhưng cái này mình thấy okay nhất
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            // Dòng này rất quan trọng, vì chạy trên firefox hay IE thì dòng này sẽ hiện Save As dialog cho người dùng chọn thư mục để lưu
            // File name của Excel này là ExcelDemo
            Response.AddHeader("Content-Disposition", "attachment; filename="+ TableName+ ".xlsx");
            // Lưu file excel của chúng ta như 1 mảng byte để trả về response
            Response.BinaryWrite(buffer.ToArray());
            // Send tất cả ouput bytes về phía clients
            Response.Flush();
            Response.End();
            return RedirectToAction("Index", "ExportDataToExcel");

        }

        public PartialViewResult GetColumnInTable(string TableName)
        {
            ViewBag.Model = new TableDao().GetListColumn(TableName);
            return PartialView();
        }
    }
}