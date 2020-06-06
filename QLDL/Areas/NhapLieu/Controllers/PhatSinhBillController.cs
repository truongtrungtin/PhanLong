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
        [HttpPost]
        public ActionResult Index(int? Bill = null, int? KhachHang = null, string ToDate = null, string FromDate = null)
        {
            var dao = new DMBillDao();
            var model = dao.ListAll(Bill,KhachHang,ToDate,FromDate);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CTBill cTBill, int[] chkId, string themngayguibai = null, string themngaygiao = null, string gui = null, string giao = null)
        {
            var dao = new PhatSinhBillDao();
            if (themngayguibai != null)
            {
                var model = dao.ListCheck(chkId);
                ViewBag.Ngay = "Thêm ngày gửi bãi";
                ViewBag.Bill = cTBill.Bill;
                return View(model);
            }
            else if (themngaygiao != null)
            {
                var model = dao.ListCheck(chkId);
                ViewBag.Ngay = "Thêm ngày giao";
                ViewBag.Bill = cTBill.Bill;
                return View(model);
            }
            else
            {
                var resutl = dao.checkbox(cTBill, chkId, gui, giao);
                if (gui != null)
                {
                    if (resutl)
                    {
                        SetAlert("Thêm ngày gửi thành công", "success");
                    }
                    else
                    {
                        SetAlert("Thêm ngày gửi không thành công", "warning");
                    }
                }
                else
                {
                    if (resutl)
                    {
                        SetAlert("Thêm ngày giao thành công", "success");
                    }
                    else
                    {
                        SetAlert("Thêm ngày giao không thành công", "warning");
                    }
                }
                return RedirectToAction("CTBill", "PhatSinhBill", new { id = cTBill.Bill });
            }
        }

        public PartialViewResult Filter()
        {
            return PartialView();
        }

        public ActionResult CTBill(long id)
        {
            ViewBag.MaBill = new DMBillDao().GetById(id).MaBill;
            ViewBag.IdBill = new DMBillDao().GetById(id).Id;
            var dao = new CTBillDao();
            var model = dao.ListAll(id);
            return View(model);
        }
    }
}