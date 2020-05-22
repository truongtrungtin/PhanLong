using QLDL.DAO;
using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLDL.Areas.DanhMuc.Controllers
{
    public class DMNoiDungController : BaseController
    {
        // GET: DMNoiDung
        public ActionResult Index()
        {
            var dao = new DMNoiDungDao();
            var model = dao.ListAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DMNoiDung dMNoiDung)
        {
            if (ModelState.IsValid)
            {
                var dao = new DMNoiDungDao();
                var Check = dao.Check(dMNoiDung.MaND);
                if (Check.Count > 0)
                {
                    SetAlert("Mã nội dung này đã tồn tại! " +
                        "Vui lòng nhập mã nội dung khác!", "warning");
                    return RedirectToAction("Create", "DMNoiDung");
                }
                else
                {
                    long id = dao.Insert(dMNoiDung);
                    if (id > 0)
                    {
                        SetAlert("Đã thêm nội dung thành công !", "success");
                        return RedirectToAction("Index", "DMNoiDung");
                    }
                    else
                    {
                        SetAlert("Thêm nội dung không thành công, vui lòng thử lại!", "warning");
                        return RedirectToAction("Create", "DMNoiDung");
                    }
                }
            }
            SetAlert("Vui lòng nhập đầy đủ các ô trống!", "warning");
            return RedirectToAction("Create", "DMNoiDung");
        }
        [HttpGet]
        public ActionResult Update(long id)
        {
            var dao = new DMNoiDungDao();
            var model = dao.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(DMNoiDung dMNoiDung)
        {
            if (ModelState.IsValid)
            {
                var dao = new DMNoiDungDao();
                var Check1 = dao.Check(dMNoiDung.MaND);
                var Check2 = dao.GetById(dMNoiDung.Id);
                if (Check1.Count > 0 && Check2.MaND != dMNoiDung.MaND)
                {
                    SetAlert("Mã nội dung này đã tồn tại! " +
                        "Vui lòng nhập mã nội dung khác!", "warning");
                    return RedirectToAction("Update", "DMNoiDung", new { id = dMNoiDung.Id });
                }
                else
                {
                    var result = dao.Update(dMNoiDung);
                    if (result)
                    {
                        SetAlert("Cập nhật dữ liệu nội dung thành công!", "success");
                        return RedirectToAction("Index", "DMNoiDung");
                    }
                    else
                    {
                        SetAlert("Cập nhật dữ liệu nội dung không thành công", "warning");
                        return RedirectToAction("Update", "DMNoiDung");
                    }
                }
            }
            return View("Index");
        }

        // Delete
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            var result = new DMNoiDungDao().Delete(id);
            if (result)
            {
                SetAlert("Xóa nội dung thành công", "success");
                return RedirectToAction("Index", "DMNoiDung");
            }
            else
            {
                SetAlert("Xóa nội dung không thành công", "warning");
                return RedirectToAction("Index", "DMNoiDung");
            }
        }
    }
}