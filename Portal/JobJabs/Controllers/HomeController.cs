using JobJabs.BAL;
using JobJabs.Entity;
using JobJabs.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace JobJabs.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            VM_Home viewModel = new VM_Home() { MailMsg = new VM_MailMsg() };
            viewModel.JobPostList = BL_JobPostDetail.Get_AllJobPostByStatus(new JobPostDetail() { JobPostStatus = 1 }).Take(10).ToList();
            return View(viewModel);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Team()
        {
            return View();
        }

        public ActionResult Contact()
        {
            VM_Home viewModel = new VM_Home() { StepNo = 1};
            if (Session["ContactMessage"] != null)
            {
                viewModel.StepNo = 2;
                Session["ContactMessage"] = null;
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Contact(VM_Home viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MailMsg msg = viewModel.MailMsg;
                    MailMessage message = new MailMessage();
                    message.From = new MailAddress("ContactUs@JobJabs.com", "JobJabs - Contact Us");
                    message.To.Add(new MailAddress(Convert.ToString(ConfigurationManager.AppSettings["ContactUsMailTo"])));
                    message.Subject = msg.Subject;
                    message.Body = "Name : " + msg.Name + " <br/> Email : " + msg.Email + " <br/> Contact  : " + msg.ContactNumber + "<br> " + msg.Body;
                    BL_Mail.Send_Mail(message);
                    message = null; // free up resources
                    Session["ContactMessage"] = true;
                    return RedirectToAction("Contact");
                }
                catch (Exception ex)
                {
                    WriteToLogClass.WriteErrorLog("Home", "Send Contact mail", ex);
                    return RedirectToAction("Contact");
                }
            }
            return View(viewModel);
        }

        public ActionResult Gallery()
        {
            return View();
        }

        [HttpPost]
        public JsonResult KeepSessionAlive()
        {
            return new JsonResult { Data = "Success" };
        }

    }
}