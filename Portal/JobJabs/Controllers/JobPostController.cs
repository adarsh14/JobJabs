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
    public class JobPostController : CommonBaseController
    {
        // GET: JobPost
        public ActionResult Index()
        {
            VM_JobPostList viewModel = BL_JobPostDetail.Get_AllJobPost( new JobPostDetail() { JPCreatedBy= session.UserDetail.UserId,  JobPostStatus=1 }).ToList();
            return View(viewModel);
        }

        public ActionResult AddJobPost()
        {
            VM_AddJobPost viewModel = FillDetail();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddJobPost(VM_AddJobPost viewModel)
        {
            if (ModelState.IsValid)
            {
                JobPostDetail jobPostDetail = viewModel.JobPost;
                jobPostDetail.JPCreatedBy = session.UserDetail.UserId;
                if (jobPostDetail.JobPostId == 0)
                {
                    BL_JobPostDetail.Add_JobPostDetail(jobPostDetail, viewModel.JDFile, viewModel.ChecklistFile);
                }
                else
                {
                    BL_JobPostDetail.Update_JobPostDetail(jobPostDetail, viewModel.JDFile, viewModel.ChecklistFile);
                }
                return RedirectToAction("Index");
            }
            viewModel = FillDetail(viewModel.JobPost.JobPostId);
            return View(viewModel);
        }


        public ActionResult EditJobPost()
        {
            VM_AddJobPost viewModel = FillDetail(Request.ConvertToInt32("jpid"));
            return View("AddJobPost", viewModel);
        }

        public ActionResult ChangeJobPostStatus()
        {
            JobPostDetail jobPostDetail = new JobPostDetail() { JobPostId= Request.ConvertToInt32("jpid"), JobPostStatus = Request.ConvertToInt32("sts"), JPCreatedBy  = session.UserDetail.UserId };
            BL_JobPostDetail.Change_JobPostStatus(jobPostDetail);
            return RedirectToAction("Index", "JobPost");
        }


        public VM_AddJobPost FillDetail(int jobPostId=0)
        {
            VM_AddJobPost viewModel = new VM_AddJobPost();
            if(jobPostId > 0)
            {
               viewModel.JobPost = BL_JobPostDetail.Get_JobPostById(new JobPostDetail() { JobPostId = jobPostId });
            }
            viewModel.CompanyList = BL_CompanyDetail.Get_AllCompanyByStatus(new CompanyDetail() { CompanyStatus = 1 }).ToList();
            viewModel.CompanyList.CompanyDetail.Insert(0, new CompanyDetail { CompanyId = 0, CompanyName = "Select Client" });
            int companyId = (viewModel.JobPost.ClientId > 0 ? viewModel.JobPost.ClientId : 0);
            if (companyId > 0)
            {
                viewModel.CompLocList = BL_CompanyDetail.Get_AllLocationByCompanyId(new CompanyLocationDetail() { CompanyId=companyId }).ToList();
            }
            viewModel.CompLocList.CompLocDetail.Insert(0, new CompanyLocationDetail { CompLocId = 0, LocationName = "Select Client Location" });
            viewModel.ExperienceLevel = BL_Common.Get_AllExperienceLevelDetail( new ExperienceLevelDetail());
            viewModel.ExperienceLevel.ExperienceLevelDetail.Insert(0, new ExperienceLevelDetail { ExperienceLevelId = 0, ExperienceLevel = "Select Experience Level" });
            viewModel.EmploymentType = BL_Common.Get_AllEmploymentTypeDetail( new EmploymentTypeDetail());
            viewModel.EmploymentType.EmploymentTypeDetail.Insert(0, new EmploymentTypeDetail { EmploymentTypeId = 0, EmploymentType = "Select Employment Type" });
            return viewModel;
        }

        public ActionResult AssignFranchise()
        {
            VM_AssignJobPostToFranchise viewModel = new VM_AssignJobPostToFranchise() { JobPostId  = Request.ConvertToInt32("jpid"), Title = Request.ConvertToString("title").Replace("_", "&").Replace("-", " ") };
            viewModel.FranchiseList = BL_JobPostDetail.Get_AllFranchiseToJobPost(new JobPostFranchiseDetail() { JobPostId  = viewModel.JobPostId, SPOCAdminId=session.UserDetail.UserId });
            if (Session["Msg"] != null)
            {
                viewModel.Message = "Franchise is assigned successfully.";
                Session["Msg"] = null;
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AssignFranchise(List<CheckModel> checkBox, string title)
        {
            int jobPostId = checkBox[0].ParentId;
            BL_JobPostDetail.Delete_JobPostFranchiseAsgn(new JobPostFranchiseDetail() { JobPostId  = jobPostId, JPFACreatedBy = session.UserDetail.UserId });
            foreach (CheckModel item in checkBox)
            {
                if (item.Checked)
                {
                    JobPostFranchiseDetail jpFranchise = new JobPostFranchiseDetail()
                    {
                       JobPostId  = item.ParentId,
                        FranchiseId = item.Id,
                        JPFACreatedBy = session.UserDetail.UserId
                    };
                    BL_JobPostDetail.Assign_JobPostToFranchise(jpFranchise);
                }

            }
            Session["Msg"] = 1;
            return RedirectToAction("AssignFranchise", "JobPost", new { jpid = jobPostId, title = title.Replace("&", "_").Replace(" ", "-") });
        }


    }
}