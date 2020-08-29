using BlazorCMS.Core.Data;
using BlazorCMS.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorCMS.Core.Services
{
    public interface IBlogService
    {
        List<Blog> GetBlogs();
        Blog GetBlog(int id);
        Blog Create(Blog blog);
        Blog Update(Blog blog);
        void Delete(int id);

    }
    public class BlogService : IBlogService
    {
        public Blog Create(Blog blog)
        {
            blog.Id = MockDataContext.NewBlogId;
            blog.CreateDate = blog.ModifyDate = DateTime.Now;
            MockDataContext.Blogs.Add(blog);
            return blog;
        }

        public void Delete(int id)
        {
            MockDataContext.Blogs = MockDataContext.Blogs.Where(b => b.Id != id).ToList();
        }

        public Blog GetBlog(int id)
        {
            return MockDataContext.Blogs.SingleOrDefault(b => b.Id == id);
        }

        public List<Blog> GetBlogs()
        {
            return MockDataContext.Blogs;
        }

        public Blog Update(Blog blog)
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
