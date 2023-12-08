using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobJabs.Entity;
using JobJabs.DAL;
using System.Data;


namespace JobJabs.BAL
{
    public class BL_FranchiseDetail : Business
    {
        public static FranchiseDetail Add_NewFranchise(FranchiseDetail  franchise)
        {
            FranchiseDetailRequest request = new FranchiseDetailRequest(franchise, 1, "Add_NewFranchise");
            DataTable dt = Database.GetDataTable(request);
            return (dt.Rows.Count > 0 ? ConvertToList<FranchiseDetail>(dt).FirstOrDefault() : new FranchiseDetail() { UserId = 0 });
        }

        //New Function To Update Franchise Detail
        public static void Update_FranchiseDetail(FranchiseDetail franchise)
        {
            FranchiseDetailRequest request = new FranchiseDetailRequest(franchise, 2, "Update_UserDetail");
            Database.ExecuteNonQuery(request);
        }

       
        //New Function To Get Franchise Detail 
        public static FranchiseDetail Get_FranchiseByFranchiseId(FranchiseDetail franchise)
        {
            FranchiseDetailRequest request = new FranchiseDetailRequest(franchise, 3, "Get_FranchiseByFranchiseId");
            DataTable dt = Database.GetDataTable(request);
            return (dt.Rows.Count > 0 ? ConvertToList<FranchiseDetail>(dt).FirstOrDefault() : new FranchiseDetail() { UserId = 0 });
        }

        public static List<UserDetail> Get_FranchiseUserByFranchiseId(FranchiseDetail franchise)
        {
            FranchiseDetailRequest request = new FranchiseDetailRequest(franchise, 31, "Get_FranchiseUserByFranchiseId");
            DataTable dt = Database.GetDataTable(request);
            return (dt.Rows.Count > 0 ? ConvertToList<UserDetail>(dt) : new List<UserDetail>());
        }

        public static FranchiseDetail Get_FranchiseDetailByUserId(FranchiseDetail franchise)
        {
            FranchiseDetailRequest request = new FranchiseDetailRequest(franchise, 32, "Get_FranchiseDetailByUserId");
            DataTable dt = Database.GetDataTable(request);
            return (dt.Rows.Count > 0 ? ConvertToList<FranchiseDetail>(dt).FirstOrDefault() : new FranchiseDetail() { UserId = 0 });
        }

        public static IEnumerable<FranchiseDetail> Get_AllFranchiseByStatus(FranchiseDetail franchise)
        {
            FranchiseDetailRequest request = new FranchiseDetailRequest(franchise, 4, "Get_AllFranchiseByStatus");
            DataTable dt = Database.GetDataTable(request);
            return (dt.Rows.Count > 0 ? ConvertToList<FranchiseDetail>(dt) : new List<FranchiseDetail>());
        }
                  

        public static bool Change_FranchiseStatus(FranchiseDetail franchise)
        {
            FranchiseDetailRequest request = new FranchiseDetailRequest(franchise, 5, "Change_FranchiseStatus");
            return Database.ExecuteNonQuery(request);
        }


        public static FranchiseDetail Add_NewFranchiseUser(FranchiseUserDetail franchiseUser)
        {
            FranchiseUserDetailRequest request = new FranchiseUserDetailRequest(franchiseUser, 1, "Add_NewFranchiseUser");
            DataTable dt = Database.GetDataTable(request);
            return (dt.Rows.Count > 0 ? ConvertToList<FranchiseDetail>(dt).FirstOrDefault() : new FranchiseDetail() { UserId = 0 });
        }

        public static void Assign_FranchiseToSPOCAdmin(SPOCFranchiseDetail spocFranchise)
        {
            SPOCFranchiseDetailRequest request = new SPOCFranchiseDetailRequest(spocFranchise, 1, "Assign_FranchiseToSPOCAdmin");
            Database.ExecuteNonQuery(request);
        }

        public static void Delete_SPOCFranchiseAsgn(SPOCFranchiseDetail spocFranchise)
        {
            SPOCFranchiseDetailRequest request = new SPOCFranchiseDetailRequest(spocFranchise, 2, "Delete_SPOCFranchiseAsgn");
            Database.ExecuteNonQuery(request);
        }

        public static SPOCFranchiseList Get_AllFranchiseToSPOCAdmin(SPOCFranchiseDetail spocFranchise)
        {
            SPOCFranchiseDetailRequest request = new SPOCFranchiseDetailRequest(spocFranchise, 3, "Get_AllFranchiseToSPOCAdmin");
            DataTable dt = Database.GetDataTable(request);
            return (dt.Rows.Count > 0 ? ConvertToList<SPOCFranchiseDetail>(dt) : new List<SPOCFranchiseDetail>());
        }
    }
}

