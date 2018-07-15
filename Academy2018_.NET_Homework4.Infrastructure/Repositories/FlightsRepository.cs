using System;
using System.Collections.Generic;
using System.Linq;
using Academy2018_.NET_Homework5.Infrastructure.Abstractions;
using Academy2018_.NET_Homework5.Infrastructure.Data;
using Academy2018_.NET_Homework5.Infrastructure.Database;
using Academy2018_.NET_Homework5.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Academy2018_.NET_Homework5.Infrastructure.Repositories
{
    public class FlightsRepository: IRepository<Flight>
    {
        private readonly AirportContext _ctx;

        public FlightsRepository(AirportContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Flight> Get()
        {
            return _ctx.Flights
                .Include(f => f.Tickets);
        }

        public object Create(Flight entity)
        {
            _ctx.Flights.Add(entity);

            // make save to get created entity id
            _ctx.SaveChanges();
            return entity.Number;
        }

        public void Update(object id, Flight entity)
        {
            entity.Number = (string)id;
            var existedEntity = _ctx.Flights.Find((int)id);
            _ctx.Entry(existedEntity).CurrentValues.SetValues(entity);
        }

        public void Delete(object id)
        {
            var entity = _ctx.Flights.Find((string)id);
            Delete(entity);
        }

        public void Delete(Flight entity)
        {
            _ctx.Flights.Remove(entity);
        }

        public bool IsExist(object id)
        {
            return _ctx.Flights.FirstOrDefault(f => f.Number == (string) id) != null;
        }
    }
}
