
namespace CRM.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            

            builder.Services.AddControllers();
         
            builder.Services.AddOpenApi();

            var app = builder.Build();

         
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
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
