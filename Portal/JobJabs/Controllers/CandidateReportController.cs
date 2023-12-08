using JobJabs.BAL;
using JobJabs.Entity;
using JobJabs.Filters;
using JobJabs.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobJabs.Controllers
{
    [SessionFilter]
    [WriteToLogErrorHandler]
    public class CandidateReportController : CommonBaseController
    {
        // GET: CandidateReport
        public ActionResult Index()
        {
            VM_CandidateReport viewModel = Fill_Detail(new CandidateReportFilter());
            viewModel.Status = -1;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(VM_CandidateReport model)
        {
            VM_CandidateReport viewModel = Fill_Content(model);
            return View(viewModel);
        }

        private VM_CandidateReport Fill_Content(VM_CandidateReport viewModel)
        {
            CandidateReport report = viewModel;
            CandidateReportFilter filter = viewModel;
            if (!string.IsNullOrEmpty(viewModel.FromDate))
            {
                report.FromDate = Convert.ToDateTime(viewModel.FromDate);
            }
            if (!string.IsNullOrEmpty(viewModel.ToDate))
            {
                report.ToDate = Convert.ToDateTime(viewModel.ToDate);
            }
            report.RecruiterId = (session.UserDetail.UserType == (int)CommonClass.enumUserType.FranchiseRecruiter ? session.UserDetail.UserId : 0);
            report.SpocAdminId = (session.UserDetail.UserType == (int)CommonClass.enumUserType.SPOCAdmin ? session.UserDetail.UserId : 0);
            viewModel.Content = BL_CandidateReport.Get_ReportContent(report);

            CandidateReportDTO dto = Fill_Filter(filter);
            viewModel.FranchiseList = dto.FranchiseList;
            viewModel.CompanyList = dto.CompanyList;
            viewModel.JobLocationList = dto.JobLocationList;
            viewModel.JobTitleList = dto.JobTitleList;

            return viewModel;
        }

        private VM_CandidateReport Fill_Detail(CandidateReportFilter filter)
        {
            VM_CandidateReport viewModel = new VM_CandidateReport();
            CandidateReportDTO dto = Fill_Filter(filter);
            viewModel.FranchiseList = dto.FranchiseList;
            viewModel.CompanyList = dto.CompanyList;
            viewModel.JobLocationList = dto.JobLocationList;
            viewModel.JobTitleList = dto.JobTitleList;
            viewModel.Content = new JPCandidateDetailList() { CandidateDetail = new List<JobPostCandidateDetail>() };
            if (session.UserDetail.UserType == (int)CommonClass.enumUserType.FranchiseRecruiter || session.UserDetail.UserType == (int)CommonClass.enumUserType.FranchiseAdmin)
            {
                viewModel.FranchiseId = session.FranchiseDetail.FranchiseId;
            }
            return viewModel;
        }

        private CandidateReportDTO Fill_Filter(CandidateReportFilter filter)
        {
            filter.RecruiterId = (session.UserDetail.UserType == (int)CommonClass.enumUserType.FranchiseRecruiter ? session.UserDetail.UserId : 0);
            if (filter.FranchiseId == 0 && (session.UserDetail.UserType == (int)CommonClass.enumUserType.FranchiseRecruiter || session.UserDetail.UserType == (int)CommonClass.enumUserType.FranchiseAdmin))
            {
                filter.FranchiseId = session.FranchiseDetail.FranchiseId;
            }
            filter.SpocAdminId = (session.UserDetail.UserType == (int)CommonClass.enumUserType.SPOCAdmin ? session.UserDetail.UserId : 0);
            CandidateReportDTO dto = BL_CandidateReport.Get_Filter(filter);
            return dto;

        }
    }
}