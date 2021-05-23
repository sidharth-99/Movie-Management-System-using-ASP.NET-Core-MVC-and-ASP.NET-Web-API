using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieData.Models;
using MovieRepo.Models;
using Microsoft.EntityFrameworkCore;
using ModelsLibrary;
using System.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MovieManagementWeb
{
    public class Startup
    {
        public IConfiguration conf;
        public Startup(IConfiguration c)
        {
            conf = c;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen();

            services.AddDbContext<Moviecontext>(op => op.UseSqlServer(conf.GetConnectionString("moviecon")));
            services.AddTransient<Movieinterface, Movieclass>();
            services.AddMvc();

            services.AddDbContext<UserRolecontext>(options => options.UseSqlServer(conf.GetConnectionString("moviecon")));
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<UserRolecontext>().AddDefaultTokenProviders();



            //services.AddMvc().AddSessionStateTempDataProvider();
            //services.AddDistributedMemoryCache();
            //services.AddSession();
            //services.AddAuthentication(auth =>
            //{
            //    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(token =>
            //{
            //    token.RequireHttpsMetadata = false;
            //    token.SaveToken = true;
            //    token.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        //Same Secret key will be used while creating the token
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(conf["Jwt:Key"])),
            //        ValidateIssuer = true,
            //        //Usually, this is your application base URL
            //        ValidIssuer = conf["Jwt:Issuer"],
            //        ValidateAudience = true,
            //        //Here, we are creating and using JWT within the same application.
            //        //In this case, base URL is fine.
            //        //If the JWT is created using a web service, then this would be the consumer URL.
            //        ValidAudience = conf["Jwt:Issuer"],
            //        RequireExpirationTime = true,
            //        ValidateLifetime = true,
            //        ClockSkew = TimeSpan.Zero
            //    };
            //});


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStatusCodePagesWithRedirects("~/account/Index");
            //else
            //{
            //    app.UseEndpoints(endpoints =>
            //    {
            //        endpoints.MapControllerRoute("default", "{controller=account}/{action=ErrorPage}/{id?}"); ;
            //    });
            //}
            //else part - default error page - redirect to home page 
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "crudwebapi");
            });
            app.UseStaticFiles();


            app.UseRouting();
            //app.UseCookiePolicy();

            //app.UseSession();
            ////Add JWToken to all incoming HTTP Request Header
            //app.Use(async (context, next) =>
            //{
            //    var JWToken = context.Session.GetString("JWToken");
            //    if (!string.IsNullOrEmpty(JWToken))
            //    {
            //        context.Request.Headers.Add("Authorization", "Bearer " + JWToken);
            //    }
            //    await next();
            //});
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Movie}/{action=StartPage}/{id?}"); ;
            });

            CreateRoles(serviceProvider);

        }

        private void CreateRoles(IServiceProvider serviceProvider)
        {

            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            Task<IdentityResult> roleResult;
            string name = "Admin_Sid";

            //Check that there is an Administrator role and create if not
            Task<bool> hasAdminRole = roleManager.RoleExistsAsync("Admin");
            hasAdminRole.Wait();

            if (!hasAdminRole.Result)
            {
                roleResult = roleManager.CreateAsync(new IdentityRole("Admin"));
                roleResult.Wait();
            }

            //Check that there is an Customer role and create if not
            Task<bool> hasCustomerRole = roleManager.RoleExistsAsync("Customer");
            hasCustomerRole.Wait();

            if (!hasCustomerRole.Result)
            {
                roleResult = roleManager.CreateAsync(new IdentityRole("Customer"));
                roleResult.Wait();
            }

            //Check if the admin user exists and create it if not
            //Add to the Administrator role

            Task<AppUser> testUser = userManager.FindByNameAsync(name);
            testUser.Wait();

            if (testUser.Result == null)
            {
                AppUser admin = new AppUser
                {
                    UserName = name,
                    Email = "sidharthv24@gmail.com",

                };
                Task<IdentityResult> newUser = userManager.CreateAsync(admin, "Sid*#123");
                newUser.Wait();

                if (newUser.Result.Succeeded)
                {
                    Task<IdentityResult> newUserRole = userManager.AddToRoleAsync(admin, "Admin");
                    newUserRole.Wait();
                }
            }

        }
    }
}
