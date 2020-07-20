using PhanLong.DAO;
using PhanLong.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhanLong.Areas.ThongKe.Controllers
{
    public class SoPhuNganHangController : BaseController
    {
        // GET: ThongKe/SoPhuNganHang
        public ActionResult Index(SoPhuNganHang soPhuNganHang, string NgayBD, string NgayKT, long? loaiphi = null)
        {
            ViewBag.NgayBD = NgayBD;
            ViewBag.NgayKT = NgayKT;
            if (soPhuNganHang.MaKH != null)
            {
                var kh = new DMKhachHangDao().GetById(soPhuNganHang.MaKH);
                ViewBag.KhachHang = kh.TenCongTy;
                ViewBag.MaKH = kh.MaKH;
                ViewBag.IDKhachHang = kh.Id;
            }
            if (soPhuNganHang.Phi != null)
            {
                var phi = new DMPhiDao().GetById(soPhuNganHang.Phi);
                ViewBag.Phi = phi.TenPhi;
                ViewBag.MaPhi = phi.MaPhi;
                ViewBag.IdPhi = phi.Id;
            }
            if (loaiphi != null)
            {
                if (loaiphi == 1)
                {
                    ViewBag.LoaiPhi = "Chi";
                    ViewBag.id = loaiphi;
                }
                else if(loaiphi == 2)
                {
                    ViewBag.LoaiPhi = "Thu";
                    ViewBag.id = loaiphi;
                }
            }
            var dao = new SoPhuNganHangDao();
            var model = dao.TimKiemThongTin(soPhuNganHang, NgayBD, NgayKT,loaiphi);
            return View(model);
        }
    }
}