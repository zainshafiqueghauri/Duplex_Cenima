using DuplexCenima.Data;
using DuplexCenima.Data.Cart;
using DuplexCenima.Data.Services;
using DuplexCenima.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DuplexCenima
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //db configuration 
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

            //services configuration
            builder.Services.AddScoped<iActorServices, ActorService>();
            //producers services
            builder.Services.AddScoped<iProducersServices, ProducersService>();
            //cinema Service
            builder.Services.AddScoped<iCinemasService, CinemaService>();
            //Movies Service
            builder.Services.AddScoped<iMoviesService, MoviesService>();
            //order services
            builder.Services.AddScoped<IOrdersService, OrdersService>();
             
            //shopping cart
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));

            //authentication and authorization
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();
            builder.Services.AddMemoryCache();
            builder.Services.AddSession();
            builder.Services.AddAuthentication(option =>
            {
                option.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            });
            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            //authentication and authorization
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            //seed database
            AppDbInitializer.Seed(app);
            AppDbInitializer.SeedUsersAndRolesAsync(app).Wait();


            app.Run();
        }
    }
}