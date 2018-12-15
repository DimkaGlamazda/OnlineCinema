using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineCinema.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCinema.API
{
	public partial class Startup
	{
        public void CreateRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var admin = UserManager.Users.FirstOrDefault(c => c.UserName == "gldmvl@gmail.com");

            if (admin == null)
            {
                //Here we create a Admin super user who will maintain the website                  

                var user = new ApplicationUser();

                // Dima
                user.UserName = "gldmvl@gmail.com";
                user.Email = "gldmvl@gmail.com";

                string userPWD = "Q1234-4321";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }
            }

            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin rool   
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
                
            }

            // creating Creating customer role    
            if (!roleManager.RoleExists("customer"))
            {
                var role = new IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);
            }

        }
    }
}