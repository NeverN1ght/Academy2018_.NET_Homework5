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
    public class CrewsRepository: BasicRepository<Crew>
    {
        private readonly AirportContext _ctx;

        public CrewsRepository(AirportContext ctx): base(ctx)
        {
            _ctx = ctx;
        }

        public override IEnumerable<Crew> Get()
        {
            return _ctx.Crews
                .Include(c => c.Pilot)
                .Include(c => c.Stewardesses);
        }    
    }
}
