using JobJabs.Entity;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace JobJabs.DAL
{
    public class Database
    {
        public static bool _loggingFlag = false;
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public string connectionstring = ConfigurationManager.ConnectionStrings[DatabaseSession.Current.ConnectionString].ToString();

        public static bool ExecuteNonQuery(iRequest request)
        {
            try
            {
                dynamic obj = request.Param;
                request.DBConnection = ConfigurationManager.ConnectionStrings[DatabaseSession.Current.ConnectionString].ToString(); // (!string.IsNullOrEmpty(request.DBConnection) ? request.DBConnection : connectionstring);
                using (SqlConnection con = new SqlConnection(request.DBConnection))
                {
                    using (SqlCommand cmd = new SqlCommand(request.ProcedureName, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (obj != null)
                        {
                            foreach (PropertyInfo prop in obj.GetType().GetProperties())
                            {
                                if (prop.PropertyType.Name.ToLower() == "datetime")
                                    cmd.Parameters.Add("@" + prop.Name, SqlDbType.DateTime).Value = obj.GetType().GetProperty(prop.Name).GetValue(obj, null);
                                else if (prop.PropertyType.Name.ToLower() == "int32")
                                    cmd.Parameters.Add("@" + prop.Name, SqlDbType.Int).Value = obj.GetType().GetProperty(prop.Name).GetValue(obj, null);
                                else if (prop.PropertyType.Name.ToLower() == "decimal")
                                    cmd.Parameters.Add("@" + prop.Name, SqlDbType.Decimal).Value = obj.GetType().GetProperty(prop.Name).GetValue(obj, null);
                                else
                                    cmd.Parameters.Add("@" + prop.Name, SqlDbType.VarChar).Value = obj.GetType().GetProperty(prop.Name).GetValue(obj, null);
                            }
                        }
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                WriteToLogClass.WriteErrorLog(request.ClassName, request.FunctionName, ex);
                return false;
            }
            return true;
        }

        public static DataTable GetDataTable(iRequest request)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable(); 
            try
            {
                dynamic obj = request.Param;
                request.DBConnection = ConfigurationManager.ConnectionStrings[DatabaseSession.Current.ConnectionString].ToString(); // (!string.IsNullOrEmpty(request.DBConnection) ? request.DBConnection : connectionstring);
                using (SqlConnection con = new SqlConnection(request.DBConnection))
                {
                    using (SqlCommand cmd = new SqlCommand(request.ProcedureName, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (obj != null)
                        {
                            foreach (PropertyInfo prop in obj.GetType().GetProperties())
                            {
                                if (prop.PropertyType.Name.ToLower() == "datetime")
                                    cmd.Parameters.Add("@" + prop.Name, SqlDbType.DateTime).Value = obj.GetType().GetProperty(prop.Name).GetValue(obj, null);
                                else if (prop.PropertyType.Name.ToLower() == "int32")
                                    cmd.Parameters.Add("@" + prop.Name, SqlDbType.Int).Value = obj.GetType().GetProperty(prop.Name).GetValue(obj, null);
                                else if (prop.PropertyType.Name.ToLower() == "decimal")
                                    cmd.Parameters.Add("@" + prop.Name, SqlDbType.Decimal).Value = obj.GetType().GetProperty(prop.Name).GetValue(obj, null);
                                else
                                    cmd.Parameters.Add("@" + prop.Name, SqlDbType.VarChar).Value = obj.GetType().GetProperty(prop.Name).GetValue(obj, null);
                            }
                        }
                        con.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(ds, "Products");
                        if(ds.Tables.Count >0 )
                           dt = ds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                WriteToLogClass.WriteErrorLog(request.ClassName, request.FunctionName, ex);
                dt = new DataTable(); 
            }

            return dt;
        }

        public static DataTable GetDataTable2(iRequest request)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                dynamic obj = request.Param;
                request.DBConnection = ConfigurationManager.ConnectionStrings[DatabaseSession.Current.ConnectionString].ToString(); // (!string.IsNullOrEmpty(request.DBConnection) ? request.DBConnection : connectionstring);
                using (SqlConnection con = new SqlConnection(request.DBConnection))
                {
                    using (SqlCommand cmd = new SqlCommand(request.ProcedureName, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (obj != null)
                        {
                            foreach (PropertyInfo prop in obj.GetType().GetProperties())
                            {
                                if (prop.Name.ToLower()== "bptext")
                                    cmd.Parameters.Add("@" + prop.Name, SqlDbType.NVarChar).Value = obj.GetType().GetProperty(prop.Name).GetValue(obj, null);
                                else if (prop.PropertyType.Name.ToLower() == "datetime")
                                    cmd.Parameters.Add("@" + prop.Name, SqlDbType.DateTime).Value = obj.GetType().GetProperty(prop.Name).GetValue(obj, null);
                                else if (prop.PropertyType.Name.ToLower() == "int32")
                                    cmd.Parameters.Add("@" + prop.Name, SqlDbType.Int).Value = obj.GetType().GetProperty(prop.Name).GetValue(obj, null);
                                else if (prop.PropertyType.Name.ToLower() == "decimal")
                                    cmd.Parameters.Add("@" + prop.Name, SqlDbType.Decimal).Value = obj.GetType().GetProperty(prop.Name).GetValue(obj, null);
                                else
                                    cmd.Parameters.Add("@" + prop.Name, SqlDbType.VarChar).Value = obj.GetType().GetProperty(prop.Name).GetValue(obj, null);
                            }
                        }
                        con.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(ds, "Products");
                        if (ds.Tables.Count > 0)
                            dt = ds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                WriteToLogClass.WriteErrorLog(request.ClassName, request.FunctionName, ex);
                dt = new DataTable();
            }

            return dt;
        }

        public static DataSet GetDataSet(iRequest request)
        {
            DataSet ds = new DataSet();
            try
            {
                dynamic obj = request.Param;
                request.DBConnection = ConfigurationManager.ConnectionStrings[DatabaseSession.Current.ConnectionString].ToString(); // (!string.IsNullOrEmpty(request.DBConnection) ? request.DBConnection : connectionstring);
                using (SqlConnection con = new SqlConnection(request.DBConnection))
                {
                    using (SqlCommand cmd = new SqlCommand(request.ProcedureName, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if(obj !=null)
                        {
                            foreach (PropertyInfo prop in obj.GetType().GetProperties())
                            {
                                if (prop.PropertyType.Name.ToLower() == "datetime")
                                    cmd.Parameters.Add("@" + prop.Name, SqlDbType.DateTime).Value = obj.GetType().GetProperty(prop.Name).GetValue(obj, null);
                                else if (prop.PropertyType.Name.ToLower() == "int32")
                                    cmd.Parameters.Add("@" + prop.Name, SqlDbType.Int).Value = obj.GetType().GetProperty(prop.Name).GetValue(obj, null);
                                else if (prop.PropertyType.Name.ToLower() == "decimal")
                                    cmd.Parameters.Add("@" + prop.Name, SqlDbType.Decimal).Value = obj.GetType().GetProperty(prop.Name).GetValue(obj, null);
                                else
                                    cmd.Parameters.Add("@" + prop.Name, SqlDbType.VarChar).Value = obj.GetType().GetProperty(prop.Name).GetValue(obj, null);
                            }
                        }
                        con.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(ds, "Products");
                      
                    }
                }
            }
            catch (Exception ex)
            {
                WriteToLogClass.WriteErrorLog(request.ClassName, request.FunctionName, ex);
                ds = new DataSet ();
            }

            return ds;
        }
     
    }
}
