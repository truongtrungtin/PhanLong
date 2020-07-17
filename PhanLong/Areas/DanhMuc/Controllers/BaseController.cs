using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhanLong.Areas.DanhMuc.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "success";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "error";
            }
        }
    }
}