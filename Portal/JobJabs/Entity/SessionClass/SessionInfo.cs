using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace JobJabs.Entity
{
     
    public sealed class SessionInfo
    {
       
        private static SessionInfo instance;
        private static object syncRoot = new Object();
        private SessionInfo() { }
       
        public static SessionInfo getSession
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null) instance = new SessionInfo();
                    }
                }
                return instance;
            }
        }
        private Dictionary<string, object> storage = new Dictionary<string, object> { };
        public object this[string name]
        {
            get
            {
                try { return System.Web.HttpContext.Current.Session[name]; }
                catch { return storage[name]; }
            }
            set
            {
                try { System.Web.HttpContext.Current.Session[name] = value; }
                catch { storage[name] = value; }
            }
        }
    }
}