using BlazorCMS.Shared.Domain;
using System;

namespace BlazorCMS.SharedModels.ViewModels.BlogPosts
{
    public class UpdateBlogPostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public int BlogId { get; set; }

        public BlogPost From()
        {
            return new BlogPost
            {
                Id = Id,
                ModifyDate = DateTime.Now,
                Title = Title,
                Content = Content,
                Author = Author
            };
        }
    }
}
