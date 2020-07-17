using PhanLong.DAO;
using PhanLong.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhanLong.Areas.DanhMuc.Controllers
{
    public class DMXeController : BaseController
    {
        // GET: DMKho
        public ActionResult Index()
        {
            var dao = new DMXeDao();
            var model = dao.ListAll();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(int[] chkId, string delete = null)
        {
            var dao = new DMXeDao();
            if (delete != null && chkId != null)
            {
                var result = dao.checkbox(chkId);
                if (result)
                {
                    SetAlert("Đã xóa thành công!", "success");
                }
                else
                {
                    SetAlert("Xóa không thành công, vui lòng thử lại!", "warning");
                }
            }
            var model = dao.ListAll();
            return View(model);
        }

        [ChildActionOnly]
        public PartialViewResult ViewDMXe()
        {
            var dao = new DMXeDao();
            var model = dao.ListAll();
            return PartialView(model);
        }
        [HttpGet]
        public ActionResult Create(long? id = null, string Copy = null)
        {
            if (id != null && Copy != null)
            {
                var dao = new DMXeDao();
                var model = dao.GetById(id);
                return View(model);
            }
            else
            {

                return View();
            }
        }
        [HttpPost]
        public ActionResult Create(DMXe dMXe, int[] chkId, string delete = null)
        {
            var item = new DMXeDao();
            if (delete != null && chkId != null)
            {
                var result = item.checkbox(chkId);
                if (result)
                {
                    SetAlert("Đã xóa thành công!", "success");
                }
                else
                {
                    SetAlert("Xóa không thành công, vui lòng thử lại!", "warning");
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var dao = new DMXeDao();
                    var Check = dao.Check(dMXe.MaXe);
                    if (Check.Count > 0)
                    {
                        SetAlert("Mã xe này đã tồn tại! " +
                            "Vui lòng nhập mã xe khác!", "warning");
                        return RedirectToAction("Create", "DMXe");
                    }
                    else
                    {
                        long id = dao.Insert(dMXe);
                        if (id > 0)
                        {
                            SetAlert("Đã thêm xe thành công !", "success");
                            return RedirectToAction("Create", "DMXe");
                        }
                        else
                        {
                            SetAlert("Thêm xe không thành công, vui lòng thử lại!", "warning");
                            return RedirectToAction("Create", "DMXe");
                        }
                    }
                }
                SetAlert("Vui lòng nhập đầy đủ các ô trống!", "warning");
            }
            return RedirectToAction("Create", "DMXe");
        }
        [HttpGet]
        public ActionResult Update(long id)
        {
            var dao = new DMXeDao();
            var model = dao.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(DMXe dMXe, int[] chkId, string delete = null)
        {
            var item = new DMXeDao();
            if (delete != null && chkId != null)
            {
                var result = item.checkbox(chkId);
                if (result)
                {
                    SetAlert("Đã xóa thành công!", "success");
                }
                else
                {
                    SetAlert("Xóa không thành công, vui lòng thử lại!", "warning");
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var dao = new DMXeDao();
                    var Check1 = dao.Check(dMXe.MaXe);
                    var Check2 = dao.GetById(dMXe.Id);
                    if (Check1.Count > 0 && Check2.MaXe != dMXe.MaXe)
                    {
                        SetAlert("Mã xe này đã tồn tại! " +
                            "Vui lòng nhập mã xe khác!", "warning");
                        return RedirectToAction("Update", "DMXe", new { id = dMXe.Id });
                    }
                    else
                    {
                        var result = dao.Update(dMXe);
                        if (result)
                        {
                            SetAlert("Cập nhật dữ liệu xe thành công!", "success");
                            return RedirectToAction("Index", "DMXe");
                        }
                        else
                        {
                            SetAlert("Cập nhật dữ liệu xe không thành công", "warning");
                            return RedirectToAction("Update", "DMXe");
                        }
                    }
                }
                SetAlert("Không có nội dung nào được chỉnh sửa", "warning");

            }
            return View("Index");
        }

        // Delete
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            var result = new DMXeDao().Delete(id);
            if (result)
            {
                SetAlert("Xóa xe thành công", "success");
                return RedirectToAction("Index", "DMXe");
            }
            else
            {
                SetAlert("Xóa xe không thành công", "warning");
                return RedirectToAction("Index", "DMXe");
            }
        }
    }
}