using QLDL.DAO;
using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLDL.Controllers
{
    public class DMKhoController : BaseController
    {
        // GET: DMKho
        public ActionResult Index()
        {
            var dao = new DMKhoDao();
            var model = dao.ListAll();
            return View(model);
        }
        [HttpGet]
        public  ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DMKho dMKho)
        {
            if (ModelState.IsValid)
            {
                var dao = new DMKhoDao();
                var Check = dao.Check(dMKho.MaKho);
                if (Check.Count > 0 )
                {
                    SetAlert("Mã kho này đã tồn tại! " +
                        "Vui lòng nhập mã kho khác!", "warning");
                    return RedirectToAction("Create", "DMKho");
                }
                else
                {
                    long id = dao.Insert(dMKho);
                    if (id > 0 )
                    {
                        SetAlert("Đã thêm Kho thành công !", "success");
                        return RedirectToAction("Index", "DMKho");
                    }
                    else
                    {
                        SetAlert("Thêm Kho không thành công, vui lòng thử lại!", "warning");
                        return RedirectToAction("Create", "DMkho");
                    }
                }
            }
            SetAlert("Vui lòng nhập đầy đủ các ô trống!", "warning");
            return RedirectToAction("Create", "DMkho");
        }
        [HttpGet]
        public ActionResult Update(long id)
        {
            var dao = new DMKhoDao();
            var model = dao.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(DMKho dMKho)
        {
            if (ModelState.IsValid)
            {
                var dao = new DMKhoDao();

                var result = dao.Update(dMKho);
                if (result)
                {
                    SetAlert("Cập nhật dữ liệu kho thành công!", "success");
                    return RedirectToAction("Index", "DMKho");
                }
                else
                {
                    SetAlert("Cập nhật dữ liệu kho không thành công", "warning");
                    return RedirectToAction("Update", "DMKho");
                }
            }
            return View("DMKho");
        }

        // Delete
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            var result = new DMKhoDao().Delete(id);
            if (result)
            {
                SetAlert("Xóa kho thành công", "success");
                return RedirectToAction("Index", "DMKho");
            }
            else
            {
                SetAlert("Xóa kho không thành công", "warning");
                return RedirectToAction("Index", "DMKho");
            }
        }
    }
}