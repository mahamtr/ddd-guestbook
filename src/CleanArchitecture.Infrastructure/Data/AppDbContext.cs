using CleanArchitecture.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.SharedKernel;
using Ardalis.EFCore.Extensions;
using CleanArchitecture.Infrastructure.Data.Config;

namespace CleanArchitecture.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IDomainEventDispatcher _dispatcher;

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options, IDomainEventDispatcher dispatcher)
            : base(options)
        {
            _dispatcher = dispatcher;
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Propuesta> Propuestas { get; set; }
        public DbSet<Rubro> Rubros { get; set; }
        public DbSet<Imagen> Imagenes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new RolConfiguracion());
            modelBuilder.ApplyConfiguration(new RubroConfiguracion());
            modelBuilder.ApplyConfiguration(new PropuestaConfiguracion());


            base.OnModelCreating(modelBuilder);

        }

        public override int SaveChanges()
        {
            int result = base.SaveChanges();

            if (_dispatcher == null) return result;

            var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();


            return result;
        }
    }
}