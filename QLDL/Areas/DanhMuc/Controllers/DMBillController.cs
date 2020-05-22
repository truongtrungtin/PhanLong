using QLDL.DAO;
using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLDL.Areas.DanhMuc.Controllers
{
    public class DMBillController : BaseController
    {
        public ActionResult Index()
        {
            var dao = new DMBillDao();
            var model = dao.ListAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult Create(DMBill dMBill)
        {
            if (ModelState.IsValid)
            {
                var dao = new DMBillDao();
                var Check = dao.Check(dMBill.MaBill);
                if (Check.Count > 0)
                {
                    SetAlert("Mã Bill này đã tồn tại! " +
                        "Vui lòng nhập mã Bill khác!", "warning");
                    return RedirectToAction("Create", "DMBill");
                }
                else
                {
                    long id = dao.Insert(dMBill);
                    if (id > 0)
                    {
                        SetAlert("Đã thêm Bill thành công !", "success");
                        return RedirectToAction("Index", "DMBill");
                    }
                    else
                    {
                        SetAlert("Thêm Bill không thành công, vui lòng thử lại!", "warning");
                        return RedirectToAction("Create", "DMBill");
                    }
                }
            }
            SetAlert("Vui lòng nhập đầy đủ các ô trống!", "warning");
            return RedirectToAction("Create", "DMBill");
        }
        public void SetViewBag(long? selectedId = null)
        {
            var KhachHang = new DMKhachHangDao();
            var Cang = new DMCangDao();
            ViewBag.KhachHang = new SelectList(KhachHang.ListAll(), "Id", "TenCongTy", selectedId);
            ViewBag.CangNhan = new SelectList(Cang.ListAll(), "Id", "TenCang", selectedId);
            ViewBag.CangTra = new SelectList(Cang.ListAll(), "Id", "TenCang", selectedId);

        }
        [HttpGet]
        public ActionResult Update(long id)
        {
            var dao = new DMBillDao();
            var model = dao.GetById(id);
            SetViewBag();
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(DMBill dMBill)
        {
            if (ModelState.IsValid)
            {
                var dao = new DMBillDao();
                var Check1 = dao.Check(dMBill.MaBill);
                var Check2 = dao.GetById(dMBill.Id);
                if (Check1.Count > 0 && Check2.MaBill != dMBill.MaBill)
                {
                    SetAlert("Mã Bill này đã tồn tại! " +
                        "Vui lòng nhập mã Bill khác!", "warning");
                    return RedirectToAction("Update", "DMBill", new { id = dMBill.Id });
                }
                else
                {
                    var result = dao.Update(dMBill);
                    if (result)
                    {
                        SetAlert("Cập nhật dữ liệu Bill thành công!", "success");
                        return RedirectToAction("Index", "DMBill");
                    }
                    else
                    {
                        SetAlert("Cập nhật dữ liệu Bill không thành công", "warning");
                        return RedirectToAction("Update", "DMBill");
                    }
                }
            }
            return View("Index");
        }


        // Delete
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            var result = new DMBillDao().Delete(id);
            if (result)
            {
                SetAlert("Xóa Bill thành công", "success");
                return RedirectToAction("Index", "DMBill");
            }
            else
            {
                SetAlert("Xóa Bill không thành công", "warning");
                return RedirectToAction("Index", "DMBill");
            }
        }

        // CTBill

        public ActionResult CTBill(long id)
        {
            var Bill = new DMBillDao().GetById(id);
            var dao = new CTBillDao();
            var model = dao.ListAll(id);
            ViewBag.Bill = Bill.MaBill;
            return View(model);
        }


        [HttpGet]
        public ActionResult CreateCTBill()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult CreateCTBill(CTBill dMBill)
        {
            if (ModelState.IsValid)
            {
                var dao = new CTBillDao();

                long id = dao.Insert(dMBill);
                if (id > 0)
                {
                    SetAlert("Đã thêm giá trị thành công !", "success");
                    return RedirectToAction("CTBill", "DMBill");
                }
                else
                {
                    SetAlert("Thêm giá trị không thành công, vui lòng thử lại!", "warning");
                    return RedirectToAction("CreateCTBill", "DMBill");
                }
            }

            SetAlert("Vui lòng nhập đầy đủ các ô trống!", "warning");
            return RedirectToAction("CreateCTBill", "DMBill");
        }

        [HttpGet]
        public ActionResult UpdateCTBill(long id)
        {
            var dao = new CTBillDao();
            var model = dao.GetById(id);
            SetViewBag();
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateCTBill(CTBill cTBill)
        {
            if (ModelState.IsValid)
            {
                var dao = new CTBillDao();
                
                var result = dao.Update(cTBill);
                if (result)
                {
                    SetAlert("Cập nhật dữ liệu thành công!", "success");
                    return RedirectToAction("CTBill", "DMBill", new { id = cTBill.Bill });
                }
                else
                {
                    SetAlert("Cập nhật dữ liệu không thành công", "warning");
                    return RedirectToAction("UpdateCTBill", "DMBill", new { id = cTBill.Bill });
                }

            }
            return View("Index");
        }


        // Delete
        [HttpDelete]
        public ActionResult DeleteCTBill(long id)
        {
            var bill = new CTBillDao().GetById(id).Bill;
            var result = new CTBillDao().Delete(id);
            if (result)
            {
                SetAlert("Xóa giá trị thành công", "success");
                return RedirectToAction("CTBill", "DMBill", new { id = bill });
            }
            else
            {
                SetAlert("Xóa giá trị không thành công", "warning");
                return RedirectToAction("CTBill", "DMBill", new { id = bill });
            }
        }
    }
}