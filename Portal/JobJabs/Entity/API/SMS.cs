using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobJabs.Entity
{

    public class OTPDetail
    {
        public string PhoneNo { get; set; }
        public int UserType { get; set; }
        public string Status { get; set; }
        public bool IsResponseValid
        {
            get
            {
                return (!string.IsNullOrEmpty(Status) ? (Status.ToLower() == "success" ? true : false ): false);
            }
        }
        public bool IsOTPValid { get {
                return ( !string.IsNullOrEmpty(Details) ?  (Details.ToLower() == "otp matched" ? true : false) : false);
            } }
        public string Details { get; set; }
        public string SessionId { get; set; }
        public string OTP { get; set; }

        public static implicit operator RAutogen(OTPDetail model)
        {
            return new RAutogen()
            {
                PhoneNo = model.PhoneNo
            };
        }

        public static implicit operator RVerifyOTP(OTPDetail model)
        {
            return new RVerifyOTP()
            {
                SessionId = model.SessionId,
                OTP = model.OTP
            };
        }
          public OTPDetail()
            {
                Status="Failed";
            }
    }

}
