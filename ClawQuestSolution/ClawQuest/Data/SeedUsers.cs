using Microsoft.AspNetCore.Identity;

namespace ClawQuest.Data
{
    public static class SeedUsers
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
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
        }
    }
}
