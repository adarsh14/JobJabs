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
    public class FranchiseAdminController : CommonBaseController
    {
        // GET: JobPost
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult RecruiterList()
        {
            VM_UserList viewModel = new VM_UserList() { UserType = (int)CommonClass.enumUserType.FranchiseRecruiter, FranchiseId = session.FranchiseDetail.FranchiseId };
            viewModel.UserList = BL_FranchiseDetail.Get_FranchiseUserByFranchiseId(new FranchiseDetail() { FranchiseId = viewModel.FranchiseId });
            return View(viewModel);
        }

      

        public ActionResult JobPost()
        {
            VM_JobPostFullDetailList viewModel = new VM_JobPostFullDetailList();
            viewModel.Status = Request.ConvertToInt32("sts");
            viewModel.JobPostList = BL_JobPostDetail.Get_JobPostWithFullDetail(new GetJobPostDetail() { FranchiseId = session.FranchiseDetail.FranchiseId, JobPostStatus = 1, JPCAStatus = viewModel.Status });
            viewModel.StatusText = CommonClass.CandidateStatusText(viewModel.Status);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult JobPost(int status)
        {
            VM_JobPostFullDetailList viewModel = new VM_JobPostFullDetailList();
            viewModel.CandidateStatus = CommonClass.Get_CandidateStatus();
            viewModel.Status = status;
            viewModel.JobPostList = BL_JobPostDetail.Get_JobPostWithFullDetail(new GetJobPostDetail() { FranchiseId = session.FranchiseDetail.FranchiseId, JobPostStatus = 1, JPCAStatus = viewModel.Status });
            viewModel.StatusText = CommonClass.CandidateStatusText(viewModel.Status);
            return View(viewModel);
        }

        public ActionResult CandidateList()
        {
            VM_CandidateList viewModel = new VM_CandidateList()
            {
                JobPostId = Request.ConvertToInt32("jpid"),
                JobTitle = CommonClass.ReConvertTitle(Request.ConvertToString("title"))
            };
            viewModel.CandidateList = BL_CandidateDetail.Get_Candidate(new JobPostCandidateDetail() { JobPostId = viewModel.JobPostId,  FranchiseId = session.FranchiseDetail.FranchiseId, JPCAStatus = Request.ConvertToInt32("sts") });
            return View(viewModel);
        }

        public ActionResult AssignRecruiter()
        {
            VM_AssignJobPostToRecruiter viewModel = new VM_AssignJobPostToRecruiter() { JobPostId  = Request.ConvertToInt32("jpid"), Title = Request.ConvertToString("title").Replace("_", "&").Replace("-", " ") };
            viewModel.RecruiterList = BL_JobPostDetail.Get_AllRecruiterToJobPost(new JobPostRecruiterDetail() { JobPostId  = viewModel.JobPostId, FranchiseId = session.FranchiseDetail.FranchiseId });
            if (Session["Msg"] != null)
            {
                viewModel.Message = "Recruiter is assigned successfully.";
                Session["Msg"] = null;
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AssignRecruiter(List<CheckModel> checkBox, string title)
        {
            int jobPostId = checkBox[0].ParentId;
            BL_JobPostDetail.Delete_JobPostRecruiterAsgn(new JobPostRecruiterDetail() { JobPostId  = jobPostId, FranchiseId= session.FranchiseDetail.FranchiseId, JPRCCreatedBy = session.UserDetail.UserId });
            foreach (CheckModel item in checkBox)
            {
                if (item.Checked)
                {
                    JobPostRecruiterDetail jpRecruiter = new JobPostRecruiterDetail()
                    {
                       JobPostId  = item.ParentId,
                        FranchiseId = session.FranchiseDetail.FranchiseId,
                        UserId =item.Id,
                        JPRCCreatedBy = session.UserDetail.UserId
                    };
                    BL_JobPostDetail.Assign_JobPostToRecruiter(jpRecruiter);
                }

            }
            Session["Msg"] = 1;
            return RedirectToAction("AssignRecruiter", "FranchiseAdmin", new { jpid = jobPostId, title = title.Replace("&", "_").Replace(" ", "-") });
        }


    }
}