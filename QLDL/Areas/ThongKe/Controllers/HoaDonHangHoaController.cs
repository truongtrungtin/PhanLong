using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLDL.DAO;
using QLDL.Common;


namespace QLDL.Areas.ThongKe.Controllers
{
    public class HoaDonHangHoaController : BaseController
    {

        public ActionResult Index()
        {
            return View();
        }
        // GET: ThongKe/HoaDonHangHoa
        public ActionResult HoaDon(long id, string SHD = null, string ND = null, string month = null)
        {
            var dao = new DMKhachHangDao().GetById(id);
            ViewBag.TenCongTy = dao.TenCongTy;
            ViewBag.MST = dao.MST;
            ViewBag.DiaChi = dao.DiaChi;
            var model = new PhatSinhDao().listKH(id);

            decimal tien;
            decimal truocthue = 0;

            ViewBag.SHD = SHD;
            ViewBag.ND = ND;
            ViewBag.Month = month;

            foreach (var item in model)
            {
                tien = Convert.ToDecimal(item.CuocKH * 1);

                truocthue += tien;
            }
            decimal thue = truocthue * 10 / 100;

            decimal tong = thue + truocthue;
            var nb = new NumberToText();
            var doctien = nb.DocTienBangChu(Convert.ToInt32(tong), "Việt Nam Đồng");
            ViewBag.DocTien = doctien;
            return View(model);
        }
    }
}