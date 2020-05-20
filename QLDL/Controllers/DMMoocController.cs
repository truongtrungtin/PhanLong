using QLDL.DAO;
using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLDL.Controllers
{
    public class DMMoocController : BaseController
    {
        // GET: DMKho
        public ActionResult Index()
        {
            var dao = new DMMoocDao();
            var model = dao.ListAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DMMooc dMMooc)
        {
            if (ModelState.IsValid)
            {
                var dao = new DMMoocDao();
                var Check = dao.Check(dMMooc.MaMooc);
                if (Check.Count > 0)
                {
                    SetAlert("Mã mooc này đã tồn tại! " +
                        "Vui lòng nhập mã mooc khác!", "warning");
                    return RedirectToAction("Create", "DMMooc");
                }
                else
                {
                    long id = dao.Insert(dMMooc);
                    if (id > 0)
                    {
                        SetAlert("Đã thêm mooc thành công !", "success");
                        return RedirectToAction("Index", "DMMooc");
                    }
                    else
                    {
                        SetAlert("Thêm mooc không thành công, vui lòng thử lại!", "warning");
                        return RedirectToAction("Create", "DMMooc");
                    }
                }
            }
            SetAlert("Vui lòng nhập đầy đủ các ô trống!", "warning");
            return RedirectToAction("Create", "DMMooc");
        }
        [HttpGet]
        public ActionResult Update(long id)
        {
            var dao = new DMMoocDao();
            var model = dao.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(DMMooc dMMooc)
        {
            if (ModelState.IsValid)
            {
                var dao = new DMMoocDao();
                var Check1 = dao.Check(dMMooc.MaMooc);
                var Check2 = dao.GetById(dMMooc.Id);
                if (Check1.Count > 0 && Check2.MaMooc != dMMooc.MaMooc)
                {
                    SetAlert("Mã mooc này đã tồn tại! " +
                        "Vui lòng nhập mã mooc khác!", "warning");
                    return RedirectToAction("Update", "DMMooc", new { id = dMMooc.Id });
                }
                else
                {
                    var result = dao.Update(dMMooc);
                    if (result)
                    {
                        SetAlert("Cập nhật dữ liệu xe thành công!", "success");
                        return RedirectToAction("Index", "DMMooc");
                    }
                    else
                    {
                        SetAlert("Cập nhật dữ liệu xe không thành công", "warning");
                        return RedirectToAction("Update", "DMMooc");
                    }
                }
            }
            return View("Index");
        }

        // Delete
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            var result = new DMMoocDao().Delete(id);
            if (result)
            {
                SetAlert("Xóa mooc thành công", "success");
                return RedirectToAction("Index", "DMXe");
            }
            else
            {
                SetAlert("Xóa mooc không thành công", "warning");
                return RedirectToAction("Index", "DMXe");
            }
        }
    }
}