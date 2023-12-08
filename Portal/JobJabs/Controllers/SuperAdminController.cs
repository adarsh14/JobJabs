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
    public class SuperAdminController : CommonBaseController
    {
        // GET: SuperAdmin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult JobPost()
        {
            VM_JobPostFullDetailList viewModel = new VM_JobPostFullDetailList();
            viewModel.Status = Request.ConvertToInt32("sts"); 
            viewModel.JobPostList = BL_JobPostDetail.Get_JobPostWithFullDetail(new GetJobPostDetail() {  JobPostStatus = 1, JPCAStatus = viewModel.Status });
            viewModel.StatusText = CommonClass.CandidateStatusText(viewModel.Status);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult JobPost(int status)
        {
            VM_JobPostFullDetailList viewModel = new VM_JobPostFullDetailList();
            viewModel.CandidateStatus = CommonClass.Get_CandidateStatus();
            viewModel.Status = status;
            viewModel.JobPostList = BL_JobPostDetail.Get_JobPostWithFullDetail(new GetJobPostDetail() { JobPostStatus = 1, JPCAStatus = viewModel.Status });
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
            viewModel.CandidateList = BL_CandidateDetail.Get_Candidate(new JobPostCandidateDetail() { JobPostId = viewModel.JobPostId, JPCAStatus = Request.ConvertToInt32("sts"), FranchiseId = Request.ConvertToInt32("fid") });
            return View(viewModel);
        }
        
        public ActionResult BlogList()
        {
            VM_BlogPostList viewModel = BL_BlogPostDetail.Get_AllBlogPost(new BlogPostDetail());
            return View(viewModel);
        }

        public ActionResult AddBlog()
        {
            VM_AddBlogPost viewModel = new VM_AddBlogPost();
            return View(viewModel);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddBlog(VM_AddBlogPost viewModel)
        {
            if (ModelState.IsValid)
            {
                BlogPostDetail blogPostDetail = viewModel;
                blogPostDetail.BPCreatedBy = session.UserDetail.UserId;
                blogPostDetail.BPText = blogPostDetail.BPText.Replace("\n", "<br/>");
                if (blogPostDetail.BlogPostId  == 0)
                {
                    BL_BlogPostDetail.Add_BlogPostDetail(blogPostDetail);
                }
                else
                {
                    BL_BlogPostDetail.Update_BlogPostDetail(blogPostDetail);
                }
                return RedirectToAction("BlogList");
            }
            viewModel = FillBlogDetail(viewModel.BlogPostId);
            return View(viewModel);
        }


        public ActionResult EditBlog()
        {
            VM_AddBlogPost viewModel = FillBlogDetail(Request.ConvertToInt32("bpid"));
            return View("AddBlog", viewModel);
        }

        public ActionResult ChangeBlogStatus()
        {
            BlogPostDetail blogPostDetail = new BlogPostDetail() { BlogPostId = Request.ConvertToInt32("bpid"), BPStatus  = Request.ConvertToInt32("sts"),  BPCreatedBy = session.UserDetail.UserId };
            BL_BlogPostDetail.Change_BlogPostStatus(blogPostDetail);
            return RedirectToAction("BlogList");
        }

        public VM_AddBlogPost FillBlogDetail(int blogId = 0)
        {
            VM_AddBlogPost viewModel = new VM_AddBlogPost();
            if (blogId > 0)
            {
                viewModel = BL_BlogPostDetail.Get_BlogPostById(new BlogPostDetail() { BlogPostId = blogId });
            }
           return viewModel;
        }
    }
}