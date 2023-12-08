using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobJabs.Entity
{
    public class CandidateDetail
    {
        public int CandidateId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get {
                return (!string.IsNullOrEmpty(FirstName) ? FirstName : "") + " " + (!string.IsNullOrEmpty(LastName) ? LastName : "");
            }  }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string CurrentPosition { get; set; }
        public string CurrentCompany { get; set; }
        public int TotalExperienceYear { get; set; }
        public int TotalExperienceMonth { get; set; }
        public string TotalExperience
        {
            get
            {
                return (TotalExperienceYear > 35  ? "More than 35 year" 
                    : Convert.ToString(TotalExperienceYear) + " Year " + Convert.ToString(TotalExperienceMonth) + " Months");
            }
        }
        public int CurrentCTCCrore { get; set; }
        public int CurrentCTCLakh { get; set; }
        public int CurrentCTCThousand { get; set; }
        public string CurrentCTC
        {
            get
            {
                return (CurrentCTCCrore > 0 ? Convert.ToString(CurrentCTCCrore) + " Crore ": "") 
                    + Convert.ToString(CurrentCTCLakh) + " Lakhs "
                     + Convert.ToString(CurrentCTCThousand) + " Thousand" ;
            }
        }
        public int NoticePeriod { get; set; }
        public string NoticePeriodText
        {
            get
            {
                return (NoticePeriod > 90 ? "More than 90 days" : Convert.ToString(NoticePeriod) + " days");
            }
           
        }
        public string ResumeFileName { get; set; }
        public int CandidateStatus { get; set; }
        public int CandidateCreatedBy { get; set; }

        public CandidateDetail()
        {
            CandidateId = 0;
            FirstName = "";
            LastName = "";
            Location = "";
            PhoneNumber = "";
            Email = "";
            Website = "";
            CurrentPosition = "";
            CurrentCompany = "";
            TotalExperienceYear = 0;
            TotalExperienceMonth = 0;
            CurrentCTCCrore = 0;
            CurrentCTCLakh = 0;
            CurrentCTCThousand = 0;
            NoticePeriod = 0;
            ResumeFileName = "";
            CandidateStatus = 0;
            CandidateCreatedBy = 0;
        }

        public static implicit operator RCandidateDetail(CandidateDetail model)
        {
            return new RCandidateDetail()
            {
                CandidateId = model.CandidateId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Location = model.Location,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Website = model.Website,
                CurrentPosition = model.CurrentPosition,
                CurrentCompany = model.CurrentCompany,
                TotalExperienceYear = model.TotalExperienceYear,
                TotalExperienceMonth = model.TotalExperienceMonth,
                CurrentCTCCrore = model.CurrentCTCCrore,
                CurrentCTCLakh = model.CurrentCTCLakh,
                CurrentCTCThousand = model.CurrentCTCThousand,
                NoticePeriod = model.NoticePeriod,
                ResumeFileName = model.ResumeFileName,
                CandidateStatus = model.CandidateStatus,
                CandidateCreatedBy = model.CandidateCreatedBy
            };
        }

    }

    public class CandidateDetailList
    {
        public List<CandidateDetail> CandidateDetail { get; set; }
        public List<CustomDropDown> CandidateDropDown
        {
            get
            {
                return (CandidateDetail != null ?
                        (from a in CandidateDetail
                         select new CustomDropDown()
                         {
                             Value = a.CandidateId,
                             Text = a.FirstName
                         }).ToList() : new List<CustomDropDown>()
                    );
            }
        }


        public static implicit operator CandidateDetailList(List<CandidateDetail> model)
        {
            model = (model == null ? new List<CandidateDetail>() : model);
            return new CandidateDetailList()
            {
                CandidateDetail = model
            };
        }
    }

    public class JobPostCandidateDetail : CandidateDetail
    {
        public int JPCAId { get; set; }
        public int JobPostId { get; set; }
        public int RecruiterId { get; set; }
        public string RecruiterName { get; set; }
        public int FranchiseId { get; set; }
        public string FranchiseName { get; set; }
        public int JPCAStatus { get; set; }
        public int JPCACreatedBy { get; set; }
        public DateTime StatusDate { get; set; }
        public string JPCLink
        {
            get
            {
                return ("jpid=" + JobPostId + "&cid=" + CandidateId + "&rid=" + RecruiterId + "&fid=" + FranchiseId);
            }
        }

        public JobPostCandidateDetail()
        {
            JobPostId = 0;
            CandidateId = 0;
            RecruiterId = 0;
            FranchiseId = 0;
            JPCAStatus = 0;
            JPCACreatedBy = 0;
            StatusDate= DateTime.Now;
        }

        public static implicit operator RJobPostCandidateDetail(JobPostCandidateDetail model)
        {
            return new RJobPostCandidateDetail()
            {
                JPCAId=model.JPCAId,
                JobPostId = model.JobPostId,
                CandidateId = model.CandidateId,
                RecruiterId = model.RecruiterId,
                FranchiseId = model.FranchiseId,
                JPCAStatus = model.JPCAStatus,
                JPCACreatedBy = model.JPCACreatedBy,
                StatusDate=model.StatusDate
            };
        }

        public static implicit operator RCandidateWithFullDetail(JobPostCandidateDetail model)
        {
            return new RCandidateWithFullDetail()
            {
                JobPostId = model.JobPostId,
                RecruiterId = model.RecruiterId,
                FranchiseId = model.FranchiseId,
                JPCAStatus = model.JPCAStatus
            };
        }
    }

    public class JPCandidateDetailList
    {
        public List<JobPostCandidateDetail> CandidateDetail { get; set; }
        public List<CustomDropDown> CandidateDropDown
        {
            get
            {
                return (CandidateDetail != null ?
                        (from a in CandidateDetail
                         select new CustomDropDown()
                         {
                             Value = a.CandidateId,
                             Text = a.FirstName
                         }).ToList() : new List<CustomDropDown>()
                    );
            }
        }


        public static implicit operator JPCandidateDetailList(List<JobPostCandidateDetail> model)
        {
            model = (model == null ? new List<JobPostCandidateDetail>() : model);
            return new JPCandidateDetailList()
            {
                CandidateDetail = model
            };
        }
    }

    public class JPCACommentDetail
    {
        public int JPCACommentId { get; set; }
        public string JPCAComment { get; set; }
        public int JPCAStatus { get; set; }
        public int JPCAId { get; set; }
        public int JPCACreatedBy { get; set; }

        public JPCACommentDetail()
        {
            JPCACommentId = 0;
            JPCAComment = "";
            JPCAStatus = 0;
            JPCAId = 0;
            JPCACreatedBy = 0;
        }
        
        public static implicit operator RJPCACommentDetail(JPCACommentDetail model)
        {
            return new RJPCACommentDetail()
            {
                JPCACommentId = model.JPCACommentId,
                JPCAComment = model.JPCAComment,
                JPCAStatus = model.JPCAStatus,
                JPCAId =model.JPCAId,
                JPCACommentCreatedBy = model.JPCACreatedBy 
            };
        }

    }

    public class JPCASessionDetail
    {
        public int JobPostId { get; set; }
        public int RecruiterId { get; set; }
        public int FranchiseId { get; set; }
        public int JPCAStatus { get; set; }
        public string JobTitle { get; set; }
    }

}
