using Microsoft.EntityFrameworkCore;
using next_world_api.Model;
using System.Text.Json;

namespace next_world_api.Data
{
    public class ComicsContext : DbContext
    {
        public ComicsContext(DbContextOptions<ComicsContext> options) : base(options)
        {
        }

        public DbSet<Capitulos> Caps { get; set; }
        public DbSet<Contas> Contas { get; set; }
        public DbSet<Paginas> Paginas { get; set; }
        public DbSet<Hq> Hq { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hq>()
                .Property(h => h.generos)
                .HasColumnType("jsonb")
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                    v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions?)null)
                );
            /*modelBuilder.Entity<Capitulos>()
                .Property(h => h.paginas)
                .HasColumnType("jsonb")
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                    v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions?)null)
                );*/

            base.OnModelCreating(modelBuilder);
        }
    }
}
