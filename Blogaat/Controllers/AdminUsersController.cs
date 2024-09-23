using Blogaat.Repository.IRepository;
using Blogaat.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace Blogaat.Controllers
{
    public class AdminUsersController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly Iusers iusers;
        private readonly SignInManager<IdentityUser> signInManager;
        public AdminUsersController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, Iusers iusers, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            this.iusers = iusers;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public async Task<IActionResult> Users()
        {
            var users = await iusers.GetALLUsers(); // استرجاع جميع المستخدمين
            var usersVM = new usersVM(); // إنشاء كائن usersVM
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var roleName = roles.FirstOrDefault() ?? "No Role"; // التعامل مع حالة عدم وجود دور
                // إضافة بيانات المستخدم إلى قائمة Users
                usersVM.Users.Add(new USERS
                {
                    Id = Guid.Parse(user.Id),
                    UserName = user.UserName,
                    Email = user.Email,
                    RoleName = roleName
                });
            }
            return View(usersVM); // إرجاع الـ View مع البيانات
        }



        [HttpPost]
        public async Task<IActionResult> CreateUser(usersVM model)
        {

            var user = new IdentityUser
            {
                UserName = model.UserName,
                Email = model.Email
            };

            var identityResult = await _userManager.CreateAsync(user, model.Password);
            if (identityResult is not null)
            {

                if (identityResult.Succeeded)
                {


                    var roles = new List<string> { "User" };
                    if (model.checkAdmin)
                    {
                        roles.Add("Admin");

                    }

                   identityResult = await _userManager.AddToRolesAsync(user, roles);
                    if (identityResult is not null && identityResult.Succeeded)
                    {
                        return RedirectToAction("Users", "AdminUsers");
                    }



                }



            }


            return RedirectToAction("Users", "AdminUsers");
        }


        // إذا فشلت التحقق من صحة النموذج، أعد تحميل النموذج مع رسائل الخطأ
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var USER = await _userManager.FindByIdAsync(id.ToString());
            if (USER != null)
            {
                var identityResult = await _userManager.DeleteAsync(USER);
                return RedirectToAction("Users", "AdminUsers");
            }
            return View();
        }
    }
}
