using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using QLBanHang.Models;

[assembly: OwinStartupAttribute(typeof(QLBanHang.Startup))]
namespace QLBanHang
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            InitUserRole();
        }
        private void InitUserRole()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            try
            {
                //tạo role Admin
                if (!roleManager.RoleExists("Admin"))//chưa có mới tạo
                {
                    var role = new IdentityRole();
                    role.Name = "Admin";
                    roleManager.Create(role);
                    //tạo user
                    var user = new ApplicationUser();
                    user.UserName = "admin@qlbh.com";
                    user.Email = "admin@qlbh.com";
                    string pass = "123456";//sau này login sẽ thay đổi pass
                    var chkUser = userManager.Create(user, pass);
                    //đưa user qlbh vào role Admin
                    if (chkUser.Succeeded)
                        userManager.AddToRole(user.Id, "Admin");
                }
            }
            catch { }
        }
    }
}
