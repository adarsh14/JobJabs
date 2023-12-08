using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace JobJabs.Entity
{
    public class AutogenRequest : GetRequest, iRequest
    {
        public static string AutogenApi_Url { get { return ConfigurationManager.AppSettings["AutogenApi.Url"] == null ? String.Empty : Convert.ToString(ConfigurationManager.AppSettings["AutogenApi.Url"]); } }
      
        public AutogenRequest(RAutogen autogen)
        {
            base.ApiUrl = AutogenApi_Url.Replace("{api_key}", "f4f0bf2d-57a6-11e9-a6e1-0200cd936042").Replace("{phone_no}", autogen.PhoneNo)  ;
            base.AuthorizationToken ="";
        }
    }

    public class RAutogen {
        public string PhoneNo { get; set; }
    }


    public class VerifyOTPRequest : GetRequest, iRequest
    {
        public static string VerifyOTP_Url { get { return ConfigurationManager.AppSettings["VerifyOTP.Url"] == null ? String.Empty : Convert.ToString(ConfigurationManager.AppSettings["VerifyOTP.Url"]); } }
        public VerifyOTPRequest(RVerifyOTP verifyOTP)
        {
            base.ApiUrl = VerifyOTP_Url.Replace("{api_key}", "f4f0bf2d-57a6-11e9-a6e1-0200cd936042").Replace("{session_id}", verifyOTP.SessionId).Replace("{otp}", verifyOTP.OTP) ;
            base.AuthorizationToken = "";
        }
    }

    public class RVerifyOTP
    {
        public string SessionId { get; set; }
        public string OTP { get; set; }
    }

}
