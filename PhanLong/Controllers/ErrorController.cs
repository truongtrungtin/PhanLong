using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhanLong.Controllers
{
    public class ErrorController : BaseController
    {
        // GET: Error
        public ActionResult Error404()
        {
            return View();
        }
        public ActionResult Error403()
        {
            return View();
        }
        public ActionResult Error500()
        {
            return View();
        }
    }
}