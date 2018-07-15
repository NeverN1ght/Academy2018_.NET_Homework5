using System.Collections.Generic;
using System.Linq;
using Academy2018_.NET_Homework5.Core.Abstractions;
using Academy2018_.NET_Homework5.Infrastructure.Abstractions;
using Academy2018_.NET_Homework5.Infrastructure.Models;
using Academy2018_.NET_Homework5.Infrastructure.UnitOfWork;
using Academy2018_.NET_Homework5.Shared.DTOs;
using Academy2018_.NET_Homework5.Shared.Exceptions;
using AutoMapper;
using FluentValidation;

namespace Academy2018_.NET_Homework5.Core.Services
{
    public class FlightsService: IService<FlightDto>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<FlightDto> _validator;

        public FlightsService(
            UnitOfWork unitOfWork,
            IMapper mapper,
            AbstractValidator<FlightDto> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public IEnumerable<FlightDto> GetAll()
        {
            return _mapper.Map<IEnumerable<Flight>, IEnumerable<FlightDto>>(
                _unitOfWork.Flights.Get());
        }

        public FlightDto GetById(object id)
        {
            var response = _mapper.Map<Flight, FlightDto>(
                _unitOfWork.Flights.Get().FirstOrDefault(f => f.Number == (string)id));

            if (response == null)
            {
                throw new NotExistException();
            }

            return response;
        }

        public object Add(FlightDto dto)
        {
            if (dto == null)
            {
                throw new NullBodyException();
            }

            var validationResult = _validator.Validate(dto);

            if (validationResult.IsValid)
            {
                return _unitOfWork.Flights.Create(
                    _mapper.Map<FlightDto, Flight>(dto));
            }

            throw new ValidationException(validationResult.Errors);
        }

        public void Update(object id, FlightDto dto)
        {
            if (dto == null)
            {
                throw new NullBodyException();
            }

            if (_unitOfWork.Flights.IsExist(id))
            {
                var validationResult = _validator.Validate(dto);

                if (validationResult.IsValid)
                {
                    _unitOfWork.Flights.Update((string)id,
                        _mapper.Map<FlightDto, Flight>(dto));

                    _unitOfWork.SaveChanges();
                }
                else
                {
                    throw new ValidationException(validationResult.Errors);
                }
            }
            else
            {
                throw new NotExistException();
            }
        }

        public void Delete(object id)
        {
            if (_unitOfWork.Flights.IsExist(id))
            {
                _unitOfWork.Flights.Delete((string)id);

                _unitOfWork.SaveChanges();
            }
            else
            {
                throw new NotExistException();
            }
        }
    }
}
