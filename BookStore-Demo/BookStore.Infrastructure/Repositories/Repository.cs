//using BookStore.Infrastructure.Contracts;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BookStore.Infrastructure.Repositories
//{
//    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
//    {
//        protected readonly EFContext context;

//        public Repository(EFContext dbContext)
//        {
//            context = dbContext;
//            db = context.Set<TEntity>();
//        }

//        protected readonly DbSet<TEntity> db;

//        public IQueryable<TEntity> Table => db;

//        public IQueryable<TEntity> TableNoTracking => db.AsNoTracking();

//        #region Async Method
//        public virtual ValueTask<TEntity> GetByIdAsync(CancellationToken cancellationToken, params object[] ids)
//        {
//            return db.FindAsync(ids, cancellationToken);
//        }

//        public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true)
//        {
//            Assert.NotNull(entity, nameof(entity));
//            await db.AddAsync(entity, cancellationToken).ConfigureAwait(false);
//            if (saveNow)
//                await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
//        }

//        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true)
//        {
//            Assert.NotNull(entities, nameof(entities));
//            await db.AddRangeAsync(entities, cancellationToken).ConfigureAwait(false);
//            if (saveNow)
//                await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
//        }

//        public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true)
//        {
//            Assert.NotNull(entity, nameof(entity));
//            db.Update(entity);
//            if (saveNow)
//                await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
//        }

//        public virtual async Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true)
//        {
//            Assert.NotNull(entities, nameof(entities));
//            db.UpdateRange(entities);
//            if (saveNow)
//                await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
//        }

//        public virtual async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true)
//        {
//            Assert.NotNull(entity, nameof(entity));
//            db.Remove(entity);
//            if (saveNow)
//                await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
//        }

//        public virtual async Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true)
//        {
//            Assert.NotNull(entities, nameof(entities));
//            db.RemoveRange(entities);
//            if (saveNow)
//                await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
//        }
//        #endregion

//        #region Sync Methods
//        public virtual TEntity GetById(params object[] ids)
//        {
//            return db.Find(ids);
//        }

//        public virtual void Add(TEntity entity, bool saveNow = true)
//        {
//            Assert.NotNull(entity, nameof(entity));
//            db.Add(entity);
//            if (saveNow)
//                context.SaveChanges();
//        }

//        public virtual void AddRange(IEnumerable<TEntity> entities, bool saveNow = true)
//        {
//            Assert.NotNull(entities, nameof(entities));
//            db.AddRange(entities);
//            if (saveNow)
//                context.SaveChanges();
//        }

//        public virtual void Update(TEntity entity, bool saveNow = true)
//        {
//            Assert.NotNull(entity, nameof(entity));
//            db.Update(entity);
//            if (saveNow)
//                context.SaveChanges();
//        }

//        public virtual void UpdateRange(IEnumerable<TEntity> entities, bool saveNow = true)
//        {
//            Assert.NotNull(entities, nameof(entities));
//            db.UpdateRange(entities);
//            if (saveNow)
//                context.SaveChanges();
//        }

//        public virtual void Delete(TEntity entity, bool saveNow = true)
//        {
//            Assert.NotNull(entity, nameof(entity));
//            db.Remove(entity);
//            if (saveNow)
//                context.SaveChanges();
//        }

//        public virtual void DeleteRange(IEnumerable<TEntity> entities, bool saveNow = true)
//        {
//            Assert.NotNull(entities, nameof(entities));
//            db.RemoveRange(entities);
//            if (saveNow)
//                context.SaveChanges();
//        }
//        #endregion

//        #region Attach & Detach
//        public virtual void Detach(TEntity entity)
//        {
//            Assert.NotNull(entity, nameof(entity));
//            var entry = context.Entry(entity);
//            if (entry != null)
//                entry.State = EntityState.Detached;
//        }

//        public virtual void Attach(TEntity entity)
//        {
//            Assert.NotNull(entity, nameof(entity));
//            if (context.Entry(entity).State == EntityState.Detached)
//                db.Attach(entity);
//        }
//        #endregion

//        #region Explicit Loading
//        public virtual async Task LoadCollectionAsync<TProperty>(TEntity entity, Expression<Func<TEntity, IEnumerable<TProperty>>> collectionProperty, CancellationToken cancellationToken)
//            where TProperty : class
//        {
//            Attach(entity);

//            var collection = context.Entry(entity).Collection(collectionProperty);
//            if (!collection.IsLoaded)
//                await collection.LoadAsync(cancellationToken).ConfigureAwait(false);
//        }

//        public virtual void LoadCollection<TProperty>(TEntity entity, Expression<Func<TEntity, IEnumerable<TProperty>>> collectionProperty)
//            where TProperty : class
//        {
//            Attach(entity);
//            var collection = context.Entry(entity).Collection(collectionProperty);
//            if (!collection.IsLoaded)
//                collection.Load();
//        }

//        public virtual async Task LoadReferenceAsync<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> referenceProperty, CancellationToken cancellationToken)
//            where TProperty : class
//        {
//            Attach(entity);
//            var reference = context.Entry(entity).Reference(referenceProperty);
//            if (!reference.IsLoaded)
//                await reference.LoadAsync(cancellationToken).ConfigureAwait(false);
//        }

//        public virtual void LoadReference<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> referenceProperty)
//            where TProperty : class
//        {
//            Attach(entity);
//            var reference = context.Entry(entity).Reference(referenceProperty);
//            if (!reference.IsLoaded)
//                reference.Load();
//        }
//        #endregion
//    }
//}
