using Academy2018_.NET_Homework5.Infrastructure.Abstractions;
using Academy2018_.NET_Homework5.Infrastructure.Database;
using Academy2018_.NET_Homework5.Infrastructure.Models;
using Academy2018_.NET_Homework5.Infrastructure.Repositories;

namespace Academy2018_.NET_Homework5.Infrastructure.UnitOfWork
{
    public class UnitOfWork
    {
        private readonly AirportContext _ctx;

        private IRepository<Airplane> _airplaneRepository;
        private IRepository<AirplaneType> _airplaneTypeRepository;
        private IRepository<Crew> _crewRepository;
        private IRepository<Departure> _deaprtureRepository;
        private IRepository<Flight> _flightRepository;
        private IRepository<Pilot> _pilotRepository;
        private IRepository<Stewardesse> _stewardesseRepository;
        private IRepository<Ticket> _ticketRepository;

        public UnitOfWork(AirportContext ctx)
        {
            _ctx = ctx;
        }

        public IRepository<Airplane> Airplanes
        {
            get
            {
                if (_airplaneRepository == null)
                    _airplaneRepository = new AirplanesRepository(_ctx);
                return _airplaneRepository;
            }
        }

        public IRepository<Pilot> Pilots
        {
            get
            {
                if (_pilotRepository == null)
                    _pilotRepository = new PilotsRepository(_ctx);
                return _pilotRepository;
            }
        }

        public IRepository<Stewardesse> Stewardesses
        {
            get
            {
                if (_stewardesseRepository == null)
                    _stewardesseRepository = new StewardessesRepository(_ctx);
                return _stewardesseRepository;
            }
        }

        public IRepository<Ticket> Tickets
        {
            get
            {
                if (_ticketRepository == null)
                    _ticketRepository = new TicketsRepository(_ctx);
                return _ticketRepository;
            }
        }

        public IRepository<Crew> Crews
        {
            get
            {
                if (_crewRepository == null)
                    _crewRepository = new CrewsRepository(_ctx);
                return _crewRepository;
            }
        }

        public IRepository<Flight> Flights
        {
            get
            {
                if (_flightRepository == null)
                    _flightRepository = new FlightsRepository(_ctx);
                return _flightRepository;
            }
        }

        public IRepository<Departure> Departures
        {
            get
            {
                if (_deaprtureRepository == null)
                    _deaprtureRepository = new DeparturesRepository(_ctx);
                return _deaprtureRepository;
            }
        }

        public IRepository<AirplaneType> AirplaneTypes
        {
            get
            {
                if (_airplaneTypeRepository == null)
                    _airplaneTypeRepository = new AirplaneTypesRepository(_ctx);
                return _airplaneTypeRepository;
            }
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }
    }
}
