
using JobJabs.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobJabs.Controllers
{

    public abstract class CommonBaseController : System.Web.Mvc.Controller
    {
              
        public static SessionClass session
        {
            get
            {
                SessionClass _sessionClass = new SessionClass();
                return _sessionClass;
            }
        }
    }

   
}
