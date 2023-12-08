using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using JobJabs.Entity;

namespace JobJabs.Entity
{

    public class UserDetail : Login
    {
        public int UserId { get; set; }
        public string FullName
        {
            get
            {
                return (!string.IsNullOrEmpty(Firstname) ? Firstname : "") + " " + (!string.IsNullOrEmpty(Lastname) ? Lastname : "");
            }
        }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public int GenderId { get; set; }
        public int UserType { get; set; }
        public int IsPasswordValidated { get; set; }
        public int TotalAssignedFranchise { get; set; }
        public int Status { get; set; }
        public int CreatedBy { get; set; }

        public UserDetail()
        {
            UserId = 0;
            Firstname = "";
            Lastname = "";
            Phone1 = "";
            Phone2 = "";
            Email = "";
            GenderId = 0;
            UserType = 0;
            IsPasswordValidated = 0;
            Status = 0;
            CreatedBy = 0;
        }

        public static implicit operator RUserDetail(UserDetail model)
        {
            model = (model == null ? new UserDetail() : model);
            return new RUserDetail()
            {
                UserId = model.UserId,
                UserName = model.UserName,
                Password = model.EncryptedPassword,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Phone1 = model.Phone1,
                Phone2 = model.Phone2,
                Email = model.Email,
                GenderId = model.GenderId,
                UserType = model.UserType,
                IsPasswordValidated = model.IsPasswordValidated,
                Status = model.Status,
                CreatedBy = model.CreatedBy
            };
        }

    }

    public class UserDetailList
    {
        public List<UserDetail> UserDetail { get; set; }
        public List<CustomDropDown> UserDetailDropDown
        {
            get
            {
                return (UserDetail != null ?
                        (from a in UserDetail
                         select new CustomDropDown()
                         {
                             Value = a.UserId,
                             Text = a.Firstname + " " + a.Lastname
                         }).ToList() : new List<CustomDropDown>()
                    );
            }
        }

        public List<CheckModel> UserDetailCheckBox
        {
            get
            {
                return (UserDetail != null ?
                        (from a in UserDetail
                         select new CheckModel()
                         {
                             Id = a.UserId,
                             Name = a.Firstname + " " + a.Lastname,
                             Checked = false
                         }).ToList() : new List<CheckModel>()
                    );
            }
        }

        public static implicit operator UserDetailList(List<UserDetail> model)
        {
            model = (model == null ? new List<UserDetail>() : model);
            return new UserDetailList()
            {
                UserDetail = model
            };
        }
    }

}
