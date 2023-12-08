using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobJabs.Entity
{
    

    public class AddFranchiseDTO
    {
        public UserDetail UserDetail { get; set; }
        public FranchiseDetail FranchiseDetail { get; set; }
        public string Message { get; set; }

        public AddFranchiseDTO()
        {
            UserDetail = new UserDetail();
            FranchiseDetail = new FranchiseDetail();
            Message = "";
        }
    }

}