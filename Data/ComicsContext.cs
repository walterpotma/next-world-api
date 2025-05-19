using Microsoft.EntityFrameworkCore;
using next_world_api.Model;

namespace next_world_api.Data
{
    public class ComicsContext : DbContext
    {
        public ComicsContext(DbContextOptions<ComicsContext> options) : base(options)
        { 

        }
        public DbSet<Contas> Contas { get; set; }
    }
}
