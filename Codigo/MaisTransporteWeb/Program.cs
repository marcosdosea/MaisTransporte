using Core;
using Core.Service;
using Service;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<MaisTransporteContext>(
                options => options.UseMySQL(builder.Configuration.GetConnectionString("MaisTransporteDatabase")));

            //inje��o depend�ncia Services
            builder.Services.AddTransient<IViagemService, ViagemService>();
            builder.Services.AddTransient<ISugerirViagemService, SugerirViagemService>();
            builder.Services.AddTransient<IUsuarioService, UsuarioService>();
            //builder.Services.AddTransient<IVeiculoService, VeiculoService>();

            // inje��o depend�ncia mappers
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
        }
    }
}