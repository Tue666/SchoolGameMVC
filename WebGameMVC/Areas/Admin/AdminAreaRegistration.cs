using System.Web.Mvc;

namespace WebGameMVC.Areas.Admin
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
                "Admin_Feedback",
                "Admin/{controller}/{action}/{id}",
                new { Controller = "Feedback", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "WebGameMVC.Areas.Admin.Controllers" }
            );

            context.MapRoute(
                "Admin_Users",
                "Admin/{controller}/{action}/{id}",
                new { Controller = "User", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "WebGameMVC.Areas.Admin.Controllers" }
            );

            context.MapRoute(
                "Admin_InsertQuestion",
                "Admin/{controller}/{action}/{id}",
                new { Controller = "Question", action = "InsertQuestion", id = UrlParameter.Optional },
                namespaces: new string[] { "WebGameMVC.Areas.Admin.Controllers" }
            );

            context.MapRoute(
                "Admin_Question",
                "Admin/{controller}/{action}/{id}",
                new { Controller = "Question", action = "DetailStage", id = UrlParameter.Optional },
                namespaces: new string[] { "WebGameMVC.Areas.Admin.Controllers" }
            );

            context.MapRoute(
                "Admin_ListStage",
                "Admin/{controller}/{action}/{id}",
                new { Controller = "Question", action = "ListStage", id = UrlParameter.Optional },
                namespaces: new string[] { "WebGameMVC.Areas.Admin.Controllers" }
            );

            context.MapRoute(
                "Admin_PVE",
                "Admin/{controller}/{action}/{id}",
                new { Controller = "Question", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "WebGameMVC.Areas.Admin.Controllers" }
            );

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { Controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "WebGameMVC.Areas.Admin.Controllers" }
            );
        }
    }
}