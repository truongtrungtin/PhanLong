using QLDL.DAO;
using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLDL.Controllers
{
    public class DMLoaiController : BaseController
    {
        // GET: DMLoai
        public ActionResult Index()
        {
            var dao = new DMLoaiDao();
            var model = dao.ListAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DMLoai dMLoai)
        {
            if (ModelState.IsValid)
            {
                var dao = new DMLoaiDao();
                var Check = dao.Check(dMLoai.MaLoai);
                if (Check.Count > 0)
                {
                    SetAlert("Mã loại này đã tồn tại! " +
                        "Vui lòng nhập mã loại khác!", "warning");
                    return RedirectToAction("Create", "DMLoai");
                }
                else
                {
                    long id = dao.Insert(dMLoai);
                    if (id > 0)
                    {
                        SetAlert("Đã thêm loại thành công !", "success");
                        return RedirectToAction("Index", "DMLoai");
                    }
                    else
                    {
                        SetAlert("Thêm loại không thành công, vui lòng thử lại!", "warning");
                        return RedirectToAction("Create", "DMLoai");
                    }
                }
            }
            SetAlert("Vui lòng nhập đầy đủ các ô trống!", "warning");
            return RedirectToAction("Create", "DMLoai");
        }
        [HttpGet]
        public ActionResult Update(long id)
        {
            var dao = new DMLoaiDao();
            var model = dao.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(DMLoai dMLoai)
        {
            if (ModelState.IsValid)
            {
                var dao = new DMLoaiDao();
                var Check1 = dao.Check(dMLoai.MaLoai);
                var Check2 = dao.GetById(dMLoai.Id);
                if (Check1.Count > 0 && Check2.MaLoai != dMLoai.MaLoai)
                {
                    SetAlert("Mã loại này đã tồn tại! " +
                        "Vui lòng nhập mã loại khác!", "warning");
                    return RedirectToAction("Create", "DMLoai");
                }
                else
                {
                    var result = dao.Update(dMLoai);
                    if (result)
                    {
                        SetAlert("Cập nhật dữ liệu loại thành công!", "success");
                        return RedirectToAction("Index", "DMLoai");
                    }
                    else
                    {
                        SetAlert("Cập nhật dữ liệu loại không thành công", "warning");
                        return RedirectToAction("Update", "DMLoai");
                    }
                }
            }
            return View("DMLoai");
        }

        // Delete
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            var result = new DMXeDao().Delete(id);
            if (result)
            {
                SetAlert("Xóa loại thành công", "success");
                return RedirectToAction("Index", "DMLoai");
            }
            else
            {
                SetAlert("Xóa loại không thành công", "warning");
                return RedirectToAction("Index", "DMLoai");
            }
        }
    }
}