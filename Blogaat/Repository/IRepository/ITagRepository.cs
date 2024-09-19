using Blogaat.Models.Domains;
using Blogaat.Models.ViewModels;

namespace Blogaat.Repository.IRepository
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetALLAsync();

        Task<Tag?> GetAsync(Guid id);

        Task<Tag> AddAsync(Tag tag);
        Task<Tag?> UpdateAsync(Tag tag);

        Task<Tag?> DeleteAsync(Guid id);

    }
}
