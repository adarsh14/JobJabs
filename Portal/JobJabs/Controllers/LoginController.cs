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
    public class LoginController : CommonBaseController
    {
        // GET: Login
        public ActionResult Index()
        {
            VM_Login viewModel = new VM_Login(); 
            return View(viewModel);
        }

        [WriteToLogErrorHandler]
        [HttpPost]
        public ActionResult Index(VM_Login viewModel)
        {
           UserDetail userDetail= BL_Login.User_Authenication(viewModel);
            if (userDetail.LoginStatus == 1)
            {
                session.CreateNewSession();
                session.UserDetail = userDetail;
                if (userDetail.UserType == (int)CommonClass.enumUserType.FranchiseAdmin || userDetail.UserType == (int)CommonClass.enumUserType.FranchiseRecruiter)
                {
                    session.FranchiseDetail = BL_FranchiseDetail.Get_FranchiseDetailByUserId(new FranchiseDetail() { UserId = userDetail.UserId });
                }
                List<string> dLink = CommonClass.DashboardActionLink(userDetail);
                return RedirectToAction(dLink[1], dLink[0]);

               
               
            }
            viewModel.Message = "Invalid Username/Password.";
            return View(viewModel);
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            return View();
        }

        public ActionResult ChangePassword()
        {
            Session.Clear();
            ViewBag.DisplayType = 2;
            return View("LogOut");
        }

    }
}