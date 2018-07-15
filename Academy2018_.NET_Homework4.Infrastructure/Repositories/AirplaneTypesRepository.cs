using System.Collections.Generic;
using System.Linq;
using Academy2018_.NET_Homework5.Infrastructure.Abstractions;
using Academy2018_.NET_Homework5.Infrastructure.Data;
using Academy2018_.NET_Homework5.Infrastructure.Database;
using Academy2018_.NET_Homework5.Infrastructure.Models;

namespace Academy2018_.NET_Homework5.Infrastructure.Repositories
{
    public class AirplaneTypesRepository: IRepository<AirplaneType>
    {
        private readonly AirportContext _ctx;

        public AirplaneTypesRepository(AirportContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<AirplaneType> Get()
        {
            return _ctx.AirplaneTypes;
        }

        public object Create(AirplaneType entity)
        {
            _ctx.AirplaneTypes.Add(entity);

            // make save to get created entity id
            _ctx.SaveChanges();
            return entity.Id;
        }

        public void Update(object id, AirplaneType entity)
        {
            entity.Id = (int)id;
            var existedEntity = _ctx.AirplaneTypes.Find((int)id);
            _ctx.Entry(existedEntity).CurrentValues.SetValues(entity);
        }

        public void Delete(object id)
        {
            var entity = _ctx.AirplaneTypes.Find((int)id);
            Delete(entity);
        }

        public void Delete(AirplaneType entity)
        {
            _ctx.AirplaneTypes.Remove(entity);
        }

        public bool IsExist(object id)
        {
            return _ctx.AirplaneTypes.FirstOrDefault(a => a.Id == (int) id) != null;
        }
    }
}
