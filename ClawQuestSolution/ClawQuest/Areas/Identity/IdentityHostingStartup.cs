[assembly: HostingStartup(typeof(ClawQuest.Areas.Identity.IdentityHostingStartup))]
namespace ClawQuest.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}
