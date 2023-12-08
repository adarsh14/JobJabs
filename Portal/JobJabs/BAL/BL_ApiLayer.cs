using JobJabs.DAL;
using JobJabs.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobJabs.BAL
{
    public class BL_ApiLayer
    {
        private DL_ApiLayer dbLayer;
         public BL_ApiLayer()
         {
             dbLayer = new DL_ApiLayer(); 
        }

         public dynamic AddUpdate_Data<T>(iRequest  request)
         {
             iResponse response= dbLayer.AddUpdate_Data<T>(request);
            if (response.Status == 1)
            {
                return response.Data;
            }
            else
            {
                return Activator.CreateInstance<T>();
            }
         }
    }
}