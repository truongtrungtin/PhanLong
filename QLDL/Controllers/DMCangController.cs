using QLDL.DAO;
using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLDL.Controllers
{
    public class DMCangController : BaseController
    {
        // GET: DMCang
        public ActionResult Index()
        {
            var dao = new DMCangDao();
            var model = dao.ListAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DMCang dMCang)
        {
            if (ModelState.IsValid)
            {
                var dao = new DMCangDao();
                var Check = dao.Check(dMCang.MaCang);
                if (Check.Count > 0)
                {
                    SetAlert("Mã cảng này đã tồn tại! " +
                        "Vui lòng nhập mã cảng khác!", "warning");
                    return RedirectToAction("Create", "DMCang");
                }
                else
                {
                    long id = dao.Insert(dMCang);
                    if (id > 0)
                    {
                        SetAlert("Đã thêm cảng thành công !", "success");
                        return RedirectToAction("Index", "DMCang");
                    }
                    else
                    {
                        SetAlert("Thêm cảng không thành công, vui lòng thử lại!", "warning");
                        return RedirectToAction("Create", "DMCang");
                    }
                }
            }
            SetAlert("Vui lòng nhập đầy đủ các ô trống!", "warning");
            return RedirectToAction("Create", "DMCang");
        }
        [HttpGet]
        public ActionResult Update(long id)
        {
            var dao = new DMCangDao();
            var model = dao.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(DMCang dMCang)
        {
            if (ModelState.IsValid)
            {
                var dao = new DMCangDao();
                var Check1 = dao.Check(dMCang.MaCang);
                var Check2 = dao.GetById(dMCang.Id);
                if (Check1.Count > 0 && Check2.MaCang != dMCang.MaCang)
                {
                    SetAlert("Mã cảng này đã tồn tại! " +
                        "Vui lòng nhập mã cảng khác!", "warning");
                    return RedirectToAction("Update", "DMCang", new { id = dMCang.Id });
                }
                else
                {
                    var result = dao.Update(dMCang);
                    if (result)
                    {
                        SetAlert("Cập nhật dữ liệu cảng thành công!", "success");
                        return RedirectToAction("Index", "DMCang");
                    }
                    else
                    {
                        SetAlert("Cập nhật dữ liệu cảng không thành công", "warning");
                        return RedirectToAction("Update", "DMCang");
                    }
                }
            }
            return View("Index");
        }

        // Delete
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            var result = new DMCangDao().Delete(id);
            if (result)
            {
                SetAlert("Xóa cảng thành công", "success");
                return RedirectToAction("Index", "DMCang");
            }
            else
            {
                SetAlert("Xóa cảng không thành công", "warning");
                return RedirectToAction("Index", "DMCang");
            }
        }
    }
}