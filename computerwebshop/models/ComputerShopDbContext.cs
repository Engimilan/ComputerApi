using Microsoft.EntityFrameworkCore;

namespace computerwebshop.models
{
    public class ComputerShopDbContext : DbContext
    {
        public ComputerShopDbContext(DbContextOptions options) : base(options)
        {
        }

        public ComputerShopDbContext()
        {
        }

        public DbSet<Osystem>Osystems { get; set; }
        public DbSet<Comp>Comps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conn = "Server=localhost;Database=computer;User=root;Password=;";

            optionsBuilder.UseMySql(conn, ServerVersion.AutoDetect(conn));
        }
    }
}
