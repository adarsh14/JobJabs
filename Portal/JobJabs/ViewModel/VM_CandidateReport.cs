using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using JobJabs.Entity;
using System.Web;

namespace JobJabs.ViewModel
{

    public class VM_CandidateReport
    {
        public List<CustomDropDown> FranchiseList { get; set; }
        public List<CustomDropDown> CompanyList { get; set; }
        public List<CustomDropDown> JobTitleList { get; set; }
        public List<CustomDropDown> JobLocationList { get; set; }
        public int SpocAdminId { get; set; }
        public int FranchiseId { get; set; }
        public int RecruiterId { get; set; }
        public int CompanyId { get; set; }
        public int JobPostId { get; set; }
        public string JobLocation { get; set; }
        public int Status { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public JPCandidateDetailList Content { get; set; }

        public static implicit operator CandidateReport(VM_CandidateReport model)
        {
            return new CandidateReport()
            {
                RecruiterId = model.RecruiterId,
                FranchiseId = model.FranchiseId,
                SpocAdminId = model.SpocAdminId,
                CompanyId = model.CompanyId,
                JobLocation = model.JobLocation,
                JobPostId = model.JobPostId,
                JPCAStatus = model.Status
            };
        }
        public static implicit operator CandidateReportFilter(VM_CandidateReport model)
        {
            return new CandidateReportFilter()
            {
                RecruiterId = model.RecruiterId,
                FranchiseId = model.FranchiseId,
                SpocAdminId = model.SpocAdminId,
                CompanyId = model.CompanyId,
                JobLocation = model.JobLocation,
                JobPostId = model.JobPostId
            };
        }
    }

    //public class VM_CandidateReportFilter
    //{
    //    public int SpocAdminId { get; set; }
    //    public int FranchiseId { get; set; }
    //    public int RecruiterId { get; set; }
    //    public int CompanyId { get; set; }
    //    public int JobPostId { get; set; }
    //    public string JobLocation { get; set; }
    //    public int Status { get; set; }
    //    public string FromDate { get; set; }
    //    public string ToDate { get; set; }

    //    public static implicit operator CandidateReport(VM_CandidateReportFilter model)
    //    {
    //        return new CandidateReport()
    //        {
    //            RecruiterId = model.RecruiterId,
    //            FranchiseId = model.FranchiseId,
    //            SpocAdminId = model.SpocAdminId,
    //            CompanyId = model.CompanyId,
    //            JobLocation = model.JobLocation,
    //            JobPostId = model.JobPostId,
    //            JPCAStatus = model.Status
    //        };
    //    }

    //    public static implicit operator VM_CandidateReportFilter(CandidateReport model)
    //    {
    //        return new VM_CandidateReportFilter()
    //        {
    //            RecruiterId = model.RecruiterId,
    //            FranchiseId = model.FranchiseId,
    //            SpocAdminId = model.SpocAdminId,
    //            CompanyId = model.CompanyId,
    //            JobLocation = model.JobLocation,
    //            JobPostId = model.JobPostId,
    //            Status = model.JPCAStatus
    //        };
    //    }
    //}


    
}


