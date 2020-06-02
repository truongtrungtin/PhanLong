using QLDL.DAO;
using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLDL.Areas.DanhMuc.Controllers
{
    public class DMThoiGianController : BaseController
    {
        // GET: DanhMuc/DMThoiGian
        public ActionResult Index()
        {
            var dao = new DMThoiGianDao();
            var model = dao.ListAll();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(int[] chkId, string delete = null)
        {
            var dao = new DMThoiGianDao();
            if (delete != null && chkId != null)
            {
                var result = dao.checkbox(chkId);
                if (result)
                {
                    SetAlert("Đã Xoá Thành Công !", "Success");
                }
                else
                {
                    SetAlert("Xoá Không Thành Công", " Warning");
                }
            }
            var model = dao.ListAll();
            return View(model);
        }
        [ChildActionOnly]
        public PartialViewResult ViewDMThoiGian()
        {
            var dao = new DMThoiGianDao();
            var model = dao.ListAll();
            return PartialView(model);
        }
        [HttpGet]
        public ActionResult Create(long? id = null, string Copy = null)
        {
            if (id != null && Copy != null)
            {
                var dao = new DMThoiGianDao();
                var model = dao.GetById(id);
                return View(model);
            }
            else
            {

                return View();
            }
        }
        [HttpPost]
        public ActionResult Create(DMThoiGian dMThoiGian ,int[] chkId, string delete = null)
        {
            var item = new DMThoiGianDao();
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
                    var dao = new DMThoiGianDao();
                    var Check = dao.Check(dMThoiGian.ThoiGian);

                    if (Check.Count > 0)
                    {
                        SetAlert("Thời gian này đã tồn tại! " +
                            "Vui lòng nhập thời gian khác!", "warning");
                        return RedirectToAction("Create", "DmThoiGian");
                    }
                    else
                    {
                        long id = dao.Insert(dMThoiGian);
                        if (id > 0)
                        {
                            SetAlert("Đã thêm thời gian thành công!", "success");
                            return RedirectToAction("Create", "DMThoiGian");
                        }
                        else
                        {
                            SetAlert("Thêm Thời Gian không thành công, vui lòng thử lại!", "warning");
                            return RedirectToAction("Create", "DMThoiGIan");
                        }
                    }
                }
                SetAlert("Vui lòng nhập đầy đủ các ô trống!", "warning");

            }
            return RedirectToAction("Create", "DMThoiGian");
        }
        [HttpGet]
        public ActionResult Update(long id)
        {
            var dao = new DMThoiGianDao();
            var model = dao.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(DMThoiGian dMThoiGian, int[] chkId, string delete = null)
        {
            var item = new DMThoiGianDao();
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
                    var dao = new DMThoiGianDao();
                    var Check1 = dao.Check(dMThoiGian.MaTG);
                    var Check2 = dao.GetById(dMThoiGian.Id);
                    if (Check1.Count > 0 && Check2.MaTG != dMThoiGian.MaTG)
                    {
                        SetAlert("Mã Thời Gian này đã tồn tại! " +
                            "Vui lòng nhập mã thời gian khác!", "warning");
                        return RedirectToAction("Update", "dMThoiGian", new { id = dMThoiGian.Id });
                    }
                    else
                    {
                        var result = dao.Update(dMThoiGian);
                        if (result)
                        {
                            SetAlert("Cập nhật dữ liệu thời gian thành công!", "success");
                            return RedirectToAction("Index", "DMThoiGian");
                        }
                        else
                        {
                            SetAlert("Cập nhật dữ liệu thời gian không thành công", "warning");
                            return RedirectToAction("Update", "DMThoiGian");
                        }
                    }

                }
                SetAlert("Không có nội dung nào được chỉnh sửa", "warning");

            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            var result = new DMThoiGianDao().Delete(id);
            if (result)
            {
                SetAlert("Xóa thời gian thành công", "success");
                return RedirectToAction("Index", "DMTHoiGian");
            }
            else
            {
                SetAlert("Xóa thời gian không thành công", "warning");
                return RedirectToAction("Index", "DMThoigian");
            }
        }
    }
}
