using BlazorCMS.Shared.Domain;
using System;

namespace BlazorCMS.SharedModels.ViewModels.Blogs
{
    public class CreateBlogViewModel
    {
        public string Name { get; set; }
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
