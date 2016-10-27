using System.Web.Mvc;

namespace WebApplication4.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Hote", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}