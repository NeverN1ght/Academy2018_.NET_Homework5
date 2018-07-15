using System;
using System.Collections.Generic;
using Academy2018_.NET_Homework5.Core.Abstractions;
using Academy2018_.NET_Homework5.Core.Services;
using Academy2018_.NET_Homework5.Core.Validation;
using Academy2018_.NET_Homework5.Infrastructure.Abstractions;
using Academy2018_.NET_Homework5.Infrastructure.Data;
using Academy2018_.NET_Homework5.Infrastructure.Database;
using Academy2018_.NET_Homework5.Infrastructure.Database.Extensions;
using Academy2018_.NET_Homework5.Infrastructure.Models;
using Academy2018_.NET_Homework5.Infrastructure.Repositories;
using Academy2018_.NET_Homework5.Infrastructure.UnitOfWork;
using Academy2018_.NET_Homework5.Shared.DTOs;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Academy2018_.NET_Homework5.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSingleton<DataSource>();

            services.AddDbContext<AirportContext>();

            services.AddTransient<UnitOfWork>();

            services.AddScoped<IService<PilotDto>, PilotsService>();
            services.AddScoped<IService<FlightDto>, FlightsService>();
            services.AddScoped<IService<DepartureDto>, DeparturesService>();
            services.AddScoped<IService<StewardesseDto>, StewardessesService>();
            services.AddScoped<IService<TicketDto>, TicketsService>();
            services.AddScoped<IService<AirplaneDto>, AirplanesService>();
            services.AddScoped<IService<AirplaneTypeDto>, AirplaneTypesService>();
            services.AddScoped<IService<CrewDto>, CrewsService>();

            services.AddTransient<AbstractValidator<PilotDto>, PilotDtoValidator>();
            services.AddTransient<AbstractValidator<AirplaneDto>, AirplaneDtoValidator>();
            services.AddTransient<AbstractValidator<DepartureDto>, DepartureDtoValidator>();
            services.AddTransient<AbstractValidator<StewardesseDto>, StewardesseDtoValidator>();
            services.AddTransient<AbstractValidator<CrewDto>, CrewDtoValidator>();
            services.AddTransient<AbstractValidator<FlightDto>, FlightDtoValidator>();
            services.AddTransient<AbstractValidator<TicketDto>, TicketDtoValidator>();
            services.AddTransient<AbstractValidator<AirplaneTypeDto>, AirplaneTypeDtoValidator>();

            services.AddTransient<IRepository<Pilot>, PilotsRepository>();
            services.AddTransient<IRepository<Flight>, FlightsRepository>();
            services.AddTransient<IRepository<Departure>, DeparturesRepository>();
            services.AddTransient<IRepository<Stewardesse>, StewardessesRepository>();
            services.AddTransient<IRepository<Ticket>, TicketsRepository>();
            services.AddTransient<IRepository<Airplane>, AirplanesRepository>();
            services.AddTransient<IRepository<AirplaneType>, AirplaneTypesRepository>();
            services.AddTransient<IRepository<Crew>, CrewsRepository>();
            
            var mapper = MapperConfiguration().CreateMapper();
            services.AddTransient(_ => mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // preparing database
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<AirportContext>();
                context.EnsureDatabaseSeeded();
            }

            app.UseMvc();
        }

        public MapperConfiguration MapperConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Pilot, PilotDto>();
                cfg.CreateMap<PilotDto, Pilot>();

                cfg.CreateMap<Flight, FlightDto>();
                cfg.CreateMap<FlightDto, Flight>();

                cfg.CreateMap<Stewardesse, StewardesseDto>();
                cfg.CreateMap<StewardesseDto, Stewardesse>();

                cfg.CreateMap<Ticket, TicketDto>();
                cfg.CreateMap<TicketDto, Ticket>();

                cfg.CreateMap<Crew, CrewDto>();
                cfg.CreateMap<CrewDto, Crew>();

                cfg.CreateMap<Airplane, AirplaneDto>();
                cfg.CreateMap<AirplaneDto, Airplane>();

                cfg.CreateMap<AirplaneType, AirplaneTypeDto>();
                cfg.CreateMap<AirplaneTypeDto, AirplaneType>();

                cfg.CreateMap<Departure, DepartureDto>();
                cfg.CreateMap<DepartureDto, Departure>();
            });

            return config;
        }
    }
}
