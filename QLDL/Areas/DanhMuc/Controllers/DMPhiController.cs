using QLDL.DAO;
using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLDL.Areas.DanhMuc.Controllers
{
    public class DMPhiController : BaseController
    {
        // GET: DMPhi
        public ActionResult Index()
        {
            var dao = new DMPhiDao();
            var model = dao.ListAll();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(int[] chkId, string delete = null)
        {
            var dao = new DMPhiDao();
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
        public PartialViewResult ViewDMPhi()
        {
            var dao = new DMPhiDao();
            var model = dao.ListAll();
            return PartialView(model);
        }
        [HttpGet]
        public ActionResult Create(long? id = null, string Copy = null)
        {
            if (id != null && Copy != null)
            {
                var dao = new DMPhiDao();
                var model = dao.GetById(id);
                return View(model);
            }
            else
            {

                return View();
            }
        }
        [HttpPost]
        public ActionResult Create(DMPhi dMPhi, int[] chkId, string delete = null)
        {
            var item = new DMPhiDao();
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
                    var dao = new DMPhiDao();
                    var Check = dao.Check(dMPhi.MaPhi);
                    if (Check.Count > 0)
                    {
                        SetAlert("Mã Phí này đã tồn tại! " +
                            "Vui lòng nhập mã Phí khác!", "warning");
                        return RedirectToAction("Create", "DMPhi");
                    }
                    else
                    {
                        long id = dao.Insert(dMPhi);
                        if (id > 0)
                        {
                            SetAlert("Đã thêm Phí thành công !", "success");
                            return RedirectToAction("Create", "DMPhi");
                        }
                        else
                        {
                            SetAlert("Thêm Phí không thành công, vui lòng thử lại!", "warning");
                            return RedirectToAction("Create", "DMPhi");
                        }
                    }
                }
                SetAlert("Vui lòng nhập đầy đủ các ô trống!", "warning");

            }
            return RedirectToAction("Create", "DMPhi");
        }
        [HttpGet]
        public ActionResult Update(long id)
        {
            var dao = new DMPhiDao();
            var model = dao.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(DMPhi dMPhi, int[] chkId, string delete = null)
        {
            var item = new DMPhiDao();
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
                    var dao = new DMPhiDao();
                    var Check1 = dao.Check(dMPhi.MaPhi);
                    var Check2 = dao.GetById(dMPhi.Id);
                    if (Check1.Count > 0 && Check2.MaPhi != dMPhi.MaPhi)
                    {
                        SetAlert("Mã Phí này đã tồn tại! " +
                            "Vui lòng nhập mã Phí khác!", "warning");
                        return RedirectToAction("Update", "DMPhi", new { id = dMPhi.Id });
                    }
                    else
                    {
                        var result = dao.Update(dMPhi);
                        if (result)
                        {
                            SetAlert("Cập nhật dữ liệu Phí thành công!", "success");
                            return RedirectToAction("Update", "DMPhi");
                        }
                        else
                        {
                            SetAlert("Cập nhật dữ liệu Phí không thành công", "warning");
                            return RedirectToAction("Update", "DMPhi");
                        }
                    }
                }
                SetAlert("Không có nội dung nào được chỉnh sửa", "warning");

            }
            return View("Update");
        }

        // Delete
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            var result = new DMPhiDao().Delete(id);
            if (result)
            {
                SetAlert("Xóa Phí thành công", "success");
                return RedirectToAction("Index", "DMPhi");
            }
            else
            {
                SetAlert("Xóa Phí không thành công", "warning");
                return RedirectToAction("Index", "DMPhi");
            }
        }
    }
}