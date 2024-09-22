using Blogaat.Data;
using Blogaat.Repository.IRepository;
using Blogaat.Repository.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Blogaat
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddDbContext<BlogaatDbcontext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("BlogaatConnectionStrings")));
            

            builder.Services.AddDbContext<BlogaatAuothanticatDbcintext>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("BlogaatAuothanticat")));


            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
       .AddEntityFrameworkStores<BlogaatAuothanticatDbcintext>();


            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;


            } );

           
            builder.Services.AddScoped<ITagRepository, TagRepository>();
            builder.Services.AddScoped<IuploadImage, uploadImage>();
            builder.Services.AddScoped<IBlogPostRepository, BlogPostRepository>();
            builder.Services.AddScoped<Iusers, UsersRepo>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
