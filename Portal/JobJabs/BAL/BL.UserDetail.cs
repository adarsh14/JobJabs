using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobJabs.Entity;
using JobJabs.DAL;
using System.Data;



namespace JobJabs.BAL
{
    public class BL_UserDetail:Business
    {
        public static UserDetail Add_NewUser(UserDetail  user)
        {
            UserDetailRequest request = new UserDetailRequest(user,1, "Add_NewUser");
            DataTable dt = Database.GetDataTable(request);
            return (dt.Rows.Count > 0 ? ConvertToList<UserDetail>(dt).FirstOrDefault() : new UserDetail() { UserId = 0 });
        }

        //New Function To Update User Detail 
        public static void Update_UserDetail(UserDetail user)
        {
            UserDetailRequest request = new UserDetailRequest(user, 2, "Update_UserDetail");
            Database.ExecuteNonQuery(request);
        }

        //New Function To Update User Password 
        public static void Update_UserPassword(UserDetail  user)
        {
            UserDetailRequest request = new UserDetailRequest(user, 21, "Update_UserPassword");
            Database.ExecuteNonQuery(request);
        }

        //New Function To Get User Detail 
        public static UserDetail Get_UserDetailByUserId(UserDetail user)
        {
            UserDetailRequest request = new UserDetailRequest(user, 3, "Get_UserDetailByUserId");
            DataTable dt = Database.GetDataTable(request);
            return (dt.Rows.Count > 0 ? ConvertToList<UserDetail>(dt).FirstOrDefault() : new UserDetail() { UserId = 0 });
        }
                 

        public static IEnumerable<UserDetail> Get_AllUserByUserType(UserDetail user)
        {
            UserDetailRequest request = new UserDetailRequest(user,4, "Get_AllUserByUserType");
            DataTable dt = Database.GetDataTable(request);
            return (dt.Rows.Count > 0 ? ConvertToList<UserDetail>(dt) : new List<UserDetail>());
        }
                  

        public static bool Change_UserStatus(UserDetail user)
        {
            UserDetailRequest request = new UserDetailRequest(user,5, "Change_UserStatus");
            return Database.ExecuteNonQuery(request);
        }

      

    }
}

