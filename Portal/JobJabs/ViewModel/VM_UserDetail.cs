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
    public class VM_AddNewUser
    {
        public VM_UserDetail UserDetail { get; set; }
        public FranchiseDetailList FranchiseList { get; set; }
        public int FranchiseId { get; set; }
        public string Message { get; set; }

        public VM_AddNewUser()
        {
            UserDetail = new VM_UserDetail();
            FranchiseList = new FranchiseDetailList();
            FranchiseId = 0;
            Message = "";
        }
    }

    public class VM_UserDetail
    {
        public int UserId { get; set; }

        [Display(Name = "User Name *", Description = "")]
        [Required(ErrorMessage = "Username is required")]
        [StringLength(100, MinimumLength = 0, ErrorMessage = " Username cannot exceed 100 characters.")]
        public string UserName { get; set; }

        [Display(Name = "First Name *", Description = "")]
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(100, MinimumLength = 0, ErrorMessage = " First Name cannot exceed 100 characters.")]
        public string Firstname { get; set; }

        [Display(Name = "Last Name *", Description = "")]
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(100, MinimumLength = 0, ErrorMessage = " Last Name cannot exceed 100 characters.")]
        public string Lastname { get; set; }

        [StringLength(10, MinimumLength = 0, ErrorMessage = "Mobile Number cannot be more than 10 characters.")]
        public string Phone1 { get; set; }

        [StringLength(10, MinimumLength = 0, ErrorMessage = "Alternate Mobile Number value cannot exceed 10 characters.")]
        public string Phone2 { get; set; }


        [StringLength(100, MinimumLength = 0, ErrorMessage = " Email Id cannot exceed 100 characters.")]
        public string Email { get; set; }

        public int GenderId { get; set; }
        public int UserType { get; set; }

        public static implicit operator VM_UserDetail(UserDetail model)
        {
            return new VM_UserDetail()
            {
                UserId = model.UserId,
                UserName = model.UserName,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Phone1 = model.Phone1,
                Phone2 = model.Phone2,
                Email = model.Email,
                GenderId = model.GenderId,
                UserType = model.UserType

            };
        }

        public static implicit operator UserDetail(VM_UserDetail model)
        {
            return new UserDetail()
            {
                UserId = model.UserId,
                UserName = model.UserName,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Phone1 = model.Phone1,
                Phone2 = model.Phone2,
                Email = model.Email,
                GenderId = model.GenderId,
                UserType = model.UserType
            };
        }

    }

    public class VM_UserList
    {
        public int UserType { get; set; }
        public int FranchiseId { get; set; }
        public List<UserDetail> UserList { get; set; }
        public FranchiseDetailList FranchiseList { get; set; }
        public VM_UserList()
        {
            UserList = new List<UserDetail>();
            FranchiseList = new FranchiseDetailList() { FranchiseDetail = new List<FranchiseDetail>() };
        }
    }

    public class VM_AddNewFranchise
    {
        public VM_FranchiseDetail FranchiseDetail { get; set; }
        public string Message { get; set; }

        public VM_AddNewFranchise()
        {
            FranchiseDetail = new VM_FranchiseDetail();
            Message = "";
        }
    }

    public class VM_FranchiseDetail : VM_UserDetail
    {

        public int FranchiseId { get; set; }

        [Display(Name = "Franchise Name *", Description = "")]
        [StringLength(1000, MinimumLength = 0, ErrorMessage = " Franchise Name cannot exceed 100 characters.")]
        public string FranchiseName { get; set; }


        [Display(Name = "Address *", Description = "")]
        [StringLength(1000, MinimumLength = 0, ErrorMessage = " Address cannot exceed 1000 characters.")]
        public string Address1 { get; set; }

        [StringLength(1000, MinimumLength = 0, ErrorMessage = " Address cannot exceed 1000 characters.")]
        public string Address2 { get; set; }

        [StringLength(100, MinimumLength = 0, ErrorMessage = " Location cannot exceed 100 characters.")]
        public string Area { get; set; }

        [Display(Name = "Pincode *", Description = "")]
        [StringLength(6, MinimumLength = 0, ErrorMessage = " Pincode cannot exceed 6 number.")]
        [Range(0, 999999, ErrorMessage = "Please enter valid Pincode")]
        public string Pincode { get; set; }

        [Display(Name = "City *", Description = "")]
        [StringLength(50, MinimumLength = 0, ErrorMessage = " City name cannot exceed 50 characters.")]
        public string City { get; set; }

        [Display(Name = "State *", Description = "")]
        [StringLength(50, MinimumLength = 0, ErrorMessage = " State name cannot exceed 50 characters.")]
        public string State { get; set; }


        [StringLength(10, MinimumLength = 0, ErrorMessage = "Mobile Number cannot be more than 10 characters.")]
        [Range(0, 9999999999, ErrorMessage = "Please enter valid Mobile Number")]
        public string FranchisePhone1 { get; set; }

        [StringLength(10, MinimumLength = 0, ErrorMessage = "Alternate Mobile Number value cannot exceed 10 characters.")]
        [Range(0, 9999999999, ErrorMessage = "Please enter valid Alternate Mobile Number")]
        public string FranchisePhone2 { get; set; }


        [StringLength(100, MinimumLength = 0, ErrorMessage = " Email Id cannot exceed 100 characters.")]
        public string FranchiseEmail { get; set; }



        public static implicit operator VM_FranchiseDetail(FranchiseDetail model)
        {
            return new VM_FranchiseDetail()
            {
                UserId = model.UserId,
                UserName = model.UserName,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Phone1 = model.Phone1,
                Phone2 = model.Phone2,
                Email = model.Email,
                GenderId = model.GenderId,
                UserType = model.UserType,
                FranchiseId = model.FranchiseId,
                FranchiseName = model.FranchiseName,
                Address1 = model.Address1,
                Address2 = model.Address2,
                Area = model.Area,
                Pincode = model.Pincode,
                City = model.City,
                State = model.State,
                FranchisePhone1 = model.FranchisePhone1,
                FranchisePhone2 = model.FranchisePhone2,
                FranchiseEmail = model.FranchiseEmail,

            };
        }

        public static implicit operator AddFranchiseDTO(VM_FranchiseDetail model)
        {
            return new AddFranchiseDTO()
            {
                FranchiseDetail = new FranchiseDetail()
                {
                    FranchiseId = model.FranchiseId,
                    UserId = model.UserId,
                    FranchiseName = model.FranchiseName,
                    Address1 = model.Address1,
                    Address2 = model.Address2,
                    Area = model.Area,
                    Pincode = model.Pincode,
                    City = model.City,
                    State = model.State,
                    FranchisePhone1 = model.FranchisePhone1,
                    FranchisePhone2 = model.FranchisePhone2,
                    FranchiseEmail = model.FranchiseEmail,
                },
                UserDetail = new UserDetail()
                {
                    UserId = model.UserId,
                    UserName = model.UserName,
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                    Phone1 = model.Phone1,
                    Phone2 = model.Phone2,
                    Email = model.Email,
                    GenderId = model.GenderId,
                    UserType = model.UserType
                }
            };
        }


    }

    public class VM_FranchiseList
    {
        public List<FranchiseDetail> FranchiseList { get; set; }
    }

    public class VM_AssignFranchise
    {
        public int SPOCAdminId { get; set; }
        public string SPOCAdminName { get; set; }
        public SPOCFranchiseList FranchiseList { get; set; }
        public string Message { get; set; }

        public static implicit operator VM_AssignFranchise(SPOCFranchiseList model)
        {
            return new VM_AssignFranchise()
            {
                FranchiseList = model.Franchise,
                Message = "",
                SPOCAdminId = 0
            };
        }

    }

    public class VM_ChangePassword
        {
            [Required(ErrorMessage = "Password is required")]
            [StringLength(10, ErrorMessage = "Must be between 5 and 10 characters", MinimumLength = 5)]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required(ErrorMessage = "Confirm Password is required")]
            [StringLength(10, ErrorMessage = "Must be between 5 and 10 characters", MinimumLength = 5)]
            [DataType(DataType.Password)]
            [Compare("Password")]
            public string ConfirmPassword { get; set; }
            public int DisplayType { get; set; }
        }
       

        //public class VM_ForgotPassword
        //{
        //    [Display(Name = "Mobile No *", Description = "")]
        //    [Required(ErrorMessage = " Mobile  No is required")]
        //    [Range(1, 9999999999, ErrorMessage = " Mobile No should be numeric and not exceed 10 characters.")]
        //    public string MobileNumber { get; set; }

        //    public string OTPMessage { get; set; }
        //}

        //public class VM_ValidateOTP
        //{
        //    [Display(Name = "OTP *", Description = "")]
        //    [Required(ErrorMessage = " OTP is required")]
        //    [StringLength(50, MinimumLength = 0, ErrorMessage = " OTP cannot exceed 50 characters.")]
        //    [DataType(DataType.Password)]
        //    public string OTP { get; set; }

        //    public string OTPMessage { get; set; }
        //}






    }
