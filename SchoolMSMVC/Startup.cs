using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using SchoolMSMVC.Models;
using System;

[assembly: OwinStartupAttribute(typeof(SchoolMSMVC.Startup))]
namespace SchoolMSMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUser();
        }

        public void createRolesandUser()
        {
            var context = new ApplicationDbContext();

            var roleManger = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            //var user = new ApplicationUser
            //{
            //    UserName = "admin",
            //    Email = "admin@gmail.com",
            //    BirthDate = DateTime.Now,
            //};


            //var password = "password";

            //var usr = userManger.Create(user, password);
            //if (usr.Succeeded)
            //{
            //    var result = userManger.AddToRole(user.Id, "Admin");
            //}

            if (!roleManger.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManger.Create(role);

            }

            if (!roleManger.RoleExists("Teacher"))
            {
                var role = new IdentityRole();//a role object
                role.Name = "Teacher";
                roleManger.Create(role);


            }
            if (!roleManger.RoleExists("Supervisor"))
            {
                var role = new IdentityRole();//a role object
                role.Name = "Supervisor";
                roleManger.Create(role);
            }


            //var user = new ApplicationUser
            //{
            //    UserName = "admin",
            //    Email = "admin@gmail.com",
            //    BirthDate = DateTime.Now,

            //};

            //var password = "password";

            //var usr = userManger.Create(user, password);


            //if (usr.Succeeded)
            //{
            //    var result = userManger.AddToRole(user.Id, "Admin");
            //}


            //if (!roleManger.RoleExists("Admin"))
            //{
            //    var role = new IdentityRole();//a role object
            //    role.Name = "Admin";
            //    roleManger.Create(role);

            //}

            //if (!roleManger.RoleExists("Teacher"))
            //{
            //    var role = new IdentityRole();//a role object
            //    role.Name = "Teacher";
            //    roleManger.Create(role);


            //}
            //if (!roleManger.RoleExists("Supervisor"))
            //{
            //    var role = new IdentityRole();//a role object
            //    role.Name = "Supervisor";
            //    roleManger.Create(role);
            //}
        }
    }
}
