using ContactControl.Data;
using ContactControl.Helpers;
using Microsoft.AspNetCore.Http;
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

            // INJE��O DE DEPEND�NCIA DO HTTPCONTEXTACCESSOR
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // CONFIGURANDO A INJE��O DE DEPEND�NCIA DO REPOSITORY
            builder.Services.AddScoped<IContactRepository, ContactRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ISessionUser, Session>();

            // CONFIGURANDO O COOKIE PARA SALVAR A SESS�O    
            builder.Services.AddSession(o =>
            {
                o.Cookie.HttpOnly = true;
                o.Cookie.IsEssential = true;
            });

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

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}");

            app.Run();
        }
    }
}