using BlazorCMS.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlazorCMS.Core.Data
{
    public class CMSDbContext : DbContext
    {

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }

        public CMSDbContext(DbContextOptions<CMSDbContext> options) : base(options)
        { }

    }
}
