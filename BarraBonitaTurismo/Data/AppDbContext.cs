using Microsoft.EntityFrameworkCore;
using BarraBonitaTurismo.Models;

namespace BarraBonitaTurismo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Attraction> Attractions { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<GuideItem> GuideItems { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Seed data removido daqui para não sobrescrever dados ao recriar o banco.
            // Os dados iniciais são inseridos pelo DbInitializer apenas quando as tabelas estão vazias.
        }
    }
}
