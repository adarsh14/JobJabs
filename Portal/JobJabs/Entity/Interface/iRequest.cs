// -----------------------------------------------------------------------
// <copyright file="iRequest.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace JobJabs.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public interface iRequest
    {
        RequestType RequestType { get; }
        DatabaseType DBType { get;  }
        string ApiUrl { get; set; }
        string ApiName { get; set; }
        string AuthorizationToken { get; set; }
        string DBConnection { get; set; }
        string ProcedureName { get; set; }
        string ClassName { get; set; }
        string FunctionName { get; set; }
        dynamic Param { get; set; }
    }

    public class GetRequest : iRequest
    {
        public RequestType RequestType { get { return RequestType.Get; } }
        public DatabaseType DBType { get { return DatabaseType.WebApi ; } }
        public string ApiUrl { get; set; }
        public string ApiName { get; set; }
        public string AuthorizationToken { get; set; }
        public string DBConnection { get; set; }
        public string ProcedureName { get; set; }
        public dynamic Param { get; set; }
        public string ClassName { get; set; }
        public string FunctionName { get; set; }
    }

    public class PostRequest : iRequest
    {
        public RequestType RequestType { get { return RequestType.Post; } }
        public DatabaseType DBType { get { return DatabaseType.WebApi; } }
        public string ApiUrl { get; set; }
        public string ApiName { get; set; }
        public string AuthorizationToken { get; set; }
        public string DBConnection { get; set; }
        public string ProcedureName { get; set; }
        public dynamic Param { get; set; }
        public string ClassName { get; set; }
        public string FunctionName { get; set; }
    }

    public class ExecuteNonQueryRequest : iRequest
    {
        public RequestType RequestType { get { return RequestType.ExecuteNonQuery; } }
        public DatabaseType DBType { get { return DatabaseType.DB; } }
        public string ApiUrl { get; set; }
        public string ApiName { get; set; }
        public string AuthorizationToken { get; set; }
        public string DBConnection { get; set; }
        public string ProcedureName { get; set; }
        public dynamic Param { get; set; }
        public string ClassName { get; set; }
        public string FunctionName { get; set; }
    }

    public class GetDataSet : iRequest
    {
        public RequestType RequestType { get { return RequestType.GetDataSet; } }
        public DatabaseType DBType { get { return DatabaseType.DB; } }
        public string ApiUrl { get; set; }
        public string ApiName { get; set; }
        public string AuthorizationToken { get; set; }
        public string DBConnection { get; set; }
        public string ProcedureName { get; set; }
        public dynamic Param { get; set; }
        public string ClassName { get; set; }
        public string FunctionName { get; set; }
    }

}
