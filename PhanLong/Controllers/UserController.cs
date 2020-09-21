using PhanLong.Common;
using PhanLong.DAO;
using PhanLong.EF;
using System;
using System.Configuration;
using System.IO;
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
        [HasCredential(RoleId = "VIEW_USER")]
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
            else if (update != null && chkId.Length == 1)
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

        public ActionResult Profile()
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            var Model = new UserDao().ViewDetail(session.UserID);
            return View(Model);
        }

        [HttpPost]
        public ActionResult Profile(User user, HttpPostedFileBase AvatarFile)
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            var dao = new UserDao();
            if (ModelState.IsValid)
            {
                if (AvatarFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(AvatarFile.FileName);
                    string extension = Path.GetExtension(AvatarFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymm") + extension;
                    user.Avatar = "/Images/Avatar/" + session.UserName + "/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/Avatar/" + session.UserName), fileName);
                    if (!Directory.Exists(Server.MapPath("~/Images/Avatar/" + session.UserName)))
                    {
                        Directory.CreateDirectory(Server.MapPath("~/Images/Avatar/" + session.UserName));
                    }
                    AvatarFile.SaveAs(fileName);
                    user.Id = session.UserID;
                    if (dao.UpdateAvatar(user))
                    {
                        SetAlert("Đổi avatar thành công!", "success");
                        return RedirectToAction("Profile", "User");
                    }
                    else
                    {
                        SetAlert("Đổi avatar không thành công!", "warning");

                    }
                }

            }
            return RedirectToAction("Profile", "User");
        }

        [ChildActionOnly]
        public PartialViewResult ChangeProfile()
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            var Model = new UserDao().ViewDetail(session.UserID);
            return PartialView(Model);
        }

        [HttpPost]
        public ActionResult ChangeProfile(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.UpdateProfile(user);
                if (result)
                {
                    SetAlert("Sửa thông tin tài khoản thành công!", "success");
                    return RedirectToAction("Profile", "User");
                }
                else
                {
                    SetAlert("Sửa thông tin tài khoản không thành công!", "warning");

                }
            }
            return RedirectToAction("Profile", "User");
        }

        [ChildActionOnly]
        public PartialViewResult ChangePassword()
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            var Model = new UserDao().ViewDetail(session.UserID);
            return PartialView(Model);
        }

        [HttpPost]
        public ActionResult ChangePassword(User user, string OldPassword, string NewPassword, string ConfirmNewPassword)
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];

            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (dao.CheckPassword(session.UserID, Encryptor.MD5Hash(OldPassword)))
                {
                    if (OldPassword != NewPassword)
                    {
                        if (NewPassword == ConfirmNewPassword)
                        {
                            var encryptedMd5Pas = Encryptor.MD5Hash(NewPassword);
                            user.Password = encryptedMd5Pas;
                            user.Id = session.UserID;
                            user.ModifiedBy = session.fullname;
                            var result = dao.UpdatePassword(user);
                            if (result)
                            {
                                string content = System.IO.File.ReadAllText(Server.MapPath("~/Content/templates/ChangePassword.html"));
                                content = content.Replace("{{username}}", session.UserName);
                                new MailHelper().SendMail(session.Email, "Phanlong.com", content, "Xác thực thông tin");


                                SetAlert("Thay đổi mật khẩu thành công!", "success");
                            }
                            else
                            {
                                SetAlert("Thay đổi mật khẩu không thành công!", "warning");

                            }
                        }
                        else
                        {
                            SetAlert("Mật khẩu mới không giống nhau!", "warning");
                        }
                    }
                    else
                    {
                        SetAlert("Mật khẩu cũ không được trùng mật khẩu mới!", "warning");
                    }

                }
                else
                {
                    SetAlert("Sai mật khẩu!", "warning");
                }
            }
            return RedirectToAction("Profile", "User");
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
        public ActionResult Create(User user, string[] selectroles)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var session = (UserLogin)Session[CommonConstants.USER_SESSION];
                string pass = dao.RandomPassword();
                var encryptedMd5Pas = Encryptor.MD5Hash(pass);
                user.Password = encryptedMd5Pas;
                user.CreatedBy = session.fullname;
                long id = dao.Insert(user, selectroles);
                if (id > 0)
                {
                    try
                    {
                        string content = System.IO.File.ReadAllText(Server.MapPath("~/Content/templates/CreateAccount.html"));

                        content = content.Replace("{{FullName}}", user.Name);
                        content = content.Replace("{{Telephone}}", user.Telephone);
                        content = content.Replace("{{Email}}", user.Email);
                        content = content.Replace("{{Address}}", user.Address);
                        content = content.Replace("{{Username}}", user.Username);
                        content = content.Replace("{{Password}}", pass);

                        var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();
                        new MailHelper().SendMail(user.Email, "Tài khoản Phanlong.com", content, "Tài khoản Phanlong.com");
                        new MailHelper().SendMail(toEmail, "Tài khoản Phanlong.com", content, "Tài khoản Phanlong.com");
                        SetAlert("Thêm user thành công! Đã gửi tên tài khoản và password tới email!", "success");
                        return RedirectToAction("Index", "User");
                    }
                    catch (Exception)
                    {
                        SetAlert("Thêm không thành công!", "warning");
                        return RedirectToAction("Create", "User");

                    }
                }
                else
                {
                    SetAlert("Thêm user không thành công!", "warning");
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
                    SetAlert("Sửa user thành công!", "success");
                    return RedirectToAction("Update", "User", new { id = user.Id });
                }
                else
                {
                    SetAlert("Cập nhật user không thành công!", "warning");

                }
            }
            return RedirectToAction("Update", "User", new { id = user.Id });
        }

        [HttpDelete]
        [HasCredential(RoleId = "DELETE_USER")]
        public ActionResult Delete(long id)
        {
            if (new UserDao().Delete(id))
            {
                SetAlert("Xoá thành công!", "success");
            }
            else
            {
                SetAlert("Xoá không thành công", "warning");
            }
            return RedirectToAction("Index", "User");
        }

    }
}