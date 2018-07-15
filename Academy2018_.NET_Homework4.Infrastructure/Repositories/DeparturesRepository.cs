using System.Collections.Generic;
using System.Linq;
using Academy2018_.NET_Homework5.Infrastructure.Abstractions;
using Academy2018_.NET_Homework5.Infrastructure.Data;
using Academy2018_.NET_Homework5.Infrastructure.Database;
using Academy2018_.NET_Homework5.Infrastructure.Models;
using Academy2018_.NET_Homework5.Infrastructure.Repositories.Basic;
using Microsoft.EntityFrameworkCore;

namespace Academy2018_.NET_Homework5.Infrastructure.Repositories
{
    public class DeparturesRepository: BasicRepository<Departure>
    {
        private readonly AirportContext _ctx;

        public DeparturesRepository(AirportContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public override IEnumerable<Departure> Get()
        {
            return _ctx.Departures
                .Include(d => d.Airplane)
                .Include(d => d.Airplane.Type)
                .Include(d => d.Crew)
                .Include(d => d.Crew.Pilot)
                .Include(d => d.Crew.Stewardesses);
        }
    }
}
