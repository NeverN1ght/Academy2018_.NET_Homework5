using System.Collections.Generic;
using System.Linq;
using Academy2018_.NET_Homework5.Infrastructure.Abstractions;
using Academy2018_.NET_Homework5.Infrastructure.Data;
using Academy2018_.NET_Homework5.Infrastructure.Database;
using Academy2018_.NET_Homework5.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Academy2018_.NET_Homework5.Infrastructure.Repositories
{
    public class CrewsRepository: IRepository<Crew>
    {
        private readonly AirportContext _ctx;

        public CrewsRepository(AirportContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Crew> Get()
        {
            return _ctx.Crews
                .Include(c => c.Pilot)
                .Include(c => c.Stewardesses);
        }

        public object Create(Crew entity)
        {
            _ctx.Crews.Add(entity);

            // make save to get created entity id
            _ctx.SaveChanges();
            return entity.Id;
        }

        public void Update(object id, Crew entity)
        {
            entity.Id = (int)id;
            var existedEntity = _ctx.Crews.Find((int)id);
            _ctx.Entry(existedEntity).CurrentValues.SetValues(entity);
        }

        public void Delete(object id)
        {
            var entity = _ctx.Crews.Find((int) id);
            Delete(entity);
        }

        public void Delete(Crew entity)
        {
            _ctx.Crews.Remove(entity);
        }

        public bool IsExist(object id)
        {
            return _ctx.Crews.FirstOrDefault(c => c.Id == (int) id) != null;
        }
    }
}
