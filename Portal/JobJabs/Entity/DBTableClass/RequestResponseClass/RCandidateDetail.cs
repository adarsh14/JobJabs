using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobJabs.Entity
{
    public class CandidateDetailRequest : ExecuteNonQueryRequest, iRequest
    {
        public CandidateDetailRequest(RCandidateDetail candidateDetail,string functionName, int queryType)
        {
            candidateDetail.QueryType = queryType;
            base.ProcedureName = "tb_CandidateDetail";
            base.ClassName = "BL_CandidateDetail";
            base.FunctionName = functionName;
            base.Param = candidateDetail;
        }
    }

    public class RCandidateDetail
    {
        public int QueryType { get; set; }
        public int CandidateId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string CurrentPosition { get; set; }
        public string CurrentCompany { get; set; }
        public int TotalExperienceYear { get; set; }
        public int TotalExperienceMonth { get; set; }
        public int CurrentCTCCrore { get; set; }
        public int CurrentCTCLakh { get; set; }
        public int CurrentCTCThousand { get; set; }
        public int NoticePeriod { get; set; }
        public string ResumeFileName { get; set; }
        public int CandidateStatus { get; set; }
        public int CandidateCreatedBy { get; set; }
    }

    public class JobPostCandidateDetailRequest : ExecuteNonQueryRequest, iRequest
    {
        public JobPostCandidateDetailRequest(RJobPostCandidateDetail candidateDetail, string functionName, int queryType)
        {
            candidateDetail.QueryType = queryType;
            base.ProcedureName = "tb_JobPostCandidateDetail";
            base.ClassName = "BL_CandidateDetail";
            base.FunctionName = functionName;
            base.Param = candidateDetail;
        }
    }

    public class RJobPostCandidateDetail
    {
        public int QueryType { get; set; }
        public int JPCAId { get; set; }
        public int JobPostId { get; set; }
        public int CandidateId { get; set; }
        public int RecruiterId { get; set; }
        public int FranchiseId { get; set; }
        public int JPCAStatus { get; set; }
        public int JPCACreatedBy { get; set; }
        public DateTime StatusDate { get; set; }
    }

    public class CandidateWithFullDetailRequest : ExecuteNonQueryRequest, iRequest
    {
        public CandidateWithFullDetailRequest(RCandidateWithFullDetail candidateDetail, string functionName, int queryType)
        {
            candidateDetail.QueryType = queryType;
            base.ProcedureName = "Get_CandidateDetail";
            base.ClassName = "BL_CandidateDetail";
            base.FunctionName = functionName;
            base.Param = candidateDetail;
        }
    }

    public class RCandidateWithFullDetail
    {
        public int QueryType { get; set; }
        public int JobPostId { get; set; }
        public int FranchiseId { get; set; }
        public int RecruiterId { get; set; }
        public int JPCAStatus { get; set; }
    }


    public class JPCACommentDetailRequest : ExecuteNonQueryRequest, iRequest
    {
        public JPCACommentDetailRequest(RJPCACommentDetail commentDetail, string functionName, int queryType)
        {
            commentDetail.QueryType = queryType;
            base.ProcedureName = "tb_JPCACommentDetail";
            base.ClassName = "BL_CandidateDetail";
            base.FunctionName = functionName;
            base.Param = commentDetail;
        }
    }

    public class RJPCACommentDetail
    {
        public int QueryType { get; set; }
        public int JPCACommentId { get; set; }
        public string JPCAComment { get; set; }
        public int JPCAStatus { get; set; }
       public int JPCAId { get; set; }
        public int JPCACommentCreatedBy { get; set; }
    }

}
