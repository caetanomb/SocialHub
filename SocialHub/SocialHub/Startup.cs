using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialHub.ApplicationServices;
using SocialHub.ApplicationServices.Interfaces;
using SocialHub.Infrastructure.Data;
using SocialHub.Infrastructure.IdentityData;

namespace SocialHub
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IdentityAppDbContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("IdentityConnection"));
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityAppDbContext>()
                .AddDefaultTokenProviders();

            services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("AppConnection"));
            });

            services.AddTransient<IEmailService, EmailService>();

            //Confire security policies
            services.Configure<IdentityOptions>(opt =>
            {
                //Password settings
                opt.ClaimsIdentity.RoleClaimType = "User";

                //password settings
                opt.Password.RequireDigit = false;
                opt.Password.RequiredLength = 4;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequiredUniqueChars = 4;

                //lockout settings
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                opt.Lockout.MaxFailedAccessAttempts = 5;
                opt.Lockout.AllowedForNewUsers = false;

                //User settings
                opt.User.RequireUniqueEmail = true;

            });

            services.ConfigureApplicationCookie(opt => 
            {
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                // If the LoginPath isn't set, ASP.NET Core defaults 
                // the path to /Account/Login.
                opt.LoginPath = "/Account/Login";
                // If the AccessDeniedPath isn't set, ASP.NET Core defaults 
                // the path to /Account/AccessDenied.
                opt.AccessDeniedPath = "/Account/AccessDenied";
                opt.SlidingExpiration = true;
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
