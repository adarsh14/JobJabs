using JobJabs.Attributes;
using JobJabs.BAL;
using JobJabs.Entity;
using JobJabs.Filters;
using JobJabs.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace JobJabs.Controllers
{
    [SessionFilter]
    [WriteToLogErrorHandler]
    public class CommonController : CommonBaseController
    {
        [NoCache]
        public JsonResult GetCompanyLocation(string id)
        {
            CompanyLocationList compLocList = BL_CompanyDetail.Get_AllLocationByCompanyId(new CompanyLocationDetail() { CompanyId = Convert.ToInt32(id) }).ToList();
            compLocList.CompLocDetail.Insert(0, new CompanyLocationDetail { CompLocId = 0, LocationName = "Select Client Location" });
            return Json(compLocList.CompLocDetailDropDown, JsonRequestBehavior.AllowGet);
        }

        [NoCache]
        public JsonResult CheckIfNewCandidate(int spocAdminId)
        {
            int newCount = BL_JobPostDetail.Check_IfNewCandidateExists(new GetJobPostDetail() { SpocAdminId = spocAdminId, JobPostStatus = 1 });
            WebApiResponse data = new WebApiResponse() { Success = true, Data = newCount };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [NoCache]
        public ActionResult GetComments()
        {
            JPCACommentDetail candidateDetail = new JPCACommentDetail()
            {
                JPCAId = Request.ConvertToInt32("jpcaid")
            };
            VM_JPCACommentDetail viewModel = BL_CandidateDetail.Get_JPCACommentDetail(candidateDetail);
            return PartialView(viewModel);
        }

        [NoCache]
        public JsonResult ResetPassword(int userId)
        {
            UserDetail userDetail = new UserDetail();
            userDetail.UserId = userId;
            userDetail.Password = CommonClass.RandomString(9);
            userDetail.IsPasswordValidated = 0;
            BL_UserDetail.Update_UserPassword(userDetail);
            WebApiResponse data = new WebApiResponse() { Success = true, Data = userDetail.Password };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [NoCache]
        public JsonResult ClientByFranchiseId(CandidateReportFilter filter)
        {
            List<CustomDropDown> lstClient = new List<CustomDropDown>();
            lstClient = BL_CandidateReport.Get_ClientFilter(filter);
            return Json(lstClient, JsonRequestBehavior.AllowGet);
        }

        [NoCache]
        public JsonResult JobLocByClientAndUserType(CandidateReportFilter filter)
        {
            List<CustomDropDown> lstJobLocation = new List<CustomDropDown>();
            lstJobLocation = BL_CandidateReport.Get_JobLocationFilter(filter);
            return Json(lstJobLocation, JsonRequestBehavior.AllowGet);
        }

        [NoCache]
        public JsonResult JobTitleByJobLocAndUserType(CandidateReportFilter filter)
        {
            List<CustomDropDown> lstJobTitle = new List<CustomDropDown>();
            lstJobTitle = BL_CandidateReport.Get_JobTitleFilter(filter);
            return Json(lstJobTitle, JsonRequestBehavior.AllowGet);
        }
     }
 }