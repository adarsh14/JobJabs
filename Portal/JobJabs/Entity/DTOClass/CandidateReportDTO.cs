using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobJabs.Entity
{
    public class CandidateReportDTO
    {
        public List<CustomDropDown> FranchiseList { get; set; }
        public List<CustomDropDown> CompanyList { get; set; }
        public List<CustomDropDown> JobTitleList { get; set; }
        public List<CustomDropDown> JobLocationList { get; set; }
        public string Message { get; set; }

        public CandidateReportDTO()
        {
            FranchiseList = new List<CustomDropDown>();
            CompanyList = new List<CustomDropDown>();
            JobTitleList = new List<CustomDropDown>();
            JobLocationList = new List<CustomDropDown>();
        }
    }



}