using PhanLong.DAO;
using System.Web.Mvc;

namespace PhanLong.Areas.ThongKe.Controllers
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
            var dao = new DMBillDao();
            var model = dao.ListAll();
            return View();
        }

        public ActionResult CTBill(long id)
        {
            var dao = new CTBillDao();
            var bill = new DMBillDao().GetById(id);
            ViewBag.MaBill = bill.MaBill;
            ViewBag.IdBill = bill.Id;
            ViewBag.KH = (bill.KhachHang != null ? bill.DMKhachHang.TenCongTy : null);
            ViewBag.TD = (bill.NgayTauDen != null ? bill.NgayTauDen.Value.ToShortDateString() : null);
            ViewBag.CN = (bill.CangNhan != null ? bill.DMCang.TenCang : null);
            ViewBag.CT = (bill.CangTra != null ? bill.DMCang1.TenCang : null);
            var model = dao.ListAll(id);
            return View(model);
        }
    }
}