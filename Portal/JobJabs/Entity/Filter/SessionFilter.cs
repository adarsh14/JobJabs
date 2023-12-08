using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using JobJabs.Entity;


namespace JobJabs.Filters
{
    public class SessionFilter : ActionFilterAttribute
    {
       
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                var _Session = new SessionClass();
                if (_Session.IsSessionExists == false)
                {
                    RouteValueDictionary redirectTargetDictionary = new RouteValueDictionary();
                    redirectTargetDictionary.Add("action", "Index");
                    redirectTargetDictionary.Add("controller", "Login");
                    redirectTargetDictionary.Add("area", "");
                    redirectTargetDictionary.Add("id", "1");
                    context.Result = new RedirectToRouteResult(redirectTargetDictionary);
                }
                base.OnActionExecuting(context);
            }
            catch (Exception ex)
            {
                WriteToLogClass.WriteErrorLog("MerchantSessionFilter", "OnActionExecuting", ex); 

            }
        }
    }
}