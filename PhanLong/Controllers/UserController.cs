using PhanLong.Common;
using PhanLong.DAO;
using PhanLong.EF;
using PhanLong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhanLong.Controllers
{
    public class UserController : BaseController
    {

        // GET: Admin/User
        [HasCredential(RoleId = "VIEW_USER")]

        public ActionResult Index()
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(int[] chkId, string delete = null, string update = null, string chitiet = null)
        {
            var dao = new UserDao();
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
            else if(update != null && chkId.Length == 1)
            {
                return RedirectToAction("Update", "User", new { id = chkId[0] });
            }
            else if (chitiet != null && chkId.Length == 1)
            {
                return RedirectToAction("Detail", "User", new { id = chkId[0] });
            }
            var model = dao.ListAllPaging();
            return View(model);
        }

        public ActionResult Detail(long id)
        {
            var dao = new UserDao();
            var model = dao.ViewDetail(id);
            return View(model);
        }

        [HttpGet]
        [HasCredential(RoleId = "ADD_USER")]
        public ActionResult Create()
        {
            return View();
        }

        [HasCredential(RoleId = "EDIT_USER")]
        public ActionResult Update(long id)
        {
            var user = new UserDao().ViewDetail(id);
            return View(user);
        }

        [HttpPost]
        [HasCredential(RoleId = "ADD_USER")]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();

                var encryptedMd5Pas = Encryptor.MD5Hash(user.Password);
                user.Password = encryptedMd5Pas;

                long id = dao.Insert(user);
                if (id > 0)
                {
                    SetAlert("Thêm user thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm user không thành công");
                }
            }
            return View("Index");
        }
        [HttpPost]
        [HasCredential(RoleId = "EDIT_USER")]
        public ActionResult Update(User user, string[] selectroles)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (!string.IsNullOrEmpty(user.Password))
                {
                    var encryptedMd5Pas = Encryptor.MD5Hash(user.Password);
                    user.Password = encryptedMd5Pas;
                }

                var result = dao.Update(user, selectroles);
                if (result)
                {
                    SetAlert("Sửa user thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật user không thành công");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        [HasCredential(RoleId = "DELETE_USER")]
        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);

            return RedirectToAction("Index");
        }

    }
}