using QLDL.DAO;
using QLDL.EF;
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
            var model = dao.ListAll().Where(x => (DateTime.Now - x.Ngay).TotalDays < 30);
            var startday = model.OrderBy(x => x.Ngay).FirstOrDefault().Ngay.ToShortDateString();
            var endday = model.OrderByDescending(x => x.Ngay).FirstOrDefault().Ngay.ToShortDateString();
            ViewBag.sday = startday;
            ViewBag.eday = endday;
            ViewBag.N20 = model.Where(x => x.Loai == 1).Count();
            ViewBag.N40 = model.Where(x => x.Loai == 2).Count();
            ViewBag.X20 = model.Where(x => x.Loai == 3).Count();
            ViewBag.X40 = model.Where(x => x.Loai == 4).Count();
            ViewBag.TongNgay = (Convert.ToDateTime(endday) - Convert.ToDateTime(startday)).TotalDays;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(PhatSinh phatSinh, string sday = null, string eday = null)
        {
            var dao = new PhatSinhDao();
            var getdata = dao.GetByData(phatSinh);
            ViewBag.KH = (phatSinh.KhachHang != null ? getdata.DMKhachHang.TenCongTy : null);
            ViewBag.Kho = (phatSinh.Kho != null ? getdata.DMKho.DiaChi: null);
            ViewBag.Loai = (phatSinh.Loai != null ? getdata.DMLoai.MaLoai:null);
            ViewBag.Xe = (phatSinh.Xe != null ? getdata.DMXe.MaXe : null);
            ViewBag.sday = (sday != "" ? Convert.ToDateTime(sday).ToShortDateString() : null);
            ViewBag.eday = (eday != "" ? Convert.ToDateTime(eday).ToShortDateString() : null);
            var model = dao.Listtk(phatSinh,sday,eday);
            ViewBag.N20 = model.Where(x => x.Loai == 1).Count();
            ViewBag.N40 = model.Where(x => x.Loai == 2).Count();
            ViewBag.X20 = model.Where(x => x.Loai == 3).Count();
            ViewBag.X40 = model.Where(x => x.Loai == 4).Count();
            ViewBag.TongNgay = (Convert.ToDateTime(eday) - Convert.ToDateTime(sday)).TotalDays;
            return View(model);
        }
    }
}