using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using JobJabs.Entity;

namespace JobJabs.Entity
{
    public class FranchiseDetailRequest : GetDataSet, iRequest
    {
        public FranchiseDetailRequest(RFranchiseDetail franchise, int queryType, string functionName)
        {
            franchise.QueryType = queryType;
            base.ProcedureName = "tb_FranchiseDetail";
            base.ClassName = "BL_FranchiseDetail";
            base.FunctionName = functionName;
            base.Param = franchise;
        }
    }

    public class RFranchiseDetail
    {
        public int QueryType { get; set; }
        public int FranchiseId { get; set; }
        public int UserId { get; set; }
        public string FranchiseName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Area { get; set; }
        public string Pincode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string FranchisePhone1 { get; set; }
        public string FranchisePhone2 { get; set; }
        public string FranchiseEmail { get; set; }
        public int FranchiseStatus { get; set; }
        public int FranchiseCreatedBy { get; set; }
    }

    public class FranchiseUserDetailRequest : GetDataSet, iRequest
    {
        public FranchiseUserDetailRequest(RFranchiseUserDetail franchiseUser, int queryType, string functionName)
        {
            franchiseUser.QueryType = queryType;
            base.ProcedureName = "tb_FranchiseUserDetail";
            base.ClassName = "BL_FranchiseDetail";
            base.FunctionName = functionName;
            base.Param = franchiseUser;
        }
    }

    public class RFranchiseUserDetail
    {
        public int QueryType { get; set; }
        public int FranchiseId { get; set; }
        public int UserId { get; set; }
    }

    public class SPOCFranchiseDetailRequest : GetDataSet, iRequest
    {
        public SPOCFranchiseDetailRequest(RSPOCFranchiseDetail franchiseSPOC, int queryType, string functionName)
        {
            franchiseSPOC.QueryType = queryType;
            base.ProcedureName = "tb_SPOCAdminFranchiseDetail";
            base.ClassName = "BL_FranchiseDetail";
            base.FunctionName = functionName;
            base.Param = franchiseSPOC;
        }
    }
    public class RSPOCFranchiseDetail
    {
        public int QueryType { get; set; }
        public int SPOCAdminId { get; set; }
        public int FranchiseId { get; set; }
        public int SPFACreatedBy { get; set; }
    }

}