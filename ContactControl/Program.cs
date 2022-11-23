using ContactControl.Data;
using ContactControl.Repository;
using Microsoft.EntityFrameworkCore;

namespace ContactControl
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            var provider = builder.Services.BuildServiceProvider();

            // CONFIGURANDO A CONNECTIONSTRING
            var configuration = provider.GetRequiredService<IConfiguration>();
            builder.Services.AddDbContext<EFContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("DataBase")));

            // CONFIGURANDO A INJEÇÃO DE DEPENDÊNCIA DO REPOSITORY
            builder.Services.AddScoped<IContactRepository, ContactRepository>();


            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
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
        }
    }
}