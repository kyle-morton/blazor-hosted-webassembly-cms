using BlazorCMS.Shared.Domain;
using System;

namespace BlazorCMS.SharedModels.ViewModels.Blogs
{
    public class UpdateBlogViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Blog ToModel()
        {
            return new Blog
            {
                Id = Id,
                ModifyDate = DateTime.Now,
                Name = Name,
                Description = Description
            };
        }
    }
}
