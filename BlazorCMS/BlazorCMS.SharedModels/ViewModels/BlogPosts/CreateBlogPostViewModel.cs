using BlazorCMS.Shared.Domain;
using System;

namespace BlazorCMS.SharedModels.ViewModels.BlogPosts
{
    public class CreateBlogPostViewModel 
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public int BlogId { get; set; }

        public BlogPost From()
        {
            return new BlogPost
            {
                CreateDate = DateTime.Now,
                ModifyDate = DateTime.Now,
                Title = Title,
                Content = Content,
                Author = Author
            };
        }
    }
}
