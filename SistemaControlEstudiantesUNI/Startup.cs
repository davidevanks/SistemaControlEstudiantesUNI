using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using SistemaControlEstudiantesUNI.Models;

[assembly: OwinStartupAttribute(typeof(SistemaControlEstudiantesUNI.Startup))]
namespace SistemaControlEstudiantesUNI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateUserAndRoles();
        }

        public void CreateUserAndRoles()
        {
            ApplicationDbContext contexto =new ApplicationDbContext();

            var rolemanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            var usermanager = new UserManager<IdentityUser>(new UserStore<IdentityUser>());

            if (!rolemanager.RoleExists("Admin"))
            {
                //Create Admin
                var role = new IdentityRole("Admin");
                rolemanager.Create(role);

                //create default user
                var user = new ApplicationUser();
                user.UserName = "sa@gmail.com";
                user.Email = "sa@gmail.com";
                string pwd = "password@2018";

                var newUser = usermanager.Create(user,pwd);
                if (newUser.Succeeded)
                {

                }

            }

        }


    }
}
