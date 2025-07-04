using Blogaat.Models.Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blogaat.Data
{
    public class BlogaatDbcontext : IdentityDbContext<IdentityUser>
    {
        // ctor
        public BlogaatDbcontext() { }
        public BlogaatDbcontext(DbContextOptions<BlogaatDbcontext> options) : base(options) { }


        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BlogPostLike> Likes { get; set; }
        public DbSet<BlogPostComment> comments { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<IdentityRole>().HasData(

                new IdentityRole()
                {

                    Id = Guid.NewGuid().ToString(),
                    Name = "Admin",
                    NormalizedName = "admin",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                },

                  new IdentityRole()
                  {
                      Id = Guid.NewGuid().ToString(),
                      Name = "User",
                      NormalizedName = "user",
                      ConcurrencyStamp = Guid.NewGuid().ToString(),
                  },
                   new IdentityRole()
                   {
                       Id = Guid.NewGuid().ToString(),
                       Name = "Super_Admin",
                       NormalizedName = "super_admin",
                       ConcurrencyStamp = Guid.NewGuid().ToString(),
                   }

                );

            var Super_Admin = "1b892d2e-2158-4170-91ec-08839cd0f4dd";
            var Admin = "2a768bee-f40e-4183-9736-2c0cae0ba9ss";
            var User = "9b5649ea-6db6-482a-a83e-73633a72c2aa";
            var superAdminD = "20F5B72B-5F5E-4D40-A45B-509A01FF18kk";

            //var roles = new List<IdentityRole>
            //{

            //    new IdentityRole()
            //     {

            //        Id= Guid.NewGuid().ToString(),
            //        Name="Admin",
            //        NormalizedName= "admin",
            //        ConcurrencyStamp = Guid.NewGuid().ToString(),
            //      },

            //      new IdentityRole()
            //      {
            //          Id = Guid.NewGuid().ToString(),
            //          Name = "User",
            //          NormalizedName = "user",
            //          ConcurrencyStamp = Guid.NewGuid().ToString(),
            //      },
            //       new IdentityRole()
            //       {
            //           Id = Guid.NewGuid().ToString(),
            //           Name = "Super_Admin",
            //           NormalizedName = "super_admin",
            //           ConcurrencyStamp = Guid.NewGuid().ToString(),
            //       }

            //};


            // add user 
            var superAdmin = new IdentityUser
            {
                Id = superAdminD,
                NormalizedEmail = "superadmin@gmail.com".ToUpper(),
                NormalizedUserName = "superadmin@gmail.com".ToUpper(),
                UserName = "superadmin@gmail.com",
                Email = "superadmin@gmail.com"

            };

            // add  hash for passward user 
            superAdmin.PasswordHash = new PasswordHasher<IdentityUser>()
                .HashPassword(superAdmin, "superadmin@gmail.com");

            //add superAdmin in IdentityRole
            builder.Entity<IdentityRole>().HasData(superAdmin);



            // add all roles to superAdmin by IdentityUserRole
            var superadminroles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    UserId =superAdminD,
                    RoleId=User
                },
                  new IdentityUserRole<string>
                {
                       UserId =superAdminD ,
                    RoleId=Admin

                },
                     new IdentityUserRole<string>
                {
                          UserId = superAdminD,
                    RoleId=Super_Admin

                }
            };

            //add superadminroles in IdentityUserRole
            builder.Entity<IdentityUserRole<string>>().HasData(superadminroles);

            base.OnModelCreating(builder);
        }





    }
}
