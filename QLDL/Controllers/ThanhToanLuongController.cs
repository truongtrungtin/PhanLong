using QLDL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLDL.Models;
namespace QLDL.Controllers
{
    public class ThanhToanLuongController : Controller
    {
        // GET: ThanhToanLuong
        public ActionResult Index()
        {
            var model = new ThanhToanLuongDao().ListAll();
            return View(model);
        }


        public ActionResult CTTTLuong(long id, string NgayBD, string NgayKT)
        {
            var tx = new DMNhanVienDao().GetById(id);
            var model = new CTTTLuongDao().ListAll(id, NgayBD, NgayKT);
            var Loai = new PhatSinhDao().GetLoai(tx.Id);
            ViewBag.tx = tx.TenNV;
            ViewBag.NgayBD = NgayBD;
            ViewBag.NgayKT = NgayKT;
            ViewBag.N20 = Loai.Where(x => x.DMLoai.MaLoai == "20N").Count();
            ViewBag.X20 = Loai.Where(x => x.DMLoai.MaLoai == "20X").Count();
            ViewBag.N40 = Loai.Where(x => x.DMLoai.MaLoai == "40N").Count();
            ViewBag.X40 = Loai.Where(x => x.DMLoai.MaLoai == "40X").Count();
            ViewBag.Tong = (ViewBag.N20 + ViewBag.X20 + ViewBag.N40 + ViewBag.X40);
            return View(model);
        }
    }
}