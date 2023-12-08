using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobJabs.Entity
{
    public class BlogPostDetailRequest : ExecuteNonQueryRequest, iRequest
    {
        public BlogPostDetailRequest(RBlogPostDetail blogPostDetail, string functionName, int queryType)
        {
            blogPostDetail.QueryType = queryType;
            base.ProcedureName = "tb_BlogPostDetail";
            base.ClassName = "BL_BlogPostDetail";
            base.FunctionName = functionName;
            base.Param = blogPostDetail;
        }
    }

    public class RBlogPostDetail
    {
        public int QueryType { get; set; }
        public int BlogPostId { get; set; }
        public string BPHeader { get; set; }
        public string BPText { get; set; }
        public string BPFileName { get; set; }
        public int BPStatus { get; set; }
        public int BPCreatedBy { get; set; }
    }
}
