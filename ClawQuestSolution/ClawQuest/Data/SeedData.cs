using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace ClawQuest.Data
{
    public static class SeedData
    {

        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            #region Seed Users and Roles
            using (UserManager<IdentityUser> _userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>())
            using (RoleManager<IdentityRole> _roleManager = serviceProvider.GetRequiredService <RoleManager<IdentityRole>>())
            {

                var userlist = new List<SeedUserModel>()
            {
                new SeedUserModel(){ UserName="miltonshaw@clawquest.com", Password= "Admin123!" },
                new SeedUserModel(){ UserName ="davidbutler@gmail.com", Password="Skyisblue123!"}
            };

                foreach (var user in userlist)
                {
                    if (!_userManager.Users.Any(r => r.UserName == user.UserName))
                    {
                        var newuser = new IdentityUser { UserName = user.UserName, Email = user.UserName };
                        var result = await _userManager.CreateAsync(newuser, user.Password);
                    }

                    string roleName = user.UserName == "miltonshaw@clawquest.com" ? "Administrator" : "Player";
                    var role = await _roleManager.FindByNameAsync(roleName);
                    if (role == null)
                    {
                        await _roleManager.CreateAsync(new IdentityRole(roleName));
                    }

                    var existingUser = await _userManager.FindByNameAsync(user.UserName);
                    await _userManager.AddToRoleAsync(existingUser, roleName);
                }
            }
            #endregion

            #region Seed Toys
            using (var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>())
            {
                if (!dbContext.Toys.Any())
                {
                    var toyNames = new string[]
                    {
                        "Mega Plushie", "Teddy Bear", "Squid Plushie",
                        "Action Figure", "Remote Control Car", "Board Game",
                        "Doll House", "LEGO Set", "Puzzle",
                        "Robot Kit", "Super Soaker Water Gun", "Science Kit",
                        "Basketball", "Toy Kitchen Set", "Art Supplies"
                    };

                    var toys = toyNames.Select(name => new Toy { Name = name });

                    dbContext.Toys.AddRange(toys);
                    dbContext.SaveChanges();
                }
            }
            #endregion
        }
    }
}
