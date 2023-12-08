using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobJabs.Entity
{
    public class EmploymentTypeDetailRequest : ExecuteNonQueryRequest, iRequest
    {
        public EmploymentTypeDetailRequest(REmploymentTypeDetail employmentTypeDetail, string functionName, int queryType)
        {
            employmentTypeDetail.QueryType = queryType;
            base.ProcedureName = "tb_EmploymentTypeDetail";
            base.ClassName = "BL_Common";
            base.FunctionName = functionName;
            base.Param = employmentTypeDetail;
        }
    }

    public class REmploymentTypeDetail
    {
        public int QueryType { get; set; }
        public int EmploymentTypeId { get; set; }
        public string EmploymentType { get; set; }
        public int EmpTypeStatus { get; set; }
        public int EmpTypeCreatedBy { get; set; }
    }

}
