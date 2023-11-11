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
            #region Seed User Roles
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                string[] roles = new string[] { "Administrator", "Player" };

                var newrolelist = new List<IdentityRole>();
                foreach (string role in roles)
                {
                    if (!context.Roles.Any(r => r.Name == role))
                    {
                        newrolelist.Add(new IdentityRole(role));
                    }
                }
                context.Roles.AddRange(newrolelist);
                context.SaveChanges();
            }
            #endregion

            #region Seed Users
            using (UserManager<IdentityUser> _userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>())
            {

                var userlist = new List<SeedUserModel>()
            {
                new SeedUserModel(){ UserName="miltonshaw@clawquest.com",Password= "Admin123!" },
                new SeedUserModel(){UserName ="davidbutler@gmail.com", Password="Skyisblue123!"}
            };

                foreach (var user in userlist)
                {
                    if (!_userManager.Users.Any(r => r.UserName == user.UserName))
                    {
                        var newuser = new IdentityUser { UserName = user.UserName, Email = user.UserName };
                        var result = await _userManager.CreateAsync(newuser, user.Password);
                    }
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
