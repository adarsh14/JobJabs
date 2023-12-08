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
    public class BL_JobPostDetail : Business
    {
        public static JobPostDetail Add_JobPostDetail(JobPostDetail jobPostDetail, HttpPostedFileBase jdFile, HttpPostedFileBase checklistFile)
        {
            jobPostDetail.JDFileName = Get_JobPostFileName(jdFile.FileName);
            jobPostDetail.ChecklistFileName = Get_JobPostFileName(checklistFile.FileName);
            JobPostDetailRequest request = new JobPostDetailRequest(jobPostDetail, "Add_JobPostDetail",1);
            DataTable dt = Database.GetDataTable(request);
            jobPostDetail = (dt.Rows.Count > 0 ? ConvertToList<JobPostDetail>(dt).FirstOrDefault() : new JobPostDetail() { JobPostId = 0 });
            Save_JobPostFile(jobPostDetail, jdFile, checklistFile);
            return jobPostDetail;
        }

        public static JobPostDetail Update_JobPostDetail(JobPostDetail jobPostDetail, HttpPostedFileBase jdFile, HttpPostedFileBase checklistFile)
        {
            JobPostDetailRequest request = new JobPostDetailRequest(jobPostDetail, "Update_JobPostDetail", 2);
            DataTable dt = Database.GetDataTable(request);
            jobPostDetail = (dt.Rows.Count > 0 ? ConvertToList<JobPostDetail>(dt).FirstOrDefault() : new JobPostDetail() { JobPostId = 0 });
            Save_JobPostFile(jobPostDetail, jdFile, checklistFile);
            return jobPostDetail;
        }

        public static JobPostDetail Get_JobPostById(JobPostDetail jobPosting)
        {
            JobPostDetailRequest request = new JobPostDetailRequest(jobPosting, "Get_JobPostById", 3);
            DataTable dt = Database.GetDataTable(request);
            return (dt.Rows.Count > 0 ? ConvertToList<JobPostDetail>(dt).FirstOrDefault() : new JobPostDetail() { JobPostId = 0 });
        }

        public static IEnumerable<JobPostDetail> Get_AllJobPost(JobPostDetail jobPosting)
        {
            JobPostDetailRequest request = new JobPostDetailRequest(jobPosting, "Get_AllJobPost", 4);
            DataTable dt = Database.GetDataTable(request);
            return (dt.Rows.Count > 0 ? ConvertToList<JobPostDetail>(dt) : new List<JobPostDetail>());
        }

        public static IEnumerable<JobPostDetail> Get_AllJobPostByStatus(JobPostDetail jobPosting)
        {
            JobPostDetailRequest request = new JobPostDetailRequest(jobPosting, "Get_AllJobPostByStatus", 41);
            DataTable dt = Database.GetDataTable(request);
            return (dt.Rows.Count > 0 ? ConvertToList<JobPostDetail>(dt) : new List<JobPostDetail>());
        }

        public static bool Change_JobPostStatus(JobPostDetail jobPosting)
        {
            JobPostDetailRequest request = new JobPostDetailRequest(jobPosting, "Change_JobPostStatus", 5);
            return Database.ExecuteNonQuery(request);
        }

        public static string Get_JobPostFileName(string fileName)
        {
            return  CommonClass.RandomString(7) + Path.GetExtension(fileName);
        }

        public static void Save_JobPostFile(JobPostDetail jobPostDetail, HttpPostedFileBase jdFile, HttpPostedFileBase checklistFile)
        { 
          
            string jpFilePath = ConfigSetting.JPFileServerPath + jobPostDetail.JobPostId;
            if (jpFilePath != null)
            {
                if (!Directory.Exists(jpFilePath))
                    Directory.CreateDirectory(jpFilePath);
            }
            jdFile.SaveAs(jpFilePath + "/" + jobPostDetail.JDFileName);
            checklistFile.SaveAs(jpFilePath + "/" + jobPostDetail.ChecklistFileName);
        }


        public static void Assign_JobPostToFranchise(JobPostFranchiseDetail jobPost)
        {
            JPFADetailRequest request = new JPFADetailRequest(jobPost, "Assign_JobPostToFranchise",1);
            Database.ExecuteNonQuery(request);
        }

        public static void Delete_JobPostFranchiseAsgn(JobPostFranchiseDetail jobPost)
        {
            JPFADetailRequest request = new JPFADetailRequest(jobPost, "Delete_JobPostFranchiseAsgn",2);
            Database.ExecuteNonQuery(request);
        }

        public static JobPostFranchiseList Get_AllFranchiseToJobPost(JobPostFranchiseDetail jobPost)
        {
            JPFADetailRequest request = new JPFADetailRequest(jobPost, "Get_AllFranchiseToJobPost", 3);
            DataTable dt = Database.GetDataTable(request);
            return (dt.Rows.Count > 0 ? ConvertToList<JobPostFranchiseDetail>(dt) : new List<JobPostFranchiseDetail>());
        }


        public static void Assign_JobPostToRecruiter(JobPostRecruiterDetail jobPost)
        {
            JPRCDetailRequest request = new JPRCDetailRequest(jobPost, "Assign_JobPostToRecruiter", 1);
            Database.ExecuteNonQuery(request);
        }

        public static void Delete_JobPostRecruiterAsgn(JobPostRecruiterDetail jobPost)
        {
            JPRCDetailRequest request = new JPRCDetailRequest(jobPost, "Delete_JobPostRecruiterAsgn", 2);
            Database.ExecuteNonQuery(request);
        }

        public static JobPostRecruiterList Get_AllRecruiterToJobPost(JobPostRecruiterDetail jobPost)
        {
            JPRCDetailRequest request = new JPRCDetailRequest(jobPost, "Get_AllRecruiterToJobPost", 3);
            DataTable dt = Database.GetDataTable(request);
            return (dt.Rows.Count > 0 ? ConvertToList<JobPostRecruiterDetail>(dt) : new List<JobPostRecruiterDetail>());
        }


        public static List<JobPostWithFullDetail> Get_JobPostWithFullDetail(GetJobPostDetail jobPosting)
        {
            JobPostWithFullDetailRequest request = new JobPostWithFullDetailRequest(jobPosting, "Get_JobPostWithCandidateDetail", 1);
            DataSet ds = Database.GetDataSet(request);
            return ConvertToJobPostWithFullDetail(ds);
        }

        public static int Check_IfNewCandidateExists(GetJobPostDetail jobPosting)
        {
            JobPostWithFullDetailRequest request = new JobPostWithFullDetailRequest(jobPosting, "Get_JobPostWithFullDetail", 2);
            DataTable dt = Database.GetDataTable(request);
            return (dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : 0);
        }

        private static List<JobPostWithFullDetail> ConvertToJobPostWithFullDetail(DataSet ds)
        {
            List<JobPostWithFullDetail> jobpostList = new List<JobPostWithFullDetail>();
            if(ds.Tables.Count > 0)
            {
                jobpostList = ConvertToList<JobPostWithFullDetail>(ds.Tables[0]).Distinct().ToList();
            }
            if (ds.Tables.Count > 1)
            {
                DataTable dt = ds.Tables[1];
               foreach (JobPostWithFullDetail item in jobpostList)
                {
                    if (dt.AsEnumerable().Where(row => row.ConvertToInt32("JobPostId") == item.JobPostId).Count() > 0)
                    {
                        //FranchiseDetailList franchiseList = ConvertToList<FranchiseDetail>(dt.AsEnumerable().Where(row => row.ConvertToInt32("JobPostId") == item.JobPostId).Distinct().CopyToDataTable());
                        //foreach (FranchiseDetail franchiseItem in franchiseList.FranchiseDetail)
                        //{
                        //    if (dt.AsEnumerable().Where(row => row.ConvertToInt32("FranchiseId") == franchiseItem.FranchiseId).Count() > 0)
                        //    {
                        //        UserDetailList recruiterList = ConvertToList<UserDetail>(dt.AsEnumerable().Where(row => row.ConvertToInt32("FranchiseId") == franchiseItem.FranchiseId).Distinct().CopyToDataTable());
                        //    }
                        //}
                        item.CandidateList= ConvertToList<JPWiseCandidateDetail>(dt.AsEnumerable().Where(row => row.ConvertToInt32("JobPostId") == item.JobPostId).Distinct().CopyToDataTable());
                        //foreach(JPWiseCandidateDetail cand in item.CandidateList) {
                        //    cand.CandidateCount = Get_CandidateCount(cand,status);
                        //}
                    }
                    else

                    {
                        item.CandidateList = new List<JPWiseCandidateDetail>(); 
                    }
                }
            }
            return jobpostList;
        }

    }
}
