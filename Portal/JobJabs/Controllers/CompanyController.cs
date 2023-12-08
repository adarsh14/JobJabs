using JobJabs.BAL;
using JobJabs.Entity;
using JobJabs.Filters;
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
    [SessionFilter]
    [WriteToLogErrorHandler]
    public class CompanyController : CommonBaseController
    {
        public ActionResult Index()
        {
            VM_CompanyList viewModel = new VM_CompanyList();
            viewModel.CompanyList = BL_CompanyDetail.Get_AllCompanyByStatus(new CompanyDetail() { CompanyStatus = 1 }).ToList();
            return View(viewModel);
        }

        public ActionResult AddCompany()
        {
            VM_AddNewCompany viewModel = new VM_AddNewCompany() { CompanyDetail = new VM_CompanyDetail() };
            return View("AddCompany", viewModel);
        }

        [HttpPost]
        public ActionResult AddCompany(VM_AddNewCompany viewModel)
        {
            if (ModelState.IsValid)
            {
                CompanyDetail companyDetail = viewModel.CompanyDetail;
                companyDetail.CompanyCreatedBy = session.UserDetail.UserId;
                BL_CompanyDetail.Add_NewCompany(companyDetail);
                return RedirectToAction("Index", "Company");
            }
            return View("AddCompany", viewModel);
        }

        public ActionResult EditCompany()
        {
            VM_AddNewCompany viewModel = new VM_AddNewCompany();
            viewModel.CompanyDetail = BL_CompanyDetail.Get_CompanyByCompanyId(new CompanyDetail() { CompanyId = Request.ConvertToInt32("cid") });
            return View("EditCompany", viewModel);
        }

        [HttpPost]
        public ActionResult EditCompany(VM_AddNewCompany viewModel)
        {
            if (ModelState.IsValid)
            {
                CompanyDetail companyDetail = viewModel.CompanyDetail;
                companyDetail.CompanyCreatedBy = session.UserDetail.UserId;
                BL_CompanyDetail.Update_CompanyDetail(companyDetail);
                return RedirectToAction("Index", "Company");
            }
            return View("EditCompany", viewModel);
        }

        public ActionResult ChangeCompanyStatus()
        {
            CompanyDetail companyDetail = new CompanyDetail() { CompanyId = Request.ConvertToInt32("cid"), CompanyStatus = Request.ConvertToInt32("sts"), CompanyCreatedBy = session.UserDetail.UserId };
            BL_CompanyDetail.Change_CompanyStatus(companyDetail);
            return RedirectToAction("Index", "Company");
        }

        public ActionResult CompanyLocationList()
        {
            VM_CompanyLocationList viewModel = new VM_CompanyLocationList() {
                CompanyId= Request.ConvertToInt32("cid"),
                CompanyName = Request.ConvertToString("cn").Replace("&", "-").Replace(" ", "_")
            };
            viewModel.CompLocList = BL_CompanyDetail.Get_AllLocationByCompanyId(viewModel).ToList();
            return View(viewModel);
        }

        public ActionResult AddCompanyLocation()
        {
            VM_AddNewCompanyLocation viewModel = new VM_AddNewCompanyLocation()
            {
                CompLocDetail = new VM_CompanyLocationDetail() { CompanyId = Request.ConvertToInt32("cid") },
                CompanyName = Request.ConvertToString("cn").Replace("&", "-").Replace(" ", "_")
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddCompanyLocation(VM_AddNewCompanyLocation viewModel)
        {
            if (ModelState.IsValid)
            {
                CompanyLocationDetail compLocDetail = viewModel.CompLocDetail;
                compLocDetail.CompLocCreatedBy = session.UserDetail.UserId;
                if (compLocDetail.CompLocId == 0)
                {
                    BL_CompanyDetail.Add_NewCompanyLocation(compLocDetail);
                }
                else
                {
                    BL_CompanyDetail.Update_CompanyLocationDetail(compLocDetail);
                }
                return RedirectToAction("CompanyLocationList", "Company", new {
                    cid = viewModel.CompLocDetail.CompanyId,
                    cn = viewModel.CompanyName.Replace("&", "-").Replace(" ", "_")
                });
            }
            return View(viewModel);
        }

        public ActionResult EditCompanyLocation()
        {



            VM_AddNewCompanyLocation viewModel = new VM_AddNewCompanyLocation()
            {
                CompLocDetail = new VM_CompanyLocationDetail() { CompLocId = Request.ConvertToInt32("clid") }, 
                CompanyName = Request.ConvertToString("cn").Replace("&", "-").Replace(" ", "_")
            };
            viewModel.CompLocDetail = BL_CompanyDetail.Get_CompLocById(viewModel.CompLocDetail);
            return View("AddCompanyLocation", viewModel);
        }

        public ActionResult ChangeCompanyLocationStatus()
        {
            CompanyLocationDetail companyDetail = new CompanyLocationDetail() { CompLocId = Request.ConvertToInt32("clid"), CompLocStatus = Request.ConvertToInt32("sts"), CompLocCreatedBy  = session.UserDetail.UserId };
            BL_CompanyDetail.Change_CompanyLocationStatus(companyDetail);
            return RedirectToAction("CompanyLocationList", "Company", new
            {
                cid = Request.ConvertToInt32("cid"),
                cn = Request.ConvertToString("cn").Replace("&", "-").Replace(" ", "_")
            });
        }

    }
}