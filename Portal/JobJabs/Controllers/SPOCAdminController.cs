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
    public class SPOCAdminController : CommonBaseController
    {
        // GET: SuperAdmin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult JobPost() 
        {
            VM_JobPostFullDetailList viewModel = new VM_JobPostFullDetailList();
            viewModel.Status = Request.ConvertToInt32("sts"); // ? viewModel.CandidateStatus.SelectItemList.FirstOrDefault().Value : Request.ConvertToInt32("sts"));
            viewModel.JobPostList= BL_JobPostDetail.Get_JobPostWithFullDetail(new GetJobPostDetail() { SpocAdminId = session.UserDetail.UserId, JobPostStatus =1, JPCAStatus= viewModel.Status});
            viewModel.StatusText = CommonClass.CandidateStatusText(viewModel.Status);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult JobPost(int status)
        {
            VM_JobPostFullDetailList viewModel = new VM_JobPostFullDetailList();
            viewModel.CandidateStatus = CommonClass.Get_CandidateStatus();
            viewModel.Status = status;
            viewModel.JobPostList = BL_JobPostDetail.Get_JobPostWithFullDetail(new GetJobPostDetail() { SpocAdminId = session.UserDetail.UserId, JobPostStatus = 1, JPCAStatus=viewModel.Status });
            viewModel.StatusText = CommonClass.CandidateStatusText(viewModel.Status);
            return View(viewModel);
        }

        public ActionResult CandidateList()
        {
            VM_CandidateList viewModel = new VM_CandidateList();
            session.JPCADetail.JobPostId= viewModel.JobPostId = (Request.ConvertToInt32("jpid") > 0 ? Request.ConvertToInt32("jpid") : session.JPCADetail.JobPostId);
            session.JPCADetail.JobTitle = viewModel.JobTitle = (Request.ConvertToString("title") != "" ? CommonClass.ReConvertTitle(Request.ConvertToString("title")) : session.JPCADetail.JobTitle);
            session.JPCADetail.FranchiseId=  (Request.ConvertToInt32("fid") > 0 ? Request.ConvertToInt32("fid") : session.JPCADetail.FranchiseId);
            session.JPCADetail.JPCAStatus = (Request.QueryString["sts"] != null ? Request.ConvertToInt32("sts") : session.JPCADetail.JPCAStatus);
            viewModel.CandidateList = BL_CandidateDetail.Get_Candidate(new JobPostCandidateDetail() { JobPostId = session.JPCADetail.JobPostId, JPCAStatus = session.JPCADetail.JPCAStatus, FranchiseId = session.JPCADetail.FranchiseId });
            viewModel.CandidateStatus = CommonClass.Get_CandidateStatus();
            return View(viewModel);
        }


        [HttpPost]
        public ActionResult ChangeCandidateStatus(int jpcaId, int jpcaStatus, string comment, string statusDate)
        {
            JobPostCandidateDetail jpcaDetail = new JobPostCandidateDetail() {
                JPCAId= jpcaId,
                JPCAStatus = jpcaStatus,
                JPCACreatedBy  = session.UserDetail.UserId,
                StatusDate=Convert.ToDateTime(statusDate)
            };
             BL_CandidateDetail.Change_JobPostCandidateStatus(jpcaDetail);
            if (!string.IsNullOrEmpty(comment))
            {
                BL_CandidateDetail.Add_JPCACommentDetail(new JPCACommentDetail() {
                    JPCAId =jpcaId, JPCAComment =comment, JPCACreatedBy = session.UserDetail.UserId, JPCAStatus = jpcaStatus
                } );
            }
            return RedirectToAction("CandidateList", "SPOCAdmin");
        }

    }
}