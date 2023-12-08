using JobJabs.BAL;
using JobJabs.Entity;
using JobJabs.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobJabs.Controllers
{
    public class CEODeskController : Controller
    {
        // GET: CEODesk
        public ActionResult Index()
        {
            VM_BlogPostList viewModel = BL_BlogPostDetail.Get_BlogPostByStatusId(new BlogPostDetail() { BPStatus=1 });
            return View(viewModel);
        }

       
    }
}