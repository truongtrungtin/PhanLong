using System.Web.Mvc;

namespace PhanLong.Controllers
{
    public class BaseLoginController : Controller
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