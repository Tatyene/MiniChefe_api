using Microsoft.EntityFrameworkCore;
using SistemasDeReceitasMiniChefeAPI.Data;
using SistemasDeReceitasMiniChefeAPI.Repositorios;
using SistemasDeReceitasMiniChefeAPI.Repositorios.interfaces;

namespace SistemasDeReceitasMiniChefeAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkNpgsql()  
            .AddDbContext<SistemaReceitasDbContex>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DataBase")));

            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<IReceitaRepositorio, ReceitaRepositorio>();

            var app = builder.Build();

            // Desativa a criação automática do banco de dados
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<SistemaReceitasDbContex>();
                dbContext.Database.EnsureCreated(); // Evita a criação automática
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}