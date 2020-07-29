using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhanLong.DAO;
using PhanLong.Common;

namespace PhanLong.Controllers
{
    public class HomeController :BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}