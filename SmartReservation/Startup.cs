using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmartReservation.Model;
using SmartReservation.Interface;
using SmartReservation.Service;
using SmartReservation.Areas.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace SmartReservation
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
            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer( Configuration.GetConnectionString("DefaultConnection"))); 
            //services.AddDefaultIdentity<ExternalUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>().AddClaimsPrincipalFactory<UserClaimsPrincipalFactory>();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages();
            services.AddTransient<IUserStore<ExternalUser>, UserStore>();
            services.AddTransient<IRoleStore<ExternalUserRole>, RoleStore>();
            services.AddScoped<IExternalUserRole, ExternalUserRoleService>();
            services.AddScoped<IExternalUser, ExternalUserService>();
            services.AddScoped<IExternalUserRole, ExternalUserRoleService>();
            services.AddIdentity<ExternalUser, ExternalUserRole>().AddDefaultTokenProviders().AddClaimsPrincipalFactory<UserClaimsPrincipalFactory>();
            services.AddHttpClient();
            services.Configure<PasswordHasherOptions>(options =>
                options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV2
            );

            StartupService.AddService(services);

            //services.ConfigureApplicationCookie(options => options.LoginPath = "/Identity/Account/Login");
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login";
                options.LogoutPath = "/Identity/Account/Logout";
                //options.ExpireTimeSpan = TimeSpan.FromSeconds(5);
                //options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStatusCodePagesWithReExecute("/Home/Privacy");
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}