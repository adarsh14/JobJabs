using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;
using JobJabs.Entity;

namespace JobJabs.DAL
{
    public class DL_ApiLayer
    {

        public iResponse AddUpdate_Data<T>(iRequest request)
        {
            DatabaseApi data = new DatabaseApi(request.ApiUrl); 
            if(request.RequestType == RequestType.Get && string.IsNullOrEmpty(request.ApiName))
                return data.GetApiWithoutBaseUrl<T>(request);
            else if (request.RequestType == RequestType.Get && !string.IsNullOrEmpty(request.ApiName))
                return  data.GetApi<T>(request);
            else
                return data.PostApi<T>(request);
        }
     
    }
}