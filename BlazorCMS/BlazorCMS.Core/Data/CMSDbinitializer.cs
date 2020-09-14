using BlazorCMS.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorCMS.Core.Data
{
    public static class CMSDbinitializer
    {

        public static void Seed(CMSDbContext context)
        {
            if (context.Blogs.Any())
            {
                return;
            }

            var blogs = new List<Blog>
            {
                new Blog
                {
                    Id = 1,
                    CreateDate = DateTime.Now,
                    ModifyDate = DateTime.Now,
                    Name = "Kyle's Blog",
                    Description = "random thoughts",
                    BlogPosts = new List<BlogPost>
                    {
                        new BlogPost
                        {
                            Id = 1,
                            CreateDate = DateTime.Now.AddDays(-1),
                            ModifyDate = DateTime.Now,
                            Author = "Kyle Morton",
                            Title = "Post #1",
                            Content = "Here's a post from KM"
                        },
                        new BlogPost
                        {
                            Id = 2,
                            CreateDate = DateTime.Now.AddDays(-9),
                            ModifyDate = DateTime.Now,
                            Author = "Kyle Morton",
                            Title = "Post #2",
                            Content = "Here's another post from KM"
                        }
                    }
                },
                new Blog
                {
                    Id = 2,
                    CreateDate = DateTime.Now,
                    ModifyDate = DateTime.Now,
                    Name = "Kyle's Other Blog",
                    Description = "random thoughts #2",
                    BlogPosts = new List<BlogPost>
                    {
                        new BlogPost
                        {
                            Id = 3,
                            CreateDate = DateTime.Now.AddDays(-10),
                            ModifyDate = DateTime.Now,
                            Author = "Kyle Morton",
                            Title = "2nd Post #1",
                            Content = "Here's a post from KM"
                        },
                        new BlogPost
                        {
                            Id = 4,
                            CreateDate = DateTime.Now.AddDays(-9),
                            ModifyDate = DateTime.Now,
                            Author = "Kyle Morton",
                            Title = "2nd Post #2",
                            Content = "Here's another post from KM"
                        }
                    }
                }
            };

            context.Blogs.AddRange(blogs);
            context.SaveChanges();
        }
    }
}
