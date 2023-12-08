using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace JobJabs.Entity
{
    public class WriteToLogErrorHandler : HandleErrorAttribute
    {
       
        public override void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;
            var controllerName = Convert.ToString(filterContext.RouteData.Values["controller"]);
            var actionName = Convert.ToString(filterContext.RouteData.Values["action"]);
            WriteToLogClass.WriteErrorLog(controllerName ,actionName,ex);
            base.OnException(filterContext);
            filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new
            {
                controller = "Error",
                action = "Index",
                Message = Convert.ToString(filterContext.RouteData.Values["controller"])
            }));
        }
    }
}
