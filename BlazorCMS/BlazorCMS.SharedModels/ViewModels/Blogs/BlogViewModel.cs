using BlazorCMS.Shared.Domain;

namespace BlazorCMS.SharedModels.ViewModels.Blogs
{
    public class BlogViewModel : EntityViewModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public static BlogViewModel From(Blog blog)
        {
            return new BlogViewModel
            {
                Id = blog.Id,
                CreateDate = blog.CreateDate,
                ModifyDate = blog.ModifyDate,
                Name = blog.Name,
                Description = blog.Description
            };
        }

    }
}
