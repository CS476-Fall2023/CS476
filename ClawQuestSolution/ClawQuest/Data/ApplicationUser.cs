using Microsoft.AspNetCore.Identity;

namespace ClawQuest.Data
{
    public class ApplicationUser : IdentityUser
    {
        public virtual Game Game { get; set; }
    }
}
