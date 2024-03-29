﻿using PhanLong.Common;
using PhanLong.DAO;
using PhanLong.EF;
using PhanLong.Models;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PhanLong.Controllers
{
    public class LoginController : BaseLoginController
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    var user = dao.GetById(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.Username;
                    userSession.UserID = user.Id;
                    userSession.GroupID = user.GroupID;
                    userSession.fullname = user.Name;
                    userSession.Email = user.Email;
                    userSession.avatar = user.Avatar;
                    var listCredentials = dao.GetListCredential(model.UserName);

                    Session.Add(CommonConstants.SESSION_CREDENTIALS, listCredentials);
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    if (model.RememberMe == true)
                    {
                        
                    }
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    SetAlert("Tài khoản không tồn tại!", "warning");
                }
                else if (result == -1)
                {
                    SetAlert("Tài khoản đang bị khoá!", "warning");
                }
                else if (result == -2)
                {
                    SetAlert("Mật khẩu không đúng!", "warning");
                }
                else if (result == -3)
                {
                    SetAlert("Tài khoản của bạn không có quyền đăng nhập!", "warning");
                }
                else
                {
                    SetAlert("đăng nhập không đúng!", "warning");
                }
            }
            return View(model);
        }


        //private Uri RedirectUri
        //{
        //    get
        //    {
        //        var uriBuilder = new UriBuilder(Request.Url);
        //        uriBuilder.Query = null;
        //        uriBuilder.Fragment = null;
        //        uriBuilder.Path = Url.Action("FacebookCallback");
        //        return uriBuilder.Uri;
        //    }
        //}

        //public ActionResult LoginFacebook()
        //{
        //    var fb = new FacebookClient();
        //    var loginUrl = fb.GetLoginUrl(new
        //    {
        //        client_id = ConfigurationManager.AppSettings["FbAppId"],
        //        client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
        //        redirect_uri = RedirectUri.AbsoluteUri,
        //        response_type = "code",
        //        scope = "email",
        //    });

        //    return Redirect(loginUrl.AbsoluteUri);
        //}

        //public ActionResult FacebookCallback(string code)
        //{
        //    var fb = new FacebookClient();
        //    dynamic result = fb.Post("oauth/access_token", new
        //    {
        //        client_id = ConfigurationManager.AppSettings["FbAppId"],
        //        client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
        //        redirect_uri = RedirectUri.AbsoluteUri,
        //        code = code
        //    });


        //    var accessToken = result.access_token;
        //    if (!string.IsNullOrEmpty(accessToken))
        //    {
        //        fb.AccessToken = accessToken;
        //        // Get the user's information, like email, first name, middle name etc
        //        dynamic me = fb.Get("me?fields=first_name,middle_name,last_name,id,email");
        //        string email = me.email;
        //        string userName = me.email;
        //        string firstname = me.first_name;
        //        string middlename = me.middle_name;
        //        string lastname = me.last_name;

        //        var user = new User();
        //        user.Email = email;
        //        user.UserName = email;
        //        user.Status = true;
        //        user.Name = firstname + " " + middlename + " " + lastname;
        //        user.CreatedDate = DateTime.Now;
        //        var resultInsert = new UserDao().InsertForFacebook(user);
        //        if (resultInsert > 0)
        //        {
        //            var userSession = new UserLogin();
        //            userSession.UserName = user.UserName;
        //            userSession.UserID = user.ID;
        //            Session.Add(CommonConstants.USER_SESSION, userSession);
        //        }
        //    }
        //    return Redirect("/");
        //}
        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return RedirectToAction("Index", "Login");
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (dao.CheckEmail(user.Email))
                {
                    int tokenkey = dao.RandomNumber(100000, 999999);

                    string content = System.IO.File.ReadAllText(Server.MapPath("~/Content/templates/ForgotPassword.html"));

                    content = content.Replace("{{FullName}}", user.Name);
                    content = content.Replace("{{tokenkey}}", Convert.ToString(tokenkey));
                    new MailHelper().SendMail(user.Email, "Phanlong.com", content, "Đặt lại mật khẩu");


                    return RedirectToAction("RecoverPassword", "Login", new { @email = user.Email, @token = Encryptor.MD5Hash(Convert.ToString(tokenkey)) });
                }
                else
                {
                    ModelState.AddModelError("", "Email không tồn tại.");
                }
            }
            return View();
        }

        public ActionResult RecoverPassword(string email, string token)
        {
            ViewBag.Token = token;
            ViewBag.Email = email;
            return View();
        }
        [HttpPost]
        public ActionResult RecoverPassword(User user, string token, string hash)
        {
            if (ModelState.IsValid)
            {
                if (Encryptor.MD5Hash(token) == hash)
                {
                    var dao = new UserDao().GetByEmail(user.Email);
                    var Code = Encryptor.MD5Hash(dao.Username + dao.Email + dao.Telephone + dao.Address);
                    return RedirectToAction("NewPassword", "Login", new { @email = user.Email, code = Code });
                }
                else
                {
                    ModelState.AddModelError("", "Sai mã bảo mật.");
                }
            }
            return View();
        }

        public ActionResult NewPassword(string email, string code)
        {
            var dao = new UserDao().GetByEmail(email);
            if (Encryptor.MD5Hash(dao.Username + dao.Email + dao.Telephone + dao.Address) == code)
            {
                ViewBag.Email = email;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpPost]
        public ActionResult NewPassword(User user, string NewPassword)
        {
            if (ModelState.IsValid)
            {

                var dao = new UserDao();
                var encryptedMd5Pas = Encryptor.MD5Hash(NewPassword);
                user.Id = dao.GetByEmail(user.Email).Id;
                user.Password = encryptedMd5Pas;
                var result = dao.UpdatePassword(user);
                if (result)
                {
                    string content = System.IO.File.ReadAllText(Server.MapPath("~/Content/templates/ChangePassword.html"));
                    content = content.Replace("{{username}}", user.Email);
                    new MailHelper().SendMail(user.Email, "Phanlong.com", content, "Thay đổi mật khẩu");

                    SetAlert("Thay đổi mật khẩu thành công!", "success");
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    ModelState.AddModelError("", "Lỗi! vui lòng thử lại.");

                }

            }
            return View();
        }


        //[HttpPost]
        //[CaptchaValidation("CaptchaCode", "registerCapcha", "Mã xác nhận không đúng!")]
        //public ActionResult Register(RegisterModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var dao = new UserDao();
        //        if (dao.CheckUserName(model.UserName))
        //        {
        //            ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
        //        }
        //        else if (dao.CheckEmail(model.Email))
        //        {
        //            ModelState.AddModelError("", "Email đã tồn tại");
        //        }
        //        else
        //        {
        //            var user = new User();
        //            user.Name = model.Name;
        //            user.Password = Encryptor.MD5Hash(model.Password);
        //            user.Phone = model.Phone;
        //            user.Email = model.Email;
        //            user.Address = model.Address;
        //            user.CreatedDate = DateTime.Now;
        //            user.Status = true;
        //            if (!string.IsNullOrEmpty(model.ProvinceID))
        //            {
        //                user.ProvinceID = int.Parse(model.ProvinceID);
        //            }
        //            if (!string.IsNullOrEmpty(model.DistrictID))
        //            {
        //                user.DistrictID = int.Parse(model.DistrictID);
        //            }

        //            var result = dao.Insert(user);
        //            if (result > 0)
        //            {
        //                ViewBag.Success = "Đăng ký thành công";
        //                model = new RegisterModel();
        //            }
        //            else
        //            {
        //                ModelState.AddModelError("", "Đăng ký không thành công.");
        //            }
        //        }
        //    }
        //    return View(model);
        //}

        //public JsonResult LoadProvince()
        //{
        //    var xmlDoc = XDocument.Load(Server.MapPath(@"~/assets/client/data/Provinces_Data.xml"));

        //    var xElements = xmlDoc.Element("Root").Elements("Item").Where(x => x.Attribute("type").Value == "province");
        //    var list = new List<ProvinceModel>();
        //    ProvinceModel province = null;
        //    foreach (var item in xElements)
        //    {
        //        province = new ProvinceModel();
        //        province.ID = int.Parse(item.Attribute("id").Value);
        //        province.Name = item.Attribute("value").Value;
        //        list.Add(province);

        //    }
        //    return Json(new
        //    {
        //        data = list,
        //        status = true
        //    });
        //}
        //public JsonResult LoadDistrict(int provinceID)
        //{
        //    var xmlDoc = XDocument.Load(Server.MapPath(@"~/assets/client/data/Provinces_Data.xml"));

        //    var xElement = xmlDoc.Element("Root").Elements("Item")
        //        .Single(x => x.Attribute("type").Value == "province" && int.Parse(x.Attribute("id").Value) == provinceID);

        //    var list = new List<DistrictModel>();
        //    DistrictModel district = null;
        //    foreach (var item in xElement.Elements("Item").Where(x => x.Attribute("type").Value == "district"))
        //    {
        //        district = new DistrictModel();
        //        district.ID = int.Parse(item.Attribute("id").Value);
        //        district.Name = item.Attribute("value").Value;
        //        district.ProvinceID = int.Parse(xElement.Attribute("id").Value);
        //        list.Add(district);

        //    }
        //    return Json(new
        //    {
        //        data = list,
        //        status = true
        //    });
        //}
    }
}