using QLDL.DAO;
using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLDL.Controllers
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
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DMNhanVien dMNhanVien)
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
                        return RedirectToAction("Index", "DMNhanVien");
                    }
                    else
                    {
                        SetAlert("Thêm Khách hàng không thành công, vui lòng thử lại!", "warning");
                        return RedirectToAction("Create", "DMNhanVien");
                    }
                }
            }
            SetAlert("Vui lòng nhập đầy đủ các ô trống!", "warning");
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
        public ActionResult Update(DMNhanVien dMNhanVien)
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