using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using IntexTwo.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IntexTwo.Models;
using Microsoft.ML.OnnxRuntime;
using Microsoft.AspNetCore.Http;

namespace IntexTwo
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential 
                // cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                // requires using Microsoft.AspNetCore.Http;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            // Default Connection
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(
                    Configuration.GetConnectionString("DefaultConnection")));

            // Second Connection
            services.AddDbContext<CrashesDbContext>(options =>
                options.UseMySql(
                    Configuration.GetConnectionString("SecondConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
           // Implement HSTS
            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(356);
            });
            services.AddRazorPages();

            // !!! IMPORTANT !!!
            //VVV DOESNT RUN ON MAC BUT WE NEED THIS FOR THE PREDICTION VVV
            services.AddSingleton<InferenceSession>(
                new InferenceSession("wwwroot/intex2.onnx")
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            //app.Use(async (context, next) =>
            //{
            //    context.Response.Headers.Add("Content-Security-Policy-Report-Only", "default-src 'self'");
            //    await next();
            //});

            // CSP
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Xss-Protection", "1");
                context.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                context.Response.Headers.Add("Referrer-Policy", "no-referrer");
                context.Response.Headers.Add("Feature-Policy",
                "vibrate 'self' ; " +
                "camera 'self' ; " +
                "microphone 'self' ; " +
                "speaker 'self' https://youtube.com https://www.youtube.com ;" +
                "geolocation 'self' ; " +
                "gyroscope 'self' ; " +
                "magnetometer 'self' ; " +
                "midi 'self' ; " +
                "sync-xhr 'self' ; " +
                "push 'self' ; " +
                "notifications 'self' ; " +
                "fullscreen '*' ; " +
                "payment 'self' ; ");

                context.Response.Headers.Add(
                "Content-Security-Policy-Report-Only",
                "default-src 'self'; " +
                "script-src-elem 'self'" +
                "style-src-elem 'self'; " +
                "img-src 'self'; http://www.w3.org/" +
                "font-src 'self'" +
                "media-src 'self'" +
                "frame-src 'self'" +
                "connect-src "

                );
                await next();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "crashCity",
                    "{crashCity}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}






