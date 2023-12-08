using JobJabs.BAL;
using JobJabs.DAL;
using JobJabs.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace JobJabs.BAL
{
    public class BL_CandidateReport : Business
    {
        public static CandidateReportDTO Get_Filter(CandidateReportFilter filter)
        {
            CandidateReportDTO dto = new CandidateReportDTO();
            dto.FranchiseList = Get_FranchiseFilter(filter);
            dto.CompanyList = Get_ClientFilter(filter);
            dto.JobLocationList = Get_JobLocationFilter(filter);
            dto.JobTitleList = Get_JobTitleFilter(filter);
            return dto;
        }

        public static List<CustomDropDown> Get_FranchiseFilter(CandidateReportFilter filter)
        {
            CandidateReporFiltertRequest request = new CandidateReporFiltertRequest(filter, "Get_FranchiseFilter", 1);
            DataSet ds = Database.GetDataSet(request);
            List<CustomDropDown> lstFranchise = new List<CustomDropDown>();
            if (ds.Tables.Count > 0)
            {
                lstFranchise = ConvertToList<CustomDropDown>(ds.Tables[0]);
            }
            lstFranchise.Insert(0, new CustomDropDown() { Value = 0, Text = "Select Franchise" });
            return lstFranchise;
        }

        public static List<CustomDropDown> Get_ClientFilter(CandidateReportFilter filter)
        {
            CandidateReporFiltertRequest request = new CandidateReporFiltertRequest(filter, "Get_ClientFilter", 2);
            DataSet ds = Database.GetDataSet(request);
            List<CustomDropDown> lstClient = new List<CustomDropDown>();
            if (ds.Tables.Count > 0)
            {
                lstClient = ConvertToList<CustomDropDown>(ds.Tables[0]);
            }
            lstClient.Insert(0, new CustomDropDown() { Value = 0, Text = "Select Client" });
            return lstClient;
        }

        public static List<CustomDropDown> Get_JobLocationFilter(CandidateReportFilter filter)
        {
            List<CustomDropDown> lstJobLocation = new List<CustomDropDown>();
            if (filter.CompanyId > 0)
            {
                CandidateReporFiltertRequest request = new CandidateReporFiltertRequest(filter, "Get_JobLocationFilter", 3);
                DataSet ds = Database.GetDataSet(request);
                if (ds.Tables.Count > 0)
                {
                    lstJobLocation = ConvertToList<CustomDropDown>(ds.Tables[0]);
                }
            }
            lstJobLocation.Insert(0, new CustomDropDown() { StringValue = "", Text = "Select Job Location" });
            return lstJobLocation;
        }

        public static List<CustomDropDown> Get_JobTitleFilter(CandidateReportFilter filter)
        {
            List<CustomDropDown> lstJobTitle = new List<CustomDropDown>();
            if (!string.IsNullOrEmpty(filter.JobLocation))
            {
                CandidateReporFiltertRequest request = new CandidateReporFiltertRequest(filter, "Get_JobTitleFilter", 4);
                DataSet ds = Database.GetDataSet(request);
                if (ds.Tables.Count > 0)
                {
                    lstJobTitle = ConvertToList<CustomDropDown>(ds.Tables[0]);
                }
            }
            lstJobTitle.Insert(0, new CustomDropDown() { Value = 0, Text = "Select Job Title" });
            return lstJobTitle;
        }


        public static JPCandidateDetailList Get_ReportContent(CandidateReport candidateReport)
        {
            CandidateReportRequest request = new CandidateReportRequest(candidateReport, "Get_ContentDate", 2);
            DataTable dt = Database.GetDataTable(request);
            return (dt.Rows.Count > 0 ? ConvertToList<JobPostCandidateDetail>(dt) : new List<JobPostCandidateDetail>());
        }


    }
}
