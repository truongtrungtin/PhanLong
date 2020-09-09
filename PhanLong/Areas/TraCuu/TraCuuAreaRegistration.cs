using System.Web.Mvc;

namespace PhanLong.Areas.TraCuu
{
    public class TraCuuAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TraCuu";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TraCuu_default",
                "TraCuu/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}