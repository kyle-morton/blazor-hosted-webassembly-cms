using BlazorCMS.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorCMS.SharedModels.ViewModels.Blogs
{
    public class CreateBlogViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public Blog ToModel()
        {
            return new Blog
            {
                CreateDate = DateTime.Now,
                ModifyDate = DateTime.Now,
                Name = Name,
                Description = Description
            };
        }
    }
}
