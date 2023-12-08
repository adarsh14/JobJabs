using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobJabs.Entity
{
    public class BlogPostDetail
    {
        public int BlogPostId { get; set; }
        public string BPHeader { get; set; }
        public string BPText { get; set; }
        public string BPFileName { get; set; }
        public int BPStatus { get; set; }
        public int BPCreatedBy { get; set; }

        public BlogPostDetail()
        {
            BlogPostId = 0;
            BPHeader = "";
            BPText = "";
            BPFileName = "";
            BPStatus = 0;
            BPCreatedBy = 0;
        }

        public static implicit operator RBlogPostDetail(BlogPostDetail model)
        {
            return new RBlogPostDetail()
            {
                BlogPostId = model.BlogPostId,
                BPHeader = model.BPHeader,
                BPText = model.BPText,
                BPFileName = model.BPFileName,
                BPStatus = model.BPStatus,
                BPCreatedBy = model.BPCreatedBy,
            };
        }
    }

    public class BlogPostList
    {
        public List<BlogPostDetail> BlogPosts { get; set; }

        public static implicit operator BlogPostList(List<BlogPostDetail> model)
        {
            model = (model == null ? new List<BlogPostDetail>() : model);
            return new BlogPostList()
            {
                BlogPosts = model
            };
        }

        public BlogPostList()
        {
            BlogPosts = new List<BlogPostDetail>();
        }
    }
}
