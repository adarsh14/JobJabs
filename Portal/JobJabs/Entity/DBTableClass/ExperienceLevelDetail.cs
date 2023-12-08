using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobJabs.Entity
{
    public class ExperienceLevelDetail
    {
        public int ExperienceLevelId { get; set; }
        public string ExperienceLevel { get; set; }
        public int ExpLevelStatus { get; set; }
        public int ExpLevelCreatedBy { get; set; }

        public ExperienceLevelDetail()
        {
            ExperienceLevelId = 0;
            ExperienceLevel = "";
            ExpLevelStatus = 0;
            ExpLevelCreatedBy = 0;
        }

        public static implicit operator RExperienceLevelDetail(ExperienceLevelDetail model)
        {
            model = (model == null ? new ExperienceLevelDetail() : model);
            return new RExperienceLevelDetail()
            {
                ExperienceLevelId = model.ExperienceLevelId,
                ExperienceLevel = model.ExperienceLevel,
                ExpLevelStatus = model.ExpLevelStatus,
                ExpLevelCreatedBy = model.ExpLevelCreatedBy
            };
        }

    }

    public class ExperienceLevelDetailList
    {
        public List<ExperienceLevelDetail> ExperienceLevelDetail { get; set; }
        public List<CustomDropDown> ExperienceLevelDropDown
        {
            get
            {
                return (ExperienceLevelDetail != null ?
                        (from a in ExperienceLevelDetail
                         select new CustomDropDown()
                         {
                             Value = a.ExperienceLevelId,
                             Text = a.ExperienceLevel
                         }).ToList() : new List<CustomDropDown>()
                    );
            }
        }


        public static implicit operator ExperienceLevelDetailList(List<ExperienceLevelDetail> model)
        {
            model = (model == null ? new List<ExperienceLevelDetail>() : model);
            return new ExperienceLevelDetailList()
            {
                ExperienceLevelDetail = model
            };
        }
    }

}