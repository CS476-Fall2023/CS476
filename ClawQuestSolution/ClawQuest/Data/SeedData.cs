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
                    var toyList1 = new List<Toy>
                    {
                        new Toy { Name = "Mega Plushie", Points = 200, WinProbability = 0.5 },
                        new Toy { Name = "Teddy Bear", Points = 160, WinProbability = 0.7 },
                        new Toy { Name = "Squid Plushie", Points = 120, WinProbability = 0.6 },
                        new Toy { Name = "Action Figure", Points = 100, WinProbability = 0.4 },
                        new Toy { Name = "Remote Control Car", Points = 250, WinProbability = 0.8 },
                        new Toy { Name = "Board Game", Points = 190, WinProbability = 0.6 },
                        new Toy { Name = "Doll House", Points = 300, WinProbability = 0.4 },
                        new Toy { Name = "LEGO Set", Points = 250, WinProbability = 0.7 },
                        new Toy { Name = "Puzzle", Points = 150, WinProbability = 0.5 },
                        new Toy { Name = "Robot Kit", Points = 230, WinProbability = 0.6 },
                        new Toy { Name = "Super Soaker Water Gun", Points = 180, WinProbability = 0.8 },
                        new Toy { Name = "Science Kit", Points = 220, WinProbability = 0.5 },
                        new Toy { Name = "Basketball", Points = 130, WinProbability = 0.3 },
                        new Toy { Name = "Toy Kitchen Set", Points = 280, WinProbability = 0.7 },
                        new Toy { Name = "Art Supplies", Points = 170, WinProbability = 0.6 },
                    };

                    dbContext.Toys.AddRange(toyList1);
                    dbContext.SaveChanges();
                }

                if (!dbContext.ClawMachineToys.Any())
                {
                    var toyList1 = new List<ClawMachineToy>
    {
        new ClawMachineToy { ToyId = dbContext.Toys.Where(p => p.Name == "Mega Plushie").FirstOrDefault().ToyId },
        new ClawMachineToy { ToyId = dbContext.Toys.Where(p => p.Name == "Robot Kit").FirstOrDefault().ToyId },
        new ClawMachineToy { ToyId = dbContext.Toys.Where(p => p.Name == "Toy Kitchen Set").FirstOrDefault().ToyId },
        new ClawMachineToy { ToyId = dbContext.Toys.Where(p => p.Name == "Art Supplies").FirstOrDefault().ToyId },
        new ClawMachineToy { ToyId = dbContext.Toys.Where(p => p.Name == "Robot Kit").FirstOrDefault().ToyId },
        new ClawMachineToy { ToyId = dbContext.Toys.Where(p => p.Name == "Basketball").FirstOrDefault().ToyId },
        new ClawMachineToy { ToyId = dbContext.Toys.Where(p => p.Name == "Puzzle").FirstOrDefault().ToyId },
        new ClawMachineToy { ToyId = dbContext.Toys.Where(p => p.Name == "Doll House").FirstOrDefault().ToyId },
        new ClawMachineToy { ToyId = dbContext.Toys.Where(p => p.Name == "Teddy Bear").FirstOrDefault().ToyId },
        new ClawMachineToy { ToyId = dbContext.Toys.Where(p => p.Name == "Robot Kit").FirstOrDefault().ToyId },
        new ClawMachineToy { ToyId = dbContext.Toys.Where(p => p.Name == "Puzzle").FirstOrDefault().ToyId },
        new ClawMachineToy { ToyId = dbContext.Toys.Where(p => p.Name == "Board Game").FirstOrDefault().ToyId },
        new ClawMachineToy { ToyId = dbContext.Toys.Where(p => p.Name == "Action Figure").FirstOrDefault().ToyId },
        new ClawMachineToy { ToyId = dbContext.Toys.Where(p => p.Name == "Doll House").FirstOrDefault().ToyId },
        new ClawMachineToy { ToyId = dbContext.Toys.Where(p => p.Name == "Squid Plushie").FirstOrDefault().ToyId },
        new ClawMachineToy { ToyId = dbContext.Toys.Where(p => p.Name == "Remote Control Car").FirstOrDefault().ToyId },
        new ClawMachineToy { ToyId = dbContext.Toys.Where(p => p.Name == "LEGO Set").FirstOrDefault().ToyId },
        new ClawMachineToy { ToyId = dbContext.Toys.Where(p => p.Name == "Squid Plushie").FirstOrDefault().ToyId },
        new ClawMachineToy { ToyId = dbContext.Toys.Where(p => p.Name == "Mega Plushie").FirstOrDefault().ToyId },
        new ClawMachineToy { ToyId = dbContext.Toys.Where(p => p.Name == "Board Game").FirstOrDefault().ToyId },
        new ClawMachineToy { ToyId = dbContext.Toys.Where(p => p.Name == "Toy Kitchen Set").FirstOrDefault().ToyId },
        new ClawMachineToy { ToyId = dbContext.Toys.Where(p => p.Name == "Mega Plushie").FirstOrDefault().ToyId },
        new ClawMachineToy { ToyId = dbContext.Toys.Where(p => p.Name == "Basketball").FirstOrDefault().ToyId },
        new ClawMachineToy { ToyId = dbContext.Toys.Where(p => p.Name == "Super Soaker Water Gun").FirstOrDefault().ToyId },
        new ClawMachineToy { ToyId = dbContext.Toys.Where(p => p.Name == "Art Supplies").FirstOrDefault().ToyId },
    };

                    dbContext.ClawMachineToys.AddRange(toyList1);
                    dbContext.SaveChanges();
                }
            }
            #endregion
        }
    }
}
