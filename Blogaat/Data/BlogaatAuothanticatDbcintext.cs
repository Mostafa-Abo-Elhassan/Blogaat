using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Blogaat.Data
{
    public class BlogaatAuothanticatDbcintext: IdentityDbContext<IdentityUser>
    {
        public BlogaatAuothanticatDbcintext() { }
       
        public BlogaatAuothanticatDbcintext(DbContextOptions<BlogaatAuothanticatDbcintext> options) : base(options) { }

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

            var Super_Admin = "1b892d2e-2158-4170-91ec-08839cd0f4d4";
            var Admin = "2a768bee-f40e-4183-9736-2c0cae0ba9f3";
            var User = "9b5649ea-6db6-482a-a83e-73633a72c2ce";
            var superAdminD = "20F5B72B-5F5E-4D40-A45B-509A01FF187F";
           
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
