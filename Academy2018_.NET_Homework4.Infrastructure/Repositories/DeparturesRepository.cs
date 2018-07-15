using System.Collections.Generic;
using System.Linq;
using Academy2018_.NET_Homework5.Infrastructure.Abstractions;
using Academy2018_.NET_Homework5.Infrastructure.Data;
using Academy2018_.NET_Homework5.Infrastructure.Database;
using Academy2018_.NET_Homework5.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Academy2018_.NET_Homework5.Infrastructure.Repositories
{
    public class DeparturesRepository: IRepository<Departure>
    {
        private readonly AirportContext _ctx;

        public DeparturesRepository(AirportContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Departure> Get()
        {
            return _ctx.Departures
                .Include(d => d.Airplane)
                .Include(d => d.Airplane.Type)
                .Include(d => d.Crew)
                .Include(d => d.Crew.Pilot)
                .Include(d => d.Crew.Stewardesses);
        }

        public object Create(Departure entity)
        {
            _ctx.Departures.Add(entity);

            // make save to get created entity id
            _ctx.SaveChanges();
            return entity.Id;
        }

        public void Update(object id, Departure entity)
        {
            entity.Id = (int)id;
            var existedEntity = _ctx.Departures.Find((int)id);
            _ctx.Entry(existedEntity).CurrentValues.SetValues(entity);
        }

        public void Delete(object id)
        {
            var entity = _ctx.Departures.Find((int) id);
            Delete(entity);
        }

        public void Delete(Departure entity)
        {
            _ctx.Departures.Remove(entity);
        }

        public bool IsExist(object id)
        {
            return _ctx.Departures.FirstOrDefault(d => d.Id == (int) id) != null;
        }
    }
}
