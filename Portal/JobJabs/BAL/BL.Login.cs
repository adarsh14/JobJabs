using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobJabs.Entity;
using JobJabs.DAL;
using System.Data;


namespace JobJabs.BAL
{
    public class BL_Login:Business
    {
        
        ///Login 
        public static UserDetail User_Authenication(Login login)
        {
            UserAuthenicationRequest request = new UserAuthenicationRequest(login, 1, "User_Authenication");
            DataTable dt = Database.GetDataTable(request);
            return (dt.Rows.Count > 0 ? ConvertToList<UserDetail>(dt).FirstOrDefault() : new UserDetail() { UserId = 0, LoginStatus = 2 });
        }

        public static OTPDetail Generate_OTP(OTPDetail autogen)
        {
            BL_ApiLayer apiLayer = new BL_ApiLayer();
            AutogenRequest request = new AutogenRequest(autogen);
            OTPDetail response = apiLayer.AddUpdate_Data<OTPDetail>(request);
            response.SessionId = response.Details;
            response.PhoneNo = autogen.PhoneNo;
            return response;
        }

        public static OTPDetail Validate_OTP(OTPDetail autogen)
        {
            BL_ApiLayer apiLayer = new BL_ApiLayer();
            VerifyOTPRequest request = new VerifyOTPRequest(autogen);
            OTPDetail response = apiLayer.AddUpdate_Data<OTPDetail>(request);
            response.SessionId = response.Details;
            return response;
        }
                     
    }
}

