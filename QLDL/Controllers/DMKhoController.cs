using QLDL.DAO;
using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLDL.Controllers
{
    public class DMKhoController : BaseController
    {
        // GET: DMKho
        public ActionResult Index()
        {
            var dao = new DMKhoDao();
            var model = dao.ListAll();
            return View(model);
        }


    }
}