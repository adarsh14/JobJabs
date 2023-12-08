using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using JobJabs.Entity;
using System.Web;

namespace JobJabs.ViewModel
{

    public class VM_BlogPostList
    {
        public BlogPostList BlogPostList { get; set; }
        public int Status { get; set; }
        public static implicit operator VM_BlogPostList(BlogPostList model)
        {
            return new VM_BlogPostList()
            {
                BlogPostList = model
            };
        }

        public VM_BlogPostList()
        {
            BlogPostList = new List<BlogPostDetail>();
        }
    }


    public class VM_AddBlogPost
    {
        public int BlogPostId { get; set; }
        public string Message { get; set; }
        [Required(ErrorMessage = " Blog Post Title cannot be balank")]
        [StringLength(250, MinimumLength = 0, ErrorMessage = " Blog Post Title cannot exceed 250 characters.")]
        public string BlogPostTitle { get; set; }

        [Required(ErrorMessage = " Blog Post Content cannot be balank")]
        public string BlogPostContent { get; set; }

        public static implicit operator VM_AddBlogPost(BlogPostDetail model)
        {
            return new VM_AddBlogPost()
            {
                BlogPostId = model.BlogPostId,
                BlogPostTitle = model.BPHeader,
                BlogPostContent = model.BPText
            };
        }

        public static implicit operator BlogPostDetail(VM_AddBlogPost model)
        {
            return new BlogPostDetail()
            {
                BlogPostId = model.BlogPostId,
                BPHeader = model.BlogPostTitle,
                BPText = model.BlogPostContent
            };
        }
    }

   
}
