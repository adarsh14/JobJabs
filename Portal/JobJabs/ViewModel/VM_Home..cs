using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using JobJabs.Entity;

namespace JobJabs.ViewModel
{

    public class VM_Home
    {
        public JobPostList JobPostList { get; set; }
        public int StepNo { get; set; }
        public VM_MailMsg MailMsg { get; set; }

        public VM_Home()
        {
            JobPostList = new JobPostList();
            MailMsg = new VM_MailMsg(); 
        }
    }

    public class VM_FranchiseEnquiry
    {
        public int StepNo { get; set; }
        public VM_MailMsg MailMsg { get; set; }
    }


    public class VM_MailMsg
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Contact Number is required")]
        public string ContactNumber { get; set; }
        [Required(ErrorMessage = "Subject is required")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        [Required(ErrorMessage = "Body is required")]
        public string Body { get; set; }

        public static implicit operator MailMsg(VM_MailMsg model)
        {
            return new MailMsg()
            {
               Name =model.Name ,
                Email =model.Email ,
                ContactNumber =model.ContactNumber ,
                 Subject =model.Subject ,
                  State =model.State,
                   City =model.City,
                  Body =model.Body 
            };
        }
    }

   
}
