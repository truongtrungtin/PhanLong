using QLDL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLDL.Controllers
{
    public class DMKhachHangController : Controller
    {
        // GET: DMKhachHang
        public ActionResult Index()
        {
            var dao = new DMKhachHangDao();
            var model = dao.ListAll();
            return View();
        }
    }
}