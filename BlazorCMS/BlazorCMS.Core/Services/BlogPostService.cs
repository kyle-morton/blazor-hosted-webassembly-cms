using BlazorCMS.Core.Data;
using BlazorCMS.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorCMS.Core.Services
{

    public interface IBlogPostService
    {
        List<BlogPost> GetPosts();
        List<BlogPost> GetBlogPosts(int blogId);
        BlogPost GetPost(int id);
        BlogPost Create(BlogPost post);
        BlogPost Update(BlogPost post);
        void Delete(int id);
    }

    public class BlogPostService : IBlogPostService
    {

        public List<BlogPost> GetPosts()
        {
            return MockDataContext.BlogPosts;
        }
        public List<BlogPost> GetBlogPosts(int blogId)
        {
            var posts = MockDataContext.BlogPosts.Where(bp => bp.BlogId == blogId).ToList();

            foreach(var post in posts)
            {
                post.Blog = MockDataContext.Blogs.Single(b => b.Id == post.BlogId);
            }

            return posts;
        }

        public BlogPost GetPost(int id)
        {
            var post = MockDataContext.BlogPosts.SingleOrDefault(bp => bp.Id == id);
            post.Blog = MockDataContext.Blogs.Single(b => b.Id == post.BlogId);
            return post;
        }

        public BlogPost Create(BlogPost post)
        {
            post.Id = MockDataContext.NewPostId;
            MockDataContext.BlogPosts.Add(post);
            post.Blog = MockDataContext.Blogs.Single(b => b.Id == post.BlogId);
            return post;
        }

        public BlogPost Update(BlogPost post)
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

        public void Delete(int id)
        {
            MockDataContext.Delete(id, MockDataContext.MockDataType.BlogPost);
        }
    }
}
