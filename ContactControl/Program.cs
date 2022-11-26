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

            // CONFIGURANDO A INJE��O DE DEPEND�NCIA DO REPOSITORY
            builder.Services.AddScoped<IContactRepository, ContactRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();


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
                pattern: "{controller=Login}/{action=Index}/{id?}");

            app.Run();
        }
    }
}