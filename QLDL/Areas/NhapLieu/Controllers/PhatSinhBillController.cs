using QLDL.DAO;
using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLDL.Areas.NhapLieu.Controllers
{
    public class PhatSinhBillController : BaseController
    {
        // GET: NhapLieu/PhatSinhBill
        public ActionResult Index()
        {
            var dao = new DMBillDao();
            var model = dao.ListAll();
            return View(model);
        }

        public ActionResult AddDay()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDay(CTBill cTBill)
        {
            var dao = new CTBillDao();
            var resutl = dao.UpdateNGui(cTBill);
            if (resutl)
            {
                SetAlert("Thêm ngày gửi thành công", "success");
            }
            else
            {
                SetAlert("Thêm ngày gửi không thành công", "warning");
            }
            return RedirectToAction("Index", "PhatSinhBill");
        }

        public ActionResult Create(long id)
        {
            var dao = new CTBillDao().GetById(id);
            ViewBag.Id = dao.Id;
            ViewBag.Cont = dao.Cont;
            return View(dao);
        }


        [HttpPost]
        public ActionResult Create(CTBill cTBill)
        {
            var dao = new CTBillDao();
            var resutl = dao.UpdateNgayGui(cTBill);
            if (resutl)
            {
                SetAlert("Thêm ngày gửi thành công", "success");
            }
            else
            {
                SetAlert("Thêm ngày gửi thành công", "warning");
            }
            return RedirectToAction("Index", "PhatSinhBill");
        }

        public ActionResult CTBill(long id)
        {
            ViewBag.MaBill = new DMBillDao().GetById(id).MaBill;
            var dao = new CTBillDao();
            var model = dao.ListAll(id).Where(x => x.NgayGui != null);
            return View(model);
        }
    }
}