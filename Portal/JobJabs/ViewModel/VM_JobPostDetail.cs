using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using JobJabs.Entity;
using System.Web;

namespace JobJabs.ViewModel
{

    public class VM_JobPostList
    {
        public List<JobPostDetail> JobPostList { get; set; }
        public int Status { get; set; }
        public static implicit operator VM_JobPostList(List<JobPostDetail> model)
        {
            return new VM_JobPostList()
            {
                JobPostList = model
            };
        }

        public VM_JobPostList()
        {
            JobPostList = new List<JobPostDetail>();
        }
    }

    public class VM_JobPostFullDetailList
    {
        public List<JobPostWithFullDetail> JobPostList { get; set; }
        public DDLList CandidateStatus { get; set; }
        public int Status { get; set; }
        public string StatusText { get; set; }
        public static implicit operator VM_JobPostFullDetailList(List<JobPostWithFullDetail> model)
        {
            return new VM_JobPostFullDetailList()
            {
                JobPostList = model
            };
        }
        public VM_JobPostFullDetailList()
        {
            JobPostList = new List<JobPostWithFullDetail>();
        }
    }

    public class VM_AddJobPost
    {
        public VM_JobPosting JobPost { get; set; }
        public CompanyDetailList CompanyList { get; set; }
        public CompanyLocationList CompLocList { get; set; }
        public ExperienceLevelDetailList ExperienceLevel { get; set; }
        public EmploymentTypeDetailList EmploymentType { get; set; }
        public HttpPostedFileBase JDFile { get; set; }
        public HttpPostedFileBase ChecklistFile { get; set; }
        public string Message { get; set; }

        public VM_AddJobPost()
        {
            JobPost = new VM_JobPosting();
            CompanyList = new List<CompanyDetail>();
            CompLocList = new List<CompanyLocationDetail>();
            ExperienceLevel = new ExperienceLevelDetailList();
            EmploymentType = new EmploymentTypeDetailList();
            Message = "";
        }
    }

    public class VM_JobPosting
    {
        public int JobPostId { get; set; }

        [Display(Name = "Client*", Description = "")]
        [Required(ErrorMessage = " Client is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select Client")]
        public int ClientId { get; set; }

        [Display(Name = "Client Location*", Description = "")]
        [Required(ErrorMessage = " Client Location is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select Client Location")]
        public int ClientLocationId { get; set; }

        [Display(Name = "Job Title*", Description = "")]
        [Required(ErrorMessage = " Job Title is required")]
        [StringLength(250, MinimumLength = 0, ErrorMessage = "Job Title cannot exceed 250 characters.")]
        public string JobTitle { get; set; }

        [Display(Name = "Job Location*", Description = "")]
        [Required(ErrorMessage = " Job Location is required")]
        [StringLength(250, MinimumLength = 0, ErrorMessage = "Job Location cannot exceed 250 characters.")]
        public string JobLocation { get; set; }

        [Display(Name = "Job CTC*", Description = "")]
        [Required(ErrorMessage = " Job CTC is required")]
        [StringLength(250, MinimumLength = 0, ErrorMessage = "CTC cannot exceed 100 characters.")]
        public string JobCTC { get; set; }

        [Display(Name = "Company Description", Description = "")]
        public string CompanyDescription { get; set; }

        [Display(Name = "Job Description", Description = "")]
        public string JobDescription { get; set; }

        [Display(Name = "Qualification", Description = "")]
        public string Qualification { get; set; }

        [Display(Name = "Additional Information", Description = "")]
        public string AdditionalInformation { get; set; }

        [Display(Name = "Industry*", Description = "")]
        [Required(ErrorMessage = " Industry is required")]
        [StringLength(250, MinimumLength = 0, ErrorMessage = "Industry cannot exceed 250 characters.")]
        public string Industry { get; set; }


        public int IndustryId { get; set; }

        [Display(Name = "Function*", Description = "")]
        [Required(ErrorMessage = " Function is required")]
        [StringLength(250, MinimumLength = 0, ErrorMessage = "Function cannot exceed 250 characters.")]
        public string Functional { get; set; }


        public int FunctionalId { get; set; }

        [Display(Name = "Experience Level*", Description = "")]
        [Required(ErrorMessage = " Experience Level is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select Experience Level")]
        public int ExperienceLevel { get; set; }

        [Display(Name = "Type Of Employment", Description = "")]
        [Required(ErrorMessage = " Type Of Employment is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select Type Of Employment")]
        public int TypeOfEmployment { get; set; }

        [Display(Name = "Attach JD", Description = "")]
        [Required(ErrorMessage = " Please attach JD File")]
        public string JDFileName { get; set; }

        [Display(Name = "Attach Checklist", Description = "")]
        [Required(ErrorMessage = " Please attach Checklist File")]
        public string ChecklistFileName { get; set; }

        public int JobPostStatus { get; set; }
        public int CreatedBy { get; set; }

        public static implicit operator JobPostDetail(VM_JobPosting model)
        {
            return new JobPostDetail()
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
                ChecklistFileName = model.ChecklistFileName
            };
        }

        public static implicit operator VM_JobPosting(JobPostDetail model)
        {
            return new VM_JobPosting()
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
                ChecklistFileName = model.ChecklistFileName
            };
        }
    }

    public class VM_AssignJobPostToFranchise
    {
        public int JobPostId { get; set; }
        public string Title { get; set; }
        public JobPostFranchiseList FranchiseList { get; set; }
        public string Message { get; set; }

        public static implicit operator VM_AssignJobPostToFranchise(JobPostFranchiseList model)
        {
            return new VM_AssignJobPostToFranchise()
            {
                FranchiseList = model.Franchise,
                Message = "",
                JobPostId = 0
            };
        }

    }

    public class VM_AssignJobPostToRecruiter
    {
        public int JobPostId { get; set; }
        public string Title { get; set; }
        public int FranchiseId { get; set; }
        public JobPostRecruiterList RecruiterList { get; set; }
        public string Message { get; set; }

        public static implicit operator VM_AssignJobPostToRecruiter(JobPostRecruiterList model)
        {
            return new VM_AssignJobPostToRecruiter()
            {
                RecruiterList = model.Recruiter,
                Message = "",
                JobPostId = 0
            };
        }

    }

    public class VM_JPCACommentDetail{

      public  List<JPCACommentDetail> Comments { get; set; }

        public static implicit operator VM_JPCACommentDetail(List<JPCACommentDetail> model)
        {
            return new VM_JPCACommentDetail()
            {
               Comments=model
            };
        }

    }
}
