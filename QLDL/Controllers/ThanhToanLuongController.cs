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
            ViewBag.tx = tx.TenNV;
            ViewBag.NgayBD = NgayBD;
            ViewBag.NgayKT = NgayKT;
            return View(model);
        }
    }
}