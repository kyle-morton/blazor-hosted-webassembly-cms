using BlazorCMS.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorCMS.SharedModels.ViewModels.BlogPosts
{
    public class UpdateBlogPostViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public int BlogId { get; set; }

        public BlogPost ToModel()
        {
            return new BlogPost
            {
                Id = Id,
                ModifyDate = DateTime.Now,
                Title = Title,
                Content = Content,
                Author = Author,
                BlogId = BlogId
            };
        }
    }
}
