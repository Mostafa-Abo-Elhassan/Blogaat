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

        public AdminUsersController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, Iusers iusers , SignInManager<IdentityUser> signInManager)
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

            // إنشاء مستخدم جديد من نوع IdentityUser
            var user = new IdentityUser
            {
                UserName = model.UserName,
                Email = model.Email
            };

            // إنشاء المستخدم مع كلمة المرور المحددة
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // تعيين الدور الأساسي

                // إضافة الدور Admin إذا تم تحديده
                if (model.checkAdmin )
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                  
                }
                else
                {
                    await _userManager.AddToRoleAsync(user, "User");
                }
                await signInManager.SignInAsync(user, false);

                return RedirectToAction("Users", "AdminUsers"); // إعادة التوجيه إلى قائمة المستخدمين بعد الإضافة الناجحة
            }

            // معالجة الأخطاء (مثل البريد الإلكتروني المكرر، كلمات المرور الضعيفة، إلخ)
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);

            }
            return View();
        }

        // إذا فشلت التحقق من صحة النموذج، أعد تحميل النموذج مع رسائل الخطأ







        [HttpPost]
        public async Task <IActionResult> Delete(Guid id)
        {
            var USER = await _userManager.FindByIdAsync(id.ToString());
            if (USER!=null)
            {
                var identityResult = await _userManager.DeleteAsync(USER);
                return RedirectToAction("Users","AdminUsers");
            }
            return View();
        }








    }























    //public class AdminUsersController : Controller
    //{
    //    private readonly Iusers iusers;
    //    private readonly IdentityRole identityRole;
    //    private readonly IdentityUser identityUser;

    //    public AdminUsersController(Iusers iusers, IdentityRole identityRole, IdentityUser identityUser)
    //    {
    //        this.iusers = iusers;
    //        this.identityRole = identityRole;
    //        this.identityUser = identityUser;
    //    }

    //    [HttpGet]
    //    public async Task<IActionResult> Users()
    //    {
    //        //var users = await iusers.GetALLUsers();
    //        var users = new usersVM
    //        {
    //            Id =Guid.Parse(identityUser.Id),
    //            UserName=identityUser.UserName,
    //            Email= identityUser.Email,
    //            RoleName= identityRole.Name


    //        };

    //        return View(users);
    //    }
    //}
}
