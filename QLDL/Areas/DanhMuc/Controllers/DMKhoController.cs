using QLDL.DAO;
using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLDL.Areas.DanhMuc.Controllers
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

        [HttpPost]
        public ActionResult Index(int[] chkId, string delete = null)
        {
            var dao = new DMKhoDao();
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
        public PartialViewResult ViewDMKho()
        {
            var dao = new DMKhoDao();
            var model = dao.ListAll();
            return PartialView(model);
        }
        [HttpGet]
        public  ActionResult Create(long? id = null, string Copy = null)
        {
            if (id != null && Copy != null)
            {
                var dao = new DMKhoDao();
                var model = dao.GetById(id);
                return View(model);
            }
            else
            {

                return View();
            }
        }
        [HttpPost]
        public ActionResult Create(DMKho dMKho, int[] chkId, string delete = null)
        {
            var item = new DMKhoDao();
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
                    var dao = new DMKhoDao();
                    var Check = dao.Check(dMKho.MaKho);

                    if (Check.Count > 0)
                    {
                        SetAlert("Mã kho này đã tồn tại! " +
                            "Vui lòng nhập mã kho khác!", "warning");
                        return RedirectToAction("Create", "DMKho");
                    }
                    else
                    {
                        long id = dao.Insert(dMKho);
                        if (id > 0)
                        {
                            SetAlert("Đã thêm Kho thành công!", "success");
                            return RedirectToAction("Create", "DMKho");
                        }
                        else
                        {
                            SetAlert("Thêm Kho không thành công, vui lòng thử lại!", "warning");
                            return RedirectToAction("Create", "DMkho");
                        }
                    }
                }
                SetAlert("Vui lòng nhập đầy đủ các ô trống!", "warning");

            }
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
        public ActionResult Update(DMKho dMKho, int[] chkId, string delete = null)
        {
            var item = new DMKhoDao();
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
                    var dao = new DMKhoDao();
                    var Check1 = dao.Check(dMKho.MaKho);
                    var Check2 = dao.GetById(dMKho.Id);
                    if (Check1.Count > 0 && Check2.MaKho != dMKho.MaKho)
                    {
                        SetAlert("Mã kho này đã tồn tại! " +
                            "Vui lòng nhập mã kho khác!", "warning");
                        return RedirectToAction("Update", "DMKho", new { id = dMKho.Id });
                    }
                    else
                    {
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

                }
                SetAlert("Không có nội dung nào được chỉnh sửa", "warning");

            }
            return View("Index");
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