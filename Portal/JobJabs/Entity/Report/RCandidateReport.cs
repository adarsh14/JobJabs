using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobJabs.Entity
{
    public class CandidateReportRequest : ExecuteNonQueryRequest, iRequest
    {
        public CandidateReportRequest(RCandidateReport report, string functionName, int queryType)
        {
            report.QueryType = queryType;
            base.ProcedureName = "Report_CandidateDetail";
            base.ClassName = "BL_CandidateReport";
            base.FunctionName = functionName;
            base.Param = report;
        }
    }

    public class RCandidateReport
    {
        public int QueryType { get; set; }
        public int RecruiterId { get; set; }
        public int FranchiseId { get; set; }
        public int SpocAdminId { get; set; }
        public int CompanyId { get; set; }
        public int JobPostId { get; set; }
        public string JobLocation { get; set; }
        public int JPCAStatus { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
    
    public class CandidateReporFiltertRequest : ExecuteNonQueryRequest, iRequest
    {
        public CandidateReporFiltertRequest(RCandidateReportFilter filter, string functionName, int queryType)
        {
            filter.QueryType = queryType;
            base.ProcedureName = "Report_CandidateDetailFilter";
            base.ClassName = "BL_CandidateReport";
            base.FunctionName = functionName;
            base.Param = filter;
        }
    }
    public class RCandidateReportFilter
    {
        public int QueryType { get; set; }
        public int RecruiterId { get; set; }
        public int FranchiseId { get; set; }
        public int SpocAdminId { get; set; }
        public int CompanyId { get; set; }
        public int JobPostId { get; set; }
        public string JobLocation { get; set; }
    }
}
