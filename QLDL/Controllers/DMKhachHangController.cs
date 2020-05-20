using QLDL.DAO;
using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLDL.Controllers
{
    public class DMKhachHangController : BaseController
    {
        // GET: DMKhachHang
        public ActionResult Index()
        {
            var dao = new DMKhachHangDao();
            var model = dao.ListAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DMKhachHang dMKhachHang)
        {
            if (ModelState.IsValid)
            {
                var dao = new DMKhachHangDao();
                var Check = dao.Check(dMKhachHang.MaKH);
                if (Check.Count > 0)
                {
                    SetAlert("Mã khách hàng này đã tồn tại! " +
                        "Vui lòng nhập mã khách hàng khác!", "warning");
                    return RedirectToAction("Create", "DMKhachHang");
                }
                else
                {
                    long id = dao.Insert(dMKhachHang);
                    if (id > 0 )
                    {
                        SetAlert("Đã thêm Khách hàng thành công!", "success");
                        return RedirectToAction("Index", "DMKhachHang");
                    }
                    else
                    {
                        SetAlert("Thêm Khách hàng không thành công, vui lòng thử lại!", "warning");
                        return RedirectToAction("Create", "DMKhachHang");
                    }
                }
            }
            SetAlert("Vui lòng nhập đầy đủ các ô trống!", "warning");
            return RedirectToAction("Create", "DMKhachHang");
        }
    }
}