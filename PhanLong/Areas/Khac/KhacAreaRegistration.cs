using System.Web.Mvc;

namespace PhanLong.Areas.Khac
{
    public class KhacAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Khac";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Khac_default",
                "Khac/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}