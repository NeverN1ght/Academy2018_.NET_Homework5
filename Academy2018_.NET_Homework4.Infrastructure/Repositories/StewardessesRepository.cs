using System.Collections.Generic;
using System.Linq;
using Academy2018_.NET_Homework5.Infrastructure.Abstractions;
using Academy2018_.NET_Homework5.Infrastructure.Data;
using Academy2018_.NET_Homework5.Infrastructure.Database;
using Academy2018_.NET_Homework5.Infrastructure.Models;

namespace Academy2018_.NET_Homework5.Infrastructure.Repositories
{
    public class StewardessesRepository: IRepository<Stewardesse>
    {
        private readonly AirportContext _ctx;

        public StewardessesRepository(AirportContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Stewardesse> Get()
        {
            return _ctx.Stewardesses;
        }

        public object Create(Stewardesse entity)
        {
            _ctx.Stewardesses.Add(entity);

            // make save to get created entity id
            _ctx.SaveChanges();
            return entity.Id;
        }

        public void Update(object id, Stewardesse entity)
        {
            entity.Id = (int)id;
            var existedEntity = _ctx.Stewardesses.Find((int)id);
            _ctx.Entry(existedEntity).CurrentValues.SetValues(entity);
        }

        public void Delete(object id)
        {
            var entity = _ctx.Stewardesses.Find((int)id);
            Delete(entity);
        }

        public void Delete(Stewardesse entity)
        {
            _ctx.Stewardesses.Remove(entity);
        }

        public bool IsExist(object id)
        {
            return _ctx.Stewardesses.FirstOrDefault(s => s.Id == (int) id) != null;
        }
    }
}
