using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PROJEKTU_SKRYPTU_EBAZA.Data;

[assembly: HostingStartup(typeof(PROJEKTU_SKRYPTU_EBAZA.Areas.Identity.IdentityHostingStartup))]
namespace PROJEKTU_SKRYPTU_EBAZA.Areas.Identity
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