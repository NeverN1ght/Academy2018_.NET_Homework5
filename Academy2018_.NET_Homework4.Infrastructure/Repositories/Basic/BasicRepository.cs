using System.Collections.Generic;
using System.Linq;
using Academy2018_.NET_Homework5.Infrastructure.Abstractions;
using Academy2018_.NET_Homework5.Infrastructure.Database;

namespace Academy2018_.NET_Homework5.Infrastructure.Repositories.Basic
{
    public abstract class BasicRepository<TEntity>: IRepository<TEntity> 
        where TEntity : class, IEntity
    {
        private readonly AirportContext _ctx;

        protected BasicRepository()
        {         
        }

        protected BasicRepository(AirportContext ctx): this()
        {
            _ctx = ctx;
        }

        public virtual IEnumerable<TEntity> Get()
        {
            return _ctx.Set<TEntity>();
        }

        public TEntity Get(object id)
        {
            return _ctx.Set<TEntity>().Find(id);
        }

        public object Create(TEntity entity)
        {
            _ctx.Set<TEntity>().Add(entity);

            // make save to get created entity id
            _ctx.SaveChanges();
            return entity.Id;
        }

        public void Update(object id, TEntity entity)
        {
            entity.Id = (int)id;
            var existedEntity = _ctx.Set<TEntity>().Find(id);
            _ctx.Entry(existedEntity).CurrentValues.SetValues(entity);
        }

        public void Delete(object id)
        {
            var entity = _ctx.Set<TEntity>().Find(id);
            Delete(entity);
        }

        public void Delete(TEntity entity)
        {
            _ctx.Set<TEntity>().Remove(entity);
        }

        public bool IsExist(object id)
        {
            return _ctx.Set<TEntity>().Find(id) != null;
        }
    }
}
