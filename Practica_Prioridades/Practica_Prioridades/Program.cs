using Microsoft.EntityFrameworkCore;
using Practica_Prioridades.Components;
using Practica_Prioridades.Models;
using Practica_Prioridades.DAL;
using Practica_Prioridades.Services;

namespace Practica_Prioridades
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var ConStr = builder.Configuration.GetConnectionString("ConStr");
            builder.Services.AddDbContext<Contexto>(options => options.UseSqlite(ConStr));
            builder.Services.AddScoped<PrioridadesService>();
            builder.Services.AddScoped<ClientesService>();
            builder.Services.AddScoped<SistemasService>();
            builder.Services.AddScoped<TicketsService>();


            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
