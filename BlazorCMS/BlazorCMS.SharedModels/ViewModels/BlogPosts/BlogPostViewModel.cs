using BlazorCMS.Shared.Domain;

namespace BlazorCMS.SharedModels.ViewModels.BlogPosts
{
    public class BlogPostViewModel : EntityViewModelBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public int BlogId { get; set; }
        public string BlogName { get; set; }

        public static BlogPostViewModel From(BlogPost post)
        {
            return new BlogPostViewModel
            {
                Id = post.Id,
                CreateDate = post.CreateDate,
                ModifyDate = post.ModifyDate,
                Title = post.Title,
                Content = post.Content,
                Author = post.Author,
                BlogId = post.BlogId,
                BlogName = post.Blog.Name
            };
        }
    }
}
