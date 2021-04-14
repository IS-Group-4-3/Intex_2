using Amazon.S3;
using Intex_2.Data;
using Intex_2.Models;
using Intex_2.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex_2
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

            services.AddSingleton<IS3Service, S3Service>();
            services.AddAWSService<IAmazonS3>();

            services.AddDbContext<ApplicationDbContext>(options =>
                //options.UseSqlServer(
                //    Configuration.GetConnectionString("DefaultConnection")));
                options.UseSqlServer(Helpers.GetSqlConnectionString()));
            services.AddIdentity<IdentityUser, IdentityRole> //add roles to services 
                (options => options.SignIn.RequireConfirmedAccount = true)
                 .AddDefaultUI()
                 .AddEntityFrameworkStores<ApplicationDbContext>()
                 .AddDefaultTokenProviders();
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddDbContext<postgresContext>(options =>
               //options.UseNpgsql(Configuration["ConnectionStrings:DB"]));
               options.UseNpgsql(Helpers.GetPgConnectionString()));
            services.AddRazorPages()
                .AddRazorRuntimeCompilation();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("listboth",
                    "BurialsList/{locationID}/{pageNum}",
                    new { controller = "Home", action = "ListMummies", pageNum = 1 });

                endpoints.MapControllerRoute("listlocation",
                    "BurialsList/{locationID}",
                    new { controller = "Home", action = "ListMummies", pageNum = 1 });

                endpoints.MapControllerRoute("listlocation",
                    "BurialsList",
                    new { controller = "Home", action = "ListMummies", pageNum = 1 });

                endpoints.MapControllerRoute("details",
                    "Details/{locationId}",
                    new { controller = "Home", action = "DetailsMummies" });

                endpoints.MapControllerRoute("about",
                    "About",
                    new { controller = "Home", action = "About" });

                endpoints.MapControllerRoute("map",
                    "BurialMap",
                    new { controller = "Home", action = "Map" });

                endpoints.MapControllerRoute("medialibrary",
                    "MediaLibrary",
                    new { controller = "Home", action = "MediaLibary" });

                endpoints.MapControllerRoute("uploadMedia",
                    "UploadMedia",
                    new { controller = "Home", action = "UploadMedia" });

                endpoints.MapControllerRoute("huploadMedia",
                    "UploadMedia",
                    new { controller = "Home", action = "HiddenUploadMedia" });

                endpoints.MapControllerRoute("admin",
                    "Admin",
                    new { controller = "Home", action = "Admin" });

                endpoints.MapControllerRoute("manageusers",
                    "Admin/ManageUsers",
                    new { controller = "Administration", action = "ManageUsers" });

                endpoints.MapControllerRoute("addrole",
                    "Admin/AddRole",
                    new { controller = "Administration", action = "AddRole" });


                endpoints.MapControllerRoute("medialibrary",
                    "OsteologyFormPage1",
                    new { controller = "GamousLocations", action = "Create" });

                endpoints.MapControllerRoute("medialibrary",
                    "OsteologyFormPage2",
                    new { controller = "GamousMains", action = "Create" });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
