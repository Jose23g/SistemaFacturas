using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(SistemaFacturas.Areas.Identity.IdentityHostingStartup))]
namespace SistemaFacturas.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}