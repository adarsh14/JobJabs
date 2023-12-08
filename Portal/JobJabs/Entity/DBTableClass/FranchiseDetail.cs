using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using JobJabs.Entity;

namespace JobJabs.Entity
{

    public class FranchiseDetail : UserDetail
    {
        public int FranchiseId { get; set; }
        public string FranchiseName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Area { get; set; }
        public string Pincode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string FranchisePhone1 { get; set; }
        public string FranchisePhone2 { get; set; }
        public string FranchiseEmail { get; set; }
        public int FranchiseStatus { get; set; }
        public int FranchiseCreatedBy { get; set; }
        public int TotalActiveUser { get; set; }
        public UserDetailList RecruiterList { get; set; }

        public FranchiseDetail()
        {
           
            FranchiseId = 0;
            UserId = 0;
            FranchiseName = "";
            Address1 = "";
            Address2 = "";
            Area = "";
            Pincode = "";
            City = "";
            State = "";
            FranchisePhone1 = "";
            FranchisePhone2 = "";
            FranchiseEmail = "";
            FranchiseStatus = 0;
            FranchiseCreatedBy = 0;
            RecruiterList = new UserDetailList(); 
        }

        public static implicit operator RFranchiseDetail(FranchiseDetail model)
        {
            model = (model == null ? new FranchiseDetail() : model);
            return new RFranchiseDetail()
            {
                FranchiseId = model.FranchiseId,
                UserId=model.UserId,
                FranchiseName=model.FranchiseName,
                Address1 = model.Address1,
                Address2 = model.Address2,
                Area = model.Area,
                Pincode = model.Pincode,
                City=model.City,
                State=model.State,
                FranchisePhone1 = model.FranchisePhone1,
                FranchisePhone2 = model.FranchisePhone2,
                FranchiseEmail = model.FranchiseEmail,
                FranchiseStatus=model.FranchiseStatus,
               FranchiseCreatedBy=model.FranchiseCreatedBy
            };
        }

    }

    public class FranchiseDetailList
    {
        public List<FranchiseDetail> FranchiseDetail { get; set; }
        public List<CustomDropDown> FranchiseDetailDropDown
        {
            get
            {
                return (FranchiseDetail != null ?
                        (from a in FranchiseDetail
                         select new CustomDropDown()
                         {
                             Value = a.FranchiseId,
                             Text =a.FranchiseName + "(" + a.Firstname + " " + a.Lastname + ")"
                         }).ToList() : new List<CustomDropDown>()
                    );
            }
        }

        public List<CheckModel> FranchiseDetailCheckBox
        {
            get
            {
                return (FranchiseDetail != null ?
                        (from a in FranchiseDetail
                         select new CheckModel()
                         {
                             Id = a.FranchiseId,
                             Name = a.FranchiseName + "(" + a.Firstname + " " + a.Lastname + ")",
                             Checked = false
                         }).ToList() : new List<CheckModel>()
                    );
            }
        }

        public static implicit operator FranchiseDetailList(List<FranchiseDetail> model)
        {
            model = (model == null ? new List<FranchiseDetail>() : model);
            return new FranchiseDetailList()
            {
                FranchiseDetail = model
            };
        }
    }

    public class FranchiseUserDetail
    {
        public int FranchiseId { get; set; }
        public int UserId { get; set; }

        public static implicit operator RFranchiseUserDetail(FranchiseUserDetail model)
        {
            model = (model == null ? new FranchiseUserDetail() : model);
            return new RFranchiseUserDetail()
            {
                FranchiseId = model.FranchiseId,
                UserId = model.UserId,
            };
        }
    }


    public class SPOCFranchiseDetail
    {
        public int FranchiseId { get; set; }
        public string FranchiseName { get; set; }
        public int SPOCAdminId { get; set; }
        public int Status { get; set; }
        public int CreatedBy { get; set; }
        public bool Checked { get; set; }
        public SPOCFranchiseDetail()
        {
            FranchiseId = 0;
            FranchiseName = "";
            SPOCAdminId = 0;
            Status = 0;
            CreatedBy = 0;
        }

        public static implicit operator RSPOCFranchiseDetail(SPOCFranchiseDetail model)
        {
            return new RSPOCFranchiseDetail()
            {
                 FranchiseId=model.FranchiseId,
                  SPOCAdminId=model.SPOCAdminId,
                   SPFACreatedBy=model.CreatedBy
            };
        }

        

    }

    public class SPOCFranchiseList
    {
        public List<SPOCFranchiseDetail> Franchise { get; set; }
        public List<CustomDropDown> SPOCFranchiseDropDown
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

        public List<CheckModel> SPOCFranchiseCheckBox
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

        public static implicit operator SPOCFranchiseList(List<SPOCFranchiseDetail> model)
        {
            model = (model == null ? new List<SPOCFranchiseDetail>() : model);
            return new SPOCFranchiseList()
            {
                Franchise = model
            };
        }
    }
}
