using BlazorCMS.Shared.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BlazorCMS.SharedModels.ViewModels.BlogPosts
{
    public class CreateBlogPostViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public int BlogId { get; set; }
        public List<SelectListItem> BlogOptions { get; set; }

        public static CreateBlogPostViewModel From(int blogId, List<Blog> blogs)
        {
            return new CreateBlogPostViewModel
            {
                BlogId = blogId,
                BlogOptions = blogs.Select(b => SelectListItem.From(b.Id, b.Name)).ToList()
            };
        }

        public BlogPost ToModel()
        {
            return new BlogPost
            {
                CreateDate = DateTime.Now,
                ModifyDate = DateTime.Now,
                Title = Title,
                Content = Content,
                Author = Author,
                BlogId = BlogId
            };
        }
    }
}
