using Blogaat.Data;
using Blogaat.Repository.IRepository;
using Microsoft.AspNetCore.Identity;

namespace Blogaat.Repository.Repository
{
    public class UsersRepo : Iusers
    {
        private readonly BlogaatDbcontext dbcontext;

        public UsersRepo(BlogaatDbcontext blogaatDbcontext)
        {
            blogaatDbcontext = dbcontext;
        }
        public async Task<IEnumerable<IdentityUser>> GetALLUsers()
        {
            //return await blogaatDbcontext.Users.ToListAsync();
            return null; // يجب استبدال هذا بـ dbcontext.Users.ToListAsync() إذا كان لديك DbSet للمستخدمين في BlogaatDbcontext


        }
    }
}
