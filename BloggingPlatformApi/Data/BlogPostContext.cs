using BloggingPlatformApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BloggingPlatformApi.Data
{
    public class BlogPostContext : DbContext
    {
        public BlogPostContext(DbContextOptions<BlogPostContext> options) : base(options){}
        public DbSet<BlogPost> blogposts { get; set; }
    }
}
