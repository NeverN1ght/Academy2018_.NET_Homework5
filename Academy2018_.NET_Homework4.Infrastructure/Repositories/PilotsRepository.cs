using System.Collections.Generic;
using System.Linq;
using Academy2018_.NET_Homework5.Infrastructure.Abstractions;
using Academy2018_.NET_Homework5.Infrastructure.Database;
using Academy2018_.NET_Homework5.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Academy2018_.NET_Homework5.Infrastructure.Repositories
{
    public class PilotsRepository: IRepository<Pilot>
    {
        private readonly AirportContext _ctx;

        public PilotsRepository(AirportContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Pilot> Get()
        {
            return _ctx.Pilots;
        }

        public object Create(Pilot entity)
        {
            _ctx.Pilots.Add(entity);

            // make save to get created entity id
            _ctx.SaveChanges();
            return entity.Id;
        }

        public void Update(object id, Pilot entity)
        {
            entity.Id = (int)id;
            var existedEntity = _ctx.Pilots.Find((int)id);
            _ctx.Entry(existedEntity).CurrentValues.SetValues(entity);
        }

        public void Delete(object id)
        {
            var entity = _ctx.Pilots.Find(id);
            Delete(entity);
        }

        public void Delete(Pilot entity)
        {
            _ctx.Pilots.Remove(entity);
        }

        public bool IsExist(object id)
        {
            return _ctx.Pilots.FirstOrDefault(p => p.Id == (int) id) != null;
        }
    }
}
