using JobJabs.BAL;
using JobJabs.DAL;
using JobJabs.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace JobJabs.BAL
{
    public class BL_Common : Business
    {
        public static ExperienceLevelDetailList Get_AllExperienceLevelDetail(ExperienceLevelDetail experienceLevelDetail)
        {
            ExperienceLevelDetailRequest request = new ExperienceLevelDetailRequest(experienceLevelDetail, "Get_AllExperienceLevelDetail", 4);
            DataTable dt = Database.GetDataTable(request);
            return (dt.Rows.Count > 0 ? ConvertToList<ExperienceLevelDetail>(dt) : new List<ExperienceLevelDetail>());
        }



        public static EmploymentTypeDetailList Get_AllEmploymentTypeDetail(EmploymentTypeDetail employmentTypeDetail)
        {
            EmploymentTypeDetailRequest request = new EmploymentTypeDetailRequest(employmentTypeDetail, "Get_AllEmploymentTypeDetail", 4);
            DataTable dt = Database.GetDataTable(request);
            return (dt.Rows.Count > 0 ? ConvertToList<EmploymentTypeDetail>(dt) : new List<EmploymentTypeDetail>());
        }

    }
  }
