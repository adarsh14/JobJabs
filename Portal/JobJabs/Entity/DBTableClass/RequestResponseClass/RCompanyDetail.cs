using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using JobJabs.Entity;

namespace JobJabs.Entity
{
    public class CompanyDetailRequest : GetDataSet, iRequest
    {
        public CompanyDetailRequest(RCompanyDetail franchise, int queryType, string functionName)
        {
            franchise.QueryType = queryType;
            base.ProcedureName = "tb_CompanyDetail";
            base.ClassName = "BL_CompanyDetail";
            base.FunctionName = functionName;
            base.Param = franchise;
        }
    }

    public class RCompanyDetail
    {
        public int QueryType { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Area { get; set; }
        public string Pincode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CompanyPhone1 { get; set; }
        public string CompanyPhone2 { get; set; }
        public string CompanyEmail { get; set; }
        public int CompanyStatus { get; set; }
        public int CompanyCreatedBy { get; set; }
    }

    public class CompanyLocationRequest : GetDataSet, iRequest
    {
        public CompanyLocationRequest(RCompanyLocationDetail location, int queryType, string functionName)
        {
            location.QueryType = queryType;
            base.ProcedureName = "tb_CompanyLocationDetail";
            base.ClassName = "BL_CompanyDetail";
            base.FunctionName = functionName;
            base.Param = location;
        }
    }


    public class RCompanyLocationDetail
    {
        public int QueryType { get; set; }
        public int CompLocId { get; set; }
        public int CompanyId { get; set; }
        public string LocationName { get; set; }
        public string HRName { get; set; }
        public DateTime DOB { get; set; }
        public string CompLocPhone1 { get; set; }
        public string CompLocPhone2 { get; set; }
        public string CompLocEmail { get; set; }
        public string CompLocAddress1 { get; set; }
        public string CompLocAddress2 { get; set; }
        public string CompLocArea { get; set; }
        public string CompLocPincode { get; set; }
        public string CompLocCity { get; set; }
        public string CompLocState { get; set; }
        public int CompLocStatus { get; set; }
        public int CompLocCreatedBy { get; set; }
    }

}