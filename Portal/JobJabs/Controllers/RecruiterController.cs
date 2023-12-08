using JobJabs.BAL;
using JobJabs.Entity;
using JobJabs.Filters;
using JobJabs.ViewModel;
using System.Web.Mvc;

namespace JobJabs.Controllers
{
    [SessionFilter]
    [WriteToLogErrorHandler]
    public class RecruiterController : CommonBaseController
    {
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult JobPost()
        {
            VM_JobPostFullDetailList viewModel = new VM_JobPostFullDetailList();
            viewModel.Status = Request.ConvertToInt32("sts"); 
            viewModel.JobPostList = BL_JobPostDetail.Get_JobPostWithFullDetail(new GetJobPostDetail() { RecruiterId = session.UserDetail.UserId, JobPostStatus = 1, JPCAStatus = viewModel.Status });
            viewModel.StatusText = CommonClass.CandidateStatusText(viewModel.Status);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult JobPost(int status)
        {
            VM_JobPostFullDetailList viewModel = new VM_JobPostFullDetailList();
            viewModel.CandidateStatus = CommonClass.Get_CandidateStatus();
            viewModel.Status = status;
            viewModel.JobPostList = BL_JobPostDetail.Get_JobPostWithFullDetail(new GetJobPostDetail() { RecruiterId = session.UserDetail.UserId, JobPostStatus = 1, JPCAStatus = viewModel.Status });
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
            viewModel.CandidateList = BL_CandidateDetail.Get_Candidate(new JobPostCandidateDetail() { JobPostId = viewModel.JobPostId, RecruiterId = session.UserDetail.UserId, FranchiseId =session.FranchiseDetail.FranchiseId, JPCAStatus = (Request.QueryString["sts"]==null ? -1 : Request.ConvertToInt32("sts"))});
            return View(viewModel);
        }

        public ActionResult AddCandidate()
        {
            VM_AddCandidate viewModel = FillDetail();
            if (Session["Msg"] != null)
            {
                viewModel.Message = "Candidate is assigned successfully. ";
                Session["Msg"] = null;
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddCandidate(VM_AddCandidate viewModel)
        {
            if (ModelState.IsValid)
            {
                CandidateDetail candidateDetail = viewModel.CandidateDetail;
                candidateDetail.CandidateCreatedBy = session.UserDetail.UserId;
                JobPostCandidateDetail jpcandidateDetail = new JobPostCandidateDetail()
                {
                    JobPostId = viewModel.JobPostId,
                    RecruiterId = session.UserDetail.UserId,
                    FranchiseId = session.FranchiseDetail.FranchiseId,
                    JPCACreatedBy = session.UserDetail.UserId
                }; 
                if (candidateDetail.CandidateId == 0)
                {
                    BL_CandidateDetail.Add_CandidateDetail(candidateDetail,viewModel.ResumeFile, jpcandidateDetail);
                }
                else
                {
                    BL_CandidateDetail.Update_CandidateDetail(candidateDetail, viewModel.ResumeFile, jpcandidateDetail); ;
                }
                if(viewModel.JobPostId > 0)
                {
                    return RedirectToAction("CandidateList", "Recruiter", new { jpid = viewModel.JobPostId, title = CommonClass.ConvertTitle(viewModel.Title)});
                }
                else
                {
                    Session["Msg"] = 1;
                    return RedirectToAction("AddCandidate", "Recruiter");
                }
            }
            viewModel = FillDetail(viewModel.CandidateDetail.CandidateId);
            return View(viewModel);
        }

        public VM_AddCandidate FillDetail(int candidateId = 0)
        {
            VM_AddCandidate viewModel = new VM_AddCandidate();
            if (candidateId > 0)
            {
                viewModel.CandidateDetail = BL_CandidateDetail.Get_CandidateDetailById(new CandidateDetail() { CandidateId = candidateId  });
            }
            viewModel.TotalExperienceMonth = Get_IncrementalValue(0, 12, "Month");
            viewModel.TotalExperienceYear = Get_IncrementalValue(0,35, "Year",1,"More than 35 year");
            viewModel.CTCCrore = Get_IncrementalValue(0, 99, "Crore");
            viewModel.CTCLakh = Get_IncrementalValue(0,99, "Lakhs");
            viewModel.CTCThousand = Get_IncrementalValue(0,99, "Thousand");
            viewModel.NoticePeriod = Get_IncrementalValue(0,90, "Days", 15,"More than 90 days");
            viewModel.JobPostId = Request.ConvertToInt32("jpid");
            viewModel.Title =  Request.ConvertToString("title").Replace("_", "&").Replace("-", " ");
            return viewModel;
        }


        public  DDLList Get_IncrementalValue(int startValue, int endValue, string caption, int incr=0, string endText="" )
        {
            DDLList list = new DDLList();
            //list.SelectItemList.Add(new CustomDropDown() { Text = startText, Value =-1 });
            for (int x = startValue; x <= endValue;)
            {
                list.SelectItemList.Add( new CustomDropDown() { Text =x.ToString() + " " + caption, Value = x});
                x = x + (incr > 0 ? incr : 1);
            }
            if (!string.IsNullOrEmpty(endText))
            {
                list.SelectItemList.Add(new CustomDropDown() { Text = endText, Value = endValue + 1 });
            }
            return list;
        }

    }
}