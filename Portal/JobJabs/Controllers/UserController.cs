using JobJabs.Entity;
using JobJabs.BAL;
using JobJabs.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobJabs.Filters;

namespace JobJabs.Controllers
{
    [SessionFilter]
    [WriteToLogErrorHandler]
    public class UserController : CommonBaseController
    {
        
        public ActionResult Index()
        {
            VM_UserList viewModel = FillUserList(Request.ConvertToInt32("UserType"));
            return View(viewModel);
        }

        public ActionResult AddSuperAdmin()
        {
            VM_AddNewUser viewModel = new VM_AddNewUser() { UserDetail = new VM_UserDetail() { UserType = (int)CommonClass.enumUserType.SuperAdmin } };
            return View("AddUser", viewModel);
        }
        public ActionResult AddSPOCAdmin()
        {
            VM_AddNewUser viewModel = new VM_AddNewUser() { UserDetail = new VM_UserDetail() { UserType = (int)CommonClass.enumUserType.SPOCAdmin } };
            return View("AddUser", viewModel);
           
        }

        public ActionResult AddRecruiter()
        {
            VM_AddNewUser viewModel = new VM_AddNewUser()
            {
                UserDetail = new VM_UserDetail() { UserType = (int)CommonClass.enumUserType.FranchiseRecruiter },
                FranchiseList = BL_FranchiseDetail.Get_AllFranchiseByStatus(new FranchiseDetail() { FranchiseStatus = 1 }).ToList()
            };
            return View("AddUser", viewModel);
        }

        [HttpPost]
        public ActionResult AddUser(VM_AddNewUser viewModel)
        {
            if (ModelState.IsValid)
            {
                UserDetail userDetail = viewModel.UserDetail;
                userDetail.Password = "123456";
                userDetail.CreatedBy = session.UserDetail.UserId;
                userDetail = BL_UserDetail.Add_NewUser(userDetail);
                if (userDetail.UserId > 0)
                {
                    if(userDetail.UserType== (int)CommonClass.enumUserType.FranchiseRecruiter)
                    {
                        FranchiseUserDetail franchiseUser = new FranchiseUserDetail() { FranchiseId = viewModel.FranchiseId, UserId = userDetail.UserId };
                        BL_FranchiseDetail.Add_NewFranchiseUser(franchiseUser);
                    }
                    return RedirectToAction("Index", "User",new { UserType= userDetail.UserType });
                }
                else
                {
                    viewModel.Message = "Username already exists";
                   
                }
            }
            if (viewModel.UserDetail.UserType == (int)CommonClass.enumUserType.FranchiseRecruiter)
            {
                viewModel.FranchiseList = BL_FranchiseDetail.Get_AllFranchiseByStatus(new FranchiseDetail() { FranchiseStatus = 1 }).ToList();
            }
            return View("AddUser", viewModel);
        }

        public ActionResult EditUser()
        {
            VM_AddNewUser viewModel = new VM_AddNewUser();
            viewModel.UserDetail = BL_UserDetail.Get_UserDetailByUserId(new UserDetail() { UserId = Request.ConvertToInt32("UserId") });
            return View("EditUser", viewModel);
        }

        [HttpPost]
        public ActionResult EditUser(VM_AddNewUser viewModel)
        {
            if (ModelState.IsValid)
            {
                UserDetail userDetail = viewModel.UserDetail;
                userDetail.CreatedBy = session.UserDetail.UserId;
                BL_UserDetail.Update_UserDetail(userDetail);
                return RedirectToAction("Index", "User", new { UserType = userDetail.UserType });
            }
            return View("EditUser", viewModel);
        }

        public ActionResult ChangeUserStatus()
        {
            UserDetail userDetail = new UserDetail() { UserId= Request.ConvertToInt32("UserId"), Status= Request.ConvertToInt32("sts"), CreatedBy=session.UserDetail.UserId,UserType = Request.ConvertToInt32("uty") };
            BL_UserDetail.Change_UserStatus(userDetail);
            return RedirectToAction("Index", "User", new { UserType = userDetail.UserType });
        }


        public ActionResult FranchiseList()
        {
            VM_FranchiseList viewModel = new VM_FranchiseList();
            viewModel.FranchiseList = BL_FranchiseDetail.Get_AllFranchiseByStatus(new FranchiseDetail() { FranchiseStatus = 1 }).ToList();
            return View(viewModel);
        }

        public ActionResult AddFranchiseAdmin()
        {
            VM_AddNewFranchise viewModel = new VM_AddNewFranchise() { FranchiseDetail  = new VM_FranchiseDetail() { UserType = (int)CommonClass.enumUserType.FranchiseAdmin, GenderId=1 } };
            return View("AddFranchiseAdmin", viewModel);
        }

        [HttpPost]
        public ActionResult AddFranchiseAdmin(VM_AddNewFranchise viewModel)
        {
            if (ModelState.IsValid)
            {
                AddFranchiseDTO dto = viewModel.FranchiseDetail;
                UserDetail userDetail = dto.UserDetail;
                userDetail.Password = "123456"; 
                userDetail.CreatedBy = session.UserDetail.UserId;
                userDetail = BL_UserDetail.Add_NewUser(userDetail);
                if (userDetail.UserId > 0)
                {
                    FranchiseDetail franchiseDetail = dto.FranchiseDetail;
                    franchiseDetail.UserId = userDetail.UserId;
                    franchiseDetail.FranchiseCreatedBy = session.UserDetail.UserId;
                    BL_FranchiseDetail.Add_NewFranchise(franchiseDetail);
                    return RedirectToAction("FranchiseList", "User");
                }
                else
                {
                    viewModel.Message = "Username already exists";
                    return View("AddFranchiseAdmin", viewModel);
                }
            }
            return View("AddFranchiseAdmin", viewModel);
        }

        public ActionResult EditFranchiseAdmin()
        {
            VM_AddNewFranchise viewModel = new VM_AddNewFranchise();
            viewModel.FranchiseDetail = BL_FranchiseDetail.Get_FranchiseByFranchiseId(new FranchiseDetail() { FranchiseId = Request.ConvertToInt32("FranchiseId") });
            return View("EditFranchiseAdmin", viewModel);
        }

        [HttpPost]
        public ActionResult EditFranchiseAdmin(VM_AddNewFranchise viewModel)
        {
            if (ModelState.IsValid)
            {
                AddFranchiseDTO dto = viewModel.FranchiseDetail;
                UserDetail userDetail = dto.UserDetail; 
                userDetail.CreatedBy = session.UserDetail.UserId;
                BL_UserDetail.Update_UserDetail(userDetail);
                FranchiseDetail franchiseDetail = dto.FranchiseDetail;
                franchiseDetail.UserId = userDetail.UserId;
                franchiseDetail.FranchiseCreatedBy = session.UserDetail.UserId;
                BL_FranchiseDetail.Update_FranchiseDetail(franchiseDetail);
                return RedirectToAction("FranchiseList", "User");
            }
            return View("EditFranchiseAdmin", viewModel);
        }

        public ActionResult ChangeFranchiseStatus()
        {
            FranchiseDetail franchiseDetail = new FranchiseDetail() { FranchiseId= Request.ConvertToInt32("fid"), FranchiseStatus = Request.ConvertToInt32("sts"), CreatedBy = session.UserDetail.UserId};
            BL_FranchiseDetail.Change_FranchiseStatus(franchiseDetail);
            return RedirectToAction("FranchiseList", "User");
        }

        public ActionResult RecruiterList()
        {
            VM_UserList viewModel = FillUserList(4,Request.ConvertToInt32("FranchiseId"));
            return View("Index", viewModel);
        }

        [HttpPost]
        public ActionResult RecruiterList(int franchiseId)
        {
            VM_UserList viewModel = FillUserList(4, franchiseId);
            return View("Index", viewModel);
        }

        private VM_UserList FillUserList(int userType, int franchiseId=0)
        {
            VM_UserList viewModel = new VM_UserList() { UserType = (userType == 0 ? (int)CommonClass.enumUserType.SPOCAdmin : userType) };
            if (viewModel.UserType == (int)CommonClass.enumUserType.FranchiseRecruiter)
            {
                viewModel.FranchiseList = BL_FranchiseDetail.Get_AllFranchiseByStatus(new FranchiseDetail() { FranchiseStatus = 1 }).ToList();
                viewModel.FranchiseId = (franchiseId == 0 ? (viewModel.FranchiseList.FranchiseDetail.Count > 0 ? viewModel.FranchiseList.FranchiseDetail.FirstOrDefault().FranchiseId : 0) : franchiseId);
                viewModel.UserList = BL_FranchiseDetail.Get_FranchiseUserByFranchiseId(new FranchiseDetail() { FranchiseId= viewModel.FranchiseId }).ToList();
            }
            else
            {
                viewModel.UserList = BL_UserDetail.Get_AllUserByUserType(new UserDetail() { UserType = viewModel.UserType }).ToList();

            }
            return viewModel;
        }

        public ActionResult AssignFranchise()
        {
            VM_AssignFranchise viewModel = new VM_AssignFranchise() { SPOCAdminId = Request.ConvertToInt32("spid"),  SPOCAdminName= Request.ConvertToString("un") };
            viewModel.FranchiseList = BL_FranchiseDetail.Get_AllFranchiseToSPOCAdmin(new SPOCFranchiseDetail() { SPOCAdminId = viewModel.SPOCAdminId });
            if(Session["Msg"] != null)
            {
                viewModel.Message = "Franchise is assigned successfully.";
                Session["Msg"] = null;
            }
                return View(viewModel);
        }

        [HttpPost]
        public ActionResult AssignFranchise(List<CheckModel> checkBox, string spocAdminName)
        {
            int spocAdminId = checkBox[0].ParentId;
            BL_FranchiseDetail.Delete_SPOCFranchiseAsgn(new SPOCFranchiseDetail() { SPOCAdminId= spocAdminId, CreatedBy= session.UserDetail.UserId });
            foreach (CheckModel item in checkBox)
            {
                if (item.Checked)
                {
                    SPOCFranchiseDetail spocFranchise = new SPOCFranchiseDetail()
                    {
                        SPOCAdminId = item.ParentId,
                         FranchiseId = item.Id,
                        CreatedBy = session.UserDetail.UserId
                    };
                    BL_FranchiseDetail.Assign_FranchiseToSPOCAdmin(spocFranchise);
                }

            }
            Session["Msg"] = 1;
            return RedirectToAction("AssignFranchise","User", new { spid= spocAdminId,un= spocAdminName });
        }
       
        public ActionResult ChangePassword()
        {
            VM_ChangePassword viewModel = new VM_ChangePassword() { DisplayType = 1 };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult ChangePassword(VM_ChangePassword viewModel)
        {
            if (ModelState.IsValid)
            {
                UserDetail userDetail = new UserDetail();
                userDetail.UserId = Convert.ToInt32(session.UserDetail.UserId);
                userDetail.Password = viewModel.Password;
                userDetail.IsPasswordValidated = 1;
                BL_UserDetail.Update_UserPassword(userDetail);
                return RedirectToAction("ChangePassword", "Login");
            }
            return View(viewModel);
        }

      
        

    }
}