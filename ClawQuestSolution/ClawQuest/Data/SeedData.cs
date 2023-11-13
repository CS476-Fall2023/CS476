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
                        var newuser = new IdentityUser { UserName = user.UserName, Email = user.UserName, EmailConfirmed = true };
                        var result = await _userManager.CreateAsync(newuser, user.Password);
                    }
                    else
                    {
                        // Update EmailConfirmed for existing users for local logins
                        var existingUser = await _userManager.FindByNameAsync(user.UserName);
                        if (!existingUser.EmailConfirmed)
                        {
                            existingUser.EmailConfirmed = true;
                            await _userManager.UpdateAsync(existingUser);
                        }
                    }

                    string roleName = user.UserName == "miltonshaw@clawquest.com" ? "Administrator" : "Player";
                    var role = await _roleManager.FindByNameAsync(roleName);
                    if (role == null)
                    {
                        await _roleManager.CreateAsync(new IdentityRole(roleName));
                    }

                    var updateUser = await _userManager.FindByNameAsync(user.UserName);
                    await _userManager.AddToRoleAsync(updateUser, roleName);


                }
            }
            #endregion

            #region Seed Toys
            using (var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>())
            {
                if (!dbContext.Toys.Any())
                {
                    var toyList = new List<Toy>
                    {
                        new Toy { Name = "Mega Plushie", Price = 19.99, WinProbability = 0.5 },
                        new Toy { Name = "Teddy Bear", Price = 15.99, WinProbability = 0.7 },
                        new Toy { Name = "Squid Plushie", Price = 12.99, WinProbability = 0.6 },
                        new Toy { Name = "Action Figure", Price = 9.99, WinProbability = 0.4 },
                        new Toy { Name = "Remote Control Car", Price = 24.99, WinProbability = 0.8 },
                        new Toy { Name = "Board Game", Price = 18.99, WinProbability = 0.6 },
                        new Toy { Name = "Doll House", Price = 29.99, WinProbability = 0.4 },
                        new Toy { Name = "LEGO Set", Price = 25.99, WinProbability = 0.7 },
                        new Toy { Name = "Puzzle", Price = 14.99, WinProbability = 0.5 },
                        new Toy { Name = "Robot Kit", Price = 22.99, WinProbability = 0.6 },
                        new Toy { Name = "Super Soaker Water Gun", Price = 17.99, WinProbability = 0.8 },
                        new Toy { Name = "Science Kit", Price = 21.99, WinProbability = 0.5 },
                        new Toy { Name = "Basketball", Price = 12.99, WinProbability = 0.3 },
                        new Toy { Name = "Toy Kitchen Set", Price = 27.99, WinProbability = 0.7 },
                        new Toy { Name = "Art Supplies", Price = 16.99, WinProbability = 0.6 },
                    };

                    dbContext.Toys.AddRange(toyList);
                    dbContext.SaveChanges();
                }
            }
            #endregion
        }
    }
}
