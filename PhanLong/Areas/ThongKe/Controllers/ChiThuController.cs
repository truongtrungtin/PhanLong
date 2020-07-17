using Microsoft.Ajax.Utilities;
using PhanLong.DAO;
using PhanLong.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using System.Web.Mvc;
using PhanLong.Common;

namespace PhanLong.Areas.ThongKe.Controllers
{
    public class ChiThuController : BaseController
    {
        // GET: ThongKe/ChiThu
        public ActionResult Index(PhatSinhChiThu phatSinhChiThu, CTChiThu cTChiThu, string NgayBD, string NgayKT, string Search, long? ChiThu = null)
        {
            var dao = new PhatSinhChiThuDao();
            if (ChiThu != null)
            {
                var loaiphi = dao.GetLoaiPhi(ChiThu);
                ViewBag.IdChiThu = loaiphi.Id;
                ViewBag.ChiThu = loaiphi.Loai;
            }
            ViewBag.NgayBD = NgayBD;
            ViewBag.NgayKT = NgayKT;
            if (cTChiThu.Xe != null)
            {
                var xe = new DMXeDao().GetById(cTChiThu.Xe);
                ViewBag.Xe = xe.BienSo;
                ViewBag.IdXe = xe.Id;
            }
            if (cTChiThu.Mooc != null)
            {
                var mooc = new DMMoocDao().GetById(cTChiThu.Mooc);
                ViewBag.Mooc = mooc.BienSo;
                ViewBag.IdMooc = mooc.Id;
            }
            if (cTChiThu.Mooc != null)
            {
                var mooc = new DMMoocDao().GetById(cTChiThu.Mooc);
                ViewBag.Mooc = mooc.BienSo;
                ViewBag.IdMooc = mooc.Id;
            }
            if (cTChiThu.Phi != null)
            {
                var phi = new DMPhiDao().GetById(cTChiThu.Phi);
                ViewBag.TenPhi = phi.TenPhi;
                ViewBag.IdTenPhi = phi.Id;
            }

            if (phatSinhChiThu.KhachHang != null)
            {
                var kh = new DMKhachHangDao().GetById(phatSinhChiThu.KhachHang);
                ViewBag.KhachHang = kh.TenCongTy;
                ViewBag.IDKhachHang = kh.Id;
            }

            if (phatSinhChiThu.Bill != null)
            {
                var bill = new DMBillDao().GetById(phatSinhChiThu.Bill);
                ViewBag.Bill = bill.MaBill;
                ViewBag.IdBill = bill.Id;
            }
            var model = dao.SearchChiThu(phatSinhChiThu, cTChiThu, NgayBD, NgayKT, ChiThu);
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(int[] chkId)
        {
            var model = new PhatSinhChiDao().GetById(chkId[0]);
            if (chkId.Length == 1 && model.CTChiThus.FirstOrDefault().DMPhi.LoaiPhi == 1)
            {
                return RedirectToAction("PhieuChi", "ChiThu", new { id = chkId[0] });
            }
            else if (chkId.Length == 1 && model.CTChiThus.FirstOrDefault().DMPhi.LoaiPhi == 2)
            {
                return RedirectToAction("PhieuThu", "ChiThu", new { id = chkId[0] });
            }
            return View();
        }

        public ActionResult PhieuChi(long id)
        {
            var model = new PhatSinhChiDao().GetById(id);
            ViewBag.TienChu = new NumberToText().DocTienBangChu(Convert.ToInt64(model.CTChiThus.FirstOrDefault().DonGia * model.CTChiThus.FirstOrDefault().SoLuong), "đồng");
            return View(model);
        }

        public ActionResult PhieuThu(long id)
        {
            var model = new PhatSinhThuDao().GetById(id);
            ViewBag.TienChu = new NumberToText().DocTienBangChu(Convert.ToInt64(model.CTChiThus.FirstOrDefault().DonGia * model.CTChiThus.FirstOrDefault().SoLuong), "đồng");
            return View(model);
        }

    }
}