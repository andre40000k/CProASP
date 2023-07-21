using CProASP.Transport.Cargo;
using CProASP.Transport.Transport;
using Microsoft.EntityFrameworkCore;

namespace CProASP.MiniDateBase.EFCore
{
    public class ApplicationContext : DbContext
    {
        
        public DbSet<BaseTransport> Transport => Set<BaseTransport>();
        public DbSet<CharacteristicCargo> Cargos => Set<CharacteristicCargo>();

        public ApplicationContext(DbContextOptions option) : base(option)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BaseTransport>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<CharacteristicCargo>()
                .HasKey(x => x.Id);
        }
    }
}
