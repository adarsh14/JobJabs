using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobJabs.Entity;
using JobJabs.DAL;
using System.Data;


namespace JobJabs.BAL
{
    public class BL_CompanyDetail : Business
    {
        public static CompanyDetail Add_NewCompany(CompanyDetail  company)
        {
            CompanyDetailRequest request = new CompanyDetailRequest(company, 1, "Add_NewCompany");
            DataTable dt = Database.GetDataTable(request);
            return (dt.Rows.Count > 0 ? ConvertToList<CompanyDetail>(dt).FirstOrDefault() : new CompanyDetail() { CompanyId = 0 });
        }

        //New Function To Update Company Detail
        public static void Update_CompanyDetail(CompanyDetail company)
        {
            CompanyDetailRequest request = new CompanyDetailRequest(company, 2, "Update_UserDetail");
            Database.ExecuteNonQuery(request);
        }

       
        //New Function To Get Company Detail 
        public static CompanyDetail Get_CompanyByCompanyId(CompanyDetail company)
        {
            CompanyDetailRequest request = new CompanyDetailRequest(company, 3, "Get_CompanyByCompanyId");
            DataTable dt = Database.GetDataTable(request);
            return (dt.Rows.Count > 0 ? ConvertToList<CompanyDetail>(dt).FirstOrDefault() : new CompanyDetail() { CompanyId = 0 });
        }

       
        public static IEnumerable<CompanyDetail> Get_AllCompanyByStatus(CompanyDetail company)
        {
            CompanyDetailRequest request = new CompanyDetailRequest(company, 4, "Get_AllCompanyByStatus");
            DataTable dt = Database.GetDataTable(request);
            return (dt.Rows.Count > 0 ? ConvertToList<CompanyDetail>(dt) : new List<CompanyDetail>());
        }
                  

        public static bool Change_CompanyStatus(CompanyDetail company)
        {
            CompanyDetailRequest request = new CompanyDetailRequest(company, 5, "Change_CompanyStatus");
            return Database.ExecuteNonQuery(request);
        }

        //New Function To Add Company Location Detail
        public static CompanyLocationDetail Add_NewCompanyLocation(CompanyLocationDetail compLoc)
        {
            CompanyLocationRequest request = new CompanyLocationRequest(compLoc, 1, "Add_NewCompanyLocation");
            DataTable dt = Database.GetDataTable(request);
            return (dt.Rows.Count > 0 ? ConvertToList<CompanyLocationDetail>(dt).FirstOrDefault() : new CompanyLocationDetail() { CompLocId = 0 });
        }

        //New Function To Update Company Location Detail
        public static void Update_CompanyLocationDetail(CompanyLocationDetail compLoc)
        {
            CompanyLocationRequest request = new CompanyLocationRequest(compLoc, 2, "Update_CompanyLocationDetail");
            Database.ExecuteNonQuery(request);
        }


        //New Function To Get Company Detail 
        public static CompanyLocationDetail Get_CompLocById(CompanyLocationDetail compLoc)
        {
            CompanyLocationRequest request = new CompanyLocationRequest(compLoc, 3, "Get_CompLocById");
            DataTable dt = Database.GetDataTable(request);
            return (dt.Rows.Count > 0 ? ConvertToList<CompanyLocationDetail>(dt).FirstOrDefault() : new CompanyLocationDetail() { CompanyId = 0 });
        }


        public static IEnumerable<CompanyLocationDetail> Get_AllLocationByCompanyId(CompanyLocationDetail compLoc)
        {
            CompanyLocationRequest request = new CompanyLocationRequest(compLoc, 4, "Get_AllLocationByCompanyId");
            DataTable dt = Database.GetDataTable(request);
            return (dt.Rows.Count > 0 ? ConvertToList<CompanyLocationDetail>(dt) : new List<CompanyLocationDetail>());
        }


        public static bool Change_CompanyLocationStatus(CompanyLocationDetail compLoc)
        {
            CompanyLocationRequest request = new CompanyLocationRequest(compLoc, 5, "Change_CompanyLocationStatus");
            return Database.ExecuteNonQuery(request);
        }

    }
}

