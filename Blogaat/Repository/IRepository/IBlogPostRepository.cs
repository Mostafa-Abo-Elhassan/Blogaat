using Blogaat.Models.Domains;

namespace Blogaat.Repository.IRepository
{
    public interface IBlogPostRepository
    {
        Task<IEnumerable<BlogPost>> GetALLAsync();

        Task<BlogPost?> GetAsync(Guid id);

        Task<BlogPost> AddAsync(BlogPost blogPost);

        Task<BlogPost?> UpdateAsync(BlogPost blogPost);

        Task<BlogPost?> DeleteAsync(Guid id);
    }
}
