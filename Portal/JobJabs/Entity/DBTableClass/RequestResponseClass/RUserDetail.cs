using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JobJabs.Entity;

namespace JobJabs.Entity
{

    public class UserDetailRequest : GetDataSet, iRequest
    {
        public UserDetailRequest(RUserDetail user, int queryType, string functionName)
        {
            user.QueryType = queryType;
            base.ProcedureName = "tb_UserDetail";
            base.ClassName = "BL_UserDetail";
            base.FunctionName = functionName;
            base.Param = user;
        }
    }

    public class RUserDetail
    {
        public int QueryType { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public int GenderId { get; set; }
        public int UserType { get; set; }
        public int IsPasswordValidated { get; set; }
        public int Status { get; set; }
        public int CreatedBy { get; set; }
    }

    public class AssignFranchiseRequest : GetDataSet, iRequest
    {
        public AssignFranchiseRequest(RUserDetail user, int queryType, string functionName)
        {
            user.QueryType = queryType;
            base.ProcedureName = "tb_UserDetail";
            base.ClassName = "BL_UserDetail";
            base.FunctionName = functionName;
            base.Param = user;
        }
    }


    public class RSPOCAdminFranchise
    {
        public int FranchiseIdId { get; set; }
        public int SPOCAdminId { get; set; }
        public int SPFACreatedBy { get; set; }
    }

}


