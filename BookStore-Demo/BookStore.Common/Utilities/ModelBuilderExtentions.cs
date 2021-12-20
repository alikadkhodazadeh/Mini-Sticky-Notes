namespace BookStore.Common
{
    public static class ModelBuilderExtentions
    {
        #region Pluralizer
        public static void AddSingularizingTableNameConvention(this ModelBuilder modelBuilder)
        {
            Pluralizer pluralizer = new Pluralizer();
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                string? tableName = entityType.GetTableName();
                entityType.SetTableName(pluralizer.Singularize(tableName));
            }
        }

        public static void AddPluralizingTableNameConvention(this ModelBuilder modelBuilder)
        {
            Pluralizer pluralizer = new Pluralizer();
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                string? tableName = entityType.GetTableName();
                entityType.SetTableName(pluralizer.Pluralize(tableName));
            }
        }
        #endregion

        #region Default Value
        public static void AddSequentialGuidForIdConvention(this ModelBuilder modelBuilder)
        {
            modelBuilder.AddDefaultValueSqlConvention("Id", typeof(Guid), "NEWSEQUENTIALID()");
        }

        public static void AddDefaultValueSqlConvention(this ModelBuilder modelBuilder, string propertyName, Type propertyType, string defaultValueSql)
        {
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                IMutableProperty? property = entityType.GetProperties().SingleOrDefault(p => p.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase));
                if (property is not null && property.ClrType == propertyType)
                    property.SetDefaultValueSql(defaultValueSql);
            }
        }
        #endregion

        #region Delete Behavior
        public static void AddRestrictDeleteBehaviorConvention(this ModelBuilder modelBuilder)
        {
            IEnumerable<IMutableForeignKey> cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (IMutableForeignKey fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;
        }
        #endregion

        #region Entity Configuration
        public static void RegisterEntityTypeConfiguration(this ModelBuilder modelBuilder, params Assembly[] assemblies)
        {
            MethodInfo applyGenericMethod = typeof(ModelBuilder).GetMethods().First(m => m.Name == nameof(ModelBuilder.ApplyConfiguration));

            IEnumerable<Type> types = assemblies.SelectMany(a => a.GetExportedTypes())
                .Where(c => c.IsClass && !c.IsAbstract && c.IsPublic);

            foreach (Type type in types)
            {
                foreach (Type iface in type.GetInterfaces())
                {
                    if (iface.IsConstructedGenericType && iface.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
                    {
                        MethodInfo applyConcreteMethod = applyGenericMethod.MakeGenericMethod(iface.GenericTypeArguments[0]);
                        applyConcreteMethod.Invoke(modelBuilder, new object[] { Activator.CreateInstance(type) });
                    }
                }
            }
        }
        #endregion

        #region Register Entities
        public static void RegisterAllEntities<BaseType>(this ModelBuilder modelBuilder, params Assembly[] assemblies)
        {
            IEnumerable<Type> types = assemblies.SelectMany(a => a.GetExportedTypes())
                .Where(c => c.IsClass && !c.IsAbstract && c.IsPublic && typeof(BaseType).IsAssignableFrom(c));

            foreach (Type type in types)
                modelBuilder.Entity(type);
        }
        #endregion

        #region Delete AspNet In Identity Tables
        public static void DeleteAspNetInIdentityTables(this ModelBuilder modelBuilder)
        {
            IEnumerable<IMutableEntityType> entities = modelBuilder.Model.GetEntityTypes()
                .Where(p => p.GetTableName().Contains("AspNet", StringComparison.OrdinalIgnoreCase));

            foreach (var item in entities)
            {
                string newName = item.GetTableName().Replace("AspNet", "");
                item.SetTableName(newName);
            }
        }
        #endregion
    }
}
