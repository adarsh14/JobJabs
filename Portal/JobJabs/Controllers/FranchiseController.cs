using JobJabs.BAL;
using JobJabs.Entity;
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
    public class FranchiseController : Controller
    {
        // GET: Franchise
        public ActionResult Index()
        {
            VM_FranchiseEnquiry viewModel = new VM_FranchiseEnquiry() { StepNo =1, MailMsg = new VM_MailMsg() { Subject = "Franchise Enquiry" }  };
            if (Session["FranchiseMessage"] != null)
            {
                viewModel.StepNo = 2;
                Session["FranchiseMessage"] = null;
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(VM_FranchiseEnquiry viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MailMsg msg = viewModel.MailMsg;
                    MailMessage message = new MailMessage();
                    message.From = new MailAddress("Franchise@JobJabs.com", "JobJabs - Franchise Enquiry ");
                    message.To.Add(new MailAddress(Convert.ToString(ConfigurationManager.AppSettings["FranchiseMailTo"])));
                    message.Subject = msg.Subject;
                    message.Body = "Name : " + msg.Name + " <br/> Email : " + msg.Email + " <br/> Contact  : " + msg.ContactNumber;
                    message.Body += " <br/> State  : " + msg.State + "<br/> City  : " + msg.City + " <br/> <br/>" + msg.Body;
                    BL_Mail.Send_Mail(message);
                    message = null; // free up resources
                    Session["FranchiseMessage"] = true;
                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {
                    WriteToLogClass.WriteErrorLog("Home", "Send Franchise Enquiry mail", ex);
                    return RedirectToAction("Index");
                }
            }
            return View(viewModel);
        }

        
    }
}