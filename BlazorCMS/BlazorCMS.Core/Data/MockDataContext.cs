using BlazorCMS.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorCMS.Core.Data
{
    public static class MockDataContext
    {
        public static List<Blog> Blogs { get; set; }
        public static List<BlogPost> BlogPosts { get; set; }
        public static List<User> Users { get; set; }
        public static List<Person> People { get; set; }

        public static int NewBlogId => Blogs.Max(b => b.Id) + 1;
        public static int NewPostId => BlogPosts.Max(bp => bp.Id) + 1;

        public static void Init()
        {
            Blogs = new List<Blog>
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

            BlogPosts = new List<BlogPost>
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

            Users = new List<User>
            {
                new User
                {
                    Id = 1,
                    CreateDate = DateTime.Now.AddDays(-9),
                    ModifyDate = DateTime.Now,
                    Email = "mkmorton@gmail.test.com",
                    Username = "mkmorton"
                },
                new User
                {
                    Id = 2,
                    CreateDate = DateTime.Now.AddDays(-9),
                    ModifyDate = DateTime.Now,
                    Email = "mkmorton2@gmail.test.com",
                    Username = "mkmorton2"
                }
            };

            People = new List<Person>
            {
                new Person
                {
                    Id = 1,
                    CreateDate = DateTime.Now,
                    ModifyDate = DateTime.Now,
                    FirstName = "Kyle",
                    LastName = "Morton",
                    PhotoUrl = "https://ui-avatars.com/api/?name=Kyle+Morton"
                }
            };
        }

    }
}
