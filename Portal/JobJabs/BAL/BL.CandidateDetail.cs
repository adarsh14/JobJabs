using JobJabs.BAL;
using JobJabs.DAL;
using JobJabs.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace JobJabs.BAL
{
    public class BL_CandidateDetail : Business
    {
        public static CandidateDetail Add_CandidateDetail(CandidateDetail candidateDetail, HttpPostedFileBase resumeFile, JobPostCandidateDetail jpCandidateDetail)
        {
            candidateDetail.ResumeFileName  = Get_ResumeFileName(resumeFile.FileName);
            CandidateDetailRequest request = new CandidateDetailRequest(candidateDetail, "Add_CandidateDetail",1);
            DataTable dt = Database.GetDataTable(request);
            candidateDetail = (dt.Rows.Count > 0 ? ConvertToList<CandidateDetail>(dt).FirstOrDefault() : new CandidateDetail() { CandidateId = 0 });
            Save_ResumeFile(candidateDetail, resumeFile);
            if (jpCandidateDetail.JobPostId > 0)
            {
                jpCandidateDetail.CandidateId = candidateDetail.CandidateId;
                Add_JobPostCandidateDetail(jpCandidateDetail);
            }
            return candidateDetail;
        }

        public static CandidateDetail Update_CandidateDetail(CandidateDetail candidateDetail, HttpPostedFileBase resumeFile, JobPostCandidateDetail jpCandidateDetail)
        {
            CandidateDetailRequest request = new CandidateDetailRequest(candidateDetail, "Update_CandidateDetail", 2);
            DataTable dt = Database.GetDataTable(request);
            candidateDetail=(dt.Rows.Count > 0 ? ConvertToList<CandidateDetail>(dt).FirstOrDefault() : new CandidateDetail() { CandidateId = 0 });
            Save_ResumeFile(candidateDetail, resumeFile);
            if (jpCandidateDetail.JobPostId > 0)
            {
                jpCandidateDetail.CandidateId = candidateDetail.CandidateId;
                Add_JobPostCandidateDetail(jpCandidateDetail);
            }
            return candidateDetail;
        }

        public static CandidateDetail Get_CandidateDetailById(CandidateDetail candidateDetail)
        {
            CandidateDetailRequest request = new CandidateDetailRequest(candidateDetail, "Get_CandidateDetailById", 3);
            DataTable dt = Database.GetDataTable(request);
            return (dt.Rows.Count > 0 ? ConvertToList<CandidateDetail>(dt).FirstOrDefault() : new CandidateDetail() { CandidateId = 0 });
        }

        public static IEnumerable<CandidateDetail> Get_AllCandidate(CandidateDetail candidateDetail)
        {
            CandidateDetailRequest request = new CandidateDetailRequest(candidateDetail, "Get_AllCandidate", 4);
            DataTable dt = Database.GetDataTable(request);
            return (dt.Rows.Count > 0 ? ConvertToList<CandidateDetail>(dt) : new List<CandidateDetail>());
        }

        public static bool Change_CandidateStatus(CandidateDetail candidateDetail)
        {
            CandidateDetailRequest request = new CandidateDetailRequest(candidateDetail, "Change_CandidateStatus", 5);
            return Database.ExecuteNonQuery(request);
        }

        public static string Get_ResumeFileName(string fileName)
        {
            return CommonClass.RandomString(7) + Path.GetExtension(fileName);
        }

        public static void Save_ResumeFile(CandidateDetail candidateDetail, HttpPostedFileBase resumeFile)
        {

            string resumeFilePath = ConfigSetting.ResumeFileServerPath + candidateDetail.CandidateId;
            if (resumeFilePath != null)
            {
                if (!Directory.Exists(resumeFilePath))
                    Directory.CreateDirectory(resumeFilePath);
            }
            resumeFile.SaveAs(resumeFilePath + "/" + candidateDetail.ResumeFileName);
        }


        public static bool Add_JobPostCandidateDetail(JobPostCandidateDetail jpCandidateDetail)
        {
            JobPostCandidateDetailRequest request = new JobPostCandidateDetailRequest(jpCandidateDetail, "Add_JobPostCandidateDetail", 1);
            return Database.ExecuteNonQuery(request);
        }

        public static List<JobPostCandidateDetail> Get_Candidate(JobPostCandidateDetail candidateDetail)
        {
            CandidateWithFullDetailRequest request = new CandidateWithFullDetailRequest(candidateDetail, "Get_Candidate", 1);
            DataTable dt = Database.GetDataTable(request);
            return (dt.Rows.Count > 0 ? ConvertToList<JobPostCandidateDetail>(dt) : new List<JobPostCandidateDetail>());
        }

        //public static List<JobPostCandidateDetail> Get_CandidateByJobPostId(JobPostCandidateDetail candidateDetail)
        //{
        //    JobPostCandidateDetailRequest request = new JobPostCandidateDetailRequest(candidateDetail, "Get_CandidateByJobPostId", 4);
        //    DataTable dt = Database.GetDataTable(request);
        //    return (dt.Rows.Count > 0 ? ConvertToList<JobPostCandidateDetail>(dt) : new List<JobPostCandidateDetail>());
        //}


        public static bool Change_JobPostCandidateStatus(JobPostCandidateDetail candidateDetail)
        {
            JobPostCandidateDetailRequest request = new JobPostCandidateDetailRequest(candidateDetail, "Change_JobPostCandidateStatus", 5);
            return Database.ExecuteNonQuery(request);
        }

        public static bool Add_JPCACommentDetail(JPCACommentDetail commentDetail)
        {
            JPCACommentDetailRequest request = new JPCACommentDetailRequest(commentDetail, "Add_JPCACommentDetail", 1);
            return Database.ExecuteNonQuery(request);
        }

        public static List<JPCACommentDetail> Get_JPCACommentDetail(JPCACommentDetail commentDetail)
        {
            JPCACommentDetailRequest request = new JPCACommentDetailRequest(commentDetail, "Get_JPCACommentDetail", 3);
            DataTable dt = Database.GetDataTable(request);
            return (dt.Rows.Count > 0 ? ConvertToList<JPCACommentDetail>(dt) : new List<JPCACommentDetail>());
        }

    }
  }
