using CProASP.Transport;
using Microsoft.EntityFrameworkCore;

namespace CProASP.MiniDateBase.EFCore
{
    public class ApplicationContext : DbContext
    {
        public DbSet<BaseTransport> Transport => Set<BaseTransport>();

        public ApplicationContext(DbContextOptions option) : base(option) 
            => Database.EnsureCreated();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BaseTransport>()
                .HasKey(x => x.Id);
        }
    }
}
