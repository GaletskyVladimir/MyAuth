using Microsoft.AspNetCore.Identity;
using MyAuth.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAuth.Initializers
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            string adminEmail = "admin@gmail.com";
            string password = "Nidsf473!";

            string stringUserName = "wowa@gmail.com";
            string userPass = "Test123!";

            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new AppRole("admin"));
            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new AppRole("user"));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                AppUser admin = new AppUser { Email = adminEmail, UserName = adminEmail };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
            if (await userManager.FindByNameAsync(stringUserName) == null)
            {
                AppUser user = new AppUser { Email = stringUserName, UserName = stringUserName };
                IdentityResult result = await userManager.CreateAsync(user, userPass);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "user");
                }
            }
        }
    }
}
