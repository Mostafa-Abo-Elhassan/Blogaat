using Blogaat.Models.Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Blogaat.Data
{
    public class BlogaatDbcontext:DbContext
    {
          // ctor
            public BlogaatDbcontext() { }
            public BlogaatDbcontext(DbContextOptions<BlogaatDbcontext> options) : base(options) { }


            public DbSet<BlogPost> BlogPosts { get; set; }
           public DbSet<Tag> Tags { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                base.OnConfiguring(optionsBuilder);
            }

    }
}
