using BlazorCMS.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorCMS.Core.Data
{
    public static class MockDataContext
    {
        private static List<Blog> _blogs { get; set; }
        private static List<BlogPost> _blogPosts { get; set; }

        public static List<Blog> Blogs
        {
            get
            {
                var blogs = _blogs;
                foreach (var blog in blogs)
                {
                    blog.BlogPosts = _blogPosts.Where(p => p.BlogId == blog.Id).ToList();
                }

                return blogs;
            }
        }
        public static List<BlogPost> BlogPosts
        {
            get
            {
                var blogPosts = _blogPosts;
                foreach (var post in blogPosts)
                {
                    post.Blog = _blogs.Single(b => b.Id == post.BlogId);
                }

                return blogPosts;
            }
        }

        public static int NewBlogId => _blogs.Count > 0 ? _blogs.Max(b => b.Id) + 1 : 1;
        public static int NewPostId => _blogPosts.Count > 0 ? _blogPosts.Max(bp => bp.Id) + 1 : 1;

        public static void Init()
        {
            _blogs = new List<Blog>
            {
                new Blog
                {
                    Id = 1,
                    CreateDate = DateTime.Now,
                    ModifyDate = DateTime.Now,
                    Name = "Kyle's Blog",
                    Description = "random thoughts"
                },
                new Blog
                {
                    Id = 2,
                    CreateDate = DateTime.Now,
                    ModifyDate = DateTime.Now,
                    Name = "Kyle's Other Blog",
                    Description = "random thoughts #2"
                }
            };

            _blogPosts = new List<BlogPost>
            {
                new BlogPost
                {
                    Id = 1,
                    CreateDate = DateTime.Now.AddDays(-1),
                    ModifyDate = DateTime.Now,
                    Author = "Kyle Morton",
                    Title = "Post #1",
                    Content = "Here's a post from KM",
                    BlogId = 1
                },
                new BlogPost
                {
                    Id = 2,
                    CreateDate = DateTime.Now.AddDays(-9),
                    ModifyDate = DateTime.Now,
                    Author = "Kyle Morton",
                    Title = "Post #2",
                    Content = "Here's another post from KM",
                    BlogId = 1
                },
                new BlogPost
                {
                    Id = 3,
                    CreateDate = DateTime.Now.AddDays(-10),
                    ModifyDate = DateTime.Now,
                    Author = "Kyle Morton",
                    Title = "2nd Post #1",
                    Content = "Here's a post from KM",
                    BlogId = 2
                },
                new BlogPost
                {
                    Id = 4,
                    CreateDate = DateTime.Now.AddDays(-9),
                    ModifyDate = DateTime.Now,
                    Author = "Kyle Morton",
                    Title = "2nd Post #2",
                    Content = "Here's another post from KM",
                    BlogId = 2
                }
            };

        }

        public static void Delete(int id, MockDataType type)
        {
            switch(type)
            {
                case MockDataType.Blog:
                    _blogs = _blogs.Where(b => b.Id != id).ToList();
                    _blogPosts = _blogPosts.Where(p => p.BlogId != id).ToList();
                    break;
                case MockDataType.BlogPost:
                    _blogPosts = _blogPosts.Where(b => b.Id != id).ToList();
                    break;
            }
        }

        public enum MockDataType
        {
            Blog, 
            BlogPost
        }
    }
}
