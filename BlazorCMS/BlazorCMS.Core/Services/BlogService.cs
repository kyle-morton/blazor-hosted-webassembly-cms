using BlazorCMS.Core.Data;
using BlazorCMS.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorCMS.Core.Services
{
    public interface IBlogService
    {
        List<Blog> GetBlogsAsync();
        Blog GetBlogAsync(int id);
        Blog CreateAsync(Blog blog);
        Blog UpdateAsync(Blog blog);
        void DeleteAsync(int id);

    }
    public class BlogService : ServiceBase, IBlogService
    {
        public BlogService(CMSDbContext context) : base(context)
        {
        }

        public Blog CreateAsync(Blog blog)
        {
            blog.Id = MockDataContext.NewBlogId;
            blog.CreateDate = blog.ModifyDate = DateTime.Now;
            MockDataContext.Blogs.Add(blog);
            return blog;
        }

        public void DeleteAsync(int id)
        {
            MockDataContext.Delete(id, MockDataContext.MockDataType.Blog);
        }

        public Blog GetBlogAsync(int id)
        {
            return MockDataContext.Blogs.SingleOrDefault(b => b.Id == id);
        }

        public List<Blog> GetBlogsAsync()
        {
            return MockDataContext.Blogs;
        }

        public Blog UpdateAsync(Blog blog)
        {
            var blogToUpdate = MockDataContext.Blogs.SingleOrDefault(b => b.Id == blog.Id);
            if (blogToUpdate == null)
            {
                return blog;
            }

            blogToUpdate.Name = blog.Name;
            blogToUpdate.Description = blog.Description;

            return blogToUpdate;
        }
    }
}
