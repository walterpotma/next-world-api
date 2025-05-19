
using next_world_api.Repository.Interface;
using next_world_api.Repository;
using Microsoft.EntityFrameworkCore;
using next_world_api.Data;

namespace next_world_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ComicsContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("supabase")));

            builder.Services.AddScoped<IContasRepository, ContasRepository>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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
