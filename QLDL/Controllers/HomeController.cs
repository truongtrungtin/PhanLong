using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLDL.DAO;
using QLDL.Common;

namespace QLDL.Areas.DanhMuc.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index(long id)
        {
            var dao = new DMKhachHangDao().GetById(id);
            ViewBag.TenCongTy = dao.TenCongTy;
            ViewBag.MST = dao.MST;
            ViewBag.DiaChi = dao.DiaChi;
            var model = new PhatSinhDao().listKH(id);

            decimal tien;
            decimal truocthue = 0;
            

            foreach (var item in model)
            {
                tien = Convert.ToDecimal(item.CuocKH * 1);

                truocthue += tien;
            }
            decimal thue = truocthue*10/100;

            decimal tong = thue + truocthue;
            var nb = new NumberToText();
            var doctien = nb.DocTienBangChu(Convert.ToInt32(tong), "VNĐ");
            ViewBag.DocTien = doctien;
            return View(model);
        }
    }
}