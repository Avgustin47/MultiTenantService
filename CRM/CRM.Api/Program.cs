
using CRM.DataAccess;
using CRM.Service;
using CRM.Service.IService;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using System.Diagnostics;

namespace CRM.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("AppDbContext") ?? throw new InvalidOperationException("Connection string 'AppDbContext' not found.");

            builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));





            builder.Services.AddControllers();

            builder.Services.AddOpenApi();
            builder.Services.AddSwaggerGen(setup =>
            {
                setup.SwaggerDoc("v1", new OpenApiInfo { Title = "CRM API", Version = "v1" });
            });
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            var app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(setup => setup.SwaggerEndpoint("/swagger/v1/swagger.json", "CRM API V1"));
                var url = "https://localhost:7135/swagger";
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllerRoute(
                 "areas",
                 "{area:exists}:/{controller=Home}/{action=Index}/{id?}"
                 );

            app.Run();
        }
    }
}
