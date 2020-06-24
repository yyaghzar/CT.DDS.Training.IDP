using System;
using CT.DDS.Training.IDP.Areas.Identity.Data;
using CT.DDS.Training.IDP.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CT.DDS.Training.IDP.Areas.Identity.IdentityHostingStartup))]
namespace CT.DDS.Training.IDP.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<CTDDSTrainingIDPContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("CTDDSTrainingIDPContextConnection")));

                services.AddDefaultIdentity<CTDDSTrainingIDPUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<CTDDSTrainingIDPContext>();
            });
        }
    }
}