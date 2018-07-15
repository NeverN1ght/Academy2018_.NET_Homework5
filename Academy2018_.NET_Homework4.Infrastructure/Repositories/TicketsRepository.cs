using System.Collections.Generic;
using System.Linq;
using Academy2018_.NET_Homework5.Infrastructure.Abstractions;
using Academy2018_.NET_Homework5.Infrastructure.Data;
using Academy2018_.NET_Homework5.Infrastructure.Database;
using Academy2018_.NET_Homework5.Infrastructure.Models;

namespace Academy2018_.NET_Homework5.Infrastructure.Repositories
{
    public class TicketsRepository: IRepository<Ticket>
    {
        private readonly AirportContext _ctx;

        public TicketsRepository(AirportContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Ticket> Get()
        {
            return _ctx.Tickets;
        }

        public object Create(Ticket entity)
        {
            _ctx.Tickets.Add(entity);

            // make save to get created entity id
            _ctx.SaveChanges();
            return entity.Id;
        }

        public void Update(object id, Ticket entity)
        {
            entity.Id = (int)id;
            var existedEntity = _ctx.Tickets.Find((int)id);
            _ctx.Entry(existedEntity).CurrentValues.SetValues(entity);
        }

        public void Delete(object id)
        {
            var entity = _ctx.Tickets.Find((int)id);
            Delete(entity);
        }

        public void Delete(Ticket entity)
        {
            _ctx.Tickets.Remove(entity);
        }

        public bool IsExist(object id)
        {
            return _ctx.Tickets.FirstOrDefault(t => t.Id == (int) id) != null;         
        }
    }
}
