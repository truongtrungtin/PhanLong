using PhanLong.DAO;
using PhanLong.EF;
using System.Web.Mvc;

namespace PhanLong.Areas.ThongKe.Controllers
{
    public class ChiHoController : BaseController
    {
        // GET: ThongKe/ChiHo
        public ActionResult Index(PhatSinh phatSinh, string NgayBD = null, string NgayKT = null)
        {
            var dao = new PhatSinhDao();
            if (phatSinh.Xe != null)
            {
                var xe = new DMXeDao().GetById(phatSinh.Xe);
                ViewBag.Xe = xe.BienSo;
                ViewBag.MaXe = xe.MaXe;
                ViewBag.IdXe = xe.Id;
            }
            ViewBag.NgayBD = NgayBD;
            ViewBag.NgayKT = NgayKT;
            var model = dao.Listtk(phatSinh, NgayBD, NgayKT);
            return View(model);
        }
    }
}