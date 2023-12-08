using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobJabs.Entity
{
    public class JobPostDetailRequest : ExecuteNonQueryRequest, iRequest
    {
        public JobPostDetailRequest(RJobPostDetail jobPostDetail, string functionName, int queryType)
        {
            jobPostDetail.QueryType = queryType;
            base.ProcedureName = "tb_JobPostDetail";
            base.ClassName = "BL_JobPostDetail";
            base.FunctionName = functionName;
            base.Param = jobPostDetail;
        }
    }

    public class RJobPostDetail
    {
        public int QueryType { get; set; }
        public int JobPostId { get; set; }
        public int ClientId { get; set; }
        public int ClientLocationId { get; set; }
        public string JobTitle { get; set; }
        public string JobLocation { get; set; }
        public string JobCTC { get; set; }
        public string CompanyDescription { get; set; }
        public string JobDescription { get; set; }
        public string Qualification { get; set; }
        public string AdditionalInformation { get; set; }
        public string Industry { get; set; }
        public int IndustryId { get; set; }
        public string Functional { get; set; }
        public int FunctionalId { get; set; }
        public int ExperienceLevel { get; set; }
        public int TypeOfEmployment { get; set; }
        public string JDFileName { get; set; }
        public string ChecklistFileName { get; set; }
        public int JobPostStatus { get; set; }
        public int JPCreatedBy { get; set; }
    }


    public class JPFADetailRequest : ExecuteNonQueryRequest, iRequest
    {
        public JPFADetailRequest(RJobPostFranchiseDetail jobPostDetail, string functionName, int queryType)
        {
            jobPostDetail.QueryType = queryType;
            base.ProcedureName = "tb_JobPostFranchiseDetail";
            base.ClassName = "BL_JobPostDetail";
            base.FunctionName = functionName;
            base.Param = jobPostDetail;
        }
    }


    public class RJobPostFranchiseDetail
    {
        public int QueryType { get; set; }
        public int JobPostId { get; set; }
        public int FranchiseId { get; set; }
        public int SPOCAdminId { get; set; }
        public int JPFACreatedBy { get; set; }
    }


    public class JPRCDetailRequest : ExecuteNonQueryRequest, iRequest
    {
        public JPRCDetailRequest(RJobPostRecruiterDetail jobPostDetail, string functionName, int queryType)
        {
            jobPostDetail.QueryType = queryType;
            base.ProcedureName = "tb_JobPostRecruiterDetail";
            base.ClassName = "BL_JobPostDetail";
            base.FunctionName = functionName;
            base.Param = jobPostDetail;
        }
    }


    public class RJobPostRecruiterDetail
    {
        public int QueryType { get; set; }
        public int JobPostId { get; set; }
        public int RecruiterId { get; set; }
        public int FranchiseId { get; set; }
        public int JPRCCreatedBy { get; set; }
    }


    public class JobPostWithFullDetailRequest : ExecuteNonQueryRequest, iRequest
    {
        public JobPostWithFullDetailRequest(RJobPostWithFullDetail jobPostDetail, string functionName, int queryType)
        {
            jobPostDetail.QueryType = queryType;
            base.ProcedureName = "Get_JobPostDetail";
            base.ClassName = "BL_JobPostDetail";
            base.FunctionName = functionName;
            base.Param = jobPostDetail;
        }
    }


    public class RJobPostWithFullDetail
    {
        public int QueryType { get; set; }
        public int JobPostId { get; set; }
        public int RecruiterId { get; set; }
        public int FranchiseId { get; set; }
        public int SpocAdminId { get; set; }
        public int JobPostStatus { get; set; }
        public int JPCAStatus { get; set; }
    }



}


