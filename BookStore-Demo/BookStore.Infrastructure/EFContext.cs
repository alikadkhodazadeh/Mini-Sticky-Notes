using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection;

namespace BookStore.Infrastructure
{
    public class EFContext : IdentityDbContext<User,Role,string>
    {
        public EFContext(DbContextOptions<EFContext> options)
            : base(options) { }

        //public DbSet<Book> Books { get; set; }
        //public DbSet<Author> Authors { get; set; }
        //public DbSet<BookAuthor> BookAuthors { get; set; }
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<Tag> Tags { get; set; }
        //public DbSet<BookTag> BookTags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var entityAssembly = typeof(IBaseEntity).Assembly;
            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterAllEntities<IBaseEntity>(entityAssembly);
            builder.RegisterEntityTypeConfiguration(assembly, entityAssembly);

            builder.DeleteAspNetInIdentityTables();
            builder.AddRestrictDeleteBehaviorConvention();
            builder.AddSequentialGuidForIdConvention();
            builder.AddPluralizingTableNameConvention();
        }

        public override int SaveChanges()
        {
            CleanString();
            CreateUpdate();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            CleanString();
            CreateUpdate();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            CleanString();
            CreateUpdate();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            CleanString();
            CreateUpdate();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void CleanString()
        {
            var changedEntities = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var item in changedEntities)
            {
                if (item.Entity == null)
                    continue;

                var properties = item.Entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.CanWrite && p.CanWrite && p.PropertyType == typeof(string));

                foreach (var property in properties)
                {
                    string propertyName = property.Name;
                    string value = (string)property.GetValue(item.Entity, null);

                    if (value.HasValue())
                    {
                        var newValue = value.FixPersianChars().Fa2En();
                        if (newValue.Equals(value))
                            continue;

                        property.SetValue(item.Entity, newValue, null);
                    }
                }
            }
        }

        private void CreateUpdate()
        {
            var changedEntities = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entity in changedEntities)
            {
                if (entity.State == EntityState.Added)
                {
                    var property = entity.Entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .FirstOrDefault(p => p.CanWrite && p.CanRead && p.PropertyType == typeof(DateTime) &&
                    p.Name.Equals("CreationDate", StringComparison.OrdinalIgnoreCase));

                    if (property != null)
                    {
                        property.SetValue(entity.Entity, DateTime.Now, null);
                    }
                }
                else
                {
                    var property = entity.Entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .FirstOrDefault(p => p.CanWrite && p.CanRead && p.Name.Contains("LastModifyDate", StringComparison.OrdinalIgnoreCase));

                    property.SetValue(entity.Entity, DateTime.Now, null);
                }
            }
        }
    }
}
