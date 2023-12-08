using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobJabs.Entity
{
    public class CandidateReport
    {
        public int RecruiterId { get; set; }
        public int FranchiseId { get; set; }
        public int SpocAdminId { get; set; }
        public int CompanyId { get; set; }
        public int JobPostId { get; set; }
        public string JobLocation { get; set; }
        public int JPCAStatus { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public CandidateReport()
        {
            RecruiterId = 0;
            FranchiseId = 0;
            SpocAdminId = 0;
            CompanyId = 0;
            JobPostId = 0;
            JobLocation = "";
            JPCAStatus = 0;
            FromDate = null;
            ToDate = null;
        }

        public static implicit operator RCandidateReport(CandidateReport model)
        {
            return new RCandidateReport()
            {
                CompanyId = model.CompanyId,
                FranchiseId = model.FranchiseId,
                FromDate = model.FromDate,
                ToDate = model.ToDate,
                JobLocation = model.JobLocation,
                JobPostId = model.JobPostId,
                JPCAStatus = model.JPCAStatus,
                RecruiterId = model.RecruiterId,
                SpocAdminId = model.SpocAdminId
            };
        }
    }

    public class CandidateReportFilter
    {
        public int RecruiterId { get; set; }
        public int FranchiseId { get; set; }
        public int SpocAdminId { get; set; }
        public int CompanyId { get; set; }
        public int JobPostId { get; set; }
        public string JobLocation { get; set; }

        public static implicit operator RCandidateReportFilter(CandidateReportFilter model)
        {
            return new RCandidateReportFilter()
            {
                RecruiterId = model.RecruiterId,
                FranchiseId = model.FranchiseId,
                SpocAdminId = model.SpocAdminId,
                CompanyId=model.CompanyId,
                JobLocation = model.JobLocation,
                JobPostId = model.JobPostId
            };
        }
    }
}



