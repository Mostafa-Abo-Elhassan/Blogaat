using Blogaat.Data;
using Blogaat.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Blogaat.Repository.Repository
{
    public class UsersRepo : Iusers
    {
        private readonly BlogaatDbcontext dbcontext;
        private readonly UserManager<IdentityUser> _userManager;

        public UsersRepo(BlogaatDbcontext blogaatDbcontext, UserManager<IdentityUser> userManager)
        {
            blogaatDbcontext = dbcontext;
            _userManager = userManager;
        }
        public async Task<IEnumerable<IdentityUser>> GetALLUsers()
        {
            return await _userManager.Users.ToListAsync();
            return null; // يجب استبدال هذا بـ dbcontext.Users.ToListAsync() إذا كان لديك DbSet للمستخدمين في BlogaatDbcontext


        }
    }
}
