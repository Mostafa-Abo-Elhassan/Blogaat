using Azure;
using Blogaat.Data;
using Blogaat.Models.Domains;
using Blogaat.Models.ViewModels;
using Blogaat.Repository.IRepository;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

namespace Blogaat.Repository.Repository
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BlogaatDbcontext dbcontext;

        public BlogPostRepository(BlogaatDbcontext dbcontext1)
        {
            dbcontext = dbcontext1;
        }



        public async Task<BlogPost> AddAsync(BlogPost blogPost)
        {
            await dbcontext.BlogPosts.AddAsync(blogPost);
            await dbcontext.SaveChangesAsync();
            return blogPost;
        }



        public async Task<BlogPost?> DeleteAsync(Guid id)
        {
            var exsiting = await dbcontext.BlogPosts.FindAsync(id);
            if (exsiting != null)
            {
                dbcontext.BlogPosts.Remove(exsiting); // remove without await 
                await dbcontext.SaveChangesAsync();
                return exsiting;
            }
            return null;
        }



        public async Task<IEnumerable<BlogPost>> GetALLAsync()
        {
            return await dbcontext.BlogPosts.Include(x=>x.tags).ToListAsync();
        }



        public async Task<BlogPost?> GetAsync(Guid id)
        {
            return await dbcontext.BlogPosts.Include(e=>e.tags).FirstOrDefaultAsync(x=>x.Id==id);
        }



        public  async Task<BlogPost?> UpdateAsync(BlogPost blogPost)
        {
            var exsiting = await dbcontext.BlogPosts.Include(e=>e.tags).FirstOrDefaultAsync(e=>e.Id==blogPost.Id);
            if (exsiting != null)
            {
                exsiting.Heading = blogPost.Heading;
                exsiting.PageTitle = blogPost.PageTitle;
                exsiting.Content = blogPost.Content;
                exsiting.ShortDescription = blogPost.ShortDescription;
                exsiting.FeateredImageUrl = blogPost.FeateredImageUrl;
                exsiting.UrlHandle = blogPost.UrlHandle;
                exsiting.PublishedDate = blogPost.PublishedDate;
                exsiting.Author = blogPost.Author;
                exsiting.Visible = blogPost.Visible;
                exsiting.tags = blogPost.tags;
                await dbcontext.SaveChangesAsync();
                return exsiting;

            }

            return null;
        }

        



    }
}
