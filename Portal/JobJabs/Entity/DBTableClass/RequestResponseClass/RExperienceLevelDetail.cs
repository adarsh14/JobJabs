using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobJabs.Entity
{
    public class ExperienceLevelDetailRequest : ExecuteNonQueryRequest, iRequest
    {
        public ExperienceLevelDetailRequest(RExperienceLevelDetail experienceLevelDetail,string functionName, int queryType)
        {
            experienceLevelDetail.QueryType = queryType;
            base.ProcedureName = "tb_ExperienceLevelDetail";
            base.ClassName = "BL_Common";
            base.FunctionName = functionName;
            base.Param = experienceLevelDetail;
        }
    }

    public class RExperienceLevelDetail
    {
        public int QueryType { get; set; }
        public int ExperienceLevelId { get; set; }
        public string ExperienceLevel { get; set; }
        public int ExpLevelStatus { get; set; }
        public int ExpLevelCreatedBy { get; set; }
    }

}
