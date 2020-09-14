using BlazorCMS.Core.Data;
using BlazorCMS.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorCMS.Core.Services
{

    public interface IBlogPostService
    {
        List<BlogPost> GetPostsAsync();
        List<BlogPost> GetBlogPostsAsync(int blogId);
        BlogPost GetPostAsync(int id);
        BlogPost CreateAsync(BlogPost post);
        BlogPost UpdateAsync(BlogPost post);
        void DeleteAsync(int id);
    }

    public class BlogPostService : ServiceBase, IBlogPostService
    {
        public BlogPostService(CMSDbContext context) : base(context)
        {
        }

        public List<BlogPost> GetPostsAsync()
        {
            var posts = _context.BlogPosts.ToList();
            return MockDataContext.BlogPosts;
        }
        public List<BlogPost> GetBlogPostsAsync(int blogId)
        {
            var posts = MockDataContext.BlogPosts.Where(bp => bp.BlogId == blogId).ToList();

            foreach(var post in posts)
            {
                post.Blog = MockDataContext.Blogs.Single(b => b.Id == post.BlogId);
            }

            return posts;
        }

        public BlogPost GetPostAsync(int id)
        {
            var post = MockDataContext.BlogPosts.SingleOrDefault(bp => bp.Id == id);
            post.Blog = MockDataContext.Blogs.Single(b => b.Id == post.BlogId);
            return post;
        }

        public BlogPost CreateAsync(BlogPost post)
        {
            post.Id = MockDataContext.NewPostId;
            MockDataContext.BlogPosts.Add(post);
            post.Blog = MockDataContext.Blogs.Single(b => b.Id == post.BlogId);
            return post;
        }

        public BlogPost UpdateAsync(BlogPost post)
        {
            var postToUpdate = MockDataContext.BlogPosts.SingleOrDefault(bp => bp.Id == post.Id);
            if (postToUpdate == null)
            {
                return post;
            }

            postToUpdate.ModifyDate = DateTime.Now;
            postToUpdate.Title = post.Title;
            postToUpdate.Content = post.Content;

            return postToUpdate;
        }

        public void DeleteAsync(int id)
        {
            MockDataContext.Delete(id, MockDataContext.MockDataType.BlogPost);
        }
    }
}
