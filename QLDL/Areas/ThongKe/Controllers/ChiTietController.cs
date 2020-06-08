using QLDL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLDL.Areas.ThongKe.Controllers
{
    public class ChiTietController : BaseController
    {
        // GET: ThongKe/Chitiet
        public ActionResult Index()
        {
            var dao = new PhatSinhDao();
            var model = dao.ListAll();
            return View(model);
        }
    }
}