﻿using QLDL.DAO;
using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLDL.Models;
using Newtonsoft.Json;

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
            ViewBag.idtx = tx.Id;
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

        [HttpPost]
        public ActionResult CTTTLuong(PhatSinh phatSinh,string NgayBD, string NgayKT)
        {
            var tx = new DMNhanVienDao().GetById(phatSinh.TenTX);
            var model = new CTTTLuongDao().PhatSinhLuong(phatSinh.TenTX, NgayBD, NgayKT);
            var ChiLuong = new CTTTLuongDao().ChiLuong(phatSinh.TenTX, NgayBD, NgayKT);
            var dao = new PhatSinhDao();
            var Loai = dao.GetLoai(tx.Id);
            ViewBag.ChiLuong = ChiLuong;
            ViewBag.idtx = tx.Id;
            ViewBag.tx = tx.TenNV;
            ViewBag.NgayBD = NgayBD;
            ViewBag.NgayKT = NgayKT;
            ViewBag.N20 = model.Where(x => x.Loai == "20N").Count();
            ViewBag.X20 = model.Where(x => x.Loai == "20X").Count();
            ViewBag.N40 = model.Where(x => x.Loai == "40N").Count();
            ViewBag.X40 = model.Where(x => x.Loai == "40X").Count();
            ViewBag.Tong = (ViewBag.N20 + ViewBag.X20 + ViewBag.N40 + ViewBag.X40);
            if (dao.UpdateGhiChuLuong(phatSinh))
            {
                SetAlert("Đã thêm ghi chú lương thành công!", "success");
            }
            else
            {
                SetAlert("Thêm ghi chú lương không thành công, vui lòng thử lại!", "warning");
            }
            return RedirectToAction("CTTTLuong", "Luong" ,new { id = phatSinh.TenTX, @NgayBD = NgayBD, @NgayKT = NgayKT });
        }

        [HttpGet]
        public PartialViewResult EditGhiChu(long id)
        {
            PhatSinh model = new PhatSinhDao().GetById(id);

            return PartialView("EditGhiChuLuong", model);
        }

        public JsonResult GetPhatSinhId(long id)
        {
            var model = new PhatSinhDao().GetById(id);
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }
    }
}