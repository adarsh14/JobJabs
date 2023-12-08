using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using JobJabs.Entity;

namespace JobJabs.Entity
{

    public class CompanyDetail
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Area { get; set; }
        public string Pincode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CompanyPhone1 { get; set; }
        public string CompanyPhone2 { get; set; }
        public string CompanyEmail { get; set; }
        public int CompanyStatus { get; set; }
        public int CompanyCreatedBy { get; set; }
        public int TotalLocation { get; set; }
        public CompanyDetail()
        {

            CompanyId = 0;
            CompanyName = "";
            Address1 = "";
            Address2 = "";
            Area = "";
            Pincode = "";
            City = "";
            State = "";
            CompanyPhone1 = "";
            CompanyPhone2 = "";
            CompanyEmail = "";
            CompanyStatus = 0;
            CompanyCreatedBy = 0;
            TotalLocation = 0;
        }

        public static implicit operator RCompanyDetail(CompanyDetail model)
        {
            model = (model == null ? new CompanyDetail() : model);
            return new RCompanyDetail()
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
                CompanyStatus = model.CompanyStatus,
                CompanyCreatedBy = model.CompanyCreatedBy
            };
        }

    }

    public class CompanyDetailList
    {
        public List<CompanyDetail> CompanyDetail { get; set; }
        public List<CustomDropDown> CompanyDetailDropDown
        {
            get
            {
                return (CompanyDetail != null ?
                        (from a in CompanyDetail
                         select new CustomDropDown()
                         {
                             Value = a.CompanyId,
                             Text = a.CompanyName
                         }).ToList() : new List<CustomDropDown>()
                    );
            }
        }

        public List<CheckModel> CompanyDetailCheckBox
        {
            get
            {
                return (CompanyDetail != null ?
                        (from a in CompanyDetail
                         select new CheckModel()
                         {
                             Id = a.CompanyId,
                             Name = a.CompanyName,
                             Checked = false
                         }).ToList() : new List<CheckModel>()
                    );
            }
        }

        public static implicit operator CompanyDetailList(List<CompanyDetail> model)
        {
            model = (model == null ? new List<CompanyDetail>() : model);
            return new CompanyDetailList()
            {
                CompanyDetail = model
            };
        }
    }


    public class CompanyLocationDetail
    {
        public int CompLocId { get; set; }
        public int CompanyId { get; set; }
        public string LocationName { get; set; }
        public string HRName { get; set; }
        public DateTime DOB { get; set; }
        public string CompLocPhone1 { get; set; }
        public string CompLocPhone2 { get; set; }
        public string CompLocEmail { get; set; }
        public string CompLocAddress1 { get; set; }
        public string CompLocAddress2 { get; set; }
        public string CompLocArea { get; set; }
        public string CompLocPincode { get; set; }
        public string CompLocCity { get; set; }
        public string CompLocState { get; set; }
        public int CompLocStatus { get; set; }
        public int CompLocCreatedBy { get; set; }
      


        public  CompanyLocationDetail(){
            CompLocId = 0;
            CompanyId = 0;
            LocationName = "";
            HRName = "";
            DOB = DateTime.Now;
            CompLocPhone1 = "";
            CompLocPhone2 = "";
            CompLocEmail = "";
            CompLocAddress1 = "";
            CompLocAddress2 = "";
            CompLocArea = "";
            CompLocPincode = "";
            CompLocCity = "";
            CompLocState = "";
            CompLocStatus = 0;
            CompLocCreatedBy = 0;
            
        }
        public static implicit operator RCompanyLocationDetail(CompanyLocationDetail model)
        {
            model = (model == null ? new CompanyLocationDetail() : model);
            return new RCompanyLocationDetail()
            {
                CompLocId = model.CompLocId,
                CompanyId = model.CompanyId,
                LocationName = model.LocationName,
                HRName = model.HRName,
                DOB = model.DOB,
                CompLocPhone1 = model.CompLocPhone1,
                CompLocPhone2 = model.CompLocPhone2,
                CompLocEmail = model.CompLocEmail,
                CompLocAddress1 = model.CompLocAddress1,
                CompLocAddress2 = model.CompLocAddress2,
                CompLocArea = model.CompLocArea,
                CompLocPincode = model.CompLocPincode,
                CompLocCity = model.CompLocCity,
                CompLocState = model.CompLocState,
                CompLocStatus = model.CompLocStatus,
                CompLocCreatedBy = model.CompLocCreatedBy
            };
        }
    }

    public class CompanyLocationList
    {
        public List<CompanyLocationDetail> CompLocDetail { get; set; }
        public List<CustomDropDown> CompLocDetailDropDown
        {
            get
            {
                return (CompLocDetail != null ?
                        (from a in CompLocDetail
                         select new CustomDropDown()
                         {
                             Value = a.CompLocId,
                             Text = a.LocationName
                         }).ToList() : new List<CustomDropDown>()
                    );
            }
        }

        public List<CheckModel> CompLocDetailCheckBox
        {
            get
            {
                return (CompLocDetail != null ?
                        (from a in CompLocDetail
                         select new CheckModel()
                         {
                             Id = a.CompLocId,
                             Name = a.LocationName,
                             Checked = false
                         }).ToList() : new List<CheckModel>()
                    );
            }
        }

        public static implicit operator CompanyLocationList(List<CompanyLocationDetail> model)
        {
            model = (model == null ? new List<CompanyLocationDetail>() : model);
            return new CompanyLocationList()
            {
                CompLocDetail = model
            };
        }
    }


}
