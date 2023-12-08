using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobJabs.Entity
{
    
    public enum RequestType{
      Get=1,
      Post=2,
        ExecuteNonQuery,
        GetDataSet
    }

    public enum DatabaseType
    {
        WebApi = 1,
        DB = 2
    }
}