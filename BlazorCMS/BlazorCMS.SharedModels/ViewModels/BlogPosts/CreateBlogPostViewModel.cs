using BlazorCMS.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorCMS.SharedModels.ViewModels.BlogPosts
{
    public class CreateBlogPostViewModel 
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public string Author { get; set; }

        public int BlogId { get; set; }

        public BlogPost ToModel()
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
