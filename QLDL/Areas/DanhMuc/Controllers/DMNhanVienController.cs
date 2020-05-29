using QLDL.DAO;
using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLDL.Areas.DanhMuc.Controllers
{
    public class DMNhanVienController : BaseController
    {
        // GET: DMNhanVien
        public ActionResult Index()
        {
            var dao = new DMNhanVienDao();
            var model = dao.ListAll();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(int[] chkId, string delete = null)
        {
            var dao = new DMNhanVienDao();
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
        public PartialViewResult ViewDMNhanVien()
        {
            var dao = new DMNhanVienDao();
            var model = dao.ListAll();
            return PartialView(model);
        }
        [HttpGet]
        public ActionResult Create(long? id = null, string Copy = null)
        {
            if (id != null && Copy != null)
            {
                var dao = new DMNhanVienDao();
                var model = dao.GetById(id);
                return View(model);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Create(DMNhanVien dMNhanVien, int[] chkId, string delete = null)
        {
            var item = new DMNhanVienDao();
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
                    var dao = new DMNhanVienDao();
                    var Check = dao.Check(dMNhanVien.MaNV);
                    if (Check.Count > 0)
                    {
                        SetAlert("Mã nhân viên này đã tồn tại! " +
                            "Vui lòng nhập mã nhân viên khác!", "warning");
                        return RedirectToAction("Create", "DMNhanVien");
                    }
                    else
                    {
                        long id = dao.Insert(dMNhanVien);
                        if (id > 0)
                        {
                            SetAlert("Đã thêm Khách hàng thành công!", "success");
                            return RedirectToAction("Create", "DMNhanVien");
                        }
                        else
                        {
                            SetAlert("Thêm Khách hàng không thành công, vui lòng thử lại!", "warning");
                            return RedirectToAction("Create", "DMNhanVien");
                        }
                    }
                }
                SetAlert("Vui lòng nhập đầy đủ các ô trống!", "warning");

            }
            return RedirectToAction("Create", "DMNhanVien");
        }

        [HttpGet]
        public ActionResult Update(long id)
        {
            var dao = new DMNhanVienDao();
            var model = dao.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(DMNhanVien dMNhanVien, int[] chkId, string delete = null)
        {
            var item = new DMNhanVienDao();
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
                    var dao = new DMNhanVienDao();
                    var Check1 = dao.Check(dMNhanVien.MaNV);
                    var Check2 = dao.GetById(dMNhanVien.Id);
                    if (Check1.Count > 0 && Check2.MaNV != dMNhanVien.MaNV)
                    {
                        SetAlert("Mã nhân viên này đã tồn tại! " +
                            "Vui lòng nhập mã xe khác!", "warning");
                        return RedirectToAction("Update", "DMNhanVien", new { id = dMNhanVien.Id });
                    }
                    else
                    {
                        var result = dao.Update(dMNhanVien);
                        if (result)
                        {
                            SetAlert("Cập nhật dữ liệu nhân viên thành công!", "success");
                            return RedirectToAction("Index", "DMNhanVien");
                        }
                        else
                        {
                            SetAlert("Cập nhật dữ liệu nhân viên không thành công", "warning");
                            return RedirectToAction("Update", "DMNhanVien");
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
            var result = new DMNhanVienDao().Delete(id);
            if (result)
            {
                SetAlert("Xóa nhân viên thành công", "success");
                return RedirectToAction("Index", "DMNhanVien");
            }
            else
            {
                SetAlert("Xóa nhân viên không thành công", "warning");
                return RedirectToAction("Index", "DMNhanVien");
            }
        }
    }
}