
using Microsoft.OpenApi;

namespace CRM.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            

            builder.Services.AddControllers();
         
            builder.Services.AddOpenApi();
            builder.Services.AddSwaggerGen(setup =>
            {
                setup.SwaggerDoc("v1",new OpenApiInfo { Title = "CRM API",Version = "v1"});
            });

            var app = builder.Build();

         
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(setup => setup.SwaggerEndpoint("/swagger/v1/swagger.json", "CRM API V1"));
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
