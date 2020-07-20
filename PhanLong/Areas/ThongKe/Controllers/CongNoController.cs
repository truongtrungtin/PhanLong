using PhanLong.EF;
using PhanLong.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhanLong.Models;

namespace PhanLong.Areas.ThongKe.Controllers
{
    public class CongNoController : BaseController
    {
        // GET: ThongKe/CongNo
        public ActionResult Index(CongNoModel congNoModel, string ngayBD, string ngayKT)
        {
            ViewBag.NgayBD = ngayBD;
            ViewBag.NgayKT = ngayKT;
            if (congNoModel.KhachHang != null)
            {
                var kh = new CongNoDao().GetByMa(congNoModel.KhachHang);
                ViewBag.KhachHang = kh.TenCongTy;
                ViewBag.MaKH = kh.MaKH;
                ViewBag.IDKhachHang = kh.Id;
            }
            var model = new CongNoDao().ListAll(congNoModel);
            return View(model);
        }
    }
}