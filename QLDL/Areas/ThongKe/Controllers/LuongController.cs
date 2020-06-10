﻿using QLDL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLDL.Models;
namespace QLDL.Areas.ThongKe.Controllers
{
    public class LuongController : BaseController
    {
        // GET: ThanhToanLuong
        public ActionResult Index()
        {
            var model = new ThongKeLuong().ListAll();
            return View(model);
        }


        public ActionResult CTTTLuong(long id, string NgayBD, string NgayKT)
        {
            var tx = new DMNhanVienDao().GetById(id);
            var model = new CTTTLuongDao().PhatSinhLuong(id, NgayBD, NgayKT);
            var ChiLuong = new CTTTLuongDao().ChiLuong(id, NgayBD, NgayKT);
            var Loai = new PhatSinhDao().GetLoai(tx.Id);
            ViewBag.ChiLuong = ChiLuong;
            ViewBag.tx = tx.TenNV;
            ViewBag.NgayBD = NgayBD;
            ViewBag.NgayKT = NgayKT;
            ViewBag.N20 = model.Where(x => x.Loai == "20N").Count();
            ViewBag.X20 = model.Where(x => x.Loai == "20X").Count();
            ViewBag.N40 = model.Where(x => x.Loai == "40N").Count();
            ViewBag.X40 = model.Where(x => x.Loai == "40X").Count();
            ViewBag.Tong = (ViewBag.N20 + ViewBag.X20 + ViewBag.N40 + ViewBag.X40);
            return View(model);
        }
    }
}