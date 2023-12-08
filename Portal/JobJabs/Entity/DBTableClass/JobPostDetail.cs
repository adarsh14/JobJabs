using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobJabs.Entity
{
    public class JobPostDetail
    {
        public int JobPostId { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int ClientLocationId { get; set; }
        public string ClientLocation { get; set; }
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
        public DateTime JPCreatedOn { get; set; }
        public DateTime JPUpdatedOn { get; set; }
        public FranchiseDetailList FranchiseList { get; set; }
        public JobPostDetail()
        {
            JobPostId = 0;
            ClientId = 0;
            ClientName = "";
            ClientLocationId = 0;
            ClientLocation = "";
            JobTitle = "";
            JobLocation = "";
            JobCTC = "";
            CompanyDescription = "";
            JobDescription = "";
            Qualification = "";
            AdditionalInformation = "";
            Industry = "";
            IndustryId = 0;
            Functional = "";
            FunctionalId = 0;
            ExperienceLevel = 0;
            TypeOfEmployment = 0;
            JDFileName = "";
            ChecklistFileName = "";
            JobPostStatus = 0;
            JPCreatedBy = 0;
            FranchiseList = new FranchiseDetailList();
            
        }

        public static implicit operator RJobPostDetail(JobPostDetail model)
        {
            return new RJobPostDetail()
            {
                JobPostId = model.JobPostId,
                ClientId = model.ClientId,
                ClientLocationId = model.ClientLocationId,
                JobTitle = model.JobTitle,
                JobLocation = model.JobLocation,
                JobCTC = model.JobCTC,
                CompanyDescription = model.CompanyDescription,
                JobDescription = model.JobDescription,
                Qualification = model.Qualification,
                AdditionalInformation = model.AdditionalInformation,
                Industry = model.Industry,
                IndustryId = model.IndustryId,
                Functional = model.Functional,
                FunctionalId = model.FunctionalId,
                ExperienceLevel = model.ExperienceLevel,
                TypeOfEmployment = model.TypeOfEmployment,
                JDFileName = model.JDFileName,
                ChecklistFileName = model.ChecklistFileName,
                JobPostStatus = model.JobPostStatus,
                JPCreatedBy = model.JPCreatedBy
            };
        }
    }

    public class JobPostList
    {
        public List<JobPostDetail> JobPost { get; set; }
        public List<CustomDropDown> JobPostDropDown
        {
            get
            {
                return (JobPost != null ?
                        (from a in JobPost
                         select new CustomDropDown()
                         {
                             Value = a.JobPostId,
                             Text = a.JobTitle
                         }).ToList() : new List<CustomDropDown>()
                    );
            }
        }


        public static implicit operator JobPostList(List<JobPostDetail> model)
        {
            model = (model == null ? new List<JobPostDetail>() : model);
            return new JobPostList()
            {
                JobPost = model
            };
        }

        public JobPostList()
        {
            JobPost = new List<JobPostDetail>();
        }
    }


    public class JobPostFranchiseDetail
    {
        public int JobPostId { get; set; }
        public int FranchiseId { get; set; }
        public string FranchiseName { get; set; }
        public int SPOCAdminId { get; set; }
        public int JPFAStatus { get; set; }
        public int JPFACreatedBy { get; set; }
        public bool Checked { get; set; }
        public JobPostFranchiseDetail()
        {
            FranchiseId = 0;
            FranchiseName = "";
            JobPostId = 0;
            JPFAStatus = 0;
            JPFACreatedBy = 0;
        }

        public static implicit operator RJobPostFranchiseDetail(JobPostFranchiseDetail model)
        {
            return new RJobPostFranchiseDetail()
            {
                JobPostId = model.JobPostId,
                FranchiseId = model.FranchiseId,
                SPOCAdminId=model.SPOCAdminId,
                JPFACreatedBy = model.JPFACreatedBy,
            };
        }
    }

    public class JobPostFranchiseList
    {
        public List<JobPostFranchiseDetail> Franchise { get; set; }
        public List<CustomDropDown> JPFranchiseDropDown
        {
            get
            {
                return (Franchise != null ?
                        (from a in Franchise
                         select new CustomDropDown()
                         {
                             Value = a.FranchiseId,
                             Text = a.FranchiseName
                         }).ToList() : new List<CustomDropDown>()
                    );
            }
        }

        public List<CheckModel> JPFranchiseCheckBox
        {
            get
            {
                return (Franchise != null ?
                        (from a in Franchise
                         select new CheckModel()
                         {
                             Id = a.FranchiseId,
                             Name = a.FranchiseName,
                             Checked = a.Checked
                         }).ToList() : new List<CheckModel>()
                    );
            }
        }

        public static implicit operator JobPostFranchiseList(List<JobPostFranchiseDetail> model)
        {
            model = (model == null ? new List<JobPostFranchiseDetail>() : model);
            return new JobPostFranchiseList()
            {
                Franchise = model
            };
        }
    }

    public class JobPostRecruiterDetail:UserDetail
    {
        public int JobPostId { get; set; }
        public int FranchiseId { get; set; }
        public int JPRCStatus { get; set; }
        public int JPRCCreatedBy { get; set; }
        public bool Checked { get; set; }

        public JobPostRecruiterDetail()
        {
            FranchiseId = 0;
            JobPostId = 0;
            JPRCStatus = 0;
            JPRCCreatedBy = 0;
        }

        public static implicit operator RJobPostRecruiterDetail(JobPostRecruiterDetail model)
        {
            return new RJobPostRecruiterDetail()
            {
                JobPostId = model.JobPostId,
                RecruiterId = model.UserId,
                FranchiseId = model.FranchiseId,
                JPRCCreatedBy = model.JPRCCreatedBy
            };
        }
    }

    public class JobPostRecruiterList
    {
        public List<JobPostRecruiterDetail> Recruiter { get; set; }
        public List<CustomDropDown> RecruiterDropDown
        {
            get
            {
                return (Recruiter != null ?
                        (from a in Recruiter
                         select new CustomDropDown()
                         {
                             Value = a.UserId,
                             Text = a.FullName
                         }).ToList() : new List<CustomDropDown>()
                    );
            }
        }

        public List<CheckModel> RecruiterCheckBox
        {
            get
            {
                return (Recruiter != null ?
                        (from a in Recruiter
                         select new CheckModel()
                         {
                             Id = a.UserId,
                             Name = a.FullName,
                             Checked = a.Checked
                         }).ToList() : new List<CheckModel>()
                    );
            }
        }

        public static implicit operator JobPostRecruiterList(List<JobPostRecruiterDetail> model)
        {
            model = (model == null ? new List<JobPostRecruiterDetail>() : model);
            return new JobPostRecruiterList()
            {
                Recruiter = model
            };
        }
    }

    public class JobPostWithFullDetail:JobPostDetail
    {
        public string JPLink
        {
            get
            {
                return ("jpid=" + JobPostId + "&title=" + (!string.IsNullOrEmpty(JobTitle) ? JobTitle.Replace("&", "_").Replace(" ", "-") : ""));
            }
        }
        public List<JPWiseCandidateDetail> CandidateList { get; set; }
        public JobPostWithFullDetail()
        {
            CandidateList = new List<JPWiseCandidateDetail>();
        }

    }

  
    public class JPWiseCandidateDetail 
    {
        public int SpocAdminId { get; set; }
        public int FranchiseId { get; set; }
        public string FranchiseName { get; set; }
        public int RecruiterId { get; set; }
        public string RecruiterName { get; set; }
        public int CandidateCount { get; set; }
    }

    public class GetJobPostDetail
    {
        public int SpocAdminId { get; set; }
        public int FranchiseId { get; set; }
        public int RecruiterId { get; set; }
        public int JobPostId { get; set; }
        public int JobPostStatus { get; set; }
        public int JPCAStatus { get; set; }

        public static implicit operator RJobPostWithFullDetail(GetJobPostDetail model)
        {
            return new RJobPostWithFullDetail()
            {
                JobPostId = model.JobPostId,
                FranchiseId = model.FranchiseId,
                JobPostStatus = model.JobPostStatus,
                RecruiterId = model.RecruiterId,
                SpocAdminId = model.SpocAdminId,
                JPCAStatus=model.JPCAStatus
            };
        }

    }

    public class JPCAStatusDetail
    {
     
        public int CandidateAssigned { get; set; }
        public DateTime CandidateAssignedDate { get; set; }
        public int ValidatedBySPOC { get; set; }
        public DateTime ValidatedBySPOCDate { get; set; }
        public int CandidateRejectedBySPOC { get; set; }
        public DateTime CandidateRejectedBySPOCDate { get; set; }
        public int ResumeSentToHR { get; set; }
        public DateTime ResumeSentToHRDate { get; set; }
        public int InterviewScheduled { get; set; }
        public DateTime InterviewScheduledDate { get; set; }
        public int SecondRoundSheduled { get; set; }
        public DateTime SecondRoundSheduledDate { get; set; }
        public int FinalRoundScheduled { get; set; }
        public DateTime FinalRoundScheduledDate { get; set; }
        public int InterviewRejected { get; set; }
        public DateTime InterviewRejectedDate { get; set; }
        public int CandidateShortlisted { get; set; }
        public DateTime CandidateShortlistedDate { get; set; }
        public int CandidateSelected { get; set; }
        public DateTime CandidateSelectedDate { get; set; }
        public int DocumentationPending { get; set; }
        public DateTime DocumentationPendingDate { get; set; }
        public int CandidateJoined { get; set; }
        public DateTime CandidateJoinedDate { get; set; }
        public int CandidateNotJoined { get; set; }
        public DateTime CandidateNotJoinedDate { get; set; }
        public int CandidateBackOut { get; set; }
        public DateTime CandidateBackOutDate { get; set; }

        public JPCAStatusDetail()
        {
            CandidateAssigned = 0;
            CandidateAssignedDate = DateTime.Now;
            ValidatedBySPOC = 0;
            ValidatedBySPOCDate = DateTime.Now;
            CandidateRejectedBySPOC = 0;
            CandidateRejectedBySPOCDate = DateTime.Now;
            ResumeSentToHR = 0;
            ResumeSentToHRDate = DateTime.Now;
            InterviewScheduled = 0;
            InterviewScheduledDate = DateTime.Now;
            SecondRoundSheduled = 0;
            SecondRoundSheduledDate = DateTime.Now;
            FinalRoundScheduled = 0;
            FinalRoundScheduledDate = DateTime.Now;
            InterviewRejected = 0;
            InterviewRejectedDate = DateTime.Now;
            CandidateShortlisted = 0;
            CandidateShortlistedDate = DateTime.Now;
            CandidateSelected = 0;
            CandidateSelectedDate = DateTime.Now;
            DocumentationPending = 0;
            DocumentationPendingDate = DateTime.Now;
            CandidateJoined = 0;
            CandidateJoinedDate = DateTime.Now;
            CandidateNotJoined = 0;
            CandidateNotJoinedDate = DateTime.Now;
            CandidateBackOut = 0;
            CandidateBackOutDate = DateTime.Now;
        }

    }
}
