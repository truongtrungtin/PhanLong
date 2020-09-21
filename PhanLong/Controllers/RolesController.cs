using PhanLong.DAO;
using System.Web.Mvc;

namespace PhanLong.Controllers
{
    public class RolesController : Controller
    {
        // GET: Roles
        public ActionResult Index()
        {
            var model = new RolesDao().ListAll();
            return View(model);
        }
    }
}