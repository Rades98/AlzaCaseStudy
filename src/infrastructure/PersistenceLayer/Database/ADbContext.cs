namespace PersistenceLayer.Database
{
    using ApplicationLayer.Interfaces;
    using DomainLayer.Entities.Product;
    using Extensions;
    using Microsoft.EntityFrameworkCore;

    public class ADbContext : DbContext, IDbContext
    {
        public ADbContext(DbContextOptions<ADbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(ADbContext).Assembly)
                .SeedData();
        }

        public override int SaveChanges()
        {
            ChangeStateInfo();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ChangeStateInfo();
            return base.SaveChangesAsync(cancellationToken);
        }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : class => base.Set<TEntity>();

        #region Tables

        public DbSet<ProductEntity> Products { get; set; }

        #endregion

        #region private methods 

        private void ChangeStateInfo()
        {
            ChangeTracker.Entries<ProductEntity>()
                .ToList()
                .ForEach(entry =>
                {
                    entry.Entity.Created = entry.State == EntityState.Added ? DateTime.Now : entry.Entity.Created;
                    entry.Entity.Changed = entry.State == EntityState.Modified ? DateTime.Now : entry.Entity.Changed;
                    entry.Entity.Deleted = entry.State == EntityState.Deleted ? DateTime.Now : entry.Entity.Deleted;
                });
        }

        #endregion
    }
}
