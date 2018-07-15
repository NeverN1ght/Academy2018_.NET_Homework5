using System.Collections.Generic;

namespace Academy2018_.NET_Homework5.Infrastructure.Abstractions
{
    public interface IRepository<TEntity> 
        where TEntity: class
    {
        IEnumerable<TEntity> Get();

        TEntity Get(object id);

        object Create(TEntity entity);

        void Update(object id, TEntity entity);

        void Delete(object id);

        void Delete(TEntity entity);

        bool IsExist(object id);
    }
}
