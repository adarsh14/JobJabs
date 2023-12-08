using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using JobJabs.Entity;

namespace JobJabs.ViewModel
{

    public class VM_CurrentOpenings
    {
        public JobPostList JobPostList { get; set; }
        public VM_CurrentOpenings()
        {
            JobPostList = new JobPostList();
        }
    }

   

  
   
}
