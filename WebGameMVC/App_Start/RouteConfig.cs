using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebGameMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "HistoryFeedback",
                url: "Feedback/HistoryFeedBack",
                defaults: new { controller = "Feedback", action = "HistoryFeedBack", id = UrlParameter.Optional },
                namespaces: new string[] { "WebGameMVC.Controllers" }
            );

            routes.MapRoute(
                name: "Feedback",
                url: "Feedback/Index",
                defaults: new { controller = "Feedback", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "WebGameMVC.Controllers" }
            );

            routes.MapRoute(
                name: "ShopPet",
                url: "Shop/ShopPet",
                defaults: new { controller = "Shop", action = "ShopPet", id = UrlParameter.Optional },
                namespaces: new string[] { "WebGameMVC.Controllers" }
            );

            routes.MapRoute(
                name: "ShopWings",
                url: "Shop/ShopWings",
                defaults: new { controller = "Shop", action = "ShopWings", id = UrlParameter.Optional },
                namespaces: new string[] { "WebGameMVC.Controllers" }
            );

            routes.MapRoute(
                name: "ShopAvatar",
                url: "Shop/ShopAvatar",
                defaults: new { controller = "Shop", action = "ShopAvatar", id = UrlParameter.Optional },
                namespaces: new string[] { "WebGameMVC.Controllers" }
            );

            routes.MapRoute(
                name: "TopRank",
                url: "Rank/TopRank",
                defaults: new { controller = "Rank", action = "TopRank", id = UrlParameter.Optional },
                namespaces: new string[] { "WebGameMVC.Controllers" }
            );

            routes.MapRoute(
                name: "UserInfor",
                url: "Account/UserInfor",
                defaults: new { controller = "Account", action = "UserInfor", id = UrlParameter.Optional },
                namespaces: new string[] { "WebGameMVC.Controllers" }
            );

            routes.MapRoute(
                name: "UpdateImage",
                url: "Collection/UpdateImage",
                defaults: new { controller = "Collection", action = "UpdateImage", id = UrlParameter.Optional },
                namespaces: new string[] { "WebGameMVC.Controllers" }
            );

            routes.MapRoute(
                name: "ViewItem",
                url: "Collection/ViewItem",
                defaults: new { controller = "Collection", action = "ViewItem", id = UrlParameter.Optional },
                namespaces: new string[] { "WebGameMVC.Controllers" }
            );

            routes.MapRoute(
                name: "Collection",
                url: "Collection/Index",
                defaults: new { controller = "Collection", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "WebGameMVC.Controllers" }
            );

            routes.MapRoute(
                name: "Result",
                url: "result",
                defaults: new { controller = "War", action = "Result", id = UrlParameter.Optional },
                namespaces: new string[] { "WebGameMVC.Controllers" }
            );

            routes.MapRoute(
                name: "War-PVE",
                url: "{controller}/{action}/{dungeonID}-{stageId}",
                defaults: new { controller = "War", action = "PVE", id = UrlParameter.Optional },
                namespaces: new string[] { "WebGameMVC.Controllers" }
            );

            routes.MapRoute(
                name: "Dungeon",
                url: "{controller}/{action}/{dungeonID}",
                defaults: new { controller = "Dungeon", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "WebGameMVC.Controllers" }
            );

            routes.MapRoute(
                name: "Regis",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Regis", id = UrlParameter.Optional },
                namespaces: new string[] { "WebGameMVC.Controllers" }
            );

            routes.MapRoute(
                name: "LogOut",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "LogOut", id = UrlParameter.Optional },
                namespaces: new string[] { "WebGameMVC.Controllers" }
            );

            routes.MapRoute(
                name: "Login",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "WebGameMVC.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "WebGameMVC.Controllers" }
            );
        }
    }
}
