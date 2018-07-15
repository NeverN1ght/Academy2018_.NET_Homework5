using System.Collections.Generic;
using System.Linq;
using Academy2018_.NET_Homework5.Infrastructure.Abstractions;
using Academy2018_.NET_Homework5.Infrastructure.Database;
using Academy2018_.NET_Homework5.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Academy2018_.NET_Homework5.Infrastructure.Repositories
{
    public class AirplanesRepository: IRepository<Airplane>
    {
        private readonly AirportContext _ctx;

        public AirplanesRepository(AirportContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Airplane> Get()
        {
            return _ctx.Airplanes
                .Include(a => a.Type);
        }

        public object Create(Airplane entity)
        {
            _ctx.Airplanes.Add(entity);

            // make save to get created entity id
            _ctx.SaveChanges();
            return entity.Id;
        }

        public void Update(object id, Airplane entity)
        {
            entity.Id = (int)id;
            var existedEntity = _ctx.Airplanes.Find((int)id);
            _ctx.Entry(existedEntity).CurrentValues.SetValues(entity);
        }

        public void Delete(object id)
        {
            var entity = _ctx.Airplanes.Find(id);
            Delete(entity);
        }

        public void Delete(Airplane entity)
        {
            _ctx.Airplanes.Remove(entity);
        }

        public bool IsExist(object id)
        {
            return _ctx.Airplanes.FirstOrDefault(a => a.Id == (int) id) != null;
        }
    }
}
