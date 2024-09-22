using Blogaat.Data;
using Blogaat.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Blogaat.Repository.Repository
{
    public class UsersRepo : Iusers
    {
        private readonly BlogaatAuothanticatDbcintext blogaatAuothanticat;

        public UsersRepo(BlogaatAuothanticatDbcintext blogaatAuothanticat)
        {
            this.blogaatAuothanticat = blogaatAuothanticat;
        }
        public async Task<IEnumerable<IdentityUser>> GetALLUsers()
        {
            return await blogaatAuothanticat.Users.ToListAsync();
           

        }
    }
}
