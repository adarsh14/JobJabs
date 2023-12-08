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
    public class BL_BlogPostDetail : Business
    {
        public static BlogPostDetail Add_BlogPostDetail(BlogPostDetail blogPostDetail)
        {
            BlogPostDetailRequest request = new BlogPostDetailRequest(blogPostDetail, "Add_BlogPostDetail",1);
            DataTable dt = Database.GetDataTable2(request);
            blogPostDetail = (dt.Rows.Count > 0 ? ConvertToList<BlogPostDetail>(dt).FirstOrDefault() : new BlogPostDetail() { BlogPostId = 0 });
            return blogPostDetail;
        }

        public static BlogPostDetail Update_BlogPostDetail(BlogPostDetail blogPostDetail)
        {
            BlogPostDetailRequest request = new BlogPostDetailRequest(blogPostDetail, "Update_BlogPostDetail", 2);
            DataTable dt = Database.GetDataTable2(request);
            blogPostDetail = (dt.Rows.Count > 0 ? ConvertToList<BlogPostDetail>(dt).FirstOrDefault() : new BlogPostDetail() { BlogPostId = 0 });
            return blogPostDetail;
        }

        public static BlogPostDetail Get_BlogPostById(BlogPostDetail blogPostDetail)
        {
            BlogPostDetailRequest request = new BlogPostDetailRequest(blogPostDetail, "Get_BlogPostById", 3);
            DataTable dt = Database.GetDataTable(request);
            return (dt.Rows.Count > 0 ? ConvertToList<BlogPostDetail>(dt).FirstOrDefault() : new BlogPostDetail() { BlogPostId = 0 });
        }

        public static BlogPostList Get_AllBlogPost(BlogPostDetail blogPostDetail)
        {
            BlogPostDetailRequest request = new BlogPostDetailRequest(blogPostDetail, "Get_AllBlogPost", 4);
            DataTable dt = Database.GetDataTable(request);
            return (dt.Rows.Count > 0 ? ConvertToList<BlogPostDetail>(dt) : new List<BlogPostDetail>());
        }

        public static BlogPostList Get_BlogPostByStatusId(BlogPostDetail blogPostDetail)
        {
            BlogPostDetailRequest request = new BlogPostDetailRequest(blogPostDetail, "Get_BlogPostByStatusId", 41);
            DataTable dt = Database.GetDataTable(request);
            return (dt.Rows.Count > 0 ? ConvertToList<BlogPostDetail>(dt) : new List<BlogPostDetail>());
        }

        public static bool Change_BlogPostStatus(BlogPostDetail blogPostDetail)
        {
            BlogPostDetailRequest request = new BlogPostDetailRequest(blogPostDetail, "Change_BlogPostStatus", 5);
            return Database.ExecuteNonQuery(request);
        }

    }
}
