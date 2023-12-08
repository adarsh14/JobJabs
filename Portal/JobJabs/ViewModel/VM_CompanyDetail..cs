using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;
using JobJabs.Entity;



namespace JobJabs.ViewModel
{

    public class VM_AddNewCompany
    {
        public VM_CompanyDetail CompanyDetail { get; set; }
        public string Message { get; set; }

        public VM_AddNewCompany()
        {
            CompanyDetail = new VM_CompanyDetail();
            Message = "";
        }
    }

    public class VM_CompanyDetail
    {

        public int CompanyId { get; set; }

        [Display(Name = "Company Name *", Description = "")]
        [StringLength(1000, MinimumLength = 0, ErrorMessage = " Company Name cannot exceed 100 characters.")]
        public string CompanyName { get; set; }


        [Display(Name = "Address *", Description = "")]
        [StringLength(1000, MinimumLength = 0, ErrorMessage = " Address cannot exceed 1000 characters.")]
        public string Address1 { get; set; }


        [StringLength(1000, MinimumLength = 0, ErrorMessage = " Address cannot exceed 1000 characters.")]
        public string Address2 { get; set; }

        [StringLength(100, MinimumLength = 0, ErrorMessage = " Location cannot exceed 100 characters.")]
        public string Area { get; set; }

        [Display(Name = "Pincode *", Description = "")]
        [StringLength(6, MinimumLength = 0, ErrorMessage = " Pincode cannot exceed 6 characters.")]
        public string Pincode { get; set; }

        [Display(Name = "City *", Description = "")]
        [StringLength(50, MinimumLength = 0, ErrorMessage = " City name cannot exceed 50 characters.")]
        public string City { get; set; }

        [Display(Name = "State *", Description = "")]
        [StringLength(50, MinimumLength = 0, ErrorMessage = " State name cannot exceed 50 characters.")]
        public string State { get; set; }


        [StringLength(10, MinimumLength = 0, ErrorMessage = "Mobile Number cannot be more than 10 characters.")]
        public string CompanyPhone1 { get; set; }

        [StringLength(10, MinimumLength = 0, ErrorMessage = "Alternate Mobile Number value cannot exceed 10 characters.")]
        public string CompanyPhone2 { get; set; }


        [StringLength(100, MinimumLength = 0, ErrorMessage = " Email Id cannot exceed 100 characters.")]
        public string CompanyEmail { get; set; }



        public static implicit operator VM_CompanyDetail(CompanyDetail model)
        {
            return new VM_CompanyDetail()
            {
                CompanyId = model.CompanyId,
                CompanyName = model.CompanyName,
                Address1 = model.Address1,
                Address2 = model.Address2,
                Area = model.Area,
                Pincode = model.Pincode,
                City = model.City,
                State = model.State,
                CompanyPhone1 = model.CompanyPhone1,
                CompanyPhone2 = model.CompanyPhone2,
                CompanyEmail = model.CompanyEmail,

            };
        }

        public static implicit operator CompanyDetail(VM_CompanyDetail model)
        {
            return new CompanyDetail()
            {
                CompanyId = model.CompanyId,
                CompanyName = model.CompanyName,
                Address1 = model.Address1,
                Address2 = model.Address2,
                Area = model.Area,
                Pincode = model.Pincode,
                City = model.City,
                State = model.State,
                CompanyPhone1 = model.CompanyPhone1,
                CompanyPhone2 = model.CompanyPhone2,
                CompanyEmail = model.CompanyEmail
            };
        }


    }

    public class VM_CompanyList
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public List<CompanyDetail> CompanyList { get; set; }

        public static implicit operator CompanyDetail(VM_CompanyList model)
        {
            return new CompanyDetail()
            {
                 CompanyId=model.CompanyId
            };
         }
    }


    public class VM_AddNewCompanyLocation
    {
        public string CompanyName { get; set; }
        public VM_CompanyLocationDetail CompLocDetail { get; set; }
        public string Message { get; set; }

        public VM_AddNewCompanyLocation()
        {
            CompLocDetail = new VM_CompanyLocationDetail();
            Message = "";
        }
    }

    public class VM_CompanyLocationDetail
    {

        public int CompanyId { get; set; }
        public int CompLocId { get; set; }

        [Display(Name = "Location *", Description = "")]
        [StringLength(150, MinimumLength = 0, ErrorMessage = " Location cannot exceed 150 characters.")]
        public string Location { get; set; }

        [Display(Name = "HR Name *", Description = "")]
        [StringLength(150, MinimumLength = 0, ErrorMessage = " HR Name cannot exceed 150 characters.")]
        public string HRName { get; set; }

        [Display(Name = "DOB", Description = "")]
        [StringLength(10, MinimumLength = 0, ErrorMessage = " DOB cannot exceed 15 characters.")]
        public string DOB { get; set; }

        [Display(Name = "Address *", Description = "")]
        [StringLength(1000, MinimumLength = 0, ErrorMessage = " Address cannot exceed 1000 characters.")]
        public string Address1 { get; set; }


        [StringLength(1000, MinimumLength = 0, ErrorMessage = " Address cannot exceed 1000 characters.")]
        public string Address2 { get; set; }

        [StringLength(100, MinimumLength = 0, ErrorMessage = " Location cannot exceed 100 characters.")]
        public string Area { get; set; }

        [Display(Name = "Pincode *", Description = "")]
        [StringLength(6, MinimumLength = 0, ErrorMessage = " Pincode cannot exceed 6 characters.")]
        public string Pincode { get; set; }

        [Display(Name = "City *", Description = "")]
        [StringLength(50, MinimumLength = 0, ErrorMessage = " City name cannot exceed 50 characters.")]
        public string City { get; set; }

        [Display(Name = "State *", Description = "")]
        [StringLength(50, MinimumLength = 0, ErrorMessage = " State name cannot exceed 50 characters.")]
        public string State { get; set; }


        [StringLength(10, MinimumLength = 0, ErrorMessage = "Mobile Number cannot be more than 10 characters.")]
        public string CompLocPhone1 { get; set; }

        [StringLength(10, MinimumLength = 0, ErrorMessage = "Alternate Mobile Number value cannot exceed 10 characters.")]
        public string CompLocPhone2 { get; set; }


        [StringLength(100, MinimumLength = 0, ErrorMessage = " Email Id cannot exceed 100 characters.")]
        public string CompLocEmail { get; set; }



        public static implicit operator VM_CompanyLocationDetail(CompanyLocationDetail model)
        {
            return new VM_CompanyLocationDetail()
            {
                CompLocId = model.CompLocId,
                CompanyId = model.CompanyId,
                Location = model.LocationName,
                HRName = model.HRName,
                DOB = model.DOB.ToString(),
                CompLocPhone1 = model.CompLocPhone1,
                CompLocPhone2 = model.CompLocPhone2,
                CompLocEmail = model.CompLocEmail,
                Address1 = model.CompLocAddress1,
                Address2 = model.CompLocAddress2,
                Area = model.CompLocArea,
                Pincode = model.CompLocPincode,
                City = model.CompLocCity,
                State = model.CompLocState,
            };
        }

        public static implicit operator CompanyLocationDetail(VM_CompanyLocationDetail model)
        {
            return new CompanyLocationDetail()
            {
                CompLocId = model.CompLocId,
                CompanyId = model.CompanyId,
                LocationName = model.Location,
                HRName = model.HRName,
                DOB = Convert.ToDateTime((model.DOB==null ? DateTime.Now.ToString() :model.DOB)),
                CompLocPhone1 = model.CompLocPhone1,
                CompLocPhone2 = model.CompLocPhone2,
                CompLocEmail = model.CompLocEmail,
                CompLocAddress1 = model.Address1,
                CompLocAddress2 = model.Address2,
                CompLocArea = model.Area,
                CompLocPincode = model.Pincode,
                CompLocCity = model.City,
                CompLocState = model.State,
            };
        }


    }

    public class VM_CompanyLocationList
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public List<CompanyLocationDetail> CompLocList { get; set; }

        public static implicit operator CompanyLocationDetail(VM_CompanyLocationList model)
        {
            return new CompanyLocationDetail()
            {
                CompanyId = model.CompanyId
            };
        }
    }
}
