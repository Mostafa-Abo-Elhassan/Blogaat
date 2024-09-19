using Azure;
using Blogaat.Data;
using Blogaat.Models.Domains;
using Blogaat.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Blogaat.Repository.IRepository;

namespace Blogaat.Repository.Repository
{
    public class TagRepository : ITagRepository
    {
        private readonly BlogaatDbcontext dbcontext;

        public TagRepository(BlogaatDbcontext dbcontext1)
        {
            dbcontext = dbcontext1;
        }

       

        public async Task<Tag> AddAsync(Tag tag)
        {
            await dbcontext.Tags.AddAsync(tag);
            await dbcontext.SaveChangesAsync();
            return tag;
        }


        public async Task<Tag?> DeleteAsync(Guid id)
        {
            var exsiting = await dbcontext.Tags.FindAsync(id);
            if (exsiting != null)
            {
                dbcontext.Tags.Remove(exsiting); // remove without await 
                await dbcontext.SaveChangesAsync();
                return exsiting;
            }
            return null;
        }

        public Task DeleteAsync(EditTagVM editTagVM)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Tag>> GetALLAsync()
        {
            return await dbcontext.Tags.ToListAsync();

        }

        public async Task<Tag?> GetAsync(Guid id)
        {
            return await dbcontext.Tags.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Tag?> UpdateAsync(Tag tag)
        {
            var exsiting = await dbcontext.Tags.FindAsync(tag.Id);

            if (exsiting != null)
            {
                exsiting.Name = tag.Name;
                //exsiting.urlimage = tag.urlimage;
                exsiting.DisplayName = tag.DisplayName;
                await dbcontext.SaveChangesAsync();
                return exsiting;

            }

            return null;
        }

       


    }
}
