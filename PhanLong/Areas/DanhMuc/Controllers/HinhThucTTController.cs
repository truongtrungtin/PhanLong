using PhanLong.DAO;
using PhanLong.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhanLong.Areas.DanhMuc.Controllers
{
    public class HinhThucTTController : BaseController
    {
        // GET: DMKho
        public ActionResult Index()
        {
            var dao = new HinhThucTTDao();
            var model = dao.ListAll();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(int[] chkId, string delete = null)
        {
            var dao = new HinhThucTTDao();
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
        public PartialViewResult ViewHinhThucTT()
        {
            var dao = new HinhThucTTDao();
            var model = dao.ListAll();
            return PartialView(model);
        }
        [HttpGet]
        public ActionResult Create(long? id = null, string Copy = null)
        {
            if (id != null && Copy != null)
            {
                var dao = new HinhThucTTDao();
                var model = dao.GetById(id);
                return View(model);
            }
            else
            {

                return View();
            }
        }
        [HttpPost]
        public ActionResult Create(HinhThucTT hinhThucTT, int[] chkId, string delete = null)
        {
            var item = new HinhThucTTDao();
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
                    var dao = new HinhThucTTDao();
                    var Check = dao.Check(hinhThucTT.MaHT);
                    if (Check.Count > 0)
                    {
                        SetAlert("Mã xe này đã tồn tại! " +
                            "Vui lòng nhập mã xe khác!", "warning");
                        return RedirectToAction("Create", "HinhThucTT");
                    }
                    else
                    {
                        long id = dao.Insert(hinhThucTT);
                        if (id > 0)
                        {
                            SetAlert("Đã thêm thành công !", "success");
                            return RedirectToAction("Create", "HinhThucTT");
                        }
                        else
                        {
                            SetAlert("Thêm không thành công, vui lòng thử lại!", "warning");
                            return RedirectToAction("Create", "HinhThucTT");
                        }
                    }
                }
                SetAlert("Vui lòng nhập đầy đủ các ô trống!", "warning");
            }
            return RedirectToAction("Create", "HinhThucTT");
        }
        [HttpGet]
        public ActionResult Update(long id)
        {
            var dao = new HinhThucTTDao();
            var model = dao.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(HinhThucTT hinhThucTT, int[] chkId, string delete = null)
        {
            var item = new HinhThucTTDao();
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
                    var dao = new HinhThucTTDao();
                    var Check1 = dao.Check(hinhThucTT.MaHT);
                    var Check2 = dao.GetById(hinhThucTT.Id);
                    if (Check1.Count > 0 && Check2.MaHT != hinhThucTT.MaHT)
                    {
                        SetAlert("Mã xe này đã tồn tại! " +
                            "Vui lòng nhập mã xe khác!", "warning");
                        return RedirectToAction("Update", "HinhThucTT", new { id = hinhThucTT.Id });
                    }
                    else
                    {
                        var result = dao.Update(hinhThucTT);
                        if (result)
                        {
                            SetAlert("Cập nhật dữ liệu thành công!", "success");
                            return RedirectToAction("Index", "HinhThucTT");
                        }
                        else
                        {
                            SetAlert("Cập nhật dữ liệu không thành công", "warning");
                            return RedirectToAction("Update", "HinhThucTT");
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
            var result = new HinhThucTTDao().Delete(id);
            if (result)
            {
                SetAlert("Xóa thành công", "success");
                return RedirectToAction("Index", "HinhThucTT");
            }
            else
            {
                SetAlert("Xóa không thành công", "warning");
                return RedirectToAction("Index", "HinhThucTT");
            }
        }
    }
}