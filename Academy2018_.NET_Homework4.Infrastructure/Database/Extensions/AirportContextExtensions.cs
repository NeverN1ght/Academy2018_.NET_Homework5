using System;
using System.Collections.Generic;
using System.Linq;
using Academy2018_.NET_Homework5.Infrastructure.Models;

namespace Academy2018_.NET_Homework5.Infrastructure.Database.Extensions
{
    public static class AirportContextExtensions
    {
        public static void EnsureDatabaseSeeded(this AirportContext context)
        {
            if (!context.Pilots.Any())
            {
                context.AddRange(new Pilot[]
                {
                    new Pilot
                    {
                        FirstName = "Petro",
                        LastName = "Chernov",
                        Birthdate = new DateTime(1990, 2, 5),
                        Experience = 5
                    },
                    new Pilot
                    {
                        FirstName = "Alex",
                        LastName = "Yaschenko",
                        Birthdate = new DateTime(1983, 6, 28),
                        Experience = 3
                    },
                    new Pilot
                    {
                        FirstName = "Ivan",
                        LastName = "Golub",
                        Birthdate = new DateTime(1993, 12, 31),
                        Experience = 1
                    },
                    new Pilot
                    {
                        FirstName = "Anrew",
                        LastName = "Novikov",
                        Birthdate = new DateTime(1975, 8, 14),
                        Experience = 8
                    }
                });
                context.SaveChanges();
            }
            

            if (!context.Stewardesses.Any())
            {
                context.AddRange(new Stewardesse[]
                {
                    new Stewardesse {
                        FirstName = "Natalia",
                        LastName = "Korobko",
                        Birthdate = new DateTime(1986, 5, 21)
                    },
                    new Stewardesse
                    {
                        FirstName = "Olha",
                        LastName = "Bilyk",
                        Birthdate = new DateTime(1979, 6, 27)
                    },
                    new Stewardesse
                    {
                        FirstName = "Nina",
                        LastName = "Ivanova",
                        Birthdate = new DateTime(1995, 9, 17)
                    },
                    new Stewardesse
                    {
                        FirstName = "Viktoria",
                        LastName = "Petrova",
                        Birthdate = new DateTime(1997, 7, 17)
                    },
                    new Stewardesse
                    {
                        FirstName = "Daria",
                        LastName = "Kolomiets",
                        Birthdate = new DateTime(1991, 3, 13)
                    },
                    new Stewardesse
                    {
                        FirstName = "Maria",
                        LastName = "Bondarenko",
                        Birthdate = new DateTime(1994, 10, 5)
                    },
                    new Stewardesse
                    {
                        FirstName = "Anastasia",
                        LastName = "Golovko",
                        Birthdate = new DateTime(1989, 12, 25)
                    }
                });
                context.SaveChanges();
            }

            if (!context.Crews.Any())
            {
                context.AddRange(new Crew[]
                {
                    new Crew
                {
                    Pilot = new Pilot
                    {
                        Birthdate = new DateTime(1987, 3 , 1),
                        Experience = 6,
                        FirstName = "Sasha",
                        LastName = "Saharov"
                    },
                    Stewardesses = new List<Stewardesse> {
                        new Stewardesse
                        {
                            Birthdate = new DateTime(1989, 1, 2),
                            FirstName = "Samira",
                            LastName = "Elbrus"
                        },
                        new Stewardesse
                        {
                            Birthdate = new DateTime(1989, 1, 3),
                            FirstName = "Elvira",
                            LastName = "Elbrus"
                        }
                    }
                },
                new Crew
                {
                    Pilot = new Pilot
                    {
                        Birthdate = new DateTime(1991, 12, 2),
                        FirstName = "Maxim",
                        LastName = "Suvorov",
                        Experience = 15
                    },
                    Stewardesses = new List<Stewardesse> {
                        new Stewardesse
                        {
                            Birthdate = new DateTime(1989, 1, 5),
                            FirstName = "Valeriya",
                            LastName = "Solomko"
                        }
                    }
                },
                new Crew
                {
                    Pilot = new Pilot
                    {
                        Birthdate = new DateTime(1991, 10, 2),
                        FirstName = "Vadim",
                        LastName = "Melnik",
                        Experience = 15
                    },
                    Stewardesses = new List<Stewardesse> {
                        new Stewardesse
                        {
                            Birthdate = new DateTime(1979, 2, 5),
                            FirstName = "Irina",
                            LastName = "Natamina"
                        }
                    }
                }
                });
                context.SaveChanges();
            }

            if (!context.AirplaneTypes.Any())
            {
                context.AddRange(new AirplaneType[]
                {
                    new AirplaneType
                    {
                        AirplaneModel = "Typolev Ty-134",
                        CarryingCapacity = 47000,
                        SeatsCount = 96
                    },
                    new AirplaneType
                    {
                        AirplaneModel = "Typolev Ty-154",
                        CarryingCapacity = 52000,
                        SeatsCount = 158
                    },
                    new AirplaneType
                    {
                        AirplaneModel = "Sukhoi SuperJet-100",
                        CarryingCapacity = 45900,
                        SeatsCount = 86
                    },
                    new AirplaneType
                    {
                        AirplaneModel = "Illyushin IL-62",
                        CarryingCapacity = 280300,
                        SeatsCount = 198
                    },
                    new AirplaneType
                    {
                        AirplaneModel = "Airbus A310",
                        CarryingCapacity = 164000,
                        SeatsCount = 183
                    }
                });
                context.SaveChanges();
            }

            if (!context.Airplanes.Any())
            {
                context.Airplanes.AddRange(new Airplane[]
                {
                    new Airplane
                    {
                        Name = "A. Dayneka",
                        Type = new AirplaneType
                        {
                            AirplaneModel = "NYA-226",
                            CarryingCapacity = 15000,
                            SeatsCount = 987
                        },
                        ExploitationTerm = TimeSpan.FromTicks(100000000),
                        ReleaseDate = new DateTime(1985, 5, 21)
                    },
                    new Airplane
                    {
                        Name = "Manchester United",
                        Type = new AirplaneType
                        {
                            AirplaneModel = "MNA-566",
                            CarryingCapacity = 19000,
                            SeatsCount = 876
                        },
                        ExploitationTerm = TimeSpan.FromTicks(5000000),
                        ReleaseDate = new DateTime(1990, 7, 12)
                    },
                    new Airplane
                    {
                        Name = "Retro",
                        Type = new AirplaneType
                        {
                            AirplaneModel = "OKA-221",
                            CarryingCapacity = 30000,
                            SeatsCount = 658
                        },
                        ExploitationTerm = TimeSpan.FromTicks(8000000),
                        ReleaseDate = new DateTime(1980, 12, 11)
                    }
                });
                context.SaveChanges();
            }

            if (!context.Flights.Any())
            {
                context.Flights.AddRange(new Flight[]
                {
                    new Flight
                {
                    Number = "DY-2891",
                    ArrivalTime = new DateTime(2018, 07, 12, 12, 24, 0),
                    DeparturePoint = "Borispol, Ukraine",
                    DestinationPoint = "New York, USA",
                    Tickets = new List<Ticket>
                    {
                        new Ticket
                        {
                            FlightNumber = "DY-2891",
                            Price = 300
                        },
                        new Ticket
                        {
                            FlightNumber = "DY-2891",
                            Price = 600
                        }
                    }
                },
                new Flight
                {
                    Number = "AC-3948",
                    ArrivalTime = new DateTime(2018, 08, 15, 14, 12, 0),
                    DeparturePoint = "Borispol, Ukraine",
                    DestinationPoint = "Moscow, Russia",
                    Tickets = new List<Ticket>
                    {
                        new Ticket
                        {
                            FlightNumber = "AC-3948",
                            Price = 400
                        },
                        new Ticket
                        {
                            FlightNumber = "AC-3948",
                            Price = 700
                        }
                    }
                },
                new Flight
                {
                    Number = "KO-8712",
                    ArrivalTime = new DateTime(2018, 10, 5, 20, 21, 0),
                    DeparturePoint = "Borispol, Ukraine",
                    DestinationPoint = "Katowice, Poland",
                    Tickets = new List<Ticket>
                    {
                        new Ticket
                        {
                            FlightNumber = "KO-8712",
                            Price = 1300
                        },
                        new Ticket
                        {
                            FlightNumber = "KO-8712",
                            Price = 6000
                        }
                    }
                }
                });
                context.SaveChanges();
            }

            if (!context.Tickets.Any())
            {
                context.Tickets.AddRange(new Ticket[]
                {
                    new Ticket
                    {
                        FlightNumber = "AC-3948",
                        Price = 200m
                    },
                    new Ticket
                    {
                        FlightNumber = "KO-8712",
                        Price = 400m
                    },
                    new Ticket
                    {
                        FlightNumber = "DY-2891",
                        Price = 600m
                    },
                    new Ticket
                    {
                        FlightNumber = "KO-8712",
                        Price = 100m
                    },
                    new Ticket
                    {
                        FlightNumber = "DY-2891",
                        Price = 150m
                    },
                    new Ticket
                    {
                        FlightNumber = "KO-8712",
                        Price = 450m
                    }
                });
                context.SaveChanges();
            }

            if (!context.Departures.Any())
            {
                context.AddRange(new Departure[]
                {
                    new Departure
                    {
                        FlightNumber = "AM-2325",
                        Airplane = new Airplane
                        {
                            ExploitationTerm = TimeSpan.FromTicks(7000000),
                            Name = "FirstClassPlane",
                            Type = new AirplaneType
                            {
                                SeatsCount = 879,
                                AirplaneModel = "AR-228",
                                CarryingCapacity = 25000
                            }
                        },
                        Crew = new Crew
                        {
                            Stewardesses = new List<Stewardesse>
                            {
                                new Stewardesse
                                {
                                    Birthdate = new DateTime(1987, 12, 15),
                                    FirstName = "Larisa",
                                    LastName = "Bolinskaya"
                                }
                            },
                            Pilot = new Pilot
                            {
                                Birthdate = new DateTime(1978, 5, 21),
                                FirstName = "Bohdan",
                                LastName = "Klavimak",
                                Experience = 21
                            }
                        },
                        DepartureTime = new DateTime(2018, 10, 21, 20, 22, 0)
                    }
                });
                context.SaveChanges();
            }
        }
    }
}
