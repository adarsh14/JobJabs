using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using JobJabs.Entity;


namespace JobJabs.Entity
{

    public sealed class SessionRepository
    {
        public UserDetail UserDetail { get; set; }
        public FranchiseDetail FranchiseDetail { get; set; }
        public JPCASessionDetail JPCADetail { get; set; }
        public bool? MobileBrowserType { get; set; }
        public string SessionId { get; set; }
        public OTPDetail OTPDetail { get; set; }
    }

    public class SessionClass
    {
        private static SessionRepository SessionRepository
        {
            get
            {
                if (SessionInfo.getSession["SessionRepository"] == null)
                {
                    SessionInfo.getSession["SessionRepository"] = new SessionRepository()
                    {
                         UserDetail = new UserDetail(), FranchiseDetail = new FranchiseDetail(), JPCADetail = new JPCASessionDetail()
                    };
                }
                return SessionInfo.getSession["SessionRepository"] as SessionRepository;
            }
            set { SessionInfo.getSession["SessionRepository"] = value; }
        }

        public string SessionId
        {
            get
            {
                if (string.IsNullOrEmpty(SessionRepository.SessionId))
                    SessionRepository.SessionId = CommonClass.RandomString(10);
                return SessionRepository.SessionId;
            }
            set
            {
                SessionRepository.SessionId = value;
            }
        }

        public UserDetail UserDetail
        {
            get
            {
                return SessionRepository.UserDetail;
            }
            set
            {
                SessionRepository.UserDetail = value;
            }
        }

        public FranchiseDetail FranchiseDetail
        {
            get
            {
                return SessionRepository.FranchiseDetail;
            }
            set
            {
                SessionRepository.FranchiseDetail = value;
            }
        }

        public JPCASessionDetail JPCADetail
        {
            get
            {
                return SessionRepository.JPCADetail;
            }
            set
            {
                SessionRepository.JPCADetail = value;
            }
        }

        public bool? MobileBrowserType
        {
            get
            {
                if (SessionRepository.MobileBrowserType == null)
                    return null;
                else
                    return SessionRepository.MobileBrowserType.Value;
            }
            set
            {
                SessionRepository.MobileBrowserType = value;
            }
        }

        public OTPDetail OTPDetail
        {
            get
            {
                return SessionRepository.OTPDetail;
            }
            set
            {
                SessionRepository.OTPDetail = value;
            }
        }

        public bool IsSessionExists
        {
            get
            {
                if (SessionInfo.getSession["sessionstart"] == null)
                {
                    return false;
                }
                return true;
            }
        }

        public void CreateNewSession()
        {
            SessionInfo.getSession["sessionstart"] = "start";
        }

    }

    public class DatabaseSession
    {
        // private constructor
        private DatabaseSession()
        {
            ConnectionString = "JobJabsDB";
        }

        // Gets the current session.
        public static DatabaseSession Current
        {
            get
            {
                DatabaseSession session =
              (DatabaseSession)HttpContext.Current.Session["DatabaseSession"];
                if (session == null)
                {
                    session = new DatabaseSession();
                    HttpContext.Current.Session["DatabaseSession"] = session;
                }
                return session;
            }
        }

        // **** add your session properties here, e.g like this:
        public string ConnectionString { get; set; }
    }
}