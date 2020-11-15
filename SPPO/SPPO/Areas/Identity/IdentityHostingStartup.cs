using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SPPO.Areas.Identity.Data;
using SPPO.Data;

[assembly: HostingStartup(typeof(SPPO.Areas.Identity.IdentityHostingStartup))]
namespace SPPO.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<SPPOContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("SPPOContextConnection")));

                services.AddDefaultIdentity<SPPOUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<SPPOContext>();
            });
        }
    }
}