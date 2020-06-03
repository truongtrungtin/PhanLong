using QLDL.DAO;
using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLDL.Areas.ThongKe.Controllers
{
    public class BillController : Controller
    {
        // GET: ThongKe/ThongKeBill
        public ActionResult Index()
        {
            var dao = new DMBillDao();
            var model = dao.ListAll();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(string searchString)
        {
            return View();
        }
        //Bill Tồn
        public ActionResult BillTon()
        {
            var dao = new DMBillDao();
            var model = dao.ListAll();
            return View(model);
        }

        //Bill chưa gửi bãi
        public ActionResult BillBai()
        {
            var dao = new DMBillDao();
            var model = dao.ListAll();
            return View(model);
        }

        public ActionResult CTBill(long id)
        {
            var dao = new CTBillDao();
            var model = dao.ListAll(id).Where(x => x.NgayGui == null).ToList();
            ViewBag.MaBill = new DMBillDao().GetById(id).MaBill;
            return View(model);
        }
    }
}