using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using JobJabs.Entity;
using System.Web;

namespace JobJabs.ViewModel
{

    public class VM_CandidateList
    {
        public JPCandidateDetailList CandidateList { get; set; }
        public DDLList CandidateStatus { get; set; }
        public int JobPostId { get; set; }
        public string JobTitle { get; set; }
        public string JPLink
        {
            get
            {
                return ("jpid=" + JobPostId + "&title=" + CommonClass.ConvertTitle(JobTitle));
            }
        }
        public int Status { get; set; }
        public string JPCADate { get; set; }

        public VM_CandidateList()
        {
            CandidateList = new JPCandidateDetailList();
            JobPostId = 0;
            JobTitle = "";
            Status = 0;
        }

        public static implicit operator VM_CandidateList(List<JobPostCandidateDetail> model)
        {
            return new VM_CandidateList()
            {
                CandidateList = model,
            };
        }
    }

    public class VM_AddCandidate
    {
        public VM_CandidateDetail CandidateDetail { get; set; }
        public DDLList TotalExperienceYear { get; set; }
        public DDLList TotalExperienceMonth { get; set; }
        public DDLList CTCCrore { get; set; }
        public DDLList CTCLakh { get; set; }
        public DDLList CTCThousand { get; set; }
        public DDLList NoticePeriod { get; set; }
        public HttpPostedFileBase ResumeFile { get; set; }
        public string Message { get; set; }
        public int JobPostId { get; set; }
        public string Title { get; set; }

        public VM_AddCandidate()
        {
            CandidateDetail = new VM_CandidateDetail();
            TotalExperienceYear = new DDLList(); 
            TotalExperienceMonth = new DDLList();
            CTCCrore = new DDLList();
            CTCLakh = new DDLList();
            CTCThousand = new DDLList();
            NoticePeriod = new DDLList();
            Message = "";
            JobPostId = 0;
            Title = "";
        }
    }

    public class VM_CandidateDetail
    {
        public int CandidateId { get; set; }

        [Display(Name = "First Name*", Description = "")]
        [Required(ErrorMessage = " First Name is required")]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "FirstName cannot exceed 100 characters.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name*", Description = "")]
        [Required(ErrorMessage = " Last Name is required")]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "LastName cannot exceed 100 characters.")]
        public string LastName { get; set; }

        [Display(Name = "Location", Description = "")]
        [Required(ErrorMessage = " Location is required")]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "Location cannot exceed 50 characters.")]
        public string Location { get; set; }

        [Display(Name = "Contact Number*", Description = "")]
        [Required(ErrorMessage = " Contact Number is required")]
        [StringLength(10, MinimumLength = 0, ErrorMessage = "Mobile Number cannot exceed 10 characters.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email*", Description = "")]
        [Required(ErrorMessage = " Email is required")]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "Email cannot exceed 50 characters.")]
        public string Email { get; set; }

        [Display(Name = "Website or Social Network", Description = "")]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "Website  or Social Network cannot exceed 100 characters.")]
        public string Website { get; set; }

        [Display(Name = "Current Position", Description = "")]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "Current Position cannot exceed 100 characters.")]
        public string CurrentPosition { get; set; }

        [Display(Name = "Current Company", Description = "")]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "Current Company cannot exceed 100 characters.")]
        public string CurrentCompany { get; set; }

        [Display(Name = "Year", Description = "")]
        [Required(ErrorMessage = " Please select Year")]
        public int? TotalExperienceYear { get; set; }

        [Display(Name = "Month", Description = "")]
        [Required(ErrorMessage = " Please select Month")]
        public int? TotalExperienceMonth { get; set; }

        [Display(Name = "Corer", Description = "")]
        [Required(ErrorMessage = " Please select CTC")]
        public int? CurrentCTCCrore { get; set; }

        [Display(Name = "CTCLakh", Description = "")]
        [Required(ErrorMessage = " Please select CTC")]
        public int? CurrentCTCLakh { get; set; }

        [Display(Name = "CTCThousand", Description = "")]
        [Required(ErrorMessage = " Please select CTC")]
        public int? CurrentCTCThousand { get; set; }

        [Display(Name = "Notice Period", Description = "")]
        [Required(ErrorMessage = " Please select Notice Period")]
        public int? NoticePeriod { get; set; }

        [Display(Name = "Attach Resume", Description = "")]
        [Required(ErrorMessage = " Please attach Resume")]
        public string ResumeFileName { get; set; }

        public int CandidateStatus { get; set; }


        public VM_CandidateDetail()
        {
            TotalExperienceYear = null;
        }

        public static implicit operator CandidateDetail(VM_CandidateDetail model)
        {
            return new CandidateDetail()
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
               TotalExperienceYear = model.TotalExperienceYear.Value,
                TotalExperienceMonth = model.TotalExperienceMonth.Value,
                CurrentCTCCrore = model.CurrentCTCCrore.Value,
                CurrentCTCLakh = model.CurrentCTCLakh.Value,
                CurrentCTCThousand = model.CurrentCTCThousand.Value,
                NoticePeriod = model.NoticePeriod.Value
            };
        }

        public static implicit operator VM_CandidateDetail(CandidateDetail model)
        {
            return new VM_CandidateDetail()
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
                NoticePeriod = model.NoticePeriod
            };
        }

    }


}
