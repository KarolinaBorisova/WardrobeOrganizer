using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WardrobeOrganizer.Infrastructure.Data;

namespace WardrobeOrganizer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
                
            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<User>(options =>
            {

                options.SignIn.RequireConfirmedAccount = builder.Configuration.GetValue<bool>("Identity:RequireConfirmedAccount");
                options.SignIn.RequireConfirmedEmail = builder.Configuration.GetValue<bool>("Identity:RequireConfirmedEmail");
                options.Password.RequireDigit = builder.Configuration.GetValue<bool>("Identity:RequireDigit");
                options.Password.RequiredLength = builder.Configuration.GetValue<int>("Identity:RequiredLength"); 
                options.Password.RequireNonAlphanumeric = builder.Configuration.GetValue<bool>("Identity:RequireNonAlphanumeric"); 
                options.Password.RequireUppercase = builder.Configuration.GetValue<bool>("Identity:RequireUppercase"); 

                options.User.RequireUniqueEmail = builder.Configuration.GetValue<bool>("Identity:RequireUniqueEmail"); 
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
            });

            builder.Services.AddControllersWithViews(
               options =>
               {
                   options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
               });

            builder.Services.AddApplicationServices();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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

                endpoints.MapControllerRoute(
                 name: "areas",
                 pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
               );

                endpoints.MapControllerRoute(
               name: "default",
               pattern: "{controller=Home}/{action=Index}/{id?}"
               );


               


                // endpoints.MapControllerRoute(
                // name: "usersInfo",
                // pattern: "{controller=Home}/{action=Index}/{id?}"
                // );

                endpoints.MapRazorPages();
            });

          
           

            app.Run();
        }
    }
}