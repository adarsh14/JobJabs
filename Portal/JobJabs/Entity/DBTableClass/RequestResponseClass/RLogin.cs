using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JobJabs.Entity;

namespace JobJabs.Entity
{
    public class UserAuthenicationRequest : GetDataSet, iRequest
    {
        public UserAuthenicationRequest(RLogin login, int queryType, string functionName)
        {
            login.QueryType = queryType;
            base.ProcedureName = "Authenication_User";
            base.ClassName = "BL_Login";
            base.FunctionName = functionName;
            base.Param = login;
        }
    }

    public class RLogin
    {
        public int QueryType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
       
    }


   

}
