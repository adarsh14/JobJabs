using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobJabs.Entity
{
    public class EmploymentTypeDetail
    {
        public int EmploymentTypeId { get; set; }
        public string EmploymentType { get; set; }
        public int EmpTypeStatus { get; set; }
        public int EmpTypeCreatedBy { get; set; }

        public EmploymentTypeDetail()
        {
            EmploymentTypeId = 0;
            EmploymentType = "";
            EmpTypeStatus = 0;
            EmpTypeCreatedBy = 0;
        }

        public static implicit operator REmploymentTypeDetail(EmploymentTypeDetail model)
        {
            model = (model == null ? new EmploymentTypeDetail() : model);
            return new REmploymentTypeDetail()
            {
                EmploymentTypeId = model.EmploymentTypeId,
                EmploymentType = model.EmploymentType,
                EmpTypeStatus = model.EmpTypeStatus,
                EmpTypeCreatedBy = model.EmpTypeCreatedBy
            };
        }
    }


    public class EmploymentTypeDetailList
    {
        public List<EmploymentTypeDetail> EmploymentTypeDetail { get; set; }
        public List<CustomDropDown> EmploymentTypeDropDown
        {
            get
            {
                return (EmploymentTypeDetail != null ?
                        (from a in EmploymentTypeDetail
                         select new CustomDropDown()
                         {
                             Value = a.EmploymentTypeId,
                             Text = a.EmploymentType
                         }).ToList() : new List<CustomDropDown>()
                    );
            }
        }


        public static implicit operator EmploymentTypeDetailList(List<EmploymentTypeDetail> model)
        {
            model = (model == null ? new List<EmploymentTypeDetail>() : model);
            return new EmploymentTypeDetailList()
            {
                EmploymentTypeDetail = model
            };
        }
    }

}