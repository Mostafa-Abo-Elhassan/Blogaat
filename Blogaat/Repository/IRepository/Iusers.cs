using Microsoft.AspNetCore.Identity;

namespace Blogaat.Repository.IRepository
{
    public interface Iusers
    {
        Task<IEnumerable<IdentityUser>> GetALLUsers();
    }
}
