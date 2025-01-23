using Microsoft.EntityFrameworkCore;
using Tracker.WebAPIClient;
using Week1Lab12025.Models;

namespace Week1Lab12025
{
    public class Program
    {
        public static void Main(string[] args)
        {
            

            var builder = WebApplication.CreateBuilder(args);

            // Here we retrieve the connection string from the appsettings. json file
            // and create the UserContext with the connection string
            var dbConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<UserContext>(options =>
            //New Target assembly directive for migrations
            options.UseSqlServer(dbConnectionString));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();

            ActivityAPIClient.Track(StudentID: "s00221640", StudentName: "Jack Tierney",
            activityName: "Rad302 2025 Week 1 Lab 1", Task: " Project Setup ");
            //1

        }
    }
}

