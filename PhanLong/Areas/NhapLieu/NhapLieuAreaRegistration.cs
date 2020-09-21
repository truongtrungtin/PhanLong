
using System.Web.Mvc;

namespace PhanLong.Areas.NhapLieu
{
    public class NhapLieuAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "NhapLieu";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "NhapLieu_default",
                "NhapLieu/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}