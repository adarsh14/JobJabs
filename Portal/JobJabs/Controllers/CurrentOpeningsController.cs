using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobJabs.BAL;
using JobJabs.Entity;
using JobJabs.ViewModel;

namespace JobJabs.Controllers
{
    public class CurrentOpeningsController : Controller
    {
        // GET: CurrentOpenings
        public ActionResult Index()
        {
            VM_CurrentOpenings viewModel = new VM_CurrentOpenings() {};
            //viewModel.JobPostList = BL_JobPosting.Get_AlljobPosting(new JobPosting() { Status = 1 }).ToList();
            return View(viewModel);
        }
    }

}

