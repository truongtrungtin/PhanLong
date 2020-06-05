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
        [HttpGet]
        public ActionResult Themngayguibai(int[] chkId)
        {
            var dao = new PhatSinhBillDao();
            var model = dao.ListCheck(chkId);
            return View(model);
        }

        [HttpPost]
        public ActionResult Themngayguibai(CTBill cTBill, int[] chkId, string themngayguibai = null)
        {
            if (themngayguibai != null)
            {
                var dao = new PhatSinhBillDao();
                var model = dao.ListCheck(chkId);
                return View(model);
            }
            else
            {
                var dao = new PhatSinhBillDao();
                var resutl = dao.checkboxguibai(cTBill, chkId);
                if (resutl)
                {
                    SetAlert("Thêm ngày gửi thành công", "success");
                }
                else
                {
                    SetAlert("Thêm ngày gửi không thành công", "warning");
                }
                return RedirectToAction("CTBill", "PhatSinhBill", new { id = cTBill.Bill });
            }
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
            var model = dao.ListAll(id);
            return View(model);
        }
    }
}