using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebGameMVC.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (WebGameMVC.Commons.Login.UserModel)Session[WebGameMVC.Commons.Login.UserSession.USER_SESSION];
            if (session != null)
            {
                if (session.type != 1)
                {
                    filterContext.Result = Redirect("/Home/Index");
                    //filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { Controller = "Home", Action = "Index" }));
                }
            }
            else
            {
                filterContext.Result = Redirect("/Home/Index");
                //filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { Controller = "Home", Action = "Index" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}