using JobJabs.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobJabs.Entity
{
    public class CommonClass
    {
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public enum enumUserType
        {
            SuperAdmin = 1,
            SPOCAdmin = 2,
            FranchiseAdmin = 3,
            FranchiseRecruiter = 4
        }

        public enum enumCandidateStatus
        {
            CandidateAssignedToJob = 0,
            CandidateValidatedBySPOC = 1,
            CandidateRejectedBySPOC = 2,
            ResumeSentToHR = 3,
            InterviewScheduled = 4,
            SecondRoundSheduled = 5,
            FinalRoundScheduled = 6,
            InterviewRejected = 7,
            CandidateShortlisted = 8,
            CandidateSelected = 9,
            DocumentationPending = 10,
            CandidateJoined = 11,
            CandidateNotJoined = 12,
            CandidateBackOut = 13,
            NRC=14
        }

        public static string UserInitial(int userType)
        {
            if (userType == 1)
                return "SA";
            else if (userType == 2)
                return "SP";
            else if (userType == 3)
                return "FA";
            else
                return "R";
        }

        public static string UserTypeText(int userType)
        {
            if (userType == 1)
                return "Super Admin";
            else if (userType == 2)
                return "SPOC";
            else if (userType == 3)
                return "Franchise Admin";
            else
                return "Recruiter";
        }

        public static string CandidateStatusText(int status)
        {
            if (status == 0)
                return "New Candidate";
            else if (status == 1)
                return "Validated";
            else if (status == 2)
                return "Validation rejected";
            else if (status == 3)
                return "Turn Ups";
            else if (status == 4)
                return "Interview scheduled";
            else if (status == 5)
                return "2nd round scheduled";
            else if (status == 6)
                return "Final round scheduled";
            else if (status == 7)
                return "Interview Rejected ";
            else if (status == 8)
                return "Shortlisted";
            else if (status == 9)
                return "Selected";
            else if (status == 10)
                return "Documentation Pending";
            else if (status == 11)
                return "Joined";
            else if (status == 12)
                return "Not Joined";
            else if (status == 12)
                return "Back Out";
            else
                return "NRC";
        }

        public static string AddButtonText(int userType)
        {
            if (userType == 1)
                return "Add Super Admin";
            else if (userType == 2)
                return "Add SPOC";
            else if (userType == 3)
                return "Add Franchise Admin";
            else
                return "Add Recruiter";
        }

        public static string AddButtonLink(int userType)
        {
            if (userType == 1)
                return "AddSuperAdmin";
            else if (userType == 2)
                return "AddSPOCAdmin";
            else if (userType == 4)
                return "AddRecruiter";
            else
                return "AddRecruiter";
        }

        public static string DashboardLink(int userType)
        {
            if (userType == 1)
                return "SuperAdmin";
            else if (userType == 2)
                return "SPOCAdmin";
            else if (userType == 3)
                return "FranchiseAdmin";
            else
                return "Recruiter";
        }



        public static List<string> DashboardActionLink(UserDetail userDetail)
        {
            List<string> dLink = new List<string>();
            if (userDetail.IsPasswordValidated == 1)
            {
                if (userDetail.UserType == 1)
                {
                    dLink.Add("SuperAdmin");
                    dLink.Add("Index");
                }
                else if (userDetail.UserType == 2)
                {
                    dLink.Add("SPOCAdmin");
                    dLink.Add("Index");
                }
                else if (userDetail.UserType == 3)
                {
                    dLink.Add("FranchiseAdmin");
                    dLink.Add("Index");
                }
                else
                {
                    dLink.Add("Recruiter");
                    dLink.Add("Index");
                }
            }
            else
            {
                dLink.Add("User");
                dLink.Add("ChangePassword");
            }

            return dLink;
        }

        public static string ConvertTitle(string title)
        {
            return title.Replace("&", "_").Replace(" ", "-");
        }

        public static string ReConvertTitle(string title)
        {
            return title.Replace("_", "&").Replace("-", " ");
        }


        public static DDLList Get_CandidateStatus()
        {
            DDLList ddlCandidateStatus = new DDLList() { SelectItemList = new List<CustomDropDown>() };
            ddlCandidateStatus.SelectItemList.Add(new CustomDropDown() { Text = "CandidateAssignedToJob", Value = 1 });
            ddlCandidateStatus.SelectItemList.Add(new CustomDropDown() { Text = "CandidateValidatedBySPOC", Value = 2 });
            ddlCandidateStatus.SelectItemList.Add(new CustomDropDown() { Text = "CandidateRejectedBySPOC", Value = 3 });
            ddlCandidateStatus.SelectItemList.Add(new CustomDropDown() { Text = "ResumeSentToHR", Value = 4 });
            ddlCandidateStatus.SelectItemList.Add(new CustomDropDown() { Text = "InterviewScheduled", Value = 5 });
            ddlCandidateStatus.SelectItemList.Add(new CustomDropDown() { Text = "SecondRoundSheduled", Value = 6 });
            ddlCandidateStatus.SelectItemList.Add(new CustomDropDown() { Text = "FinalRoundScheduled", Value = 7 });
            ddlCandidateStatus.SelectItemList.Add(new CustomDropDown() { Text = "InterviewRejected", Value = 8 });
            ddlCandidateStatus.SelectItemList.Add(new CustomDropDown() { Text = "CandidateShortlisted", Value = 9 });
            ddlCandidateStatus.SelectItemList.Add(new CustomDropDown() { Text = "CandidateSelected", Value = 10 });
            ddlCandidateStatus.SelectItemList.Add(new CustomDropDown() { Text = "DocumentationPending", Value = 11 });
            ddlCandidateStatus.SelectItemList.Add(new CustomDropDown() { Text = "CandidateJoined", Value = 12 });
            ddlCandidateStatus.SelectItemList.Add(new CustomDropDown() { Text = "CandidateNotJoined", Value = 13 });
            ddlCandidateStatus.SelectItemList.Add(new CustomDropDown() { Text = "CandidateBackOut", Value = 14 });
            return ddlCandidateStatus;
        }

    }




    //    public enum enumQueryType
    //    {
    //        Add = 1,
    //        Update = 2,
    //        Get = 3,
    //        GetByMobileNumber = 31,
    //        ValidateAndGetByMobileNumber = 32,
    //        GetAll = 4,
    //        GetAllVariant = 41,
    //        GetAllBranded = 42,
    //        ChangeStatus = 5,
    //        GetAllByIds = 6,
    //        AddVariant = 11,
    //        Visited = 21,
    //        AddCustomerUserDetail = 111
    //    }

    //    public enum MarketingStatus
    //    {
    //        NewEnrtry = 0,
    //        SellerRegistered = 1,
    //        SellerInterested = 2,
    //        SellerNotInterested = 3
    //    }

    //    public enum TelemarketingStatus
    //    {
    //        NewEnrtry = 0,
    //        DataValidated = 1,
    //        SellerRegistered = 2,
    //        InvalidData = 3,
    //        SellerIsNotInterested = 4,
    //        GaveDemo = 20,
    //        SellerMayTakeAccount = 5,
    //        SellerWantsToMeetExecutive = 6,
    //        SellerWantsToTryFreeAccount = 7,
    //        MarketingTeam_ContactedOwner = 11,
    //        MarketingTeam_OwnerNotAvailable = 12,
    //        MarketingTeam_OwnerWillThinkAndTell = 13,
    //        MarketingTeam_OwnerToldToMeetLater = 14,
    //        SellerInterested = 21,
    //        SellerNotInterested = 31,
    //        ProductAdded = 51,
    //        SellerNotAvailable = 61
    //    }

    //    public enum TelemarketingReminderStatus
    //    {
    //        NewReminder = 0,
    //        ReminderSeen = 1,
    //        WorkedOnReminder = 2,
    //        NextReminderSet = 3
    //    }

    //    public enum enumCartStatus
    //    {
    //        New_Order_Cart = 1,
    //        Converted_To_Order_Cart = 2,
    //        InComplete_Cart = 3,
    //        Deleted_Cart = 4,
    //        Abandoned_Cart = 5,
    //        Rejected_Cart = 6
    //    }

    //    public enum enumCartItemStatus
    //    {
    //        Added = 1,
    //        Removed = 2,
    //        Cancelled = 3
    //    }

    //    public enum enumOrderItemStatus
    //    {
    //        Order_Placed = 1,
    //        Packed = 2,
    //        Shipped = 3,
    //        In_Transit = 4,
    //        Out_For_Delivery = 5,
    //        Delivered = 6,
    //        Reattempt_Delivery = 7,
    //        Cancelled_Order = 8,
    //    }

    //    public static string CartStatusText(int orderItemStatus)
    //    {
    //        if (orderItemStatus == 1)
    //            return "New Order Cart";
    //        else if (orderItemStatus == 2)
    //            return "Converted To Order Cart";
    //        else if (orderItemStatus == 3)
    //            return "InComplete Cart";
    //        else if (orderItemStatus == 4)
    //            return "Deleted Cart";
    //        else if (orderItemStatus == 5)
    //            return "Abandoned Cart";
    //        else
    //            return "Rejected Cart";
    //    }

    //    public static string OrderItemStatusText(int orderItemStatus)
    //    {
    //        if (orderItemStatus == 1)
    //            return "Order Placed";
    //        else if (orderItemStatus == 2)
    //            return "Packed";
    //        else if (orderItemStatus == 3)
    //            return "Shipped";
    //        else if (orderItemStatus == 4)
    //            return "In Transit";
    //        else if (orderItemStatus == 5)
    //            return "Out For Delivery";
    //        else if (orderItemStatus == 6)
    //            return "Delivered";
    //        else if (orderItemStatus == 7)
    //            return "Reattempt Delivery";
    //        else
    //            return "Cancelled Order";
    //    }


    //    public enum enumReturnStatus
    //    {
    //        ReturnRequested = 1,
    //        ReturnAccepted = 2,
    //        Rejected = 3,
    //        Picked = 4,
    //        ReachedDestination = 5,
    //        MoneyRefunded = 6
    //    }


    //    public static string ReturnStatusText(int returnStatus)
    //    {
    //        if (returnStatus == 1)
    //            return "Return Placed";
    //        else if (returnStatus == 2)
    //            return "Return Accepted";
    //        else if (returnStatus == 3)
    //            return "Return Rejected";
    //        else if (returnStatus == 4)
    //            return "Picked";
    //        else if (returnStatus == 5)
    //            return "Reached Destination";
    //        else
    //            return "Refund Completed";
    //    }

    //    public enum enumReturnCommentType
    //    {
    //        SuperAdminComment = 1,
    //        AdminComment = 2,
    //        ManagerComment = 3,
    //        ExecutiveComment = 4,
    //        CustomerComment = 5
    //    }

    //    public enum enumReasonType
    //    {
    //        CustomerCancelOrderReason = 1,
    //        AdminCancelOrderReason = 2,
    //        CustomerReturnOrderReason = 3,
    //        AdminRejectsReturnReason = 4,
    //        AdminRejectsCartReason = 5
    //    }



    //    public enum enumAdsType
    //    {
    //        Sell = 1,
    //        Buy = 2
    //    }

    //    public enum enumMaketProductStatus
    //    {
    //        New = 100,
    //        Active = 1,
    //        SoldOut = 2,
    //        Rejected = 3,
    //        Expired = 4
    //    }

    //    public enum enumEcomProductStatus
    //    {
    //        New = 0,
    //        Active = 1,
    //        Inactive = 2,
    //        Deleted = 3,
    //        Rejected = 4,
    //        ImageNotProper = 5,
    //        InCompleteData = 6,
    //        ValidatedByExecutive = 7,
    //        ValidatedByManager = 8,
    //        ValidatedByAdmin = 9
    //    }

    //    public enum enumProductType
    //    {
    //        SingleProduct = 1,
    //        CatlogProduct = 2,
    //        MultipleProduct = 3
    //    }

    //    public enum enumMessageStatus
    //    {
    //        New = 100,
    //        Active = 1,
    //        Inactive = 2,
    //        NotInterested = 3,
    //        ReortAbuse = 4
    //    }


    //    public enum AdManagementStatus
    //    {
    //        New = 1,
    //        ActiveVisited = 2,
    //        Purchased = 3
    //    }

    //    public enum enumBusinessType
    //    {
    //        ShopOnline = 1,
    //        MarketPlace = 2,
    //        BusinessListing = 3,
    //        BookStore = 4,
    //        Vehicle = 5,
    //        Property = 6
    //    }

    //    public enum enumShopType
    //    {
    //        SingleStore = 1,
    //        MultiStoreMain = 2,
    //        MultiSingleStore = 3,
    //        Wholesaler = 4,
    //        ECommerceStore = 5,
    //        ECommerceSingleStore = 51,
    //        ECommerceMultiStore = 52,
    //        ECommerceWholesaler = 54
    //    }

    //    public enum enumControlType
    //    {
    //        Textbox = 1,
    //        DropDownList = 2,
    //        TextArea = 3,
    //        CheckBox = 4,
    //        RadioButton = 5
    //    }

    //    public enum enumPaymentSource
    //    {
    //        COD = 1,
    //        NetBanking = 2,
    //        DebitCard = 3,
    //        CreditCard = 4,
    //        PAYTM = 5,
    //        GooglePay = 6,
    //        PhonePe = 7
    //    }


    //    public enum enumSiteType
    //    {
    //        ShopOnline = 1,
    //        MarketPlace = 2,
    //        BusinessListing = 3,
    //        ALL = 4,
    //        ShopOnline_MarketPlace = 5,
    //        ShopOnline_BusinessListing = 6,
    //        MarketPlace_BusinessListing = 7
    //    }

    //    public enum enumPurchaseStatus
    //    {
    //        NewRFQ = 1,
    //        RFQSent = 2
    //    }

    //    public enum enumAdminUserType
    //    {
    //        SuperAdmin = 101,
    //        SiteAdmin = 102,
    //        SiteManager = 103,
    //        SiteExecutive = 104
    //    }

    //    public enum enumUserType
    //    {
    //        Customer = 1,
    //        ShopOwnerAdmin = 2,
    //    }

    //    public enum enumShopImageType
    //    {
    //        Banner = 1,
    //        Gallery = 2
    //    }

    //    public enum WarrantyType
    //    {
    //        NoWarranty = 1,
    //        OneTimeReplacementWarranty = 2,
    //        ReplacementWarranty = 3,
    //        SevenDaysWarranty = 4,
    //        FifteenDaysWarranty = 5,
    //        ThirtyDaysWarranty = 6
    //    }

    //    public enum enumWishlistStatus
    //    {
    //        Active = 1,
    //        Inactive = 2
    //    }

    //    public static string FunctionPrefix(int queryType)
    //    {
    //        if (queryType == 1)
    //            return "Add_";
    //        else if (queryType == 2)
    //            return "Update_";
    //        else if (queryType == 3)
    //            return "Get_";
    //        else if (queryType == 31)
    //            return "GetByMobileNumber";
    //        else if (queryType == 32)
    //            return "ValidateAndGet_";
    //        else if (queryType == 4)
    //            return "GetAll_";
    //        else if (queryType == 41)
    //            return "GetAllVariant_";
    //        else if (queryType == 42)
    //            return "GetAllBranded_";
    //        else if (queryType == 5)
    //            return "ChangeStatus_";
    //        else if (queryType == 11)
    //            return "AddVariant_";
    //        else if (queryType == 111)
    //            return "Add_UserDetail_";
    //        else
    //            return "GetAllByIds_";

    //    }

    //    public static string OrderStatusText(int statusId)
    //    {
    //        if (statusId == 1)
    //            return "Order Placed";
    //        else if (statusId == 2)
    //            return "Payment Is Not Confirmed";
    //        else if (statusId == 3)
    //            return "Your item is ready for Shipment";
    //        else if (statusId == 4)
    //            return "Your item is Shiped";
    //        else if (statusId == 5)
    //            return "In Transit";
    //        else if (statusId == 6)
    //            return "Out For Delivery";
    //        else if (statusId == 7)
    //            return "Item Delivered Successfully";
    //        else if (statusId == 8)
    //            return "Customer rejected the product";
    //        else if (statusId == 9)
    //            return "Customer was not present at the given Address";
    //        else if (statusId == 10)
    //            return "Customer returned the product";
    //        else if (statusId == 11)
    //            return "Incorrect Address";
    //        else
    //            return "";

    //    }




    //    public static List<CustomDropDown> Get_CartStatusDropDown()
    //    {
    //        List<CustomDropDown> lstCartStatus = Enum.GetValues(typeof(CommonClass.enumCartStatus)).Cast<CommonClass.enumCartStatus>
    //           ().Select(x => new CustomDropDown { Text = x.ToString().Replace("_", " "), Value = ((int)x) }).ToList();
    //        lstCartStatus.Insert(0, new CustomDropDown { Text = "Select Cart Status", Value = 0 });
    //        return lstCartStatus;
    //    }

    //    public static List<CustomDropDown> Get_OrderStatusDropDown()
    //    {
    //        List<CustomDropDown> lstOrderStatus = Enum.GetValues(typeof(CommonClass.enumOrderItemStatus)).Cast<CommonClass.enumOrderItemStatus>
    //           ().Select(x => new CustomDropDown { Text = x.ToString().Replace("_", " "), Value = ((int)x)}).ToList();
    //        lstOrderStatus.Insert(0, new CustomDropDown { Text = "Select Order Status", Value = 0 });
    //        return lstOrderStatus;
    //    }

    //    public static List<CustomDropDown> Get_ReturnOrderStatusDropDown()
    //    {
    //        List<CustomDropDown> lstReturnOrderStatus = Enum.GetValues(typeof(CommonClass.enumReturnStatus)).Cast<CommonClass.enumReturnStatus>
    //        ().Select(x => new CustomDropDown { Text = CommonClass.ReturnStatusText(((int)x)), Value = ((int)x) }).ToList();
    //        lstReturnOrderStatus.Insert(0, new CustomDropDown { Text = "Select Return Order Status", Value = 0 });
    //        return lstReturnOrderStatus;
    //    }

    //    public static List<CustomDropDown> Get_PaymentSourceDropDown()
    //    {
    //        List<CustomDropDown> lstPaymentSource = Enum.GetValues(typeof(CommonClass.enumPaymentSource)).Cast<CommonClass.enumPaymentSource>
    //      ().Select(x => new CustomDropDown { Text = x.ToString().Replace("_", " "), Value = ((int)x) }).ToList();
    //        lstPaymentSource.Insert(0, new CustomDropDown { Text = "Select Payment Source", Value = 0 });
    //        return lstPaymentSource;
    //    }

    //    public static string ShopProductStatusText(int statusId)
    //    {
    //        if (statusId == 0)
    //            return "New";
    //        else if (statusId == 1)
    //            return "Active";
    //        else if (statusId == 2)
    //            return "InActive";
    //        else if (statusId == 10)
    //            return "Validated By Manager";
    //        else if (statusId == 11)
    //            return "Validated By Admin";
    //        else if (statusId == 21)
    //            return "Deals";
    //        else if (statusId == 22)
    //            return "Status - 22";
    //        else if (statusId == 23)
    //            return "Status - 23";
    //        else if (statusId == 24)
    //            return "Status - 24";
    //        else if (statusId == 25)
    //            return "Status - 25";
    //        else if (statusId == 3)
    //            return "Other";
    //        else
    //            return "";

    //    }


    //    public static string Get_OrderNumber(int orderId)
    //    {
    //        return (orderId > 0 ? ("AZ000" + Convert.ToString(orderId)) : "Not Generated");
    //    }

    //    public static string Get_ReturnOrderNumber(int returnOrderId)
    //    {
    //        return (returnOrderId > 0 ? ("RZ000" + Convert.ToString(returnOrderId)) : "Not Generated");
    //    }

    //    //        public enum enumCustomerRegistrationStatus
    //    //        {
    //    //            New = 1,
    //    //            Error = -1,
    //    //            Update = -2,
    //    //            AlreadyExists = -3
    //    //        }

    //    //        public enum enumCustomerLoginStatus
    //    //        {
    //    //            Valid = 1,
    //    //            Error = -1,
    //    //            Invalid = -2
    //    //        }

    //    //        public static string GetCityName(string CityId)
    //    //        {
    //    //            string Cityname = "";
    //    //            switch (CityId)
    //    //            {
    //    //                case "1":
    //    //                    Cityname = "Mumbai";
    //    //                    break;
    //    //                case "2":
    //    //                    Cityname = "Navi Mumbai";
    //    //                    break;
    //    //                case "3":
    //    //                    Cityname = "Thane";
    //    //                    break;
    //    //                case "4":
    //    //                    Cityname = "Kalyan";
    //    //                    break;
    //    //                default:
    //    //                    Cityname = "Others";
    //    //                    break;

    //    //            }
    //    //            return Cityname;
    //    //        }

    //    //        public static string GetWebSource(string WebSourceId)
    //    //        {
    //    //            string WebSource = "";
    //    //            switch (WebSourceId)
    //    //            {
    //    //                case "1":
    //    //                    WebSource = "Email";
    //    //                    break;
    //    //                case "2":
    //    //                    WebSource = "Google";
    //    //                    break;
    //    //                case "3":
    //    //                    WebSource = "Word of mouth";
    //    //                    break;
    //    //                default:
    //    //                    WebSource = "Others";
    //    //                    break;

    //    //            }
    //    //            return WebSource;
    //    //        }


    //    //        public enum enumUserType
    //    //        {
    //    //            Admin = 1,
    //    //            Merchant = 2
    //    //        }



    //    //        public static string CouponImage
    //    //        {
    //    //            get
    //    //            {
    //    //                if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["CouponImage"].ToString()))
    //    //                {
    //    //                    return System.Configuration.ConfigurationManager.AppSettings["CouponImage"].ToString();
    //    //                }
    //    //                return "";
    //    //            }
    //    //        }

    //    //        public static string MobileCouponImage
    //    //        {
    //    //            get
    //    //            {
    //    //                if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["CouponImage"].ToString()))
    //    //                {
    //    //                    return System.Configuration.ConfigurationManager.AppSettings["CouponImage"].ToString() + "Mobile/";
    //    //                }
    //    //                return "";
    //    //            }
    //    //        }

    //    //        public static string MobileProductImage
    //    //        {
    //    //            get
    //    //            {
    //    //                if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["ProductImage"].ToString()))
    //    //                {
    //    //                    return System.Configuration.ConfigurationManager.AppSettings["ProductImage"].ToString() + "Mobile/";
    //    //                }
    //    //                return "";
    //    //            }
    //    //        }

    //    //        public static string MainBanner
    //    //        {
    //    //            get
    //    //            {
    //    //                if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["MainBanner"].ToString()))
    //    //                {
    //    //                    return System.Configuration.ConfigurationManager.AppSettings["MainBanner"].ToString();
    //    //                }
    //    //                return "";
    //    //            }
    //    //        }

    //    //        public static string StoreImages
    //    //        {
    //    //            get
    //    //            {
    //    //                if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["StoreImages"].ToString()))
    //    //                {
    //    //                    return System.Configuration.ConfigurationManager.AppSettings["StoreImages"].ToString();
    //    //                }
    //    //                return "";
    //    //            }
    //    //        }

    //    //        public static string ProfileImages
    //    //        {
    //    //            get
    //    //            {
    //    //                if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["ImagePath"].ToString()))
    //    //                {
    //    //                    return System.Configuration.ConfigurationManager.AppSettings["ImagePath"].ToString() + "ProfileImages/";
    //    //                }
    //    //                return "";
    //    //            }
    //    //        }



    //    //        public static string TransportImages
    //    //        {
    //    //            get
    //    //            {
    //    //                if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["ImagePath"].ToString()))
    //    //                {
    //    //                    return System.Configuration.ConfigurationManager.AppSettings["ImagePath"].ToString() + "TransportImages/";
    //    //                }
    //    //                return "";
    //    //            }
    //    //        }

    //    //        public static string TailorImages
    //    //        {
    //    //            get
    //    //            {
    //    //                if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["ImagePath"].ToString()))
    //    //                {
    //    //                    return System.Configuration.ConfigurationManager.AppSettings["ImagePath"].ToString() + "TailorImages/";
    //    //                }
    //    //                return "";
    //    //            }
    //    //        }

    //    //        public static string BrandBanner
    //    //        {
    //    //            get
    //    //            {
    //    //                if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["BrandBanner"].ToString()))
    //    //                {
    //    //                    return System.Configuration.ConfigurationManager.AppSettings["BrandBanner"].ToString();
    //    //                }
    //    //                return "";
    //    //            }
    //    //        }

    //    //        public static string BrandLogo
    //    //        {
    //    //            get
    //    //            {
    //    //                if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["BrandLogo"].ToString()))
    //    //                {
    //    //                    return System.Configuration.ConfigurationManager.AppSettings["BrandLogo"].ToString();
    //    //                }
    //    //                return "";
    //    //            }
    //    //        }

    //    public static string LoginName
    //    {
    //        get
    //        {
    //            if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["LoginName"].ToString()))
    //            {
    //                return System.Configuration.ConfigurationManager.AppSettings["LoginName"].ToString();
    //            }
    //            return "";
    //        }
    //    }

    //    public static string Password
    //    {
    //        get
    //        {
    //            if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["Password"].ToString()))
    //            {
    //                return System.Configuration.ConfigurationManager.AppSettings["Password"].ToString() + "@123";
    //            }
    //            return "";
    //        }
    //    }

    //    public static string FormatProductName(string str)
    //    {
    //        if (!string.IsNullOrEmpty(str))
    //        {
    //            return str.Replace(" ", "-").Replace("&", "-").Replace("---", "-");
    //        }
    //        return "";
    //    }

    //    //        public static string AdminName
    //    //        {
    //    //            get
    //    //            {
    //    //                if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["AdminName"].ToString()))
    //    //                {
    //    //                    return System.Configuration.ConfigurationManager.AppSettings["AdminName"].ToString();
    //    //                }
    //    //                return "";
    //    //            }
    //    //        }

    //    //        public static string ProductListPath
    //    //        {
    //    //            get
    //    //            {
    //    //                if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["ProductListPath"].ToString()))
    //    //                {
    //    //                    return System.Configuration.ConfigurationManager.AppSettings["ProductListPath"].ToString();
    //    //                }
    //    //                return "";
    //    //            }
    //    //        }


    //    //        public static string ProductDetailPath
    //    //        {
    //    //            get
    //    //            {
    //    //                if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["ProductDetailPath"].ToString()))
    //    //                {
    //    //                    return System.Configuration.ConfigurationManager.AppSettings["ProductDetailPath"].ToString();
    //    //                }
    //    //                return "";
    //    //            }
    //    //        }

    //    //        public static string ProductImage
    //    //        {
    //    //            get
    //    //            {
    //    //                if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["ImagePath"].ToString()))
    //    //                {
    //    //                    return System.Configuration.ConfigurationManager.AppSettings["ImagePath"].ToString() + "Product/";
    //    //                }
    //    //                return "";
    //    //            }
    //    //        }

    //    //        public static string MainBannerImage
    //    //        {
    //    //            get
    //    //            {
    //    //                if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["ImagePath"].ToString()))
    //    //                {
    //    //                    return System.Configuration.ConfigurationManager.AppSettings["ImagePath"].ToString() + "MainBanner/";
    //    //                }
    //    //                return "";
    //    //            }
    //    //        }

    //    //        public static string CategoryImage
    //    //        {
    //    //            get
    //    //            {
    //    //                if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["ImagePath"].ToString()))
    //    //                {
    //    //                    return System.Configuration.ConfigurationManager.AppSettings["ImagePath"].ToString() + "Category/";
    //    //                }
    //    //                return "";
    //    //            }
    //    //        }

    //    //        public static string SubCategoryImage
    //    //        {
    //    //            get
    //    //            {
    //    //                if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["ImagePath"].ToString()))
    //    //                {
    //    //                    return System.Configuration.ConfigurationManager.AppSettings["ImagePath"].ToString() + "SubCategory/";
    //    //                }
    //    //                return "";
    //    //            }
    //    //        }

    //    //        public static string EntityImage
    //    //        {
    //    //            get
    //    //            {
    //    //                if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["ImagePath"].ToString()))
    //    //                {
    //    //                    return System.Configuration.ConfigurationManager.AppSettings["ImagePath"].ToString() + "Entity/";
    //    //                }
    //    //                return "";
    //    //            }
    //    //        }

    //    //        public static string FunctionAreaImage
    //    //        {
    //    //            get
    //    //            {
    //    //                if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["ImagePath"].ToString()))
    //    //                {
    //    //                    return System.Configuration.ConfigurationManager.AppSettings["ImagePath"].ToString() + "FunctionalArea/";
    //    //                }
    //    //                return "";
    //    //            }
    //    //        }

    //    //        public static string KeySkillImage
    //    //        {
    //    //            get
    //    //            {
    //    //                if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["ImagePath"].ToString()))
    //    //                {
    //    //                    return System.Configuration.ConfigurationManager.AppSettings["ImagePath"].ToString() + "KeySkill/";
    //    //                }
    //    //                return "";
    //    //            }
    //    //        }

    //    //        //public static string ShopBannerImage
    //    //        //{
    //    //        //    get
    //    //        //    {
    //    //        //        if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["ImagePath"].ToString()))
    //    //        //        {
    //    //        //            return System.Configuration.ConfigurationManager.AppSettings["ImagePath"].ToString() + "Shop/";
    //    //        //        }
    //    //        //        return "";
    //    //        //    }
    //    //        //}

    //    //public static string ShopImagePath
    //    //{
    //    //    get
    //    //    {
    //    //        if (string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["ImageSource"].ToString()))
    //    //        {
    //    //            if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["ImagePath"].ToString()))
    //    //            {
    //    //                return System.Configuration.ConfigurationManager.AppSettings["ImagePath"].ToString() + "Shop/";
    //    //            }
    //    //        }
    //    //        return "~/Images/Shop/";
    //    //    }
    //    //}

    //    //public static string ShopImageSerevrPath
    //    //{
    //    //    get
    //    //    {
    //    //        return Path.Combine(HttpContext.Current.Server.MapPath(ConfigSetting.ImageServerPath) + "Shop/");
    //    //    }
    //    //}

    //    //        public static string ProductImagePath
    //    //        {
    //    //            get
    //    //            {
    //    //                if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["ImagePath"].ToString()))
    //    //                {
    //    //                    return System.Configuration.ConfigurationManager.AppSettings["ImagePath"].ToString() + "Product/";
    //    //                }
    //    //                return "";
    //    //            }
    //    //        }

    //    //        public static string ProductImageSerevrPath
    //    //        {
    //    //            get
    //    //            {
    //    //                return Path.Combine(HttpContext.Current.Server.MapPath(ConfigSetting.ImageServerPath) + "Product/");
    //    //            }
    //    //        }

    //    //        public static string SLGradientImagePath
    //    //        {
    //    //            get
    //    //            {
    //    //                if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["ImagePath"].ToString()))
    //    //                {
    //    //                    return System.Configuration.ConfigurationManager.AppSettings["ImagePath"].ToString() + "ShopListingGradient/";
    //    //                }
    //    //                return "";
    //    //            }
    //    //        }

    //    //        public static string StoreFrontImagePath
    //    //        {
    //    //            get
    //    //            {
    //    //                if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["ImagePath"].ToString()))
    //    //                {
    //    //                    return System.Configuration.ConfigurationManager.AppSettings["ImagePath"].ToString() + "StoreFront/";
    //    //                }
    //    //                return "";
    //    //            }
    //    //        }

    //    //        public static string SDGradientImagePath
    //    //        {
    //    //            get
    //    //            {
    //    //                if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["ImagePath"].ToString()))
    //    //                {
    //    //                    return System.Configuration.ConfigurationManager.AppSettings["ImagePath"].ToString() + "ShopDetailGradient/";
    //    //                }
    //    //                return "";
    //    //            }
    //    //        }



    //    //        //public static string GetProductListPath(ProductDetail obj)
    //    //        //{
    //    //        //    return ProductDetailPath + obj.Category + "/" + obj.SubCategory + "/" + obj.ProductName.Replace(" ", "").Replace("&", "").Replace(",", "") + "?id=" + obj.ProductId;
    //    //        //}

    //    //        //public static string GetProductDetailPath(ProductDetail obj)
    //    //        //{
    //    //        //    return ProductDetailPath + obj.Category + "/" + obj.SubCategory + "/" + obj.ProductName.Replace(" ", "").Replace("&", "").Replace(",", "") + "?id=" + obj.ProductId;
    //    //        //}

    //    //        //  public static string PortalPath
    //    //        //{
    //    //        //    get
    //    //        //    {
    //    //        //        if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["PortalPath"].ToString()))
    //    //        //        {
    //    //        //            return System.Configuration.ConfigurationManager.AppSettings["PortalPath"].ToString();
    //    //        //        }
    //    //        //        return "";
    //    //        //    }
    //    //        //}


    //    //        public static int Get_CategoryId(string ControllerName)
    //    //        {
    //    //            if (ControllerName.ToLower().Trim() == "clothingcontroller")
    //    //                return 1;
    //    //            else if (ControllerName.ToLower().Trim() == "shoescontroller")
    //    //                return 2;
    //    //            else if (ControllerName.ToLower().Trim() == "furniturecontroller")
    //    //                return 3;
    //    //            else if (ControllerName.ToLower().Trim() == "healthcarecontroller")
    //    //                return 4;
    //    //            else if (ControllerName.ToLower().Trim() == "fitnesscontroller")
    //    //                return 5;
    //    //            else if (ControllerName.ToLower().Trim() == "servicecentercontroller")
    //    //                return 6;
    //    //            else
    //    //                return 1;

    //    //        }

    //    //        public static int Get_SubCategoryId(int CategoryId, string SubcategoryName)
    //    //        {
    //    //            if (CategoryId == 1 && SubcategoryName.Trim() == "men")
    //    //                return 101;
    //    //            else if (CategoryId == 1 && SubcategoryName.Trim() == "women")
    //    //                return 102;
    //    //            else if (CategoryId == 1 && SubcategoryName.Trim() == "kids")
    //    //                return 103;
    //    //            else if (CategoryId == 2 && SubcategoryName.Trim() == "men")
    //    //                return 201;
    //    //            else if (CategoryId == 2 && SubcategoryName.Trim() == "Women")
    //    //                return 202;
    //    //            else if (CategoryId == 2 && SubcategoryName.Trim() == "kids")
    //    //                return 203;
    //    //            else if (CategoryId == 3 && SubcategoryName.Trim() == "livingroom")
    //    //                return 301;
    //    //            else if (CategoryId == 3 && SubcategoryName.Trim() == "bedroom")
    //    //                return 302;
    //    //            else if (CategoryId == 3 && SubcategoryName.Trim() == "diningroom")
    //    //                return 303;
    //    //            else if (CategoryId == 3 && SubcategoryName.Trim() == "wardrobes")
    //    //                return 304;
    //    //            else if (CategoryId == 4 && SubcategoryName.Trim() == "skinCare")
    //    //                return 401;
    //    //            else if (CategoryId == 4 && SubcategoryName.Trim() == "bodycontouring")
    //    //                return 402;
    //    //            else if (CategoryId == 4 && SubcategoryName.Trim() == "dentalcare")
    //    //                return 403;
    //    //            else if (CategoryId == 4 && SubcategoryName.Trim() == "wellness")
    //    //                return 404;
    //    //            else if (CategoryId == 5 && SubcategoryName.Trim() == "gym")
    //    //                return 501;
    //    //            else if (CategoryId == 5 && SubcategoryName.Trim() == "yoga")
    //    //                return 502;
    //    //            else if (CategoryId == 5 && SubcategoryName.Trim() == "dance")
    //    //                return 503;
    //    //            else
    //    //                return 101;


    //    //        }
    //    //        public static int ValidateInteger(string IntegerToValidate)
    //    //        {
    //    //            IntegerToValidate = (IntegerToValidate == null ? "0" : IntegerToValidate);
    //    //            int value;
    //    //            if (!int.TryParse(IntegerToValidate, out value))
    //    //            {
    //    //                IntegerToValidate = "0";
    //    //            }
    //    //            return Convert.ToInt32(IntegerToValidate);
    //    //        }

    //    //        public static string ValidateString(string StringToValidate)
    //    //        {
    //    //            StringToValidate = (StringToValidate == null ? "" : StringToValidate);

    //    //            return StringToValidate;
    //    //        }

    //    //        public static Decimal ValidateDecimal(string DecimalToValidate)
    //    //        {
    //    //            DecimalToValidate = (DecimalToValidate == null ? "0" : DecimalToValidate);
    //    //            decimal value;
    //    //            if (!decimal.TryParse(DecimalToValidate, out value))
    //    //            {
    //    //                int ivalue;
    //    //                if (!int.TryParse(DecimalToValidate, out ivalue))
    //    //                {
    //    //                    DecimalToValidate = "0";
    //    //                }
    //    //            }

    //    //            return Convert.ToDecimal(DecimalToValidate);
    //    //        }

    //    //        private static Random random = new Random();
    //    //        public static string RandomString(int length)
    //    //        {
    //    //            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    //    //            return new string(Enumerable.Repeat(chars, length)
    //    //              .Select(s => s[random.Next(s.Length)]).ToArray());
    //    //        }

    //    //        public static Bitmap ResizeImage(System.Drawing.Image img, int htOfImage, int maxOfWidth = 0)
    //    //        {
    //    //            int width = Convert.ToInt32(Convert.ToDouble(img.Width) *
    //    //            (Convert.ToDouble(htOfImage) / Convert.ToDouble(img.Height)));
    //    //            if (maxOfWidth != 0)
    //    //            {
    //    //                if (width > maxOfWidth)
    //    //                {
    //    //                    htOfImage = Convert.ToInt32(Convert.ToDouble(img.Height) *
    //    //                    (Convert.ToDouble(maxOfWidth) / Convert.ToDouble(img.Width)));
    //    //                    width = maxOfWidth;
    //    //                }
    //    //            }
    //    //            System.Drawing.Size s = new System.Drawing.Size(width, htOfImage);
    //    //            System.Drawing.Bitmap resizedImg = Resize(img, s, true);
    //    //            return resizedImg;
    //    //        }

    //    //        public static Bitmap Resize(System.Drawing.Image image,
    //    //     System.Drawing.Size size, bool preserveAspectRatio = true, bool IsBackgroundColor = false)
    //    //        {
    //    //            int newWidth;
    //    //            int newHeight;
    //    //            if (preserveAspectRatio)
    //    //            {
    //    //                int originalWidth = image.Width;
    //    //                int originalHeight = image.Height;
    //    //                float percentWidth = (float)size.Width / (float)originalWidth;
    //    //                float percentHeight = (float)size.Height / (float)originalHeight;
    //    //                float percent = percentHeight < percentWidth ? percentHeight : percentWidth;
    //    //                newWidth = (int)(originalWidth * percent);
    //    //                newHeight = (int)(originalHeight * percent);
    //    //            }
    //    //            else
    //    //            {
    //    //                newWidth = size.Width;
    //    //                newHeight = size.Height;
    //    //            }

    //    //            int x = size.Width;
    //    //            int y = size.Height;

    //    //            Bitmap outputImage = new Bitmap(x, y, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
    //    //            using (System.Drawing.Graphics graphicsHandle = System.Drawing.Graphics.FromImage(outputImage))
    //    //            {
    //    //                if (IsBackgroundColor == true)
    //    //                {
    //    //                    graphicsHandle.Clear(Color.White);
    //    //                }
    //    //                graphicsHandle.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
    //    //                graphicsHandle.InterpolationMode =
    //    //                           System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
    //    //                graphicsHandle.DrawImage(image, (outputImage.Width / 2) - (newWidth / 2),
    //    //                       (outputImage.Height / 2) - (newHeight / 2), newWidth, newHeight);
    //    //            }

    //    //            return outputImage;
    //    //        }




    //    //    }




    //    //    //public class DDLList
    //    //    //{
    //    //    //    public List<CustomDropDown> SelectItemList { get; set; }

    //    //    //    public static implicit operator DDLList(List<CategoryMaster>  model)
    //    //    //    {
    //    //    //        return new DDLList()
    //    //    //        {
    //    //    //            SelectItemList = (from item in model
    //    //    //                              select new CustomDropDown()
    //    //    //                              {
    //    //    //                                  Text = item.CategoryName,
    //    //    //                                  Value = item.CategoryId 
    //    //    //                              }
    //    //    //                     ).ToList()
    //    //    //        };
    //    //    //    }

    //    //    //    public static implicit operator DDLList(List<SubCategoryMaster> model)
    //    //    //    {
    //    //    //        return new DDLList()
    //    //    //        {
    //    //    //            SelectItemList = (from item in model
    //    //    //                              select new CustomDropDown()
    //    //    //                              {
    //    //    //                                  Text = item.SubCategoryName,
    //    //    //                                  Value = item.SubCategoryId
    //    //    //                              }
    //    //    //                     ).ToList()
    //    //    //        };
    //    //    //    }

    //    //    //    public static implicit operator DDLList(List<EntityMaster > model)
    //    //    //    {
    //    //    //        return new DDLList()
    //    //    //        {
    //    //    //            SelectItemList = (from item in model
    //    //    //                              select new CustomDropDown()
    //    //    //                              {
    //    //    //                                  Text = item.Entity ,
    //    //    //                                  Value = item.EntityId
    //    //    //                              }
    //    //    //                     ).ToList()
    //    //    //        };
    //    //    //    }

    //    //    //    public static implicit operator DDLList(List<FunctionalAreaMaster > model)
    //    //    //    {
    //    //    //        return new DDLList()
    //    //    //        {
    //    //    //            SelectItemList = (from item in model
    //    //    //                              select new CustomDropDown()
    //    //    //                              {
    //    //    //                                  Text = item.FunctionalArea,
    //    //    //                                  Value = item.FunctionalAreaId 
    //    //    //                              }
    //    //    //                     ).ToList()
    //    //    //        };
    //    //    //    }

    //    //    //    public static implicit operator DDLList(List<KeySkillMaster > model)
    //    //    //    {
    //    //    //        return new DDLList()
    //    //    //        {
    //    //    //            SelectItemList = (from item in model
    //    //    //                              select new CustomDropDown()
    //    //    //                              {
    //    //    //                                  Text = item.KeySkill,
    //    //    //                                  Value = item.KeySkillId 
    //    //    //                              }
    //    //    //                     ).ToList()
    //    //    //        };
    //    //    //    }


    //    //    //}


    //    //    public class CustomDropDown
    //    //    {
    //    //        public int Value
    //    //        {
    //    //            get;
    //    //            set;
    //    //        }
    //    //        public string Text
    //    //        {
    //    //            get;
    //    //            set;
    //    //        }
    //    //        public string StringValue
    //    //        {
    //    //            get;
    //    //            set;
    //    //        }
    //    //    }   

    //    //    public class CheckModel
    //    //    {
    //    //        public int ParentId
    //    //        {
    //    //            get;
    //    //            set;
    //    //        }

    //    //        public string ParentName
    //    //        {
    //    //            get;
    //    //            set;
    //    //        }
    //    //        public int Id
    //    //        {
    //    //            get;
    //    //            set;
    //    //        }
    //    //        public string Name
    //    //        {
    //    //            get;
    //    //            set;
    //    //        }
    //    //        public bool Checked
    //    //        {
    //    //            get;
    //    //            set;
    //    //        }
    //    //    }   


    //    //     public class CategoryCheckModel
    //    //    {
    //    //        public int EntityId { get; set; }
    //    //        public int FunctionalAreaId { get; set; }
    //    //        public int KeySkillId { get; set; }

    //    //        public int ParentId
    //    //        {
    //    //            get;
    //    //            set;
    //    //        }

    //    //        public string ParentName
    //    //        {
    //    //            get;
    //    //            set;
    //    //        }
    //    //        public int Id
    //    //        {
    //    //            get;
    //    //            set;
    //    //        }
    //    //        public string Name
    //    //        {
    //    //            get;
    //    //            set;
    //    //        }
    //    //        public bool Checked
    //    //        {
    //    //            get;
    //    //            set;
    //    //        }
    //    //    }



    //}

    public class WebApiResponse
    {
        public bool Success { get; set; }
        public dynamic Data { get; set; }

    }

    public class FunctionResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }

    public class CustomDropDown
    {
        public int Value
        {
            get;
            set;
        }
        public string Text
        {
            get;
            set;
        }
        public string StringValue
        {
            get;
            set;
        }

        public int SiteId
        {
            get;
            set;
        }
    }

    public class CheckModel
    {
        public int ParentId
        {
            get;
            set;
        }

        public string ParentName
        {
            get;
            set;
        }
        public int Id
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public bool Checked
        {
            get;
            set;
        }
    }

    public class DDLList
    {
        public List<CustomDropDown> SelectItemList { get; set; }

        public DDLList()
        {
            SelectItemList = new List<CustomDropDown>();
        }
    }

    //public class RedirectControllerDetail
    //{
    //    public string ControllerName { get; set; }
    //    public string ActionName { get; set; }
    //    public string QueryString { get; set; }
    //    public string FullUrl { get; set; }
    //    public string DeliveryUrl { get; set; }
    //}




}


